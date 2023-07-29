using System;

namespace SunSharp
{
    public static class SunVoxLibExtensions
    {
        /// <summary>
        /// Use to group multiple calls in one lock/unlock block.
        /// Possible issues: when a slot is closed, then re-opened while user code is running, it may escape the abstraction and/or throw an exception.
        /// </summary>
        public static void RunInLock(this ISunVoxLib lib, int slotId, Action action)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                action();
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static void RunInLock<T1>(this ISunVoxLib lib, int slotId, Action<T1> action, T1 arg1)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                action(arg1);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static void RunInLock<T1, T2>(this ISunVoxLib lib, int slotId, Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                action(arg1, arg2);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static void RunInLock<T1, T2, T3>(this ISunVoxLib lib, int slotId, Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                action(arg1, arg2, arg3);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static void RunInLock<T1, T2, T3, T4>(this ISunVoxLib lib, int slotId, Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                action(arg1, arg2, arg3, arg4);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static void RunInLock<T1, T2, T3, T4, T5>(this ISunVoxLib lib, int slotId, Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                action(arg1, arg2, arg3, arg4, arg5);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static TResult RunInLock<TResult>(this ISunVoxLib lib, int slotId, Func<TResult> func)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                return func();
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static TResult RunInLock<TResult, T1>(this ISunVoxLib lib, int slotId, Func<T1, TResult> func, T1 arg1)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                return func(arg1);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static TResult RunInLock<TResult, T1, T2>(this ISunVoxLib lib, int slotId, Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                return func(arg1, arg2);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static TResult RunInLock<TResult, T1, T2, T3>(this ISunVoxLib lib, int slotId, Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                return func(arg1, arg2, arg3);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static TResult RunInLock<TResult, T1, T2, T3, T4>(this ISunVoxLib lib, int slotId, Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                return func(arg1, arg2, arg3, arg4);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }

        /// <inheritdoc cref="SunVoxLibExtensions.RunInLock"/>
        public static TResult RunInLock<TResult, T1, T2, T3, T4, T5>(this ISunVoxLib lib, int slotId, Func<T1, T2, T3, T4, T5, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var entered = false;
            try
            {
                lib.LockSlot(slotId);
                entered = true;
                return func(arg1, arg2, arg3, arg4, arg5);
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slotId);
            }
        }
    }
}
