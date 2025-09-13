using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Tests;

public class SunVoxLibExtensionsTests
{
    private static IEnumerable<TestCaseData> RunInLockActionCases => PrepareRunInLockActionCalls();

    private static IEnumerable<TestCaseData> RunInLockFuncCases => PrepareRunInLockFuncCalls();

    private static bool IsNullableObjectArrayEqual(object[]? a, object[]? b)
    {
        if (a != null && b != null)
            return a.SequenceEqual(b);

        return a == null && b == null;
    }

    private static IEnumerable<TestCaseData> PrepareRunInLockActionCalls()
    {
        yield return new TestCaseData(
            0,
            static (ISunVoxLib lib, Action<object[]?> action, object[]? _) => { lib.RunInLock(0, () => action(null)); }
        );
        yield return new TestCaseData(
            1,
            static (ISunVoxLib lib, Action<object[]?> action, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                lib.RunInLock(0, arg => action([arg]), args[0]);
            }
        );
        yield return new TestCaseData(
            2,
            static (ISunVoxLib lib, Action<object[]?> action, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                lib.RunInLock(0, (arg1, arg2) => action([arg1, arg2]), args[0], args[1]);
            }
        );
        yield return new TestCaseData(
            3,
            static (ISunVoxLib lib, Action<object[]?> action, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                lib.RunInLock(0, (arg1, arg2, arg3) => action([arg1, arg2, arg3]), args[0], args[1], args[2]);
            }
        );
        yield return new TestCaseData(
            4,
            static (ISunVoxLib lib, Action<object[]?> action, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                lib.RunInLock(0, (arg1, arg2, arg3, arg4) => action([arg1, arg2, arg3, arg4]), args[0], args[1],
                    args[2], args[3]);
            }
        );
        yield return new TestCaseData(
            5,
            static (ISunVoxLib lib, Action<object[]?> action, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                lib.RunInLock(0, (arg1, arg2, arg3, arg4, arg5) => action([arg1, arg2, arg3, arg4, arg5]),
                    args[0], args[1], args[2], args[3], args[4]);
            }
        );
    }

    private static IEnumerable<TestCaseData> PrepareRunInLockFuncCalls()
    {
        yield return new TestCaseData(
            0,
            static (ISunVoxLib lib, Func<object[]?, object> func, object[]? _) =>
            {
                return lib.RunInLock(0, () => func(null));
            }
        );
        yield return new TestCaseData(
            1,
            static (ISunVoxLib lib, Func<object[]?, object> func, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                return lib.RunInLock(0, arg => func([arg]), args[0]);
            }
        );
        yield return new TestCaseData(
            2,
            static (ISunVoxLib lib, Func<object[]?, object> func, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                return lib.RunInLock(0, (arg1, arg2) => func([arg1, arg2]), args[0], args[1]);
            }
        );
        yield return new TestCaseData(
            3,
            static (ISunVoxLib lib, Func<object[]?, object> func, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                return lib.RunInLock(0, (arg1, arg2, arg3) => func([arg1, arg2, arg3]), args[0], args[1],
                    args[2]);
            }
        );
        yield return new TestCaseData(
            4,
            static (ISunVoxLib lib, Func<object[]?, object> func, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                return lib.RunInLock(0, (arg1, arg2, arg3, arg4) => func([arg1, arg2, arg3, arg4]), args[0],
                    args[1], args[2], args[3]);
            }
        );
        yield return new TestCaseData(
            5,
            static (ISunVoxLib lib, Func<object[]?, object> func, object[]? args) =>
            {
                ArgumentNullException.ThrowIfNull(args);
                return lib.RunInLock(0, (arg1, arg2, arg3, arg4, arg5) => func([arg1, arg2, arg3, arg4, arg5]),
                    args[0], args[1], args[2], args[3], args[4]);
            }
        );
    }

    [TestCaseSource(nameof(RunInLockActionCases))]
    public void RunInLockShouldCallLockActionAndUnlock(int argCount,
        Action<ISunVoxLib, Action<object[]?>, object[]?> action)
    {
        var lib = Substitute.For<ISunVoxLib>();
        var mockAction = Substitute.For<Action<object[]?>>();
        var mockData = argCount == 0
            ? null
            : Enumerable.Range(0, argCount).Select(static i => (object)i.ToString()).ToArray();
        // when
        action(lib, mockAction, mockData);

        // then
        lib.Received(1).LockSlot(0);
        mockAction.Received(1).Invoke(Arg.Is<object[]?>(arr => IsNullableObjectArrayEqual(arr, mockData)));
        lib.Received(1).UnlockSlot(0);
    }

    [TestCaseSource(nameof(RunInLockFuncCases))]
    public void RunInLockShouldCallLockFuncAndUnlock(int argCount,
        Func<ISunVoxLib, Func<object[]?, object>, object[]?, object> function)
    {
        var lib = Substitute.For<ISunVoxLib>();
        var mockFunction = Substitute.For<Func<object[]?, object>>();
        var mockResult = Substitute.For<object>();
        mockFunction.Invoke(Arg.Any<object[]>()).Returns(mockResult);
        var mockData = argCount == 0
            ? null
            : Enumerable.Range(0, argCount).Select(static i => (object)i.ToString()).ToArray();
        // when
        var result = function(lib, mockFunction, mockData);

        // then
        lib.Received(1).LockSlot(0);
        mockFunction.Received(1).Invoke(Arg.Is<object[]?>(arr => IsNullableObjectArrayEqual(arr, mockData)));
        result.Should().BeSameAs(mockResult);
        lib.Received(1).UnlockSlot(0);
    }

    [TestCaseSource(nameof(RunInLockActionCases))]
    public void RunInLockShouldCallLockActionAndUnlockWhenPassedActionThrowsException(int argCount,
        Action<ISunVoxLib, Action<object[]?>, object[]?> action)
    {
        var lib = Substitute.For<ISunVoxLib>();
        var sub = Substitute.For<Action>();
        var mockAction = new Action<object[]?>(_ =>
        {
            sub();
            throw new Exception();
        });
        var mockData = argCount == 0
            ? null
            : Enumerable.Range(0, argCount).Select(static i => (object)i.ToString()).ToArray();
        // when
        ((Action)(() => action(lib, mockAction, mockData))).Should().Throw<Exception>();

        // then
        lib.Received(1).LockSlot(0);
        sub.Received(1).Invoke();
        lib.Received(1).UnlockSlot(0);
    }

    [TestCaseSource(nameof(RunInLockFuncCases))]
    public void RunInLockShouldCallLockFuncAndUnlockWhenPassedFuncThrowsException(int argCount,
        Func<ISunVoxLib, Func<object[]?, object>, object[]?, object> function)
    {
        var lib = Substitute.For<ISunVoxLib>();
        var sub = Substitute.For<Action>();
        var mockFunction = new Func<object[]?, object>(_ =>
        {
            sub();
            throw new Exception();
        });
        var mockData = argCount == 0
            ? null
            : Enumerable.Range(0, argCount).Select(static i => (object)i.ToString()).ToArray();
        // when
        var action = () => function(lib, mockFunction, mockData);
        action.Invoking(a => a()).Should().Throw<Exception>();

        // then
        lib.Received(1).LockSlot(0);
        sub.Received(1).Invoke();
        lib.Received(1).UnlockSlot(0);
    }

    [TestCaseSource(nameof(RunInLockActionCases))]
    public void RunInLockForActionShouldCallLockAndNothingElseIfItThrowsException(int argCount,
        Action<ISunVoxLib, Action<object[]?>, object[]?> action)
    {
        var lib = Substitute.For<ISunVoxLib>();
        lib.When(static x => x.LockSlot(Arg.Any<int>())).Do(static _ => throw new Exception());
        var mockAction = Substitute.For<Action<object[]?>>();
        var mockData = argCount == 0
            ? null
            : Enumerable.Range(0, argCount).Select(static i => (object)i.ToString()).ToArray();
        // when
        ((Action)(() => action(lib, mockAction, mockData))).Should().Throw<Exception>();

        // then
        lib.Received(1).LockSlot(0);
        mockAction.Received(0).Invoke(Arg.Any<object[]?>());
        lib.Received(0).UnlockSlot(0);
    }

    [TestCaseSource(nameof(RunInLockFuncCases))]
    public void RunInLockForFuncShouldCallLockAndNothingElseIfItThrowsException(int argCount,
        Func<ISunVoxLib, Func<object[]?, object>, object[]?, object> function)
    {
        var lib = Substitute.For<ISunVoxLib>();
        lib.When(static x => x.LockSlot(Arg.Any<int>())).Do(static _ => throw new Exception());
        var mockFunction = Substitute.For<Func<object[]?, object>>();
        var mockData = argCount == 0
            ? null
            : Enumerable.Range(0, argCount).Select(static i => (object)i.ToString()).ToArray();
        // when
        ((Action)(() => function(lib, mockFunction, mockData))).Should().Throw<Exception>();

        // then
        lib.Received(1).LockSlot(0);
        mockFunction.Received(0).Invoke(Arg.Any<object[]?>());
        lib.Received(0).UnlockSlot(0);
    }
}
