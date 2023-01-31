using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Abstractions.Horizontal.Jumping
{
    // TODO make setters init, or properties readonly when raising C# version?

    public class GraphData
    {
        public string Name { get; set; }
        public int? StartStateId { get; set; }
        public IReadOnlyCollection<StateData> States { get; set; }
        public IReadOnlyCollection<TransitionData> Transitions { get; set; }

        public GraphData()
        {
        }

        public static GraphData DeepCopy(GraphData original)
        {
            if (original == null)
                throw new System.ArgumentNullException(nameof(original));

            return new GraphData()
            {
                Name = original.Name,
                StartStateId = original.StartStateId,
                States = original.States.Select(s => StateData.DeepCopy(s)).ToArray(),
                Transitions = original.Transitions.Select(t => TransitionData.DeepCopy(t)).ToArray()
            };
        }
    }

    public class StateData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FirstLine { get; set; }
        public int LastLine { get; set; }

        public StateData()
        {
        }

        public static StateData DeepCopy(StateData original)
        {
            if (original == null)
                throw new System.ArgumentNullException(nameof(original));

            return new StateData()
            {
                Id = original.Id,
                FirstLine = original.FirstLine,
                LastLine = original.LastLine,
                Name = original.Name,
            };
        }
    }

    public class TransitionData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FromStateId { get; set; }
        public int ToStateId { get; set; }
        public bool IsStopping { get; set; }
        public IReadOnlyCollection<int> PatternIds { get; set; }

        public TransitionData()
        {
        }

        public static TransitionData DeepCopy(TransitionData original)
        {
            if (original == null)
                throw new System.ArgumentNullException(nameof(original));

            return new TransitionData()
            {
                Id = original.Id,
                Name = original.Name,
                FromStateId = original.FromStateId,
                ToStateId = original.ToStateId,
                IsStopping = original.IsStopping,
                PatternIds = original.PatternIds.Select(i => i).ToArray()
            };
        }
    }
}
