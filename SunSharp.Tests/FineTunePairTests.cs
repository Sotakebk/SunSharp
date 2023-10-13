using NUnit.Framework;
using static TddXt.AnyRoot.Root;

namespace SunSharp.Tests;

public class FineTunePairTests
{
    [Test]
    public void FineTunePairFromPackedValueHasExpectedValues()
    {
        var fineTuneValue = Any.Instance<short>();
        var relativeNoteValue = Any.Instance<short>();

        var packedValue = Helper.PackTwoSignedShorts(fineTuneValue, relativeNoteValue);

        var fineTune = new FineTunePair(packedValue);
        Assert.Multiple(() =>
        {
            Assert.That(fineTune.Value, Is.EqualTo(packedValue));
            Assert.That(fineTune.FineTune, Is.EqualTo(fineTuneValue));
            Assert.That(fineTune.RelativeNote, Is.EqualTo(relativeNoteValue));
        });
    }

    [Test]
    public void FineTunePairToStringReturnsExpectedString()
    {
        var fineTune = new FineTunePair(0, 0);
        const string message = "Fine-tune: 0, relative note: 0.";

        Assert.That(fineTune.ToString(), Is.EqualTo(message));

        var anotherFineTune = new FineTunePair(9241, -9823);
        const string anotherMessage = "Fine-tune: 9241, relative note: -9823.";

        Assert.That(anotherFineTune.ToString(), Is.EqualTo(anotherMessage));
    }

    [Test]
    public void FineTunePairEqualityComparisonShouldJustWork()
    {
        var a = new FineTunePair(0, 1);
        var b = new FineTunePair(0, 1);
        var c = new FineTunePair(1, 0);

        Assert.Multiple(() =>
        {
#pragma warning disable NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
            Assert.That(a.Equals(b));
            Assert.That(a.Equals(a));
            Assert.That(a.Equals((object?)b));
            Assert.That(a.Equals((object?)a));
            Assert.That(a.Equals(null), Is.False);
            Assert.That(a.Equals(new object()), Is.False);
            Assert.That(new Note(1).Equals(2), Is.False);

            Assert.That(a == b);
            Assert.That(a != c);
            Assert.That(a == c, Is.False);
#pragma warning restore NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
        });
    }

    [Test]
    public void FineTunePairGetHashCodeShouldPreserveComparability()
    {
        var a = new FineTunePair(0, 1);
        var b = new FineTunePair(0, 1);
        var c = new FineTunePair(1, 0);

        Assert.Multiple(() =>
        {
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
            Assert.That(a.GetHashCode(), !Is.EqualTo(c.GetHashCode()));
        });
    }
}
