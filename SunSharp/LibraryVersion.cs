using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    /// <summary>
    /// Represents the version of the SunVox library.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public readonly struct LibraryVersion : IEquatable<LibraryVersion>
    {
        [FieldOffset(0)] private readonly int _value;
        [FieldOffset(2)] private readonly byte _major;
        [FieldOffset(1)] private readonly byte _minor;
        [FieldOffset(0)] private readonly byte _minor2;

        public byte Major => _major;

        public byte Minor => _minor;

        public byte Minor2 => _minor2;

        public LibraryVersion(int code)
        {
            _major = _minor = _minor2 = 0; // unfortunately required
            _value = code;
        }

        public override string ToString()
        {
            return $"SunVox Lib v{Major}.{Minor}.{Minor2}";
        }

        public bool Equals(LibraryVersion other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            return obj is LibraryVersion other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public static bool operator ==(LibraryVersion left, LibraryVersion right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LibraryVersion left, LibraryVersion right)
        {
            return !left.Equals(right);
        }
    }
}
