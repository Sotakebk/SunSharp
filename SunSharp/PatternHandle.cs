using SunSharp.Native;

namespace SunSharp
{
    /// <summary>
    /// Represents a handle to a pattern. The handle may be invalid if the pattern does not exist.
    /// </summary>
    public interface IPatternHandle
    {
        int Id { get; }

        bool GetExists();

        string? GetName();

        void SetName(string name);

        (int x, int y) GetPosition();

        void SetPosition(int x, int y);

        int GetTrackCount();

        int GetLength();

        /// <summary>
        /// Resize the pattern.
        /// </summary>
        /// <param name="tracks"><see langword="null"/> to leave as is.</param>
        /// <param name="lines"><see langword="null"/> to leave as is.</param>
        void Resize(int? tracks = null, int? lines = null);

        (PatternEvent[] data, int tracks, int lines)? GetData();

        void SetData(PatternEvent[] data, int tracks, int lines);

        void SetMuted(int id, bool mute);

        bool GetMuted(int id);

        void SetEvent(int track, int line, PatternEvent patternEvent);

        void SetEvent(int track, int line, int nn, int vv, int mm, int ccee, int xxyy);

        int GetEventValue(int track, int line, Column column);
    }

    public readonly struct PatternHandle : IPatternHandle
    {
        private readonly ISunVoxLib _lib;
        private readonly int _slotId;
        private readonly Slot _slot;

        public int Id { get; }

        public PatternHandle(Timeline timeline, int id)
        {
            _lib = timeline.Slot.SunVox.Library;
            _slot = timeline.Slot;
            _slotId = timeline.Slot.Id;
            Id = id;
        }

        /// <inheritdoc/>
        public bool GetExists()
        {
            return _lib.GetPatternExists(_slotId, Id);
        }

        /// <inheritdoc/>
        public string? GetName()
        {
            return _lib.GetPatternName(_slotId, Id);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public (int x, int y) GetPosition()
        {
            return _lib.GetPatternPosition(_slotId, Id);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public int GetTrackCount() => _lib.GetPatternTracks(_slotId, Id);

        /// <inheritdoc/>
        public int GetLength() => _lib.GetPatternLines(_slotId, Id);

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void SetMuted(int id, bool mute)
        {
            var lib = _lib;
            var slotId = Id;
            using (_slot.AcquireLock())
            {
                lib.SetPatternMuted(slotId, id, mute);
            }
        }

        /// <inheritdoc/>
        public bool GetMuted(int id)
        {
            using (_slot.AcquireLock())
            {
                return _lib.GetPatternMuted(Id, id);
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public int GetEventValue(int track, int line, Column column)
        {
            var lib = _lib;
            var slotId = Id;
            var id = Id;
            return lib.GetPatternEventValue(slotId, id, track, line, column);
        }
    }
}
