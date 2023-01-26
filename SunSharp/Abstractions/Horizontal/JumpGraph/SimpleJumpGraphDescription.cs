using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Abstractions.Horizontal.JumpGraph
{
    public class SimpleJumpGraphDescription : IJumpGraphDescription
    {
        public string Name { get; set; }
        public int? StartStateId { get; set; }
        IDescribedState IJumpGraphDescription.StartState => (StartStateId == null) ? null : DescribedStates.First(s => s.Id == StartStateId);
        IReadOnlyCollection<IDescribedState> IJumpGraphDescription.DescribedStates => DescribedStates;
        IReadOnlyCollection<IDescribedTransition> IJumpGraphDescription.DescribedTransitions => DescribedTransitions;

        public List<SimpleDescribedState> DescribedStates;
        public List<SimpleDescribedTransition> DescribedTransitions;

        public SimpleJumpGraphDescription()
        {
            DescribedStates = new List<SimpleDescribedState>();
            DescribedTransitions = new List<SimpleDescribedTransition>();
        }

        public SimpleDescribedState AddState(string name, string guideName, int? id = null, bool hasLoop = false, bool hasStop = false)
        {
            if (id == null)
                id = (DescribedStates.Count == 0) ? 0 : DescribedStates.Max(s => s.Id) + 1;

            var state = new SimpleDescribedState()
            {
                Id = id.Value,
                Name = name,
                Description = this,
                GuideName = guideName,
                HasLoop = hasLoop,
                HasStop = hasStop
            };

            DescribedStates.Add(state);
            return state;
        }

        public SimpleDescribedTransition AddTransition(string name, SimpleDescribedState from, SimpleDescribedState to, int? id = null)
        {
            if (id == null)
                id = (DescribedTransitions.Count == 0) ? 0 : DescribedTransitions.Max(s => s.Id) + 1;

            var transition = new SimpleDescribedTransition()
            {
                Id = id.Value,
                Description = this,
                StateFromId = from.Id,
                StateToId = to.Id,
                Name = name
            };

            DescribedTransitions.Add(transition);
            return transition;
        }
    }

    public class SimpleDescribedState : IDescribedState
    {
        public SimpleJumpGraphDescription Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string GuideName { get; set; }
        public bool HasLoop { get; set; }
        public bool HasStop { get; set; }

        public SimpleDescribedState()
        {
        }
    }

    public class SimpleDescribedTransition : IDescribedTransition
    {
        public SimpleJumpGraphDescription Description { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int StateFromId { get; set; }
        public int StateToId { get; set; }

        public IDescribedState From => Description.DescribedStates.First(s => s.Id == StateFromId);
        public IDescribedState To => Description.DescribedStates.First(s => s.Id == StateToId);

        public SimpleDescribedTransition()
        {
        }
    }
}
