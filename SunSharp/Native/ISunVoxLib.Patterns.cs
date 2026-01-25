namespace SunSharp.Native
{
    public partial interface ISunVoxLib
    {
        /// <inheritdoc cref="SunVoxLibNativeWrapper.CreatePattern"/>
        int CreatePattern(int slotId, int x, int y, int tracks, int lines, int iconSeed = 0, string? name = null);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.ClonePattern"/>
        int ClonePattern(int slotId, int originalPatternId, int x, int y);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.RemovePattern"/>
        void RemovePattern(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetUpperPatternCount"/>
        int GetUpperPatternCount(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.FindPattern"/>
        int? FindPattern(int slotId, string name);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternEventValue"/>
        int GetPatternEventValue(int slotId, int patternId, int track, int line, Column column);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternName"/>
        string? GetPatternName(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetPatternName"/>
        void SetPatternName(int slotId, int patternId, string name);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternExists"/>
        bool GetPatternExists(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternLines"/>
        int GetPatternLines(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternTracks"/>
        int GetPatternTracks(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetPatternSize"/>
        void SetPatternSize(int slotId, int patternId, int? tracks = null, int? lines = null);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternPosition"/>
        (int x, int y) GetPatternPosition(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternX"/>
        int GetPatternX(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternY"/>
        int GetPatternY(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetPatternPosition"/>
        void SetPatternPosition(int slotId, int patternId, int x, int y);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternData"/>
        (PatternEvent[] data, int tracks, int lines)? GetPatternData(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetPatternData"/>
        void SetPatternData(int slotId, int patternId, PatternEvent[] data, int tracks, int lines);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.ReadPatternData"/>
        public int ReadPatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int readOffsetTracks = 0, int readOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.WritePatternData"/>
        public int WritePatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int writeOffsetTracks = 0, int writeOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetPatternMuted"/>
        void SetPatternMuted(int slotId, int patternId, bool muted);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetPatternMuted"/>
        bool GetPatternMuted(int slotId, int patternId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetPatternEvent(int, int, int, int, int, int, int, int, int)"/>
        void SetPatternEvent(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee,
            int xxyy);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetPatternEvent(int, int, int, int, PatternEvent)"/>
        void SetPatternEvent(int slotId, int patternId, int track, int line, PatternEvent ev);
    }
}

