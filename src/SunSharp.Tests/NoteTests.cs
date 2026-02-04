namespace SunSharp.Tests;

public class NoteTests
{
    [TestCase(NoteName.A, 'A')]
    [TestCase(NoteName.As, 'a')]
    [TestCase(NoteName.B, 'B')]
    [TestCase(NoteName.C, 'C')]
    [TestCase(NoteName.Cs, 'c')]
    [TestCase(NoteName.D, 'D')]
    [TestCase(NoteName.Ds, 'd')]
    [TestCase(NoteName.E, 'E')]
    [TestCase(NoteName.F, 'F')]
    [TestCase(NoteName.Fs, 'f')]
    [TestCase(NoteName.G, 'G')]
    [TestCase(NoteName.Gs, 'g')]
    [TestCase(NoteName.Other, '?')]
    [TestCase((NoteName)(-1), '?')]
    public void GetNoteCharacterAsDisplayed_ShouldReturnExpectedValue(NoteName argument, char expectedValue)
    {
        var value = argument.GetNoteCharacterAsDisplayed();
        value.Should().Be(expectedValue);
    }

    [TestCase(0, NoteName.Other)]
    [TestCase(1, NoteName.C)]
    [TestCase(2, NoteName.Cs)]
    [TestCase(1 + 12, NoteName.C)]
    [TestCase(1 + 12 * 2, NoteName.C)]
    [TestCase(1 + 12 * 3, NoteName.C)]
    [TestCase(1 + 12 * 8, NoteName.C)]
    [TestCase(127, NoteName.Fs)]
    [TestCase(128, NoteName.Other)]
    [TestCase(129, NoteName.Other)]
    public void NameGetter_ShouldReturnExpectedValue(byte noteValue, NoteName expectedValue)
    {
        var note = new Note(noteValue);
        var value = note.Name;
        value.Should().Be(expectedValue);
    }

    [TestCase(NoteName.C, 0, 1)]
    [TestCase(NoteName.Cs, 0, 2)]
    [TestCase(NoteName.C, 1, 13)]
    [TestCase(NoteName.Fs, 10, 127)]
    public void Constructor_FromOctaveAndName_ShouldReturnExpectedValue(NoteName name, int octave, byte expectedValue)
    {
        var note = new Note(name, octave);
        var value = note.Value;
        value.Should().Be(expectedValue);
        note.Octave.Should().Be(octave);
        note.Name.Should().Be(name);
    }

    [TestCase(NoteName.C, -1)]
    [TestCase(NoteName.C, 13)]
    [TestCase(NoteName.G, 10)]
    [TestCase(NoteName.Cb, 0)]
    public void NoteConstructor_FromOctaveAndName_ShouldThrowOnInvalidArguments(NoteName name, int octave)
    {
        var action = () => _ = new Note(name, octave);
        action.Invoking(a => a())
            .Should().Throw<ArgumentOutOfRangeException>();
    }

    [TestCase(NoteName.Other)]
    [TestCase((NoteName)(-2))]
    [TestCase((NoteName)13)]
    public void NoteConstructor_FromOctaveAndName_ShouldThrowOnInvalidNoteName(NoteName name)
    {
        var action = () => _ = new Note(name, 1);
        action.Invoking(a => a())
            .Should().Throw<ArgumentException>();
    }

    [Test]
    public void SpecialProperties_ShouldReturnValueAsExpected()
    {
        var normalNote = new Note(NoteName.E, 5);

        Note.AllNotesOff.IsAllNotesOff.Should().BeTrue();
        Note.AllNotesOff.Octave.Should().Be(-1);
        Note.AllNotesOff.Name.Should().Be(NoteName.Other);
        Note.AllNotesOff.IsMusicalNote.Should().BeFalse();
        normalNote.IsAllNotesOff.Should().BeFalse();

        Note.Off.IsNoteOff.Should().BeTrue();
        Note.Off.Octave.Should().Be(-1);
        Note.Off.Name.Should().Be(NoteName.Other);
        Note.Off.IsMusicalNote.Should().BeFalse();
        normalNote.IsNoteOff.Should().BeFalse();

        Note.Play.IsPlay.Should().BeTrue();
        Note.Play.Octave.Should().Be(-1);
        Note.Play.Name.Should().Be(NoteName.Other);
        Note.Play.IsMusicalNote.Should().BeFalse();
        normalNote.IsPlay.Should().BeFalse();

        Note.SetPitch.IsSetPitch.Should().BeTrue();
        Note.SetPitch.Octave.Should().Be(-1);
        Note.SetPitch.Name.Should().Be(NoteName.Other);
        Note.SetPitch.IsMusicalNote.Should().BeFalse();
        normalNote.IsSetPitch.Should().BeFalse();

        Note.Stop.IsStop.Should().BeTrue();
        Note.Stop.Octave.Should().Be(-1);
        Note.Stop.Name.Should().Be(NoteName.Other);
        Note.Stop.IsMusicalNote.Should().BeFalse();
        normalNote.IsStop.Should().BeFalse();

        Note.Nothing.IsNothing.Should().BeTrue();
        Note.Nothing.Octave.Should().Be(-1);
        Note.Nothing.Name.Should().Be(NoteName.Other);
        Note.Nothing.IsMusicalNote.Should().BeFalse();
        normalNote.IsNothing.Should().BeFalse();

        Note.CleanSynths.IsCleanSynths.Should().BeTrue();
        Note.CleanSynths.Octave.Should().Be(-1);
        Note.CleanSynths.Name.Should().Be(NoteName.Other);
        Note.CleanSynths.IsMusicalNote.Should().BeFalse();
        normalNote.IsCleanSynths.Should().BeFalse();

        Note.CleanModule.IsCleanModule.Should().BeTrue();
        Note.CleanModule.Octave.Should().Be(-1);
        Note.CleanModule.Name.Should().Be(NoteName.Other);
        Note.CleanModule.IsMusicalNote.Should().BeFalse();
        normalNote.IsCleanModule.Should().BeFalse();
    }

    public static TestCaseData[] TestCases =>
    [
        new(new Note(NoteName.C, 0), "C0"),
        new(new Note(NoteName.Cs, 0), "c0"),
        new(new Note(NoteName.G, 3), "G3"),
        new(Note.AllNotesOff, "-!"),
        new(Note.Off, "--"),
        new(Note.Play, "P!"),
        new(Note.SetPitch, "SP"),
        new(Note.Stop, "S!"),
        new(Note.Nothing, "  "),
        new(Note.CleanSynths, "CS"),
        new(Note.CleanModule, "CM"),
        new(new Note(255), "??"),
        new(new Note(NoteName.C, 10), "CA"),
        new(new Note(NoteName.Fs, 10), "fA")
    ];

    [TestCaseSource(nameof(TestCases))]
    public void ToString_ShouldReturnExpectedValue(Note note, string expectedValue)
    {
        note.ToString().Should().Be(expectedValue);
    }

    [TestCase(0)]
    [TestCase(255)]
    [TestCase(10)]
    [TestCase(128)]
    public void ImplicitConversion_ShouldSetDataAsExpected(byte value)
    {
        var note = (Note)value;
        var otherValue = (byte)note;
        note.Value.Should().Be(value);
        otherValue.Should().Be(value);
    }

    [Test]
    public void EqualityComparison_ShouldJustWork()
    {
        var a = new Note(1);
        var b = new Note(1);
        var c = new Note(2);

        a.Equals(b).Should().BeTrue();
        a.Equals(a).Should().BeTrue();
        a.Equals(1).Should().BeTrue();
        a.Equals(1).Should().BeTrue();
        a.Equals((object?)b).Should().BeTrue();
        a.Equals((object?)a).Should().BeTrue();
        a.Equals(null).Should().BeFalse();
        a.Equals(new object()).Should().BeFalse();
        b.Equals(new Note(2)).Should().BeFalse();
        b.Equals(2).Should().BeFalse();
        new Note(1).Equals(2).Should().BeFalse();

        (a == b).Should().BeTrue();
        (a != b).Should().BeFalse();
        (a == 1).Should().BeTrue();
        (a != 2).Should().BeTrue();
        (a != c).Should().BeTrue();
        (a == c).Should().BeFalse();
    }

    [Test]
    public void GetHashCode_ShouldPreserveComparability()
    {
        var a = new Note(1);
        var b = new Note(1);
        var c = new Note(2);

        a.GetHashCode().Should().Be(b.GetHashCode());
        a.GetHashCode().Should().NotBe(c.GetHashCode());
    }
}
