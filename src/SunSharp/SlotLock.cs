using System;

namespace SunSharp
{
    internal sealed class SlotLock : IDisposable
    {
        private enum LockState : byte
        {
            NotLockedYet = 0,
            Locked = 1,
            Unlocked = 2
        }

        private readonly Slot _slot;
        private readonly object _slotManagementLock;
        private readonly uint _openCount;
        private LockState _lockState;

        /// <summary>
        /// This object should only be created under a lock on SlotManagementLock.
        /// </summary>
        internal SlotLock(Slot slot, object slotManagementLock, uint openCount)
        {
            _slot = slot;
            _openCount = openCount;
            _slotManagementLock = slotManagementLock;
            _lockState = LockState.NotLockedYet;
            slot.Library.LockSlot(slot.Id);
            _lockState = LockState.Locked;
        }

        private void ReleaseUnmanagedResources(bool disposing)
        {
            if (disposing)
            {
                _slot.Library.UnlockSlot(_slot.Id);
                return;
            }
            try
            {
                _slot.Library.UnlockSlot(_slot.Id);
            }
            catch (Exception)
            {
                // may be caused by a null delegate, or SunVoxException
            }
        }

        private void Dispose(bool disposing)
        {
            if (_lockState != LockState.Locked)
            {
                return;
            }

            _lockState = LockState.Unlocked;
            lock (_slotManagementLock)
            {
                if (_slot.SunVox.Deinitialized)
                {
                    return;
                }

                if (_slot.OpenCount == _openCount)
                {
                    ReleaseUnmanagedResources(disposing);
                }
            }

            if (disposing)
            {
                // release managed resources
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SlotLock()
        {
            Dispose(false);
        }
    }
}
