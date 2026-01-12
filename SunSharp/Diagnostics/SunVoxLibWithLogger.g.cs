/*
 * Do not modify this file manually.
*/

#nullable enable

using System;
using SunSharp.Native;

namespace SunSharp.Diagnostics
{
    public sealed partial class SunVoxLibWithLogger : ISunVoxLibC
    {
        int ISunVoxLibC.sv_audio_callback(IntPtr buf, int frames, int latency, uint out_time)
        {
            FormattableString? parameters = $"buf=0x{buf.ToString("X")}, frames={frames}, latency={latency}, out_time={out_time}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_audio_callback(buf, frames, latency, out_time);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_audio_callback2(IntPtr buf, int frames, int latency, uint out_time, int in_type, int in_channels, IntPtr in_buf)
        {
            FormattableString? parameters = $"buf=0x{buf.ToString("X")}, frames={frames}, latency={latency}, out_time={out_time}, in_type={in_type}, in_channels={in_channels}, in_buf=0x{in_buf.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_audio_callback2(buf, frames, latency, out_time, in_type, in_channels, in_buf);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_close_slot(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_close_slot(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_connect_module(int slot, int source, int destination)
        {
            FormattableString? parameters = $"slot={slot}, source={source}, destination={destination}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_connect_module(slot, source, destination);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_deinit()
        {
            FormattableString? parameters = null;
            Log("Starting call.", parameters, null);
            var result = _lib.sv_deinit();
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_disconnect_module(int slot, int source, int destination)
        {
            FormattableString? parameters = $"slot={slot}, source={source}, destination={destination}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_disconnect_module(slot, source, destination);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_end_of_song(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_end_of_song(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_find_module(int slot, IntPtr name)
        {
            FormattableString? parameters = $"slot={slot}, name=0x{name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_find_module(slot, name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_find_pattern(int slot, IntPtr name)
        {
            FormattableString? parameters = $"slot={slot}, name=0x{name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_find_pattern(slot, name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_autostop(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_autostop(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_current_line(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_current_line(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_current_line2(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_current_line2(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_current_signal_level(int slot, int channel)
        {
            FormattableString? parameters = $"slot={slot}, channel={channel}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_current_signal_level(slot, channel);
            Log("Finished call.", parameters, result);
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_log(int size)
        {
            FormattableString? parameters = $"size={size}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_log(size);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        int ISunVoxLibC.sv_get_module_color(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_color(slot, mod_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_module_ctl_group(int slot, int mod_num, int ctl_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, ctl_num={ctl_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_ctl_group(slot, mod_num, ctl_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_module_ctl_max(int slot, int mod_num, int ctl_num, int scaled)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, ctl_num={ctl_num}, scaled={scaled}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_ctl_max(slot, mod_num, ctl_num, scaled);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_module_ctl_min(int slot, int mod_num, int ctl_num, int scaled)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, ctl_num={ctl_num}, scaled={scaled}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_ctl_min(slot, mod_num, ctl_num, scaled);
            Log("Finished call.", parameters, result);
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_module_ctl_name(int slot, int mod_num, int ctl_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, ctl_num={ctl_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_ctl_name(slot, mod_num, ctl_num);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        int ISunVoxLibC.sv_get_module_ctl_offset(int slot, int mod_num, int ctl_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, ctl_num={ctl_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_ctl_offset(slot, mod_num, ctl_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_module_ctl_type(int slot, int mod_num, int ctl_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, ctl_num={ctl_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_ctl_type(slot, mod_num, ctl_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_module_ctl_value(int slot, int mod_num, int ctl_num, int scaled)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, ctl_num={ctl_num}, scaled={scaled}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_ctl_value(slot, mod_num, ctl_num, scaled);
            Log("Finished call.", parameters, result);
            return result;
        }


        uint ISunVoxLibC.sv_get_module_finetune(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_finetune(slot, mod_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        uint ISunVoxLibC.sv_get_module_flags(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_flags(slot, mod_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_module_inputs(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_inputs(slot, mod_num);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_module_name(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_name(slot, mod_num);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_module_outputs(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_outputs(slot, mod_num);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        uint ISunVoxLibC.sv_get_module_scope2(int slot, int mod_num, int channel, IntPtr dest_buf, uint samples_to_read)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, channel={channel}, dest_buf=0x{dest_buf.ToString("X")}, samples_to_read={samples_to_read}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_scope2(slot, mod_num, channel, dest_buf, samples_to_read);
            Log("Finished call.", parameters, result);
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_module_type(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_type(slot, mod_num);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        uint ISunVoxLibC.sv_get_module_xy(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_module_xy(slot, mod_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_number_of_module_ctls(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_number_of_module_ctls(slot, mod_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_number_of_modules(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_number_of_modules(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_number_of_patterns(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_number_of_patterns(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_pattern_data(int slot, int pat_num)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_pattern_data(slot, pat_num);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        int ISunVoxLibC.sv_get_pattern_event(int slot, int pat_num, int track, int line, int column)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}, track={track}, line={line}, column={column}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_pattern_event(slot, pat_num, track, line, column);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_pattern_lines(int slot, int pat_num)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_pattern_lines(slot, pat_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_pattern_name(int slot, int pat_num)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_pattern_name(slot, pat_num);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        int ISunVoxLibC.sv_get_pattern_tracks(int slot, int pat_num)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_pattern_tracks(slot, pat_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_pattern_x(int slot, int pat_num)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_pattern_x(slot, pat_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_pattern_y(int slot, int pat_num)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_pattern_y(slot, pat_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_sample_rate()
        {
            FormattableString? parameters = null;
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_sample_rate();
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_song_bpm(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_song_bpm(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        uint ISunVoxLibC.sv_get_song_length_frames(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_song_length_frames(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        uint ISunVoxLibC.sv_get_song_length_lines(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_song_length_lines(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        IntPtr ISunVoxLibC.sv_get_song_name(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_song_name(slot);
            Log("Finished call.", parameters, result.ToString("X"));
            return result;
        }


        int ISunVoxLibC.sv_get_song_tpl(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_song_tpl(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        uint ISunVoxLibC.sv_get_ticks()
        {
            FormattableString? parameters = null;
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_ticks();
            Log("Finished call.", parameters, result);
            return result;
        }


        uint ISunVoxLibC.sv_get_ticks_per_second()
        {
            FormattableString? parameters = null;
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_ticks_per_second();
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_get_time_map(int slot, int start_line, int len, IntPtr dest, int flags)
        {
            FormattableString? parameters = $"slot={slot}, start_line={start_line}, len={len}, dest=0x{dest.ToString("X")}, flags={flags}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_get_time_map(slot, start_line, len, dest, flags);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_init(IntPtr config, int freq, int channels, uint flags)
        {
            FormattableString? parameters = $"config=0x{config.ToString("X")}, freq={freq}, channels={channels}, flags={flags}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_init(config, freq, channels, flags);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_load(int slot, IntPtr name)
        {
            FormattableString? parameters = $"slot={slot}, name=0x{name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_load(slot, name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_load_from_memory(int slot, IntPtr data, uint data_size)
        {
            FormattableString? parameters = $"slot={slot}, data=0x{data.ToString("X")}, data_size={data_size}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_load_from_memory(slot, data, data_size);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_load_module(int slot, IntPtr file_name, int x, int y, int z)
        {
            FormattableString? parameters = $"slot={slot}, file_name=0x{file_name.ToString("X")}, x={x}, y={y}, z={z}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_load_module(slot, file_name, x, y, z);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_load_module_from_memory(int slot, IntPtr data, uint data_size, int x, int y, int z)
        {
            FormattableString? parameters = $"slot={slot}, data=0x{data.ToString("X")}, data_size={data_size}, x={x}, y={y}, z={z}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_load_module_from_memory(slot, data, data_size, x, y, z);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_lock_slot(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_lock_slot(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_metamodule_load(int slot, int mod_num, IntPtr file_name)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, file_name=0x{file_name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_metamodule_load(slot, mod_num, file_name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_metamodule_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, data=0x{data.ToString("X")}, data_size={data_size}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_metamodule_load_from_memory(slot, mod_num, data, data_size);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_module_curve(int slot, int mod_num, int curve_num, IntPtr data, int len, int w)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, curve_num={curve_num}, data=0x{data.ToString("X")}, len={len}, w={w}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_module_curve(slot, mod_num, curve_num, data, len, w);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_new_module(int slot, IntPtr type, IntPtr name, int x, int y, int z)
        {
            FormattableString? parameters = $"slot={slot}, type=0x{type.ToString("X")}, name=0x{name.ToString("X")}, x={x}, y={y}, z={z}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_new_module(slot, type, name, x, y, z);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_new_pattern(int slot, int clone, int x, int y, int tracks, int lines, int icon_seed, IntPtr name)
        {
            FormattableString? parameters = $"slot={slot}, clone={clone}, x={x}, y={y}, tracks={tracks}, lines={lines}, icon_seed={icon_seed}, name=0x{name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_new_pattern(slot, clone, x, y, tracks, lines, icon_seed, name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_open_slot(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_open_slot(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_pattern_mute(int slot, int pat_num, int mute)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}, mute={mute}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_pattern_mute(slot, pat_num, mute);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_pause(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_pause(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_play(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_play(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_play_from_beginning(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_play_from_beginning(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_remove_module(int slot, int mod_num)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_remove_module(slot, mod_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_remove_pattern(int slot, int pat_num)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_remove_pattern(slot, pat_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_resume(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_resume(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_rewind(int slot, int line_num)
        {
            FormattableString? parameters = $"slot={slot}, line_num={line_num}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_rewind(slot, line_num);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_sampler_load(int slot, int mod_num, IntPtr file_name, int sample_slot)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, file_name=0x{file_name.ToString("X")}, sample_slot={sample_slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_sampler_load(slot, mod_num, file_name, sample_slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_sampler_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size, int sample_slot)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, data=0x{data.ToString("X")}, data_size={data_size}, sample_slot={sample_slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_sampler_load_from_memory(slot, mod_num, data, data_size, sample_slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_save(int slot, IntPtr name)
        {
            FormattableString? parameters = $"slot={slot}, name=0x{name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_save(slot, name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_send_event(int slot, int track_num, int note, int vel, int module, int ctl, int ctl_val)
        {
            FormattableString? parameters = $"slot={slot}, track_num={track_num}, note={note}, vel={vel}, module={module}, ctl={ctl}, ctl_val={ctl_val}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_send_event(slot, track_num, note, vel, module, ctl, ctl_val);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_autostop(int slot, int autostop)
        {
            FormattableString? parameters = $"slot={slot}, autostop={autostop}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_autostop(slot, autostop);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_event_t(int slot, int set, int t)
        {
            FormattableString? parameters = $"slot={slot}, set={set}, t={t}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_event_t(slot, set, t);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_module_color(int slot, int mod_num, int color)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, color={color}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_module_color(slot, mod_num, color);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_module_ctl_value(int slot, int mod_num, int ctl_num, int val, int scaled)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, ctl_num={ctl_num}, val={val}, scaled={scaled}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_module_ctl_value(slot, mod_num, ctl_num, val, scaled);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_module_finetune(int slot, int mod_num, int finetune)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, finetune={finetune}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_module_finetune(slot, mod_num, finetune);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_module_name(int slot, int mod_num, IntPtr name)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, name=0x{name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_module_name(slot, mod_num, name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_module_relnote(int slot, int mod_num, int relative_note)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, relative_note={relative_note}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_module_relnote(slot, mod_num, relative_note);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_module_xy(int slot, int mod_num, int x, int y)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, x={x}, y={y}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_module_xy(slot, mod_num, x, y);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_pattern_event(int slot, int pat_num, int track, int line, int nn, int vv, int mm, int ccee, int xxyy)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}, track={track}, line={line}, nn={nn}, vv={vv}, mm={mm}, ccee={ccee}, xxyy={xxyy}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_pattern_event(slot, pat_num, track, line, nn, vv, mm, ccee, xxyy);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_pattern_name(int slot, int pat_num, IntPtr name)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}, name=0x{name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_pattern_name(slot, pat_num, name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_pattern_size(int slot, int pat_num, int tracks, int lines)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}, tracks={tracks}, lines={lines}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_pattern_size(slot, pat_num, tracks, lines);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_pattern_xy(int slot, int pat_num, int x, int y)
        {
            FormattableString? parameters = $"slot={slot}, pat_num={pat_num}, x={x}, y={y}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_pattern_xy(slot, pat_num, x, y);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_set_song_name(int slot, IntPtr name)
        {
            FormattableString? parameters = $"slot={slot}, name=0x{name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_set_song_name(slot, name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_stop(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_stop(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_sync_resume(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_sync_resume(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_unlock_slot(int slot)
        {
            FormattableString? parameters = $"slot={slot}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_unlock_slot(slot);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_update_input()
        {
            FormattableString? parameters = null;
            Log("Starting call.", parameters, null);
            var result = _lib.sv_update_input();
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_volume(int slot, int vol)
        {
            FormattableString? parameters = $"slot={slot}, vol={vol}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_volume(slot, vol);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_vplayer_load(int slot, int mod_num, IntPtr file_name)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, file_name=0x{file_name.ToString("X")}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_vplayer_load(slot, mod_num, file_name);
            Log("Finished call.", parameters, result);
            return result;
        }


        int ISunVoxLibC.sv_vplayer_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size)
        {
            FormattableString? parameters = $"slot={slot}, mod_num={mod_num}, data=0x{data.ToString("X")}, data_size={data_size}";
            Log("Starting call.", parameters, null);
            var result = _lib.sv_vplayer_load_from_memory(slot, mod_num, data, data_size);
            Log("Finished call.", parameters, result);
            return result;
        }

    }
}
