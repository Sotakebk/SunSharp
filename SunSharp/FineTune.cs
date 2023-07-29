using System;

namespace SunSharp
{
    [Serializable]
    public struct FineTunePair
    {
        public short FineTune { get; set; }
        public short RelativeNote { get; set; }

        public FineTunePair(short fineTune, short relativeNote)
        {
            FineTune = fineTune;
            RelativeNote = relativeNote;
        }

        public override readonly bool Equals(object obj)
        {
            if (obj is FineTunePair other)
                return Equals(other);

            return false;
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
            return $"FineTune: fine-tune: {FineTune}, relative note: {RelativeNote}";
        }

        public static bool operator ==(FineTunePair left, FineTunePair right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FineTunePair left, FineTunePair right)
        {
            return !(left == right);
        }
    }
}
