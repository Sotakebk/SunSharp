using SunSharp.Data;

namespace SunSharp.Tests.Data;

public class DataTests
{
    [Test, AutoData]
    public void SongData_DeepCopy_ShouldBeEquivalent(SongData songData, SongData anotherSongData)
    {
        var clone = songData.DeepCopy();

        clone.Should().BeEquivalentTo(songData);
        clone.Should().NotBeEquivalentTo(anotherSongData);
    }

    [Test, AutoData]
    public void PatternData_DeepCopy_ShouldBeEquivalent(PatternData patternData, PatternData anotherPatternData)
    {
        var clone = patternData.DeepCopy();

        clone.Should().BeEquivalentTo(patternData);
        clone.Should().NotBeEquivalentTo(anotherPatternData);
    }

    [Test, AutoData]
    public void ModuleData_DeepCopy_ShouldBeEquivalent(ModuleData moduleData, ModuleData anotherModuleData)
    {
        var clone = moduleData.DeepCopy();

        clone.Should().BeEquivalentTo(moduleData);
        clone.Should().NotBeEquivalentTo(anotherModuleData);
    }
}
