using SunSharp.Native;

namespace SunSharp
{
    /// <inheritdoc cref="VirtualPattern"/>
    public interface IVirtualPattern
    {
        /// <inheritdoc cref="VirtualPattern.Slot"/>
        ISlot Slot { get; }

        /// <inheritdoc cref="VirtualPattern.GetTicks"/>
        uint GetTicks();

        /// <inheritdoc cref="VirtualPattern.GetTicksPerSecond"/>
        uint GetTicksPerSecond();

        /// <inheritdoc cref="VirtualPattern.SetEventTiming"/>
        void SetEventTiming(int timestamp);

        /// <inheritdoc cref="VirtualPattern.ResetEventTiming"/>
        void ResetEventTiming();

        /// <inheritdoc cref="VirtualPattern.SendEvent(int, PatternEvent)"/>
        void SendEvent(int track, PatternEvent e);

        /// <inheritdoc cref="VirtualPattern.SendEvent(int, int, int, int, int, int)"/>
        void SendEvent(int track, int nn = 0, int vv = 0, int mm = 0, int ccee = 0, int xxyy = 0);
    }

    /// <summary>
    /// Virtual, 16-track pattern for sending events to the engine.
    /// </summary>
    public sealed class VirtualPattern : IVirtualPattern
    {
        /// <summary>
        /// Gets the slot this virtual pattern belongs to.
        /// </summary>
        public Slot Slot { get; }

        /// <inheritdoc/>
        ISlot IVirtualPattern.Slot => Slot;

#if SUNSHARP_RELEASE
        private readonly SunVoxLib _lib;
#else
        private readonly ISunVoxLib _lib;
#endif
        private readonly int _id;

        internal VirtualPattern(Slot slot)
        {
            Slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
        }

        /// <inheritdoc cref="ISunVoxLib.GetTicks"/>
        public uint GetTicks()
        {
            return _lib.GetTicks();
        }

        /// <inheritdoc cref="ISunVoxLib.GetTicksPerSecond"/>
        public uint GetTicksPerSecond()
        {
            return _lib.GetTicksPerSecond();
        }

        /// <inheritdoc cref="ISunVoxLib.SetEventTiming"/>
        public void SetEventTiming(int timestamp)
        {
            _lib.SetEventTiming(_id, timestamp);
        }

        /// <inheritdoc cref="ISunVoxLib.ResetEventTiming"/>
        public void ResetEventTiming()
        {
            _lib.ResetEventTiming(_id);
        }

        /// <inheritdoc cref="ISunVoxLib.SendEvent(int, int, PatternEvent)"/>
        public void SendEvent(int track, PatternEvent e)
        {
            _lib.SendEvent(_id, track, e);
        }

        /// <inheritdoc cref="ISunVoxLib.SendEvent(int, int, int, int, int, int, int)"/>
        public void SendEvent(int track, int nn = 0, int vv = 0, int mm = 0, int ccee = 0, int xxyy = 0)
        {
            _lib.SendEvent(_id, track, nn, vv, mm, ccee, xxyy);
        }
    }
}
