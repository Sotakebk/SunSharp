using System.Runtime.InteropServices;

namespace SunSharp
{
    /// <summary>
    /// Contains beats per minute and ticks per line.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public readonly struct Speed
    {
        /// <summary>
        /// Beats per minute.
        /// </summary>
        [field: FieldOffset(0)]
        public short Bpm { get; }

        /// <summary>
        /// Ticks per line.
        /// </summary>
        [field: FieldOffset(2)]
        public short Tpl { get; }

        [field: FieldOffset(0)]
        public uint Value { get; }

        public Speed(short bpm, short tpl)
        {
            Value = 0;
            Bpm = bpm;
            Tpl = tpl;
        }

        public Speed(uint value)
        {
            Bpm = 0;
            Tpl = 0;
            Value = value;
        }

        public static implicit operator Speed(uint value) => new Speed(value);

        public static implicit operator uint(Speed speed) => speed.Value;

        public override string ToString() => $"BPM: {Bpm}, TPL: {Tpl}";

        public override bool Equals(object? obj)
        {
            return obj is Speed other && Equals(other);
        }

        public bool Equals(Speed other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Speed left, Speed right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Speed left, Speed right)
        {
            return !(left == right);
        }
    }
}
