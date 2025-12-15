using System.Collections;
using System.Collections.Generic;
using SunSharp.Native;

namespace SunSharp
{
    public interface ITimeline : IEnumerable<PatternHandle>
    {
        ISlot Slot { get; }

        int GetUpperPatternCount();

        bool GetPatternExists(int patternId);

        bool TryGetPattern(string name, out PatternHandle pattern);

        bool TryGetPattern(int id, out PatternHandle pattern);

        PatternHandle CreatePattern(int lines, int tracks, int x, int y, int iconSeed = 0, string? name = null);

        PatternHandle ClonePattern(PatternHandle original, int x, int y);
    }

    public sealed class Timeline : ITimeline
    {
        public Slot Slot { get; }

        ISlot ITimeline.Slot => Slot;

        private readonly ISunVoxLib _lib;
        private readonly int _id;

        internal Timeline(Slot slot)
        {
            Slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
        }

        public int GetUpperPatternCount()
        {
            return _lib.GetUpperPatternCount(_id);
        }

        public bool GetPatternExists(int patternId)
        {
            return _lib.GetPatternExists(_id, patternId);
        }

        public bool TryGetPattern(string name, out PatternHandle pattern)
        {
            var id = _lib.FindPattern(_id, name);

            if (id != null)
            {
                pattern = new PatternHandle(this, id.Value);
                return true;
            }

            pattern = default;
            return false;
        }

        public bool TryGetPattern(int id, out PatternHandle pattern)
        {
            if (_lib.GetPatternExists(_id, id))
            {
                pattern = new PatternHandle(this, id);
                return true;
            }
            else
            {
                pattern = default;
                return false;
            }
        }

        public PatternHandle CreatePattern(int lines, int tracks, int x, int y, int iconSeed = 0, string? name = null)
        {
            using (Slot.AcquireLock())
            {
                var id = _lib.CreatePattern(_id, x, y, tracks, lines, iconSeed, name);
                return new PatternHandle(this, id);
            }
        }

        public PatternHandle ClonePattern(PatternHandle original, int x, int y)
        {
            using (Slot.AcquireLock())
            {
                var id = _lib.ClonePattern(_id, original.Id, x, y);
                return new PatternHandle(this, id);
            }
        }

        public IEnumerator<PatternHandle> GetEnumerator()
        {
            for (var i = 0; i < GetUpperPatternCount(); i++)
            {
                if (TryGetPattern(i, out var p))
                {
                    yield return p;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
