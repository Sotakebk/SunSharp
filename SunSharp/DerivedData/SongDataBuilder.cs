using SunSharp.ThinWrapper;
using SunSharp.ObjectWrapper;
using System.Linq;
using System.Collections.Generic;

namespace SunSharp.DerivedData
{
    public static class SongDataBuilder
    {
        public static SongData ReadSongData(ISunVoxLib lib, int slotId)
        {
            return lib.RunInLock(slotId, () => ReadSongDataInternal(lib, slotId));
        }

        public static SongData ReadSongData(Slot slot)
        {
            return slot.RunInLock(() => ReadSongDataInternal(slot.Library, slot.Id));
        }

        private static SongData ReadSongDataInternal(ISunVoxLib lib, int slot)
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
                    var m = ReadModuleData(lib, slot, i);
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
                    var p = ReadPatternData(lib, slot, i);
                    patterns.Add(p);
                }
            }
            return patterns.ToArray();
        }

        private static ModuleData ReadModuleData(ISunVoxLib lib, int slot, int moduleId)
        {
            var flags = lib.GetModuleFlags(slot, moduleId);
            var controllers = new (string name, int value)[lib.GetModuleControllerCount(slot, moduleId)];

            for (int i = 0; i < controllers.Length; i++)
            {
                var name = lib.GetModuleControllerName(slot, moduleId, i);
                var value = lib.GetModuleControllerValue(slot, moduleId, i, false);
                controllers[i] = (name, value);
            }

            var moduleData = new ModuleData()
            {
                Bypass = flags.Bypass,
                Color = lib.GetModuleColor(slot, moduleId),
                Controllers = controllers,
                Finetune = lib.GetModuleFinetune(slot, moduleId),
                Id = moduleId,
                Inputs = lib.GetModuleInputs(slot, moduleId),
                Mute = flags.Mute,
                Name = lib.GetModuleName(slot, moduleId),
                Outputs = lib.GetModuleOutputs(slot, moduleId),
                Position = lib.GetModulePosition(slot, moduleId),
                Solo = flags.Solo
            };
            return moduleData;
        }

        private static PatternData ReadPatternData(ISunVoxLib lib, int slot, int patternId)
        {
            var data = lib.GetPatternData(slot, patternId).Select(e => (ReadOnlyEvent)e).ToArray();
            bool isDestructive = false;
            bool isLinear = true;
            bool hasDynamicTempo = false;

            for (int i = 0; i < data.Length; i++)
            {
                var @event = data[i];
                isDestructive = @event.Effect.IsDestructive() || isDestructive;
                isLinear = isLinear && !@event.Effect.IsNonLinear();
                hasDynamicTempo = hasDynamicTempo || @event.Effect.ModifiesTime();
            }

            bool muted = lib.PatternMute(slot, patternId, false);
            lib.PatternMute(slot, patternId, muted);

            var patternData = new PatternData()
            {
                Data = data,
                HasDynamicTempo = hasDynamicTempo,
                Id = patternId,
                IsDestructive = isDestructive,
                IsLinear = isLinear,
                IsMuted = muted,
                Lines = lib.GetPatternLines(slot, patternId),
                Name = lib.GetPatternName(slot, patternId),
                Position = lib.GetPatternPosition(slot, patternId),
                Tracks = lib.GetPatternTracks(slot, patternId)
            };
            return patternData;
        }
    }
}
