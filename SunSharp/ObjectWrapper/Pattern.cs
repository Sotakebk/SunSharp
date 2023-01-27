using SunSharp.ThinWrapper;

namespace SunSharp.ObjectWrapper
{
    public struct Pattern
    {
        private readonly ISunVoxLib _lib;
        private readonly int _id;
        private readonly int _slotId;
        private readonly Slot _slot;

        public int Id => _id;
        public Slot Slot => _slot;
        public ISunVoxLib Library => _lib;

        internal Pattern(Timeline timeline, int id)
        {
            _lib = timeline.Slot.SunVox.Library;
            _slot = timeline.Slot;
            _slotId = timeline.Slot.Id;
            _id = id;
        }

        public bool GetExists() => _lib.GetPatternExists(_slotId, _id);

        public string GetName() => _lib.GetPatternName(_slotId, _id);

        public (int X, int Y) GetPosition() => _lib.GetModulePosition(_slotId, _id);

        public int GetTrackCount() => _lib.GetPatternTracks(_slotId, _id);

        public int GetLength() => _lib.GetPatternLines(_slotId, _id);

        public Event[] GetData()
        {
            int slotId = _slotId;
            int id = _id;
            var lib = _lib;
            return _slot.RunInLock(() =>
            {
                return lib.GetPatternData(slotId, id);
            });
        }

        public Event[,] GetData2D()
        {
            int tracks = GetTrackCount();
            var lines = GetLength();
            var data = GetData();
            var data2 = new Event[lines, tracks];
            // TODO slow?
            for (int l = 0; l < lines; l++)
            {
                for (int t = 0; t < tracks; t++)
                {
                    data2[l, t] = data[t + l * tracks];
                }
            }
            return data2;
        }

        public void SetData(Event[] data)
        {
            // TODO: sv_set_pattern_data() does not exist
            var slotId = _slotId;
            var id = _id;
            var lib = _lib;
            _slot.RunInLock(() =>
            {
                int tracks = lib.GetPatternTracks(slotId, id);
                var arr = lib.GetPatternData(slotId, id);
                for (int i = 0; i < data.Length; i++)
                {
                    if (arr[i].Data == data[i].Data)
                        continue;

                    var track = i % tracks;
                    var line = i - track * tracks;
                    lib.SetPatternEvent(slotId, id, track, line, data[i]);
                }
            });
        }

        public void SetData2D(Event[,] data)
        {
            // TODO: sv_set_pattern_data() does not exist
            var slotId = _slotId;
            var id = _id;
            var lib = _lib;
            int inputLines = data.GetLength(0);
            int inputTracks = data.GetLength(1);
            _slot.RunInLock(() =>
            {
                var tracks = lib.GetPatternTracks(slotId, id);
                var arr = lib.GetPatternData(slotId, id);
                for (int l = 0; l < inputLines; l++)
                {
                    for (int t = 0; t < inputTracks; t++)
                    {
                        if (arr[t + l * tracks].Data == data[l, t].Data)
                            continue;

                        lib.SetPatternEvent(slotId, id, t, l, data[l, t]);
                    }
                }
            });
        }

        public void SetPatternMute(int id, bool mute)
        {
            var lib = _lib;
            var slotId = _id;
            _slot.RunInLock(() =>
            {
                lib.PatternMute(slotId, id, mute);
            });
        }

        public bool GetPatternMute(int id)
        {
            var lib = _lib;
            var slotId = _id;
            return _slot.RunInLock(() =>
            {
                var wasMuted = lib.PatternMute(slotId, id, false);
                lib.PatternMute(slotId, id, wasMuted);
                return wasMuted;
            });
        }

        public void SetPatternEvent(int track, int line, Event @event)
        {
            var lib = _lib;
            var slotId = _id;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.SetPatternEvent(slotId, id, track, line, @event);
            });
        }

        public void SetPatternEvent(int track, int line, int NN, int VV, int MM, int CCEE, int XXYY)
        {
            var lib = _lib;
            var slotId = _id;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.SetPatternEvent(slotId, id, track, line, NN, VV, MM, CCEE, XXYY);
            });
        }

        public int GetPatternEventValue(int track, int line, Column column)
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
