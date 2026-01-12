using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    public enum NoteName
    {
        C = 0,
        Cs = 1,
        D = 2,
        Ds = 3,
        E = 4,
        F = 5,
        Fs = 6,
        G = 7,
        Gs = 8,
        A = 9,
        As = 10,
        B = 11,
        Other = 12
    }

    public static class NoteNameExtensions
    {
        public static char GetNoteCharacter(this NoteName noteName)
        {
            const string notes = "CcDdEFfGgAaB";
            var i = (int)noteName;
            if (i < 0 || i > 11)
            {
                return '?';
            }
            return notes[i];
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public readonly struct Note : IEquatable<Note>
    {
        [FieldOffset(0)] public readonly byte Value;

        private const byte NOTECMD_NOTE_OFF = 128;
        private const byte NOTECMD_ALL_NOTES_OFF = 129;
        private const byte NOTECMD_CLEAN_SYNTHS = 130;
        private const byte NOTECMD_STOP = 131;
        private const byte NOTECMD_PLAY = 132;
        private const byte NOTECMD_SET_PITCH = 133;
        private const byte NOTECMD_CLEAN_MODULE = 140;

        public static Note Silence => new Note(0);

        /// <summary>
        /// Stops the note playing on its track.
        /// </summary>
        public static Note Off => new Note(NOTECMD_NOTE_OFF);

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
        /// Sets the pitch specified in column XXYY, where 0x0000 - highest possible pitch, 0x7800 - lowest pitch (note C0);
        /// one semitone = 0x100.
        /// </summary>
        public static Note SetPitch => NOTECMD_SET_PITCH;

        /// <summary>
        /// Stops the module: clear its internal buffers and put it into standby mode.
        /// </summary>
        public static Note CleanModule => NOTECMD_CLEAN_MODULE;

        /// <summary>
        /// Get the name of the note. Returns valid values for notes in range C0 to F#10 inclusive.
        /// Returns <see cref="NoteName.Other" /> otherwise.
        /// </summary>
        public NoteName Name
        {
            get
            {
                if (IsNormal)
                {
                    return (NoteName)((Value - 1) % 12);
                }

                return NoteName.Other;
            }
        }

        /// <summary>
        /// Get the name of the note. Returns valid values for notes in range C0 to F#10 inclusive.
        /// Returns <see langword="-1" /> otherwise.
        /// </summary>
        public int Octave
        {
            get
            {
                if (IsNormal) return (Value - 1) / 12;

                return -1;
            }
        }

        /// <inheritdoc cref="Off" />
        public bool IsNoteOff => Value == NOTECMD_NOTE_OFF;

        /// <inheritdoc cref="AllNotesOff" />
        public bool IsAllNotesOff => Value == NOTECMD_ALL_NOTES_OFF;

        /// <inheritdoc cref="CleanSynths" />
        public bool IsCleanSynths => Value == NOTECMD_CLEAN_SYNTHS;

        /// <inheritdoc cref="CleanModule" />
        public bool IsCleanModule => Value == NOTECMD_CLEAN_MODULE;

        /// <inheritdoc cref="Stop" />
        public bool IsStop => Value == NOTECMD_STOP;

        /// <inheritdoc cref="Play" />
        public bool IsPlay => Value == NOTECMD_PLAY;

        /// <inheritdoc cref="SetPitch" />
        public bool IsSetPitch => Value == NOTECMD_SET_PITCH;

        /// <inheritdoc cref="Silence" />
        public bool IsSilence => Value == 0;

        /// <summary>
        /// Whether this is a normal note.
        /// </summary>
        public bool IsNormal => Value > 0 && Value < 128;

        public Note(byte value)
        {
            Value = value;
        }

        /// <summary>
        /// Construct a note in range of C0 to F#10 inclusive.
        /// </summary>
        /// <param name="name">The note value.</param>
        /// <param name="octave"></param>
        public Note(NoteName name, int octave)
        {
            if (name < NoteName.C || name > NoteName.B)
            {
                throw new ArgumentException($"Unsupported note '{name}'.");
            }

            if (octave < 0 || octave > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(octave), octave, "Only values in range of 0 to 10 are supported.");
            }

            if (octave == 10 && name > NoteName.Fs)
            {
                throw new ArgumentOutOfRangeException(nameof(name), name, "In the tenth octave, only notes up to F# are supported.");
            }

            Value = unchecked((byte)(1 + name + octave * 12));
        }

        public static implicit operator Note(byte value)
        {
            return new Note(value);
        }

        public static implicit operator byte(Note note)
        {
            return note.Value;
        }

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
                _ => Value < 128 ? $"{Name.GetNoteCharacter()}{Octave}" : "??"
            };
        }

        public bool Equals(Note other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                Note other => Equals(other),
                _ => false
            };
        }

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
