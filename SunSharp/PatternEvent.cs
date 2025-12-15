using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PatternEvent : IEquatable<PatternEvent>
    {
        /// <summary>
        /// Gets or sets the raw 64-bit data value.
        /// </summary>
        [field: FieldOffset(0)] public ulong Data { get; set; }

        [field: FieldOffset(0)] public byte NN { get; set; }

        [field: FieldOffset(1)] public byte VV { get; set; }

        [field: FieldOffset(2)] public ushort MM { get; set; }

        [field: FieldOffset(4)] public ushort CCEE { get; set; }

        [field: FieldOffset(4)] public byte EE { get; set; }

        [field: FieldOffset(5)] public byte CC { get; set; }

        [field: FieldOffset(6)] public ushort XXYY { get; set; }

        [field: FieldOffset(7)] public byte YY { get; set; }

        [field: FieldOffset(6)] public byte XX { get; set; }

        public Effect Effect
        {
            readonly get => (Effect)EE;
            set => EE = (byte)value;
        }

        public Note Note
        {
            readonly get => NN;
            set => NN = value;
        }

        public PatternEvent(ulong value) : this()
        {
            Data = value;
        }

        public PatternEvent(Note nn, byte vv, ushort mm) : this()
        {
            NN = nn;
            VV = vv;
            MM = mm;
        }

        public PatternEvent(Effect ee, ushort xxyy) : this()
        {
            EE = (byte)ee;
            XXYY = xxyy;
        }

        public PatternEvent(byte nn, byte vv, ushort mm, ushort ccee, ushort xxyy) : this()
        {
            NN = nn;
            VV = vv;
            MM = mm;
            CCEE = ccee;
            XXYY = xxyy;
        }

        public PatternEvent(Note nn, byte vv, ushort mm, byte cc, Effect ee, ushort xxyy) : this()
        {
            NN = nn;
            VV = vv;
            MM = mm;
            CC = cc;
            EE = (byte)ee;
            XXYY = xxyy;
        }

        public PatternEvent(Note nn, byte vv, ushort mm, byte cc, byte ee, ushort xxyy) : this()
        {
            NN = nn;
            VV = vv;
            MM = mm;
            CC = cc;
            EE = ee;
            XXYY = xxyy;
        }

        public static implicit operator PatternEvent(ulong value)
        {
            return new PatternEvent(value);
        }

        public static implicit operator ulong(PatternEvent @event)
        {
            return @event.Data;
        }

        public readonly override string ToString()
        {
            return $"{(Note)NN}" +
                   $"{(VV != 0 ? $"{VV:X2}" : "__")}" +
                   $"{(MM != 0 ? $"{MM:X4}" : "__")}" +
                   $"{(CC != 0 ? $"{CC:X2}" : "__")}" +
                   $"{(EE != 0 ? $"{EE:X2}" : "__")}" +
                   $"{(XXYY != 0 ? $"{XXYY:X4}" : "__")}";
        }

        public static bool operator ==(PatternEvent a, PatternEvent b)
        {
            return a.Data == b.Data;
        }

        public static bool operator !=(PatternEvent a, PatternEvent b)
        {
            return a.Data != b.Data;
        }

        public readonly override bool Equals(object? obj)
        {
            return obj is PatternEvent e && this == e;
        }

        public readonly bool Equals(PatternEvent other)
        {
            return this == other;
        }

        public readonly override int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }
}
