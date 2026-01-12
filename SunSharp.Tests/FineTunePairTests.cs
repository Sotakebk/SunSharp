namespace SunSharp.Tests;

public class FineTunePairTests
{
    [Test, AutoData]
    public void FineTunePairFromPackedValueHasExpectedValues(short fineTuneValue, short relativeNoteValue)
    {
        var packedValue = Helper.PackTwoSignedShorts(fineTuneValue, relativeNoteValue);
        var fineTune = new FineTunePair(packedValue);
        fineTune.RawValue.Should().Be(packedValue);
        fineTune.FineTune.Should().Be(fineTuneValue);
        fineTune.RelativeNote.Should().Be(relativeNoteValue);
    }

    [Test]
    public void FineTunePairToStringReturnsExpectedString()
    {
        var fineTune = new FineTunePair(0, 0);
        const string message = "Fine-tune: 0, relative note: 0.";
        fineTune.ToString().Should().Be(message);
        var anotherFineTune = new FineTunePair(9241, -9823);
        const string anotherMessage = "Fine-tune: 9241, relative note: -9823.";
        anotherFineTune.ToString().Should().Be(anotherMessage);
    }

    [Test]
    public void FineTunePairEqualityComparisonShouldJustWork()
    {
        var a = new FineTunePair(0, 1);
        var b = new FineTunePair(0, 1);
        var c = new FineTunePair(1, 0);
        a.Equals(b).Should().BeTrue();
        a.Equals(a).Should().BeTrue();
        a.Equals((object?)b).Should().BeTrue();
        a.Equals((object?)a).Should().BeTrue();
        a.Equals(null).Should().BeFalse();
        a.Equals(new object()).Should().BeFalse();
        new Note(1).Equals(2).Should().BeFalse();
        (a == b).Should().BeTrue();
        (a != c).Should().BeTrue();
        (a == c).Should().BeFalse();
    }

    [Test]
    public void FineTunePairGetHashCodeShouldPreserveComparability()
    {
        var a = new FineTunePair(0, 1);
        var b = new FineTunePair(0, 1);
        var c = new FineTunePair(1, 0);
        a.GetHashCode().Should().Be(b.GetHashCode());
        a.GetHashCode().Should().NotBe(c.GetHashCode());
    }
}
