using System;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.DerivedData
{
    public class SongData : IDeepCopyable<SongData>
    {
        public string? Name { get; set; }
        public int BPM { get; set; }
        public int TPL { get; set; }
        public int Frames { get; set; }
        public int Lines { get; set; }
        public int CurrentLine { get; set; }
        public int FirstLine { get; set; }
        public int LastLine { get; set; }
        public bool IsLinear { get; set; }
        public bool IsDestructive { get; set; }
        public bool HasDynamicTempo { get; set; }
        public ICollection<ModuleData> Modules { get; set; } = Array.Empty<ModuleData>();
        public ICollection<PatternData> Patterns { get; set; } = Array.Empty<PatternData>();

        public SongData DeepCopy()
        {
            var copy = new SongData()
            {
                Name = this.Name,
                BPM = this.BPM,
                TPL = this.TPL,
                Frames = this.Frames,
                Lines = this.Lines,
                CurrentLine = this.CurrentLine,
                FirstLine = this.FirstLine,
                LastLine = this.LastLine,
                IsLinear = this.IsLinear,
                IsDestructive = this.IsDestructive,
                HasDynamicTempo = this.HasDynamicTempo,
                Modules = this.Modules.Select(m => m.DeepCopy()).ToArray(),
                Patterns = this.Patterns.Select(p => p.DeepCopy()).ToArray()
            };
            return copy;
        }
    }
}
