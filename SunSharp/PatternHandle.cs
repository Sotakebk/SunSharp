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

        /// <inheritdoc cref="PatternHandle.Resize"/>
        void Resize(int? tracks = null, int? lines = null);

        /// <inheritdoc cref="PatternHandle.GetData"/>
        (PatternEvent[] data, int tracks, int lines)? GetData();

        /// <inheritdoc cref="PatternHandle.SetData"/>
        void SetData(PatternEvent[] data, int tracks, int lines);

        /// <inheritdoc cref="PatternHandle.SetMuted"/>
        void SetMuted(int id, bool mute);

        /// <inheritdoc cref="PatternHandle.GetMuted"/>
        bool GetMuted(int id);

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
#if RELEASE
        private readonly SunVoxLib _lib;
#else
        private readonly ISunVoxLib _lib;
#endif
        private readonly int _slotId;
        private readonly Slot _slot;

        /// <summary>
        /// Gets the pattern ID.
        /// </summary>
        public int Id { get; }

        public PatternHandle(Timeline timeline, int id)
        {
            _lib = timeline.Slot.SunVox.Library;
            _slot = timeline.Slot;
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
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            using (_slot.AcquireLock())
            {
                lib.SetPatternName(slotId, id, name);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternPosition"/>
        public (int x, int y) GetPosition()
        {
            return _lib.GetPatternPosition(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternPosition"/>
        public void SetPosition(int x, int y)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            using (_slot.AcquireLock())
            {
                lib.SetPatternPosition(slotId, id, x, y);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternTracks"/>
        public int GetTrackCount() => _lib.GetPatternTracks(_slotId, Id);

        /// <inheritdoc cref="ISunVoxLib.GetPatternLines"/>
        public int GetLength() => _lib.GetPatternLines(_slotId, Id);

        /// <summary>
        /// Resize the pattern.
        /// </summary>
        /// <param name="tracks"><see langword="null"/> to leave as is.</param>
        /// <param name="lines"><see langword="null"/> to leave as is.</param>
        /// <inheritdoc cref="ISunVoxLib.SetPatternSize"/>
        public void Resize(int? tracks = null, int? lines = null)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;

            using (_slot.AcquireLock())
            {
                lib.SetPatternSize(slotId, id, tracks, lines);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternData"/>
        public (PatternEvent[] data, int tracks, int lines)? GetData()
        {
            var slotId = _slotId;
            var id = Id;
            var lib = _lib;
            using (_slot.AcquireLock())
            {
                return lib.GetPatternData(slotId, id);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternData"/>
        public void SetData(PatternEvent[] data, int tracks, int lines)
        {
            var slotId = _slotId;
            var id = Id;
            var lib = _lib;
            using (_slot.AcquireLock())
            {
                lib.SetPatternData(slotId, id, data, tracks, lines);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternMuted"/>
        public void SetMuted(int id, bool mute)
        {
            var lib = _lib;
            var slotId = Id;
            using (_slot.AcquireLock())
            {
                lib.SetPatternMuted(slotId, id, mute);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternMuted"/>
        public bool GetMuted(int id)
        {
            using (_slot.AcquireLock())
            {
                return _lib.GetPatternMuted(Id, id);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternEvent(int, int, int, int, PatternEvent)"/>
        public void SetEvent(int track, int line, PatternEvent patternEvent)
        {
            var lib = _lib;
            var slotId = Id;
            var id = Id;

            using (_slot.AcquireLock())
            {
                lib.SetPatternEvent(slotId, id, track, line, patternEvent);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.SetPatternEvent(int, int, int, int, int, int, int, int, int)"/>
        public void SetEvent(int track, int line, int nn, int vv, int mm, int ccee, int xxyy)
        {
            var lib = _lib;
            var slotId = Id;
            var id = Id;

            using (_slot.AcquireLock())
            {
                lib.SetPatternEvent(slotId, id, track, line, nn, vv, mm, ccee, xxyy);
            }
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternEventValue"/>
        public int GetEventValue(int track, int line, Column column)
        {
            var lib = _lib;
            var slotId = Id;
            var id = Id;
            return lib.GetPatternEventValue(slotId, id, track, line, column);
        }
    }
}
