using SunSharp.ThinWrapper;
using System.Collections;
using System.Collections.Generic;

namespace SunSharp.ObjectWrapper
{
    public class Timeline : IEnumerable<Pattern>
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

        public bool TryGetPattern(string name, out Pattern pattern)
        {
            var id = _lib.FindPattern(_id, name);

            if (id > -1)
            {
                pattern = new Pattern(this, id);
                return true;
            }
            else
            {
                pattern = default;
                return false;
            }
        }

        public bool TryGetPattern(int id, out Pattern pattern)
        {
            if (_lib.GetPatternExists(_id, id))
            {
                pattern = new Pattern(this, id);
                return true;
            }
            else
            {
                pattern = default;
                return false;
            }
        }

        public IEnumerator<Pattern> GetEnumerator()
        {
            for (int i = 0; i < GetUpperPatternCount(); i++)
                if (TryGetPattern(i, out var p))
                    yield return p;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
