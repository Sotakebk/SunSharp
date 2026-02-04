namespace SunSharp.Tests;

public class SunVoxVersionTests
{
    [Test]
    public void FromProjectBaseVersion_ShouldSetPropertiesAsExpected()
    {
        const byte major = 1;
        const byte minor = 2;
        const byte minor2 = 3;
        const byte bugfix = 4;
        const int code = (major << 24)
                         | (minor << 16)
                         | (minor2 << 8)
                         | bugfix;
        var version = SunVoxVersion.FromProjectBaseVersion(code);
        version.Major.Should().Be(1);
        version.Minor.Should().Be(2);
        version.Minor2.Should().Be(3);
        version.Bugfix.Should().Be(4);
    }

    [Test]
    public void FromLibraryVersion_ShouldSetPropertiesAsExpected()
    {
        const byte major = 1;
        const byte minor = 2;
        const byte minor2 = 3;
        const int code = (major << 16)
                         | (minor << 8)
                         | minor2;
        var version = SunVoxVersion.FromLibraryVersion(code);
        version.Major.Should().Be(1);
        version.Minor.Should().Be(2);
        version.Minor2.Should().Be(3);
        version.Bugfix.Should().Be(0);
    }

    [Test]
    public void ToString_ShouldReturnExpectedFormat()
    {
        const byte major = 1;
        const byte minor = 2;
        const byte minor2 = 3;
        const byte bugfix = 4;
        var version = new SunVoxVersion(major, minor, minor2, bugfix);
        var value = $"version 1.2.3.4";
        version.ToString().Should().Be(value);
    }
}
