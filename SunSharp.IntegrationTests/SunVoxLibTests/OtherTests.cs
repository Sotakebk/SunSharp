namespace SunSharp.IntegrationTests.SunVoxLibTests;

internal class OtherTests : BaseIntegrationTests
{
    protected override void SetUp()
    {
    }

    [Test]
    public void Initialize_ShouldReturnExpectedVersion()
    {
        var version = Lib.Initialize(-1, options: SunVoxInitOptions.UserAudioCallback | SunVoxInitOptions.AudioFloat32);

        version.Major.Should().Be(2);
        version.Minor.Should().Be(1);
        version.Minor2.Should().Be(4);
    }
}
