using SunSharp.ThinWrapper;
using System.Collections.Generic;

namespace SunSharp.DerivedData
{
    public interface ISongData<T, V>
        where T : IModuleData
        where V : IPatternData
    {
        string Name { get; }
        int BPM { get; }
        int TPL { get; }
        int Frames { get; }
        int Lines { get; }
        int CurrentLine { get; }
        int FirstLine { get; }
        int LastLine { get; }
        bool IsLinear { get; }
        bool IsDestructive { get; }
        bool HasDynamicTempo { get; }
        IReadOnlyCollection<T> Modules { get; }
        IReadOnlyCollection<V> Patterns { get; }
    }

    public interface IModuleData
    {
        int Id { get; }
        string Name { get; }
        (int X, int Y) Position { get; }
        (int finetune, int relativeNote) Finetune { get; }
        bool Solo { get; }
        bool Mute { get; }
        bool Bypass { get; }
        (int R, int G, int B) Color { get; }
        IReadOnlyCollection<(string name, int value)> Controllers { get; }
        IReadOnlyCollection<int> Inputs { get; }
        IReadOnlyCollection<int> Outputs { get; }
    }

    public interface IPatternData
    {
        int Id { get; }
        string Name { get; }
        (int X, int Y) Position { get; }
        int Lines { get; }
        int Tracks { get; }
        bool IsMuted { get; }
        bool IsLinear { get; }
        bool IsDestructive { get; }
        bool HasDynamicTempo { get; }
        IReadOnlyCollection<ReadOnlyEvent> Data { get; }
    }
}
