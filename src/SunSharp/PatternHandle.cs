using SunSharp.Native;

namespace SunSharp
{
    /// <inheritdoc cref="PatternHandle"/>
    public interface IPatternHandle
    {
        /// <inheritdoc cref="PatternHandle.Id"/>
        int Id { get; }

        /// <inheritdoc cref="PatternHandle.GetExists"/>
        bool GetExists();

        /// <inheritdoc cref="PatternHandle.GetName"/>
        string? GetName();

        /// <inheritdoc cref="PatternHandle.SetName"/>
        void SetName(string name);

        /// <inheritdoc cref="PatternHandle.GetPosition"/>
        (int x, int y) GetPosition();

        /// <inheritdoc cref="PatternHandle.SetPosition"/>
        void SetPosition(int x, int y);

        /// <inheritdoc cref="PatternHandle.GetTrackCount"/>
        int GetTrackCount();

        /// <inheritdoc cref="PatternHandle.GetLength"/>
        int GetLength();

        /// <inheritdoc cref="PatternHandle.SetPatternSize"/>
        void SetPatternSize(int? tracks = null, int? lines = null);

        /// <inheritdoc cref="PatternHandle.GetData"/>
        (PatternEvent[] data, int tracks, int lines)? GetData();

        /// <inheritdoc cref="PatternHandle.SetData"/>
        void SetData(PatternEvent[] data, int tracks, int lines);

        /// <inheritdoc cref="PatternHandle.SetMuted"/>
        void SetMuted(bool mute);

        /// <inheritdoc cref="PatternHandle.GetMuted"/>
        bool GetMuted();

        /// <inheritdoc cref="PatternHandle.SetEvent(int, int, PatternEvent)"/>
        void SetEvent(int track, int line, PatternEvent patternEvent);

        /// <inheritdoc cref="PatternHandle.SetEvent(int, int, int, int, int, int, int)"/>
        void SetEvent(int track, int line, int nn, int vv, int mm, int ccee, int xxyy);

        /// <inheritdoc cref="PatternHandle.GetEventValue"/>
        int GetEventValue(int track, int line, Column column);
    }

    /// <summary>
    /// Represents a handle to a pattern. The handle may be invalid if the pattern does not exist.
    /// </summary>
    public readonly struct PatternHandle : IPatternHandle
    {
#if SUNSHARP_RELEASE
        private readonly SunVoxLib _lib;
#else
        private readonly ISunVoxLib _lib;
#endif
        private readonly int _slotId;

        /// <summary>
        /// Gets the pattern ID.
        /// </summary>
        public int Id { get; }

        public PatternHandle(Timeline timeline, int id)
        {
            _lib = timeline.Slot.SunVox.Library;
            _slotId = timeline.Slot.Id;
            Id = id;
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternExists"/>
        public bool GetExists()
        {
            return _lib.GetPatternExists(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternName"/>
        public string? GetName()
        {
            return _lib.GetPatternName(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternName"/>
        public void SetName(string name)
        {
            _lib.SetPatternName(_slotId, Id, name);
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternPosition"/>
        public (int x, int y) GetPosition()
        {
            return _lib.GetPatternPosition(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternPosition"/>
        public void SetPosition(int x, int y)
        {
            _lib.SetPatternPosition(_slotId, Id, x, y);
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternTracks"/>
        public int GetTrackCount() => _lib.GetPatternTracks(_slotId, Id);

        /// <inheritdoc cref="ISunVoxLib.GetPatternLines"/>
        public int GetLength() => _lib.GetPatternLines(_slotId, Id);

        /// <inheritdoc cref="ISunVoxLib.SetPatternSize"/>
        public void SetPatternSize(int? tracks = null, int? lines = null)
        {
            _lib.SetPatternSize(_slotId, Id, tracks, lines);
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternData"/>
        public (PatternEvent[] data, int tracks, int lines)? GetData()
        {
            return _lib.GetPatternData(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternData"/>
        public void SetData(PatternEvent[] data, int tracks, int lines)
        {
            _lib.SetPatternData(_slotId, Id, data, tracks, lines);
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternMuted"/>
        public void SetMuted(bool mute)
        {
            _lib.SetPatternMuted(_slotId, Id, mute);
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternMuted"/>
        public bool GetMuted()
        {
            return _lib.GetPatternMuted(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternEvent(int, int, int, int, PatternEvent)"/>
        public void SetEvent(int track, int line, PatternEvent patternEvent)
        {
            _lib.SetPatternEvent(_slotId, Id, track, line, patternEvent);
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternEvent(int, int, int, int, int, int, int, int, int)"/>
        public void SetEvent(int track, int line, int nn, int vv, int mm, int ccee, int xxyy)
        {
            _lib.SetPatternEvent(_slotId, Id, track, line, nn, vv, mm, ccee, xxyy);
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternEventValue"/>
        public int GetEventValue(int track, int line, Column column)
        {
            return _lib.GetPatternEventValue(_slotId, Id, track, line, column);
        }
    }
}
