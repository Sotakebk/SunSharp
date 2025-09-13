using System.Runtime.InteropServices;
using SunSharp.Native;

namespace SunSharp.Tests.Native;

public class SunVoxLibNativeWrapperAudioCallbackTests
{
    private const int ErrorResponseCode = -1;

    #region input short, output short

    [Test, AutoData]
    public void ForOutputShortInStereoInputShortInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(bool expectedValue, int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var outputBuffer = new short[256];
        var inputBuffer = new short[256];
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var copiedOutputBuffer = Array.Empty<short>();
        var copiedInputBuffer = Array.Empty<short>();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo,
            latency, outTime);
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 0, 2,
            Arg.Any<IntPtr>());
        copiedOutputBuffer.Should().BeEquivalentTo(outputBuffer);
        copiedInputBuffer.Should().BeEquivalentTo(inputBuffer);
        returnedValue.Should().Be(expectedValue);
    }

    #endregion input short, output short

    #region input float, output short

    [Test, AutoData]
    public void
        ForOutputShortInStereoInputFloatInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(bool expectedValue, int latency, uint outTime)
    {
        var outputBuffer = new short[256];
        var inputBuffer = new float[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var copiedOutputBuffer = Array.Empty<short>();
        var copiedInputBuffer = Array.Empty<float>();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo,
            latency, outTime);
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 1, 2,
            Arg.Any<IntPtr>());
        copiedOutputBuffer.Should().BeEquivalentTo(outputBuffer);
        copiedInputBuffer.Should().BeEquivalentTo(inputBuffer);
        returnedValue.Should().Be(expectedValue);
    }

    #endregion

    #region input short, output float

    [Test, AutoData]
    public void
        ForOutputFloatInStereoInputShortInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(bool expectedValue, int latency, uint outTime)
    {
        var outputBuffer = new float[256];
        var inputBuffer = new short[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var copiedOutputBuffer = Array.Empty<float>();
        var copiedInputBuffer = Array.Empty<short>();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo,
            latency, outTime);
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 0, 2,
            Arg.Any<IntPtr>());
        copiedOutputBuffer.Should().BeEquivalentTo(outputBuffer);
        copiedInputBuffer.Should().BeEquivalentTo(inputBuffer);
        returnedValue.Should().Be(expectedValue);
    }

    #endregion

    #region output only, float, mono

    [Test, AutoData]
    public void ForFloatInMonoShouldCallExpectedMethodAndReturnsBooleanFromReturnCode(bool expectedValue, int latency, uint outTime)
    {
        var buffer = new float[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(expectedValue ? 1 : 0);
        var copiedBuffer = Array.Empty<float>();
        library.When(
                static l => l.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()))
            .Do(callInfo =>
            {
                copiedBuffer = new float[callInfo.ArgAt<int>(1)];
                Marshal.Copy(callInfo.Arg<IntPtr>(), copiedBuffer, 0, copiedBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(buffer, AudioChannels.Mono, latency, outTime);

        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), buffer.Length, latency, outTime);
        copiedBuffer.Should().BeEquivalentTo(buffer);
        returnedValue.Should().Be(expectedValue);
    }

    [Test, AutoData]
    public void ForFloatInMonoShouldThrowIfReturnCodeNotOneOrZero(float[] buffer, int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(ErrorResponseCode);
        // when
        wrapper.Invoking(w => w.AudioCallback(buffer, AudioChannels.Mono, latency, outTime)).Should().Throw<SunVoxException>();
        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    #endregion output only, float, mono

    #region output only, float, stereo

    [Test, AutoData]
    public void ForFloatInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(
        bool expectedValue, int latency, uint outTime)
    {
        var buffer = new float[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(expectedValue ? 1 : 0);
        var copiedBuffer = Array.Empty<float>();
        library.When(
                static l => l.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()))
            .Do(callInfo =>
            {
                copiedBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.Arg<IntPtr>(), copiedBuffer, 0, copiedBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime);

        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), buffer.Length / 2, latency, outTime);
        copiedBuffer.Should().BeEquivalentTo(buffer);
        returnedValue.Should().Be(expectedValue);
    }

    [Test, AutoData]
    public void ForFloatInStereoShouldThrowIfBufferSizeIsNotMultipleOfTwo(float[] buffer, int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(0);
        // when
        wrapper.Invoking(w => w.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime)).Should().Throw<ArgumentException>().WithMessage("Buffer size is not a multiple of two.");
        // then
        library.Received(0).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    [Test, AutoData]
    public void ForFloatInStereoShouldThrowIfReturnCodeNotOneOrZero(int latency, uint outTime)
    {
        var buffer = new float[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(ErrorResponseCode);
        // when
        wrapper.Invoking(w => w.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime)).Should().Throw<SunVoxException>();
        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    #endregion output only, float, stereo

    #region output only, short, mono

    [Test, AutoData]
    public void ForShortInMonoShouldCallExpectedMethodAndReturnsBooleanFromReturnCode(bool expectedValue, int latency, uint outTime)
    {
        var buffer = new short[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(expectedValue ? 1 : 0);
        var copiedBuffer = Array.Empty<short>();
        library.When(
                static l => l.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()))
            .Do(callInfo =>
            {
                copiedBuffer = new short[callInfo.ArgAt<int>(1)];
                Marshal.Copy(callInfo.Arg<IntPtr>(), copiedBuffer, 0, copiedBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(buffer, AudioChannels.Mono, latency, outTime);

        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), buffer.Length, latency, outTime);
        copiedBuffer.Should().BeEquivalentTo(buffer);
        returnedValue.Should().Be(expectedValue);
    }

    [Test, AutoData]
    public void ForShortInMonoShouldThrowIfReturnCodeNotOneOrZero(int latency, uint outTime)
    {
        var buffer = new short[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(ErrorResponseCode);
        // when
        wrapper.Invoking(w => w.AudioCallback(buffer, AudioChannels.Mono, latency, outTime)).Should().Throw<SunVoxException>();
        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    #endregion output only, short, mono

    #region output only, short, stereo

    [Test, AutoData]
    public void ForShortInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(
        bool expectedValue, int latency, uint outTime)
    {
        var buffer = new short[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(expectedValue ? 1 : 0);
        var copiedBuffer = Array.Empty<short>();
        library.When(
                static l => l.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()))
            .Do(callInfo =>
            {
                copiedBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.Arg<IntPtr>(), copiedBuffer, 0, copiedBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime);

        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), buffer.Length / 2, latency, outTime);
        copiedBuffer.Should().BeEquivalentTo(buffer);
        returnedValue.Should().Be(expectedValue);
    }

    [Test, AutoData]
    public void ForShortInStereoShouldThrowIfBufferSizeIsNotMultipleOfTwo(short[] buffer, int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(0);
        // when
        wrapper.Invoking(w => w.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime)).Should().Throw<ArgumentException>().WithMessage("Buffer size is not a multiple of two.");
        // then
        library.Received(0).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    [Test, AutoData]
    public void ForShortInStereoShouldThrowIfReturnCodeNotOneOrZero(int latency, uint outTime)
    {
        var buffer = new short[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(ErrorResponseCode);
        // when
        wrapper.Invoking(w => w.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime)).Should().Throw<SunVoxException>();
        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    #endregion output only, short, stereo

    #region output float mono, input float mono

    [Test, AutoData]
    public void ForOutputFloatInMonoInputFloatInMonoShouldCallExpectedMethodAndReturnsBooleanFromReturnCode(
        bool expectedValue, float[] outputBuffer, float[] inputBuffer, int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var copiedOutputBuffer = Array.Empty<float>();
        var copiedInputBuffer = Array.Empty<float>();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new float[callInfo.ArgAt<int>(1)];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new float[callInfo.ArgAt<int>(1)];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Mono, inputBuffer, AudioChannels.Mono,
            latency, outTime);
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length, latency, outTime, 1, 1,
            Arg.Any<IntPtr>());
        copiedOutputBuffer.Should().BeEquivalentTo(outputBuffer);
        copiedInputBuffer.Should().BeEquivalentTo(inputBuffer);
        returnedValue.Should().Be(expectedValue);
    }

    [Test, AutoData]
    public void ForOutputFloatInMonoInputFloatInMonoShouldThrowIfBufferSizeMismatched(int latency, uint outTime)
    {
        var outputBuffer = new float[10];
        var inputBuffer = new float[11];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(1);
        // when
        wrapper.Invoking(w => w.AudioCallback(outputBuffer, AudioChannels.Mono, inputBuffer, AudioChannels.Mono, latency, outTime))
            .Should().Throw<ArgumentException>();
        // then
        library.Received(0).sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void ForOutputFloatInMonoInputFloatInMonoShouldThrowIfReturnCodeNotOneOrZero(float[] outputBuffer, float[] inputBuffer, int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(ErrorResponseCode);
        // when
        wrapper.Invoking(w => w.AudioCallback(outputBuffer, AudioChannels.Mono, inputBuffer, AudioChannels.Mono, latency, outTime)).Should().Throw<SunVoxException>();
        // then
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>());
    }

    #endregion output float mono, input float mono

    #region output float stereo, input float mono

    [Test, AutoData]
    public void
        ForOutputFloatInStereoInputFloatInMonoShouldCallExpectedMethodWithHalfInputFramesAndReturnsBooleanFromReturnCode(bool expectedValue, int latency, uint outTime)
    {
        var outputBuffer = new float[256];
        var inputBuffer = new float[128];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var copiedOutputBuffer = Array.Empty<float>();
        var copiedInputBuffer = Array.Empty<float>();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new float[callInfo.ArgAt<int>(1)];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Mono,
            latency, outTime);
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 1, 1,
            Arg.Any<IntPtr>());
        copiedOutputBuffer.Should().BeEquivalentTo(outputBuffer);
        copiedInputBuffer.Should().BeEquivalentTo(inputBuffer);
        returnedValue.Should().Be(expectedValue);
    }

    [Test, AutoData]
    public void ForOutputFloatInStereoInputFloatInMonoShouldThrowDueToBufferSizeMismatch(float[] outputBuffer, float[] inputBuffer, int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(1);
        // when
        wrapper.Invoking(w => w.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Mono, latency, outTime))
            .Should().Throw<ArgumentException>();

        // then
        library.Received(0).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 1, 1, Arg.Any<IntPtr>());
    }

    #endregion output float stereo, input float mono

    #region input float stereo, output float stereo

    [Test, AutoData]
    public void
        ForOutputFloatInStereoInputFloatInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(bool expectedValue, int latency, uint outTime)
    {
        var outputBuffer = new float[256];
        var inputBuffer = new float[256];
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var copiedOutputBuffer = Array.Empty<float>();
        var copiedInputBuffer = Array.Empty<float>();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo,
            latency, outTime);
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 1, 2,
            Arg.Any<IntPtr>());
        copiedOutputBuffer.Should().BeEquivalentTo(outputBuffer);
        copiedInputBuffer.Should().BeEquivalentTo(inputBuffer);
        returnedValue.Should().Be(expectedValue);
    }

    [Test, AutoData]
    public void ForOutputFloatInStereoInputFloatInStereoShouldFailWhenInputBufferSizeNotDivisibleByTwo(int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        // Use provided parameters, but ensure inputBuffer is not divisible by two and outputBuffer is divisible by two
        var outputBuffer = new float[256];
        var inputBuffer = new float[255];
        // when
        wrapper.Invoking(w => w.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo, latency, outTime))
            .Should().Throw<ArgumentException>()
            .WithMessage("Input buffer size is not a multiple of two.");
        // then
        library.Received(0).sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void ForOutputFloatInStereoInputFloatInStereoShouldFailWhenOutputBufferSizeNotDivisibleByTwo(int latency, uint outTime)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        // Use provided parameters, but ensure outputBuffer is not divisible by two and inputBuffer is divisible by two
        var outputBuffer = new float[31];
        var inputBuffer = new float[32];
        // when
        wrapper.Invoking(w => w.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo, latency, outTime))
            .Should().Throw<ArgumentException>()
            .WithMessage("Output buffer size is not a multiple of two.");
        // then
        library.Received(0).sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>());
    }

    #endregion input float stereo, output float stereo
}
