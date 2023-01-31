using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Abstractions.Horizontal.Jumping
{
    public class SimpleGraphDescription : IGraphDescription
    {
        public string Name { get; set; }
        public int? StartStateId { get; set; }
        IStateDescription IGraphDescription.StartState => (StartStateId == null) ? null : DescribedStates.First(s => s.Id == StartStateId);
        IReadOnlyCollection<IStateDescription> IGraphDescription.DescribedStates => DescribedStates;
        IReadOnlyCollection<ITransitionDescription> IGraphDescription.DescribedTransitions => DescribedTransitions;

        public List<SimpleStateDescription> DescribedStates { get; private set; }
        public List<SimpleTransitionDescription> DescribedTransitions { get; private set; }

        public SimpleGraphDescription()
        {
            DescribedStates = new List<SimpleStateDescription>();
            DescribedTransitions = new List<SimpleTransitionDescription>();
        }

        public SimpleStateDescription AddState(string name, string guideName, int? id = null, bool hasLoop = false, bool hasStop = false)
        {
            if (id == null)
                id = (DescribedStates.Count == 0) ? 0 : DescribedStates.Max(s => s.Id) + 1;

            var state = new SimpleStateDescription()
            {
                Id = id.Value,
                Name = name,
                GraphDescription = this,
                GuideName = guideName,
                HasLoop = hasLoop,
                HasStop = hasStop
            };

            DescribedStates.Add(state);
            return state;
        }

        public SimpleTransitionDescription AddTransition(string name, SimpleStateDescription from, SimpleStateDescription to, int? id = null)
        {
            if (id == null)
                id = (DescribedTransitions.Count == 0) ? 0 : DescribedTransitions.Max(s => s.Id) + 1;

            var transition = new SimpleTransitionDescription()
            {
                Id = id.Value,
                GraphDescription = this,
                StateFromId = from.Id,
                StateToId = to.Id,
                Name = name
            };

            DescribedTransitions.Add(transition);
            return transition;
        }
    }

    public class SimpleStateDescription : IStateDescription
    {
        public SimpleGraphDescription GraphDescription { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string GuideName { get; set; }
        public bool HasLoop { get; set; }
        public bool HasStop { get; set; }

        public SimpleStateDescription()
        {
        }
    }

    public class SimpleTransitionDescription : ITransitionDescription
    {
        public SimpleGraphDescription GraphDescription { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int StateFromId { get; set; }
        public int StateToId { get; set; }

        public IStateDescription FromState => GraphDescription.DescribedStates.First(s => s.Id == StateFromId);
        public IStateDescription ToState => GraphDescription.DescribedStates.First(s => s.Id == StateToId);

        public SimpleTransitionDescription()
        {
        }
    }
}
