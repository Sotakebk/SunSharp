using SunSharp.ThinWrapper;

namespace SunSharp.ObjectWrapper
{
    public class VirtualPattern
    {
        public Slot Slot => _slot;

        private readonly ISunVoxLib _lib;
        private readonly Slot _slot;
        private readonly int _id;
        private int? _lastSetTimeStamp;
        private readonly object _lock;

        internal VirtualPattern(Slot slot)
        {
            _slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
            _lock = new object();
        }

        public uint GetCurrentTick() => _lib.GetTicks();

        public uint GetTicksPerSecond() => _lib.GetTicksPerSecond();

        /// <summary>
        /// Send an event to be processed as fast as possible.
        /// Do not use if any other code sends events to the library directly.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="e"></param>
        public void SendEventImmediately(int track, PatternEvent e)
        {
            lock (_lock)
            {
                if (_lastSetTimeStamp != null)
                {
                    var previous = _lastSetTimeStamp;
                    _lib.SetSendEventTimestamp(_id, reset: true);
                    _lib.SendEvent(_id, track, e);
                    _lib.SetSendEventTimestamp(_id, false, previous.Value);
                }
                else
                {
                    _lib.SendEvent(_id, track, e);
                }
            }
        }

        /// <summary>
        /// Set the tick timestamp of future events.
        /// Do not use if any other code sends events to the library directly.
        /// </summary>
        /// <param name="timestamp"></param>
        public void SetEventTiming(int timestamp)
        {
            lock (_lock)
            {
                _lib.SetSendEventTimestamp(_id, false, timestamp);
                _lastSetTimeStamp = timestamp;
            }
        }

        /// <summary>
        /// Reset the tick timestamp of future events.
        /// Do not use if any other code sends events to the library directly.
        /// </summary>
        public void ResetEventTiming()
        {
            lock (_lock)
            {
                _lib.SetSendEventTimestamp(_id, true);
                _lastSetTimeStamp = null;
            }
        }

        /// <summary>
        /// Send an event.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="e"></param>
        public void SendEvent(int track, PatternEvent @event)
        {
            lock (_lock)
            {
                _lib.SendEvent(_id, track, @event);
            }
        }

        /// <summary>
        /// Send an event.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="e"></param>
        public void SendEvent(int track, int nn = 0, int vv = 0, int mm = 0, int ccee = 0, int xxyy = 0)
        {
            lock (_lock)
            {
                _lib.SendEvent(_id, track, nn, vv, mm, ccee, xxyy);
            }
        }
    }
}
