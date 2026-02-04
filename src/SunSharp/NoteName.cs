namespace SunSharp
{
    /// <summary>
    /// Represents the name of a musical note within an octave.
    /// </summary>
    /// <remarks>
    /// Supports enharmonic equivalents with one accidental (sharp or flat).
    /// </remarks>
    public enum NoteName : sbyte
    {
        #region normal notes

        /// <summary>
        /// C note.
        /// Enharmonic equivalent of B♯ in the previous octave.
        /// </summary>
        C = 0,

        /// <summary>
        /// C♯ note.
        /// </summary>
        Cs = 1,

        /// <summary>
        /// D note.
        /// </summary>
        D = 2,

        /// <summary>
        /// D♯ note.
        /// Enharmonic equivalent of E♭.
        /// </summary>
        Ds = 3,

        /// <summary>
        /// E note.
        /// Enharmonic equivalent of F♭.
        /// </summary>
        E = 4,

        /// <summary>
        /// F note.
        /// </summary>
        F = 5,

        /// <summary>
        /// F♯ note.
        /// Enharmonic equivalent of G♭.
        /// </summary>
        Fs = 6,

        /// <summary>
        /// G note.
        /// </summary>
        G = 7,

        /// <summary>
        /// G♯ note.
        /// Enharmonic equivalent of A♭.
        /// </summary>
        Gs = 8,

        /// <summary>
        /// A note.
        /// </summary>
        A = 9,

        /// <summary>
        /// A♯ note.
        /// Enharmonic equivalent of B♭.
        /// </summary>
        As = 10,

        /// <summary>
        /// B note.
        /// Enharmonic equivalent of C♭ in the next octave.
        /// </summary>
        B = 11,

        #endregion normal notes

        #region additioanl enharmonic notes

        /// <summary>
        /// D♭ note (flat).
        /// Enharmonic equivalent of B in the previous octave.
        /// </summary>
        Cb = -1,

        /// <summary>
        /// D♭ note.
        /// Enharmonic equivalent of C♯.
        /// </summary>
        Db = Cs,

        /// <summary>
        /// E♭ note (flat).
        /// Enharmonic equivalent of D♯.
        /// </summary>
        Eb = Ds,

        /// <summary>
        /// E♯ note (natural).
        /// Enharmonic equivalent of F.
        /// </summary>
        Es = F,

        /// <summary>
        /// E♭ note (flat).
        /// Enharmonic equivalent of E.
        /// </summary>
        Fb = E,

        /// <summary>
        /// G♭ note.
        /// Enharmonic equivalent of F♯.
        /// </summary>
        Gb = Fs,

        /// <summary>
        /// A♭ note.
        /// Enharmonic equivalent of G♯.
        /// </summary>
        Ab = Gs,

        /// <summary>
        /// B♭ note.
        /// Enharmonic equivalent of A♯.
        /// </summary>
        Bb = As,

        /// <summary>
        /// B♯ note.
        /// Enharmonic equivalent of C in the next octave.
        /// </summary>
        Bs = 12,

        #endregion additioanl enharmonic notes

        /// <summary>
        /// Unspecified, unknown or otherwise invalid note name.
        /// </summary>
        Other = -128
    }

    /// <summary>
    /// Extension methods for the <see cref="NoteName"/> enum.
    /// </summary>
    public static class NoteNameExtensions
    {
        /// <summary>
        /// Returns the character representation of the specified note as displayed in SunVox.
        /// </summary>
        /// <remarks>
        /// Only valid for note names in the range of C to B, and defaults to '?' for others.
        /// In case of accidentals, returns the lowercase character for sharp notes.
        /// You are likely looking for <see cref="Note.ToString"/> for full note representation.
        /// </remarks>
        public static char GetNoteCharacterAsDisplayed(this NoteName noteName)
        {
            const string Mapping = "CcDdEFfGgAaB";
            var i = (int)noteName;
            if (i < 0 || i > 11) // check if greater than B or less than C
            {
                return '?';
            }
            return Mapping[(int)noteName];
        }

        /// <summary>
        /// Returns whether the specified note name is a valid note name.
        /// </summary>
        public static bool IsValidNoteName(this NoteName noteName)
        {
            return noteName >= NoteName.Cb && noteName <= NoteName.Bs;
        }
    }
}
