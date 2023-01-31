using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Abstractions.Horizontal.Jumping
{
    public sealed class Graph
    {
        public string Name { get; internal set; }
        public IReadOnlyCollection<State> States { get; internal set; }
        public IReadOnlyCollection<Transition> Transitions { get; internal set; }
        public State StartingState { get; internal set; }

        internal Graph()
        {
        }

        public static Graph BuildFromData(GraphData data)
        {
            var states = data.States.Select(s => new State()
            {
                Id = s.Id,
                Name = s.Name,
                FirstLine = s.FirstLine,
                LastLine = s.LastLine
            }).ToArray();

            var transitions = data.Transitions.Select(t => new Transition()
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

            var graph = new Graph()
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

    public sealed class State
    {
        public Graph JumpGraph { get; internal set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public int FirstLine { get; internal set; }
        public int LastLine { get; internal set; }
        public Transition LoopingTransition { get; internal set; }
        public Transition StoppingTransition { get; internal set; }
        public IReadOnlyCollection<Transition> TransitionsFrom { get; internal set; }
        public IReadOnlyCollection<Transition> TransitionsTo { get; internal set; }

        internal State()
        {
        }
    }

    public sealed class Transition
    {
        public Graph JumpGraph { get; internal set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public bool Stopping { get; internal set; }
        public bool Looping { get; internal set; }
        public State FromState { get; internal set; }
        public State ToState { get; internal set; }
        public IReadOnlyCollection<int> PatternIds { get; internal set; }

        internal Transition()
        {
        }
    }
}
