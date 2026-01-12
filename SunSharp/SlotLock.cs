using System;

namespace SunSharp
{
    public sealed class SlotLock : IDisposable
    {
        private readonly SunVox _instance;
        private readonly int _slotId;
        private bool _disposed;

        public SlotLock(SunVox sunVox, int slotId)
        {
            _instance = sunVox;
            _slotId = slotId;
            sunVox.Library.LockSlot(slotId);
        }

        private void ReleaseUnmanagedResources()
        {
            _instance.Library.UnlockSlot(_slotId);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            ReleaseUnmanagedResources();

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
