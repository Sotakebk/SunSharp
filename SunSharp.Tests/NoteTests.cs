using System;
using NUnit.Framework;

namespace SunSharp.Tests;

public class NoteTests
{
    public static TestCaseData[] TestCases => new TestCaseData[]
    {
        new(new Note(NoteName.C, 0), "C0"),
        new(new Note(NoteName.Cs, 0), "c0"),
        new(new Note(NoteName.G, 3), "G3"),
        new(Note.AllNotesOff, "-!"),
        new(Note.Off, "--"),
        new(Note.Play, "P!"),
        new(Note.SetPitch, "SP"),
        new(Note.Stop, "S!"),
        new(Note.Silence, "__"),
        new(Note.CleanSynths, "CS"),
        new(Note.CleanModule, "CM"),
        new(new Note(255), "??")
    };

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

        Assert.That(value, Is.EqualTo(expectedValue));
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

        Assert.That(value, Is.EqualTo(expectedValue));
    }

    [TestCase(NoteName.C, 0, 1)]
    [TestCase(NoteName.Cs, 0, 2)]
    [TestCase(NoteName.C, 1, 13)]
    [TestCase(NoteName.Fs, 10, 127)]
    public void NoteConstructorFromOctaveAndNameShouldReturnExpectedValue(NoteName name, int octave, byte expectedValue)
    {
        var note = new Note(name, octave);
        var value = note.Value;

        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(expectedValue));
            Assert.That(note.Octave, Is.EqualTo(octave));
            Assert.That(note.Name, Is.EqualTo(name));
        });
    }

    [TestCase(NoteName.C, -1)]
    [TestCase(NoteName.C, 13)]
    [TestCase(NoteName.G, 10)]
    public void NoteConstructorFromOctaveAndNameShouldThrowOnInvalidArguments(NoteName name, int octave)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Note(name, octave));
    }

    [TestCase(NoteName.Other)]
    [TestCase((NoteName)(-1))]
    [TestCase((NoteName)13)]
    public void NoteConstructorFromOctaveAndNameShouldThrowOnInvalidNoteName(NoteName name)
    {
        Assert.Throws<ArgumentException>(() => _ = new Note(name, 1));
    }

    [Test]
    public void NotePropertiesShouldReturnValidValuesForSpecialCases()
    {
        Assert.Multiple(static () =>
        {
            Assert.That(Note.AllNotesOff.IsAllNotesOff, Is.True);
            Assert.That(Note.Off.IsNoteOff, Is.True);
            Assert.That(Note.Play.IsPlay, Is.True);
            Assert.That(Note.SetPitch.IsSetPitch, Is.True);
            Assert.That(Note.Stop.IsStop, Is.True);
            Assert.That(Note.Silence.IsSilence, Is.True);
            Assert.That(Note.CleanSynths.IsCleanSynths, Is.True);
            Assert.That(Note.CleanModule.IsCleanModule, Is.True);

            Assert.That(Note.Silence.IsNormal, Is.False);
            Assert.That(Note.SetPitch.IsNormal, Is.False);
            Assert.That(Note.Stop.IsNormal, Is.False);
            Assert.That(Note.AllNotesOff.Octave, Is.EqualTo(-1));
            Assert.That(Note.AllNotesOff.Name, Is.EqualTo(NoteName.Other));
        });

        Assert.Multiple(static () =>
        {
            var normalNote = new Note(NoteName.E, 5);

            Assert.That(normalNote.IsAllNotesOff, Is.False);
            Assert.That(normalNote.IsNoteOff, Is.False);
            Assert.That(normalNote.IsPlay, Is.False);
            Assert.That(normalNote.IsSetPitch, Is.False);
            Assert.That(normalNote.IsStop, Is.False);
            Assert.That(normalNote.IsSilence, Is.False);
            Assert.That(normalNote.IsCleanSynths, Is.False);
            Assert.That(normalNote.IsCleanModule, Is.False);
            Assert.That(normalNote.IsNormal, Is.True);
            Assert.That(normalNote.Octave, Is.EqualTo(5));
            Assert.That(normalNote.Name, Is.EqualTo(NoteName.E));
        });
    }

    [TestCaseSource(nameof(TestCases))]
    public void NoteToStringShouldReturnExpectedValues(Note note, string expectedValue)
    {
        Assert.That(note.ToString(), Is.EqualTo(expectedValue));
    }

    [TestCase(0)]
    [TestCase(255)]
    [TestCase(10)]
    [TestCase(128)]
    public void NoteImplicitConversionShouldSetDataAsExpected(byte value)
    {
        var note = (Note)value;
        var otherValue = (byte)note;

        Assert.Multiple(() =>
        {
            Assert.That(note.Value, Is.EqualTo(value));
            Assert.That(otherValue, Is.EqualTo(value));
        });
    }

    [Test]
    public void NoteEqualityComparisonShouldJustWork()
    {
        var a = new Note(1);
        var b = new Note(1);
        var c = new Note(2);

        Assert.Multiple(() =>
        {
#pragma warning disable NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
            Assert.That(a.Equals(b));
            Assert.That(a.Equals(a));
            Assert.That(a.Equals(1));
            Assert.That(a.Equals(1));
            Assert.That(a.Equals((object?)b));
            Assert.That(a.Equals((object?)a));
            Assert.That(a.Equals(null), Is.False);
            Assert.That(a.Equals(new object()), Is.False);
            Assert.That(b.Equals(new Note(2)), Is.False);
            Assert.That(b.Equals(2), Is.False);
            Assert.That(new Note(1).Equals(2), Is.False);

            Assert.That(a == b);
            Assert.That(a != b, Is.False);
            Assert.That(a == 1);
            Assert.That(a != 2);
            Assert.That(a != c);
            Assert.That(a == c, Is.False);
#pragma warning restore NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
        });
    }

    [Test]
    public void NoteGetHashCodeShouldPreserveComparability()
    {
        var a = new Note(1);
        var b = new Note(1);
        var c = new Note(2);

        Assert.Multiple(() =>
        {
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
            Assert.That(a.GetHashCode(), !Is.EqualTo(c.GetHashCode()));
        });
    }
}
