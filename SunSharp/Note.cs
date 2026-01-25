using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    /// <summary>
    /// Represents a musical note or command in the SunVox pattern format.
    /// This structure encapsulates both standard musical notes (C0-F#10) and special commands
    /// like note off, stop, play, etc.
    /// </summary>
    /// <remarks>
    /// The note value is stored as a single byte where:
    /// <list type="bullet">
    /// <item><description>0 = Nothing/Silence</description></item>
    /// <item><description>1-127 = Musical notes (C0 = 1, C#0 = 2, ..., F#10 = 127)</description></item>
    /// <item><description>128+ = Special commands (note off, stop, play, etc.)</description></item>
    /// </list>
    /// </remarks>
    /// <seealso cref="NoteName"/>
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public readonly struct Note : IEquatable<Note>
    {
        /// <summary>
        /// The raw byte value of the note.
        /// </summary>
        [FieldOffset(0)] public readonly byte Value;

        private const byte NOTECMD_NOTE_OFF = 128;
        private const byte NOTECMD_ALL_NOTES_OFF = 129;
        private const byte NOTECMD_CLEAN_SYNTHS = 130;
        private const byte NOTECMD_STOP = 131;
        private const byte NOTECMD_PLAY = 132;
        private const byte NOTECMD_SET_PITCH = 133;
        private const byte NOTECMD_PREVIOUS_TRACK = 134;
        private const byte NOTECMD_CLEAN_MODULE = 140;

        /// <summary>
        /// Does nothing.
        /// </summary>
        public static Note Nothing => 0;

        /// <summary>
        /// Stops the note playing on its track.
        /// </summary>
        public static Note Off => NOTECMD_NOTE_OFF;

        /// <summary>
        /// Sends "note off" to all modules.
        /// </summary>
        public static Note AllNotesOff => NOTECMD_ALL_NOTES_OFF;

        /// <summary>
        /// Stops all modules, clears their internal buffers and puts them into standby mode.
        /// </summary>
        public static Note CleanSynths => NOTECMD_CLEAN_SYNTHS;

        /// <summary>
        /// Stops playing the project.
        /// </summary>
        public static Note Stop => NOTECMD_STOP;

        /// <summary>
        /// Starts playing the project.
        /// </summary>
        public static Note Play => NOTECMD_PLAY;

        /// <summary>
        /// Sets the pitch specified in column XXYY, where 0x0000 - highest possible pitch,
        /// 0x7800 -lowest pitch (note C0); one semitone = 0x100.
        /// </summary>
        /// <remarks>
        /// Consider using the <see cref="Microtones"/> helper class for pitch conversions.
        /// </remarks>
        public static Note SetPitch => NOTECMD_SET_PITCH;

        /// <summary>
        /// Stops the module, clears its internal buffers and puts it into standby mode.
        /// </summary>
        public static Note CleanModule => NOTECMD_CLEAN_MODULE;

        /// <summary>
        /// Used to apply effects to the previous track.
        /// </summary>
        public static Note PreviousTrack => NOTECMD_PREVIOUS_TRACK;

        /// <summary>
        /// Get the name of the note. Returns valid values for notes in range C0 to F#10 inclusive.
        /// Returns <see cref="NoteName.Other"/> otherwise.
        /// </summary>
        public NoteName Name
        {
            get
            {
                if (IsMusicalNote)
                {
                    return (NoteName)((Value - 1) % 12);
                }

                return NoteName.Other;
            }
        }

        /// <summary>
        /// Gets the octave number of the musical note, if applicable.
        /// </summary>
        /// <remarks>
        /// Returns <c>-1</c> if the value does not represent a musical note.
        /// </remarks>
        public int Octave
        {
            get
            {
                if (IsMusicalNote)
                {
                    return (Value - 1) / 12;
                }
                return -1;
            }
        }

        public bool IsNoteOff => Value == NOTECMD_NOTE_OFF;

        public bool IsAllNotesOff => Value == NOTECMD_ALL_NOTES_OFF;

        public bool IsCleanSynths => Value == NOTECMD_CLEAN_SYNTHS;

        public bool IsCleanModule => Value == NOTECMD_CLEAN_MODULE;

        public bool IsStop => Value == NOTECMD_STOP;

        public bool IsPlay => Value == NOTECMD_PLAY;

        public bool IsSetPitch => Value == NOTECMD_SET_PITCH;

        public bool IsNothing => Value == 0;

        /// <summary>
        /// Gets a value indicating whether this is a normal musical note (C0-F#10).
        /// </summary>
        public bool IsMusicalNote => Value > 0 && Value < 128;

        /// <summary>
        /// Whether the note value can be displayed in SunVox's pattern editor.
        /// Does not include commands that don't have a visual representation.
        /// </summary>
        public bool IsDisplayable => Value <= 128 // nothing, note or silence
            || Value == NOTECMD_SET_PITCH
            || Value == NOTECMD_PREVIOUS_TRACK
            || Value == NOTECMD_CLEAN_MODULE;

        /// <summary>
        /// Gets a value indicating whether the value is considered a valid note or command in SunVox.
        /// </summary>
        public bool IsValid => IsDisplayable
            || Value == NOTECMD_ALL_NOTES_OFF
            || Value == NOTECMD_CLEAN_SYNTHS
            || Value == NOTECMD_STOP
            || Value == NOTECMD_PLAY;

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> struct with the specified raw byte value.
        /// </summary>
        public Note(byte value)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> struct with the specified note name and octave.
        /// Valid range is C0 to F#10 inclusive.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="name"/> is not a valid note name.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the note and octave combination is out of the supported range (C0 to F#10).
        /// </exception>
        public Note(NoteName name, int octave)
        {
            if (!name.IsValidNoteName())
            {
                throw new ArgumentException($"Unsupported note '{name}'.");
            }

            var i = 1 + (int)name + (octave * 12);
            if (i < 1 || i > 127)
            {
                throw new ArgumentOutOfRangeException($"The note '{name}' at octave '{octave}' is out of supported range (C0 to F#10).");
            }

            Value = (byte)i;
        }

        #region shorthand factory methods

        /// <summary>
        /// Creates a C note at the specified octave.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <inheritdoc cref="Note.Note(NoteName, int)" path="/exception[@cref='ArgumentOutOfRangeException']"/>
        /// </exception>
        public static Note C(int octave) => new Note(NoteName.C, octave);

        /// <summary>
        /// Creates a C# note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Cs(int octave) => new Note(NoteName.Cs, octave);

        /// <summary>
        /// Creates a D♭ note at the specified octave. Enharmonic equivalent of C#.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Db(int octave) => new Note(NoteName.Db, octave);

        /// <summary>
        /// Creates a D note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note D(int octave) => new Note(NoteName.D, octave);

        /// <summary>
        /// Creates a D# note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Ds(int octave) => new Note(NoteName.Ds, octave);

        /// <summary>
        /// Creates an E♭ note at the specified octave. Enharmonic equivalent of D#.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Eb(int octave) => new Note(NoteName.Eb, octave);

        /// <summary>
        /// Creates an E note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note E(int octave) => new Note(NoteName.E, octave);

        /// <summary>
        /// Creates an E# note at the specified octave. Enharmonic equivalent of F.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Es(int octave) => new Note(NoteName.Es, octave);

        /// <summary>
        /// Creates an F♭ note at the specified octave. Enharmonic equivalent of E.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Fb(int octave) => new Note(NoteName.Fb, octave);

        /// <summary>
        /// Creates an F note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note F(int octave) => new Note(NoteName.F, octave);

        /// <summary>
        /// Creates an F# note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Fs(int octave) => new Note(NoteName.Fs, octave);

        /// <summary>
        /// Creates a G♭ note at the specified octave. Enharmonic equivalent of F#.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Gb(int octave) => new Note(NoteName.Gb, octave);

        /// <summary>
        /// Creates a G note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note G(int octave) => new Note(NoteName.G, octave);

        /// <summary>
        /// Creates a G# note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Gs(int octave) => new Note(NoteName.Gs, octave);

        /// <summary>
        /// Creates an A♭ note at the specified octave. Enharmonic equivalent of G#.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Ab(int octave) => new Note(NoteName.Ab, octave);

        /// <summary>
        /// Creates an A note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note A(int octave) => new Note(NoteName.A, octave);

        /// <summary>
        /// Creates an A# note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note As(int octave) => new Note(NoteName.As, octave);

        /// <summary>
        /// Creates a B♭ note at the specified octave. Enharmonic equivalent of A#.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note Bb(int octave) => new Note(NoteName.Bb, octave);

        /// <summary>
        /// Creates a B note at the specified octave.
        /// </summary>
        /// <inheritdoc cref="C"/>
        public static Note B(int octave) => new Note(NoteName.B, octave);

        /// <summary>
        /// Creates a B# note at the specified octave. Enharmonic equivalent of C in the next octave.
        /// </summary>
        /// <remarks>
        /// Since B♯ is a semitone above B, it actually belongs to the next octave.
        /// For example, B♯3 = C4, B♯4 = C5, etc.
        /// </remarks>
        /// <inheritdoc cref="C"/>
        public static Note Bs(int octave) => new Note(NoteName.Bs, octave);

        /// <summary>
        /// Creates a C♭ note at the specified octave. Enharmonic equivalent of B in the previous octave.
        /// </summary>
        /// <remarks>
        /// Since C♭ is a semitone below C, it actually belongs to the previous octave.
        /// For example, C♭4 = B3, C♭5 = B4, etc.
        /// </remarks>
        /// <inheritdoc cref="C"/>
        public static Note Cb(int octave) => new Note(NoteName.Cb, octave);

        #endregion shorthand factory methods

        public static implicit operator Note(byte value)
        {
            return new Note(value);
        }

        public static implicit operator byte(Note note)
        {
            return note.Value;
        }

        /// <summary>
        /// Returns a two-character string representation of the note.
        /// </summary>
        /// <remarks>
        /// The <see cref="ToString"/> returns a two-character string representing the note or command,
        /// even if SunVox does not display it in the pattern editor.
        /// </remarks>
        /// <returns>
        /// A two-character string representing the note:
        /// <list type="bullet">
        /// <item><description>two empty spaces for nothing/silence</description></item>
        /// <item><description>"--" for <see cref="Off"/></description></item>
        /// <item><description>"-!" for <see cref="AllNotesOff"/></description></item>
        /// <item><description>"CS" for <see cref="CleanSynths"/></description></item>
        /// <item><description>"CM" for <see cref="CleanModule"/></description></item>
        /// <item><description>"S!" for <see cref="Stop"/></description></item>
        /// <item><description>"P!" for <see cref="Play"/></description></item>
        /// <item><description>"SP" for <see cref="SetPitch"/></description></item>
        /// <item><description>Note name and octave (e.g., "C4", "d5") for musical notes</description></item>
        /// <item><description>"??" for unknown/invalid values</description></item>
        /// </list>
        /// </returns>
        public override string ToString()
        {
            return Value switch
            {
                0 => "  ",
                NOTECMD_NOTE_OFF => "--",
                NOTECMD_ALL_NOTES_OFF => "-!",
                NOTECMD_CLEAN_SYNTHS => "CS",
                NOTECMD_CLEAN_MODULE => "CM",
                NOTECMD_STOP => "S!",
                NOTECMD_PLAY => "P!",
                NOTECMD_SET_PITCH => "SP",
                NOTECMD_PREVIOUS_TRACK => "<<",
                _ => IsMusicalNote ? MusicalNoteToString() : "??"
            };
        }

        private string MusicalNoteToString()
        {
            return $"{Name.GetNoteCharacterAsDisplayed()}{OctaveToChar(Octave)}";
        }

        private static char OctaveToChar(int octave)
        {
            if (octave < 10)
            {
                return (char)('0' + octave);
            }
            return (char)('A' + (octave-10));
        }

        /// <inheritdoc/>
        public bool Equals(Note other)
        {
            return Value == other.Value;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj switch
            {
                Note other => Equals(other),
                byte b => Equals(b),
                _ => false
            };
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Note left, Note right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Note left, Note right)
        {
            return !(left == right);
        }
    }
}
