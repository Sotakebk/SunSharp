namespace SunSharp.Tests;

public class LibraryVersionTests
{
    [Test]
    public void Constructor_ShouldSetPropertiesAsExpected()
    {
        const byte major = 1;
        const byte minor = 2;
        const byte minor2 = 3;
        const int code = (major << 16)
                         | (minor << 8)
                         | minor2;
        var anotherVersion = new LibraryVersion(code);
        anotherVersion.Major.Should().Be(1);
        anotherVersion.Minor.Should().Be(2);
        anotherVersion.Minor2.Should().Be(3);
    }

    [Test]
    public void ToString_ShouldReturnExpectedFormat()
    {
        const byte major = 1;
        const byte minor = 2;
        const byte minor2 = 3;
        const int code = (major << 16)
                         | (minor << 8)
                         | minor2;
        var version = new LibraryVersion(code);
        var value = $"SunVox Lib v{major}.{minor}.{minor2}";
        version.ToString().Should().Be(value);
    }
}
