using SunSharp.ThinWrapper;

namespace SunSharp.ObjectWrapper
{
    public class VirtualPattern
    {
        public Slot Slot => _slot;

        private readonly ISunVoxLib _lib;
        private readonly Slot _slot;
        private readonly int _id;
        private int? lastSetTimeStamp = null;

        internal VirtualPattern(Slot slot)
        {
            _slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
        }

        public uint GetCurrentTick() => _lib.GetTicks();

        public uint GetTicksPerSecond() => _lib.GetTicksPerSecond();

        public void SendEventImmediately(int track, Event e)
        {
            _slot.RunInLock(() =>
            {
                if (lastSetTimeStamp != null)
                {
                    var previous = lastSetTimeStamp;
                    _lib.SetSendEventTimestamp(_id, true);
                    _lib.SendEvent(_id, track, e);
                    _lib.SetSendEventTimestamp(_id, false, previous.Value);
                }
                else
                {
                    _lib.SendEvent(_id, track, e);
                }
            });
        }

        public void SetEventTiming(int timestamp)
        {
            _slot.RunInLock(() =>
            {
                _lib.SetSendEventTimestamp(_id, false, timestamp);
                lastSetTimeStamp = timestamp;
            });
        }

        public void ResetEventTiming()
        {
            _slot.RunInLock(() =>
            {
                _lib.SetSendEventTimestamp(_id, true);
                lastSetTimeStamp = null;
            });
        }

        public void SendEvent(int track, Event @event)
        {
            _slot.RunInLock(() =>
            {
                _lib.SendEvent(_id, track, @event);
            });
        }

        public void SendEvent(int track, int NN = 0, int VV = 0, int MM = 0, int CCEE = 0, int XXYY = 0)
        {
            _slot.RunInLock(() =>
            {
                _lib.SendEvent(_id, track, NN, VV, MM, CCEE, XXYY);
            });
        }
    }
}
