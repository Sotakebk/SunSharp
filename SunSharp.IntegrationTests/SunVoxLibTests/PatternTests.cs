using System.Linq;
using SunSharp.Data;

namespace SunSharp.IntegrationTests.SunVoxLibTests;

internal class PatternTests : BaseIntegrationTests
{
    [Test]
    public void EmptyProjectStartsWithOneEmptyPattern()
    {
        // Should be reported as a possible bug

        const int slotId = 0;

        var lib = GetLoadedLibrary();

        lib.OpenSlot(slotId);
        lib.LockSlot(slotId);

        var data = SongDataReader.ReadSongData(lib, slotId);

        lib.UnlockSlot(slotId);
        lib.CloseSlot(slotId);

        data.Patterns.Should().ContainSingle();
        data.Patterns.First().Data.Should().OnlyContain(e => e == 0);
    }

    [Test]
    public void PatternCreationCloningThenReadingPropertiesWorksAsExpected()
    {
        const int slotId = 0;

        var firstPattern = new PatternData
        {
            Data =
            [
                1, 0, 0, 0,
                2, 2, 0, 0,
                0, 3, 3, 0,
                0, 0, 4, 4,
                0, 0, 0, 5
            ],
            Lines = 5,
            Tracks = 4,
            Position = (0, 0),
            Name = "One"
        };

        var secondPattern = new PatternData
        {
            Data =
            [
                0, 1,
                2, 0,
                0, 3,
                4, 0
            ],
            Lines = 4,
            Tracks = 2,
            Position = (5, 4),
            Name = "Another"
        };

        var lib = GetLoadedLibrary();

        lib.OpenSlot(slotId);
        lib.LockSlot(slotId);

        var onePatternId = lib.CreatePattern(slotId, firstPattern.Position.X, firstPattern.Position.Y,
            firstPattern.Tracks, firstPattern.Lines, name: firstPattern.Name);
        lib.SetPatternData(slotId, onePatternId, [.. firstPattern.Data], firstPattern.Tracks, firstPattern.Lines);

        var clonePatternId = lib.ClonePattern(slotId, onePatternId, 8, 0);
        var anotherPatternId = lib.CreatePattern(slotId, secondPattern.Position.X, secondPattern.Position.Y,
            secondPattern.Tracks, secondPattern.Lines, name: secondPattern.Name);
        lib.SetPatternData(slotId, anotherPatternId, [.. secondPattern.Data], secondPattern.Tracks,
            secondPattern.Lines);

        var data = SongDataReader.ReadSongData(lib, slotId);

        lib.RemovePattern(slotId, onePatternId);

        var dataAfterRemoval = SongDataReader.ReadSongData(lib, slotId);

        lib.UnlockSlot(slotId);
        lib.CloseSlot(slotId);

        // pattern has expected data
        data.Patterns.FirstOrDefault(p => p.Id == onePatternId)
            .Should()
            .BeEquivalentTo(firstPattern, options => options
                .Excluding(p => p.Id)
                .Excluding(p => p.IsDestructive)
                .Excluding(p => p.IsLinear)
                .Excluding(p => p.IsMuted)
                .Excluding(p => p.HasDynamicTempo));

        // clone has expected data
        data.Patterns.FirstOrDefault(p => p.Id == clonePatternId)
            .Should()
            .BeEquivalentTo(firstPattern, options => options
                .Excluding(p => p.Id)
                .Excluding(p => p.IsDestructive)
                .Excluding(p => p.IsLinear)
                .Excluding(p => p.IsMuted)
                .Excluding(p => p.HasDynamicTempo)
                .Excluding(p => p.Position));
        data.Patterns.Should()
            .Contain(p => p.Position.X == 8 &&
                          p.Position.Y == 0);

        // clone doesn't exist
        dataAfterRemoval.Patterns.FirstOrDefault(p => p.Id == clonePatternId).Should().Be(null);

        // the other pattern has expected data in both cases
        data.Patterns.FirstOrDefault(p => p.Id == anotherPatternId)
            .Should()
            .BeEquivalentTo(secondPattern, options => options
                .Excluding(p => p.Id)
                .Excluding(p => p.IsDestructive)
                .Excluding(p => p.IsLinear)
                .Excluding(p => p.IsMuted)
                .Excluding(p => p.HasDynamicTempo));

        dataAfterRemoval.Patterns.FirstOrDefault(p => p.Id == anotherPatternId)
            .Should()
            .BeEquivalentTo(secondPattern, options => options
                .Excluding(p => p.Id)
                .Excluding(p => p.IsDestructive)
                .Excluding(p => p.IsLinear)
                .Excluding(p => p.IsMuted)
                .Excluding(p => p.HasDynamicTempo));
    }
}
