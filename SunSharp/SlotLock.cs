using System;

namespace SunSharp
{
    internal sealed class SlotLock : IDisposable
    {
        private readonly Slot _slot;
        private readonly uint _openCount;
        private bool _disposed;

        /// <summary>
        /// This object should only be created under a lock on SlotManagementLock.
        /// </summary>
        internal SlotLock(Slot slot, uint openCount)
        {
            _slot = slot;
            _openCount = openCount;
            slot.Library.LockSlot(slot.Id);
        }

        private void ReleaseUnmanagedResources()
        {
            _slot.Library.UnlockSlot(_slot.Id);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            lock (_slot.SunVox.Slots.SlotManagementLock)
            {
                if (_slot.SunVox.Deinitialized)
                {
                    _disposed = true;
                    return;
                }

                if (_slot.OpenCount == _openCount)
                {
                    ReleaseUnmanagedResources();
                }
            }

            if (disposing)
            {
                // release managed resources
            }

            _disposed = true;
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
