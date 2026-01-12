using SunSharp.Data;

namespace SunSharp.Tests.Data;

public class DataTests
{
    [Test, AutoData]
    public void SongDataDeepCopyShouldBeEquivalent(SongData songData, SongData anotherSongData)
    {
        var clone = songData.DeepCopy();

        clone.Should().BeEquivalentTo(songData);
        clone.Should().NotBeEquivalentTo(anotherSongData);
    }

    [Test, AutoData]
    public void PatternDataDeepCopyShouldBeEquivalent(PatternData patternData, PatternData anotherPatternData)
    {
        var clone = patternData.DeepCopy();

        clone.Should().BeEquivalentTo(patternData);
        clone.Should().NotBeEquivalentTo(anotherPatternData);
    }

    [Test, AutoData]
    public void ModuleDataDeepCopyShouldBeEquivalent(ModuleData moduleData, ModuleData anotherModuleData)
    {
        var clone = moduleData.DeepCopy();

        clone.Should().BeEquivalentTo(moduleData);
        clone.Should().NotBeEquivalentTo(anotherModuleData);
    }
}
