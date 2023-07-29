namespace SunSharp
{
    public partial interface ISunVoxLib
    {
        /// <summary>
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        int CreatePattern(int slotId, int? patternToCloneId, int x, int y, int tracks, int lines, int? iconSeed, string? name);

        /// <summary>
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void RemovePattern(int slotId, int patternId);

        /// <summary>
        /// Get the upper pattern count, which may be greater than the actual pattern count.
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        int GetUpperPatternCount(int slotId);

        /// <summary>
        /// Find pattern by name.
        /// </summary>
        /// <returns>Pattern Id, or -1 if pattern was not found.</returns>
        /// <exception cref="SunVoxException"></exception>
        int FindPattern(int slotId, string name);

        int GetPatternEventValue(int slotId, int patternId, int track, int line, Column column);

        string? GetPatternName(int slotId, int patternId);

        /// <summary>
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void SetPatternName(int slotId, int patternId, string name);

        bool GetPatternExists(int slotId, int patternId);

        int GetPatternLines(int slotId, int patternId);

        int GetPatternTracks(int slotId, int patternId);

        /// <summary>
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        void SetPatternSize(int slotId, int patternId, int? tracks = null,
            int? lines = null);

        (int x, int y) GetPatternPosition(int slotId, int patternId);

        int GetPatternX(int slotId, int patternId);

        int GetPatternY(int slotId, int patternId);

        /// <summary>
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void SetPatternPosition(int slotId, int patternId, int x, int y);

        /// <summary>
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        PatternEvent[]? GetPatternData(int slotId, int patternId);

        /// <summary>
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void SetPatternData(int slotId, int patternId, PatternEvent[] data);

        /// <summary>
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        bool SetPatternMute(int slotId, int patternId, bool muted);

        void SetPatternEvent(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee, int xxyy);

        void SetPatternEvent(int slotId, int patternId, int track, int line, PatternEvent ev);
    }
}
