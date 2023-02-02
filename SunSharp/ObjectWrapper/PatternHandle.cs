using SunSharp.ThinWrapper;
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace SunSharp.ObjectWrapper
{
    /// <summary>
    /// Represents a pattern. The underlying SunVox pattern may or may not exist!
    /// </summary>
    public readonly struct PatternHandle
    {
        private readonly ISunVoxLib _lib;
        private readonly int _id;
        private readonly int _slotId;
        private readonly Slot _slot;

        public int Id => _id;
        public Slot Slot => _slot;
        public ISunVoxLib Library => _lib;

        public PatternHandle(Timeline timeline, int id)
        {
            _lib = timeline.Slot.SunVox.Library;
            _slot = timeline.Slot;
            _slotId = timeline.Slot.Id;
            _id = id;
        }

        public bool GetExists() => _lib.GetPatternExists(_slotId, _id);

        public string GetName() => _lib.GetPatternName(_slotId, _id);

        public void SetName(string name)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            _slot.RunInLock(() => lib.SetPatternName(slotId, id, name));
        }

        public (int x, int y) GetPosition() => _lib.GetPatternPosition(_slotId, _id);

        public void SetPosition(int x, int y)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            _slot.RunInLock(() => lib.SetPatternPosition(slotId, id, x, y));
        }

        public int GetTrackCount() => _lib.GetPatternTracks(_slotId, _id);

        public int GetLength() => _lib.GetPatternLines(_slotId, _id);

        /// <summary>
        /// Resize the pattern.
        /// </summary>
        /// <param name="tracks"><see langword="null"/> to leave as is.</param>
        /// <param name="lines"><see langword="null"/> to leave as is.</param>
        public void Resize(int? tracks = null, int? lines = null)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            _slot.RunInLock(() => lib.SetPatternSize(slotId, id, tracks, lines));
        }

        public PatternEvent[] GetData()
        {
            int slotId = _slotId;
            int id = _id;
            var lib = _lib;
            return _slot.RunInLock(() =>
            {
                return lib.GetPatternData(slotId, id);
            });
        }

        public PatternEvent[,] GetData2D()
        {
            int slotId = _slotId;
            int id = _id;
            var lib = _lib;
            var (data, tracks, lines) = _slot.RunInLock(() => {
                var _data = lib.GetPatternData(slotId, id);
                int _tracks = lib.GetPatternTracks(slotId, id);
                var _lines = lib.GetPatternLines(slotId, id);
                return (_data, _tracks, _lines);
            });

            var newData = new PatternEvent[lines, tracks];

            for (int l = 0; l < lines; l++)
                for (int t = 0; t < tracks; t++)
                    newData[l, t] = data[l * tracks + t];

            return newData;
        }

        public void SetData(PatternEvent[] data)
        {
            var slotId = _slotId;
            var id = _id;
            var lib = _lib;
            _slot.RunInLock(() =>
            {
                lib.SetPatternData(slotId, id, data);
            });
        }

        public void SetData2D(PatternEvent[,] data)
        {
            // TODO: sv_set_pattern_data() does not exist
            var slotId = _slotId;
            var id = _id;
            var lib = _lib;
            int inputLines = data.GetLength(0);
            int inputTracks = data.GetLength(1);
            var newData = new PatternEvent[inputLines * inputTracks];

            for (int l = 0; l < inputLines; l++)
                for (int t = 0; t < inputTracks; t++)
                    newData[l * inputTracks + t] = data[l, t];

            _slot.RunInLock(() =>
            {
                lib.SetPatternData(slotId, id, newData);
            });
        }

        public void SetMute(int id, bool mute)
        {
            var lib = _lib;
            var slotId = _id;
            _slot.RunInLock(() =>
            {
                lib.SetPatternMute(slotId, id, mute);
            });
        }

        public bool GetMute(int id)
        {
            var lib = _lib;
            var slotId = _id;
            return _slot.RunInLock(() =>
            {
                var wasMuted = lib.SetPatternMute(slotId, id, false);
                lib.SetPatternMute(slotId, id, wasMuted);
                return wasMuted;
            });
        }

        public void SetEvent(int track, int line, PatternEvent @event)
        {
            var lib = _lib;
            var slotId = _id;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.SetPatternEvent(slotId, id, track, line, @event);
            });
        }

        public void SetEvent(int track, int line, int NN, int VV, int MM, int CCEE, int XXYY)
        {
            var lib = _lib;
            var slotId = _id;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.SetPatternEvent(slotId, id, track, line, NN, VV, MM, CCEE, XXYY);
            });
        }

        public int GetEventValue(int track, int line, Column column)
        {
            var lib = _lib;
            var slotId = _id;
            var id = _id;
            return _slot.RunInLock(() =>
            {
                return lib.GetPatternEventValue(slotId, id, track, line, column);
            });
        }
    }
}
