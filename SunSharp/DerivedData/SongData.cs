using SunSharp.ThinWrapper;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.DerivedData
{
    public class SongData : IReadOnlySongData
    {
        public string Name { get; set; }
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
        public ICollection<ModuleData> Modules { get; set; }
        public ICollection<PatternData> Patterns { get; set; }

        IReadOnlyCollection<IReadOnlyModuleData> IReadOnlySongData.Modules => Modules.AsReadonlyOrGetWrapper();
        IReadOnlyCollection<IReadOnlyPatternData> IReadOnlySongData.Patterns => Patterns.AsReadonlyOrGetWrapper();

        public SongData()
        {
        }

        public static SongData DeepCopy(IReadOnlySongData original)
        {
            return new SongData()
            {
                Name = original.Name,
                BPM = original.BPM,
                TPL = original.TPL,
                Frames = original.Frames,
                Lines = original.Lines,
                CurrentLine = original.CurrentLine,
                FirstLine = original.FirstLine,
                LastLine = original.LastLine,
                IsLinear = original.IsLinear,
                IsDestructive = original.IsDestructive,
                HasDynamicTempo = original.HasDynamicTempo,
                Modules = original.Modules.Select(m => ModuleData.DeepCopy(m)).ToArray(),
                Patterns = original.Patterns.Select(p => PatternData.DeepCopy(p)).ToArray()
            };
        }
    }

    public class ModuleData : IReadOnlyModuleData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public (int X, int Y) Position { get; set; }
        public (int finetune, int relativeNote) Finetune { get; set; }
        public bool Solo { get; set; }
        public bool Mute { get; set; }
        public bool Bypass { get; set; }
        public (int R, int G, int B) Color { get; set; }
        public ICollection<(string name, int value)> Controllers { get; set; }
        public ICollection<int> Inputs { get; set; }
        public ICollection<int> Outputs { get; set; }

        IReadOnlyCollection<(string name, int value)> IReadOnlyModuleData.Controllers => Controllers.AsReadonlyOrGetWrapper();
        IReadOnlyCollection<int> IReadOnlyModuleData.Inputs => Inputs.AsReadonlyOrGetWrapper();
        IReadOnlyCollection<int> IReadOnlyModuleData.Outputs => Outputs.AsReadonlyOrGetWrapper();

        public ModuleData()
        {
        }

        public static ModuleData DeepCopy(IReadOnlyModuleData data)
        {
            return new ModuleData
            {
                Id = data.Id,
                Name = data.Name,
                Position = data.Position,
                Finetune = data.Finetune,
                Solo = data.Solo,
                Mute = data.Mute,
                Bypass = data.Bypass,
                Color = data.Color,
                Controllers = data.Controllers.Select(c => (c.name, c.value)).ToArray(),
                Inputs = data.Inputs.Select(i => i).ToArray(),
                Outputs = data.Outputs.Select(o => o).ToArray()
            };
        }
    }

    public class PatternData : IReadOnlyPatternData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public (int X, int Y) Position { get; set; }
        public int Lines { get; set; }
        public int Tracks { get; set; }
        public bool IsMuted { get; set; }
        public bool IsLinear { get; set; }
        public bool IsDestructive { get; set; }
        public bool HasDynamicTempo { get; set; }
        public ICollection<ReadOnlyEvent> Data { get; set; }

        IReadOnlyCollection<ReadOnlyEvent> IReadOnlyPatternData.Data => Data.AsReadonlyOrGetWrapper();

        public PatternData()
        {
        }

        public static PatternData DeepCopy(IReadOnlyPatternData data)
        {
            return new PatternData()
            {
                Id = data.Id,
                Name = data.Name,
                Position = data.Position,
                Lines = data.Lines,
                Tracks = data.Tracks,
                IsMuted = data.IsMuted,
                IsLinear = data.IsLinear,
                IsDestructive = data.IsDestructive,
                HasDynamicTempo = data.HasDynamicTempo,
                Data = data.Data.Select(e => e).ToArray()
            };
        }
    }
}
