namespace SunSharp.Tests;

public class LibraryVersionTests
{
    [Test]
    public void LibraryVersionConstructorShouldSetPropertiesAsExpected()
    {
        const byte major = 1;
        const byte minor = 2;
        const byte minor2 = 3;
        var version = new LibraryVersion(major, minor, minor2);
        version.Major.Should().Be(1);
        version.Minor.Should().Be(2);
        version.Minor2.Should().Be(3);
        const int code = (major << 16)
                         | (minor << 8)
                         | minor2;
        var anotherVersion = new LibraryVersion(code);
        anotherVersion.Major.Should().Be(1);
        anotherVersion.Minor.Should().Be(2);
        anotherVersion.Minor2.Should().Be(3);
    }

    [Test]
    public void LibraryVersionToStringReturnsExpectedFormat()
    {
        const byte major = 1;
        const byte minor = 2;
        const byte minor2 = 3;
        var version = new LibraryVersion(major, minor, minor2);
        var value = $"SunVox Lib v{major}.{minor}.{minor2}";
        version.ToString().Should().Be(value);
    }
}
