using System;

namespace SunSharp
{
    [Serializable]
    public struct FineTunePair : IEquatable<FineTunePair>
    {
        public short FineTune { get; set; }
        public short RelativeNote { get; set; }

        public readonly uint Value => Helper.PackTwoSignedShorts(FineTune, RelativeNote);

        public FineTunePair(short fineTune, short relativeNote)
        {
            FineTune = fineTune;
            RelativeNote = relativeNote;
        }

        public FineTunePair(uint value)
        {
            (FineTune, RelativeNote) = Helper.UnpackTwoSignedShorts(value);
        }

        public readonly override bool Equals(object? obj)
        {
            if (obj is FineTunePair other)
                return Equals(other);

            return false;
        }

        public readonly bool Equals(FineTunePair other)
        {
            return FineTune == other.FineTune && RelativeNote == other.RelativeNote;
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(FineTune, RelativeNote);
        }

        public readonly override string ToString()
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
