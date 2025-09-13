using System;
using System.Runtime.InteropServices;

namespace SunSharp.Native
{
    public partial class SunVoxLibNativeWrapper : ISunVoxLib
    {
        private readonly ISunVoxLibC _lib;

        public SunVoxLibNativeWrapper(ISunVoxLibC nativeLibrary)
        {
            _lib = nativeLibrary;
        }

        /// <inheritdoc />
        public bool AudioCallback(float[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, channels, latency, outTime);
        }

        /// <inheritdoc />
        public bool AudioCallback(short[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, channels, latency, outTime);
        }

        /// <inheritdoc />
        public bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels, float[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 1);
        }

        /// <inheritdoc />
        public bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 0);
        }

        /// <inheritdoc />
        public bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels, float[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 1);
        }

        /// <inheritdoc />
        public bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels, short[] inputBuffer,
            AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 0);
        }

        /// <inheritdoc />
        public void CloseSlot(int slotId)
        {
            var ret = _lib.sv_close_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_close_slot));
            }
        }

        /// <inheritdoc />
        public void Deinitialize()
        {
            var retCode = _lib.sv_deinit();
            if (retCode != 0)
            {
                throw new SunVoxException(retCode, nameof(_lib.sv_deinit));
            }
        }

        /// <inheritdoc />
        public bool GetAutostop(int slotId)
        {
            var ret = _lib.sv_get_autostop(slotId);
            if (ret != 0 && ret != 1)
                throw new SunVoxException(ret, nameof(_lib.sv_get_autostop));
            return ret == 1;
        }

        /// <inheritdoc />
        public int GetCurrentLine(int slotId)
        {
            return _lib.sv_get_current_line(slotId);
        }

        /// <inheritdoc />
        public int GetCurrentLineWithTenthPart(int slotId)
        {
            return _lib.sv_get_current_line2(slotId);
        }

        /// <inheritdoc />
        public int GetCurrentSignalLevel(int slotId, int channel)
        {
            return _lib.sv_get_current_signal_level(slotId, channel);
        }

        /// <inheritdoc />
        public string? GetLog(int size)
        {
            var ptr = _lib.sv_get_log(size);
            try
            {
                return Marshal.PtrToStringAnsi(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <inheritdoc />
        public int GetSampleRate()
        {
            var ret = _lib.sv_get_sample_rate();
            if (ret < 1)
                throw new SunVoxException(ret, nameof(_lib.sv_get_sample_rate));
            return ret;
        }

        /// <inheritdoc />
        public int GetSongBpm(int slotId)
        {
            var ret = _lib.sv_get_song_bpm(slotId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_song_bpm));
            return ret;
        }

        /// <inheritdoc />
        public uint GetSongLengthInFrames(int slotId)
        {
            var ret = _lib.sv_get_song_length_frames(slotId);
            return ret;
        }

        /// <inheritdoc />
        public uint GetSongLengthInLines(int slotId)
        {
            var ret = _lib.sv_get_song_length_lines(slotId);
            return ret;
        }

        /// <inheritdoc />
        public string? GetSongName(int slotId)
        {
            var ptr = _lib.sv_get_song_name(slotId);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <inheritdoc />
        public int GetSongTpl(int slotId)
        {
            var ret = _lib.sv_get_song_tpl(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_song_tpl));
            }

            return ret;
        }

        /// <inheritdoc />
        public uint GetTicks()
        {
            return _lib.sv_get_ticks();
        }

        /// <inheritdoc />
        public uint GetTicksPerSecond()
        {
            return _lib.sv_get_ticks_per_second();
        }

        /// <inheritdoc />
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
                throw new SunVoxException(ret, nameof(_lib.sv_get_time_map));
            }

            return arr;
        }

        /// <inheritdoc />
        public LibraryVersion Initialize(int sampleRate, string? config = null,
            AudioChannels channels = AudioChannels.Stereo, InitFlags flags = InitFlags.None)
        {
            var ptr = Marshal.StringToHGlobalAnsi(config);
            try
            {
                var ret = _lib.sv_init(ptr, sampleRate, (int)channels, (uint)flags);
                if (ret < 0)
                {
                    throw new SunVoxException(ret, nameof(_lib.sv_init));
                }

                return new LibraryVersion(ret);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <inheritdoc />
        public bool IsPlaying(int slotId)
        {
            var ret = _lib.sv_end_of_song(slotId);
            if (ret != 0 && ret != 1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_end_of_song));
            }

            return ret == 0;
        }

        /// <inheritdoc />
        public void Load(int slotId, string path)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = _lib.sv_load(slotId, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_load));
            }
        }

        /// <inheritdoc />
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
                throw new SunVoxException(ret, nameof(_lib.sv_load));
            }
        }

        /// <inheritdoc />
        public void LockSlot(int slotId)
        {
            var ret = _lib.sv_lock_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_lock_slot));
            }
        }

        /// <inheritdoc />
        public void OpenSlot(int slotId)
        {
            var ret = _lib.sv_open_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_open_slot));
            }
        }

        /// <inheritdoc />
        public void PauseStream(int slotId)
        {
            var ret = _lib.sv_pause(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_pause));
            }
        }

        /// <inheritdoc />
        public void ResumeStream(int slotId)
        {
            var ret = _lib.sv_resume(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_resume));
            }
        }

        public void ResumeStreamOnSyncEffect(int slotId)
        {
            var ret = _lib.sv_sync_resume(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_sync_resume));
            }
        }

        /// <inheritdoc />
        public void Rewind(int slotId, int line)
        {
            var ret = _lib.sv_rewind(slotId, line);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_rewind));
            }
        }

        /// <inheritdoc />
        public void Save(int slotId, string path)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = _lib.sv_save(slotId, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_save));
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
                throw new SunVoxException(ret, nameof(_lib.sv_send_event));
            }
        }

        public void SetAutoStop(int slotId, bool autoStop)
        {
            var ret = _lib.sv_set_autostop(slotId, autoStop ? 1 : 0);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_set_autostop));
            }
        }

        public void SetSendEventTimestamp(int slotId, bool reset = true, int t = 0)
        {
            var ret = _lib.sv_set_event_t(slotId, reset ? 0 : 1, t);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_set_event_t));
            }
        }

        /// <inheritdoc />
        public void SetSongName(int slotId, string newName)
        {
            var ptr = Marshal.StringToHGlobalAnsi(newName);
            try
            {
                var ret = _lib.sv_set_song_name(slotId, ptr);
                if (ret != 0)
                {
                    throw new SunVoxException(ret, nameof(_lib.sv_init));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <inheritdoc />
        public void StartPlayback(int slotId)
        {
            var ret = _lib.sv_play(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_play));
            }
        }

        /// <inheritdoc />
        public void StartPlaybackFromBeginning(int slotId)
        {
            var ret = _lib.sv_play_from_beginning(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_play_from_beginning));
            }
        }

        /// <inheritdoc />
        public void StopPlayback(int slotId)
        {
            var ret = _lib.sv_stop(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_stop));
            }
        }

        /// <inheritdoc />
        public void UnlockSlot(int slotId)
        {
            var ret = _lib.sv_unlock_slot(slotId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_unlock_slot));
            }
        }

        /// <inheritdoc />
        public void UpdateInputDevices()
        {
            var ret = _lib.sv_update_input();
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_update_input));
            }
        }

        /// <inheritdoc />
        public int Volume(int slotId, int volume)
        {
            var ret = _lib.sv_volume(slotId, volume);
            if (ret < 0 || ret > 256)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_volume));
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
                throw new SunVoxException(ret, nameof(_lib.sv_audio_callback));

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
                throw new SunVoxException(ret, nameof(_lib.sv_audio_callback2));

            return ret == 1;
        }
    }
}
