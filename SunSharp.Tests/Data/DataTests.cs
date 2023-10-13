using FluentAssertions;
using NUnit.Framework;
using SunSharp.Data;
using static TddXt.AnyRoot.Root;

namespace SunSharp.Tests.Data;

public class DataTests
{
    [Test]
    public void SongDataDeepCopyShouldBeEquivalent()
    {
        var songData = Any.Instance<SongData>();
        var anotherSongData = Any.Instance<SongData>();

        var clone = songData.DeepCopy();

        clone.Should().BeEquivalentTo(songData);
        clone.Should().NotBeEquivalentTo(anotherSongData);
    }

    [Test]
    public void PatternDataDeepCopyShouldBeEquivalent()
    {
        var patternData = Any.Instance<PatternData>();
        var anotherPatternData = Any.Instance<PatternData>();

        var clone = patternData.DeepCopy();

        clone.Should().BeEquivalentTo(patternData);
        clone.Should().NotBeEquivalentTo(anotherPatternData);
    }

    [Test]
    public void ModuleDataDeepCopyShouldBeEquivalent()
    {
        var moduleData = Any.Instance<ModuleData>();
        var anotherModuleData = Any.Instance<ModuleData>();

        var clone = moduleData.DeepCopy();

        clone.Should().BeEquivalentTo(moduleData);
        clone.Should().NotBeEquivalentTo(anotherModuleData);
    }
}
