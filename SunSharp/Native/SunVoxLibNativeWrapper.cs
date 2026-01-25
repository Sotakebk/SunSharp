using System;
using System.Runtime.InteropServices;

namespace SunSharp.Native
{
    public sealed partial class SunVoxLibNativeWrapper : ISunVoxLib
    {
        private readonly ISunVoxLibC _lib;

        public SunVoxLibNativeWrapper(ISunVoxLibC nativeLibrary)
        {
            _lib = nativeLibrary;
        }

        /// <summary>
        /// Get the next piece of audio from the Output module.
        /// </summary>
        /// <param name="outputBuffer">Output buffer to write audio data to.</param>
        /// <param name="channels">Number of channels the library was initialized with.</param>
        /// <param name="latency">Audio latency in frames.</param>
        /// <param name="outTime">Buffer output time in system ticks. See <see cref="GetTicks"/>.</param>
        /// <returns>
        /// <see langword="true"/> if buffer contains any non-0 samples.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when buffer size is invalid for the channel count.</exception>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>
        /// <see cref="SunVoxInitOptions.UserAudioCallback"/> must be set in <see cref="Initialize"/> to use this function.
        /// </para>
        /// <para>
        /// Make sure to call the correct overload for the buffer data type.
        /// </para>
        /// Calls <see cref="ISunVoxLibC.sv_audio_callback"/>.
        /// </remarks>
        public bool AudioCallback(float[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, channels, latency, outTime);
        }

        /// <inheritdoc cref="AudioCallback(float[], AudioChannels, int, uint)"/>
        public bool AudioCallback(short[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, channels, latency, outTime);
        }

        /// <summary>
        /// Send audio to the Input module and get the next piece of audio from the Output module.
        /// </summary>
        /// <param name="outputBuffer">Output buffer to write audio data to.</param>
        /// <param name="outputChannels">Number of channels the library was initialized with.</param>
        /// <param name="inputBuffer">Input buffer. Stereo data must be interleaved.</param>
        /// <param name="inputChannels">Number of input channels.</param>
        /// <param name="latency">Audio latency in frames.</param>
        /// <param name="outTime">Buffer output time in system ticks. See <see cref="GetTicks"/>.</param>
        /// <returns>
        /// <see langword="true"/> if buffer contains any non-0 samples.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="SunVoxInitOptions.UserAudioCallback"/> must be set in <see cref="Initialize"/> to use this function.
        /// </para>
        /// Calls <see cref="ISunVoxLibC.sv_audio_callback2"/>.
        /// </remarks>
        public bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels, float[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 1);
        }

        /// <inheritdoc cref="AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        public bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 0);
        }

        /// <inheritdoc cref="AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        public bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels, float[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 1);
        }

        /// <inheritdoc cref="AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        public bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels, short[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 0);
        }

        /// <summary>
        /// Close the slot and free its resources.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_close_slot"/>.</remarks>
        public void CloseSlot(int slotId)
        {
            var ret = _lib.sv_close_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_close_slot), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Deinitialize the SunVox engine and free all resources.
        /// May be safely called multiple times.
        /// </summary>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_deinit"/>.</remarks>
        public void Deinitialize()
        {
            var retCode = _lib.sv_deinit();
            if (retCode != 0)
            {
                throw new SunVoxException(retCode, nameof(_lib.sv_deinit));
            }
        }

        /// <summary>
        /// Get the autostop mode. When <see langword="false"/>, the project loops endlessly.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <returns>
        /// <see langword="true"/> if automatic stop is enabled.
        /// </returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_autostop"/>.</remarks>
        public bool GetAutomaticStop(int slotId)
        {
            var ret = _lib.sv_get_autostop(slotId);
            if (ret != 0 && ret != 1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_autostop), $"{nameof(slotId)}: {slotId}.");
            }
            return ret == 1;
        }

        /// <summary>
        /// Get the current line number on the timeline.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <returns>Current line number (playback position).</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_current_line"/>.</remarks>
        public int GetCurrentLine(int slotId)
        {
            return _lib.sv_get_current_line(slotId);
        }

        /// <summary>
        /// Get the current line number in fixed point format.
        /// The value contains the tenth part of the line for higher precision.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <returns>Current line number in fixed point format.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_current_line2"/>.</remarks>
        public int GetCurrentLineWithTenthPart(int slotId)
        {
            return _lib.sv_get_current_line2(slotId);
        }

        /// <summary>
        /// Get the current signal level from the Output module.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="channel">Audio channel.</param>
        /// <returns>Signal level (0 to 255).</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_current_signal_level"/>.</remarks>
        public int GetCurrentSignalLevel(int slotId, AudioChannel channel)
        {
            var ret = _lib.sv_get_current_signal_level(slotId, (int)channel);

            if (ret < 0 || ret > 255)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_current_signal_level), $"{nameof(slotId)}: {slotId}, {nameof(channel)}: {channel}.");
            }

            return ret;
        }

        /// <summary>
        /// Get the latest log messages from the SunVox engine.
        /// </summary>
        /// <param name="size">Maximum number of characters to read.</param>
        /// <returns>Log messages, or <see langword="null"/> if unavailable.</returns>
        /// <remarks>
        /// <para>
        /// Log messages are typically written when a call to another function fails.
        /// </para>
        /// Calls <see cref="ISunVoxLibC.sv_get_log"/>.</remarks>
        public string? GetLog(int size)
        {
            // memory managed by SunVox, should not be freed
            var ptr = _lib.sv_get_log(size);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <summary>
        /// Get the current sampling rate (may differ from the value specified in <see cref="Initialize"/>).
        /// </summary>
        /// <returns>Current sample rate in Hz.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_sample_rate"/>.</remarks>
        public int GetSampleRate()
        {
            var ret = _lib.sv_get_sample_rate();
            if (ret < 1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_sample_rate));
            }

            return ret;
        }

        /// <summary>
        /// Get the SunVox version used to create this project.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <returns>SunVox version used to create the project.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_base_version"/>.</remarks>
        public SunVoxVersion GetSongBaseVersion(int slotId)
        {
            var ret = _lib.sv_get_base_version(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_base_version), $"{nameof(slotId)}: {slotId}.");
            }
            return SunVoxVersion.FromProjectBaseVersion(ret);
        }

        /// <summary>
        /// Get the project BPM (Beats Per Minute).
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_song_bpm"/>.</remarks>
        /// <seealso cref="GetSongTpl(int)"/>
        public int GetSongBpm(int slotId)
        {
            var ret = _lib.sv_get_song_bpm(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_song_bpm), $"{nameof(slotId)}: {slotId}.");
            }

            return ret;
        }

        /// <summary>
        /// Get the project length in frames.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <remarks>
        /// <para>
        /// A frame is a pair of samples for stereo audio, or a single sample for mono audio.
        /// </para>
        /// Calls <see cref="ISunVoxLibC.sv_get_song_length_frames"/>.
        /// </remarks>
        public uint GetSongLengthInFrames(int slotId)
        {
            return _lib.sv_get_song_length_frames(slotId);
        }

        /// <summary>
        /// Get the project length in lines.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_song_length_lines"/>.</remarks>
        public uint GetSongLengthInLines(int slotId)
        {
            return _lib.sv_get_song_length_lines(slotId);
        }

        /// <summary>
        /// Get the project name.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <returns>Project name, or <see langword="null"/> if unavailable.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_song_name"/>.</remarks>
        public string? GetSongName(int slotId)
        {
            // memory managed by SunVox
            var ptr = _lib.sv_get_song_name(slotId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <summary>
        /// Get the project TPL (Ticks Per Line).
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_song_tpl"/>.</remarks>
        public int GetSongTpl(int slotId)
        {
            var ret = _lib.sv_get_song_tpl(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_song_tpl), $"{nameof(slotId)}: {slotId}.");
            }

            return ret;
        }

        /// <summary>
        /// Get the current system tick counter.
        /// </summary>
        /// <remarks>
        /// <para>
        /// SunVox engine uses system-provided time space, measured in system ticks (don't confuse it with the project ticks). System ticks are used for timing in functions like <see cref="AudioCallback"/> and <see cref="SetSendEventTimestamp"/>.
        /// </para>
        /// Calls <see cref="ISunVoxLibC.sv_get_ticks"/>.</remarks>
        public uint GetTicks()
        {
            return _lib.sv_get_ticks();
        }

        /// <summary>
        /// Get the number of system ticks per second.
        /// </summary>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_ticks_per_second"/>.</remarks>
        public uint GetTicksPerSecond()
        {
            return _lib.sv_get_ticks_per_second();
        }

        /// <summary>
        /// Get the project time map.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="startLine">First line to read (usually 0).</param>
        /// <param name="length">Number of lines to read.</param>
        /// <param name="type">
        /// <see cref="TimeMapType.Speed"/>: array[X] = BPM | (TPL &lt;&lt; 16);
        /// <see cref="TimeMapType.FrameCount"/>: array[X] = frame counter.
        /// </param>
        /// <returns>Array with time map values.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_time_map"/>.</remarks>
        public uint[] GetTimeMap(int slotId, int startLine, int length, TimeMapType type)
        {
            var arr = new uint[length];
            var handle = GCHandle.Alloc(arr, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_get_time_map(slotId, startLine, length, handle.AddrOfPinnedObject(), (int)type);
            }
            finally
            {
                handle.Free();
            }

            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(startLine)}: {startLine}, {nameof(length)}: {length}, {nameof(type)}: {type}.";
                throw new SunVoxException(ret, nameof(_lib.sv_get_time_map), details);
            }

            return arr;
        }

        /// <summary>
        /// Initialize the SunVox engine. May be called again to re-initialize.
        /// </summary>
        /// <param name="sampleRate">
        /// Desired sample rate (Hz); minimum 44100. The actual rate may differ if offline mode is not set.
        /// </param>
        /// <param name="config">
        /// Configuration string in pipe-separated format (e.g., "param1=value1|param2=value2").
        /// Use <see langword="null"/> for automatic configuration.
        /// </param>
        /// <param name="channels">Number of audio channels.</param>
        /// <param name="options">Initialization flags.</param>
        /// <exception cref="SunVoxException">Thrown when initialization fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_init"/>.</remarks>
        public SunVoxVersion Initialize(int sampleRate, string? config = null,
            AudioChannels channels = AudioChannels.Stereo, SunVoxInitOptions options = SunVoxInitOptions.None)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(config);
            try
            {
                var ret = _lib.sv_init(ptr, sampleRate, (int)channels, (uint)options);
                if (ret < 0)
                {
                    var details = $"{nameof(sampleRate)}: {sampleRate}, {nameof(channels)}: {channels}, {nameof(options)}: {options}.";
                    throw new SunVoxException(ret, nameof(_lib.sv_init), details);
                }

                return SunVoxVersion.FromLibraryVersion(ret);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }
        }

        /// <summary>
        /// Check if the project is currently playing.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_end_of_song"/>.</remarks>
        public bool IsPlaying(int slotId)
        {
            var ret = _lib.sv_end_of_song(slotId);
            if (ret != 0 && ret != 1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_end_of_song), $"{nameof(slotId)}: {slotId}.");
            }

            return ret == 0;
        }

        /// <summary>
        /// Load a SunVox project from file.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="path">File path (relative or absolute).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_load"/>.</remarks>
        public void Load(int slotId, string path)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(path);
            int ret;
            try
            {
                ret = _lib.sv_load(slotId, ptr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_load),
                    $"{nameof(slotId)}: {slotId}, {nameof(path)}: '{path ?? "<null>"}'.");
            }
        }

        /// <summary>
        /// Load a SunVox project from memory.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="data">Byte array with project data.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_load_from_memory"/>.</remarks>
        public void Load(int slotId, byte[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_load_from_memory(slotId, handle.AddrOfPinnedObject(), (uint)data.Length);
            }
            finally
            {
                handle.Free();
            }

            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_load_from_memory),
                   $"{nameof(slotId)}: {slotId}, data length: {data.Length}.");
            }
        }

        /// <summary>
        /// Lock the slot for thread-safe access.
        /// Use when reading/modifying SunVox data from different threads on the same slot.
        /// Some functions require lock/unlock. Remember to call <see cref="UnlockSlot"/>!
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>
        /// The library uses a recursive mutex, so the same thread may call <see cref="LockSlot"/> multiple times without deadlocking itself.
        /// </para>
        /// Calls <see cref="ISunVoxLibC.sv_lock_slot"/>.</remarks>
        public void LockSlot(int slotId)
        {
            var ret = _lib.sv_lock_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_lock_slot), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Open a slot.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_open_slot"/>.</remarks>
        public void OpenSlot(int slotId)
        {
            var ret = _lib.sv_open_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_open_slot), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Pause the audio stream from a slot.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_pause"/>.</remarks>
        public void PauseAudioStream(int slotId)
        {
            var ret = _lib.sv_pause(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_pause), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Resume the audio stream from a slot.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_resume"/>.</remarks>
        public void ResumeAudioStream(int slotId)
        {
            var ret = _lib.sv_resume(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_resume), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Wait for sync (pattern effect 0x33 in any slot) and resume the audio stream.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_sync_resume"/>.</remarks>
        public void ResumeStreamOnSyncEffect(int slotId)
        {
            var ret = _lib.sv_sync_resume(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_sync_resume), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Jump to the specified line on the timeline.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="line">Line number on the timeline.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_rewind"/>.</remarks>
        public void Rewind(int slotId, int line)
        {
            var ret = _lib.sv_rewind(slotId, line);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_rewind), $"{nameof(slotId)}: {slotId}, {nameof(line)}: {line}.");
            }
        }

        /// <summary>
        /// Save the SunVox project to a file.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="path">File path where the project will be saved.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_save"/>.</remarks>
        public void SaveToFile(int slotId, string path)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(path);
            int ret;
            try
            {
                ret = _lib.sv_save(slotId, ptr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_save),
                    $"{nameof(slotId)}: {slotId}, {nameof(path)}: '{path ?? "<null>"}'.");
            }
        }

        // TODO FIXME
        // issues with deallocating memory allocated by native code
        // additionally - size_t vs long issues on 32/64 bit platforms
        /*
        /// <summary>
        /// Save the SunVox project to memory.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <returns>Byte array containing the saved project data.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_save_to_memory"/>.</remarks>
        public byte[] SaveToMemory(int slotId)
        {
            long[] lengthArray = new long[1];
            var handle = GCHandle.Alloc(lengthArray, GCHandleType.Pinned);
            try
            {
                var ptr = handle.AddrOfPinnedObject();
                var buffer = _lib.sv_save_to_memory(slotId, ptr);
                if (buffer == IntPtr.Zero)
                {
                    throw new SunVoxException(buffer.ToInt64(), nameof(_lib.sv_save_to_memory), $"{nameof(slotId)}: {slotId}.");
                }

                long length = lengthArray[0];
                byte[] result = new byte[length];
                Marshal.Copy(buffer, result, 0, (int)length);
                Marshal.FreeHGlobal(buffer);
                return result;
            }
            finally
            {
                handle.Free();
            }
        }*/

        /// <summary>
        /// Send an event to the SunVox engine.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="track">Track number within the virtual pattern.</param>
        /// <param name="data">Pattern event data.</param>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_send_event"/>.</remarks>
        /// <seealso cref="PatternEvent"/>
        public void SendEvent(int slotId, int track, PatternEvent data)
        {
            SendEvent(slotId, track, data.NN, data.VV, data.MM, data.CCEE, data.XXYY);
        }

        /// <summary>
        /// Send an event to the SunVox engine.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="track">Track number within the virtual pattern.</param>
        /// <param name="nn">Note.</param>
        /// <param name="vv">Velocity.</param>
        /// <param name="mm">Module.</param>
        /// <param name="ccee">Controller and effect.</param>
        /// <param name="xxyy">Value.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>
        /// Consider using <see cref="PatternEvent"/> and the overload that accepts it for better readability.
        /// </para>
        /// Calls <see cref="ISunVoxLibC.sv_send_event"/>.
        /// </remarks>
        public void SendEvent(int slotId, int track, int nn = 0, int vv = 0, int mm = 0,
            int ccee = 0, int xxyy = 0)
        {
            var ret = _lib.sv_send_event(slotId, track, nn, vv, mm, ccee, xxyy);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(track)}: {track}, {nameof(nn)}: {nn}, {nameof(vv)}: {vv}, {nameof(mm)}: {mm}, {nameof(ccee)}: {ccee}, {nameof(xxyy)}: {xxyy}.";
                throw new SunVoxException(ret, nameof(_lib.sv_send_event), details);
            }
        }

        /// <summary>
        /// Set autostop mode. When OFF, the project loops endlessly.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="autoStop">
        /// <see langword="true"/> - stop at the end.
        /// </param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_autostop"/>.</remarks>
        public void SetAutomaticStop(int slotId, bool autoStop)
        {
            var ret = _lib.sv_set_autostop(slotId, autoStop ? 1 : 0);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_set_autostop),
                    $"{nameof(slotId)}: {slotId}, {nameof(autoStop)}: {autoStop}.");
            }
        }

        /// <summary>
        /// Set the timestamp of events sent by <see cref="SendEvent"/>.
        /// Every event has a timestamp (when it was generated, e.g., key press time).
        /// If timestamp is zero: event is heard as quickly as possible.
        /// If nonzero: event is heard at timestamp + sound latency * 2.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="reset">
        /// <see langword="true"/> - set timestamp;
        /// <see langword="false"/> - reset (ignores <paramref name="t"/>).
        /// </param>
        /// <param name="t">
        /// Timestamp (in system ticks) for future events.
        /// If not zero, must be ≥ previous value for same slot. See <see cref="GetTicks"/>.
        /// </param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_event_t"/>.</remarks>
        public void SetSendEventTimestamp(int slotId, bool reset, int t)
        {
            var ret = _lib.sv_set_event_t(slotId, reset ? 0 : 1, t);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_set_event_t),
                    $"{nameof(slotId)}: {slotId}, {nameof(reset)}: {reset}, {nameof(t)}: {t}.");
            }
        }

        /// <summary>
        /// Set the project name.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="newName">New project name.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_song_name"/>.</remarks>
        public void SetSongName(int slotId, string newName)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(newName);
            try
            {
                var ret = _lib.sv_set_song_name(slotId, ptr);
                if (ret != 0)
                {
                    throw new SunVoxException(ret, nameof(_lib.sv_set_song_name),
                        $"{nameof(slotId)}: {slotId}, {nameof(newName)}: '{newName ?? "<null>"}'.");
                }
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }
        }

        /// <summary>
        /// Play from the current position.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_play"/>.</remarks>
        public void StartPlayback(int slotId)
        {
            var ret = _lib.sv_play(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_play), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Play from the beginning (line 0).
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_play_from_beginning"/>.</remarks>
        public void StartPlaybackFromBeginning(int slotId)
        {
            var ret = _lib.sv_play_from_beginning(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_play_from_beginning), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Stop playing.
        /// First call stops playback. The sound engine continues working (e.g., reverb tail may be heard).
        /// Second call resets all activity and enters standby mode.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_stop"/>.</remarks>
        public void StopPlayback(int slotId)
        {
            var ret = _lib.sv_stop(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_stop), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Unlock the slot. Must be called after <see cref="LockSlot"/>.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_unlock_slot"/>.</remarks>
        public void UnlockSlot(int slotId)
        {
            var ret = _lib.sv_unlock_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_unlock_slot), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <summary>
        /// Handle input ON/OFF requests to enable/disable sound card input ports (e.g., after Input module creation).
        /// Call from the main thread only, where the SunVox sound stream is not locked.
        /// </summary>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_update_input"/>.</remarks>
        public void UpdateInputDevices()
        {
            var ret = _lib.sv_update_input();
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_update_input));
            }
        }

        /// <summary>
        /// Set the project volume.
        /// </summary>
        /// <param name="slotId">Slot number (0 to 15).</param>
        /// <param name="volume">Volume: 0 (min) to 256 (max/100%). Negative values are ignored.</param>
        /// <returns>Previous volume (0 to 256).</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_volume"/>.</remarks>
        public int Volume(int slotId, int volume)
        {
            var ret = _lib.sv_volume(slotId, volume);
            if (ret < 0 || ret > 256)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_volume),
                    $"{nameof(slotId)}: {slotId}, {nameof(volume)}: {volume}.");
            }

            return ret;
        }

        private bool AudioCallbackInternal<T>(T[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            if (channels == AudioChannels.Stereo && (outputBuffer.Length & 1) != 0)
            {
                throw new ArgumentException("Buffer size is not a multiple of two.");
            }

            var frames = outputBuffer.Length;
            if (channels == AudioChannels.Stereo)
            {
                frames /= 2;
            }

            var outHandle = GCHandle.Alloc(outputBuffer, GCHandleType.Pinned);
            var ptr = outHandle.AddrOfPinnedObject();
            int ret;
            try
            {
                ret = _lib.sv_audio_callback(ptr, frames, latency, outTime);
            }
            finally
            {
                outHandle.Free();
            }

            if (ret != 0 && ret != 1)
            {
                var details = $"{nameof(frames)}: {frames}, {nameof(latency)}: {latency}, {nameof(outTime)}: {outTime}.";
                throw new SunVoxException(ret, nameof(_lib.sv_audio_callback), details);
            }

            return ret == 1;
        }

        private bool AudioCallbackInternal<TOut, TIn>(TOut[] outputBuffer, AudioChannels outputChannels,
            TIn[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime,
            int inputType)
        {
            if (outputChannels == AudioChannels.Stereo && (outputBuffer.Length & 1) != 0)
            {
                throw new ArgumentException("Output buffer size is not a multiple of two.");
            }

            if (inputChannels == AudioChannels.Stereo && (inputBuffer.Length & 1) != 0)
            {
                throw new ArgumentException("Input buffer size is not a multiple of two.");
            }

            var inputFrames = inputBuffer.Length;
            if (inputChannels == AudioChannels.Stereo)
            {
                inputFrames /= 2;
            }

            var outputFrames = outputBuffer.Length;
            if (outputChannels == AudioChannels.Stereo)
            {
                outputFrames /= 2;
            }

            if (inputFrames != outputFrames)
            {
                throw new ArgumentException($"Input and output frame count is different (input: {inputFrames}, output: {outputFrames}).");
            }

            var outHandle = GCHandle.Alloc(outputBuffer, GCHandleType.Pinned);
            var inHandle = GCHandle.Alloc(inputBuffer, GCHandleType.Pinned);
            var outPtr = outHandle.AddrOfPinnedObject();
            var inPtr = inHandle.AddrOfPinnedObject();
            int ret;
            try
            {
                ret = _lib.sv_audio_callback2(outPtr, outputFrames, latency, outTime, inputType, (int)inputChannels,
                    inPtr);
            }
            finally
            {
                inHandle.Free();
                outHandle.Free();
            }

            if (ret != 0 && ret != 1)
            {
                var details = $"{nameof(outputFrames)}: {outputFrames}, {nameof(latency)}: {latency}, {nameof(outTime)}: {outTime}, {nameof(inputType)}: {inputType}, {nameof(inputChannels)}: {inputChannels}.";
                throw new SunVoxException(ret, nameof(_lib.sv_audio_callback2), details);
            }

            return ret == 1;
        }
    }
}
