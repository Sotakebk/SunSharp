using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    /// <summary>
    /// Represents a pair of fine-tune and relative note adjustment values.
    /// Used for per-module configuration.
    /// </summary>
    /// <seealso cref="ISynthModuleHandle"/>
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public readonly struct FineTunePair : IEquatable<FineTunePair>
    {
        [field: FieldOffset(0)] public uint RawValue { get; }

        /// <summary>
        /// The fine-tune adjustment value.
        /// The value range is -0x0100 (-1 semitone) to 0x0100 (+1 semitone).
        /// </summary>
        [field: FieldOffset(0)] public short FineTune { get; }

        /// <summary>
        /// The relative note adjustment in semitones.
        /// </summary>
        [field: FieldOffset(2)] public short RelativeNote { get; }

        public FineTunePair(uint rawValue) : this()
        {
            RawValue = rawValue;
        }

        public FineTunePair(short fineTune, short relativeNote) : this()
        {
            FineTune = fineTune;
            RelativeNote = relativeNote;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is FineTunePair other && Equals(other);
        }

        /// <inheritdoc/>
        public bool Equals(FineTunePair other)
        {
            return FineTune == other.FineTune && RelativeNote == other.RelativeNote;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(RawValue);
        }

        /// <inheritdoc/>
        public override string ToString()
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
