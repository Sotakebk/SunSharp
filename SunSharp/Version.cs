﻿namespace SunSharp
{
    public readonly struct Version
    {
        public byte Major { get; }

        public byte Minor { get; }

        public byte Minor2 { get; }

        public Version(byte major, byte minor, byte minor2)
        {
            Major = major;
            Minor = minor;
            Minor2 = minor2;
        }

        public Version(int code)
        {
            Major = (byte)(code >> 16 & 255);
            Minor = (byte)(code >> 8 & 255);
            Minor2 = (byte)(code & 255);
        }

        public override string ToString() => $"SunVox Lib v{Major}.{Minor}.{Minor2}";
    }
}
