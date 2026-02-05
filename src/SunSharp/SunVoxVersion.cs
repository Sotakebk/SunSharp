using System;

namespace SunSharp
{
    /// <summary>
    /// Represents the version of the SunVox library.
    /// </summary>
    public readonly struct SunVoxVersion : IEquatable<SunVoxVersion>
    {
        public byte Major { get; }

        public byte Minor { get; }

        public byte Minor2 { get; }

        public byte Bugfix { get; }

        public SunVoxVersion(byte major, byte minor, byte minor2, byte bugfix)
        {
            Major = major;
            Minor = minor;
            Minor2 = minor2;
            Bugfix = bugfix;
        }

        public static SunVoxVersion FromLibraryVersion(int code)
        {
            var major = (byte)((code >> 16) & 0xFF);
            var minor = (byte)((code >> 8) & 0xFF);
            var minor2 = (byte)(code & 0xFF);
            return new SunVoxVersion(major, minor, minor2, 0);
        }

        public static SunVoxVersion FromProjectBaseVersion(int code)
        {
            var major = (byte)((code >> 24) & 0xFF);
            var minor = (byte)((code >> 16) & 0xFF);
            var minor2 = (byte)((code >> 8) & 0xFF);
            var bugfix = (byte)(code & 0xFF);
            return new SunVoxVersion(major, minor, minor2, bugfix);
        }

        public override string ToString()
        {
            return $"version {Major}.{Minor}.{Minor2}.{Bugfix}";
        }

        public bool Equals(SunVoxVersion other)
        {
            return Major == other.Major && Minor == other.Minor && Minor2 == other.Minor2 && Bugfix == other.Bugfix;
        }

        public override bool Equals(object obj)
        {
            return obj is SunVoxVersion other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Major, Minor, Minor2, Bugfix);
        }

        public static bool operator ==(SunVoxVersion left, SunVoxVersion right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SunVoxVersion left, SunVoxVersion right)
        {
            return !left.Equals(right);
        }
    }
}
