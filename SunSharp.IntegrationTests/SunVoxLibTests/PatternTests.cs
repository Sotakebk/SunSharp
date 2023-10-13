using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SunSharp.Data;
using TddXt.AnyRoot.Numbers;
using static TddXt.AnyRoot.Root;

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

        var data = DataReader.ReadSongData(lib, slotId);

        lib.UnlockSlot(slotId);
        lib.CloseSlot(slotId);

        data.Patterns.Count.Should().Be(1);
        data.Patterns.First().Data.All(e => e.Data.Equals(0)).Should().BeTrue();
    }

    [Test]
    public void PatternCreationCloningThenReadingPropertiesWorksAsExpected()
    {
        const int slotId = 0;

        var firstPattern = new PatternData
        {
            Data = new PatternEvent[]
            {
                1, 0, 0, 0,
                2, 2, 0, 0,
                0, 3, 3, 0,
                0, 0, 4, 4,
                0, 0, 0, 5
            },
            Lines = 5,
            Tracks = 4,
            Position = (0, 0),
            Name = "One"
        };

        var secondPattern = new PatternData
        {
            Data = new PatternEvent[]
            {
                0, 1,
                2, 0,
                0, 3,
                4, 0
            },
            Lines = 4,
            Tracks = 2,
            Position = (5, 4),
            Name = "Another"
        };

        var clonePosition = (X: Any.Integer(), Y: Any.Integer());

        var lib = GetLoadedLibrary();

        lib.OpenSlot(slotId);
        lib.LockSlot(slotId);

        var onePatternId = lib.CreatePattern(slotId, firstPattern.Position.X, firstPattern.Position.Y,
            firstPattern.Tracks, firstPattern.Lines, name: firstPattern.Name);
        lib.SetPatternData(slotId, onePatternId, firstPattern.Data.ToArray(), firstPattern.Tracks, firstPattern.Lines);

        var clonePatternId = lib.ClonePattern(slotId, onePatternId, clonePosition.X, clonePosition.Y);
        var anotherPatternId = lib.CreatePattern(slotId, secondPattern.Position.X, secondPattern.Position.Y,
            secondPattern.Tracks, secondPattern.Lines, name: secondPattern.Name);
        lib.SetPatternData(slotId, anotherPatternId, secondPattern.Data.ToArray(), secondPattern.Tracks,
            secondPattern.Lines);

        var data = DataReader.ReadSongData(lib, slotId);

        lib.RemovePattern(slotId, onePatternId);

        var dataAfterRemoval = DataReader.ReadSongData(lib, slotId);

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
        data.Patterns.FirstOrDefault(p => p.Id == clonePatternId)?.Position
            .Should()
            .BeEquivalentTo(clonePosition);

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
