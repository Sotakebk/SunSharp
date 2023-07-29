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
        public static char GetNoteNameCharacter(this NoteName noteName)
        {
            const string notes = "CcDdEFfGgAaB";
            var i = (int)noteName;
            if (i < 0 || i > 11)
                return '?';
            return notes[i];
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public readonly struct Note
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
        public static Note Off => new Note(NOTECMD_NOTE_OFF);

        /// <summary>
        /// Send "note off" to all modules.
        /// </summary>
        public static Note AllNotesOff => NOTECMD_ALL_NOTES_OFF;

        /// <summary>
        /// StopPlayback all modules, clear their internal buffers and put them into standby mode.
        /// </summary>
        public static Note CleanSynths => NOTECMD_CLEAN_SYNTHS;

        /// <summary>
        /// StopPlayback playing the project.
        /// </summary>
        public static Note Stop => NOTECMD_STOP;

        /// <summary>
        /// Start playing the project.
        /// </summary>
        public static Note Play => NOTECMD_PLAY;

        /// <summary>
        /// Set the pitch specified in column XXYY, where 0x0000 - highest possible pitch, 0x7800 - lowest pitch (note C0); one semitone = 0x100.
        /// </summary>
        public static Note SetPitch => NOTECMD_SET_PITCH;

        /// <summary>
        /// StopPlayback the module: clear its internal buffers and put it into standby mode.one semitone = 0x100.
        /// </summary>
        public static Note CleanModule => NOTECMD_CLEAN_MODULE;

        public NoteName Name => Value > 0 || Value < 128 ? (NoteName)((Value - 1) % 12) : NoteName.Other;
        public int Octave => Value > 0 || Value < 128 ? (Value - 1) / 12 : 0;
        public bool IsNoteOff => Value == NOTECMD_NOTE_OFF;
        public bool IsAllNotesOff => Value == NOTECMD_ALL_NOTES_OFF;
        public bool IsNoteCleanSynths => Value == NOTECMD_CLEAN_SYNTHS;
        public bool IsNoteStop => Value == NOTECMD_STOP;
        public bool IsNotePlay => Value == NOTECMD_PLAY;
        public bool IsNoteSetPitch => Value == NOTECMD_SET_PITCH;

        public Note(byte value)
        {
            Value = value;
        }

        public Note(NoteName name, int octave)
        {
            Value = (byte)(1 + name + octave * 12);
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
                0 => "__",
                NOTECMD_NOTE_OFF => "--",
                NOTECMD_ALL_NOTES_OFF => "-!",
                NOTECMD_CLEAN_SYNTHS => "C!",
                NOTECMD_STOP => "S!",
                NOTECMD_PLAY => "P!",
                NOTECMD_SET_PITCH => "SP",
                _ => Value < 128 ? $"{Name.GetNoteNameCharacter()}{Octave}" : "??",
            };
        }
    }
}
