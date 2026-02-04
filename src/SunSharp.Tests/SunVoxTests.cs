using SunSharp.Native;

namespace SunSharp.Tests;

public class SunVoxTests
{
#if !SUNSHARP_RELEASE

    [Test, AutoData]
    public void Constructor_WithOwnAudioStream_ShouldInitializeCorrectly(int sampleRate)
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.GetSampleRate().Returns(sampleRate);
        const int expectedSampleRate = 44100;
        mockLib.GetSampleRate().Returns(expectedSampleRate);

        // Act
        using var sunvox = new SunVox(mockLib, AudioChannels.Stereo);

        // Assert
        sunvox.Channels.Should().Be(AudioChannels.Stereo);
        sunvox.SampleRate.Should().Be(expectedSampleRate);
        sunvox.SingleThreaded.Should().BeFalse();
        sunvox.OutputType.Should().BeNull();
        sunvox.NeedsUserCallback.Should().BeFalse();
        sunvox.Version.Should().Be(new SunVoxVersion(2, 1, 0, 0));
        sunvox.Slots.Should().NotBeNull();
        mockLib.Received(1).Initialize(-1, Arg.Any<string?>(), AudioChannels.Stereo, SunVoxInitOptions.NoDebugOutput);
    }

    [Test]
    public void Constructor_WithOwnAudioStream_WithBufferSize_ShouldIncludeInConfig()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        using var sunvox = new SunVox(mockLib, bufferSize: 2048);

        // Assert
        mockLib.Received(1).Initialize(-1, Arg.Is<string?>(s => s != null && s.Contains("buffer=2048")), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>());
    }

    [Test]
    public void Constructor_WithOwnAudioStream_WithDevices_ShouldIncludeInConfig()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        using var sunvox = new SunVox(mockLib, deviceIn: "input_device", deviceOut: "output_device");

        // Assert
        mockLib.Received(1).Initialize(-1, Arg.Is<string?>(s => s != null && s.Contains("audiodevice_in=input_device") && s.Contains("audiodevice=output_device")), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>());
    }

    [Test]
    public void Constructor_WithOwnAudioStream_WithDriver_ShouldIncludeInConfig()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        using var sunvox = new SunVox(mockLib, driver: "asio");

        // Assert
        mockLib.Received(1).Initialize(-1, Arg.Is<string?>(s => s != null && s.Contains("audiodriver=asio")), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>());
    }

    [Test, AutoData]
    public void Constructor_WithUserCallback_Float32_ShouldInitializeCorrectly(int sampleRate)
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.GetSampleRate().Returns(sampleRate);

        // Act
        using var sunvox = new SunVox(mockLib, sampleRate, OutputType.Float32, AudioChannels.Stereo);

        // Assert
        sunvox.Channels.Should().Be(AudioChannels.Stereo);
        sunvox.SampleRate.Should().Be(sampleRate);
        sunvox.SingleThreaded.Should().BeFalse();
        sunvox.OutputType.Should().Be(OutputType.Float32);
        sunvox.NeedsUserCallback.Should().BeTrue();
        mockLib.Received(1).Initialize(sampleRate, Arg.Any<string?>(), AudioChannels.Stereo, SunVoxInitOptions.NoDebugOutput | SunVoxInitOptions.UserAudioCallback | SunVoxInitOptions.AudioFloat32);
    }

    [Test, AutoData]
    public void Constructor_WithUserCallback_Int16_ShouldInitializeCorrectly(int sampleRate)
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        using var sunvox = new SunVox(mockLib, sampleRate, OutputType.Int16, AudioChannels.Stereo);

        // Assert
        sunvox.OutputType.Should().Be(OutputType.Int16);
        sunvox.Channels.Should().Be(AudioChannels.Stereo);
        mockLib.Received(1).Initialize(sampleRate, Arg.Any<string?>(), AudioChannels.Stereo, SunVoxInitOptions.NoDebugOutput | SunVoxInitOptions.UserAudioCallback | SunVoxInitOptions.AudioInt16);
    }

    [Test]
    public void Constructor_WithUserCallback_ShouldCallInitializeWithCorrectFlags()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Float32, singleThreaded: true, noDebugOutput: true);

        // Assert
        mockLib.Received(1).Initialize(44100, null, AudioChannels.Stereo, SunVoxInitOptions.UserAudioCallback | SunVoxInitOptions.NoDebugOutput | SunVoxInitOptions.AudioFloat32 | SunVoxInitOptions.OneThread);
    }

    [Test]
    public void Constructor_WithUserCallback_InvalidSampleRate_ShouldThrow()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        Action act = () => new SunVox(mockLib, 0, OutputType.Float32);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("*Invalid value: 0*").And.ParamName.Should().Be("sampleRate");
    }

    [Test]
    public void Constructor_WithUserCallback_NegativeSampleRate_ShouldThrow()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        Action act = () => new SunVox(mockLib, -1, OutputType.Float32);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("*Invalid value: -1*").And.ParamName.Should().Be("sampleRate");
    }

    [Test]
    public void Properties_ShouldReturnCorrectValues()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        var expectedVersion = new SunVoxVersion(2, 1, 1, 0);
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(expectedVersion);
        mockLib.GetSampleRate().Returns(48000);

        // Act
        using var sunvox = new SunVox(mockLib, AudioChannels.Stereo);

        // Assert
        sunvox.Version.Should().Be(expectedVersion);
        sunvox.SampleRate.Should().Be(48000);
        sunvox.Channels.Should().Be(AudioChannels.Stereo);
        sunvox.Library.Should().Be(mockLib);
    }

    [Test]
    public void NeedsUserCallback_WithOwnAudioStream_ShouldReturnFalse()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        using var sunvox = new SunVox(mockLib);

        // Assert
        sunvox.NeedsUserCallback.Should().BeFalse();
    }

    [Test]
    public void NeedsUserCallback_WithUserCallback_ShouldReturnTrue()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));

        // Act
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Float32);

        // Assert
        sunvox.NeedsUserCallback.Should().BeTrue();
    }

    [Test]
    public void UpdateInputDevices_ShouldCallLibraryMethod()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        using var sunvox = new SunVox(mockLib);

        // Act
        sunvox.UpdateInputDevices();

        // Assert
        mockLib.Received(1).UpdateInputDevices();
    }

    [Test]
    public void AudioCallback_Float32_WithCorrectOutputType_ShouldCallLibrary()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.AudioCallback(Arg.Any<float[]>(), Arg.Any<AudioChannels>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(true);
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Float32);
        var buffer = new float[256];

        // Act
        var result = sunvox.AudioCallback(buffer, 128, 1000);

        // Assert
        result.Should().BeTrue();
        mockLib.Received(1).AudioCallback(buffer, AudioChannels.Stereo, 128, 1000);
    }

    [Test]
    public void AudioCallback_Float32_WithWrongOutputType_ShouldThrow()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Int16);
        var buffer = new float[256];

        // Act
        Action act = () => sunvox.AudioCallback(buffer, 128, 1000);

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("*Int16*Float32*");
    }

    [Test]
    public void AudioCallback_Float32_WithoutUserCallback_ShouldThrow()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        using var sunvox = new SunVox(mockLib);
        var buffer = new float[256];

        // Act
        Action act = () => sunvox.AudioCallback(buffer, 128, 1000);

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("*not initialized in user callback mode*");
    }

    [Test]
    public void AudioCallback_Float32WithInput_Float32_ShouldCallLibrary()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.AudioCallback(Arg.Any<float[]>(), Arg.Any<AudioChannels>(), Arg.Any<float[]>(), Arg.Any<AudioChannels>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(true);
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Float32);
        var outputBuffer = new float[256];
        var inputBuffer = new float[256];

        // Act
        var result = sunvox.AudioCallback(outputBuffer, inputBuffer, AudioChannels.Stereo, 128, 1000);

        // Assert
        result.Should().BeTrue();
        mockLib.Received(1).AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo, 128, 1000);
    }

    [Test]
    public void AudioCallback_Float32WithInput_Int16_ShouldCallLibrary()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.AudioCallback(Arg.Any<float[]>(), Arg.Any<AudioChannels>(), Arg.Any<short[]>(), Arg.Any<AudioChannels>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(true);
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Float32);
        var outputBuffer = new float[256];
        var inputBuffer = new short[256];

        // Act
        var result = sunvox.AudioCallback(outputBuffer, inputBuffer, AudioChannels.Stereo, 128, 1000);

        // Assert
        result.Should().BeTrue();
        mockLib.Received(1).AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo, 128, 1000);
    }

    [Test]
    public void AudioCallback_Int16_WithCorrectOutputType_ShouldCallLibrary()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.AudioCallback(Arg.Any<short[]>(), Arg.Any<AudioChannels>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(true);
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Int16);
        var buffer = new short[256];

        // Act
        var result = sunvox.AudioCallback(buffer, 128, 1000);

        // Assert
        result.Should().BeTrue();
        mockLib.Received(1).AudioCallback(buffer, AudioChannels.Stereo, 128, 1000);
    }

    [Test]
    public void AudioCallback_Int16_WithWrongOutputType_ShouldThrow()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Float32);
        var buffer = new short[256];

        // Act
        Action act = () => sunvox.AudioCallback(buffer, 128, 1000);

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("*Float32*Int16*");
    }

    [Test]
    public void AudioCallback_Int16WithInput_Float32_ShouldCallLibrary()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.AudioCallback(Arg.Any<short[]>(), Arg.Any<AudioChannels>(), Arg.Any<float[]>(), Arg.Any<AudioChannels>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(true);
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Int16);
        var outputBuffer = new short[256];
        var inputBuffer = new float[256];

        // Act
        var result = sunvox.AudioCallback(outputBuffer, inputBuffer, AudioChannels.Stereo, 128, 1000);

        // Assert
        result.Should().BeTrue();
        mockLib.Received(1).AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo, 128, 1000);
    }

    [Test]
    public void AudioCallback_Int16WithInput_Int16_ShouldCallLibrary()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.AudioCallback(Arg.Any<short[]>(), Arg.Any<AudioChannels>(), Arg.Any<short[]>(), Arg.Any<AudioChannels>(), Arg.Any<int>(), Arg.Any<uint>()).Returns(true);
        using var sunvox = new SunVox(mockLib, 44100, OutputType.Int16);
        var outputBuffer = new short[256];
        var inputBuffer = new short[256];

        // Act
        var result = sunvox.AudioCallback(outputBuffer, inputBuffer, AudioChannels.Stereo, 25, 1000);

        // Assert
        result.Should().BeTrue();
        mockLib.Received(1).AudioCallback(outputBuffer, AudioChannels.Stereo, inputBuffer, AudioChannels.Stereo, 25, 1000);
    }

    [Test]
    public void GetTicks_ShouldCallLibraryMethod()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.GetTicks().Returns(12345u);
        using var sunvox = new SunVox(mockLib);

        // Act
        var result = sunvox.GetTicks();

        // Assert
        result.Should().Be(12345u);
        mockLib.Received(1).GetTicks();
    }

    [Test]
    public void GetTicksPerSecond_ShouldCallLibraryMethod()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.GetTicksPerSecond().Returns(1000u);
        using var sunvox = new SunVox(mockLib);

        // Act
        var result = sunvox.GetTicksPerSecond();

        // Assert
        result.Should().Be(1000u);
        mockLib.Received(1).GetTicksPerSecond();
    }

    [Test]
    public void GetLog_ShouldCallLibraryMethod()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.GetLog(100).Returns("Test log message");
        using var sunvox = new SunVox(mockLib);

        // Act
        var result = sunvox.GetLog(100);

        // Assert
        result.Should().Be("Test log message");
        mockLib.Received(1).GetLog(100);
    }

    [Test]
    public void GetLog_WithNull_ShouldReturnNull()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        mockLib.GetLog(Arg.Any<int>()).Returns((string?)null);
        using var sunvox = new SunVox(mockLib);

        // Act
        var result = sunvox.GetLog(100);

        // Assert
        result.Should().BeNull();
    }

    [Test]
    public void Dispose_ShouldCallDeinitialize()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        using var sunvox = new SunVox(mockLib);

        // Act
        sunvox.Dispose();

        // Assert
        mockLib.Received(1).Deinitialize();
    }

    [Test]
    public void Dispose_CalledMultipleTimes_ShouldOnlyDeinitializeOnce()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        using var sunvox = new SunVox(mockLib);

        // Act
        sunvox.Dispose();
        sunvox.Dispose();
        sunvox.Dispose();

        // Assert
        mockLib.Received(1).Deinitialize();
    }

    [Test]
    public void Deinitialized_AfterDispose_ShouldBeTrue()
    {
        // Arrange
        var mockLib = Substitute.For<ISunVoxLib>();
        mockLib.Initialize(Arg.Any<int>(), Arg.Any<string?>(), Arg.Any<AudioChannels>(), Arg.Any<SunVoxInitOptions>()).Returns(new SunVoxVersion(2, 1, 0, 0));
        using var sunvox = new SunVox(mockLib);

        // Act
        sunvox.Deinitialized.Should().BeFalse();
        sunvox.Dispose();

        // Assert
        sunvox.Deinitialized.Should().BeTrue();
    }

#endif
}
