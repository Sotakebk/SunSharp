using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Abstractions.Horizontal.JumpGraph
{
    // TODO make setters init, or properties readonly when raising C# version?

    public class JumpGraphData
    {
        public string Name { get; set; }
        public int? StartStateId { get; set; }
        public IReadOnlyCollection<JumpGraphStateData> States { get; set; }
        public IReadOnlyCollection<JumpGraphTransitionData> Transitions { get; set; }

        public JumpGraphData()
        {
        }

        public static JumpGraphData DeepCopy(JumpGraphData original)
        {
            return new JumpGraphData()
            {
                Name = original.Name,
                StartStateId = original.StartStateId,
                States = original.States.Select(s => JumpGraphStateData.DeepCopy(s)).ToArray(),
                Transitions = original.Transitions.Select(t => JumpGraphTransitionData.DeepCopy(t)).ToArray()
            };
        }
    }

    public class JumpGraphStateData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FirstLine { get; set; }
        public int LastLine { get; set; }

        public JumpGraphStateData()
        {
        }

        public static JumpGraphStateData DeepCopy(JumpGraphStateData original)
        {
            return new JumpGraphStateData()
            {
                Id = original.Id,
                FirstLine = original.FirstLine,
                LastLine = original.LastLine,
                Name = original.Name,
            };
        }
    }

    public class JumpGraphTransitionData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FromStateId { get; set; }
        public int ToStateId { get; set; }
        public bool IsStopping { get; set; }
        public IReadOnlyCollection<int> PatternIds { get; set; }

        public JumpGraphTransitionData()
        {
        }

        public static JumpGraphTransitionData DeepCopy(JumpGraphTransitionData original)
        {
            return new JumpGraphTransitionData()
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
