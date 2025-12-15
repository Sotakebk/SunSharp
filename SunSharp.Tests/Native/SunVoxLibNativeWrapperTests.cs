using System.Linq;
using System.Runtime.InteropServices;
using SunSharp.Native;

namespace SunSharp.Tests.Native;

public class SunVoxLibNativeWrapperTests
{
    public const int ErrorResponseCode = -1;

    [Test, AutoData]
    public void CloseSlotShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_close_slot(Arg.Any<int>()).Returns(0);

        // when
        wrapper.CloseSlot(slotId);

        // then
        library.Received(1).sv_close_slot(slotId);
    }

    [Test, AutoData]
    public void CloseSlotShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_close_slot(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.CloseSlot(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_close_slot(slotId);
    }

    [Test]
    public void DeinitializeShouldCallDeinitAsExpected()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_deinit().Returns(0);

        // when
        wrapper.Deinitialize();

        // then
        library.Received(1).sv_deinit();
    }

    [Test]
    public void DeinitializeShouldThrowExceptionOnNonzeroCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_deinit().Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.Deinitialize()).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_deinit();
    }

    [Test, AutoData]
    public void GetAutomaticStopShouldReturnValue(bool automaticStop, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_autostop(Arg.Any<int>()).Returns(automaticStop ? 1 : 0);

        // when
        var value = wrapper.GetAutomaticStop(slotId);

        // then
        library.Received(1).sv_get_autostop(slotId);
        value.Should().Be(automaticStop);
    }

    [Test, AutoData]
    public void GetAutomaticStopShouldThrowOnInvalidValue(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_autostop(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.GetAutomaticStop(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_autostop(slotId);
    }

    [Test, AutoData]
    public void GetCurrentLineShouldReturnValue(int currentLine, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_current_line(Arg.Any<int>()).Returns(currentLine);

        // when
        var value = wrapper.GetCurrentLine(slotId);

        // then
        library.Received(1).sv_get_current_line(slotId);
        value.Should().Be(currentLine);
    }

    [Test, AutoData]
    public void GetCurrentLineWithTenthPartShouldReturnValue(int currentLineWithTenthPart, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_current_line2(Arg.Any<int>()).Returns(currentLineWithTenthPart);

        // when
        var value = wrapper.GetCurrentLineWithTenthPart(slotId);

        // then
        library.Received(1).sv_get_current_line2(slotId);
        value.Should().Be(currentLineWithTenthPart);
    }

    [Test, AutoData]
    public void GetCurrentSignalLevelShouldReturnValue(int signalLevel, int slotId, int channelId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_current_signal_level(Arg.Any<int>(), Arg.Any<int>()).Returns(signalLevel);

        // when
        var value = wrapper.GetCurrentSignalLevel(slotId, channelId);

        // then
        library.Received(1).sv_get_current_signal_level(slotId, channelId);
        value.Should().Be(signalLevel);
    }

    [Test, AutoData]
    public void GetLogsShouldReturnNullForNullPtr(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_get_log(Arg.Any<int>()).Returns(IntPtr.Zero);

        // when - then
        var result = wrapper.GetLog(slotId);

        // then
        result.Should().BeNull();
    }

    [Test, AutoData]
    public void GetLogsShouldReturnStringForValidPointer(string log)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var logLength = log.Length;
        library.sv_get_log(logLength).Returns(_ => Marshal.StringToHGlobalAnsi(log));

        // when
        var result = wrapper.GetLog(logLength);

        // then
        result.Should().Be(log);
    }

    [Test, AutoData]
    public void GetSampleRateShouldReturnValue(int ticks)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_sample_rate().Returns(ticks);

        // when
        var result = wrapper.GetSampleRate();

        // then
        result.Should().Be(ticks);
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void GetSampleRateShouldThrowOnNonsenseValue(int sampleRate)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_sample_rate().Returns(sampleRate);

        // when - then
        wrapper.Invoking(w => w.GetSampleRate()).Should().Throw<SunVoxException>();
    }

    [Test, AutoData]
    public void GetSongBpmShouldReturnValue(int songBpm, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_song_bpm(Arg.Any<int>()).Returns(songBpm);

        // when
        var value = wrapper.GetSongBpm(slotId);

        // then
        library.Received(1).sv_get_song_bpm(slotId);
        value.Should().Be(songBpm);
    }

    [Test, AutoData]
    public void GetSongBpmShouldThrowOnInvalidValue(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_song_bpm(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.GetSongBpm(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_song_bpm(slotId);
    }

    [Test, AutoData]
    public void GetSongLengthInFramesShouldReturnValue(uint songLength, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_song_length_frames(Arg.Any<int>()).Returns(songLength);

        // when
        var value = wrapper.GetSongLengthInFrames(slotId);

        // then
        library.Received(1).sv_get_song_length_frames(slotId);
        value.Should().Be(songLength);
    }

    [Test, AutoData]
    public void GetSongLengthInLinesShouldReturnValue(uint songLength, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_song_length_lines(Arg.Any<int>()).Returns(songLength);

        // when
        var value = wrapper.GetSongLengthInLines(slotId);

        // then
        library.Received(1).sv_get_song_length_lines(slotId);
        value.Should().Be(songLength);
    }

    [Test, AutoData]
    public void GetSongNameShouldReturnNullOnNullPtr(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_get_song_name(Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var result = wrapper.GetSongName(slotId);

        // then
        result.Should().BeNull();
        library.Received(1).sv_get_song_name(slotId);
    }

    [Test, AutoData]
    public void GetSongNameShouldReturnValue(string songName, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var ptr = Marshal.StringToHGlobalAnsi(songName);
        try
        {
            library.sv_get_song_name(Arg.Any<int>()).Returns(ptr);

            // when
            var result = wrapper.GetSongName(slotId);

            // then
            result.Should().Be(songName);
            library.Received(1).sv_get_song_name(slotId);
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }
    }

    [Test, AutoData]
    public void GetSongTplShouldReturnValue(int songTpl, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_song_tpl(Arg.Any<int>()).Returns(songTpl);

        // when
        var value = wrapper.GetSongTpl(slotId);

        // then
        library.Received(1).sv_get_song_tpl(slotId);
        value.Should().Be(songTpl);
    }

    [Test, AutoData]
    public void GetSongTplShouldThrowOnInvalidValue(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_song_tpl(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.GetSongTpl(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_song_tpl(slotId);
    }

    [Test, AutoData]
    public void GetTicksPerSecondShouldReturnValue(uint ticks)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_ticks_per_second().Returns(ticks);

        // when
        var result = wrapper.GetTicksPerSecond();

        // then
        result.Should().Be(ticks);
    }

    [Test, AutoData]
    public void GetTicksShouldReturnValue(uint ticks)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_ticks().Returns(ticks);

        // when
        var result = wrapper.GetTicks();

        // then
        result.Should().Be(ticks);
    }

    [Test, AutoData]
    public void GetTimeMapShouldReturnExpectedValue(int slotId, int startLine, TimeMapType mapType)
    {
        const int length = 32;
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var timeMap = Enumerable.Range(0, length).ToArray();

        library
            .When(static l =>
                l.sv_get_time_map(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                var intPtr = callInfo.Arg<IntPtr>();
                for (var i = 0; i < timeMap.Length; i++)
                {
                    Marshal.WriteInt32(intPtr + i * 4, timeMap[i]);
                }
            });

        // when
        var value = wrapper.GetTimeMap(slotId, startLine, length, mapType);

        // then
        library.Received(1).sv_get_time_map(slotId, startLine, length, Arg.Any<IntPtr>(), (int)mapType);
        value.Should().BeEquivalentTo(timeMap);
    }

    [Test, AutoData]
    public void GetTimeMapShouldThrowOnNonZeroReturnCode(int slotId, int startLine, int length, TimeMapType mapType)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_time_map(0, 0, 0, default, 0).ReturnsForAnyArgs(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.GetTimeMap(slotId, startLine, length, mapType)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_time_map(slotId, startLine, length, Arg.Any<IntPtr>(), (int)mapType);
    }

    [Test, AutoData]
    public void InitializeShouldCallInitAndThrowExceptionOnUnhandledValue(int sampleRate, AudioChannels channels, SunVoxInitOptions sunVoxInitOptions)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_init(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.Initialize(sampleRate, null, channels, sunVoxInitOptions)).Should().Throw<SunVoxException>();

        // and then
        library.Received(1).sv_init(IntPtr.Zero, sampleRate, (int)channels, (uint)sunVoxInitOptions);
    }

    [Test, AutoData]
    public void InitializeShouldCallInitAsExpected(int sampleRate, string config, AudioChannels channels, SunVoxInitOptions sunVoxInitOptions)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        const int returnCode = 123454321;
        library.sv_init(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(returnCode);

        string? receivedString = null;
        library.When(static l => l.sv_init(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var version = wrapper.Initialize(sampleRate, config, channels, sunVoxInitOptions);

        // then
        library.Received(1).sv_init(Arg.Any<IntPtr>(), sampleRate, (int)channels, (uint)sunVoxInitOptions);
        version.Should().Be(new LibraryVersion(returnCode));
        receivedString.Should().Be(config);
    }

    [Test, AutoData]
    public void InitializeShouldCallInitAsExpectedWithNullConfig(int sampleRate, AudioChannels channels, SunVoxInitOptions sunVoxInitOptions)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        const int returnCode = 123454321;
        library.sv_init(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(returnCode);

        // when
        var version = wrapper.Initialize(sampleRate, null, channels, sunVoxInitOptions);

        // then
        library.Received(1).sv_init(IntPtr.Zero, sampleRate, (int)channels, (uint)sunVoxInitOptions);
        version.Should().Be(new LibraryVersion(returnCode));
    }

    [Test, AutoData]
    public void IsPlayingShouldReturnExpectedValue(bool isPlaying, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_end_of_song(Arg.Any<int>()).Returns(isPlaying ? 0 : 1);

        // when
        var value = wrapper.IsPlaying(slotId);

        // then
        library.Received(1).sv_end_of_song(slotId);
        value.Should().Be(isPlaying);
    }

    [Test, AutoData]
    public void IsPlayingShouldThrowOnUnexpectedValue(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_end_of_song(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when
        wrapper.Invoking(w => w.IsPlaying(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_end_of_song(slotId);
    }

    [Test, AutoData]
    public void LoadFromMemoryShouldCallExpectedMethods(int slotId, byte[] data)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var receivedArray = Array.Empty<byte>();

        library.When(static l => l.sv_load_from_memory(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>()))
            .Do(callInfo =>
            {
                receivedArray = new byte[callInfo.Arg<uint>()];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedArray, 0, (int)callInfo.Arg<uint>());
            });

        // when
        wrapper.Load(slotId, data);

        // then
        receivedArray.Should().BeEquivalentTo(data);
        library.Received(1).sv_load_from_memory(slotId, Arg.Any<IntPtr>(), (uint)data.Length);
    }

    [Test, AutoData]
    public void LoadFromMemoryShouldThrowOnNonzeroReturnCode(int slotId, byte[] data)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_load_from_memory(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>()).Returns(ErrorResponseCode);

        // when
        wrapper.Invoking(w => w.Load(slotId, data)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_load_from_memory(slotId, Arg.Any<IntPtr>(), Arg.Any<uint>());
    }

    [Test, AutoData]
    public void LoadShouldCallExpectedMethods(int slotId, string path)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var receivedString = string.Empty;

        library.When(static l => l.sv_load(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.Load(slotId, path);

        // then
        receivedString.Should().Be(path);
        library.Received(1).sv_load(slotId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void LoadShouldThrowOnNonzeroReturnCode(int slotId, string fileName)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_load(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(ErrorResponseCode);

        // when
        wrapper.Invoking(w => w.Load(slotId, fileName)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_load(slotId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void LockSlotShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_lock_slot(Arg.Any<int>()).Returns(0);

        // when
        wrapper.LockSlot(slotId);

        // then
        library.Received(1).sv_lock_slot(slotId);
    }

    [Test, AutoData]
    public void LockSlotShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_lock_slot(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.LockSlot(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_lock_slot(slotId);
    }

    [Test, AutoData]
    public void OpenSlotShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_open_slot(Arg.Any<int>()).Returns(0);

        // when
        wrapper.OpenSlot(slotId);

        // then
        library.Received(1).sv_open_slot(slotId);
    }

    [Test, AutoData]
    public void OpenSlotShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_open_slot(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.OpenSlot(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_open_slot(slotId);
    }

    [Test, AutoData]
    public void PauseStreamShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_pause(Arg.Any<int>()).Returns(0);

        // when
        wrapper.PauseAudioStream(slotId);

        // then
        library.Received(1).sv_pause(slotId);
    }

    [Test, AutoData]
    public void PauseStreamShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_pause(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.PauseAudioStream(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_pause(slotId);
    }

    [Test, AutoData]
    public void ResumeStreamOnSyncEffectShouldCallMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sync_resume(Arg.Any<int>()).Returns(0);

        // when
        wrapper.ResumeStreamOnSyncEffect(slotId);

        // then
        library.Received(1).sv_sync_resume(slotId);
    }

    [Test, AutoData]
    public void ResumeStreamOnSyncEffectShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sync_resume(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.ResumeStreamOnSyncEffect(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_sync_resume(slotId);
    }

    [Test, AutoData]
    public void ResumeStreamShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_resume(Arg.Any<int>()).Returns(0);

        // when
        wrapper.ResumeAudioStream(slotId);

        // then
        library.Received(1).sv_resume(slotId);
    }

    [Test, AutoData]
    public void ResumeStreamShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_resume(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.ResumeAudioStream(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_resume(slotId);
    }

    [Test, AutoData]
    public void RewindShouldCallExpectedMethod(int slotId, int line)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_rewind(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.Rewind(slotId, line);

        // then
        library.Received(1).sv_rewind(slotId, line);
    }

    [Test, AutoData]
    public void RewindShouldThrowOnNonZeroReturnCode(int slotId, int line)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_rewind(Arg.Any<int>(), Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.Rewind(slotId, line)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_rewind(slotId, line);
    }

    [Test, AutoData]
    public void SaveShouldCallExpectedMethods(int slotId, string path)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var receivedString = string.Empty;

        library.When(static l => l.sv_save(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.Save(slotId, path);

        // then
        receivedString.Should().Be(path);
        library.Received(1).sv_save(slotId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void SaveShouldThrowOnUnexpectedReturnCode(int slotId, string path)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_save(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(ErrorResponseCode);

        // when
        wrapper.Invoking(w => w.Save(slotId, path)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_save(slotId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void SendEventWithPatternEventStructShouldSendArgumentsAsExpected(int slotId, int track, PatternEvent patternEvent)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_send_event(0, 0, 0, 0, 0, 0, 0).ReturnsForAnyArgs(0);

        // when
        wrapper.SendEvent(slotId, track, patternEvent);

        // then
        library.Received(1).sv_send_event(slotId, track, patternEvent.NN, patternEvent.VV, patternEvent.MM, patternEvent.CCEE, patternEvent.XXYY);
    }

    [Test, AutoData]
    public void SendEventWithRawDataShouldSendArgumentsAsExpected(int slotId, int track, int nn, int vv, int mm, int ccee, int xxyy)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_send_event(0, 0, 0, 0, 0, 0, 0).ReturnsForAnyArgs(0);

        // when
        wrapper.SendEvent(slotId, track, nn, vv, mm, ccee, xxyy);

        // then
        library.Received(1).sv_send_event(slotId, track, nn, vv, mm, ccee, xxyy);
    }

    [Test, AutoData]
    public void SendEventWithPatternEventShouldThrowException(int slotId, int track, PatternEvent patternEvent)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        // when
        library.sv_send_event(0, 0, 0, 0, 0, 0, 0).ReturnsForAnyArgs(ErrorResponseCode);

        // then
        wrapper.Invoking(w => w.SendEvent(slotId, track, patternEvent)).Should().Throw<SunVoxException>();
        library.Received(1).sv_send_event(slotId, track, patternEvent.NN, patternEvent.VV, patternEvent.MM, patternEvent.CCEE, patternEvent.XXYY);
    }

    [Test, AutoData]
    public void SendEventWithRawDataShouldThrowException(int slotId, int track, int nn, int vv, int mm, int ccee, int xxyy)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_send_event(0, 0, 0, 0, 0, 0, 0).ReturnsForAnyArgs(-1);

        // then
        wrapper.Invoking(w => w.SendEvent(slotId, track, nn, vv, mm, ccee, xxyy)).Should().Throw<SunVoxException>();
        library.Received(1).sv_send_event(slotId, track, nn, vv, mm, ccee, xxyy);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void SetAutoStopShouldCallWithArgument(bool autoStop)
    {
        var fixture = new Fixture();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_autostop(Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        var slotId = fixture.Create<int>();

        // when
        wrapper.SetAutomaticStop(slotId, autoStop);

        // then
        library.Received(1).sv_set_autostop(slotId, autoStop ? 1 : 0);
    }

    [Test, AutoData]
    public void SetAutoStopShouldThrowOnInvalidReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_autostop(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when - then
        wrapper.Invoking(w => w.SetAutomaticStop(slotId, false)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_autostop(slotId, 0);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void SetSendEventTimestampShouldCallWithArgument(bool reset)
    {
        var fixture = new Fixture();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_event_t(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        var slotId = fixture.Create<int>();
        var t = fixture.Create<int>();

        // when
        wrapper.SetSendEventTimestamp(slotId, reset, t);

        // then
        library.Received(1).sv_set_event_t(slotId, reset ? 0 : 1, t);
    }

    [Test, AutoData]
    public void SetSendEventTimestampShouldThrowOnInvalidReturnCode(int slotId, int t)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_event_t(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when - then
        wrapper.Invoking(w => w.SetSendEventTimestamp(slotId, false, t)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_event_t(slotId, 1, t);
    }

    [Test, AutoData]
    public void SetSongNameShouldSendString(int slotId, string newSongName)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        string? receivedString = null;

        library.When(static l => l.sv_set_song_name(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.SetSongName(slotId, newSongName);

        // then
        receivedString.Should().Be(newSongName);
        library.Received(1).sv_set_song_name(slotId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void SetSongNameShouldThrowExceptionOnNonzeroReturnCode(int slotId, string newSongName)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_set_song_name(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetSongName(slotId, newSongName)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_song_name(slotId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void StartPlaybackFromBeginningShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_play_from_beginning(Arg.Any<int>()).Returns(0);

        // when
        wrapper.StartPlaybackFromBeginning(slotId);

        // then
        library.Received(1).sv_play_from_beginning(slotId);
    }

    [Test, AutoData]
    public void StartPlaybackFromBeginningShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_play_from_beginning(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.StartPlaybackFromBeginning(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_play_from_beginning(slotId);
    }

    [Test, AutoData]
    public void StartPlaybackShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_play(Arg.Any<int>()).Returns(0);

        // when
        wrapper.StartPlayback(slotId);

        // then
        library.Received(1).sv_play(slotId);
    }

    [Test, AutoData]
    public void StartPlaybackShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_play(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.StartPlayback(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_play(slotId);
    }

    [Test, AutoData]
    public void StopPlaybackShouldCallMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_stop(Arg.Any<int>()).Returns(0);

        // when
        wrapper.StopPlayback(slotId);

        // then
        library.Received(1).sv_stop(slotId);
    }

    [Test, AutoData]
    public void StopPlaybackShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_stop(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.StopPlayback(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_stop(slotId);
    }

    [Test, AutoData]
    public void UnlockSlotShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_unlock_slot(Arg.Any<int>()).Returns(0);

        // when
        wrapper.UnlockSlot(slotId);

        // then
        library.Received(1).sv_unlock_slot(slotId);
    }

    [Test, AutoData]
    public void UnlockSlotShouldThrowOnNonZeroReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_unlock_slot(Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.UnlockSlot(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_unlock_slot(slotId);
    }

    [Test]
    public void UpdateInputDevicesShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_update_input().Returns(0);

        // when
        wrapper.UpdateInputDevices();

        // then
        library.Received(1).sv_update_input();
    }

    [Test]
    public void UpdateInputDevicesShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_update_input().Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.UpdateInputDevices()).Should().Throw<SunVoxException>();
    }

    [Test, AutoData]
    public void VolumeShouldReturnExpectedValue(int slotId, int volume, int otherVolume)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_volume(Arg.Any<int>(), Arg.Any<int>()).Returns(volume);

        // when
        var value = wrapper.Volume(slotId, otherVolume);

        // then
        library.Received(1).sv_volume(slotId, otherVolume);
        value.Should().Be(volume);
    }

    [Test, AutoData]
    public void VolumeShouldThrowOnNonZeroReturnCode(int slotId, int otherVolume)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_volume(Arg.Any<int>(), Arg.Any<int>()).Returns(ErrorResponseCode);

        // when - then
        wrapper.Invoking(w => w.Volume(slotId, otherVolume)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_volume(slotId, otherVolume);
    }
}
