using SunSharp.ObjectWrapper;
using SunSharp.ThinWrapper;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.DerivedData
{
    public interface IReadOnlySongData
    {
        string Name { get; }
        int BPM { get; }
        int TPL { get; }
        int Frames { get; }
        int Lines { get; }
        int CurrentLine { get; }
        int FirstLine { get; }
        int LastLine { get; }
        bool IsLinear { get; }
        bool IsDestructive { get; }
        bool HasDynamicTempo { get; }
        IReadOnlyCollection<IReadOnlyModuleData> Modules { get; }
        IReadOnlyCollection<IReadOnlyPatternData> Patterns { get; }
    }

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

        public static SongData ReadSongData(ISunVoxLib lib, int slotId)
        {
            return lib.RunInLock(slotId, () => ReadSongDataInternal(lib, slotId));
        }

        public static SongData ReadSongData(Slot slot)
        {
            return slot.RunInLock(() => ReadSongDataInternal(slot.Library, slot.Id));
        }

        internal static SongData ReadSongDataInternal(ISunVoxLib lib, int slot)
        {
            var modules = ReadModuleDataArray(lib, slot);
            var patterns = ReadPatternDataArray(lib, slot);

            var songData = new SongData()
            {
                Modules = modules,
                Patterns = patterns,
                BPM = lib.GetSongBpm(slot),
                CurrentLine = lib.GetCurrentLine(slot),
                FirstLine = patterns.Min(p => p.Position.X),
                Frames = lib.GetSongLengthFrames(slot),
                HasDynamicTempo = patterns.Any(p => p.HasDynamicTempo),
                IsDestructive = patterns.Any(p => p.IsDestructive),
                IsLinear = patterns.All(p => p.IsLinear),
                LastLine = patterns.Max(p => p.Position.X + p.Lines),
                Lines = lib.GetSongLengthLines(slot),
                Name = lib.GetSongName(slot),
                TPL = lib.GetSongTpl(slot)
            };
            return songData;
        }

        private static ModuleData[] ReadModuleDataArray(ISunVoxLib lib, int slot)
        {
            var moduleCount = lib.GetUpperModuleCount(slot);
            var modules = new List<ModuleData>(moduleCount);

            for (int i = 0; i < moduleCount; i++)
            {
                if (lib.GetModuleExists(slot, i))
                {
                    var m = ModuleData.ReadModuleDataInternal(lib, slot, i);
                    modules.Add(m);
                }
            }
            return modules.ToArray();
        }

        private static PatternData[] ReadPatternDataArray(ISunVoxLib lib, int slot)
        {
            var patternCount = lib.GetUpperPatternCount(slot);
            var patterns = new List<PatternData>(patternCount);

            for (int i = 0; i < patternCount; i++)
            {
                if (lib.GetPatternExists(slot, i))
                {
                    var p = PatternData.ReadPatternDataInternal(lib, slot, i);
                    patterns.Add(p);
                }
            }
            return patterns.ToArray();
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
}
