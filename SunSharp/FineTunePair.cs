using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct FineTunePair : IEquatable<FineTunePair>
    {
        [field: FieldOffset(0)] public uint RawValue { get; set; }
        [field: FieldOffset(0)] public short FineTune { get; set; }
        [field: FieldOffset(2)] public short RelativeNote { get; set; }

        public FineTunePair(uint rawValue) : this()
        {
            RawValue = rawValue;
        }

        public FineTunePair(short fineTune, short relativeNote) : this()
        {
            FineTune = fineTune;
            RelativeNote = relativeNote;
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is FineTunePair other && Equals(other);
        }

        public readonly bool Equals(FineTunePair other)
        {
            return FineTune == other.FineTune && RelativeNote == other.RelativeNote;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(FineTune, RelativeNote);
        }

        public override readonly string ToString()
        {
            return $"Fine-tune: {FineTune}, relative note: {RelativeNote}.";
        }

        public static bool operator ==(FineTunePair left, FineTunePair right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FineTunePair left, FineTunePair right)
        {
            return !left.Equals(right);
        }
    }
}
