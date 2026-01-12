namespace SunSharp.Tests;

public class NoteTests
{
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
        new(Note.Silence, "  "),
        new(Note.CleanSynths, "CS"),
        new(Note.CleanModule, "CM"),
        new(new Note(255), "??")
    ];

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
    public void GetNoteCharacterShouldReturnExpectedValue(NoteName argument, char expectedValue)
    {
        var value = argument.GetNoteCharacter();
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
    public void NoteNameGetterShouldReturnExpectedValue(byte noteValue, NoteName expectedValue)
    {
        var note = new Note(noteValue);
        var value = note.Name;
        value.Should().Be(expectedValue);
    }

    [TestCase(NoteName.C, 0, 1)]
    [TestCase(NoteName.Cs, 0, 2)]
    [TestCase(NoteName.C, 1, 13)]
    [TestCase(NoteName.Fs, 10, 127)]
    public void NoteConstructorFromOctaveAndNameShouldReturnExpectedValue(NoteName name, int octave, byte expectedValue)
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
    public void NoteConstructorFromOctaveAndNameShouldThrowOnInvalidArguments(NoteName name, int octave)
    {
        var action = () => _ = new Note(name, octave);
        action.Invoking(a => a())
        .Should().Throw<ArgumentOutOfRangeException>();
    }

    [TestCase(NoteName.Other)]
    [TestCase((NoteName)(-1))]
    [TestCase((NoteName)13)]
    public void NoteConstructorFromOctaveAndNameShouldThrowOnInvalidNoteName(NoteName name)
    {
        var action = () => _ = new Note(name, 1);
        action.Invoking(a => a())
            .Should().Throw<ArgumentException>();
    }

    [Test]
    public void NotePropertiesShouldReturnValidValuesForSpecialCases()
    {
        Note.AllNotesOff.IsAllNotesOff.Should().BeTrue();
        Note.Off.IsNoteOff.Should().BeTrue();
        Note.Play.IsPlay.Should().BeTrue();
        Note.SetPitch.IsSetPitch.Should().BeTrue();
        Note.Stop.IsStop.Should().BeTrue();
        Note.Silence.IsSilence.Should().BeTrue();
        Note.CleanSynths.IsCleanSynths.Should().BeTrue();
        Note.CleanModule.IsCleanModule.Should().BeTrue();

        Note.Silence.IsNormal.Should().BeFalse();
        Note.SetPitch.IsNormal.Should().BeFalse();
        Note.Stop.IsNormal.Should().BeFalse();
        Note.AllNotesOff.Octave.Should().Be(-1);
        Note.AllNotesOff.Name.Should().Be(NoteName.Other);

        var normalNote = new Note(NoteName.E, 5);
        normalNote.IsAllNotesOff.Should().BeFalse();
        normalNote.IsNoteOff.Should().BeFalse();
        normalNote.IsPlay.Should().BeFalse();
        normalNote.IsSetPitch.Should().BeFalse();
        normalNote.IsStop.Should().BeFalse();
        normalNote.IsSilence.Should().BeFalse();
        normalNote.IsCleanSynths.Should().BeFalse();
        normalNote.IsCleanModule.Should().BeFalse();
        normalNote.IsNormal.Should().BeTrue();
        normalNote.Octave.Should().Be(5);
        normalNote.Name.Should().Be(NoteName.E);
    }

    [TestCaseSource(nameof(TestCases))]
    public void NoteToStringShouldReturnExpectedValues(Note note, string expectedValue)
    {
        note.ToString().Should().Be(expectedValue);
    }

    [TestCase(0)]
    [TestCase(255)]
    [TestCase(10)]
    [TestCase(128)]
    public void NoteImplicitConversionShouldSetDataAsExpected(byte value)
    {
        var note = (Note)value;
        var otherValue = (byte)note;
        note.Value.Should().Be(value);
        otherValue.Should().Be(value);
    }

    [Test]
    public void NoteEqualityComparisonShouldJustWork()
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
    public void NoteGetHashCodeShouldPreserveComparability()
    {
        var a = new Note(1);
        var b = new Note(1);
        var c = new Note(2);

        a.GetHashCode().Should().Be(b.GetHashCode());
        a.GetHashCode().Should().NotBe(c.GetHashCode());
    }
}
