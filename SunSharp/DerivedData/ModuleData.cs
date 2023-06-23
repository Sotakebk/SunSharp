using System;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.DerivedData
{
    public sealed class ModuleData : IDeepCopyable<ModuleData>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public (int X, int Y) Position { get; set; } = (0, 0);
        public FineTunePair FineTunePair { get; set; }
        public bool Solo { get; set; }
        public bool Mute { get; set; }
        public bool Bypass { get; set; }
        public (int r, int g, int b) Color { get; set; } = (0, 0, 0);
        public ICollection<ControllerData> Controllers { get; set; } = Array.Empty<ControllerData>();
        public ICollection<int> Inputs { get; set; } = Array.Empty<int>();
        public ICollection<int> Outputs { get; set; } = Array.Empty<int>();

        public ModuleData DeepCopy()
        {
            var copy = new ModuleData
            {
                Id = this.Id,
                Name = this.Name,
                Position = this.Position,
                FineTunePair = this.FineTunePair,
                Solo = this.Solo,
                Mute = this.Mute,
                Bypass = this.Bypass,
                Color = this.Color,
                Controllers = this.Controllers.Select(c => c.DeepCopy()).ToArray(),
                Inputs = this.Inputs.Select(i => i).ToArray(),
                Outputs = this.Outputs.Select(o => o).ToArray()
            };

            return copy;
        }
    }
}
