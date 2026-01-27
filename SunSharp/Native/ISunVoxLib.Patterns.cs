namespace SunSharp.Native
{
    public partial interface ISunVoxLib
    {
        /// <inheritdoc cref="SunVoxLib.CreatePattern"/>
        int CreatePattern(int slotId, int x, int y, int tracks, int lines, int iconSeed = 0, string? name = null);

        /// <inheritdoc cref="SunVoxLib.ClonePattern"/>
        int ClonePattern(int slotId, int originalPatternId, int x, int y);

        /// <inheritdoc cref="SunVoxLib.RemovePattern"/>
        void RemovePattern(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.GetUpperPatternCount"/>
        int GetUpperPatternCount(int slotId);

        /// <inheritdoc cref="SunVoxLib.FindPattern"/>
        int? FindPattern(int slotId, string name);

        /// <inheritdoc cref="SunVoxLib.GetPatternEventValue"/>
        int GetPatternEventValue(int slotId, int patternId, int track, int line, Column column);

        /// <inheritdoc cref="SunVoxLib.GetPatternName"/>
        string? GetPatternName(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.SetPatternName"/>
        void SetPatternName(int slotId, int patternId, string name);

        /// <inheritdoc cref="SunVoxLib.GetPatternExists"/>
        bool GetPatternExists(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.GetPatternLines"/>
        int GetPatternLines(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.GetPatternTracks"/>
        int GetPatternTracks(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.SetPatternSize"/>
        void SetPatternSize(int slotId, int patternId, int? tracks = null, int? lines = null);

        /// <inheritdoc cref="SunVoxLib.GetPatternPosition"/>
        (int x, int y) GetPatternPosition(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.GetPatternX"/>
        int GetPatternX(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.GetPatternY"/>
        int GetPatternY(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.SetPatternPosition"/>
        void SetPatternPosition(int slotId, int patternId, int x, int y);

        /// <inheritdoc cref="SunVoxLib.GetPatternData"/>
        (PatternEvent[] data, int tracks, int lines)? GetPatternData(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.SetPatternData"/>
        void SetPatternData(int slotId, int patternId, PatternEvent[] data, int tracks, int lines);

        /// <inheritdoc cref="SunVoxLib.ReadPatternData"/>
        public int ReadPatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int readOffsetTracks = 0, int readOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null);

        /// <inheritdoc cref="SunVoxLib.WritePatternData"/>
        public int WritePatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int writeOffsetTracks = 0, int writeOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null);

        /// <inheritdoc cref="SunVoxLib.SetPatternMuted"/>
        void SetPatternMuted(int slotId, int patternId, bool muted);

        /// <inheritdoc cref="SunVoxLib.GetPatternMuted"/>
        bool GetPatternMuted(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLib.SetPatternEvent(int, int, int, int, int, int, int, int, int)"/>
        void SetPatternEvent(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee,
            int xxyy);

        /// <inheritdoc cref="SunVoxLib.SetPatternEvent(int, int, int, int, PatternEvent)"/>
        void SetPatternEvent(int slotId, int patternId, int track, int line, PatternEvent ev);
    }
}

