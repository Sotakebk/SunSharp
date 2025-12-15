using SunSharp.Native;

namespace SunSharp
{
    public interface IVirtualPattern
    {
        ISlot Slot { get; }

        uint GetCurrentTick();

        uint GetTicksPerSecond();

        /// <summary>
        /// Send an event to be processed as fast as possible.
        /// This ignores any previously set timing.
        /// </summary>
        void SendEventImmediately(int track, PatternEvent e);

        /// <summary>
        /// Set the tick timestamp of future events.
        /// This will make future events be processed at the specified timestamp.
        /// </summary>
        void SetEventTiming(int timestamp);

        /// <summary>
        /// Reset the tick timestamp of future events.
        /// This will make future events be processed as soon as possible.
        /// </summary>
        void ResetEventTiming();

        /// <summary>
        /// Sends the specified pattern event to the given track.
        /// The event will be processed according to the last set timing.
        /// </summary>
        void SendEvent(int track, PatternEvent e);

        /// <summary>
        /// Sends the specified pattern event to the given track.
        /// The event will be processed according to the last set timing.
        /// </summary>
        void SendEvent(int track, int nn = 0, int vv = 0, int mm = 0, int ccee = 0, int xxyy = 0);
    }

    public sealed class VirtualPattern : IVirtualPattern
    {
        public Slot Slot { get; }

        public int? LastSetTimestamp { get; private set; }

        ISlot IVirtualPattern.Slot => Slot;

        private readonly ISunVoxLib _lib;
        private readonly int _id;
        private readonly object _lock;

        internal VirtualPattern(Slot slot)
        {
            Slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
            _lock = new object();
        }

        /// <inheritdoc/>
        public uint GetCurrentTick()
        {
            return _lib.GetTicks();
        }

        /// <inheritdoc/>
        public uint GetTicksPerSecond()
        {
            return _lib.GetTicksPerSecond();
        }

        /// <inheritdoc/>
        public void SendEventImmediately(int track, PatternEvent e)
        {
            lock (_lock)
            {
                if (LastSetTimestamp != null)
                {
                    var previous = LastSetTimestamp;
                    _lib.SetSendEventTimestamp(_id, true, 0);
                    _lib.SendEvent(_id, track, e);
                    _lib.SetSendEventTimestamp(_id, false, previous.Value);
                }
                else
                {
                    _lib.SendEvent(_id, track, e);
                }
            }
        }

        /// <inheritdoc/>
        public void SetEventTiming(int timestamp)
        {
            lock (_lock)
            {
                _lib.SetSendEventTimestamp(_id, false, timestamp);
                LastSetTimestamp = timestamp;
            }
        }

        /// <inheritdoc/>
        public void ResetEventTiming()
        {
            lock (_lock)
            {
                _lib.SetSendEventTimestamp(_id, true, 0);
                LastSetTimestamp = null;
            }
        }

        /// <inheritdoc/>
        public void SendEvent(int track, PatternEvent e)
        {
            lock (_lock)
            {
                _lib.SendEvent(_id, track, e);
            }
        }

        /// <inheritdoc/>
        public void SendEvent(int track, int nn = 0, int vv = 0, int mm = 0, int ccee = 0, int xxyy = 0)
        {
            lock (_lock)
            {
                _lib.SendEvent(_id, track, nn, vv, mm, ccee, xxyy);
            }
        }
    }
}
