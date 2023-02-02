namespace SunSharp
{
    public readonly struct Version
    {
        public byte Major => _major;
        public byte Minor => _minor;
        public byte Minor2 => _minor2;

        private readonly byte _major, _minor, _minor2;

        public Version(byte major, byte minor, byte minor2)
        {
            _major = major;
            _minor = minor;
            _minor2 = minor2;
        }

        public Version(int code)
        {
            _major = (byte)(code >> 16 & 255);
            _minor = (byte)(code >> 8 & 255);
            _minor2 = (byte)(code & 255);
        }

        public override string ToString() => $"SunVox Lib v{_major}.{_minor}.{_minor2}";
    }
}
