using SunSharp.ObjectWrapper;
using SunSharp.ThinWrapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Abstractions.Horizontal.Jumping
{
    public class GraphController
    {
        protected Graph Graph { get; set; }
        protected ISunVoxLib Lib { get; set; }
        protected int SlotId { get; set; }

        public GraphController(Slot slot, GraphData data) : this(slot, Graph.BuildFromData(data))
        {
            Lib = slot.Library;
            SlotId = slot.Id;
        }

        public GraphController(ISunVoxLib lib, int slotId, GraphData data) : this(lib, slotId, Graph.BuildFromData(data))
        {
            Lib = lib;
            SlotId = slotId;
        }

        public GraphController(Slot slot, Graph graph)
        {
            Lib = slot.Library;
            SlotId = slot.Id;
            Graph = graph;
        }

        public GraphController(ISunVoxLib lib, int slotId, Graph graph)
        {
            Lib = lib;
            SlotId = slotId;
            Graph = graph;
        }

        public State GetState(int id)
        {
            return Graph.States.FirstOrDefault(s => s.Id == id);
        }

        public State GetState(string name)
        {
            return Graph.States.FirstOrDefault(s => s.Name == name);
        }

        public Transition GetTransition(int id)
        {
            return Graph.Transitions.FirstOrDefault(s => s.Id == id);
        }

        public Transition GetTransition(string name)
        {
            return Graph.Transitions.FirstOrDefault(s => s.Name == name);
        }

        public State GetCurrentState()
        {
            var position = Lib.GetCurrentLine(SlotId);
            return Lib.RunInLock(SlotId, () =>
            {
                return Graph.States.FirstOrDefault(s => s.FirstLine <= position && s.LastLine >= position);
            });
        }

        public void SetTransitionEnabled(Transition transition, bool enabled)
        {
            Lib.RunInLock(SlotId, () =>
            {
                foreach (var i in transition.PatternIds)
                    Lib.SetPatternMute(SlotId, i, enabled);
            });
        }

        public void Start(State startingState, State targetState = null, TargetType targetType = TargetType.Either)
        {
            if (startingState.JumpGraph != Graph)
                throw new ArgumentException("Starting state does not belong to the graph provided in controller construction.");

            if (targetState == null)
            {
                targetState = startingState;
            }
            Lib.RunInLock(SlotId, () =>
            {
                DirectGraphToState(targetState, targetType);
                Lib.SetAutostop(SlotId, true);
                Lib.Rewind(SlotId, startingState.FirstLine);
                Lib.Play(SlotId);
            });
        }

        public void DirectGraphToState(State targetState, TargetType targetType = TargetType.Either)
        {
            if (targetState.JumpGraph != Graph)
                throw new ArgumentException("Target state does not belong to the graph provided in controller construction.");

            if (targetType == TargetType.Either && targetState.LoopingTransition == null && targetState.StoppingTransition == null)
                throw new ArgumentException("Target state does not have a looping transition or a stopping transition.");

            if (targetType == TargetType.Loop && targetState.LoopingTransition == null)
                throw new ArgumentException("Target state does not have a looping transition.");

            if (targetType == TargetType.Stop && targetState.StoppingTransition == null)
                throw new ArgumentException("Target state does not have a stopping transition.");

            var transitionsToEnable = new HashSet<Transition>();

            var oldStates = new HashSet<State>();
            var states = new HashSet<State>();
            var newStates = new HashSet<State>();
            states.Add(targetState);

            if (targetType == TargetType.Either)
            {
                if (targetState.LoopingTransition != null)
                    transitionsToEnable.Add(targetState.LoopingTransition);
                else
                    transitionsToEnable.Add(targetState.StoppingTransition);
            }
            else if (targetType == TargetType.Loop)
                transitionsToEnable.Add(targetState.LoopingTransition);
            else if (targetType == TargetType.Stop)
                transitionsToEnable.Add(targetState.StoppingTransition);
            else
                throw new ArgumentException("Unsupported value.", nameof(targetType));

            while (states.Any())
            {
                foreach (var state in states)
                {
                    foreach (var transition in state.TransitionsFrom)
                    {
                        if (transition.ToState != transition.FromState
                            && !oldStates.Contains(transition.ToState)
                            && !oldStates.Contains(transition.FromState)
                            && !states.Contains(transition.FromState))
                        {
                            newStates.Add(transition.FromState);
                            transitionsToEnable.Add(transition);
                        }
                    }
                    oldStates.Add(state);
                }
                (newStates, states) = (states, newStates);
                newStates.Clear();
            }

            Lib.RunInLock(SlotId, () =>
            {
                foreach (var transition in Graph.Transitions)
                {
                    var enabled = transitionsToEnable.Contains(transition);
                    foreach (var patternId in transition.PatternIds)
                    {
                        Lib.SetPatternMute(SlotId, patternId, !enabled);
                    }
                }
            });
        }

        public object Select() => throw new NotImplementedException();
    }
}
