using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute.ExceptionExtensions;
using SunSharp.Native;
using SunSharp.Native.Loader;

namespace SunSharp.Tests.Native.Loader;

public class NativeProxyTests
{
    private static void AssertGetFunctionByNameWasCalledForAllMethods(ILibraryHandler handler)
    {
        var methods = typeof(ISunVoxLibC).GetMethods();

        foreach (var method in methods)
        {
            handler.Received(1).GetFunctionByName(method.Name, Arg.Any<Type>());
        }
    }

    private static void AssertGetFunctionByNameWasCalledForNoMethods(ILibraryHandler handler)
    {
        handler.Received(0).GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>());
    }

    private static Dictionary<string, Delegate> PrepareHandlerAndGetDelegateDictionary(ILibraryHandler handler)
    {
        var delegates = new Dictionary<string, Delegate>();
        handler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For([callInfo.Arg<Type>()], []);
                delegates.Add(callInfo.Arg<string>(), @delegate);
                return @delegate;
            });
        return delegates;
    }

    [Test]
    public void Lifetime_ShouldCallExpectedMethodsInOptimisticScenario()
    {
        var handler = Substitute.For<ILibraryHandler>();
        handler.IsLibraryLoaded.Returns(false);
        var delegates = PrepareHandlerAndGetDelegateDictionary(handler);

        // when
        var proxy = new NativeProxy(handler);
        proxy.Load();

        // then
        _ = handler.Received().IsLibraryLoaded;
        handler.Received(1).LoadLibrary();
        AssertGetFunctionByNameWasCalledForAllMethods(handler);

        // setup
        handler.ClearReceivedCalls();
        handler.IsLibraryLoaded.Returns(true);

        // when
        proxy.Load();

        // then
        _ = handler.Received().IsLibraryLoaded;
        handler.Received(0).LoadLibrary();
        AssertGetFunctionByNameWasCalledForNoMethods(handler);

        //setup
        handler.ClearReceivedCalls();
        handler.IsLibraryLoaded.Returns(true);

        // when
        proxy.Unload();

        // then
        _ = handler.Received(1).IsLibraryLoaded;
        delegates[nameof(ISunVoxLibC.sv_deinit)].Received(1).DynamicInvoke();
        handler.Received(1).UnloadLibrary();
    }

    [Test]
    public void Load_LibraryLoadedButProxyIsNot_ShouldNotCallHandlerLoad()
    {
        var handler = Substitute.For<ILibraryHandler>();
        handler.IsLibraryLoaded.Returns(true);

        var proxy = new NativeProxy(handler);

        // when
        proxy.Load();

        // then
        _ = handler.Received().IsLibraryLoaded;
        handler.Received(0).LoadLibrary();
        AssertGetFunctionByNameWasCalledForAllMethods(handler);
    }

    [Test]
    public void Load_HandlerLoadFails_ShouldCallHandlerUnload()
    {
        var handler = Substitute.For<ILibraryHandler>();
        handler.IsLibraryLoaded.Returns(false);
        var innerException = new Exception("A fun exception.");
        handler.When(static h => h.LoadLibrary()).Throw(innerException);

        var proxy = new NativeProxy(handler);

        // when
        proxy.Invoking(p => p.Load())
            .Should().Throw<Exception>()
            .Which.Should().BeEquivalentTo(innerException);
        Received.InOrder(() =>
        {
            handler.Received(1).LoadLibrary();
            handler.Received(1).UnloadLibrary();
        });
        AssertGetFunctionByNameWasCalledForNoMethods(handler);
    }

    [Test]
    public void Unload_WhenLibraryFailed_ShouldCallUnloadLibraryAndRethrowException()
    {
        var handler = Substitute.For<ILibraryHandler>();
        var delegates = PrepareHandlerAndGetDelegateDictionary(handler);
        handler.IsLibraryLoaded.Returns(false);

        var proxy = new NativeProxy(handler);

        proxy.Load();

        _ = handler.Received().IsLibraryLoaded;
        handler.Received(1).LoadLibrary();

        handler.ClearReceivedCalls();
        handler.IsLibraryLoaded.Returns(true);

        proxy.Unload();

        _ = handler.Received().IsLibraryLoaded;
        handler.Received(1).UnloadLibrary();
        delegates[nameof(ISunVoxLibC.sv_deinit)].Received(1).DynamicInvoke();
    }

    [TestCase(false, true, "Missing delegate. Library is not loaded, proxy is loaded.")]
    [TestCase(true, false, "Missing delegate. Library is loaded, proxy is not loaded.")]
    [TestCase(false, false, "Missing delegate. Library is not loaded, proxy is not loaded.")]
    [TestCase(true, true, "Missing delegate. Library is loaded, proxy is loaded.")]
    public void GetNoDelegateException_ShouldReturnExpectedMessage(bool libraryLoaded, bool proxyLoaded, string message)
    {
        var handler = Substitute.For<ILibraryHandler>();
        var proxy = new NativeProxy(handler);

        if (proxyLoaded)
        {
            proxy.Load();
        }
        else
        {
            proxy.Unload();
        }

        proxy.IsLoaded.Should().Be(proxyLoaded);

        handler.IsLibraryLoaded.Returns(libraryLoaded);

        var exception = proxy.GetNoDelegateException();
        exception.Message.Should().Be(message);
    }

    [Test]
    public void GetNoDelegateException_OnFailWhenGettingLibraryStatus_ShouldReturnExpectedMessage()
    {
        var handler = Substitute.For<ILibraryHandler>();
        var proxy = new NativeProxy(handler);

        var innerException = new Exception("A fun exception.");
        handler.IsLibraryLoaded.Throws(innerException);
        const string message = "Missing delegate. Library state is unknown.";

        var exception = proxy.GetNoDelegateException();

        exception.Message.Should().Be(message);
        exception.InnerException.Should().Be(innerException);
    }

    private static object? GetDefault(Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }

    [Test]
    public void Load_ShouldAskForExpectedDelegates()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        var delegates = new Dictionary<string, Delegate>();
        libraryHandler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For([callInfo.Arg<Type>()], []);
                delegates.Add(callInfo.Arg<string>(), @delegate);
                return @delegate;
            });

        var proxy = new NativeProxy(libraryHandler);
        proxy.Load();

        foreach (var methodName in typeof(ISunVoxLibC).GetMethods().Select(m => m.Name))
        {
            delegates.Should().ContainKey(methodName);
        }

        foreach (var method in typeof(ISunVoxLibC).GetMethods())
        {
            var parameters = method.GetParameters().Select(p => GetDefault(p.ParameterType)).ToArray();
            method.Invoke(proxy, parameters);

            delegates[method.Name].Received(1).DynamicInvoke(parameters);
        }
    }

    [Test]
    public void Unload_ShouldCallDeinitWhenAvailable()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        var delegates = new Dictionary<string, Delegate>();
        libraryHandler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For([callInfo.Arg<Type>()], []);
                delegates.Add(callInfo.Arg<string>(), @delegate);
                return @delegate;
            });

        libraryHandler.IsLibraryLoaded.Returns(true);
        var proxy = new NativeProxy(libraryHandler);
        proxy.Load();

        // WHEN
        proxy.Unload();

        // THEN
        var method = delegates[nameof(ISunVoxLibC.sv_deinit)];
        method.Received(1).DynamicInvoke();
        libraryHandler.Received(1).UnloadLibrary();
    }

    [Test]
    public void Unload_WhenDeinitFails_ShouldThrowExpectedExceptionAndCallExpectedMethods()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        var delegates = new Dictionary<string, Delegate>();
        libraryHandler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For([callInfo.Arg<Type>()], []);
                delegates.Add(callInfo.Arg<string>(), @delegate);
                return @delegate;
            });

        libraryHandler.IsLibraryLoaded.Returns(true);

        var proxy = new NativeProxy(libraryHandler);
        var exception = new Exception("A fun exception.");

        proxy.Load();

        var method = delegates[nameof(ISunVoxLibC.sv_deinit)];
        method.DynamicInvoke().Throws(exception);

        // WHEN - THEN
        proxy.Invoking(p => p.Unload())
            .Should().Throw<Exception>()
            .Which.Should().BeEquivalentTo(exception);

        // AND
        method.Received(1).DynamicInvoke();
        libraryHandler.Received(0).UnloadLibrary();
    }

    [Test]
    public void Unload_WhenUnloadLibraryFails_ShouldThrowExpectedExceptionAndCallExpectedMethods()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        var delegates = new Dictionary<string, Delegate>();
        libraryHandler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For([callInfo.Arg<Type>()], []);
                delegates.Add(callInfo.Arg<string>(), @delegate);
                return @delegate;
            });

        libraryHandler.IsLibraryLoaded.Returns(true);

        var proxy = new NativeProxy(libraryHandler);
        var exception = new Exception("A fun exception.");

        proxy.Load();

        var method = delegates[nameof(ISunVoxLibC.sv_deinit)];
        libraryHandler.When(static handler => handler.UnloadLibrary()).Throw(exception);

        // WHEN - THEN
        proxy.Invoking(p => p.Unload())
            .Should().Throw<Exception>()
            .Which.Should().BeEquivalentTo(exception);

        // AND
        method.Received(1).DynamicInvoke();
        libraryHandler.Received(1).UnloadLibrary();
    }

    [Test]
    public void Unload_WhenUnloadLibraryAndDeinitFail_ShouldThrowBothExpectedExceptionsAndCallExpectedMethods()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        libraryHandler.IsLibraryLoaded.Returns(true);
        var delegates = PrepareHandlerAndGetDelegateDictionary(libraryHandler);

        var proxy = new NativeProxy(libraryHandler);
        var exception = new Exception("A fun exception.");

        proxy.Load();

        var method = delegates[nameof(ISunVoxLibC.sv_deinit)];
        method.DynamicInvoke().Throws(exception);

        // WHEN - THEN
        proxy.Invoking(p => p.Unload())
            .Should().Throw<Exception>()
            .Which.Should().BeEquivalentTo(exception);

        // AND
        method.Received(1).DynamicInvoke();
        libraryHandler.Received(0).UnloadLibrary();
        proxy.IsLoaded.Should().BeTrue();
    }

    [Test]
    public void Unload_WhenDeinitDelegateWasNotProvided_ShouldThrow()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        libraryHandler.IsLibraryLoaded.Returns(true);

        var proxy = new NativeProxy(libraryHandler);

        proxy.Load();

        // WHEN - THEN
        proxy.Invoking(p => p.Unload())
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"{nameof(ISunVoxLibC.sv_deinit)} was null, but library and proxy are both loaded.");

        // AND
        libraryHandler.Received(0).UnloadLibrary();
        proxy.IsLibraryLoaded.Should().BeTrue();
    }

    [Test]
    public async Task InterfaceCalls_BeforeLoadCalled_ShouldThrowInvalidOperationException()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();
        libraryHandler.IsLibraryLoaded.Returns(false);
        var proxy = new NativeProxy(libraryHandler);

        var methods = typeof(ISunVoxLibC).GetMethods();

        await Parallel.ForEachAsync(methods, (method, _) =>
        {
            var parameters = method.GetParameters().Select(static p => GetDefault(p.ParameterType)).ToArray();
            method.Invoking(m => m.Invoke(proxy, parameters))
                .Should().Throw<Exception>()
                .WithInnerException<InvalidOperationException>()
                .WithMessage("Missing delegate. Library is not loaded, proxy is not loaded.");
            return ValueTask.CompletedTask;
        });
    }
}
