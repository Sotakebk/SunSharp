using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PatternEvent : IEquatable<PatternEvent>
    {
        [field: FieldOffset(0)] public ulong Data { get; set; }

        [field: FieldOffset(0)] public byte NN { get; set; }

        [field: FieldOffset(1)] public byte VV { get; set; }

        [field: FieldOffset(2)] public ushort MM { get; set; }

        [field: FieldOffset(4)] public ushort CCEE { get; set; }

        [field: FieldOffset(5)] public byte CC { get; set; }

        [field: FieldOffset(4)] public byte EE { get; set; }

        [field: FieldOffset(6)] public ushort XXYY { get; set; }

        [field: FieldOffset(6)] public byte YY { get; set; }

        [field: FieldOffset(7)] public byte XX { get; set; }

        public Effect Effect
        {
            get => (Effect)EE;
            set => EE = (byte)value;
        }

        public Note Note
        {
            get => (Note)NN;
            set => NN = (byte)value;
        }

        public PatternEvent(ulong value) : this()
        {
            Data = value;
        }

        public PatternEvent(Note note, byte velocity, ushort module) : this()
        {
            NN = note;
            VV = velocity;
            MM = module;
        }

        public PatternEvent(Effect effect, ushort xxyy) : this()
        {
            EE = (byte)effect;
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

        public PatternEvent(Note note, byte velocity, ushort module, byte controller, Effect effect,
            ushort xxyy) : this()
        {
            NN = note;
            VV = velocity;
            MM = module;
            CC = controller;
            EE = (byte)effect;
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

        public override string ToString() => $"{(Note)NN}{VV:X2}{MM:X4}{CC:X2}{EE:X2}{XX:X2}{YY:X2}";

        public static bool operator ==(PatternEvent a, PatternEvent b) => a.Data == b.Data;

        public static bool operator !=(PatternEvent a, PatternEvent b) => a.Data != b.Data;

        public override bool Equals(object obj) => obj is PatternEvent e && this == e;

        public bool Equals(PatternEvent other) => this == other;

        public override int GetHashCode() => -1945990370 + Data.GetHashCode();
    }
}
