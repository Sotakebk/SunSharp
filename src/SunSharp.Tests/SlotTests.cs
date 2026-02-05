using SunSharp.Native;

namespace SunSharp.Tests;

public class SlotTests
{
#if !SUNSHARP_RELEASE

    private static (Slot slot, ISunVoxLib mockLib, ISunVox mockSunVox) CreateTestSlot(int slotId = 0)
    {
        var mockLib = Substitute.For<ISunVoxLib>();
        var mockSunVox = Substitute.For<ISunVox>();
        mockSunVox.Library.Returns(mockLib);
        var slotManagementLock = new object();
        var slot = new Slot(slotId, slotManagementLock, mockSunVox);
        return (slot, mockLib, mockSunVox);
    }

    #region Constructor

    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // arrange & act
        var (slot, _, mockSunVox) = CreateTestSlot(5);

        // assert
        slot.Id.Should().Be(5);
        slot.IsOpen.Should().BeFalse();
        slot.OpenCount.Should().Be(0);
        slot.SunVox.Should().Be(mockSunVox);
        slot.VirtualPattern.Should().NotBeNull();
        slot.Timeline.Should().NotBeNull();
        slot.Synthesizer.Should().NotBeNull();
    }

    #endregion Constructor

    #region Lock/Unlock

    [Test]
    public void Lock_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(3);

        // act
        slot.Lock();

        // assert
        mockLib.Received(1).LockSlot(3);
    }

    [Test]
    public void Unlock_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(3);

        // act
        slot.Unlock();

        // assert
        mockLib.Received(1).UnlockSlot(3);
    }

    [Test]
    public void AcquireLock_ShouldReturnDisposable()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(3);

        // act
        var lockObject = slot.AcquireLock();

        // assert
        lockObject.Should().NotBeNull();
        lockObject.Should().BeAssignableTo<IDisposable>();
    }

    [Test]
    public void AcquireLock_WhenDisposed_ShouldUnlock()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(3);

        // act
        using (slot.AcquireLock())
        {
            // Lock acquired
        }

        // assert
        mockLib.Received(1).UnlockSlot(3);
    }

    #endregion Lock/Unlock

    #region Open/Close

    [Test]
    public void Open_WhenClosed_ShouldOpenSlot()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(2);

        // act
        slot.Open();

        // assert
        slot.IsOpen.Should().BeTrue();
        slot.OpenCount.Should().Be(1);
        mockLib.Received(1).OpenSlot(2);
    }

    [Test]
    public void Open_WhenAlreadyOpen_ShouldThrowSlotAlreadyOpenException()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(2);
        slot.Open();

        // act - assert
        slot.Invoking(s => s.Open()).Should().Throw<SlotAlreadyOpenException>().WithMessage("*ID=2*already open*");
    }

    [Test]
    public void Open_MultipleOpenClose_ShouldIncrementOpenCount()
    {
        // arrange
        var (slot, _, _) = CreateTestSlot(2);

        // act
        slot.Open();
        slot.Close();
        slot.Open();
        slot.Close();
        slot.Open();

        // assert
        slot.OpenCount.Should().Be(3);
    }

    [Test]
    public void Close_WhenOpen_ShouldCloseSlot()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(2);
        slot.Open();

        // act
        slot.Close();

        // assert
        slot.IsOpen.Should().BeFalse();
        mockLib.Received(1).CloseSlot(2);
    }

    [Test]
    public void Close_WhenAlreadyClosed_ShouldThrowSlotAlreadyClosedException()
    {
        // arrange
        var (slot, _, _) = CreateTestSlot(2);

        // act - assert
        slot.Invoking(s => s.Close()).Should().Throw<SlotAlreadyClosedException>().WithMessage("*ID=2*already closed*");
    }

    #endregion Open/Close

    #region Loading/Saving

    [Test]
    public void Load_WithPath_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        const string path = "test.sunvox";

        // act
        slot.Load(path);

        // assert
        mockLib.Received(1).Load(1, path);
    }

    [Test]
    public void Load_WithData_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        var data = new byte[] { 1, 2, 3, 4 };

        // act
        slot.Load(data);

        // assert
        mockLib.Received(1).Load(1, data);
    }

    [Test]
    public void SaveToFile_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        const string path = "output.sunvox";

        // act
        slot.SaveToFile(path);

        // assert
        mockLib.Received(1).SaveToFile(1, path);
    }

    #endregion Loading/Saving

    #region Playback

    [Test]
    public void StartPlayback_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.StartPlayback();

        // assert
        mockLib.Received(1).StartPlayback(1);
    }

    [Test]
    public void StartPlaybackFromBeginning_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.StartPlaybackFromBeginning();

        // assert
        mockLib.Received(1).StartPlaybackFromBeginning(1);
    }

    [Test]
    public void StopPlayback_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.StopPlayback();

        // assert
        mockLib.Received(1).StopPlayback(1);
    }

    [Test]
    public void ResumeStreamOnSyncEffect_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.ResumeStreamOnSyncEffect();

        // assert
        mockLib.Received(1).ResumeStreamOnSyncEffect(1);
    }

    [Test]
    public void PauseAudioStream_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.PauseAudioStream();

        // assert
        mockLib.Received(1).PauseAudioStream(1);
    }

    [Test]
    public void ResumeAudioStream_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.ResumeAudioStream();

        // assert
        mockLib.Received(1).ResumeAudioStream(1);
    }

    [Test]
    public void SetAutomaticStop_WithTrue_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.SetAutomaticStop(true);

        // assert
        mockLib.Received(1).SetAutomaticStop(1, true);
    }

    [Test]
    public void SetAutomaticStop_WithFalse_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.SetAutomaticStop(false);

        // assert
        mockLib.Received(1).SetAutomaticStop(1, false);
    }

    [Test]
    public void GetAutomaticStop_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetAutomaticStop(1).Returns(true);

        // act
        var result = slot.GetAutomaticStop();

        // assert
        result.Should().BeTrue();
        mockLib.Received(1).GetAutomaticStop(1);
    }

    [Test]
    public void IsPlaying_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.IsPlaying(1).Returns(true);

        // act
        var result = slot.IsPlaying();

        // assert
        result.Should().BeTrue();
        mockLib.Received(1).IsPlaying(1);
    }

    [Test]
    public void Rewind_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.Rewind(128);

        // assert
        mockLib.Received(1).Rewind(1, 128);
    }

    [Test]
    public void GetCurrentLine_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetCurrentLine(1).Returns(42);

        // act
        var result = slot.GetCurrentLine();

        // assert
        result.Should().Be(42);
        mockLib.Received(1).GetCurrentLine(1);
    }

    [Test]
    public void GetCurrentLineWithTenthPart_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetCurrentLineWithTenthPart(1).Returns(425);

        // act
        var result = slot.GetCurrentLineWithTenthPart();

        // assert
        result.Should().Be(425);
        mockLib.Received(1).GetCurrentLineWithTenthPart(1);
    }

    [Test]
    public void GetCurrentSignalLevel_WithDefaultChannel_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetCurrentSignalLevel(1, AudioChannel.Left).Returns(12345);

        // act
        var result = slot.GetCurrentSignalLevel();

        // assert
        result.Should().Be(12345);
        mockLib.Received(1).GetCurrentSignalLevel(1, AudioChannel.Left);
    }

    [Test]
    public void GetCurrentSignalLevel_WithRightChannel_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetCurrentSignalLevel(1, AudioChannel.Right).Returns(54321);

        // act
        var result = slot.GetCurrentSignalLevel(AudioChannel.Right);

        // assert
        result.Should().Be(54321);
        mockLib.Received(1).GetCurrentSignalLevel(1, AudioChannel.Right);
    }

    #endregion Playback

    #region Song Properties

    [Test]
    public void GetVolume_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.Volume(1, -1).Returns(256);

        // act
        var result = slot.GetVolume();

        // assert
        result.Should().Be(256);
        mockLib.Received(1).Volume(1, -1);
    }

    [Test]
    public void SetVolume_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.SetVolume(512);

        // assert
        mockLib.Received(1).Volume(1, 512);
    }

    [Test]
    public void GetSongBpm_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetSongBpm(1).Returns(125);

        // act
        var result = slot.GetSongBpm();

        // assert
        result.Should().Be(125);
        mockLib.Received(1).GetSongBpm(1);
    }

    [Test]
    public void GetSongTpl_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetSongTpl(1).Returns(6);

        // act
        var result = slot.GetSongTpl();

        // assert
        result.Should().Be(6);
        mockLib.Received(1).GetSongTpl(1);
    }

    [Test]
    public void GetSongLengthInLines_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetSongLengthInLines(1).Returns(1024u);

        // act
        var result = slot.GetSongLengthInLines();

        // assert
        result.Should().Be(1024u);
        mockLib.Received(1).GetSongLengthInLines(1);
    }

    [Test]
    public void GetSongLengthInFrames_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetSongLengthInFrames(1).Returns(98304u);

        // act
        var result = slot.GetSongLengthInFrames();

        // assert
        result.Should().Be(98304u);
        mockLib.Received(1).GetSongLengthInFrames(1);
    }

    [Test]
    public void GetSongName_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetSongName(1).Returns("Test Song");

        // act
        var result = slot.GetSongName();

        // assert
        result.Should().Be("Test Song");
        mockLib.Received(1).GetSongName(1);
    }

    [Test]
    public void GetSongName_WithNull_ShouldReturnNull()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        mockLib.GetSongName(1).Returns((string?)null);

        // act
        var result = slot.GetSongName();

        // assert
        result.Should().BeNull();
    }

    [Test]
    public void SetSongName_ShouldCallLibraryMethod()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);

        // act
        slot.SetSongName("New Song Name");

        // assert
        mockLib.Received(1).SetSongName(1, "New Song Name");
    }

    [Test]
    public void GetTimeMapFrames_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        var expectedFrames = new uint[] { 100, 200, 300 };
        mockLib.GetTimeMapFrames(1, 0, 3).Returns(expectedFrames);

        // act
        var result = slot.GetTimeMapFrames(0, 3);

        // assert
        result.Should().BeEquivalentTo(expectedFrames);
        mockLib.Received(1).GetTimeMapFrames(1, 0, 3);
    }

    [Test]
    public void GetTimeMapSpeed_ShouldReturnLibraryValue()
    {
        // arrange
        var (slot, mockLib, _) = CreateTestSlot(1);
        var expectedSpeeds = new Speed[] { new(125, 6), new(125, 6) };
        mockLib.GetTimeMapSpeed(1, 0, 2).Returns(expectedSpeeds);

        // act
        var result = slot.GetTimeMapSpeed(0, 2);

        // assert
        result.Should().BeEquivalentTo(expectedSpeeds);
        mockLib.Received(1).GetTimeMapSpeed(1, 0, 2);
    }

    #endregion Song Properties

    #region Exception Classes

    [Test]
    public void SlotAlreadyOpenException_DefaultConstructor_ShouldCreate()
    {
        // act
        var exception = new SlotAlreadyOpenException();

        // assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<SlotAlreadyOpenException>();
    }

    [Test]
    public void SlotAlreadyOpenException_WithIndex_ShouldContainIndex()
    {
        // act
        var exception = new SlotAlreadyOpenException(5);

        // assert
        exception.Message.Should().Contain("ID=5");
        exception.Message.Should().Contain("already open");
    }

    [Test]
    public void SlotAlreadyOpenException_WithMessage_ShouldContainMessage()
    {
        // act
        var exception = new SlotAlreadyOpenException("Custom message");

        // assert
        exception.Message.Should().Be("Custom message");
    }

    [Test]
    public void SlotAlreadyOpenException_WithMessageAndInner_ShouldContainBoth()
    {
        // arrange
        var innerException = new InvalidOperationException("Inner");

        // act
        var exception = new SlotAlreadyOpenException("Outer", innerException);

        // assert
        exception.Message.Should().Be("Outer");
        exception.InnerException.Should().Be(innerException);
    }

    [Test]
    public void SlotAlreadyClosedException_DefaultConstructor_ShouldCreate()
    {
        // act
        var exception = new SlotAlreadyClosedException();

        // assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<SlotAlreadyClosedException>();
    }

    [Test]
    public void SlotAlreadyClosedException_WithIndex_ShouldContainIndex()
    {
        // act
        var exception = new SlotAlreadyClosedException(3);

        // assert
        exception.Message.Should().Contain("ID=3");
        exception.Message.Should().Contain("already closed");
    }

    [Test]
    public void SlotAlreadyClosedException_WithMessage_ShouldContainMessage()
    {
        // act
        var exception = new SlotAlreadyClosedException("Custom message");

        // assert
        exception.Message.Should().Be("Custom message");
    }

    [Test]
    public void SlotAlreadyClosedException_WithMessageAndInner_ShouldContainBoth()
    {
        // arrange
        var innerException = new InvalidOperationException("Inner");

        // act
        var exception = new SlotAlreadyClosedException("Outer", innerException);

        // assert
        exception.Message.Should().Be("Outer");
        exception.InnerException.Should().Be(innerException);
    }

    #endregion Exception Classes

    #region Interface Implementation

    [Test]
    public void ISlot_Properties_ShouldReturnCorrectValues()
    {
        // arrange
        var (slot, _, _) = CreateTestSlot(7);
        ISlot iSlot = slot;

        // act & assert
        iSlot.Id.Should().Be(7);
        iSlot.IsOpen.Should().BeFalse();
        iSlot.VirtualPattern.Should().Be(slot.VirtualPattern);
        ((object)iSlot.Timeline).Should().Be(slot.Timeline);
        ((object)iSlot.Synthesizer).Should().Be(slot.Synthesizer);
        iSlot.SunVox.Should().Be(slot.SunVox);
    }

    #endregion Interface Implementation

#endif
}
