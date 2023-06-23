using System;
using System.Collections.Generic;
using System.Linq;
using SunSharp.ObjectWrapper;
using SunSharp.ThinWrapper;

namespace SunSharp.DerivedData
{
    public static class DerivedDataFactory
    {
        #region entire song

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
            var modules = ReadModules(lib, slot);
            var patterns = ReadPatterns(lib, slot);

            var songData = new SongData
            {
                Modules = modules,
                Patterns = patterns,
                BPM = lib.GetSongBpm(slot),
                CurrentLine = lib.GetCurrentLine(slot),
                FirstLine = patterns.Min(p => p.Position.X),
                Frames = lib.GetSongLengthInFrames(slot),
                HasDynamicTempo = patterns.Any(p => p.HasDynamicTempo),
                IsDestructive = patterns.Any(p => p.IsDestructive),
                IsLinear = patterns.All(p => p.IsLinear),
                LastLine = patterns.Max(p => p.Position.X + p.Lines),
                Lines = lib.GetSongLengthInLines(slot),
                Name = lib.GetSongName(slot),
                TPL = lib.GetSongTpl(slot)
            };
            return songData;
        }

        #endregion entire song

        #region module data

        internal static ModuleData[] ReadModules(ISunVoxLib lib, int slot)
        {
            var moduleCount = lib.GetUpperModuleCount(slot);
            var modules = new List<ModuleData>(moduleCount);

            for (var i = 0; i < moduleCount; i++)
            {
                if (!lib.GetModuleExists(slot, i))
                    continue;

                var m = ReadModule(lib, slot, i);
                modules.Add(m);
            }

            return modules.ToArray();
        }

        internal static ModuleData ReadModule(ISunVoxLib lib, int slot, int moduleId)
        {
            var flags = lib.GetModuleFlags(slot, moduleId);

            var controllerCount = lib.GetModuleControllerCount(slot, moduleId);
            var controllers = new ControllerData[controllerCount];

            for (var controllerId = 0; controllerId < controllerCount; controllerId++)
            {
                var controllerData = ReadControllerData(lib, slot, moduleId, controllerId);
                controllers[controllerId] = controllerData;
            }

            var moduleData = new ModuleData()
            {
                Bypass = flags.Bypass,
                Color = lib.GetModuleColor(slot, moduleId),
                Controllers = controllers,
                FineTunePair = lib.GetModuleFineTune(slot, moduleId),
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

        #region controller data

        public static ControllerData ReadControllerData(ISunVoxLib lib, int slot, int moduleId, int controllerId)
        {
            var controllerData = new ControllerData
            {
                Id = controllerId,
                Name = lib.GetModuleControllerName(slot, moduleId, controllerId) ?? "undefined",
                Value = lib.GetModuleControllerValue(slot, moduleId, controllerId, ValueScalingType.Real),
                ControllerType = lib.GetModuleControllerType(slot, moduleId, controllerId)
            };
            return controllerData;
        }

        #endregion controller data

        #endregion module data

        #region pattern data

        private static PatternData[] ReadPatterns(ISunVoxLib lib, int slot)
        {
            var patternCount = lib.GetUpperPatternCount(slot);
            var patterns = new List<PatternData>(patternCount);

            for (var i = 0; i < patternCount; i++)
            {
                if (!lib.GetPatternExists(slot, i))
                    continue;

                var p = ReadPatternData(lib, slot, i);
                patterns.Add(p);
            }

            return patterns.ToArray();
        }

        internal static PatternData ReadPatternData(ISunVoxLib lib, int slot, int patternId)
        {
            var data = lib.GetPatternData(slot, patternId) ?? Array.Empty<PatternEvent>();
            var isDestructive = false;
            var isLinear = true;
            var hasDynamicTempo = false;

            foreach (var @event in data)
            {
                isDestructive = @event.Effect.IsDestructive() || isDestructive;
                isLinear = isLinear && !@event.Effect.IsNonLinear();
                hasDynamicTempo = hasDynamicTempo || @event.Effect.ModifiesTime();
            }

            var muted = lib.SetPatternMute(slot, patternId, false);
            lib.SetPatternMute(slot, patternId, muted);

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

        #endregion pattern data
    }
}
