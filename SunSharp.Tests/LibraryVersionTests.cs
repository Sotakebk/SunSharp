using NUnit.Framework;

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
        Assert.Multiple(() =>
        {
            Assert.That(version.Major, Is.EqualTo(1));
            Assert.That(version.Minor, Is.EqualTo(2));
            Assert.That(version.Minor2, Is.EqualTo(3));
        });
        const int code = (major << 16)
                         | (minor << 8)
                         | minor2;
        var anotherVersion = new LibraryVersion(code);
        Assert.Multiple(() =>
        {
            Assert.That(anotherVersion.Major, Is.EqualTo(1));
            Assert.That(anotherVersion.Minor, Is.EqualTo(2));
            Assert.That(anotherVersion.Minor2, Is.EqualTo(3));
        });
    }

    [Test]
    public void LibraryVersionToStringReturnsExpectedFormat()
    {
        const byte major = 1;
        const byte minor = 2;
        const byte minor2 = 3;
        var version = new LibraryVersion(major, minor, minor2);
        var value = $"SunVox Lib v{major}.{minor}.{minor2}";

        Assert.That(version.ToString(), Is.EqualTo(value));
    }
}
