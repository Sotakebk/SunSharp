using System;
using System.Runtime.InteropServices;

namespace SunSharp.ThinWrapper
{
    public static class SunVoxLibExtensions
    {
        #region helper helpers

        private static short ToShortBitwise(uint value)
        {
            if ((value & 0x8000) != 0) // sign byte
            {
                int val = (int)value;
                return (short)(val - 0x10000);
            }
            return (short)value;
        }

        private static int[] CopyIntArraySkipNegativeOnes(IntPtr ptr, int count)
        {
            int c = 0;
            for (int i = 0; i < count; i++)
            {
                if (Marshal.ReadInt32(ptr, i * sizeof(int)) != -1)
                    c++;
            }
            var arr = new int[c];

            c = 0;
            for (int i = 0; i < count; i++)
            {
                var value = Marshal.ReadInt32(ptr, i * sizeof(int));
                if (value != -1)
                {
                    arr[c] = value;
                    c++;
                }
            }

            return arr;
        }

        #endregion helper helpers

        #region macros

        // this code is translated from sunvox.h

        /// <summary>
        /// Get x, y position from one xy value received from <see cref="ISunVoxLib.sv_get_module_xy(int, int)"/>.
        /// </summary>
        /// <param name="xy"></param>
        /// <returns></returns>
        public static (short x, short y) PositionToXY(uint xy)
        {
            uint x = xy & 0xFFFF;
            uint y = (xy >> 16) & 0xFFFF;
            return (ToShortBitwise(x), ToShortBitwise(y));
        }

        /// <summary>
        /// Get finetune and relative note value from one finetune value received from <see cref="ISunVoxLib.sv_get_module_finetune(int, int)"/>.
        /// </summary>
        /// <param name="moduleFinetune"></param>
        /// <returns></returns>
        public static (short finetune, short relativeNote) SplitFinetune(uint moduleFinetune)
        {
            uint out_finetune = moduleFinetune & 0xFFFF;
            uint out_relative_note = (moduleFinetune >> 16) & 0xFFFF;
            return (ToShortBitwise(out_finetune), ToShortBitwise(out_relative_note));
        }

        public static float FrequencyFromPitch(float pitch)
        {
            return (float)FrequencyFromPitch((double)pitch);
        }

        public static double FrequencyFromPitch(double pitch)
        {
            var value = (30720.0 - pitch) / 3072.0;
            value = Math.Pow(2, value) * 16.333984375;
            return value;
        }

        public static float PitchFromFrequency(float frequency)
        {
            return (float)PitchFromFrequency((double)frequency);
        }

        public static double PitchFromFrequency(double frequency)
        {
            var value = Math.Log(frequency, 2) / 16.333984375;
            value = 30720 - value * 3072;
            return (float)value;
        }

        #endregion macros

        #region audio rendering

        private static bool AudioCallbackInternal<T>(this ISunVoxLib lib, T[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            if (channels == AudioChannels.Stereo && (outputBuffer.Length & 1) != 0)
                throw new ArgumentException("Buffer size is not a multiple of two.");

            int frames = outputBuffer.Length;
            if (channels == AudioChannels.Stereo)
                frames /= 2;

            var outHandle = GCHandle.Alloc(outputBuffer, GCHandleType.Pinned);
            IntPtr ptr = outHandle.AddrOfPinnedObject();
            int ret;
            try
            {
                ret = lib.sv_audio_callback(ptr, frames, latency, outTime);
            }
            finally
            {
                outHandle.Free();
            }
            if (ret != 0 && ret != 1)
                throw new SunVoxException(ret, nameof(lib.sv_audio_callback));

            return (ret == 1);
        }

        private static bool AudioCallbackInternal<T, V>(this ISunVoxLib lib, T[] outputBuffer, AudioChannels outputChannels, V[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime, int inputType)
        {
            if (outputChannels == AudioChannels.Stereo && (outputBuffer.Length & 1) != 0)
                throw new ArgumentException("Output buffer size is not a multiple of two.");

            if (inputChannels == AudioChannels.Stereo && (inputBuffer.Length & 1) != 0)
                throw new ArgumentException("Input buffer size is not a multiple of two.");

            int inputFrames = inputBuffer.Length;
            if (inputChannels == AudioChannels.Stereo)
                inputFrames /= 2;

            int outputFrmaes = outputBuffer.Length;
            if (outputChannels == AudioChannels.Stereo)
                outputFrmaes /= 2;

            if (inputFrames != outputFrmaes)
                throw new ArgumentException($"Input and output frame count is different (input: {inputFrames} vs {outputFrmaes}).");

            var outHandle = GCHandle.Alloc(outputBuffer, GCHandleType.Pinned);
            var inHandle = GCHandle.Alloc(inputBuffer, GCHandleType.Pinned);
            IntPtr outPtr = outHandle.AddrOfPinnedObject();
            IntPtr inPtr = inHandle.AddrOfPinnedObject();
            int ret;
            try
            {
                int frames =
                ret = lib.sv_audio_callback2(outPtr, outputFrmaes, latency, outTime, inputType, (int)inputChannels, inPtr);
            }
            finally
            {
                inHandle.Free();
                outHandle.Free();
            }
            if (ret != 0 && ret != 1)
                throw new SunVoxException(ret, nameof(lib.sv_audio_callback2));

            return (ret == 1);
        }

        /// <summary>
        /// Get the next piece of audio.
        /// If audio is stereo, the samples will be interlaced, and the buffer size must be a multiple of two.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="outputBuffer">Buffer to write sound data to.</param>
        /// <param name="channels">Channels the library was initialized with.</param>
        /// <param name="latency">Audio latency (in frames).</param>
        /// <param name="outTime">Buffer output time (in system ticks).</param>
        /// <returns><see langword="false"/> if buffer was filled with zeros.</returns>
        public static bool AudioCallback(this ISunVoxLib lib, float[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, channels, latency, outTime);
        }

        /// <inheritdoc cref="AudioCallback(ISunVoxLib, float[], AudioChannels, int, uint)"/>
        public static bool AudioCallback(this ISunVoxLib lib, short[] outputBuffer, AudioChannels channels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, channels, latency, outTime);
        }

        /// <summary>
        /// Get the next piece of audio.
        /// If audio is stereo, the samples will be interlaced, and the buffer size must be a multiple of two.
        /// Sends equal size buffer of an input device, which will be applied to any Input modules.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="outputBuffer">Buffer to write sound data to.</param>
        /// <param name="outputChannels">Channels the library was initialized with.</param>
        /// <param name="inputBuffer">Buffer to read sound data from.</param>
        /// <param name="inputChannels">Input data channels.</param>
        /// <param name="latency">Audio latency (in frames).</param>
        /// <param name="outTime">Buffer output time (in system ticks).</param>
        /// <returns><see langword="false"/> if buffer was filled with zeros.</returns>
        public static bool AudioCallback(this ISunVoxLib lib, float[] outputBuffer, AudioChannels outputChannels, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 1);
        }

        /// <inheritdoc cref="AudioCallback(ISunVoxLib, float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        public static bool AudioCallback(this ISunVoxLib lib, float[] outputBuffer, AudioChannels outputChannels, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 0);
        }

        /// <inheritdoc cref="AudioCallback(ISunVoxLib, float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        public static bool AudioCallback(this ISunVoxLib lib, short[] outputBuffer, AudioChannels outputChannels, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 1);
        }

        /// <inheritdoc cref="AudioCallback(ISunVoxLib, float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        public static bool AudioCallback(this ISunVoxLib lib, short[] outputBuffer, AudioChannels outputChannels, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, outputChannels, inputBuffer, inputChannels, latency, outTime, 0);
        }

        #endregion audio rendering

        #region engine

        /// <summary>
        /// Initialize the engine.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="sampleRate">Sample rate. If not using audio callback, may be set to -1.</param>
        /// <param name="config">Configuration, which may include input and output devices. See SunVox Lib documentation for details.</param>
        /// <param name="channels">Channels to be used.</param>
        /// <param name="flags">Initialization flags.</param>
        /// <returns>The version of underlying library.</returns>
        /// <exception cref="SunVoxException"></exception>
        public static Version Init(this ISunVoxLib lib, int sampleRate, string config = null, AudioChannels channels = AudioChannels.Stereo, InitFlags flags = InitFlags.Default)
        {
            var ptr = Marshal.StringToHGlobalAnsi(config);
            try
            {
                var ret = lib.sv_init(ptr, sampleRate, (int)channels, (uint)flags);
                if (ret < 0)
                    throw new SunVoxException(ret, nameof(lib.sv_init));
                return new Version(ret);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Deinitializes the library, frees resources.
        /// </summary>
        /// <param name="lib"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void Deinit(this ISunVoxLib lib)
        {
            var retCode = lib.sv_deinit();
            if (retCode != 0)
                throw new SunVoxException(retCode, nameof(lib.sv_deinit));
        }

        /// <summary>
        /// Get first <paramref name="size"/> characters of engine logs.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="size">Character count to be read.</param>
        /// <returns></returns>
        public static string GetLog(this ISunVoxLib lib, int size)
        {
            var ptr = lib.sv_get_log(size);
            if (ptr == IntPtr.Zero)
                return null;
            try
            {
                return Marshal.PtrToStringAnsi(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static uint GetTicks(this ISunVoxLib lib)
        {
            var ret = lib.sv_get_ticks();
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_ticks));
            return ret;
        }

        public static uint GetTicksPerSecond(this ISunVoxLib lib)
        {
            var ret = lib.sv_get_ticks_per_second();
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_ticks_per_second));
            return ret;
        }

        public static int GetSampleRate(this ISunVoxLib lib)
        {
            var ret = lib.sv_get_sample_rate();
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_sample_rate));
            return ret;
        }

        /// <summary>
        /// Handle input ON/OFF requests to enable/disable input ports of the sound card (for example, after the Input module creation). Call it from the main thread only, where the SunVox sound stream is not locked.
        /// </summary>
        /// <param name="lib"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void UpdateInputDevices(this ISunVoxLib lib)
        {
            var ret = lib.sv_update_input();
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_update_input));
        }

        #endregion engine

        #region slot

        public static bool IsPlaying(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_end_of_song(slot);
            if (ret != 0 && ret != 1)
                throw new SunVoxException(ret, nameof(lib.sv_end_of_song));
            return ret == 0;
        }

        /// <summary>
        /// Get current behaviour for reaching the end of project timeline.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <returns><see langword="true"/> if project is stopped after reaching the end.</returns>
        /// <exception cref="SunVoxException"></exception>
        public static bool GetAutostop(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_autostop(slot);
            if (ret != 0 && ret != 1)
                throw new SunVoxException(ret, nameof(lib.sv_get_autostop));
            return ret == 1;
        }

        public static int GetCurrentLine(this ISunVoxLib lib, int slot)
        {
            return lib.sv_get_current_line(slot);
        }

        /// <summary>
        /// Get current line in fixed point format (with tenth part).
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public static int GetCurrentLine2(this ISunVoxLib lib, int slot)
        {
            return lib.sv_get_current_line2(slot);
        }

        public static int GetCurrentSignalLevel(this ISunVoxLib lib, int slot, int channel)
        {
            return lib.sv_get_current_signal_level(slot, channel);
        }

        public static int GetSongBpm(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_song_bpm(slot);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_song_bpm));
            return ret;
        }

        public static int GetSongLengthInFrames(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_song_length_frames(slot);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_song_length_frames));
            return (int)ret;
        }

        public static int GetSongLengthInLines(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_song_length_lines(slot);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_song_length_lines));
            return (int)ret;
        }

        public static string GetSongName(this ISunVoxLib lib, int slot)
        {
            var ptr = lib.sv_get_song_name(slot);
            if (ptr == IntPtr.Zero)
                return null;

            return Marshal.PtrToStringAnsi(ptr);
        }

        public static int GetSongTpl(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_song_tpl(slot);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_song_tpl));
            return ret;
        }

        public static void Save(this ISunVoxLib lib, int slot, string path)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = lib.sv_save(slot, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_save));
        }

        public static void SendEvent(this ISunVoxLib lib, int slot, int track, PatternEvent @event)
        {
            SendEvent(lib, slot, track, @event.NN, @event.VV, @event.MM, @event.CCEE, @event.XXYY);
        }

        public static void SendEvent(this ISunVoxLib lib, int slot, int track, int NN = 0, int VV = 0, int MM = 0, int CCEE = 0, int XXYY = 0)
        {
            int ret = lib.sv_send_event(slot, track, NN, VV, MM, CCEE, XXYY);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_send_event));
        }

        public static void SetAutostop(this ISunVoxLib lib, int slot, bool autostop)
        {
            var ret = lib.sv_set_autostop(slot, autostop ? 1 : 0);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_set_autostop));
        }

        public static void SetSendEventTimestamp(this ISunVoxLib lib, int slot, bool reset = true, int t = 0)
        {
            var ret = lib.sv_set_event_t(slot, reset ? 0 : 1, t);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_set_event_t));
        }

        public static void Stop(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_stop(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_stop));
        }

        public static void ResumeOnSyncEffect(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_sync_resume(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_sync_resume));
        }

        /// <summary>
        /// Get and set volume. Call with <paramref name="volume"/> = -1 to only get the value.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="volume">Value in range 0-256.</param>
        /// <returns>Previous volume in range 0-256.</returns>
        /// <exception cref="SunVoxException"></exception>
        public static int Volume(this ISunVoxLib lib, int slot, int volume)
        {
            var ret = lib.sv_volume(slot, volume);
            if (ret < 0 || ret > 256)
                throw new SunVoxException(ret, nameof(lib.sv_volume));
            return ret;
        }

        /// <summary>
        /// Get the project time map.
        /// <para>For <paramref name="type"/> = <see cref="TimeMapType.Speed"/>, Nth value equals speed at the beginning of Nth line (Bpm | Tpl &lt;&lt; 16). </para>
        /// <para>For <paramref name="type"/> = <see cref="TimeMapType.FrameCount"/>, Nth value equals frame counter at the beginning of Nth line. </para>
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="startLine"></param>
        /// <param name="length"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="SunVoxException"></exception>
        public static uint[] GetTimeMap(this ISunVoxLib lib, int slot, int startLine, int length, TimeMapType type)
        {
            var arr = new uint[length];
            var handle = GCHandle.Alloc(arr, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = lib.sv_get_time_map(slot, startLine, length, handle.AddrOfPinnedObject(), (int)type);
            }
            finally
            {
                handle.Free();
            }
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_time_map));
            return arr;
        }

        /// <summary>
        /// Load a project from path.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="path"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void Load(this ISunVoxLib lib, int slot, string path)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = lib.sv_load(slot, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_load));
        }

        /// <summary>
        /// Load a project from memory.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="data"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void Load(this ISunVoxLib lib, int slot, byte[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = lib.sv_load_from_memory(slot, handle.AddrOfPinnedObject(), (uint)data.Length);
            }
            finally
            {
                handle.Free();
            }
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_load));
        }

        public static void OpenSlot(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_open_slot(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_open_slot));
        }

        public static void CloseSlot(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_close_slot(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_close_slot));
        }

        /// <summary>
        /// Enter a lock block.
        /// Use to send multiple events at the same time, read or write data from multiple threads.
        /// Remember to call <see cref="UnlockSlot(ISunVoxLib, int)"/>!
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void LockSlot(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_lock_slot(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_lock_slot));
        }

        /// <summary>
        /// Leave a lock block.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void UnlockSlot(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_unlock_slot(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_unlock_slot));
        }

        /// <summary>
        /// Use to group multiple calls in one lock/unlock block.
        /// Possible issues: when a slot is closed, then re-opened while user code is running, it may escape the abstraction and/or throw an exception.
        /// </summary>
        public static void RunInLock(this ISunVoxLib lib, int slot, Action action)
        {
            bool entered = false;
            try
            {
                lib.LockSlot(slot);
                entered = true;
                action();
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slot);
            }
        }

        /// <inheritdoc cref="RunInLock(ISunVoxLib, int, Action)"/>
        public static T RunInLock<T>(this ISunVoxLib lib, int slot, Func<T> func)
        {
            bool entered = false;
            try
            {
                lib.LockSlot(slot);
                entered = true;
                return func();
            }
            finally
            {
                if (entered)
                    lib.UnlockSlot(slot);
            }
        }

        public static void Pause(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_pause(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_pause));
        }

        public static void Play(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_play(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_play));
        }

        public static void PlayFromBeginning(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_play_from_beginning(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_play_from_beginning));
        }

        public static void Resume(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_resume(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_resume));
        }

        public static void Rewind(this ISunVoxLib lib, int slot, int line)
        {
            var ret = lib.sv_rewind(slot, line);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_rewind));
        }

        #region module

        /// <summary>
        /// <para>Use <see cref="LockSlot(ISunVoxLib, int)"/> or an alternative!</para>
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void ConnectModule(this ISunVoxLib lib, int slot, int source, int destination)
        {
            var ret = lib.sv_connect_module(slot, source, destination);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_connect_module));
        }

        /// <summary>
        ///
        /// <para>Use <see cref="LockSlot(ISunVoxLib, int)"/> or an alternative!</para>
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void DisconnectModule(this ISunVoxLib lib, int slot, int source, int destination)
        {
            var ret = lib.sv_disconnect_module(slot, source, destination);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_disconnect_module));
        }

        /// <summary>
        /// Find module by name.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="name"></param>
        /// <returns>Id of found module, -1 if it was not found.</returns>
        /// <exception cref="SunVoxException"></exception>
        public static int FindModule(this ISunVoxLib lib, int slot, string name)
        {
            var ptr = Marshal.StringToHGlobalAnsi(name);
            int ret;
            try
            {
                ret = lib.sv_find_module(slot, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            if (ret < -1)
                throw new SunVoxException(ret, nameof(lib.sv_find_module));

            return ret;
        }

        public static (byte R, byte G, byte B) GetModuleColor(this ISunVoxLib lib, int slot, int module)
        {
            var ret = lib.sv_get_module_color(slot, module);
            var red = (byte)((ret) & 0xFF);
            var green = (byte)((ret >> 8) & 0xFF);
            var blue = (byte)((ret >> 16) & 0xFF);
            return (red, green, blue);
        }

        public static string GetModuleControllerName(this ISunVoxLib lib, int slot, int module, int controller)
        {
            var ptr = lib.sv_get_module_ctl_name(slot, module, controller);
            if (ptr == IntPtr.Zero)
                return null;

            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <summary>
        /// Get module controller value. If scaled, it will be in XXYY column format, in range of 0x0000 to 0x8000.
        /// Otherwise, it will return actual values.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="module"></param>
        /// <param name="controller"></param>
        /// <param name="scaled"></param>
        /// <returns></returns>
        public static int GetModuleControllerValue(this ISunVoxLib lib, int slot, int module, int controller, bool scaled)
        {
            return lib.sv_get_module_ctl_value(slot, module, controller, scaled ? 1 : 0);
        }

        public static (int finetune, int relativeNote) GetModuleFinetune(this ISunVoxLib lib, int slot, int module)
        {
            return SplitFinetune(lib.sv_get_module_finetune(slot, module));
        }

        public static ModuleFlags GetModuleFlags(this ISunVoxLib lib, int slot, int module)
        {
            return lib.sv_get_module_flags(slot, module);
        }

        public static bool GetModuleExists(this ISunVoxLib lib, int slot, int module)
        {
            return GetModuleFlags(lib, slot, module).Exists;
        }

        /// <summary>
        /// Get an array of Ids of modules.
        /// Does NOT return -1 for empty connection slots.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public static int[] GetModuleInputs(this ISunVoxLib lib, int slot, int module)
        {
            var count = GetModuleFlags(lib, slot, module).InputUpperCount;
            if (count == 0)
                return Array.Empty<int>();

            var ptr = lib.sv_get_module_inputs(slot, module);
            try
            {
                return CopyIntArraySkipNegativeOnes(ptr, count);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static string GetModuleName(this ISunVoxLib lib, int slot, int module)
        {
            var ptr = lib.sv_get_module_name(slot, module);
            if (ptr == IntPtr.Zero)
                return null;

            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <summary>
        /// Get an array of Ids of modules.
        /// Does NOT return -1 for empty connection slots.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public static int[] GetModuleOutputs(this ISunVoxLib lib, int slot, int module)
        {
            var count = GetModuleFlags(lib, slot, module).OutputUpperCount;
            if (count == 0)
                return Array.Empty<int>();

            var ptr = lib.sv_get_module_outputs(slot, module);
            try
            {
                return CopyIntArraySkipNegativeOnes(ptr, count);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Read module scope view, and write it to a buffer.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="module"></param>
        /// <param name="channel"></param>
        /// <param name="buffer"></param>
        /// <returns>Number of samples successfully read.</returns>
        public static int ReadModuleScope(this ISunVoxLib lib, int slot, int module, int channel, short[] buffer)
        {
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();
            try
            {
                return (int)lib.sv_get_module_scope2(slot, module, channel, ptr, (uint)buffer.Length);
            }
            finally
            {
                handle.Free();
            }
        }

        public static (int x, int y) GetModulePosition(this ISunVoxLib lib, int slot, int module)
        {
            return PositionToXY(lib.sv_get_module_xy(slot, module));
        }

        /// <summary>
        /// Get the upper module count, which may be greater than the actual module count.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        /// <exception cref="SunVoxException"></exception>
        public static int GetUpperModuleCount(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_number_of_modules(slot);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_number_of_modules));
            return ret;
        }

        public static int GetModuleControllerCount(this ISunVoxLib lib, int slot, int module)
        {
            var ret = lib.sv_get_number_of_module_ctls(slot, module);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_number_of_module_ctls));
            return ret;
        }

        /// <summary>
        /// Load a MetaModule from a file.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="path"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        /// <exception cref="SunVoxException"></exception>
        public static int LoadModule(this ISunVoxLib lib, int slot, string path, int x = 0, int y = 0, int z = 0)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = lib.sv_load_module(slot, ptr, x, y, z);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_load_module));
            return ret;
        }

        /// <summary>
        /// Load a MetaModule from memory.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="data"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        /// <exception cref="SunVoxException"></exception>
        public static int LoadModule(this ISunVoxLib lib, int slot, byte[] data, int x = 0, int y = 0, int z = 0)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = lib.sv_load_module_from_memory(slot, handle.AddrOfPinnedObject(), (uint)data.Length, x, y, z);
            }
            finally
            {
                handle.Free();
            }
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_load_module));
            return ret;
        }

        public static int WriteModuleCurve(this ISunVoxLib lib, int slot, int module, int curve, float[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = lib.sv_module_curve(slot, module, curve, handle.AddrOfPinnedObject(), data.Length, 1);
            }
            finally
            {
                handle.Free();
            }
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_module_curve));
            return ret;
        }

        public static int ReadModuleCurve(this ISunVoxLib lib, int slot, int module, int curve, float[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = lib.sv_module_curve(slot, module, curve, handle.AddrOfPinnedObject(), data.Length, 0);
            }
            finally
            {
                handle.Free();
            }
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_module_curve));
            return ret;
        }

        /// <summary>
        /// Create a new module. Type refers to the name visible on new module creation window.
        /// <para>Use <see cref="LockSlot(ISunVoxLib, int)"/> or an alternative!</para>
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>ID of newly created module.</returns>
        /// <exception cref="SunVoxException"></exception>
        public static int CreateModule(this ISunVoxLib lib, int slot, string type, string name, int x = 0, int y = 0, int z = 0)
        {
            var typeptr = Marshal.StringToHGlobalAnsi(type);
            var nameptr = Marshal.StringToHGlobalAnsi(name);
            int ret;
            try
            {
                ret = lib.sv_new_module(slot, typeptr, nameptr, x, y, z);
            }
            finally
            {
                Marshal.FreeHGlobal(typeptr);
                Marshal.FreeHGlobal(nameptr);
            }
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_new_module));
            return ret;
        }

        /// <summary>
        /// Remove an existing module.
        /// <para>Use <see cref="LockSlot(ISunVoxLib, int)"/> or an alternative!</para>
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="module"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void RemoveModule(this ISunVoxLib lib, int slot, int module)
        {
            var ret = lib.sv_remove_module(slot, module);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_remove_module));
        }

        /// <summary>
        /// Load a sample (xi, wav, aiff) to an existing Sampler module from file.
        /// Set <paramref name="sampleSlot"/> to -1 to apply the sample to all sample slots.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="module"></param>
        /// <param name="path"></param>
        /// <param name="sampleSlot"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void LoadSample(this ISunVoxLib lib, int slot, int module, string path, int sampleSlot = -1)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = lib.sv_sampler_load(slot, module, ptr, sampleSlot);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_sampler_load));
        }

        /// <summary>
        /// Load a sample (xi, wav, aiff) to an existing Sampler module from memory.
        /// Set <paramref name="sampleSlot"/> to -1 to apply the sample to all sample slots.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="module"></param>
        /// <param name="path"></param>
        /// <param name="sampleSlot"></param>
        /// <exception cref="SunVoxException"></exception>
        public static void LoadSample(this ISunVoxLib lib, int slot, int module, byte[] data, int sampleSlot = -1)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = lib.sv_sampler_load_from_memory(slot, module, handle.AddrOfPinnedObject(), (uint)data.Length, sampleSlot);
            }
            finally
            {
                handle.Free();
            }
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_sampler_load_from_memory));
        }

        #endregion module

        #region pattern

        /// <summary>
        /// Get the upper pattern count, which may be greater than the actual pattern count.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        /// <exception cref="SunVoxException"></exception>
        public static int GetUpperPatternCount(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_number_of_patterns(slot);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_number_of_patterns));
            return ret;
        }

        /// <summary>
        /// Find pattern by name.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="name"></param>
        /// <returns>Pattern Id, or -1 if pattern was not found.</returns>
        /// <exception cref="SunVoxException"></exception>
        public static int FindPattern(this ISunVoxLib lib, int slot, string name)
        {
            var ptr = Marshal.StringToHGlobalAnsi(name);
            int ret;
            try
            {
                ret = lib.sv_find_pattern(slot, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            if (ret < -1)
                throw new SunVoxException(ret, nameof(lib.sv_find_pattern));

            return ret;
        }

        public static int GetPatternEventValue(this ISunVoxLib lib, int slot, int pattern, int track, int line, Column column)
        {
            var ret = lib.sv_get_pattern_event(slot, pattern, track, line, (int)column);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_pattern_event));
            return ret;
        }

        public static int GetPatternLines(this ISunVoxLib lib, int slot, int pattern)
        {
            var ret = lib.sv_get_pattern_lines(slot, pattern);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_pattern_lines));
            return ret;
        }

        public static string GetPatternName(this ISunVoxLib lib, int slot, int pattern)
        {
            var ptr = lib.sv_get_pattern_name(slot, pattern);
            if (ptr == IntPtr.Zero)
                return null;

            return Marshal.PtrToStringAnsi(ptr);
        }

        public static bool GetPatternExists(this ISunVoxLib lib, int slot, int pattern)
        {
            return GetPatternLines(lib, slot, pattern) > 0;
        }

        public static int GetPatternTracks(this ISunVoxLib lib, int slot, int pattern)
        {
            var ret = lib.sv_get_pattern_tracks(slot, pattern);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_pattern_tracks));
            return ret;
        }

        public static (int x, int y) GetPatternPosition(this ISunVoxLib lib, int slot, int pattern)
        {
            return (lib.sv_get_pattern_x(slot, pattern), lib.sv_get_pattern_y(slot, pattern));
        }

        public static int GetPatternX(this ISunVoxLib lib, int slot, int pattern)
        {
            return lib.sv_get_pattern_x(slot, pattern);
        }

        public static int GetPatternY(this ISunVoxLib lib, int slot, int pattern)
        {
            return lib.sv_get_pattern_y(slot, pattern);
        }

        public static PatternEvent[] GetPatternData(this ISunVoxLib lib, int slot, int pattern)
        {
            if (!GetPatternExists(lib, slot, pattern))
                return null;

            int lines = GetPatternLines(lib, slot, pattern);
            int tracks = GetPatternTracks(lib, slot, pattern);

            var ptr = lib.sv_get_pattern_data(slot, pattern);
            if (ptr == IntPtr.Zero)
                return null;
            try
            {
                var arr = new PatternEvent[lines * tracks];
                for (int i = 0; i < lines * tracks; i++)
                    arr[i] = (ulong)Marshal.ReadInt64(ptr, i * sizeof(ulong));
                return arr;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///
        /// <para>Use <see cref="LockSlot(ISunVoxLib, int)"/> or an alternative!</para>
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="slot"></param>
        /// <param name="pattern"></param>
        /// <param name="muted"></param>
        /// <returns></returns>
        /// <exception cref="SunVoxException"></exception>
        public static bool PatternMute(this ISunVoxLib lib, int slot, int pattern, bool muted)
        {
            var ret = lib.sv_pattern_mute(slot, pattern, muted ? 1 : 0);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_pattern_mute));
            return ret == 1;
        }

        public static void SetPatternEvent(this ISunVoxLib lib, int slot, int pattern, int track, int line, int NN, int VV, int MM, int CCEE, int XXYY)
        {
            var ret = lib.sv_set_pattern_event(slot, pattern, track, line, NN, VV, MM, CCEE, XXYY);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_set_pattern_event));
        }

        public static void SetPatternEvent(this ISunVoxLib lib, int slot, int pattern, int track, int line, PatternEvent ev)
        {
            var ret = lib.sv_set_pattern_event(slot, pattern, track, line, ev.NN, ev.VV, ev.MM, ev.CCEE, ev.XXYY);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_set_pattern_event));
        }

        #endregion pattern

        #endregion slot
    }
}
