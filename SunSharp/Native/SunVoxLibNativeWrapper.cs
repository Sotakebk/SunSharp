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

        /// <inheritdoc/>
        public bool AudioCallback(float[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, channels, latency, outTime);
        }

        /// <inheritdoc/>
        public bool AudioCallback(short[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, channels, latency, outTime);
        }

        /// <inheritdoc/>
        public bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels, float[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 1);
        }

        /// <inheritdoc/>
        public bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 0);
        }

        /// <inheritdoc/>
        public bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels, float[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 1);
        }

        /// <inheritdoc/>
        public bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels, short[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 0);
        }

        /// <inheritdoc/>
        public void CloseSlot(int slotId)
        {
            var ret = _lib.sv_close_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_close_slot), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void Deinitialize()
        {
            var retCode = _lib.sv_deinit();
            if (retCode != 0)
            {
                throw new SunVoxException(retCode, nameof(_lib.sv_deinit));
            }
        }

        /// <inheritdoc/>
        public bool GetAutomaticStop(int slotId)
        {
            var ret = _lib.sv_get_autostop(slotId);
            if (ret != 0 && ret != 1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_autostop), $"{nameof(slotId)}: {slotId}.");
            }
            return ret == 1;
        }

        /// <inheritdoc/>
        public int GetCurrentLine(int slotId)
        {
            return _lib.sv_get_current_line(slotId);
        }

        /// <inheritdoc/>
        public int GetCurrentLineWithTenthPart(int slotId)
        {
            return _lib.sv_get_current_line2(slotId);
        }

        /// <inheritdoc/>
        public int GetCurrentSignalLevel(int slotId, int channel)
        {
            var ret = _lib.sv_get_current_signal_level(slotId, channel);

            if (ret < 0 || ret > 255)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_current_signal_level),
                    $"{nameof(slotId)}: {slotId}, {nameof(channel)}: {channel}.");
            }

            return ret;
        }

        /// <inheritdoc/>
        public string? GetLog(int size)
        {
            // memory managed by SunVox
            var ptr = _lib.sv_get_log(size);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <inheritdoc/>
        public int GetSampleRate()
        {
            var ret = _lib.sv_get_sample_rate();
            if (ret < 1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_sample_rate));
            }

            return ret;
        }

        /// <inheritdoc/>
        public int GetSongBpm(int slotId)
        {
            var ret = _lib.sv_get_song_bpm(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_song_bpm), $"{nameof(slotId)}: {slotId}.");
            }

            return ret;
        }

        /// <inheritdoc/>
        public uint GetSongLengthInFrames(int slotId)
        {
            return _lib.sv_get_song_length_frames(slotId);
        }

        /// <inheritdoc/>
        public uint GetSongLengthInLines(int slotId)
        {
            return _lib.sv_get_song_length_lines(slotId);
        }

        /// <inheritdoc/>
        public string? GetSongName(int slotId)
        {
            // memory managed by SunVox
            var ptr = _lib.sv_get_song_name(slotId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <inheritdoc/>
        public int GetSongTpl(int slotId)
        {
            var ret = _lib.sv_get_song_tpl(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_song_tpl), $"{nameof(slotId)}: {slotId}.");
            }

            return ret;
        }

        /// <inheritdoc/>
        public uint GetTicks()
        {
            return _lib.sv_get_ticks();
        }

        /// <inheritdoc/>
        public uint GetTicksPerSecond()
        {
            return _lib.sv_get_ticks_per_second();
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public LibraryVersion Initialize(int sampleRate, string? config = null,
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

                return new LibraryVersion(ret);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }
        }

        /// <inheritdoc/>
        public bool IsPlaying(int slotId)
        {
            var ret = _lib.sv_end_of_song(slotId);
            if (ret != 0 && ret != 1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_end_of_song), $"{nameof(slotId)}: {slotId}.");
            }

            return ret == 0;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void LockSlot(int slotId)
        {
            var ret = _lib.sv_lock_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_lock_slot), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void OpenSlot(int slotId)
        {
            var ret = _lib.sv_open_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_open_slot), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void PauseAudioStream(int slotId)
        {
            var ret = _lib.sv_pause(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_pause), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void ResumeAudioStream(int slotId)
        {
            var ret = _lib.sv_resume(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_resume), $"{nameof(slotId)}: {slotId}.");
            }
        }

        public void ResumeStreamOnSyncEffect(int slotId)
        {
            var ret = _lib.sv_sync_resume(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_sync_resume), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void Rewind(int slotId, int line)
        {
            var ret = _lib.sv_rewind(slotId, line);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_rewind), $"{nameof(slotId)}: {slotId}, {nameof(line)}: {line}.");
            }
        }

        /// <inheritdoc/>
        public void Save(int slotId, string path)
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

        public void SendEvent(int slotId, int track, PatternEvent data)
        {
            SendEvent(slotId, track, data.NN, data.VV, data.MM, data.CCEE, data.XXYY);
        }

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

        public void SetAutomaticStop(int slotId, bool autoStop)
        {
            var ret = _lib.sv_set_autostop(slotId, autoStop ? 1 : 0);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_set_autostop),
                    $"{nameof(slotId)}: {slotId}, {nameof(autoStop)}: {autoStop}.");
            }
        }

        public void SetSendEventTimestamp(int slotId, bool reset, int t)
        {
            var ret = _lib.sv_set_event_t(slotId, reset ? 0 : 1, t);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_set_event_t),
                    $"{nameof(slotId)}: {slotId}, {nameof(reset)}: {reset}, {nameof(t)}: {t}.");
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void StartPlayback(int slotId)
        {
            var ret = _lib.sv_play(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_play), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void StartPlaybackFromBeginning(int slotId)
        {
            var ret = _lib.sv_play_from_beginning(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_play_from_beginning), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void StopPlayback(int slotId)
        {
            var ret = _lib.sv_stop(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_stop), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void UnlockSlot(int slotId)
        {
            var ret = _lib.sv_unlock_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_unlock_slot), $"{nameof(slotId)}: {slotId}.");
            }
        }

        /// <inheritdoc/>
        public void UpdateInputDevices()
        {
            var ret = _lib.sv_update_input();
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_update_input));
            }
        }

        /// <inheritdoc/>
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
