using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Abstractions.Horizontal.JumpGraph
{
    public sealed class JumpGraph
    {
        public string Name { get; internal set; }
        public IReadOnlyCollection<JumpGraphState> States { get; internal set; }
        public IReadOnlyCollection<JumpGraphTransition> Transitions { get; internal set; }
        public JumpGraphState StartingState { get; internal set; }

        internal JumpGraph()
        {
        }

        public static JumpGraph BuildFromData(JumpGraphData data)
        {
            var states = data.States.Select(s => new JumpGraphState()
            {
                Id = s.Id,
                Name = s.Name,
                FirstLine = s.FirstLine,
                LastLine = s.LastLine
            }).ToArray();

            var transitions = data.Transitions.Select(t => new JumpGraphTransition()
            {
                Id = t.Id,
                Name = t.Name,
                Looping = t.FromStateId == t.ToStateId,
                Stopping = t.IsStopping,
                FromState = states.First(s => s.Id == t.FromStateId),
                ToState = states.First(s => s.Id == t.ToStateId),
                PatternIds = t.PatternIds.Select(i => i).ToArray()
            }).ToArray();

            foreach (var state in states)
            {
                state.LoopingTransition = transitions.FirstOrDefault(t => t.Looping && t.FromState == state);
                state.StoppingTransition = transitions.FirstOrDefault(t => t.Stopping && t.FromState == state);
                state.TransitionsFrom = transitions.Where(t => t.ToState == state
                                                            && t != state.LoopingTransition
                                                            && t != state.StoppingTransition).ToArray();
                state.TransitionsTo = transitions.Where(t => t.FromState == state
                                                          && t != state.LoopingTransition
                                                          && t != state.StoppingTransition).ToArray();
            }

            var graph = new JumpGraph()
            {
                Name = data.Name,
                StartingState = (data.StartStateId != null)
                                ? states.First(s => s.Id == data.StartStateId)
                                : null,
                States = states.ToArray(),
                Transitions = transitions.ToArray()
            };

            foreach (var state in states)
                state.JumpGraph = graph;

            foreach (var transition in transitions)
                transition.JumpGraph = graph;

            return graph;
        }
    }

    public sealed class JumpGraphState
    {
        public JumpGraph JumpGraph { get; internal set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public int FirstLine { get; internal set; }
        public int LastLine { get; internal set; }
        public JumpGraphTransition LoopingTransition { get; internal set; }
        public JumpGraphTransition StoppingTransition { get; internal set; }
        public IReadOnlyCollection<JumpGraphTransition> TransitionsFrom { get; internal set; }
        public IReadOnlyCollection<JumpGraphTransition> TransitionsTo { get; internal set; }

        internal JumpGraphState()
        {
        }
    }

    public sealed class JumpGraphTransition
    {
        public JumpGraph JumpGraph { get; internal set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public bool Stopping { get; internal set; }
        public bool Looping { get; internal set; }
        public JumpGraphState FromState { get; internal set; }
        public JumpGraphState ToState { get; internal set; }
        public IReadOnlyCollection<int> PatternIds { get; internal set; }

        internal JumpGraphTransition()
        {
        }
    }
}
