using System.Runtime.InteropServices;

namespace SunSharp.ThinWrapper
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct Event
    {
        [FieldOffset(0)]
        public ulong Data;

        [FieldOffset(0)]
        public byte NN;

        [FieldOffset(0)]
        public Note Note;

        [FieldOffset(1)]
        public byte VV;

        [FieldOffset(2)]
        public ushort MM;

        [FieldOffset(4)]
        public ushort CCEE;

        [FieldOffset(5)]
        public byte CC;

        [FieldOffset(4)]
        public byte EE;

        [FieldOffset(6)]
        public ushort XXYY;

        [FieldOffset(6)]
        public byte YY;

        [FieldOffset(7)]
        public byte XX;

        public Event(ulong value) : this()
        {
            Data = value;
        }

        public Event(Note note, byte velocity, ushort module) : this()
        {
            NN = note;
            VV = velocity;
            MM = module;
        }

        public static implicit operator Event(ulong value)
        {
            return new Event(value);
        }

        public static implicit operator ulong(Event ev)
        {
            return ev.Data;
        }

        public override string ToString() => $"{(Note)NN}{VV:X2}{MM:X4}{CC:X2}{EE:X2}{XX:X2}{YY:X2}";
    }
}
