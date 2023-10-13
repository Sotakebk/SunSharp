using System;
using System.Runtime.InteropServices;

namespace SunSharp.Native
{
    public partial class SunVoxLibNativeWrapper
    {
        public int ClonePattern(int slotId, int originalPatternId, int x, int y)
        {
            var ret = _lib.sv_new_pattern(slotId, originalPatternId, x, y, -1, -1, -1, IntPtr.Zero);

            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_new_pattern));
            return ret;
        }

        public int CreatePattern(int slotId, int x, int y, int tracks, int lines, int iconSeed = 0, string? name = null)
        {
            var ptr = Marshal.StringToHGlobalAnsi(name);
            int ret;
            try
            {
                ret = _lib.sv_new_pattern(slotId, -1, x, y, tracks, lines, iconSeed, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_new_pattern));
            return ret;
        }

        /// <inheritdoc />
        public int? FindPattern(int slotId, string name)
        {
            var ptr = Marshal.StringToHGlobalAnsi(name);
            int ret;
            try
            {
                ret = _lib.sv_find_pattern(slotId, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret < -1)
                throw new SunVoxException(ret, nameof(_lib.sv_find_pattern));

            if (ret != -1)
                return ret;
            return null;
        }

        /// <inheritdoc />
        public (PatternEvent[] data, int tracks, int lines)? GetPatternData(int slotId, int patternId)
        {
            var lines = GetPatternLines(slotId, patternId);
            if (lines <= 0)
                return null;

            var tracks = GetPatternTracks(slotId, patternId);

            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
                return null;

            var arr = new PatternEvent[lines * tracks];
            for (var i = 0; i < lines * tracks; i++)
                arr[i] = (ulong)Marshal.ReadInt64(ptr, i * sizeof(ulong));
            return (arr, tracks, lines);
        }

        /// <inheritdoc />
        public int GetPatternEventValue(int slotId, int patternId, int track, int line, Column column)
        {
            var ret = _lib.sv_get_pattern_event(slotId, patternId, track, line, (int)column);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_event));
            return ret;
        }

        /// <inheritdoc />
        public bool GetPatternExists(int slotId, int patternId)
        {
            return GetPatternLines(slotId, patternId) > 0;
        }

        /// <inheritdoc />
        public int GetPatternLines(int slotId, int patternId)
        {
            var ret = _lib.sv_get_pattern_lines(slotId, patternId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_lines));
            return ret;
        }

        /// <inheritdoc />
        public bool GetPatternMuted(int slotId, int patternId)
        {
            var ret = _lib.sv_pattern_mute(slotId, patternId, -1);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_pattern_mute));
            return ret == 1;
        }

        /// <inheritdoc />
        public string? GetPatternName(int slotId, int patternId)
        {
            var ptr = _lib.sv_get_pattern_name(slotId, patternId);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <inheritdoc />
        public (int x, int y) GetPatternPosition(int slotId, int patternId)
        {
            return (_lib.sv_get_pattern_x(slotId, patternId), _lib.sv_get_pattern_y(slotId, patternId));
        }

        /// <inheritdoc />
        public int GetPatternTracks(int slotId, int patternId)
        {
            var ret = _lib.sv_get_pattern_tracks(slotId, patternId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_tracks));
            return ret;
        }

        /// <inheritdoc />
        public int GetPatternX(int slotId, int patternId)
        {
            return _lib.sv_get_pattern_x(slotId, patternId);
        }

        /// <inheritdoc />
        public int GetPatternY(int slotId, int patternId)
        {
            return _lib.sv_get_pattern_y(slotId, patternId);
        }

        /// <inheritdoc />
        public int GetUpperPatternCount(int slotId)
        {
            var ret = _lib.sv_get_number_of_patterns(slotId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_number_of_patterns));
            return ret;
        }

        /// <inheritdoc />
        public void RemovePattern(int slotId, int patternId)
        {
            var ret = _lib.sv_remove_pattern(slotId, patternId);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_remove_pattern));
        }

        /// <inheritdoc />
        public void SetPatternData(int slotId, int patternId, PatternEvent[] data, int tracks, int lines)
        {
            if (tracks < 0)
                throw new ArgumentOutOfRangeException(nameof(tracks), tracks, "Value cannot be negative.");
            if (lines < 0)
                throw new ArgumentOutOfRangeException(nameof(lines), lines, "Value cannot be negative.");

            if (tracks * lines != data.Length)
                throw new ArgumentException(
                    $"Size of {nameof(data)} ({nameof(data)}.Length)  is not equal to {nameof(tracks)} * {nameof(lines)} ({tracks * lines}).");

            SetPatternSize(slotId, patternId, tracks, lines);

            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
                return;

            for (var i = 0; i < lines * tracks; i++)
                Marshal.WriteInt64(ptr, i * sizeof(long), unchecked((long)data[i].Data));
        }

        /// <inheritdoc />
        public int ReadPatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int readOffsetTracks = 0, int readOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null)
        {
            if (readOffsetLines < 0)
                throw new ArgumentOutOfRangeException(nameof(readOffsetLines), readOffsetLines,
                    "Value cannot be negative.");
            if (readOffsetTracks < 0)
                throw new ArgumentOutOfRangeException(nameof(readOffsetTracks), readOffsetTracks,
                    "Value cannot be negative.");
            if (bufferOffsetLines < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferOffsetLines), bufferOffsetLines,
                    "Value cannot be negative.");
            if (bufferOffsetTracks < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferOffsetTracks), bufferOffsetTracks,
                    "Value cannot be negative.");
            if (bufferTracks < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferTracks), bufferTracks, "Value cannot be negative.");
            if (bufferLines < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferLines), bufferLines, "Value cannot be negative.");

            if (bufferLines * bufferTracks != buffer.Length)
                throw new ArgumentException(
                    $"Size of {nameof(buffer)} ({nameof(buffer)}.Length) is not equal to {nameof(bufferTracks)} * {nameof(bufferLines)} ({bufferTracks * bufferLines}).");

            var realLines = GetPatternLines(slotId, patternId);
            if (realLines == 0)
                return 0;
            var realTracks = GetPatternTracks(slotId, patternId);

            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
                return 0;

            var linesToIterate = Math.Min(bufferLines - bufferOffsetLines, realLines - readOffsetLines);
            linesToIterate = Math.Min(linesToIterate, maxLines ?? int.MaxValue);
            var tracksToIterate = Math.Min(bufferTracks - bufferOffsetTracks, realTracks - readOffsetTracks);
            tracksToIterate = Math.Min(tracksToIterate, maxTracks ?? int.MaxValue);

            var readEventCount = 0;
            for (var l = 0; l < linesToIterate; l++)
            for (var t = 0; t < tracksToIterate; t++)
            {
                var realIndex = (l + readOffsetLines) * realTracks + t + readOffsetTracks;
                var bufferIndex = (l + bufferOffsetLines) * bufferTracks + t + bufferOffsetTracks;
                var value = Marshal.ReadInt64(ptr, realIndex * sizeof(ulong));
                buffer[bufferIndex] = unchecked((ulong)value);
                readEventCount++;
            }

            return readEventCount;
        }

        /// <inheritdoc />
        public int WritePatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int writeOffsetTracks = 0, int writeOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null)
        {
            if (writeOffsetLines < 0)
                throw new ArgumentOutOfRangeException(nameof(writeOffsetLines), writeOffsetLines,
                    "Value cannot be negative.");
            if (writeOffsetTracks < 0)
                throw new ArgumentOutOfRangeException(nameof(writeOffsetTracks), writeOffsetTracks,
                    "Value cannot be negative.");
            if (bufferOffsetLines < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferOffsetLines), bufferOffsetLines,
                    "Value cannot be negative.");
            if (bufferOffsetTracks < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferOffsetTracks), bufferOffsetTracks,
                    "Value cannot be negative.");
            if (bufferTracks < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferTracks), bufferTracks, "Value cannot be negative.");
            if (bufferLines < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferLines), bufferLines, "Value cannot be negative.");

            if (bufferLines * bufferTracks != buffer.Length)
                throw new ArgumentException(
                    $"Size of {nameof(buffer)} ({buffer.Length}) is not equal to {nameof(bufferTracks)} * {nameof(bufferLines)} ({bufferTracks * bufferLines}).");

            var realLines = GetPatternLines(slotId, patternId);
            if (realLines == 0)
                return 0;
            var realTracks = GetPatternTracks(slotId, patternId);

            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
                return 0;

            var linesToIterate = Math.Min(bufferLines - bufferOffsetLines, realLines - writeOffsetLines);
            linesToIterate = Math.Min(linesToIterate, maxLines ?? int.MaxValue);
            var tracksToIterate = Math.Min(bufferTracks - bufferOffsetTracks, realTracks - writeOffsetTracks);
            tracksToIterate = Math.Min(tracksToIterate, maxTracks ?? int.MaxValue);

            var writeEventCount = 0;
            for (var l = 0; l < linesToIterate; l++)
            for (var t = 0; t < tracksToIterate; t++)
            {
                var realIndex = (l + writeOffsetLines) * realTracks + t + writeOffsetTracks;
                var bufferIndex = (l + bufferOffsetLines) * bufferTracks + t + bufferOffsetTracks;
                var value = buffer[bufferIndex].Data;
                Marshal.WriteInt64(ptr, realIndex * sizeof(ulong), unchecked((long)value));
                writeEventCount++;
            }

            return writeEventCount;
        }

        /// <inheritdoc />
        public void SetPatternEvent(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee,
            int xxyy)
        {
            var ret = _lib.sv_set_pattern_event(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_event));
        }

        /// <inheritdoc />
        public void SetPatternEvent(int slotId, int patternId, int track, int line, PatternEvent ev)
        {
            var ret = _lib.sv_set_pattern_event(slotId, patternId, track, line, ev.NN, ev.VV, ev.MM, ev.CCEE, ev.XXYY);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_event));
        }

        /// <inheritdoc />
        public void SetPatternMuted(int slotId, int patternId, bool muted)
        {
            var ret = _lib.sv_pattern_mute(slotId, patternId, muted ? 1 : 0);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_pattern_mute));
        }

        /// <inheritdoc />
        public void SetPatternName(int slotId, int patternId, string name)
        {
            var ptr = Marshal.StringToHGlobalAnsi(name);
            try
            {
                var ret = _lib.sv_set_pattern_name(slotId, patternId, ptr);
                if (ret != 0)
                    throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_name));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <inheritdoc />
        public void SetPatternPosition(int slotId, int patternId, int x, int y)
        {
            var ret = _lib.sv_set_pattern_xy(slotId, patternId, x, y);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_xy));
        }

        /// <inheritdoc />
        public void SetPatternSize(int slotId, int patternId, int? tracks = null, int? lines = null)
        {
            var ret = _lib.sv_set_pattern_size(slotId, patternId, tracks ?? -1, lines ?? -1);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_size));
        }
    }
}
