using System;
using System.Linq;
using System.Runtime.InteropServices;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SunSharp.Native;
using TddXt.AnyRoot.Collections;
using TddXt.AnyRoot.Numbers;
using TddXt.AnyRoot.Strings;
using static TddXt.AnyRoot.Root;

namespace SunSharp.Tests.Native;

public class SunVoxLibNativeWrapperTests
{
    [Test]
    public void CloseSlotShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_close_slot(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.CloseSlot(slotId);

        // then
        library.Received(1).sv_close_slot(slotId);
    }

    [Test]
    public void CloseSlotShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_close_slot(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.CloseSlot(slotId), Throws.Exception.TypeOf<SunVoxException>());

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

        library.sv_deinit().Returns(-1);

        // when - then
        Assert.That(() => wrapper.Deinitialize(), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_deinit();
    }

    [TestCase(true)]
    [TestCase(false)]
    public void GetAutostopShouldReturnValue(bool autostop)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_autostop(Arg.Any<int>()).Returns(autostop ? 1 : 0);
        var slotId = Any.Integer();

        // when
        var value = wrapper.GetAutostop(slotId);

        // then
        library.Received(1).sv_get_autostop(slotId);
        Assert.That(value, Is.EqualTo(autostop));
    }

    [Test]
    public void GetAutostopShouldThrowOnInvalidValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_autostop(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => _ = wrapper.GetAutostop(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_autostop(slotId);
    }

    [Test]
    public void GetCurrentLineShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var currentLine = Any.Integer();
        library.sv_get_current_line(Arg.Any<int>()).Returns(currentLine);
        var slotId = Any.Integer();

        // when
        var value = wrapper.GetCurrentLine(slotId);

        // then
        library.Received(1).sv_get_current_line(slotId);
        Assert.That(value, Is.EqualTo(currentLine));
    }

    [Test]
    public void GetCurrentLineWithTenthPartShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var currentLineWithTenthPart = Any.Integer();
        library.sv_get_current_line2(Arg.Any<int>()).Returns(currentLineWithTenthPart);
        var slotId = Any.Integer();

        // when
        var value = wrapper.GetCurrentLineWithTenthPart(slotId);

        // then
        library.Received(1).sv_get_current_line2(slotId);
        Assert.That(value, Is.EqualTo(currentLineWithTenthPart));
    }

    [Test]
    public void GetCurrentSignalLevelShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var signalLevel = Any.Integer();
        library.sv_get_current_signal_level(Arg.Any<int>(), Arg.Any<int>()).Returns(signalLevel);
        var slotId = Any.Integer();
        var channelId = Any.Integer();

        // when
        var value = wrapper.GetCurrentSignalLevel(slotId, channelId);

        // then
        library.Received(1).sv_get_current_signal_level(slotId, channelId);
        Assert.That(value, Is.EqualTo(signalLevel));
    }

    [Test]
    public void GetLogsShouldReturnNullForNullPtr()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        library.sv_get_log(Arg.Any<int>()).Returns(IntPtr.Zero);

        // when - then
        var result = wrapper.GetLog(Any.Integer());

        // then
        Assert.That(result, Is.EqualTo(null));
    }

    [Test]
    public void GetLogsShouldReturnStringForValidPointer()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        const string log = "this is a bunch of logs\nplease pretend that it's sufficient";
        var logLength = log.Length;
        // assuming that GetLog calls free()
        library.sv_get_log(logLength).Returns(static _ => Marshal.StringToHGlobalAnsi(log));

        // when
        var result = wrapper.GetLog(logLength);

        // then
        Assert.That(result, Is.EqualTo(log));
    }

    [Test]
    public void GetSampleRateShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var ticks = Any.Integer();
        library.sv_get_sample_rate().Returns(ticks);

        // when
        var result = wrapper.GetSampleRate();

        // then
        Assert.That(result, Is.EqualTo(ticks));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void GetSampleRateShouldThrowOnNonsenseValue(int sampleRate)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_sample_rate().Returns(sampleRate);

        // when - then
        Assert.That(() => _ = wrapper.GetSampleRate(), Throws.Exception.TypeOf<SunVoxException>());
    }

    [Test]
    public void GetSongBpmShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var songBpm = Any.Integer();
        library.sv_get_song_bpm(Arg.Any<int>()).Returns(songBpm);
        var slotId = Any.Integer();

        // when
        var value = wrapper.GetSongBpm(slotId);

        // then
        library.Received(1).sv_get_song_bpm(slotId);
        Assert.That(value, Is.EqualTo(songBpm));
    }

    [Test]
    public void GetSongBpmShouldThrowOnInvalidValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_song_bpm(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => _ = wrapper.GetSongBpm(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_song_bpm(slotId);
    }

    [Test]
    public void GetSongLengthInFramesShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var songLength = Any.UnsignedInt();
        library.sv_get_song_length_frames(Arg.Any<int>()).Returns(songLength);
        var slotId = Any.Integer();

        // when
        var value = wrapper.GetSongLengthInFrames(slotId);

        // then
        library.Received(1).sv_get_song_length_frames(slotId);
        Assert.That(value, Is.EqualTo(songLength));
    }

    [Test]
    public void GetSongLengthInLinesShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var songLength = Any.UnsignedInt();
        library.sv_get_song_length_lines(Arg.Any<int>()).Returns(songLength);
        var slotId = Any.Integer();

        // when
        var value = wrapper.GetSongLengthInLines(slotId);

        // then
        library.Received(1).sv_get_song_length_lines(slotId);
        Assert.That(value, Is.EqualTo(songLength));
    }

    [Test]
    public void GetSongNameShouldReturnNullOnNullPtr()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();

        library.sv_get_song_name(Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var result = wrapper.GetSongName(slotId);

        // then
        Assert.That(result, Is.EqualTo(null));
        library.Received(1).sv_get_song_name(slotId);
    }

    [Test]
    public void GetSongNameShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        const string songName = "epic song";
        var slotId = Any.Integer();

        var ptr = Marshal.StringToHGlobalAnsi(songName);
        try
        {
            library.sv_get_song_name(Arg.Any<int>()).Returns(ptr);

            // when
            var result = wrapper.GetSongName(slotId);

            // then
            Assert.That(result, Is.EqualTo(songName));
            library.Received(1).sv_get_song_name(slotId);
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }
    }

    [Test]
    public void GetSongTplShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var songTpl = Any.Integer();
        library.sv_get_song_tpl(Arg.Any<int>()).Returns(songTpl);
        var slotId = Any.Integer();

        // when
        var value = wrapper.GetSongTpl(slotId);

        // then
        library.Received(1).sv_get_song_tpl(slotId);
        Assert.That(value, Is.EqualTo(songTpl));
    }

    [Test]
    public void GetSongTplShouldThrowOnInvalidValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_song_tpl(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => _ = wrapper.GetSongTpl(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_song_tpl(slotId);
    }

    [Test]
    public void GetTicksPerSecondShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var ticks = Any.UnsignedInt();
        library.sv_get_ticks_per_second().Returns(ticks);

        // when
        var result = wrapper.GetTicksPerSecond();

        // then
        Assert.That(result, Is.EqualTo(ticks));
    }

    [Test]
    public void GetTicksShouldReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var ticks = Any.UnsignedInt();
        library.sv_get_ticks().Returns(ticks);

        // when
        var result = wrapper.GetTicks();

        // then
        Assert.That(result, Is.EqualTo(ticks));
    }

    [Test]
    public void GetTimeMapShouldReturnExpectedValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var timeMap = Enumerable.Range(0, 64).ToArray();
        var slotId = Any.Integer();
        var startLine = Any.Integer();
        var length = timeMap.Length;
        var mapType = Any.Instance<TimeMapType>();

        library
            .When(static l =>
                l.sv_get_time_map(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                var intPtr = callInfo.Arg<IntPtr>();
                for (var i = 0; i < timeMap.Length; i++)
                    Marshal.WriteInt32(intPtr + i * 4, timeMap[i]);
            });

        // when
        var value = wrapper.GetTimeMap(slotId, startLine, length, mapType);

        // then
        library.Received(1).sv_get_time_map(slotId, startLine, length, Arg.Any<IntPtr>(), (int)mapType);
        value.Should().BeEquivalentTo(timeMap);
    }

    [Test]
    public void GetTimeMapShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var startLine = Any.Integer();
        var length = Any.Integer();
        var mapType = Any.Instance<TimeMapType>();
        library.sv_get_time_map(default, default, default, default, default).ReturnsForAnyArgs(-1);

        // when - then
        Assert.That(() => _ = wrapper.GetTimeMap(slotId, startLine, length, mapType),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_time_map(slotId, startLine, length, Arg.Any<IntPtr>(), (int)mapType);
    }

    [Test]
    public void InitializeShouldCallInitAndThrowExceptionOnUnhandledValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        var sampleRate = Any.Integer();
        var channels = Any.Instance<AudioChannels>();
        var initFlags = Any.Instance<InitFlags>();

        library.sv_init(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(-1);

        // when - then
        Assert.That(() => _ = wrapper.Initialize(sampleRate, null, channels, initFlags),
            Throws.Exception.TypeOf<SunVoxException>());

        // and then
        library.Received(1).sv_init(IntPtr.Zero, sampleRate, (int)channels, (uint)initFlags);
    }

    [Test]
    public void InitializeShouldCallInitAsExpected()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        const int returnCode = 123454321;
        library.sv_init(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(returnCode);

        var sampleRate = Any.Integer();
        var channels = Any.Instance<AudioChannels>();
        var initFlags = Any.Instance<InitFlags>();
        var config = Any.String();

        string? receivedString = null;
        library.When(static l => l.sv_init(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var version = wrapper.Initialize(sampleRate, config, channels, initFlags);

        // then
        library.Received(1).sv_init(Arg.Any<IntPtr>(), sampleRate, (int)channels, (uint)initFlags);
        Assert.That(version, Is.EqualTo(new LibraryVersion(returnCode)));
        Assert.That(receivedString, Is.EqualTo(config));
    }

    [Test]
    public void InitializeShouldCallInitAsExpectedWithNullConfig()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        const int returnCode = 123454321;
        library.sv_init(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(returnCode);

        var sampleRate = Any.Instance<int>();
        var channels = Any.Instance<AudioChannels>();
        var initFlags = Any.Instance<InitFlags>();

        // when
        var version = wrapper.Initialize(sampleRate, null, channels, initFlags);

        // then
        library.Received(1).sv_init(IntPtr.Zero, sampleRate, (int)channels, (uint)initFlags);
        Assert.That(version, Is.EqualTo(new LibraryVersion(returnCode)));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void IsPlayingShouldReturnExpectedValue(bool isPlaying)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_end_of_song(Arg.Any<int>()).Returns(isPlaying ? 0 : 1);
        var slotId = Any.Integer();

        // when
        var value = wrapper.IsPlaying(slotId);

        // then
        library.Received(1).sv_end_of_song(slotId);
        Assert.That(value, Is.EqualTo(isPlaying));
    }

    [TestCase(-1)]
    [TestCase(2)]
    public void IsPlayingShouldThrowOnUnexpectedValue(int returnCode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_end_of_song(Arg.Any<int>()).Returns(returnCode);
        var slotId = Any.Integer();

        // when
        Assert.That(() => _ = wrapper.IsPlaying(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_end_of_song(slotId);
    }

    [Test]
    public void LoadFromMemoryShouldCallExpectedMethods()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var data = Any.Array<byte>();
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
        Assert.That(receivedArray, Is.EquivalentTo(data));
        library.Received(1).sv_load_from_memory(slotId, Arg.Any<IntPtr>(), (uint)data.Length);
    }

    [Test]
    public void LoadFromMemoryShouldThrowOnNonzeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var data = Any.Array<byte>();

        library.sv_load_from_memory(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>()).Returns(-1);

        // when
        Assert.That(() => wrapper.Load(slotId, data), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_load_from_memory(slotId, Arg.Any<IntPtr>(), Arg.Any<uint>());
    }

    [Test]
    public void LoadShouldCallExpectedMethods()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var receivedString = string.Empty;
        var path = Any.String();

        library.When(static l => l.sv_load(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.Load(slotId, path);

        // then
        Assert.That(receivedString, Is.EqualTo(path));
        library.Received(1).sv_load(slotId, Arg.Any<IntPtr>());
    }

    [Test]
    public void LoadShouldThrowOnNonzeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var fileName = Any.String();

        library.sv_load(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        Assert.That(() => wrapper.Load(slotId, fileName), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_load(slotId, Arg.Any<IntPtr>());
    }

    [Test]
    public void LockSlotShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_lock_slot(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.LockSlot(slotId);

        // then
        library.Received(1).sv_lock_slot(slotId);
    }

    [Test]
    public void LockSlotShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_lock_slot(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.LockSlot(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_lock_slot(slotId);
    }

    [Test]
    public void OpenSlotShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_open_slot(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.OpenSlot(slotId);

        // then
        library.Received(1).sv_open_slot(slotId);
    }

    [Test]
    public void OpenSlotShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_open_slot(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.OpenSlot(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_open_slot(slotId);
    }

    [Test]
    public void PauseStreamShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_pause(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.PauseStream(slotId);

        // then
        library.Received(1).sv_pause(slotId);
    }

    [Test]
    public void PauseStreamShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_pause(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.PauseStream(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_pause(slotId);
    }

    [Test]
    public void ResumeStreamOnSyncEffectShouldCallMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sync_resume(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.ResumeStreamOnSyncEffect(slotId);

        // then
        library.Received(1).sv_sync_resume(slotId);
    }

    [Test]
    public void ResumeStreamOnSyncEffectShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sync_resume(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.ResumeStreamOnSyncEffect(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_sync_resume(slotId);
    }

    [Test]
    public void ResumeStreamShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_resume(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.ResumeStream(slotId);

        // then
        library.Received(1).sv_resume(slotId);
    }

    [Test]
    public void ResumeStreamShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_resume(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.ResumeStream(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_resume(slotId);
    }

    [Test]
    public void RewindShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_rewind(Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();
        var line = Any.Integer();

        // when
        wrapper.Rewind(slotId, line);

        // then
        library.Received(1).sv_rewind(slotId, line);
    }

    [Test]
    public void RewindShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_rewind(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();
        var line = Any.Integer();

        // when - then
        Assert.That(() => wrapper.Rewind(slotId, line), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_rewind(slotId, line);
    }

    [Test]
    public void SaveShouldCallExpectedMethods()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var receivedString = string.Empty;
        var path = Any.String();

        library.When(static l => l.sv_save(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.Save(slotId, path);

        // then
        Assert.That(receivedString, Is.EqualTo(path));
        library.Received(1).sv_save(slotId, Arg.Any<IntPtr>());
    }

    [Test]
    public void SaveShouldThrowOnUnexpectedReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var path = Any.String();

        library.sv_save(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        Assert.That(() => wrapper.Save(slotId, path), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_save(slotId, Arg.Any<IntPtr>());
    }

    [Test]
    public void SendEventAllOverloadsShouldSendArgumentsAsExpectex()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var track = Any.Integer();

        library.sv_send_event(default, default, default, default, default, default, default).ReturnsForAnyArgs(0);
        var @event = new PatternEvent(Any.Byte(), Any.Byte(), Any.UnsignedShort(), Any.Byte(), Any.UnsignedShort());

        // when
        wrapper.SendEvent(slotId, track, @event.NN, @event.VV, @event.MM, @event.CCEE, @event.XXYY);
        wrapper.SendEvent(slotId, track, @event);

        // then
        library.Received(2).sv_send_event(slotId, track, @event.NN, @event.VV, @event.MM, @event.CCEE, @event.XXYY);
    }

    [Test]
    public void SendEventAllOverloadsShouldThrowException()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var track = Any.Integer();

        library.sv_send_event(default, default, default, default, default, default, default).ReturnsForAnyArgs(-1);
        var @event = new PatternEvent(Any.Byte(), Any.Byte(), Any.UnsignedShort(), Any.Byte(), Any.UnsignedShort());

        Assert.Multiple(() =>
        {
            Assert.That(
                () => wrapper.SendEvent(slotId, track, @event.NN, @event.VV, @event.MM, @event.CCEE, @event.XXYY),
                Throws.Exception.TypeOf<SunVoxException>());
            Assert.That(() => wrapper.SendEvent(slotId, track, @event), Throws.Exception.TypeOf<SunVoxException>());
        });

        // then
        library.Received(2).sv_send_event(slotId, track, @event.NN, @event.VV, @event.MM, @event.CCEE, @event.XXYY);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void SetAutostopShouldCallWithArgument(bool autostop)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_autostop(Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.SetAutoStop(slotId, autostop);

        // then
        library.Received(1).sv_set_autostop(slotId, autostop ? 1 : 0);
    }

    [Test]
    public void SetAutostopShouldThrowOnInvalidReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_autostop(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.SetAutoStop(slotId, false), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_autostop(slotId, 0);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void SetSendEventTimestampShouldCallWithArgument(bool reset)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_event_t(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();
        var t = Any.Integer();

        // when
        wrapper.SetSendEventTimestamp(slotId, reset, t);

        // then
        library.Received(1).sv_set_event_t(slotId, reset ? 0 : 1, t);
    }

    [Test]
    public void SetSendEventTimestampShouldThrowOnInvalidReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_event_t(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();
        var t = Any.Integer();

        // when - then
        Assert.That(() => wrapper.SetSendEventTimestamp(slotId, false, t), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_event_t(slotId, 1, t);
    }

    [Test]
    public void SetSongNameShouldSendString()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var receivedString = string.Empty;
        var newSongName = Any.String();

        library.When(static l => l.sv_set_song_name(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.SetSongName(slotId, newSongName);

        // then
        Assert.That(receivedString, Is.EqualTo(newSongName));
        library.Received(1).sv_set_song_name(slotId, Arg.Any<IntPtr>());
    }

    [Test]
    public void SetSongNameShouldThrowExceptionOnNonzeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var slotId = Any.Integer();
        var newSongName = Any.String();

        library.sv_set_song_name(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetSongName(slotId, newSongName), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_song_name(slotId, Arg.Any<IntPtr>());
    }

    [Test]
    public void StartPlaybackFromBeginningShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_play_from_beginning(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.StartPlaybackFromBeginning(slotId);

        // then
        library.Received(1).sv_play_from_beginning(slotId);
    }

    [Test]
    public void StartPlaybackFromBeginningShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_play_from_beginning(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.StartPlaybackFromBeginning(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_play_from_beginning(slotId);
    }

    [Test]
    public void StartPlaybackShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_play(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.StartPlayback(slotId);

        // then
        library.Received(1).sv_play(slotId);
    }

    [Test]
    public void StartPlaybackShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_play(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.StartPlayback(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_play(slotId);
    }

    [Test]
    public void StopPlaybackShouldCallMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_stop(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.StopPlayback(slotId);

        // then
        library.Received(1).sv_stop(slotId);
    }

    [Test]
    public void StopPlaybackShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_stop(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.StopPlayback(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_stop(slotId);
    }

    [Test]
    public void UnlockSlotShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_unlock_slot(Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();

        // when
        wrapper.UnlockSlot(slotId);

        // then
        library.Received(1).sv_unlock_slot(slotId);
    }

    [Test]
    public void UnlockSlotShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_unlock_slot(Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.UnlockSlot(slotId), Throws.Exception.TypeOf<SunVoxException>());

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
        library.sv_update_input().Returns(-1);

        // when - then
        Assert.That(() => wrapper.UpdateInputDevices(), Throws.Exception.TypeOf<SunVoxException>());
    }

    [Test]
    public void VolumeShouldReturnExpectedValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        const int volume = 127;
        const int otherVolume = 125;
        library.sv_volume(Arg.Any<int>(), Arg.Any<int>()).Returns(volume);
        var slotId = Any.Integer();

        // when
        var value = wrapper.Volume(slotId, otherVolume);

        // then
        library.Received(1).sv_volume(slotId, otherVolume);
        Assert.That(value, Is.EqualTo(volume));
    }

    [Test]
    public void VolumeShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        const int otherVolume = 125;
        library.sv_volume(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();

        // when - then
        Assert.That(() => wrapper.Volume(slotId, otherVolume), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_volume(slotId, otherVolume);
    }
}
