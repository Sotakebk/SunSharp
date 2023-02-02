using SunSharp.ObjectWrapper;
using SunSharp.ThinWrapper;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.DerivedData
{
    public interface IReadOnlyPatternData
    {
        int Id { get; }
        string Name { get; }
        (int X, int Y) Position { get; }
        int Lines { get; }
        int Tracks { get; }
        bool IsMuted { get; }
        bool IsLinear { get; }
        bool IsDestructive { get; }
        bool HasDynamicTempo { get; }
        IReadOnlyCollection<ImmutablePatternEvent> Data { get; }
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
        public ICollection<ImmutablePatternEvent> Data { get; set; }

        IReadOnlyCollection<ImmutablePatternEvent> IReadOnlyPatternData.Data => Data.AsReadonlyOrGetWrapper();

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

        public static PatternData ReadModuleData(ISunVoxLib lib, int slotId, int patternId)
        {
            return lib.RunInLock(slotId, () => ReadPatternDataInternal(lib, slotId, patternId));
        }

        public static PatternData ReadModuleData(PatternHandle pattern)
        {
            return pattern.Slot.RunInLock(() => ReadPatternDataInternal(pattern.Slot.Library, pattern.Slot.Id, pattern.Id));
        }

        internal static PatternData ReadPatternDataInternal(ISunVoxLib lib, int slot, int patternId)
        {
            var data = lib.GetPatternData(slot, patternId).Select(e => (ImmutablePatternEvent)e).ToArray();
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

            bool muted = lib.SetPatternMute(slot, patternId, false);
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
    }
}
