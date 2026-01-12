using System;
using System.Collections.Generic;
using System.Linq;
using SunSharp.Native;

namespace SunSharp.Data
{
    public static class SongDataReader
    {
        public static SongData ReadSongData(Slot slot)
        {
            return ReadSongData(slot.Library, slot.Id);
        }

        public static SongData ReadSongData(ISunVoxLib lib, int slotId)
        {
            lib.LockSlot(slotId);
            try
            {
                return ReadSongDataInternal(lib, slotId);
            }
            finally
            {
                lib.UnlockSlot(slotId);
            }
        }

        internal static SongData ReadSongDataInternal(ISunVoxLib lib, int slotId)
        {
            var modules = ReadModules(lib, slotId);
            var patterns = ReadPatterns(lib, slotId);

            var songData = new SongData
            {
                Name = lib.GetSongName(slotId),
                TPL = lib.GetSongTpl(slotId),
                BPM = lib.GetSongBpm(slotId),

                Lines = lib.GetSongLengthInLines(slotId),
                CurrentLine = lib.GetCurrentLine(slotId),
                FirstLine = patterns.Length == 0 ? 0 : patterns.Min(p => p.Position.X),
                LastLine = patterns.Length == 0 ? 0 : patterns.Max(p => p.Position.X + p.Lines),

                Modules = modules,
                Patterns = patterns
            };
            return songData;
        }

        #region module data

        internal static ModuleData[] ReadModules(ISunVoxLib lib, int slotId)
        {
            var moduleCount = lib.GetUpperModuleCount(slotId);
            var modules = new List<ModuleData>(moduleCount);

            for (var i = 0; i < moduleCount; i++)
            {
                if (!lib.GetModuleExists(slotId, i))
                {
                    continue;
                }

                var m = ReadModule(lib, slotId, i);
                modules.Add(m);
            }

            return modules.ToArray();
        }

        internal static ModuleData ReadModule(ISunVoxLib lib, int slotId, int moduleId)
        {
            var flags = lib.GetModuleFlags(slotId, moduleId);

            var controllerCount = lib.GetModuleControllerCount(slotId, moduleId);
            var controllers = new ControllerData[controllerCount];

            for (var controllerId = 0; controllerId < controllerCount; controllerId++)
            {
                var controllerData = ReadControllerData(lib, slotId, moduleId, controllerId);
                controllers[controllerId] = controllerData;
            }

            var moduleData = new ModuleData
            {
                Id = moduleId,
                Name = lib.GetModuleName(slotId, moduleId),
                Type = lib.GetModuleType(slotId, moduleId),

                Position = lib.GetModulePosition(slotId, moduleId),
                Color = lib.GetModuleColor(slotId, moduleId),
                FineTune = lib.GetModuleFineTune(slotId, moduleId),
                Flags = flags,
                Controllers = controllers,

                Inputs = lib.GetModuleInputs(slotId, moduleId),
                Outputs = lib.GetModuleOutputs(slotId, moduleId)
            };
            return moduleData;
        }

        #region controller data

        internal static ControllerData ReadControllerData(ISunVoxLib lib, int slotId, int moduleId, int controllerId)
        {
            var controllerData = new ControllerData
            {
                Id = controllerId,
                Name = lib.GetModuleControllerName(slotId, moduleId, controllerId) ?? "undefined",

                Value = lib.GetModuleControllerValue(slotId, moduleId, controllerId, ValueScalingMode.Real),
                MinValue = lib.GetModuleControllerMinValue(slotId, moduleId, controllerId, ValueScalingMode.Real),
                MaxValue = lib.GetModuleControllerMaxValue(slotId, moduleId, controllerId, ValueScalingMode.Real),
                Offset = lib.GetModuleControllerOffset(slotId, moduleId, controllerId),

                ControllerType = lib.GetModuleControllerType(slotId, moduleId, controllerId),
                Group = lib.GetModuleControllerGroup(slotId, moduleId, controllerId)
            };
            return controllerData;
        }

        #endregion controller data

        #endregion module data

        #region pattern data

        internal static PatternData[] ReadPatterns(ISunVoxLib lib, int slotId)
        {
            var patternCount = lib.GetUpperPatternCount(slotId);
            var patterns = new List<PatternData>(patternCount);

            for (var i = 0; i < patternCount; i++)
            {
                if (!lib.GetPatternExists(slotId, i))
                {
                    continue;
                }

                var p = ReadPattern(lib, slotId, i);
                patterns.Add(p);
            }

            return patterns.ToArray();
        }

        internal static PatternData ReadPattern(ISunVoxLib lib, int slotId, int patternId)
        {
            var (data, tracks, lines) = lib.GetPatternData(slotId, patternId) ??
                                        throw new ArgumentException($"The slot {slotId} does not exist.");
            var isDestructive = false;
            var isLinear = true;
            var hasDynamicTempo = false;

            for (var i = 0; i < data.Length; i++)
            {
                var e = data[i];
                isDestructive = isDestructive || e.Effect.IsDestructive();
                isLinear = isLinear && !e.Effect.IsNonLinear();
                hasDynamicTempo = hasDynamicTempo || e.Effect.ChangesTempo();
            }

            return new PatternData
            {
                Id = patternId,
                Name = lib.GetPatternName(slotId, patternId),

                HasDynamicTempo = hasDynamicTempo,
                IsDestructive = isDestructive,
                IsLinear = isLinear,
                IsMuted = lib.GetPatternMuted(slotId, patternId),

                Position = lib.GetPatternPosition(slotId, patternId),
                Lines = lines,
                Tracks = tracks,

                Data = data
            };
        }

        #endregion pattern data
    }
}
