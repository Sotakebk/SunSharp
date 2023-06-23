using System;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.DerivedData
{
    public class PatternData : IDeepCopyable<PatternData>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public (int X, int Y) Position { get; set; }
        public int Lines { get; set; }
        public int Tracks { get; set; }
        public bool IsMuted { get; set; }
        public bool IsLinear { get; set; }
        public bool IsDestructive { get; set; }
        public bool HasDynamicTempo { get; set; }
        public ICollection<PatternEvent> Data { get; set; } = Array.Empty<PatternEvent>();

        public PatternData DeepCopy()
        {
            var copy = new PatternData()
            {
                Id = this.Id,
                Name = this.Name,
                Position = this.Position,
                Lines = this.Lines,
                Tracks = this.Tracks,
                IsMuted = this.IsMuted,
                IsLinear = this.IsLinear,
                IsDestructive = this.IsDestructive,
                HasDynamicTempo = this.HasDynamicTempo,
                Data = this.Data.Select(e => e).ToArray()
            };
            return copy;
        }
    }
}
