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

        public override bool Equals(object obj)
        {
            if (obj is FineTunePair other)
                return Equals(other);

            return false;
        }

        public bool Equals(FineTunePair other)
        {
            return FineTune == other.FineTune && RelativeNote == other.RelativeNote;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FineTune, RelativeNote);
        }

        public override string ToString()
        {
            return $"FineTunePair: fine-tune: {FineTune}, relative note: {RelativeNote}";
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
