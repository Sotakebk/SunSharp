using SunSharp.ObjectWrapper;
using System;
using System.Threading;
using SunSharp.ThinWrapper;

namespace SunSharp.Abstractions
{
    public sealed class LockWrapper
    {
        private readonly Slot _slot;
        private readonly ISunVoxLib _lib;
        private readonly int _slotId;
        private readonly object _lock;

        public LockWrapper(Slot slot)
        {
            _slot = slot;
        }

        public LockWrapper(ISunVoxLib lib, int slotId)
        {
            _lock = new object();
            _lib = lib;
            _slotId = slotId;
        }

        public T RunInLock<T>(Func<T> func)
        {
            if (_slot != null)
            {
                return _slot.RunInLock(func);
            }

            bool lockWasTaken = false;
            var temp = _lock;
            try
            {
                Monitor.Enter(temp, ref lockWasTaken);
                if (lockWasTaken)
                    _lib.LockSlot(_slotId);
                return func();
            }
            finally
            {
                if (lockWasTaken)
                {
                    _lib.UnlockSlot(_slotId);
                    Monitor.Exit(temp);
                }
            }
        }

        public void RunInLock(Action action)
        {
            if (_slot != null)
            {
                _slot.RunInLock(action);
                return;
            }

            bool lockWasTaken = false;
            var temp = _lock;
            try
            {
                Monitor.Enter(temp, ref lockWasTaken);
                if (lockWasTaken)
                    _lib.LockSlot(_slotId);
                action();
            }
            finally
            {
                if (lockWasTaken)
                {
                    _lib.UnlockSlot(_slotId);
                    Monitor.Exit(temp);
                }
            }
        }
    }
}
