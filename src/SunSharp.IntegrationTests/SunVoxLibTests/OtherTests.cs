namespace SunSharp.IntegrationTests.SunVoxLibTests;

internal class OtherTests : BaseIntegrationTest
{
    [Test]
    public void Initialize_ShouldReturnExpectedVersion()
    {
        var version = Lib.Initialize(48000, options: SunVoxInitOptions.UserAudioCallback | SunVoxInitOptions.AudioFloat32);

        version.Major.Should().Be(2);
        version.Minor.Should().Be(1);
        version.Minor2.Should().Be(4);

        Lib.Deinitialize();
    }

    [Test]
    public void InitializeAndDeinitialize_CanBeCalledManyTimes()
    {
        for (var i = 0; i < 99; i++)
        {
            Lib.Initialize(48000, options: SunVoxInitOptions.UserAudioCallback | SunVoxInitOptions.AudioFloat32);
            Lib.Deinitialize();
        }
    }
}
