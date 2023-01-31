using System.Runtime.InteropServices;

namespace SunSharp.ThinWrapper
{
    public enum NoteName
    {
        C = 0,
        CS = 1,
        D = 2,
        DS = 3,
        E = 4,
        F = 5,
        FS = 6,
        G = 7,
        GS = 8,
        A = 9,
        AS = 10,
        B = 11,
        Other = 12
    }

    public static class NoteNameExtensions
    {
        public static char GetNoteNameCharacter(this NoteName noteName)
        {
            var i = (int)noteName;
            if (i < 0 || i > 11)
                return '?';
            return "CcDdEFfGgAaB"[i];
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public readonly struct Note
    {
        [FieldOffset(0)]
        public readonly byte Value;

        private const byte NOTECMD_NOTE_OFF = 128;
        private const byte NOTECMD_ALL_NOTES_OFF = 129;
        private const byte NOTECMD_CLEAN_SYNTHS = 130;
        private const byte NOTECMD_STOP = 131;
        private const byte NOTECMD_PLAY = 132;
        private const byte NOTECMD_SET_PITCH = 133;

        public static Note Silence => new Note(0);
        public static Note Off => new Note(NOTECMD_NOTE_OFF);
        public static Note AllNotesOff => new Note(NOTECMD_ALL_NOTES_OFF);
        public static Note CleanSynths => new Note(NOTECMD_CLEAN_SYNTHS);
        public static Note Stop => new Note(NOTECMD_STOP);
        public static Note Play => new Note(NOTECMD_PLAY);
        public static Note SetPitch => new Note(NOTECMD_SET_PITCH);

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
            switch (Value)
            {
                case 0: return "__";
                case NOTECMD_NOTE_OFF: return "--";
                case NOTECMD_ALL_NOTES_OFF: return "-!";
                case NOTECMD_CLEAN_SYNTHS: return "C!";
                case NOTECMD_STOP: return "S!";
                case NOTECMD_PLAY: return "P!";
                case NOTECMD_SET_PITCH: return "SP";
                default: return Value < 128 ? $"{Name.GetNoteNameCharacter()}{Octave}".Substring(0, 2) : "??";
            }
        }
    }
}
