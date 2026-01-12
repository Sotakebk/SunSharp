using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SunSharp.Native;

namespace SunSharp
{
    public interface ITimeline : IEnumerable<IPatternHandle>
    {
        ISlot Slot { get; }

        int GetUpperPatternCount();

        bool GetPatternExists(int patternId);

        bool TryGetPattern(string name, [NotNullWhen(true)] out IPatternHandle? pattern);

        bool TryGetPattern(int id, [NotNullWhen(true)] out IPatternHandle? pattern);

        IPatternHandle CreatePattern(int lines, int tracks, int x, int y, int iconSeed = 0, string? name = null);

        int ClonePattern(int id, int x, int y);

        IPatternHandle ClonePattern(IPatternHandle original, int x, int y);
    }

    public sealed class Timeline : ITimeline, IEnumerable<PatternHandle>
    {
        /// <inheritdoc cref="ITimeline.Slot" />
        public Slot Slot { get; }

        /// <inheritdoc />
        ISlot ITimeline.Slot => Slot;

        private readonly ISunVoxLib _lib;
        private readonly int _slotId;

        internal Timeline(Slot slot)
        {
            Slot = slot;
            _lib = slot.SunVox.Library;
            _slotId = slot.Id;
        }

        /// <inheritdoc />
        public int GetUpperPatternCount()
        {
            return _lib.GetUpperPatternCount(_slotId);
        }

        /// <inheritdoc />
        public bool GetPatternExists(int patternId)
        {
            return _lib.GetPatternExists(_slotId, patternId);
        }

        /// <inheritdoc />
        public bool TryGetPattern(string name, [NotNullWhen(true)] out PatternHandle? pattern)
        {
            var id = _lib.FindPattern(_slotId, name);

            if (id != null)
            {
                pattern = new PatternHandle(this, id.Value);
                return true;
            }

            pattern = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryGetPattern(int id, [NotNullWhen(true)] out PatternHandle? pattern)
        {
            if (_lib.GetPatternExists(_slotId, id))
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

        public bool TryGetPattern(string name, [NotNullWhen(true)] out IPatternHandle? pattern)
        {
            if (TryGetPattern(name, out PatternHandle? p))
            {
                pattern = p;
                return true;
            }
            else
            {
                pattern = default;
                return false;
            }
        }

        public bool TryGetPattern(int id, [NotNullWhen(true)] out IPatternHandle? pattern)
        {
            if (TryGetPattern(id, out PatternHandle? p))
            {
                pattern = p;
                return true;
            }
            else
            {
                pattern = default;
                return false;
            }
        }

        /// <inheritdoc />
        public PatternHandle CreatePattern(int lines, int tracks, int x, int y, int iconSeed = 0, string? name = null)
        {
            using (Slot.AcquireLock())
            {
                var id = _lib.CreatePattern(_slotId, x, y, tracks, lines, iconSeed, name);
                return new PatternHandle(this, id);
            }
        }

        IPatternHandle ITimeline.CreatePattern(int lines, int tracks, int x, int y, int iconSeed, string? name)
        {
            return CreatePattern(lines, tracks, x, y, iconSeed, name);
        }

        public int ClonePattern(int id, int x, int y)
        {
            using (Slot.AcquireLock())
            {
                return _lib.ClonePattern(_slotId, id, x, y);
            }
        }

        public PatternHandle ClonePattern(PatternHandle original, int x, int y)
        {
            return new PatternHandle(this, ClonePattern(original.Id, x, y));
        }

        IPatternHandle ITimeline.ClonePattern(IPatternHandle original, int x, int y)
        {
            return new PatternHandle(this, ClonePattern(original.Id, x, y));
        }

        public IEnumerator<PatternHandle> GetEnumerator()
        {
            for (var i = 0; i < GetUpperPatternCount(); i++)
            {
                if (TryGetPattern(i, out PatternHandle? p))
                {
                    if (p is null)
                    {
                        continue;
                    }
                    yield return p.Value;
                }
            }
        }

        IEnumerator<IPatternHandle> IEnumerable<IPatternHandle>.GetEnumerator()
        {
            foreach (var pattern in this)
            {
                yield return pattern;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
