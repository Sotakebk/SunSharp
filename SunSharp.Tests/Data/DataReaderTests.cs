using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SunSharp.Data;
using SunSharp.Tests.Mocks;
using static TddXt.AnyRoot.Root;

namespace SunSharp.Tests.Data;

public class DataReaderTests
{
    private static ModuleData CreateValidModuleData()
    {
        var moduleData = Any.Instance<ModuleData>();

        for (var i = 0; i < moduleData.Controllers.Count; i++)
            moduleData.Controllers.ElementAt(i).Id = i;

        return moduleData;
    }

    private static PatternData CreateValidPatternData()
    {
        var patternData = Any.Instance<PatternData>();

        patternData.IsDestructive = patternData.Data.Any(static e => e.Effect.IsDestructive());
        patternData.IsLinear = patternData.Data.All(static e => !e.Effect.IsNonLinear());
        patternData.HasDynamicTempo = patternData.Data.Any(static e => e.Effect.ChangesTempo());
        patternData.Lines = patternData.Data.Count;
        patternData.Tracks = 1;

        return patternData;
    }

    private static SongData CreateValidSongData()
    {
        var songData = Any.Instance<SongData>();

        foreach (var pattern in songData.Patterns)
        {
            pattern.IsDestructive = pattern.Data.Any(static e => e.Effect.IsDestructive());
            pattern.IsLinear = pattern.Data.All(static e => !e.Effect.IsNonLinear());
            pattern.HasDynamicTempo = pattern.Data.Any(static e => e.Effect.ChangesTempo());
            pattern.Lines = pattern.Data.Count;
            pattern.Tracks = 1;
        }

        foreach (var module in songData.Modules)
            for (var i = 0; i < module.Controllers.Count; i++)
                module.Controllers.ElementAt(i).Id = i;

        songData.FirstLine = songData.Patterns.Min(static p => p.Position.X);
        songData.LastLine = songData.Patterns.Max(static p => p.Position.X + p.Lines);
        songData.Lines = songData.LastLine - songData.FirstLine;
        return songData;
    }

    [Test]
    public void DataReaderReadSongDataShouldReturnEquivalentDataAsPutInMock()
    {
        var songData = CreateValidSongData();

        var libraryMock = SunVoxLibMockProvider.BuildMock()
            .WithSongData(0, songData)
            .Build();

        var data = DataReader.ReadSongData(libraryMock, 0);

        data.Should().BeEquivalentTo(songData);
    }

    [Test]
    public void DataReaderReadModuleShouldReturnEquivalentDataAsPutInMock()
    {
        var moduleData = CreateValidModuleData();

        var libraryMock = SunVoxLibMockProvider.BuildMock()
            .WithModuleData(0, new[] { moduleData })
            .Build();

        var data = DataReader.ReadModule(libraryMock, 0, moduleData.Id);

        data.Should().BeEquivalentTo(moduleData);
    }

    [Test]
    public void DataReaderReadPatternShouldReturnEquivalentDataAsPutInMock()
    {
        var moduleData = CreateValidPatternData();

        var libraryMock = SunVoxLibMockProvider.BuildMock()
            .WithPatternData(0, new[] { moduleData })
            .Build();

        var data = DataReader.ReadPattern(libraryMock, 0, moduleData.Id);

        data.Should().BeEquivalentTo(moduleData);
    }
}
