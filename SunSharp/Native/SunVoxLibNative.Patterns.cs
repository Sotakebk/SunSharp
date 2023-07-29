using System;
using System.Runtime.InteropServices;

namespace SunSharp.Native
{
    public partial class SunVoxLibNative
    {
        /// <inheritdoc/>
        public int CreatePattern(int slotId, int? patternToCloneId, int x, int y, int tracks,
            int lines, int? iconSeed, string? name)
        {
            var ptr = Marshal.StringToHGlobalAnsi(name);
            int ret;
            try
            {
                ret = _lib.sv_new_pattern(slotId, patternToCloneId ?? -1, x, y, tracks, lines, iconSeed ?? 0, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_new_pattern));
            return ret;
        }

        /// <inheritdoc/>
        public void RemovePattern(int slotId, int patternId)
        {
            var ret = _lib.sv_remove_pattern(slotId, patternId);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_remove_pattern));
        }

        /// <inheritdoc/>
        public int GetUpperPatternCount(int slotId)
        {
            var ret = _lib.sv_get_number_of_patterns(slotId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_number_of_patterns));
            return ret;
        }

        /// <inheritdoc/>
        public int FindPattern(int slotId, string name)
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

            return ret;
        }

        /// <inheritdoc/>
        public int GetPatternEventValue(int slotId, int patternId, int track, int line,
            Column column)
        {
            var ret = _lib.sv_get_pattern_event(slotId, patternId, track, line, (int)column);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_event));
            return ret;
        }

        /// <inheritdoc/>
        public string? GetPatternName(int slotId, int patternId)
        {
            var ptr = _lib.sv_get_pattern_name(slotId, patternId);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public bool GetPatternExists(int slotId, int patternId)
        {
            return GetPatternLines(slotId, patternId) > 0;
        }

        /// <inheritdoc/>
        public int GetPatternLines(int slotId, int patternId)
        {
            var ret = _lib.sv_get_pattern_lines(slotId, patternId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_lines));
            return ret;
        }

        /// <inheritdoc/>
        public int GetPatternTracks(int slotId, int patternId)
        {
            var ret = _lib.sv_get_pattern_tracks(slotId, patternId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_tracks));
            return ret;
        }

        /// <inheritdoc/>
        public void SetPatternSize(int slotId, int patternId, int? tracks = null,
            int? lines = null)
        {
            var ret = _lib.sv_set_pattern_size(slotId, patternId, tracks ?? -1, lines ?? -1);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_size));
        }

        /// <inheritdoc/>
        public (int x, int y) GetPatternPosition(int slotId, int patternId)
        {
            return (_lib.sv_get_pattern_x(slotId, patternId), _lib.sv_get_pattern_y(slotId, patternId));
        }

        /// <inheritdoc/>
        public int GetPatternX(int slotId, int patternId)
        {
            return _lib.sv_get_pattern_x(slotId, patternId);
        }

        /// <inheritdoc/>
        public int GetPatternY(int slotId, int patternId)
        {
            return _lib.sv_get_pattern_y(slotId, patternId);
        }

        /// <inheritdoc/>
        public void SetPatternPosition(int slotId, int patternId, int x, int y)
        {
            var ret = _lib.sv_set_pattern_xy(slotId, patternId, x, y);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_xy));
        }

        /// <inheritdoc/>
        public PatternEvent[]? GetPatternData(int slotId, int patternId)
        {
            if (!GetPatternExists(slotId, patternId))
                return null;

            var lines = GetPatternLines(slotId, patternId);
            var tracks = GetPatternTracks(slotId, patternId);

            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
                return null;
            try
            {
                var arr = new PatternEvent[lines * tracks];
                for (var i = 0; i < lines * tracks; i++)
                    arr[i] = (ulong)Marshal.ReadInt64(ptr, i * sizeof(ulong));
                return arr;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <inheritdoc/>
        public void SetPatternData(int slotId, int patternId, PatternEvent[] data)
        {
            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
                throw new SunVoxException(ptr.ToInt32(), nameof(_lib.sv_get_pattern_data));

            var lines = GetPatternLines(slotId, patternId);
            var tracks = GetPatternTracks(slotId, patternId);

            var minSize = Math.Min(lines * tracks, data.Length);

            for (var i = 0; i < minSize; i++)
            {
                Marshal.WriteInt64(ptr + i * sizeof(ulong), unchecked((long)data[i].Data));
            }
        }

        /// <inheritdoc/>
        public bool SetPatternMute(int slotId, int patternId, bool muted)
        {
            var ret = _lib.sv_pattern_mute(slotId, patternId, muted ? 1 : 0);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_pattern_mute));
            return ret == 1;
        }

        /// <inheritdoc/>
        public void SetPatternEvent(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee, int xxyy)
        {
            var ret = _lib.sv_set_pattern_event(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_event));
        }

        /// <inheritdoc/>
        public void SetPatternEvent(int slotId, int patternId, int track, int line, PatternEvent ev)
        {
            var ret = _lib.sv_set_pattern_event(slotId, patternId, track, line, ev.NN, ev.VV, ev.MM, ev.CCEE, ev.XXYY);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_event));
        }
    }
}
