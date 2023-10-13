using System;
using System.Runtime.InteropServices;
using NSubstitute;
using NUnit.Framework;
using SunSharp.Native;
using TddXt.AnyRoot.Collections;
using TddXt.AnyRoot.Numbers;
using static TddXt.AnyRoot.Root;

namespace SunSharp.Tests.Native;

public class SunVoxLibNativeWrapperAudioCallbackTests
{
    #region input short, output short

    [TestCase(true)]
    [TestCase(false)]
    public void
        ForOutputShortInStereoInputShortInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(
            bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var outputBuffer = Any.Array<short>(32);
        var copiedOutputBuffer = Array.Empty<short>();
        var inputBuffer = Any.Array<short>(32);
        var copiedInputBuffer = Array.Empty<short>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo,
            latency, outTime);

        // then
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 0, 2,
            Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(copiedOutputBuffer, Is.EquivalentTo(outputBuffer));
            Assert.That(copiedInputBuffer, Is.EquivalentTo(inputBuffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    #endregion input short, output short

    #region input float, output short

    [TestCase(true)]
    [TestCase(false)]
    public void
        ForOutputShortInStereoInputFloatInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(
            bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var outputBuffer = Any.Array<short>(32);
        var copiedOutputBuffer = Array.Empty<short>();
        var inputBuffer = Any.Array<float>(32);
        var copiedInputBuffer = Array.Empty<float>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo,
            latency, outTime);

        // then
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 1, 2,
            Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(copiedOutputBuffer, Is.EquivalentTo(outputBuffer));
            Assert.That(copiedInputBuffer, Is.EquivalentTo(inputBuffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    #endregion

    #region input short, output float

    [TestCase(true)]
    [TestCase(false)]
    public void
        ForOutputFloatInStereoInputShortInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(
            bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var outputBuffer = Any.Array<float>(32);
        var copiedOutputBuffer = Array.Empty<float>();
        var inputBuffer = Any.Array<short>(32);
        var copiedInputBuffer = Array.Empty<short>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new short[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo,
            latency, outTime);

        // then
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 0, 2,
            Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(copiedOutputBuffer, Is.EquivalentTo(outputBuffer));
            Assert.That(copiedInputBuffer, Is.EquivalentTo(inputBuffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    #endregion

    #region output only, float, mono

    [TestCase(true)]
    [TestCase(false)]
    public void ForFloatInMonoShouldCallExpectedMethodAndReturnsBooleanFromReturnCode(bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(expectedValue ? 1 : 0);
        var buffer = Any.Array<float>(25);
        var copiedBuffer = Array.Empty<float>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
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
        Assert.Multiple(() =>
        {
            Assert.That(copiedBuffer, Is.EquivalentTo(buffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    [TestCase(-1)]
    [TestCase(2)]
    public void ForFloatInMonoShouldThrowIfReturnCodeNotOneOrZero(int returnCode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(returnCode);
        var buffer = Any.Array<float>(1);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(() => wrapper.AudioCallback(buffer, AudioChannels.Mono, latency, outTime),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    #endregion output only, float, mono

    #region output only, float, stereo

    [TestCase(true)]
    [TestCase(false)]
    public void ForFloatInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(
        bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(expectedValue ? 1 : 0);
        var buffer = Any.Array<float>(32);
        var copiedBuffer = Array.Empty<float>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
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
        Assert.Multiple(() =>
        {
            Assert.That(copiedBuffer, Is.EquivalentTo(buffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    [Test]
    public void ForFloatInStereoShouldThrowIfBufferSizeIsNotMultipleOfTwo()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(0);
        var buffer = Any.Array<float>(31);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(() => wrapper.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime),
            Throws.ArgumentException.With.Message.EqualTo("Buffer size is not a multiple of two."));

        // then
        library.Received(0).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    [TestCase(-1)]
    [TestCase(2)]
    public void ForFloatInStereoShouldThrowIfReturnCodeNotOneOrZero(int returnCode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(returnCode);
        var buffer = Any.Array<float>(32);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(() => wrapper.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    #endregion output only, float, stereo

    #region output only, short, mono

    [TestCase(true)]
    [TestCase(false)]
    public void ForShortInMonoShouldCallExpectedMethodAndReturnsBooleanFromReturnCode(bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(expectedValue ? 1 : 0);
        var buffer = Any.Array<short>(25);
        var copiedBuffer = Array.Empty<short>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
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
        Assert.Multiple(() =>
        {
            Assert.That(copiedBuffer, Is.EquivalentTo(buffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    [TestCase(-1)]
    [TestCase(2)]
    public void ForShortInMonoShouldThrowIfReturnCodeNotOneOrZero(int returnCode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(returnCode);
        var buffer = Any.Array<short>(1);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(() => wrapper.AudioCallback(buffer, AudioChannels.Mono, latency, outTime),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    #endregion output only, short, mono

    #region output only, short, stereo

    [TestCase(true)]
    [TestCase(false)]
    public void ForShortInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(
        bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(expectedValue ? 1 : 0);
        var buffer = Any.Array<short>(32);
        var copiedBuffer = Array.Empty<short>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
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
        Assert.Multiple(() =>
        {
            Assert.That(copiedBuffer, Is.EquivalentTo(buffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    [Test]
    public void ForShortInStereoShouldThrowIfBufferSizeIsNotMultipleOfTwo()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(0);
        var buffer = Any.Array<short>(31);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(() => wrapper.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime),
            Throws.ArgumentException.With.Message.EqualTo("Buffer size is not a multiple of two."));

        // then
        library.Received(0).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    [TestCase(-1)]
    [TestCase(2)]
    public void ForShortInStereoShouldThrowIfReturnCodeNotOneOrZero(int returnCode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>())
            .Returns(returnCode);
        var buffer = Any.Array<short>(32);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(() => wrapper.AudioCallback(buffer, AudioChannels.Stereo, latency, outTime),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_audio_callback(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>());
    }

    #endregion output only, short, stereo

    #region output float mono, input float mono

    [TestCase(true)]
    [TestCase(false)]
    public void ForOutputFloatInMonoInputFloatInMonoShouldCallExpectedMethodAndReturnsBooleanFromReturnCode(
        bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var outputBuffer = Any.Array<float>(25);
        var copiedOutputBuffer = Array.Empty<float>();
        var inputBuffer = Any.Array<float>(25);
        var copiedInputBuffer = Array.Empty<float>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new float[callInfo.ArgAt<int>(1)];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new float[callInfo.ArgAt<int>(1)];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Mono, inputBuffer, AudioChannels.Mono,
            latency, outTime);

        // then
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length, latency, outTime, 1, 1,
            Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(copiedOutputBuffer, Is.EquivalentTo(outputBuffer));
            Assert.That(copiedInputBuffer, Is.EquivalentTo(inputBuffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    [Test]
    public void ForOutputFloatInMonoInputFloatInMonoShouldThrowIfBufferSizeMismatched()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(1);
        var outputBuffer = Any.Array<float>(1);
        var inputBuffer = Any.Array<float>(2);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(
            () => wrapper.AudioCallback(outputBuffer, AudioChannels.Mono, inputBuffer, AudioChannels.Mono, latency,
                outTime), Throws.ArgumentException);

        // then
        library.Received(0).sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(),
            Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>());
    }

    [TestCase(-1)]
    [TestCase(2)]
    public void ForOutputFloatInMonoInputFloatInMonoShouldThrowIfReturnCodeNotOneOrZero(int returnCode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(returnCode);
        var outputBuffer = Any.Array<float>(25);
        var inputBuffer = Any.Array<float>(25);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(
            () => wrapper.AudioCallback(outputBuffer, AudioChannels.Mono, inputBuffer, AudioChannels.Mono, latency,
                outTime), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(),
            Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>());
    }

    #endregion output float mono, input float mono

    #region output float stereo, input float mono

    [TestCase(true)]
    [TestCase(false)]
    public void
        ForOutputFloatInStereoInputFloatInMonoShouldCallExpectedMethodWithHalfInputFramesAndReturnsBooleanFromReturnCode(
            bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var outputBuffer = Any.Array<float>(32);
        var copiedOutputBuffer = Array.Empty<float>();
        var inputBuffer = Any.Array<float>(16);
        var copiedInputBuffer = Array.Empty<float>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new float[callInfo.ArgAt<int>(1)];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Mono,
            latency, outTime);

        // then
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 1, 1,
            Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(copiedOutputBuffer, Is.EquivalentTo(outputBuffer));
            Assert.That(copiedInputBuffer, Is.EquivalentTo(inputBuffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    [Test]
    public void ForOutputFloatInStereoInputFloatInMonoShouldThrowDueToBufferSizeMismatch()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(1);
        var outputBuffer = Any.Array<float>(32);
        var inputBuffer = Any.Array<float>(17); // 17 is not half of 32
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(
            () => wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Mono, latency,
                outTime), Throws.ArgumentException);

        // then
        library.Received(0).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 1, 1,
            Arg.Any<IntPtr>());
    }

    #endregion output float stereo, input float mono

    #region input float stereo, output float stereo

    [TestCase(true)]
    [TestCase(false)]
    public void
        ForOutputFloatInStereoInputFloatInStereoShouldCallExpectedMethodWithHalfFramesAndReturnsBooleanFromReturnCode(
            bool expectedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(expectedValue ? 1 : 0);
        var outputBuffer = Any.Array<float>(32);
        var copiedOutputBuffer = Array.Empty<float>();
        var inputBuffer = Any.Array<float>(32);
        var copiedInputBuffer = Array.Empty<float>();
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();
        library.When(static l => l.sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<uint>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo =>
            {
                copiedOutputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(0), copiedOutputBuffer, 0, copiedOutputBuffer.Length);
                copiedInputBuffer = new float[callInfo.ArgAt<int>(1) * 2];
                Marshal.Copy(callInfo.ArgAt<IntPtr>(6), copiedInputBuffer, 0, copiedInputBuffer.Length);
            });

        // when
        var returnedValue = wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo,
            latency, outTime);

        // then
        library.Received(1).sv_audio_callback2(Arg.Any<IntPtr>(), outputBuffer.Length / 2, latency, outTime, 1, 2,
            Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(copiedOutputBuffer, Is.EquivalentTo(outputBuffer));
            Assert.That(copiedInputBuffer, Is.EquivalentTo(inputBuffer));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        });
    }

    [Test]
    public void ForOutputFloatInStereoInputFloatInStereoShouldFailWhenInputBufferSizeNotDivisibleByTwo()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var outputBuffer = Any.Array<float>(32);
        var inputBuffer = Any.Array<float>(31);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(
            () => wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo, latency,
                outTime),
            Throws.ArgumentException.With.Message.EqualTo("Input buffer size is not a multiple of two."));

        // then
        library.Received(0).sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(),
            Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>());
    }

    [Test]
    public void ForOutputFloatInStereoInputFloatInStereoShouldFailWhenOutputBufferSizeNotDivisibleByTwo()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var outputBuffer = Any.Array<float>(31);
        var inputBuffer = Any.Array<float>(32);
        var latency = Any.Integer();
        var outTime = Any.UnsignedInt();

        // when
        Assert.That(
            () => wrapper.AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo, latency,
                outTime),
            Throws.ArgumentException.With.Message.EqualTo("Output buffer size is not a multiple of two."));

        // then
        library.Received(0).sv_audio_callback2(Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<uint>(),
            Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>());
    }

    #endregion input float stereo, output float stereo
}
