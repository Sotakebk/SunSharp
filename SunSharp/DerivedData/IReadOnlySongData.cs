using SunSharp.ThinWrapper;
using System.Collections.Generic;

namespace SunSharp.DerivedData
{
    public interface IReadOnlySongData
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
        IReadOnlyCollection<IReadOnlyModuleData> Modules { get; }
        IReadOnlyCollection<IReadOnlyPatternData> Patterns { get; }
    }

    public interface IReadOnlyModuleData
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

    public interface IReadOnlyPatternData
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
