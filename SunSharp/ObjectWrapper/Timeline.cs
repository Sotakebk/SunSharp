using System.Collections;
using System.Collections.Generic;
using SunSharp.ThinWrapper;

namespace SunSharp.ObjectWrapper
{
    public class Timeline : IEnumerable<PatternHandle>
    {
        public Slot Slot => _slot;

        private readonly ISunVoxLib _lib;
        private readonly Slot _slot;
        private readonly int _id;

        internal Timeline(Slot slot)
        {
            _slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
        }

        public int GetUpperPatternCount() => _lib.GetUpperPatternCount(_id);

        public bool GetPatternExists(int patternId) => _lib.GetPatternExists(_id, patternId);

        public bool TryGetPattern(string name, out PatternHandle pattern)
        {
            var id = _lib.FindPattern(_id, name);

            if (id > -1)
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

        public PatternHandle CreatePattern(string name, int lines, int tracks, int x, int y, int? iconSeed = null)
        {
            return Slot.RunInLock(() =>
            {
                var id = _lib.CreatePattern(_id, null, x, y, tracks, lines, iconSeed, name);
                return new PatternHandle(this, id);
            });
        }

        public PatternHandle ClonePattern(PatternHandle original, int x, int y)
        {
            return Slot.RunInLock(() =>
            {
                var id = _lib.CreatePattern(_id, original.Id, x, y, -1, -1, null, original.GetName());
                return new PatternHandle(this, id);
            });
        }

        public IEnumerator<PatternHandle> GetEnumerator()
        {
            for (var i = 0; i < GetUpperPatternCount(); i++)
                if (TryGetPattern(i, out var p))
                    yield return p;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
