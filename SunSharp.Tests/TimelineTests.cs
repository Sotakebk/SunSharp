using System.Linq;
using SunSharp.Native;

namespace SunSharp.Tests;

public class TimelineTests
{
#if !RELEASE

    private static (Timeline timeline, ISunVoxLib mockLib, Slot slot) CreateTestTimeline(int slotId = 0)
    {
        var mockLib = Substitute.For<ISunVoxLib>();
        var mockSunVox = Substitute.For<ISunVox>();
        mockSunVox.Library.Returns(mockLib);
        var slotManagementLock = new object();
        var slot = new Slot(slotId, slotManagementLock, mockSunVox);
        var timeline = slot.Timeline;
        return (timeline, mockLib, slot);
    }

    #region Constructor

    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var (timeline, _, slot) = CreateTestTimeline(3);

        // Assert
        timeline.Should().NotBeNull();
        timeline.Slot.Should().Be(slot);
    }

    #endregion Constructor

    #region GetUpperPatternCount

    [Test]
    public void GetUpperPatternCount_ShouldReturnLibraryValue()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.GetUpperPatternCount(1).Returns(8);

        // Act
        var result = timeline.GetUpperPatternCount();

        // Assert
        result.Should().Be(8);
        mockLib.Received(1).GetUpperPatternCount(1);
    }

    #endregion GetUpperPatternCount

    #region GetPatternExists

    [Test]
    public void GetPatternExists_WithExistingPattern_ShouldReturnTrue()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.GetPatternExists(1, 3).Returns(true);

        // Act
        var result = timeline.GetPatternExists(3);

        // Assert
        result.Should().BeTrue();
        mockLib.Received(1).GetPatternExists(1, 3);
    }

    [Test]
    public void GetPatternExists_WithNonExistingPattern_ShouldReturnFalse()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.GetPatternExists(1, 99).Returns(false);

        // Act
        var result = timeline.GetPatternExists(99);

        // Assert
        result.Should().BeFalse();
        mockLib.Received(1).GetPatternExists(1, 99);
    }

    #endregion GetPatternExists

    #region GetPattern

    [Test]
    public void GetPattern_ShouldReturnPatternHandle()
    {
        // Arrange
        var (timeline, _, _) = CreateTestTimeline(1);

        // Act
        var result = timeline.GetPattern(5);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(5);
    }

    [Test]
    public void GetPattern_AsInterface_ShouldReturnPatternHandle()
    {
        // Arrange
        var (timeline, _, _) = CreateTestTimeline(1);
        ITimeline iTimeline = timeline;

        // Act
        var result = iTimeline.GetPattern(5);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(5);
    }

    #endregion GetPattern

    #region TryGetPattern

    [Test]
    public void TryGetPattern_WithExistingPatternById_ShouldReturnTrueAndHandle()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.GetPatternExists(1, 7).Returns(true);

        // Act
        var result = timeline.TryGetPattern(7, out var patternHandle);

        // Assert
        result.Should().BeTrue();
        patternHandle.Should().NotBeNull();
        patternHandle!.Value.Id.Should().Be(7);
        mockLib.Received(1).GetPatternExists(1, 7);
    }

    [Test]
    public void TryGetPattern_WithNonExistingPatternById_ShouldReturnFalse()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.GetPatternExists(1, 99).Returns(false);

        // Act
        var result = timeline.TryGetPattern(99, out var patternHandle);

        // Assert
        result.Should().BeFalse();
        patternHandle.Should().BeNull();
    }

    [Test]
    public void TryGetPattern_WithExistingPatternByName_ShouldReturnTrueAndHandle()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.FindPattern(1, "TestPattern").Returns(42);

        // Act
        var result = timeline.TryGetPattern("TestPattern", out var patternHandle);

        // Assert
        result.Should().BeTrue();
        patternHandle.Should().NotBeNull();
        patternHandle!.Value.Id.Should().Be(42);
        mockLib.Received(1).FindPattern(1, "TestPattern");
    }

    [Test]
    public void TryGetPattern_WithNonExistingPatternByName_ShouldReturnFalse()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.FindPattern(1, "NonExistent").Returns((int?)null);

        // Act
        var result = timeline.TryGetPattern("NonExistent", out var patternHandle);

        // Assert
        result.Should().BeFalse();
        patternHandle.Should().BeNull();
    }

    [Test]
    public void TryGetPattern_AsInterface_WithExistingPatternById_ShouldReturnTrueAndHandle()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        ITimeline iTimeline = timeline;
        mockLib.GetPatternExists(1, 7).Returns(true);

        // Act
        var result = iTimeline.TryGetPattern(7, out var patternHandle);

        // Assert
        result.Should().BeTrue();
        patternHandle.Should().NotBeNull();
        patternHandle!.Id.Should().Be(7);
    }

    [Test]
    public void TryGetPattern_AsInterface_WithExistingPatternByName_ShouldReturnTrueAndHandle()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        ITimeline iTimeline = timeline;
        mockLib.FindPattern(1, "TestPattern").Returns(42);

        // Act
        var result = iTimeline.TryGetPattern("TestPattern", out var patternHandle);

        // Assert
        result.Should().BeTrue();
        patternHandle.Should().NotBeNull();
        patternHandle!.Id.Should().Be(42);
    }

    #endregion TryGetPattern

    #region CreatePattern

    [Test]
    public void CreatePattern_ShouldCallLibraryAndReturnHandle()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.CreatePattern(1, 10, 20, 8, 64, 123, "NewPattern").Returns(15);

        // Act
        var result = timeline.CreatePattern(64, 8, 10, 20, 123, "NewPattern");

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(15);
        mockLib.Received(1).CreatePattern(1, 10, 20, 8, 64, 123, "NewPattern");
    }

    [Test]
    public void CreatePattern_WithDefaults_ShouldCallLibraryWithDefaults()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.CreatePattern(1, 5, 10, 4, 32, 0, null).Returns(20);

        // Act
        var result = timeline.CreatePattern(32, 4, 5, 10);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(20);
        mockLib.Received(1).CreatePattern(1, 5, 10, 4, 32, 0, null);
    }

    [Test]
    public void CreatePattern_AsInterface_ShouldReturnHandle()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        ITimeline iTimeline = timeline;
        mockLib.CreatePattern(1, 15, 25, 16, 128, 456, "InterfacePattern").Returns(25);

        // Act
        var result = iTimeline.CreatePattern(128, 16, 15, 25, 456, "InterfacePattern");

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(25);
    }

    #endregion CreatePattern

    #region ClonePattern

    [Test]
    public void ClonePattern_ById_ShouldCallLibraryAndReturnId()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.ClonePattern(1, 5, 100, 200).Returns(30);

        // Act
        var result = timeline.ClonePattern(5, 100, 200);

        // Assert
        result.Should().Be(30);
        mockLib.Received(1).ClonePattern(1, 5, 100, 200);
    }

    [Test]
    public void ClonePattern_ByHandle_ShouldCallLibraryAndReturnHandle()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        var original = timeline.GetPattern(7);
        mockLib.ClonePattern(1, 7, 150, 250).Returns(35);

        // Act
        var result = timeline.ClonePattern(original, 150, 250);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(35);
        mockLib.Received(1).ClonePattern(1, 7, 150, 250);
    }

    [Test]
    public void ClonePattern_AsInterface_ByHandle_ShouldReturnHandle()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        ITimeline iTimeline = timeline;
        IPatternHandle original = timeline.GetPattern(9);
        mockLib.ClonePattern(1, 9, 175, 275).Returns(40);

        // Act
        var result = iTimeline.ClonePattern(original, 175, 275);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(40);
    }

    #endregion ClonePattern

    #region Enumeration

    [Test]
    public void GetEnumerator_WithPatterns_ShouldEnumerateExistingPatterns()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.GetUpperPatternCount(1).Returns(5);
        mockLib.GetPatternExists(1, 0).Returns(true);
        mockLib.GetPatternExists(1, 1).Returns(false);
        mockLib.GetPatternExists(1, 2).Returns(true);
        mockLib.GetPatternExists(1, 3).Returns(false);
        mockLib.GetPatternExists(1, 4).Returns(true);

        // Act
        var patterns = timeline.ToList<PatternHandle>();

        // Assert
        patterns.Should().HaveCount(3);
        patterns[0].Id.Should().Be(0);
        patterns[1].Id.Should().Be(2);
        patterns[2].Id.Should().Be(4);
    }

    [Test]
    public void GetEnumerator_WithNoPatterns_ShouldReturnEmpty()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        mockLib.GetUpperPatternCount(1).Returns(0);

        // Act
        var patterns = timeline.ToList<PatternHandle>();

        // Assert
        patterns.Should().BeEmpty();
    }

    [Test]
    public void GetEnumerator_AsInterface_ShouldEnumerateExistingPatterns()
    {
        // Arrange
        var (timeline, mockLib, _) = CreateTestTimeline(1);
        ITimeline iTimeline = timeline;
        mockLib.GetUpperPatternCount(1).Returns(3);
        mockLib.GetPatternExists(1, 0).Returns(true);
        mockLib.GetPatternExists(1, 1).Returns(true);
        mockLib.GetPatternExists(1, 2).Returns(false);

        // Act
        var patterns = iTimeline.ToList();

        // Assert
        patterns.Should().HaveCount(2);
        patterns[0].Id.Should().Be(0);
        patterns[1].Id.Should().Be(1);
    }

    #endregion Enumeration

    #region Interface Implementation

    [Test]
    public void ITimeline_Slot_ShouldReturnSlot()
    {
        // Arrange
        var (timeline, _, slot) = CreateTestTimeline(5);
        ITimeline iTimeline = timeline;

        // Act & Assert
        iTimeline.Slot.Should().Be(slot);
        iTimeline.Slot.Id.Should().Be(5);
    }

    #endregion Interface Implementation

#endif
}
