using System.Linq;
using SunSharp.Data;
using SunSharp.Tests.Mocks;

namespace SunSharp.Tests.Data;

public class SongDataReaderTests
{
    private static ModuleData CreateValidModuleData(ModuleData moduleData)
    {
        for (var i = 0; i < moduleData.Controllers.Count; i++)
        {
            moduleData.Controllers.ElementAt(i).Id = i;
        }

        return moduleData;
    }

    private static PatternData CreateValidPatternData(PatternData patternData)
    {
        patternData.IsDestructive = patternData.Data.Any(static e => e.Effect.IsDestructive());
        patternData.IsLinear = patternData.Data.All(static e => !e.Effect.IsNonLinear());
        patternData.HasDynamicTempo = patternData.Data.Any(static e => e.Effect.ChangesTempo());
        patternData.Lines = patternData.Data.Count;
        patternData.Tracks = 1;
        return patternData;
    }

    private static SongData CreateValidSongData(SongData songData)
    {
        foreach (var pattern in songData.Patterns)
        {
            pattern.IsDestructive = pattern.Data.Any(static e => e.Effect.IsDestructive());
            pattern.IsLinear = pattern.Data.All(static e => !e.Effect.IsNonLinear());
            pattern.HasDynamicTempo = pattern.Data.Any(static e => e.Effect.ChangesTempo());
            pattern.Lines = pattern.Data.Count;
            pattern.Tracks = 1;
        }

        foreach (var module in songData.Modules)
        {
            for (var i = 0; i < module.Controllers.Count; i++)
            {
                module.Controllers.ElementAt(i).Id = i;
            }
        }

        songData.FirstLine = songData.Patterns.Min(static p => p.Position.X);
        songData.LastLine = songData.Patterns.Max(static p => p.Position.X + p.Lines);
        songData.Lines = (uint)(songData.LastLine - songData.FirstLine);
        return songData;
    }

    [Test, AutoData]
    public void DataReaderReadSongDataShouldReturnEquivalentDataAsPutInMock(SongData songData)
    {
        var validSongData = CreateValidSongData(songData);
        var libraryMock = SunVoxLibMockProvider.BuildMock()
            .WithSongData(0, validSongData)
            .Build();
        var data = SongDataReader.ReadSongData(libraryMock, 0);
        data.Should().BeEquivalentTo(validSongData);
    }

    [Test, AutoData]
    public void DataReaderReadModuleShouldReturnEquivalentDataAsPutInMock(ModuleData moduleData)
    {
        var validModuleData = CreateValidModuleData(moduleData);
        var libraryMock = SunVoxLibMockProvider.BuildMock()
            .WithModuleData(0, [validModuleData])
            .Build();
        var data = SongDataReader.ReadModule(libraryMock, 0, validModuleData.Id);
        data.Should().BeEquivalentTo(validModuleData);
    }

    [Test, AutoData]
    public void DataReaderReadPatternShouldReturnEquivalentDataAsPutInMock(PatternData patternData)
    {
        var validPatternData = CreateValidPatternData(patternData);
        var libraryMock = SunVoxLibMockProvider.BuildMock()
            .WithPatternData(0, [validPatternData])
            .Build();
        var data = SongDataReader.ReadPattern(libraryMock, 0, validPatternData.Id);
        data.Should().BeEquivalentTo(validPatternData);
    }
}
