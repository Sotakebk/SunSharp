using System;
using System.Runtime.InteropServices;

namespace SunSharp.ThinWrapper
{
    public static class SunVoxHelper
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

        public static (short x, short y) PositionToXY(uint xy)
        {
            uint x = xy & 0xFFFF;
            uint y = (xy >> 16) & 0xFFFF;
            return (ToShortBitwise(x), ToShortBitwise(y));
        }

        public static (short finetune, short relativeNote) SplitFinetune(uint moduleFinetune)
        {
            uint out_finetune = moduleFinetune & 0xFFFF;
            uint out_relative_note = (moduleFinetune >> 16) & 0xFFFF;
            return (ToShortBitwise(out_finetune), ToShortBitwise(out_relative_note));
        }

        public static float PitchToFrequency(float pitch)
        {
            return (float)PitchToFrequency((double)pitch);
        }

        public static double PitchToFrequency(double pitch)
        {
            var value = (30720.0 - pitch) / 3072.0;
            value = Math.Pow(2, value) * 16.333984375;
            return value;
        }

        public static float FrequencyToPitch(float frequency)
        {
            return (float)FrequencyToPitch((double)frequency);
        }

        public static double FrequencyToPitch(double frequency)
        {
            var value = Math.Log(frequency, 2) / 16.333984375;
            value = 30720 - value * 3072;
            return (float)value;
        }

        #endregion macros

        #region audio rendering

        private static bool AudioCallbackInternal<T>(this ISunVoxLib lib, T[] outputBuffer, int latency, uint outTime)
        {
            var outHandle = GCHandle.Alloc(outputBuffer, GCHandleType.Pinned);
            IntPtr ptr = outHandle.AddrOfPinnedObject();
            int ret;
            try
            {
                ret = lib.sv_audio_callback(ptr, outputBuffer.Length, latency, outTime);
            }
            finally
            {
                outHandle.Free();
            }
            if (ret != 0 && ret != 1)
                throw new SunVoxException(ret, nameof(lib.sv_audio_callback));

            return (ret == 1);
        }

        private static bool AudioCallbackInternal<T, V>(this ISunVoxLib lib, T[] outputBuffer, V[] inputBuffer, Channels inputChannels, int latency, uint outTime, int inputType)
        {
            if (outputBuffer.Length != inputBuffer.Length)
                throw new InvalidOperationException($"Input and output buffers are of different size.");

            var outHandle = GCHandle.Alloc(outputBuffer, GCHandleType.Pinned);
            var inHandle = GCHandle.Alloc(inputBuffer, GCHandleType.Pinned);
            IntPtr outPtr = outHandle.AddrOfPinnedObject();
            IntPtr inPtr = inHandle.AddrOfPinnedObject();
            int ret;
            try
            {
                ret = lib.sv_audio_callback2(outPtr, outputBuffer.Length, latency, outTime, inputType, (int)inputChannels, inPtr);
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

        public static bool AudioCallback(this ISunVoxLib lib, float[] outputBuffer, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, latency, outTime);
        }

        public static bool AudioCallback(this ISunVoxLib lib, short[] outputBuffer, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, latency, outTime);
        }

        public static bool AudioCallback(this ISunVoxLib lib, float[] outputBuffer, float[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, inputBuffer, inputChannels, latency, outTime, 1);
        }

        public static bool AudioCallback(this ISunVoxLib lib, float[] outputBuffer, short[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, inputBuffer, inputChannels, latency, outTime, 0);
        }

        public static bool AudioCallback(this ISunVoxLib lib, short[] outputBuffer, float[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, inputBuffer, inputChannels, latency, outTime, 1);
        }

        public static bool AudioCallback(this ISunVoxLib lib, short[] outputBuffer, short[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            return AudioCallbackInternal(lib, outputBuffer, inputBuffer, inputChannels, latency, outTime, 0);
        }

        #endregion audio rendering

        #region engine

        public static Version Init(this ISunVoxLib lib, string config, int sampleRate, Channels channels, InitFlags flags)
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

        public static void Deinit(this ISunVoxLib lib)
        {
            var retCode = lib.sv_deinit();
            if (retCode != 0)
                throw new SunVoxException(retCode, nameof(lib.sv_deinit));
        }

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

        public static void UpdateInputDevices(this ISunVoxLib lib)
        {
            var ret = lib.sv_update_input();
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_update_input));
        }

        #endregion engine

        #region slot

        public static bool EndOfSong(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_end_of_song(slot);
            if (ret != 0 && ret != 1)
                throw new SunVoxException(ret, nameof(lib.sv_end_of_song));
            return ret == 1;
        }

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

        public static int GetSongLengthFrames(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_song_length_frames(slot);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_song_length_frames));
            return (int)ret;
        }

        public static int GetSongLengthLines(this ISunVoxLib lib, int slot)
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

        public static void SendEvent(this ISunVoxLib lib, int slot, int track, Event @event)
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

        public static int Volume(this ISunVoxLib lib, int slot, int volume)
        {
            var ret = lib.sv_volume(slot, volume);
            if (ret < 0 || ret > 256)
                throw new SunVoxException(ret, nameof(lib.sv_volume));
            return ret;
        }

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

        public static void LockSlot(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_lock_slot(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_lock_slot));
        }

        public static void UnlockSlot(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_unlock_slot(slot);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_unlock_slot));
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

        public static void ConnectModule(this ISunVoxLib lib, int slot, int source, int destination)
        {
            var ret = lib.sv_connect_module(slot, source, destination);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_connect_module));
        }

        public static void DisconnectModule(this ISunVoxLib lib, int slot, int source, int destination)
        {
            var ret = lib.sv_disconnect_module(slot, source, destination);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_disconnect_module));
        }

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

        public static int[] GetModuleInputs(this ISunVoxLib lib, int slot, int module)
        {
            var count = GetModuleFlags(lib, slot, module).InputCount;
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

        public static int[] GetModuleOutputs(this ISunVoxLib lib, int slot, int module)
        {
            var count = GetModuleFlags(lib, slot, module).OutputCount;
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

        public static void RemoveModule(this ISunVoxLib lib, int slot, int module)
        {
            var ret = lib.sv_remove_module(slot, module);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_remove_module));
        }

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

        public static int GetUpperPatternCount(this ISunVoxLib lib, int slot)
        {
            var ret = lib.sv_get_number_of_patterns(slot);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(lib.sv_get_number_of_patterns));
            return ret;
        }

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

        public static Event[] GetPatternData(this ISunVoxLib lib, int slot, int pattern)
        {
            if (!GetPatternExists(lib, slot, pattern))
                return null;

            int lines = GetPatternLines(lib, slot, pattern);
            int tracks = GetPatternTracks(lib, slot, pattern);

            var ptr = lib.sv_get_pattern_data(slot, pattern);
            if (ptr == null)
                return null;
            try
            {
                var arr = new Event[lines * tracks];
                for (int i = 0; i < lines * tracks; i++)
                    arr[i] = (ulong)Marshal.ReadInt64(ptr, i * sizeof(ulong));
                return arr;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

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

        public static void SetPatternEvent(this ISunVoxLib lib, int slot, int pattern, int track, int line, Event ev)
        {
            var ret = lib.sv_set_pattern_event(slot, pattern, track, line, ev.NN, ev.VV, ev.MM, ev.CCEE, ev.XXYY);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(lib.sv_set_pattern_event));
        }

        #endregion pattern

        #endregion slot
    }
}
