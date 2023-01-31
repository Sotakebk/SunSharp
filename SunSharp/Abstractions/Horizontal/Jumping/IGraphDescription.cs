using System.Collections.Generic;

namespace SunSharp.Abstractions.Horizontal.Jumping
{
    public interface IGraphDescription
    {
        string Name { get; }
        IStateDescription StartState { get; }
        IReadOnlyCollection<IStateDescription> DescribedStates { get; }
        IReadOnlyCollection<ITransitionDescription> DescribedTransitions { get; }
    }

    public interface IStateDescription
    {
        string Name { get; }
        string GuideName { get; }
        bool HasLoop { get; }
        bool HasStop { get; }
    }

    public interface ITransitionDescription
    {
        string Name { get; }
        IStateDescription FromState { get; }
        IStateDescription ToState { get; }
    }
}
