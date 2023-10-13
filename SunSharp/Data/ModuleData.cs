using System;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Data
{
    public sealed class ModuleData : IDeepCopyable<ModuleData>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public (int X, int Y) Position { get; set; } = (0, 0);
        public FineTunePair FineTune { get; set; }
        public (byte r, byte g, byte b) Color { get; set; } = (0, 0, 0);
        public ICollection<ControllerData> Controllers { get; set; } = Array.Empty<ControllerData>();
        public uint Flags { get; set; }
        public ICollection<int> Inputs { get; set; } = Array.Empty<int>();
        public ICollection<int> Outputs { get; set; } = Array.Empty<int>();

        public ModuleData DeepCopy()
        {
            var copy = new ModuleData
            {
                Id = Id,
                Name = Name,
                Type = Type,
                Position = Position,
                FineTune = FineTune,
                Flags = Flags,
                Color = Color,
                Controllers = Controllers.Select(c => c.DeepCopy()).ToArray(),
                Inputs = Inputs.Select(i => i).ToArray(),
                Outputs = Outputs.Select(o => o).ToArray()
            };

            return copy;
        }
    }
}
