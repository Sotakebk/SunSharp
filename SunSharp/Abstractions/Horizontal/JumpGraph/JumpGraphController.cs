using SunSharp.ObjectWrapper;
using System;
using System.Linq;
using SunSharp.ThinWrapper;
using System.Collections.Generic;

namespace SunSharp.Abstractions.Horizontal.JumpGraph
{
    public class JumpGraphController
    {
        protected JumpGraph _jumpGraph;
        protected ISunVoxLib _lib;
        protected int _slotId;

        public JumpGraphController(Slot slot, JumpGraphData data) : this(slot, JumpGraph.BuildFromData(data))
        {
            _lib = slot.Library;
            _slotId = slot.Id;
        }

        public JumpGraphController(ISunVoxLib lib, int slotId, JumpGraphData data) : this(lib, slotId, JumpGraph.BuildFromData(data))
        {
            _lib = lib;
            _slotId = slotId;
        }

        public JumpGraphController(Slot slot, JumpGraph graph)
        {
            _lib = slot.Library;
            _slotId = slot.Id;
            _jumpGraph = graph;
        }

        public JumpGraphController(ISunVoxLib lib, int slotId, JumpGraph graph)
        {
            _lib = lib;
            _slotId = slotId;
            _jumpGraph = graph;
        }

        public JumpGraphState GetState(int id)
        {
            var state = _jumpGraph.States.FirstOrDefault(s => s.Id == id);
            if (state == null)
                throw new NullReferenceException($"State with id:{id} not found.");
            else
                return state;
        }

        public JumpGraphState GetState(string name)
        {
            var state = _jumpGraph.States.FirstOrDefault(s => s.Name == name);
            if (state == null)
                throw new NullReferenceException($"State with name:\"{name}\" not found.");
            else
                return state;
        }

        public JumpGraphTransition GetTransition(int id)
        {
            var transition = _jumpGraph.Transitions.FirstOrDefault(s => s.Id == id);
            if (transition == null)
                throw new NullReferenceException($"Transition with id:{id} not found.");
            else
                return transition;
        }

        public JumpGraphTransition GetTransition(string name)
        {
            var transition = _jumpGraph.Transitions.FirstOrDefault(s => s.Name == name);
            if (transition == null)
                throw new NullReferenceException($"Transition with name:\"{name}\" not found.");
            else
                return transition;
        }

        public JumpGraphState GetCurrentState()
        {
            var position = _lib.GetCurrentLine(_slotId);
            return _lib.RunInLock(_slotId, () =>
            {
                return _jumpGraph.States.FirstOrDefault(s => s.FirstLine <= position && s.LastLine >= position);
            });
        }

        public void SetTransitionEnabled(JumpGraphTransition transition, bool enabled)
        {
            _lib.RunInLock(_slotId, () =>
            {
                foreach (var i in transition.PatternIds)
                    _lib.PatternMute(_slotId, i, enabled);
            });
        }

        public void Start(JumpGraphState startingState, JumpGraphState targetState = null, TargetType targetType = TargetType.Either)
        {
            if (startingState.JumpGraph != _jumpGraph)
                throw new ArgumentException("Starting state does not belong to the graph provided in controller construction.");

            if (targetState == null)
            {
                targetState = startingState;
            }
            _lib.RunInLock(_slotId, () =>
            {
                DirectGraphToState(targetState, targetType);
                _lib.SetAutostop(_slotId, true);
                _lib.Rewind(_slotId, startingState.FirstLine);
                _lib.Play(_slotId);
            });
        }

        public void DirectGraphToState(JumpGraphState targetState, TargetType targetType = TargetType.Either)
        {
            if (targetState.JumpGraph != _jumpGraph)
                throw new ArgumentException("Target state does not belong to the graph provided in controller construction.");

            if (targetType == TargetType.Either && targetState.LoopingTransition == null && targetState.StoppingTransition == null)
                throw new ArgumentException("Target state does not have a looping transition or a stopping transition.");

            if (targetType == TargetType.Loop && targetState.LoopingTransition == null)
                throw new ArgumentException("Target state does not have a looping transition.");

            if (targetType == TargetType.Stop && targetState.StoppingTransition == null)
                throw new ArgumentException("Target state does not have a stopping transition.");

            var transitionsToEnable = new HashSet<JumpGraphTransition>();

            var oldStates = new HashSet<JumpGraphState>();
            var states = new HashSet<JumpGraphState>();
            var newStates = new HashSet<JumpGraphState>();
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
                var temp = states;
                states = newStates;
                newStates = temp;
                newStates.Clear();
            }

            _lib.RunInLock(_slotId, () =>
            {
                foreach (var transition in _jumpGraph.Transitions)
                {
                    var enabled = transitionsToEnable.Contains(transition);
                    foreach (var patternId in transition.PatternIds)
                    {
                        _lib.PatternMute(_slotId, patternId, !enabled);
                    }
                }
            });
        }

        public object Select() => throw new NotImplementedException();
    }
}
