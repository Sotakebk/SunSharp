using System;
using System.Runtime.InteropServices;

namespace SunSharp.Native
{
    public partial class SunVoxLibNativeWrapper
    {
		/// <summary>
		/// Clone a pattern.
		/// </summary>
		/// <param name="slotId">Slot number (0 to 15).</param>
		/// <param name="originalPatternId">Pattern to clone.</param>
		/// <param name="x">Line number on which the pattern starts (horizontal).</param>
		/// <param name="y">Vertical position on the timeline.</param>
		/// <returns>The number of the newly created pattern.</returns>
		/// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
		/// <remarks>
		/// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
		/// Calls <see cref="ISunVoxLibC.sv_new_pattern"/>.
		/// </remarks>
		public int ClonePattern(int slotId, int originalPatternId, int x, int y)
        {
            var ret = _lib.sv_new_pattern(slotId, originalPatternId, x, y, -1, -1, -1, IntPtr.Zero);

            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(originalPatternId)}: {originalPatternId}, {nameof(x)}: {x}, {nameof(y)}: {y}.";
                throw new SunVoxException(ret, nameof(_lib.sv_new_pattern), details);
            }

            return ret;
        }

        /// <summary>
        /// Create a new pattern.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="x">Line number on which the pattern starts.</param>
        /// <param name="y">Y coordinate on timeline.</param>
        /// <param name="tracks">Number of tracks.</param>
        /// <param name="lines">Number of lines.</param>
        /// <param name="iconSeed">Icon seed for pattern appearance.</param>
        /// <param name="name">Pattern name.</param>
        /// <returns>The number of the newly created pattern.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_new_pattern"/>.
        /// </remarks>
        public int CreatePattern(int slotId, int x, int y, int tracks, int lines, int iconSeed = 0, string? name = null)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(name);
            int ret;
            try
            {
                ret = _lib.sv_new_pattern(slotId, -1, x, y, tracks, lines, iconSeed, ptr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(x)}: {x}, {nameof(y)}: {y}, {nameof(tracks)}: {tracks}, {nameof(lines)}: {lines}, {nameof(iconSeed)}: {iconSeed}, {nameof(name)}: '{name ?? "<null>"}'.";
                throw new SunVoxException(ret, nameof(_lib.sv_new_pattern), details);
            }

            return ret;
        }

        /// <summary>
        /// Find a pattern by name.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="name">Pattern name to search for.</param>
        /// <returns>Pattern number if found.</returns>
        /// <exception cref="SunVoxException">Thrown when an error occurs during the search.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_find_pattern"/>.</remarks>
        public int? FindPattern(int slotId, string name)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(name);
            int ret;
            try
            {
                ret = _lib.sv_find_pattern(slotId, ptr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret < -1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_find_pattern),
                    $"{nameof(slotId)}: {slotId}, {nameof(name)}: '{name ?? "<null>"}'.");
            }

            if (ret != -1)
            {
                return ret;
            }

            return null;
        }

        /// <summary>
        /// Get the pattern data (all events).
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <returns>Tuple containing event data array, number of tracks, and number of lines if pattern exists.</returns>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_get_pattern_data"/>.
        /// </remarks>
        public (PatternEvent[] data, int tracks, int lines)? GetPatternData(int slotId, int patternId)
        {
            var lines = GetPatternLines(slotId, patternId);
            if (lines <= 0)
            {
                return null;
            }

            var tracks = GetPatternTracks(slotId, patternId);

            // memory managed by SunVox
            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            var arr = new PatternEvent[lines * tracks];
            for (var i = 0; i < lines * tracks; i++)
            {
                arr[i] = (ulong)Marshal.ReadInt64(ptr, i * sizeof(ulong));
            }

            return (arr, tracks, lines);
        }

        /// <summary>
        /// Get a specific column value from a pattern event.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="track">Track number.</param>
        /// <param name="line">Line number.</param>
        /// <param name="column">Column to read.</param>
        /// <returns>Column value.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_pattern_event"/>.</remarks>
        public int GetPatternEventValue(int slotId, int patternId, int track, int line, Column column)
        {
            var ret = _lib.sv_get_pattern_event(slotId, patternId, track, line, (int)column);
            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}, {nameof(track)}: {track}, {nameof(line)}: {line}, {nameof(column)}: {column}.";
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_event), details);
            }

            return ret;
        }

        /// <summary>
        /// Check if a pattern exists.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <returns><see langword="true"/> if pattern exists; <see langword="false"/> otherwise.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_pattern_lines"/>.</remarks>
        public bool GetPatternExists(int slotId, int patternId)
        {
            return GetPatternLines(slotId, patternId) > 0;
        }

		/// <summary>
		/// Get the number of lines in the pattern.
		/// Can be used to check if a pattern exists (lines &gt; 0).
		/// </summary>
		/// <param name="slotId">Slot number (0 to 15).</param>
		/// <param name="patternId">Pattern number.</param>
		/// <returns>Number of lines.</returns>
		/// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
		/// <remarks>Calls <see cref="ISunVoxLibC.sv_get_pattern_lines"/>.</remarks>
		public int GetPatternLines(int slotId, int patternId)
        {
            var ret = _lib.sv_get_pattern_lines(slotId, patternId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_lines),
                    $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}.");
            }

            return ret;
        }

        /// <summary>
        /// Get the pattern mute state.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <returns><see langword="true"/> if pattern is muted; <see langword="false"/> otherwise.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_pattern_mute"/>.
        /// </remarks>
        public bool GetPatternMuted(int slotId, int patternId)
        {
            var ret = _lib.sv_pattern_mute(slotId, patternId, -1);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_pattern_mute),
                    $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}.");
            }

            return ret == 1;
        }

        /// <summary>
        /// Get the pattern name.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <returns>Pattern name, or <see langword="null"/> if unavailable.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_pattern_name"/>.</remarks>
        public string? GetPatternName(int slotId, int patternId)
        {
            var ptr = _lib.sv_get_pattern_name(slotId, patternId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <summary>
        /// Get the pattern position on the timeline.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <returns>Tuple containing X and Y coordinates.</returns>
        /// <remarks>
        /// Calls:
        /// <list type="bullet">
        /// <item><see cref="ISunVoxLibC.sv_get_pattern_x"/></item>
        /// <item><see cref="ISunVoxLibC.sv_get_pattern_y"/></item>
        /// </list>
        /// </remarks>
        public (int x, int y) GetPatternPosition(int slotId, int patternId)
        {
            var x = _lib.sv_get_pattern_x(slotId, patternId);
            var y = _lib.sv_get_pattern_y(slotId, patternId);
            return (x, y);
        }

        /// <summary>
        /// Get the number of tracks in the pattern.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <returns>Number of tracks.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_pattern_tracks"/>.</remarks>
        public int GetPatternTracks(int slotId, int patternId)
        {
            var ret = _lib.sv_get_pattern_tracks(slotId, patternId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_pattern_tracks),
                    $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}.");
            }

            return ret;
        }

        /// <summary>
        /// Get the pattern X coordinate on the timeline.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <returns>X coordinate.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_pattern_x"/>.</remarks>
        public int GetPatternX(int slotId, int patternId)
        {
            return _lib.sv_get_pattern_x(slotId, patternId);
        }

        /// <summary>
        /// Get the pattern Y coordinate on the timeline.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <returns>Y coordinate.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_pattern_y"/>.</remarks>
        public int GetPatternY(int slotId, int patternId)
        {
            return _lib.sv_get_pattern_y(slotId, patternId);
        }

        /// <summary>
        /// Get the upper limit of pattern count (one more than the highest pattern number).
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <returns>Upper limit of pattern count.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_number_of_patterns"/>.</remarks>
        public int GetUpperPatternCount(int slotId)
        {
            var ret = _lib.sv_get_number_of_patterns(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_number_of_patterns), $"{nameof(slotId)}: {slotId}.");
            }

            return ret;
        }

		/// <summary>
		/// Delete a pattern.
		/// </summary>
		/// <param name="slotId">Slot number (0 to 15).</param>
		/// <param name="patternId">Pattern number.</param>
		/// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
		/// <remarks>
		/// <para>
		/// Deleting the original pattern also deletes all its clones.
        /// </para>
		/// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
		/// Calls <see cref="ISunVoxLibC.sv_remove_pattern"/>.
		/// </remarks>
		public void RemovePattern(int slotId, int patternId)
        {
            var ret = _lib.sv_remove_pattern(slotId, patternId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_remove_pattern),
                    $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}.");
            }
        }

        /// <summary>
        /// Set the pattern data (all events).
        /// Resizes the pattern and sets all event data.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="data">Event data array (length must equal tracks * lines).</param>
        /// <param name="tracks">Number of tracks.</param>
        /// <param name="lines">Number of lines.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if tracks or lines are negative.</exception>
        /// <exception cref="ArgumentException">Thrown if data length doesn't match tracks * lines.</exception>
        /// <exception cref="SunVoxException">Thrown when the operation fails or pattern doesn't exist.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls:
        /// <list type="bullet">
        /// <item><see cref="ISunVoxLibC.sv_set_pattern_size"/></item>
        /// <item><see cref="ISunVoxLibC.sv_get_pattern_data"/></item>
        /// </list>
        /// </remarks>
        public void SetPatternData(int slotId, int patternId, PatternEvent[] data, int tracks, int lines)
        {
            if (tracks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tracks), tracks, "Value cannot be negative.");
            }

            if (lines < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lines), lines, "Value cannot be negative.");
            }

            if (tracks * lines != data.Length)
            {
                throw new ArgumentException(
                    $"Size of {nameof(data)} ({nameof(data)}.Length) is not equal to {nameof(tracks)} * {nameof(lines)} ({tracks * lines}).");
            }

            // should throw an exception if the pattern in question does not exist
            SetPatternSize(slotId, patternId, tracks, lines);

            // memory managed by SunVox
            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
            {
                throw new SunVoxException(0, $"{nameof(_lib.sv_get_pattern_data)} returned nullptr.");
            }

            for (var i = 0; i < lines * tracks; i++)
            {
                Marshal.WriteInt64(ptr, i * sizeof(long), unchecked((long)data[i].Data));
            }
        }

		/// <summary>
		/// Read a section or all of the pattern data into a buffer.
		/// </summary>
		/// <param name="slotId">Slot number (0 to 15).</param>
		/// <param name="patternId">Pattern number.</param>
		/// <param name="buffer">Buffer to receive pattern data.</param>
		/// <param name="bufferTracks">Width of the buffer.</param>
		/// <param name="bufferLines">Height of the buffer.</param>
		/// <param name="bufferOffsetTracks">Number of tracks in the buffer to skip.</param>
		/// <param name="bufferOffsetLines">Number of lines in the buffer to skip.</param>
		/// <param name="readOffsetTracks">Number of tracks in the pattern to skip.</param>
		/// <param name="readOffsetLines">Number of lines in the pattern to skip.</param>
		/// <param name="maxTracks">Maximum number of tracks to read.</param>
		/// <param name="maxLines">Maximum number of lines to read.</param>
		/// <returns>Number of events read.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if any offset or size parameter is negative.</exception>
		/// <exception cref="ArgumentException">Thrown if buffer length doesn't match bufferTracks * bufferLines.</exception>
		/// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
		/// <remarks>
		/// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
		/// Calls <see cref="ISunVoxLibC.sv_get_pattern_data"/>.
		/// </remarks>
		public int ReadPatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int readOffsetTracks = 0, int readOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null)
        {
            if (readOffsetLines < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(readOffsetLines), readOffsetLines, "Value cannot be negative.");
            }

            if (readOffsetTracks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(readOffsetTracks), readOffsetTracks, "Value cannot be negative.");
            }

            if (bufferOffsetLines < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferOffsetLines), bufferOffsetLines, "Value cannot be negative.");
            }

            if (bufferOffsetTracks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferOffsetTracks), bufferOffsetTracks, "Value cannot be negative.");
            }

            if (bufferTracks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferTracks), bufferTracks, "Value cannot be negative.");
            }

            if (bufferLines < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferLines), bufferLines, "Value cannot be negative.");
            }

            if (bufferLines * bufferTracks != buffer.Length)
            {
                throw new ArgumentException($"Size of {nameof(buffer)} ({nameof(buffer)}.Length) is not equal to {nameof(bufferTracks)} * {nameof(bufferLines)} ({bufferTracks * bufferLines}).");
            }

            var realLines = GetPatternLines(slotId, patternId);
            if (realLines == 0)
            {
                return 0;
            }

            var realTracks = GetPatternTracks(slotId, patternId);

            // memory managed by SunVox
            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
            {
                return 0;
            }

            var linesToIterate = Math.Min(bufferLines - bufferOffsetLines, realLines - readOffsetLines);
            linesToIterate = Math.Min(linesToIterate, maxLines ?? int.MaxValue);
            var tracksToIterate = Math.Min(bufferTracks - bufferOffsetTracks, realTracks - readOffsetTracks);
            tracksToIterate = Math.Min(tracksToIterate, maxTracks ?? int.MaxValue);

            var readEventCount = 0;
            for (var l = 0; l < linesToIterate; l++)
            {
                for (var t = 0; t < tracksToIterate; t++)
                {
                    var realIndex = ((l + readOffsetLines) * realTracks) + t + readOffsetTracks;
                    var bufferIndex = ((l + bufferOffsetLines) * bufferTracks) + t + bufferOffsetTracks;
                    var value = Marshal.ReadInt64(ptr, realIndex * sizeof(ulong));
                    buffer[bufferIndex] = unchecked((ulong)value);
                    readEventCount++;
                }
            }

            return readEventCount;
        }

        /// <summary>
        /// Write a section or all of a buffer into the pattern data.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="buffer">Buffer containing pattern data to write.</param>
        /// <param name="bufferTracks">Width of the buffer.</param>
        /// <param name="bufferLines">Height of the buffer.</param>
        /// <param name="bufferOffsetTracks">Number of tracks in the buffer to skip.</param>
        /// <param name="bufferOffsetLines">Number of lines in the buffer to skip.</param>
        /// <param name="writeOffsetTracks">Number of tracks in the pattern to skip.</param>
        /// <param name="writeOffsetLines">Number of lines in the pattern to skip.</param>
        /// <param name="maxTracks">Maximum number of tracks to write.</param>
        /// <param name="maxLines">Maximum number of lines to write.</param>
        /// <returns>Number of events written.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any offset or size parameter is negative.</exception>
        /// <exception cref="ArgumentException">Thrown if buffer length doesn't match bufferTracks * bufferLines.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_get_pattern_data"/>.
        /// </remarks>
        public int WritePatternData(int slotId, int patternId, PatternEvent[] buffer, int bufferTracks, int bufferLines,
            int bufferOffsetTracks = 0, int bufferOffsetLines = 0, int writeOffsetTracks = 0, int writeOffsetLines = 0,
            int? maxTracks = null, int? maxLines = null)
        {
            if (writeOffsetLines < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(writeOffsetLines), writeOffsetLines, "Value cannot be negative.");
            }

            if (writeOffsetTracks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(writeOffsetTracks), writeOffsetTracks, "Value cannot be negative.");
            }

            if (bufferOffsetLines < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferOffsetLines), bufferOffsetLines, "Value cannot be negative.");
            }

            if (bufferOffsetTracks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferOffsetTracks), bufferOffsetTracks, "Value cannot be negative.");
            }

            if (bufferTracks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferTracks), bufferTracks, "Value cannot be negative.");
            }

            if (bufferLines < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferLines), bufferLines, "Value cannot be negative.");
            }

            if (bufferLines * bufferTracks != buffer.Length)
            {
                throw new ArgumentException($"Size of {nameof(buffer)} ({buffer.Length}) is not equal to {nameof(bufferTracks)} * {nameof(bufferLines)} ({bufferTracks * bufferLines}).");
            }

            var realLines = GetPatternLines(slotId, patternId);
            if (realLines == 0)
            {
                return 0;
            }

            var realTracks = GetPatternTracks(slotId, patternId);

            // memory managed by SunVox
            var ptr = _lib.sv_get_pattern_data(slotId, patternId);
            if (ptr == IntPtr.Zero)
            {
                return 0;
            }

            var linesToIterate = Math.Min(bufferLines - bufferOffsetLines, realLines - writeOffsetLines);
            linesToIterate = Math.Min(linesToIterate, maxLines ?? int.MaxValue);
            var tracksToIterate = Math.Min(bufferTracks - bufferOffsetTracks, realTracks - writeOffsetTracks);
            tracksToIterate = Math.Min(tracksToIterate, maxTracks ?? int.MaxValue);

            var writeEventCount = 0;
            for (var l = 0; l < linesToIterate; l++)
            {
                for (var t = 0; t < tracksToIterate; t++)
                {
                    var realIndex = ((l + writeOffsetLines) * realTracks) + t + writeOffsetTracks;
                    var bufferIndex = ((l + bufferOffsetLines) * bufferTracks) + t + bufferOffsetTracks;
                    var value = buffer[bufferIndex].Data;
                    Marshal.WriteInt64(ptr, realIndex * sizeof(ulong), unchecked((long)value));
                    writeEventCount++;
                }
            }

            return writeEventCount;
        }

        /// <summary>
        /// Set a pattern event at a specific location.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="track">Track number.</param>
        /// <param name="line">Line number.</param>
        /// <param name="nn">Note: 0 - nothing; 1 to 127 - note; 128 - note off; 129+ - see NOTECMD_*.</param>
        /// <param name="vv">Velocity: 1 to 129; 0 - default.</param>
        /// <param name="mm">Module: 0 (empty) or module number + 1 (1 to 65535).</param>
        /// <param name="ccee">Controller/effect: 0xCCEE. CC - controller (1 to 255); EE - effect.</param>
        /// <param name="xxyy">Value: 0xXXYY. Controller value (0 to 32768) or effect parameter (0 to 65535).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_pattern_event"/>.</remarks>
        public void SetPatternEvent(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee,
            int xxyy)
        {
            var ret = _lib.sv_set_pattern_event(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}, {nameof(track)}: {track}, {nameof(line)}: {line}, {nameof(nn)}: {nn}, {nameof(vv)}: {vv}, {nameof(mm)}: {mm}, {nameof(ccee)}: {ccee}, {nameof(xxyy)}: {xxyy}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_event), details);
            }
        }

        /// <summary>
        /// Set a pattern event at a specific location.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="track">Track number.</param>
        /// <param name="line">Line number.</param>
        /// <param name="ev">Pattern event data.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_pattern_event"/>.</remarks>
        public void SetPatternEvent(int slotId, int patternId, int track, int line, PatternEvent ev)
        {
            var ret = _lib.sv_set_pattern_event(slotId, patternId, track, line, ev.NN, ev.VV, ev.MM, ev.CCEE, ev.XXYY);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}, {nameof(track)}: {track}, {nameof(line)}: {line}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_event), details);
            }
        }

        /// <summary>
        /// Set the pattern mute state.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="muted"><see langword="true"/> to mute; <see langword="false"/> to unmute.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_pattern_mute"/>.
        /// </remarks>
        public void SetPatternMuted(int slotId, int patternId, bool muted)
        {
            var ret = _lib.sv_pattern_mute(slotId, patternId, muted ? 1 : 0);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_pattern_mute),
                    $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}, {nameof(muted)}: {muted}.");
            }
        }

        /// <summary>
        /// Set the pattern name.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="name">New pattern name.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_set_pattern_name"/>.
        /// </remarks>
        public void SetPatternName(int slotId, int patternId, string name)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(name);
            try
            {
                var ret = _lib.sv_set_pattern_name(slotId, patternId, ptr);
                if (ret != 0)
                {
                    throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_name),
                        $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}, {nameof(name)}: '{name ?? "<null>"}'.");
                }
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }
        }

        /// <summary>
        /// Set the pattern position on the timeline.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="x">Line number on which the pattern starts.</param>
        /// <param name="y">Y coordinate on timeline.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_set_pattern_xy"/>.
        /// </remarks>
        public void SetPatternPosition(int slotId, int patternId, int x, int y)
        {
            var ret = _lib.sv_set_pattern_xy(slotId, patternId, x, y);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}, {nameof(x)}: {x}, {nameof(y)}: {y}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_xy), details);
            }
        }

        /// <summary>
        /// Set the pattern size (number of tracks and/or lines).
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="patternId">Pattern number.</param>
        /// <param name="tracks">Number of tracks (null to keep current).</param>
        /// <param name="lines">Number of lines (null to keep current).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_set_pattern_size"/>.
        /// </remarks>
        public void SetPatternSize(int slotId, int patternId, int? tracks = null, int? lines = null)
        {
            var ret = _lib.sv_set_pattern_size(slotId, patternId, tracks ?? -1, lines ?? -1);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_set_pattern_size),
                    $"{nameof(slotId)}: {slotId}, {nameof(patternId)}: {patternId}, {nameof(tracks)}: {tracks}, {nameof(lines)}: {lines}.");
            }
        }
    }
}
