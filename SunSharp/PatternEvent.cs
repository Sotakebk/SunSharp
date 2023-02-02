using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public readonly struct ImmutablePatternEvent : IEquatable<PatternEvent>, IEquatable<ImmutablePatternEvent>
    {
        [FieldOffset(0)] private readonly ulong _data;
        [FieldOffset(0)] private readonly byte _nn;
        [FieldOffset(1)] private readonly byte _vv;
        [FieldOffset(2)] private readonly ushort _mm;
        [FieldOffset(4)] private readonly ushort _ccee;
        [FieldOffset(4)] private readonly byte _ee;
        [FieldOffset(5)] private readonly byte _cc;
        [FieldOffset(6)] private readonly ushort _xxyy;
        [FieldOffset(6)] private readonly byte _yy;
        [FieldOffset(7)] private readonly byte _xx;

        public ulong Data => _data;
        public byte NN => _nn;
        public Note Note => (Note)_nn;
        public byte VV => _vv;
        public ushort MM => _mm;
        public ushort CCEE => _ccee;
        public byte CC => _cc;
        public byte EE => _ee;
        public Effect Effect => (Effect)EE;
        public ushort XXYY => _xxyy;
        public byte YY => _yy;
        public byte XX => _xx;

        public ImmutablePatternEvent(ulong value) : this()
        {
            _data = value;
        }

        public ImmutablePatternEvent(PatternEvent @event) : this(@event.Data)
        {
        }

        public ImmutablePatternEvent(byte nn, byte vv, ushort mm, ushort ccee, ushort xxyy) : this()
        {
            _nn = nn;
            _vv = vv;
            _mm = mm;
            _ccee = ccee;
            _xxyy = xxyy;
        }

        public ImmutablePatternEvent(Note note, byte velocity, ushort module, byte controller, Effect effect, ushort xxyy) : this()
        {
            _nn = (byte)note;
            _vv = velocity;
            _mm = module;
            _cc = controller;
            _ee = (byte)effect;
            _xxyy = xxyy;
        }

        public static implicit operator ImmutablePatternEvent(ulong value)
        {
            return new ImmutablePatternEvent(value);
        }

        public static implicit operator ulong(ImmutablePatternEvent ev)
        {
            return ev.Data;
        }

        public override string ToString() => $"{(Note)NN}{VV:X2}{MM:X4}{CC:X2}{EE:X2}{XX:X2}{YY:X2}";

        public static bool operator ==(ImmutablePatternEvent a, ImmutablePatternEvent b) => a._data == b._data;

        public static bool operator !=(ImmutablePatternEvent a, ImmutablePatternEvent b) => a._data != b._data;

        public override bool Equals(object obj)
        {
            if (obj is ImmutablePatternEvent readOnlyEvent) return readOnlyEvent._data == _data;
            if (obj is PatternEvent @event) return @event.Data == _data;
            return false;
        }

        public bool Equals(PatternEvent other) => this == other;

        public override int GetHashCode() => -1945990370 + _data.GetHashCode();

        public bool Equals(ImmutablePatternEvent other) => _data == other.Data;
    }

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PatternEvent : IEquatable<PatternEvent>, IEquatable<ImmutablePatternEvent>
    {
        [FieldOffset(0)] private ulong _data;
        [FieldOffset(0)] private byte _nn;
        [FieldOffset(1)] private byte _vv;
        [FieldOffset(2)] private ushort _mm;
        [FieldOffset(4)] private ushort _ccee;
        [FieldOffset(4)] private byte _ee;
        [FieldOffset(5)] private byte _cc;
        [FieldOffset(6)] private ushort _xxyy;
        [FieldOffset(6)] private byte _yy;
        [FieldOffset(7)] private byte _xx;

        public ulong Data { get => _data; set => _data = value; }
        public byte NN { get => _nn; set => _nn = value; }
        public Note Note { get => (Note)_nn; set => _nn = (byte)value; }
        public byte VV { get => _vv; set => _vv = value; }
        public ushort MM { get => _mm; set => _mm = value; }
        public ushort CCEE { get => _ccee; set => _ccee = value; }
        public byte CC { get => _cc; set => _cc = value; }
        public byte EE { get => _ee; set => _ee = value; }
        public Effect Effect { get => (Effect)_ee; set => _ee = (byte)value; }
        public ushort XXYY { get => _xxyy; set => _xxyy = value; }
        public byte YY { get => _yy; set => _yy = value; }
        public byte XX { get => _xx; set => _xx = value; }

        public PatternEvent(ulong value) : this()
        {
            _data = value;
        }

        public PatternEvent(Note note, byte velocity, ushort module) : this()
        {
            _nn = note;
            _vv = velocity;
            _mm = module;
        }

        public PatternEvent(Effect effect, ushort xxyy) : this()
        {
            _ee = (byte)effect;
            _xxyy = xxyy;
        }

        public PatternEvent(byte nn, byte vv, ushort mm, ushort ccee, ushort xxyy) : this()
        {
            _nn = nn;
            _vv = vv;
            _mm = mm;
            _ccee = ccee;
            _xxyy = xxyy;
        }

        public PatternEvent(Note note, byte velocity, ushort module, byte controller, Effect effect, ushort xxyy) : this()
        {
            _nn = (byte)note;
            _vv = velocity;
            _mm = module;
            _cc = controller;
            _ee = (byte)effect;
            _xxyy = xxyy;
        }

        public static implicit operator PatternEvent(ulong value)
        {
            return new PatternEvent(value);
        }

        public static implicit operator ulong(PatternEvent @event)
        {
            return @event.Data;
        }

        public static implicit operator ImmutablePatternEvent(PatternEvent @event)
        {
            return new ImmutablePatternEvent(@event._data);
        }

        public override string ToString() => $"{(Note)NN}{VV:X2}{MM:X4}{CC:X2}{EE:X2}{XX:X2}{YY:X2}";

        public static bool operator ==(PatternEvent a, PatternEvent b) => a._data == b._data;

        public static bool operator !=(PatternEvent a, PatternEvent b) => a._data != b._data;

        public override bool Equals(object obj) => obj is PatternEvent e && this == e;

        public bool Equals(PatternEvent other) => this == other;

        public override int GetHashCode() => -1945990370 + _data.GetHashCode();

        public bool Equals(ImmutablePatternEvent other) => _data == other.Data;
    }
}
