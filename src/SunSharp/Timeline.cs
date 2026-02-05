using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SunSharp.Native;

namespace SunSharp
{
    /// <inheritdoc cref="Timeline"/>
    public interface ITimeline : IEnumerable<IPatternHandle>
    {
        /// <inheritdoc cref="Timeline.Slot"/>
        ISlot Slot { get; }

        /// <inheritdoc cref="Timeline.GetUpperPatternCount"/>
        int GetUpperPatternCount();

        /// <inheritdoc cref="Timeline.GetPatternExists"/>
        bool GetPatternExists(int patternId);

        IPatternHandle GetPattern(int patternId);

        /// <inheritdoc cref="Timeline.TryGetPattern(string, out PatternHandle?)"/>
        bool TryGetPattern(string name, [NotNullWhen(true)] out IPatternHandle? pattern);

        /// <inheritdoc cref="Timeline.TryGetPattern(int, out PatternHandle?)"/>
        bool TryGetPattern(int patternId, [NotNullWhen(true)] out IPatternHandle? pattern);

        /// <inheritdoc cref="Timeline.CreatePattern"/>
        IPatternHandle CreatePattern(int lines, int tracks, int x, int y, int iconSeed = 0, string? name = null);

        /// <inheritdoc cref="Timeline.ClonePattern(int, int, int)"/>
        int ClonePattern(int patternId, int x, int y);

        /// <inheritdoc cref="Timeline.ClonePattern(PatternHandle, int, int)"/>
        IPatternHandle ClonePattern(IPatternHandle original, int x, int y);
    }

    /// <summary>
    /// Project timeline, containing all the existing patterns.
    /// </summary>
    public sealed class Timeline : ITimeline, IEnumerable<PatternHandle>
    {
        /// <summary>
        /// Gets the slot this timeline belongs to.
        /// </summary>
        public Slot Slot { get; }

        /// <inheritdoc />
        ISlot ITimeline.Slot => Slot;

#if SUNSHARP_RELEASE
        private readonly SunVoxLib _lib;
#else
        private readonly ISunVoxLib _lib;
#endif
        private readonly int _slotId;

        internal Timeline(Slot slot)
        {
            Slot = slot;
            _lib = slot.SunVox.Library;
            _slotId = slot.Id;
        }

        /// <inheritdoc cref="ISunVoxLib.GetUpperPatternCount"/>
        public int GetUpperPatternCount()
        {
            return _lib.GetUpperPatternCount(_slotId);
        }

        /// <inheritdoc cref="ISunVoxLib.GetPatternExists"/>
        public bool GetPatternExists(int patternId)
        {
            return _lib.GetPatternExists(_slotId, patternId);
        }

        /// <summary>
        /// Returns a handle to a pattern by ID.
        /// The underlying pattern may not exist.
        /// </summary>
        public PatternHandle GetPattern(int patternId)
        {
            return new PatternHandle(this, patternId);
        }

        /// <inheritdoc cref="GetPattern(int)" />
        IPatternHandle ITimeline.GetPattern(int patternId)
        {
            return GetPattern(patternId);
        }

        /// <summary>
        /// Tries to get a pattern by name.
        /// </summary>
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

        /// <summary>
        /// Tries to get a pattern by ID.
        /// </summary>
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

        bool ITimeline.TryGetPattern(string name, [NotNullWhen(true)] out IPatternHandle? pattern)
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

        bool ITimeline.TryGetPattern(int patternId, [NotNullWhen(true)] out IPatternHandle? pattern)
        {
            if (TryGetPattern(patternId, out PatternHandle? p))
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

        /// <inheritdoc cref="ISunVoxLib.CreatePattern"/>
        public PatternHandle CreatePattern(int lines, int tracks, int x, int y, int iconSeed = 0, string? name = null)
        {
            var id = _lib.CreatePattern(_slotId, x, y, tracks, lines, iconSeed, name);
            return new PatternHandle(this, id);
        }

        IPatternHandle ITimeline.CreatePattern(int lines, int tracks, int x, int y, int iconSeed, string? name)
        {
            return CreatePattern(lines, tracks, x, y, iconSeed, name);
        }

        /// <inheritdoc cref="ISunVoxLib.ClonePattern"/>
        public int ClonePattern(int patternId, int x, int y)
        {
            return _lib.ClonePattern(_slotId, patternId, x, y);
        }

        /// <summary>
        /// Clones a pattern and returns a handle to the new pattern.
        /// </summary>
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
