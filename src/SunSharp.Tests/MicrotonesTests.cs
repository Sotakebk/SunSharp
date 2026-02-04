namespace SunSharp.Tests;

public class MicrotonesTests
{
    [TestCase(0x7800, 16.35)]
    [TestCase(0x7800 - 0x100 * (12 * 4 + 9), 440)]
    [TestCase(0x7800 - 0x100 * (12 * 5 + 9), 880)]
    public void PitchToFrequency_ShouldReturnExpectedValue(double input, double expected)
    {
        var result = Microtones.PitchToFrequency((float)input);
        result.Should().BeApproximately((float)expected, (float)(expected * 0.01));

        var resultFloat = Microtones.PitchToFrequency((double)input);
        resultFloat.Should().BeApproximately((float)expected, (float)(expected * 0.01));
    }

    [TestCase(16.35, 0x7800)]
    [TestCase(440, 0x7800 - 0x100 * (12 * 4 + 9))]
    [TestCase(880, 0x7800 - 0x100 * (12 * 5 + 9))]
    public void FrequencyToPitch_ShouldReturnExpectedValue(double input, double expected)
    {
        var result = Microtones.FrequencyToPitch(input);
        result.Should().BeApproximately(expected, expected * 0.01);

        var resultFloat = Microtones.FrequencyToPitch((float)input);
        resultFloat.Should().BeApproximately((float)expected, (float)(expected * 0.01));
    }

    [TestCase(NoteName.C, 0, 0x7800)]
    [TestCase(NoteName.Cs, 0, 0x7800 - 0x100 * 1)]
    [TestCase(NoteName.D, 0, 0x7800 - 0x100 * 2)]
    [TestCase(NoteName.C, 1, 0x7800 - 0x100 * 12)]
    [TestCase(NoteName.C, 4, 0x7800 - 0x100 * (4 * 12))]
    [TestCase(NoteName.A, 4, 0x7800 - 0x100 * (4 * 12 + 9))]
    [TestCase(NoteName.C, 10, 0x0000)]
    public void NoteToPitch_ShouldReturnExpectedValue(NoteName noteName, int octave, short expectedPitch)
    {
        var pitch = Microtones.NoteToPitch(noteName, octave);
        pitch.Should().Be(expectedPitch);
    }

    [Test]
    public void NoteToPitch_InvalidNote_ThrowsArgumentException()
    {
        var action = () => Microtones.NoteToPitch(NoteName.Other, 0);
        action.Should().Throw<ArgumentException>();
    }

    [TestCase(NoteName.Cb, 0)]
    [TestCase(NoteName.G, 10)]
    [TestCase(NoteName.C, -1)]
    [TestCase(NoteName.Cs, 10)]
    [TestCase(NoteName.C, 11)]
    public void NoteToPitch_NoteOutOfRange_ThrowsArgumentOutOfRangeException(NoteName noteName, int octave)
    {
        var action = () => Microtones.NoteToPitch(noteName, octave);
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}
