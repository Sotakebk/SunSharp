using System;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Data
{
    public class SongData : IDeepCopyable<SongData>
    {
        public string? Name { get; set; }

        /// <summary>
        /// Beats per minute.
        /// </summary>
        public int BPM { get; set; }

        /// <summary>
        /// Ticks per line.
        /// </summary>
        public int TPL { get; set; }

        public uint Lines { get; set; }
        public int CurrentLine { get; set; }
        public int FirstLine { get; set; }
        public int LastLine { get; set; }
        public ICollection<ModuleData> Modules { get; set; } = Array.Empty<ModuleData>();
        public ICollection<PatternData> Patterns { get; set; } = Array.Empty<PatternData>();

        public bool IsLinear => Patterns.All(p => p.IsLinear);
        public bool IsDestructive => Patterns.Any(p => p.IsDestructive);
        public bool HasDynamicTempo => Patterns.Any(p => p.HasDynamicTempo);

        public SongData DeepCopy()
        {
            var copy = new SongData
            {
                Name = Name,
                BPM = BPM,
                TPL = TPL,
                Lines = Lines,
                CurrentLine = CurrentLine,
                FirstLine = FirstLine,
                LastLine = LastLine,
                Modules = Modules.Select(m => m.DeepCopy()).ToArray(),
                Patterns = Patterns.Select(p => p.DeepCopy()).ToArray()
            };
            return copy;
        }
    }
}
