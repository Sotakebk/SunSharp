namespace SunSharp.Native
{
    public partial interface ISunVoxLib
    {
        /// <summary>
        /// Create a new pattern. <br />
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        int CreatePattern(int slotId, int x, int y, int tracks, int lines, int iconSeed = 0, string? name = null);

        /// <summary>
        /// Clone a pattern. <br />
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        int ClonePattern(int slotId, int originalPatternId, int x, int y);

        /// <summary>
        /// Delete a pattern. <br />
        /// Deleting the original pattern also deletes all clones. <br />
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        void RemovePattern(int slotId, int patternId);

        /// <summary>
        /// Get the upper pattern count, which may be greater than the actual pattern count.
        /// </summary>
        int GetUpperPatternCount(int slotId);

        /// <summary>
        /// Find pattern by name.
        /// </summary>
        /// <returns>Pattern identifier, or <see langword="null" /> if pattern was not found.</returns>
        int? FindPattern(int slotId, string name);

        int GetPatternEventValue(int slotId, int patternId, int track, int line, Column column);

        string? GetPatternName(int slotId, int patternId);

        /// <summary>
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        void SetPatternName(int slotId, int patternId, string name);

        bool GetPatternExists(int slotId, int patternId);

        int GetPatternLines(int slotId, int patternId);

        int GetPatternTracks(int slotId, int patternId);

        /// <summary>
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        void SetPatternSize(int slotId, int patternId, int? tracks = null, int? lines = null);

        (int x, int y) GetPatternPosition(int slotId, int patternId);

        int GetPatternX(int slotId, int patternId);

        int GetPatternY(int slotId, int patternId);

        /// <summary>
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        void SetPatternPosition(int slotId, int patternId, int x, int y);

        /// <summary>
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        (PatternEvent[] data, int tracks, int lines)? GetPatternData(int slotId, int patternId);

        /// <summary>
        /// Resizes the pattern and sets the pattern event data. Throws an exception if the pattern does not exist.
        /// <br />
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        void SetPatternData(int slotId, int patternId, PatternEvent[] data, int tracks, int lines);

        /// <summary>
        /// Allows to read a section or all pattern data into a buffer.
        /// <br />
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="patternId"></param>
        /// <param name="buffer"></param>
        /// <param name="bufferTracks">Width of the buffer.</param>
        /// <param name="bufferLines">Height of the buffer.</param>
        /// <param name="bufferOffsetTracks">Count of tracks in the buffer to be skipped.</param>
        /// <param name="bufferOffsetLines">Count of lines in the buffer to be skipped.</param>
        /// <param name="readOffsetTracks">Count of tracks in the pattern to be skipped.</param>
        /// <param name="readOffsetLines">Count of lines in the pattern to be skipped.</param>
        /// <param name="maxTracks">Upper limit of tracks to be read.</param>
        /// <param name="maxLines">Upper limit of lines to be read.</param>
        /// <returns>Number of read events.</returns>
        public int ReadPatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int readOffsetTracks = 0, int readOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null);

        /// <summary>
        /// Allows to write a section or all of a buffer into pattern data.
        /// <br />
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="patternId"></param>
        /// <param name="buffer"></param>
        /// <param name="bufferTracks">Width of the buffer.</param>
        /// <param name="bufferLines">Height of the buffer.</param>
        /// <param name="bufferOffsetTracks">Count of tracks in the buffer to be skipped.</param>
        /// <param name="bufferOffsetLines">Count of lines in the buffer to be skipped.</param>
        /// <param name="writeOffsetTracks">Count of tracks in the pattern to be skipped.</param>
        /// <param name="writeOffsetLines">Count of lines in the pattern to be skipped.</param>
        /// <param name="maxTracks">Upper limit of tracks to be written.</param>
        /// <param name="maxLines">Upper limit of lines to be written.</param>
        /// <returns>Number of written events.</returns>
        public int WritePatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int writeOffsetTracks = 0, int writeOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null);

        /// <summary>
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        void SetPatternMuted(int slotId, int patternId, bool muted);

        /// <summary>
        /// Use <see cref="ISunVoxLib.LockSlot" /> or an alternative!
        /// </summary>
        bool GetPatternMuted(int slotId, int patternId);

        void SetPatternEvent(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee,
            int xxyy);

        void SetPatternEvent(int slotId, int patternId, int track, int line, PatternEvent ev);
    }
}
