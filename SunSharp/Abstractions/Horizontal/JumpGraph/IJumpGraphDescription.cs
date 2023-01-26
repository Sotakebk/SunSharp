using System.Collections.Generic;

namespace SunSharp.Abstractions.Horizontal.JumpGraph
{
    public interface IJumpGraphDescription
    {
        string Name { get; }
        IDescribedState StartState { get; }
        IReadOnlyCollection<IDescribedState> DescribedStates { get; }
        IReadOnlyCollection<IDescribedTransition> DescribedTransitions { get; }
    }

    public interface IDescribedState
    {
        string Name { get; }
        string GuideName { get; }
        bool HasLoop { get; }
        bool HasStop { get; }
    }

    public interface IDescribedTransition
    {
        string Name { get; }
        IDescribedState From { get; }
        IDescribedState To { get; }
    }
}
