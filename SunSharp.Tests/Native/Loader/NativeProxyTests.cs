using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using SunSharp.Native;
using SunSharp.Native.Loader;

namespace SunSharp.Tests.Native.Loader;

public class NativeProxyTests
{
    private static void AssertThatGetFunctionByNameWasCalledForAllMethods(ILibraryHandler handler)
    {
        var methods = typeof(ISunVoxLibC).GetMethods();

        foreach (var method in methods)
            handler.Received(1).GetFunctionByName(method.Name, Arg.Any<Type>());
    }

    private static void AssertThatGetFunctionByNameWasCalledForNoMethods(ILibraryHandler handler)
    {
        handler.Received(0).GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>());
    }

    private static Dictionary<string, Delegate> PrepareHandlerAndGetDelegateDictionary(ILibraryHandler handler)
    {
        var delegates = new Dictionary<string, Delegate>();
        handler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For(new[] { callInfo.Arg<Type>() }, Array.Empty<object>());
                delegates.Add(callInfo.Arg<string>(), @delegate);
                return @delegate;
            });
        return delegates;
    }

    [Test]
    public void NativeProxyShouldCallExpectedMethodsInPositiveScenario()
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
        AssertThatGetFunctionByNameWasCalledForAllMethods(handler);

        // setup
        handler.ClearReceivedCalls();
        handler.IsLibraryLoaded.Returns(true);

        // when
        proxy.Load();

        // then
        _ = handler.Received().IsLibraryLoaded;
        handler.Received(0).LoadLibrary();
        AssertThatGetFunctionByNameWasCalledForNoMethods(handler);

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
    public void NativeProxyLoadShouldNotCallHandlerLoadIfLibraryLoadedButProxyIsNot()
    {
        var handler = Substitute.For<ILibraryHandler>();
        handler.IsLibraryLoaded.Returns(true);

        var proxy = new NativeProxy(handler);

        // when
        proxy.Load();

        // then
        _ = handler.Received().IsLibraryLoaded;
        handler.Received(0).LoadLibrary();
        AssertThatGetFunctionByNameWasCalledForAllMethods(handler);
    }

    [Test]
    public void NativProxyLoadShouldCallHandlerUnloadWhenHandlerLoadFails()
    {
        var handler = Substitute.For<ILibraryHandler>();
        handler.IsLibraryLoaded.Returns(false);
        var innerException = new Exception("A fun exception.");
        handler.When(static h => h.LoadLibrary()).Throw(innerException);

        var proxy = new NativeProxy(handler);

        // when
        Assert.That(() => proxy.Load(), Throws.Exception.EqualTo(innerException));
        Received.InOrder(() =>
        {
            handler.Received(1).LoadLibrary();
            handler.Received(1).UnloadLibrary();
        });
        AssertThatGetFunctionByNameWasCalledForNoMethods(handler);
    }

    [Test]
    public void NativeProxyShouldCallUnloadLibraryWhenLibraryFailedAndRethrowException()
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
    public void NativeProxyGetExceptionReturnsExpectedMessage(bool libraryLoaded, bool proxyLoaded, string message)
    {
        var handler = Substitute.For<ILibraryHandler>();
        var proxy = new NativeProxy(handler);

        if (proxyLoaded)
            proxy.Load();
        else
            proxy.Unload();

        Assert.That(proxy.IsLoaded, Is.EqualTo(proxyLoaded));

        handler.IsLibraryLoaded.Returns(libraryLoaded);

        var exception = proxy.GetNoDelegateException();
        Assert.That(exception.Message, Is.EqualTo(message));
    }

    [Test]
    public void NativeProxyGetExceptionReturnsExpectedMessageOnFailWhenGettingLibraryStatus()
    {
        var handler = Substitute.For<ILibraryHandler>();
        var proxy = new NativeProxy(handler);

        var innerException = new Exception("A fun exception.");
        handler.IsLibraryLoaded.Throws(innerException);
        const string message = "Missing delegate. Library state is unknown.";

        var exception = proxy.GetNoDelegateException();

        Assert.Multiple(() =>
        {
            Assert.That(exception.Message, Is.EqualTo(message));
            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        });
    }

    private static object? GetDefault(Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }

    [Test]
    public void NativeProxyShouldAskForAndCallProvidedDelegates()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        var delegates = new Dictionary<string, Delegate>();
        libraryHandler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For(new[] { callInfo.Arg<Type>() }, Array.Empty<object>());
                delegates.Add(callInfo.Arg<string>(), @delegate);
                return @delegate;
            });

        var proxy = new NativeProxy(libraryHandler);
        proxy.Load();

        foreach (var methodName in typeof(ISunVoxLibC).GetMethods().Select(m => m.Name))
            Assert.That(delegates.ContainsKey(methodName));

        foreach (var method in typeof(ISunVoxLibC).GetMethods())
        {
            var parameters = method.GetParameters().Select(p => GetDefault(p.ParameterType)).ToArray();
            method.Invoke(proxy, parameters);

            delegates[method.Name].Received(1).DynamicInvoke(parameters);
        }
    }

    [Test]
    public void NativeProxyUnloadShouldCallDeinitWhenAvailable()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        var delegates = new Dictionary<string, Delegate>();
        libraryHandler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For(new[] { callInfo.Arg<Type>() }, Array.Empty<object>());
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
    public void NativeProxyUnloadShouldThrowExpectedExceptionAndCallExpectedMethodsWhenDeinitFails()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        var delegates = new Dictionary<string, Delegate>();
        libraryHandler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For(new[] { callInfo.Arg<Type>() }, Array.Empty<object>());
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
        Assert.That(() => proxy.Unload(), Throws.Exception.EqualTo(exception));

        // AND
        method.Received(1).DynamicInvoke();
        libraryHandler.Received(0).UnloadLibrary();
    }

    [Test]
    public void NativeProxyUnloadShouldThrowExpectedExceptionAndCallExpectedMethodsWhenUnloadLibraryFails()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        var delegates = new Dictionary<string, Delegate>();
        libraryHandler.GetFunctionByName(Arg.Any<string>(), Arg.Any<Type>())
            .Returns(callInfo =>
            {
                var @delegate = (Delegate)Substitute.For(new[] { callInfo.Arg<Type>() }, Array.Empty<object>());
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
        Assert.That(() => proxy.Unload(), Throws.Exception.EqualTo(exception));

        // AND
        method.Received(1).DynamicInvoke();
        libraryHandler.Received(1).UnloadLibrary();
    }

    [Test]
    public void NativeProxyUnloadShouldThrowBothExpectedExceptionsAndCallExpectedMethodsWhenUnloadLibraryAndDeinitFail()
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
        Assert.That(() => proxy.Unload(), Throws.Exception.EqualTo(exception));

        // AND
        method.Received(1).DynamicInvoke();
        libraryHandler.Received(0).UnloadLibrary();
        Assert.That(proxy.IsLoaded, Is.True);
    }

    [Test]
    public void NativeProxyUnloadShouldThrowWhenDeinitDelegateWasNotProvided()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();

        libraryHandler.IsLibraryLoaded.Returns(true);

        var proxy = new NativeProxy(libraryHandler);

        proxy.Load();

        // WHEN - THEN
        Assert.That(() => proxy.Unload(),
            Throws.InvalidOperationException
                .With.Message
                .EqualTo($"{nameof(ISunVoxLibC.sv_deinit)} was null, but library and proxy are both loaded."));

        // AND
        libraryHandler.Received(0).UnloadLibrary();
        Assert.That(proxy.IsLibraryLoaded);
    }

    [Test]
    public void NativeProxyInterfaceCallsShouldThrowInvalidOperationExceptionBeforeLoadCalled()
    {
        var libraryHandler = Substitute.For<ILibraryHandler>();
        libraryHandler.IsLibraryLoaded.Returns(false);
        var proxy = new NativeProxy(libraryHandler);

        foreach (var method in typeof(ISunVoxLibC).GetMethods())
        {
            var parameters = method.GetParameters().Select(static p => GetDefault(p.ParameterType)).ToArray();
            Assert.That(() => method.Invoke(proxy, parameters),
                Throws.Exception.With.InnerException.TypeOf<InvalidOperationException>()
                    .And.InnerException.With.Message
                    .EqualTo("Missing delegate. Library is not loaded, proxy is not loaded."));
        }
    }
}
