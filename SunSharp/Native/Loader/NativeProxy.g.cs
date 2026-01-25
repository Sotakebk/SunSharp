/*
 * Do not modify this file manually.
*/

#nullable enable

using System;

namespace SunSharp.Native.Loader
{
    public sealed partial class NativeProxy : ISunVoxLibC
    {
        #region delegate definitions

        private delegate IntPtr ReturnsIntPtrTakesInt(int arg1);

        private delegate IntPtr ReturnsIntPtrTakesIntInt(int arg1, int arg2);

        private delegate IntPtr ReturnsIntPtrTakesIntIntInt(int arg1, int arg2, int arg3);

        private delegate IntPtr ReturnsIntPtrTakesIntIntPtr(int arg1, IntPtr arg2);

        private delegate int ReturnsintTakesInt(int arg1);

        private delegate int ReturnsintTakesIntInt(int arg1, int arg2);

        private delegate int ReturnsintTakesIntIntInt(int arg1, int arg2, int arg3);

        private delegate int ReturnsintTakesIntIntIntInt(int arg1, int arg2, int arg3, int arg4);

        private delegate int ReturnsintTakesIntIntIntIntInt(int arg1, int arg2, int arg3, int arg4, int arg5);

        private delegate int ReturnsintTakesIntIntIntIntIntInt(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6);

        private delegate int ReturnsintTakesIntIntIntIntIntIntInt(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7);

        private delegate int ReturnsintTakesIntIntIntIntIntIntIntIntInt(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9);

        private delegate int ReturnsintTakesIntIntIntIntIntIntIntIntPtr(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, IntPtr arg8);

        private delegate int ReturnsintTakesIntIntIntIntPtrInt(int arg1, int arg2, int arg3, IntPtr arg4, int arg5);

        private delegate int ReturnsintTakesIntIntIntIntPtrIntInt(int arg1, int arg2, int arg3, IntPtr arg4, int arg5, int arg6);

        private delegate int ReturnsintTakesIntIntIntPtr(int arg1, int arg2, IntPtr arg3);

        private delegate int ReturnsintTakesIntIntIntPtrInt(int arg1, int arg2, IntPtr arg3, int arg4);

        private delegate int ReturnsintTakesIntIntIntPtrUint(int arg1, int arg2, IntPtr arg3, uint arg4);

        private delegate int ReturnsintTakesIntIntIntPtrUintInt(int arg1, int arg2, IntPtr arg3, uint arg4, int arg5);

        private delegate int ReturnsintTakesIntIntPtr(int arg1, IntPtr arg2);

        private delegate int ReturnsintTakesIntIntPtrIntIntInt(int arg1, IntPtr arg2, int arg3, int arg4, int arg5);

        private delegate int ReturnsintTakesIntIntPtrIntPtrIntIntInt(int arg1, IntPtr arg2, IntPtr arg3, int arg4, int arg5, int arg6);

        private delegate int ReturnsintTakesIntIntPtrUint(int arg1, IntPtr arg2, uint arg3);

        private delegate int ReturnsintTakesIntIntPtrUintIntIntInt(int arg1, IntPtr arg2, uint arg3, int arg4, int arg5, int arg6);

        private delegate int ReturnsintTakesIntPtrIntIntUint(IntPtr arg1, int arg2, int arg3, uint arg4);

        private delegate int ReturnsintTakesIntPtrIntIntUintIntIntIntPtr(IntPtr arg1, int arg2, int arg3, uint arg4, int arg5, int arg6, IntPtr arg7);

        private delegate int ReturnsintTakesVoid();

        private delegate uint ReturnsuintTakesInt(int arg1);

        private delegate uint ReturnsuintTakesIntInt(int arg1, int arg2);

        private delegate uint ReturnsuintTakesIntIntIntIntPtrUint(int arg1, int arg2, int arg3, IntPtr arg4, uint arg5);

        private delegate uint ReturnsuintTakesVoid();

        #endregion delegate definitions

        #region delegates

        private ReturnsintTakesIntPtrIntIntUint? sv_audio_callback;

        private ReturnsintTakesIntPtrIntIntUintIntIntIntPtr? sv_audio_callback2;

        private ReturnsintTakesInt? sv_close_slot;

        private ReturnsintTakesIntIntInt? sv_connect_module;

        private ReturnsintTakesVoid? sv_deinit;

        private ReturnsintTakesIntIntInt? sv_disconnect_module;

        private ReturnsintTakesInt? sv_end_of_song;

        private ReturnsintTakesIntIntPtr? sv_find_module;

        private ReturnsintTakesIntIntPtr? sv_find_pattern;

        private ReturnsintTakesInt? sv_get_autostop;

        private ReturnsintTakesInt? sv_get_base_version;

        private ReturnsintTakesInt? sv_get_current_line;

        private ReturnsintTakesInt? sv_get_current_line2;

        private ReturnsintTakesIntInt? sv_get_current_signal_level;

        private ReturnsIntPtrTakesInt? sv_get_log;

        private ReturnsintTakesIntInt? sv_get_module_color;

        private ReturnsintTakesIntIntInt? sv_get_module_ctl_group;

        private ReturnsintTakesIntIntIntInt? sv_get_module_ctl_max;

        private ReturnsintTakesIntIntIntInt? sv_get_module_ctl_min;

        private ReturnsIntPtrTakesIntIntInt? sv_get_module_ctl_name;

        private ReturnsintTakesIntIntInt? sv_get_module_ctl_offset;

        private ReturnsintTakesIntIntInt? sv_get_module_ctl_type;

        private ReturnsintTakesIntIntIntInt? sv_get_module_ctl_value;

        private ReturnsuintTakesIntInt? sv_get_module_finetune;

        private ReturnsuintTakesIntInt? sv_get_module_flags;

        private ReturnsIntPtrTakesIntInt? sv_get_module_inputs;

        private ReturnsIntPtrTakesIntInt? sv_get_module_name;

        private ReturnsIntPtrTakesIntInt? sv_get_module_outputs;

        private ReturnsuintTakesIntIntIntIntPtrUint? sv_get_module_scope2;

        private ReturnsIntPtrTakesIntInt? sv_get_module_type;

        private ReturnsuintTakesIntInt? sv_get_module_xy;

        private ReturnsintTakesIntInt? sv_get_number_of_module_ctls;

        private ReturnsintTakesInt? sv_get_number_of_modules;

        private ReturnsintTakesInt? sv_get_number_of_patterns;

        private ReturnsIntPtrTakesIntInt? sv_get_pattern_data;

        private ReturnsintTakesIntIntIntIntInt? sv_get_pattern_event;

        private ReturnsintTakesIntInt? sv_get_pattern_lines;

        private ReturnsIntPtrTakesIntInt? sv_get_pattern_name;

        private ReturnsintTakesIntInt? sv_get_pattern_tracks;

        private ReturnsintTakesIntInt? sv_get_pattern_x;

        private ReturnsintTakesIntInt? sv_get_pattern_y;

        private ReturnsintTakesVoid? sv_get_sample_rate;

        private ReturnsintTakesInt? sv_get_song_bpm;

        private ReturnsuintTakesInt? sv_get_song_length_frames;

        private ReturnsuintTakesInt? sv_get_song_length_lines;

        private ReturnsIntPtrTakesInt? sv_get_song_name;

        private ReturnsintTakesInt? sv_get_song_tpl;

        private ReturnsuintTakesVoid? sv_get_ticks;

        private ReturnsuintTakesVoid? sv_get_ticks_per_second;

        private ReturnsintTakesIntIntIntIntPtrInt? sv_get_time_map;

        private ReturnsintTakesIntPtrIntIntUint? sv_init;

        private ReturnsintTakesIntIntPtr? sv_load;

        private ReturnsintTakesIntIntPtrUint? sv_load_from_memory;

        private ReturnsintTakesIntIntPtrIntIntInt? sv_load_module;

        private ReturnsintTakesIntIntPtrUintIntIntInt? sv_load_module_from_memory;

        private ReturnsintTakesInt? sv_lock_slot;

        private ReturnsintTakesIntIntIntPtr? sv_metamodule_load;

        private ReturnsintTakesIntIntIntPtrUint? sv_metamodule_load_from_memory;

        private ReturnsintTakesIntIntIntIntPtrIntInt? sv_module_curve;

        private ReturnsintTakesIntIntPtrIntPtrIntIntInt? sv_new_module;

        private ReturnsintTakesIntIntIntIntIntIntIntIntPtr? sv_new_pattern;

        private ReturnsintTakesInt? sv_open_slot;

        private ReturnsintTakesIntIntInt? sv_pattern_mute;

        private ReturnsintTakesInt? sv_pause;

        private ReturnsintTakesInt? sv_play;

        private ReturnsintTakesInt? sv_play_from_beginning;

        private ReturnsintTakesIntInt? sv_remove_module;

        private ReturnsintTakesIntInt? sv_remove_pattern;

        private ReturnsintTakesInt? sv_resume;

        private ReturnsintTakesIntInt? sv_rewind;

        private ReturnsintTakesIntIntIntPtrInt? sv_sampler_load;

        private ReturnsintTakesIntIntIntPtrUintInt? sv_sampler_load_from_memory;

        private ReturnsintTakesIntIntIntIntIntInt? sv_sampler_par;

        private ReturnsintTakesIntIntPtr? sv_save;

        private ReturnsIntPtrTakesIntIntPtr? sv_save_to_memory;

        private ReturnsintTakesIntIntIntIntIntIntInt? sv_send_event;

        private ReturnsintTakesIntInt? sv_set_autostop;

        private ReturnsintTakesIntIntInt? sv_set_event_t;

        private ReturnsintTakesIntIntInt? sv_set_module_color;

        private ReturnsintTakesIntIntIntIntInt? sv_set_module_ctl_value;

        private ReturnsintTakesIntIntInt? sv_set_module_finetune;

        private ReturnsintTakesIntIntIntPtr? sv_set_module_name;

        private ReturnsintTakesIntIntInt? sv_set_module_relnote;

        private ReturnsintTakesIntIntIntInt? sv_set_module_xy;

        private ReturnsintTakesIntIntIntIntIntIntIntIntInt? sv_set_pattern_event;

        private ReturnsintTakesIntIntIntPtr? sv_set_pattern_name;

        private ReturnsintTakesIntIntIntInt? sv_set_pattern_size;

        private ReturnsintTakesIntIntIntInt? sv_set_pattern_xy;

        private ReturnsintTakesIntIntPtr? sv_set_song_name;

        private ReturnsintTakesInt? sv_stop;

        private ReturnsintTakesInt? sv_sync_resume;

        private ReturnsintTakesInt? sv_unlock_slot;

        private ReturnsintTakesVoid? sv_update_input;

        private ReturnsintTakesIntInt? sv_volume;

        private ReturnsintTakesIntIntIntPtr? sv_vplayer_load;

        private ReturnsintTakesIntIntIntPtrUint? sv_vplayer_load_from_memory;

        #endregion delegates

        #region interface

        int ISunVoxLibC.sv_audio_callback(IntPtr buf, int frames, int latency, uint out_time) => sv_audio_callback?.Invoke(buf, frames, latency, out_time) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_audio_callback2(IntPtr buf, int frames, int latency, uint out_time, int in_type, int in_channels, IntPtr in_buf) => sv_audio_callback2?.Invoke(buf, frames, latency, out_time, in_type, in_channels, in_buf) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_close_slot(int slot) => sv_close_slot?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_connect_module(int slot, int source, int destination) => sv_connect_module?.Invoke(slot, source, destination) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_deinit() => sv_deinit?.Invoke() ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_disconnect_module(int slot, int source, int destination) => sv_disconnect_module?.Invoke(slot, source, destination) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_end_of_song(int slot) => sv_end_of_song?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_find_module(int slot, IntPtr name) => sv_find_module?.Invoke(slot, name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_find_pattern(int slot, IntPtr name) => sv_find_pattern?.Invoke(slot, name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_autostop(int slot) => sv_get_autostop?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_base_version(int slot) => sv_get_base_version?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_current_line(int slot) => sv_get_current_line?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_current_line2(int slot) => sv_get_current_line2?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_current_signal_level(int slot, int channel) => sv_get_current_signal_level?.Invoke(slot, channel) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_log(int size) => sv_get_log?.Invoke(size) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_module_color(int slot, int mod_num) => sv_get_module_color?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_module_ctl_group(int slot, int mod_num, int ctl_num) => sv_get_module_ctl_group?.Invoke(slot, mod_num, ctl_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_module_ctl_max(int slot, int mod_num, int ctl_num, int scaled) => sv_get_module_ctl_max?.Invoke(slot, mod_num, ctl_num, scaled) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_module_ctl_min(int slot, int mod_num, int ctl_num, int scaled) => sv_get_module_ctl_min?.Invoke(slot, mod_num, ctl_num, scaled) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_module_ctl_name(int slot, int mod_num, int ctl_num) => sv_get_module_ctl_name?.Invoke(slot, mod_num, ctl_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_module_ctl_offset(int slot, int mod_num, int ctl_num) => sv_get_module_ctl_offset?.Invoke(slot, mod_num, ctl_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_module_ctl_type(int slot, int mod_num, int ctl_num) => sv_get_module_ctl_type?.Invoke(slot, mod_num, ctl_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_module_ctl_value(int slot, int mod_num, int ctl_num, int scaled) => sv_get_module_ctl_value?.Invoke(slot, mod_num, ctl_num, scaled) ?? throw GetNoDelegateException();

        uint ISunVoxLibC.sv_get_module_finetune(int slot, int mod_num) => sv_get_module_finetune?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        uint ISunVoxLibC.sv_get_module_flags(int slot, int mod_num) => sv_get_module_flags?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_module_inputs(int slot, int mod_num) => sv_get_module_inputs?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_module_name(int slot, int mod_num) => sv_get_module_name?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_module_outputs(int slot, int mod_num) => sv_get_module_outputs?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        uint ISunVoxLibC.sv_get_module_scope2(int slot, int mod_num, int channel, IntPtr dest_buf, uint samples_to_read) => sv_get_module_scope2?.Invoke(slot, mod_num, channel, dest_buf, samples_to_read) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_module_type(int slot, int mod_num) => sv_get_module_type?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        uint ISunVoxLibC.sv_get_module_xy(int slot, int mod_num) => sv_get_module_xy?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_number_of_module_ctls(int slot, int mod_num) => sv_get_number_of_module_ctls?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_number_of_modules(int slot) => sv_get_number_of_modules?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_number_of_patterns(int slot) => sv_get_number_of_patterns?.Invoke(slot) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_pattern_data(int slot, int pat_num) => sv_get_pattern_data?.Invoke(slot, pat_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_pattern_event(int slot, int pat_num, int track, int line, int column) => sv_get_pattern_event?.Invoke(slot, pat_num, track, line, column) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_pattern_lines(int slot, int pat_num) => sv_get_pattern_lines?.Invoke(slot, pat_num) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_pattern_name(int slot, int pat_num) => sv_get_pattern_name?.Invoke(slot, pat_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_pattern_tracks(int slot, int pat_num) => sv_get_pattern_tracks?.Invoke(slot, pat_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_pattern_x(int slot, int pat_num) => sv_get_pattern_x?.Invoke(slot, pat_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_pattern_y(int slot, int pat_num) => sv_get_pattern_y?.Invoke(slot, pat_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_sample_rate() => sv_get_sample_rate?.Invoke() ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_song_bpm(int slot) => sv_get_song_bpm?.Invoke(slot) ?? throw GetNoDelegateException();

        uint ISunVoxLibC.sv_get_song_length_frames(int slot) => sv_get_song_length_frames?.Invoke(slot) ?? throw GetNoDelegateException();

        uint ISunVoxLibC.sv_get_song_length_lines(int slot) => sv_get_song_length_lines?.Invoke(slot) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_get_song_name(int slot) => sv_get_song_name?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_song_tpl(int slot) => sv_get_song_tpl?.Invoke(slot) ?? throw GetNoDelegateException();

        uint ISunVoxLibC.sv_get_ticks() => sv_get_ticks?.Invoke() ?? throw GetNoDelegateException();

        uint ISunVoxLibC.sv_get_ticks_per_second() => sv_get_ticks_per_second?.Invoke() ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_get_time_map(int slot, int start_line, int len, IntPtr dest, int flags) => sv_get_time_map?.Invoke(slot, start_line, len, dest, flags) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_init(IntPtr config, int freq, int channels, uint flags) => sv_init?.Invoke(config, freq, channels, flags) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_load(int slot, IntPtr name) => sv_load?.Invoke(slot, name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_load_from_memory(int slot, IntPtr data, uint data_size) => sv_load_from_memory?.Invoke(slot, data, data_size) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_load_module(int slot, IntPtr file_name, int x, int y, int z) => sv_load_module?.Invoke(slot, file_name, x, y, z) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_load_module_from_memory(int slot, IntPtr data, uint data_size, int x, int y, int z) => sv_load_module_from_memory?.Invoke(slot, data, data_size, x, y, z) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_lock_slot(int slot) => sv_lock_slot?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_metamodule_load(int slot, int mod_num, IntPtr file_name) => sv_metamodule_load?.Invoke(slot, mod_num, file_name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_metamodule_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size) => sv_metamodule_load_from_memory?.Invoke(slot, mod_num, data, data_size) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_module_curve(int slot, int mod_num, int curve_num, IntPtr data, int len, int w) => sv_module_curve?.Invoke(slot, mod_num, curve_num, data, len, w) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_new_module(int slot, IntPtr type, IntPtr name, int x, int y, int z) => sv_new_module?.Invoke(slot, type, name, x, y, z) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_new_pattern(int slot, int clone, int x, int y, int tracks, int lines, int icon_seed, IntPtr name) => sv_new_pattern?.Invoke(slot, clone, x, y, tracks, lines, icon_seed, name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_open_slot(int slot) => sv_open_slot?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_pattern_mute(int slot, int pat_num, int mute) => sv_pattern_mute?.Invoke(slot, pat_num, mute) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_pause(int slot) => sv_pause?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_play(int slot) => sv_play?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_play_from_beginning(int slot) => sv_play_from_beginning?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_remove_module(int slot, int mod_num) => sv_remove_module?.Invoke(slot, mod_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_remove_pattern(int slot, int pat_num) => sv_remove_pattern?.Invoke(slot, pat_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_resume(int slot) => sv_resume?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_rewind(int slot, int line_num) => sv_rewind?.Invoke(slot, line_num) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_sampler_load(int slot, int mod_num, IntPtr file_name, int sample_slot) => sv_sampler_load?.Invoke(slot, mod_num, file_name, sample_slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_sampler_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size, int sample_slot) => sv_sampler_load_from_memory?.Invoke(slot, mod_num, data, data_size, sample_slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_sampler_par(int slot, int mod_num, int sample_slot, int par, int par_val, int set) => sv_sampler_par?.Invoke(slot, mod_num, sample_slot, par, par_val, set) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_save(int slot, IntPtr name) => sv_save?.Invoke(slot, name) ?? throw GetNoDelegateException();

        IntPtr ISunVoxLibC.sv_save_to_memory(int slot, IntPtr size) => sv_save_to_memory?.Invoke(slot, size) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_send_event(int slot, int track_num, int note, int vel, int module, int ctl, int ctl_val) => sv_send_event?.Invoke(slot, track_num, note, vel, module, ctl, ctl_val) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_autostop(int slot, int autostop) => sv_set_autostop?.Invoke(slot, autostop) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_event_t(int slot, int set, int t) => sv_set_event_t?.Invoke(slot, set, t) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_module_color(int slot, int mod_num, int color) => sv_set_module_color?.Invoke(slot, mod_num, color) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_module_ctl_value(int slot, int mod_num, int ctl_num, int val, int scaled) => sv_set_module_ctl_value?.Invoke(slot, mod_num, ctl_num, val, scaled) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_module_finetune(int slot, int mod_num, int finetune) => sv_set_module_finetune?.Invoke(slot, mod_num, finetune) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_module_name(int slot, int mod_num, IntPtr name) => sv_set_module_name?.Invoke(slot, mod_num, name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_module_relnote(int slot, int mod_num, int relative_note) => sv_set_module_relnote?.Invoke(slot, mod_num, relative_note) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_module_xy(int slot, int mod_num, int x, int y) => sv_set_module_xy?.Invoke(slot, mod_num, x, y) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_pattern_event(int slot, int pat_num, int track, int line, int nn, int vv, int mm, int ccee, int xxyy) => sv_set_pattern_event?.Invoke(slot, pat_num, track, line, nn, vv, mm, ccee, xxyy) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_pattern_name(int slot, int pat_num, IntPtr name) => sv_set_pattern_name?.Invoke(slot, pat_num, name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_pattern_size(int slot, int pat_num, int tracks, int lines) => sv_set_pattern_size?.Invoke(slot, pat_num, tracks, lines) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_pattern_xy(int slot, int pat_num, int x, int y) => sv_set_pattern_xy?.Invoke(slot, pat_num, x, y) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_set_song_name(int slot, IntPtr name) => sv_set_song_name?.Invoke(slot, name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_stop(int slot) => sv_stop?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_sync_resume(int slot) => sv_sync_resume?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_unlock_slot(int slot) => sv_unlock_slot?.Invoke(slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_update_input() => sv_update_input?.Invoke() ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_volume(int slot, int vol) => sv_volume?.Invoke(slot, vol) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_vplayer_load(int slot, int mod_num, IntPtr file_name) => sv_vplayer_load?.Invoke(slot, mod_num, file_name) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_vplayer_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size) => sv_vplayer_load_from_memory?.Invoke(slot, mod_num, data, data_size) ?? throw GetNoDelegateException();

        #endregion interface

        private void FetchAndAssignDelegates()
        {
            sv_audio_callback = (ReturnsintTakesIntPtrIntIntUint)(_handler.GetFunctionByName("sv_audio_callback", typeof(ReturnsintTakesIntPtrIntIntUint)) ?? throw new InvalidOperationException("Failed to load function sv_audio_callback"));
            sv_audio_callback2 = (ReturnsintTakesIntPtrIntIntUintIntIntIntPtr)(_handler.GetFunctionByName("sv_audio_callback2", typeof(ReturnsintTakesIntPtrIntIntUintIntIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_audio_callback2"));
            sv_close_slot = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_close_slot", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_close_slot"));
            sv_connect_module = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_connect_module", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_connect_module"));
            sv_deinit = (ReturnsintTakesVoid)(_handler.GetFunctionByName("sv_deinit", typeof(ReturnsintTakesVoid)) ?? throw new InvalidOperationException("Failed to load function sv_deinit"));
            sv_disconnect_module = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_disconnect_module", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_disconnect_module"));
            sv_end_of_song = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_end_of_song", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_end_of_song"));
            sv_find_module = (ReturnsintTakesIntIntPtr)(_handler.GetFunctionByName("sv_find_module", typeof(ReturnsintTakesIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_find_module"));
            sv_find_pattern = (ReturnsintTakesIntIntPtr)(_handler.GetFunctionByName("sv_find_pattern", typeof(ReturnsintTakesIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_find_pattern"));
            sv_get_autostop = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_get_autostop", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_autostop"));
            sv_get_base_version = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_get_base_version", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_base_version"));
            sv_get_current_line = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_get_current_line", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_current_line"));
            sv_get_current_line2 = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_get_current_line2", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_current_line2"));
            sv_get_current_signal_level = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_get_current_signal_level", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_current_signal_level"));
            sv_get_log = (ReturnsIntPtrTakesInt)(_handler.GetFunctionByName("sv_get_log", typeof(ReturnsIntPtrTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_log"));
            sv_get_module_color = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_get_module_color", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_color"));
            sv_get_module_ctl_group = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_get_module_ctl_group", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_ctl_group"));
            sv_get_module_ctl_max = (ReturnsintTakesIntIntIntInt)(_handler.GetFunctionByName("sv_get_module_ctl_max", typeof(ReturnsintTakesIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_ctl_max"));
            sv_get_module_ctl_min = (ReturnsintTakesIntIntIntInt)(_handler.GetFunctionByName("sv_get_module_ctl_min", typeof(ReturnsintTakesIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_ctl_min"));
            sv_get_module_ctl_name = (ReturnsIntPtrTakesIntIntInt)(_handler.GetFunctionByName("sv_get_module_ctl_name", typeof(ReturnsIntPtrTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_ctl_name"));
            sv_get_module_ctl_offset = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_get_module_ctl_offset", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_ctl_offset"));
            sv_get_module_ctl_type = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_get_module_ctl_type", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_ctl_type"));
            sv_get_module_ctl_value = (ReturnsintTakesIntIntIntInt)(_handler.GetFunctionByName("sv_get_module_ctl_value", typeof(ReturnsintTakesIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_ctl_value"));
            sv_get_module_finetune = (ReturnsuintTakesIntInt)(_handler.GetFunctionByName("sv_get_module_finetune", typeof(ReturnsuintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_finetune"));
            sv_get_module_flags = (ReturnsuintTakesIntInt)(_handler.GetFunctionByName("sv_get_module_flags", typeof(ReturnsuintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_flags"));
            sv_get_module_inputs = (ReturnsIntPtrTakesIntInt)(_handler.GetFunctionByName("sv_get_module_inputs", typeof(ReturnsIntPtrTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_inputs"));
            sv_get_module_name = (ReturnsIntPtrTakesIntInt)(_handler.GetFunctionByName("sv_get_module_name", typeof(ReturnsIntPtrTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_name"));
            sv_get_module_outputs = (ReturnsIntPtrTakesIntInt)(_handler.GetFunctionByName("sv_get_module_outputs", typeof(ReturnsIntPtrTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_outputs"));
            sv_get_module_scope2 = (ReturnsuintTakesIntIntIntIntPtrUint)(_handler.GetFunctionByName("sv_get_module_scope2", typeof(ReturnsuintTakesIntIntIntIntPtrUint)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_scope2"));
            sv_get_module_type = (ReturnsIntPtrTakesIntInt)(_handler.GetFunctionByName("sv_get_module_type", typeof(ReturnsIntPtrTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_type"));
            sv_get_module_xy = (ReturnsuintTakesIntInt)(_handler.GetFunctionByName("sv_get_module_xy", typeof(ReturnsuintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_module_xy"));
            sv_get_number_of_module_ctls = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_get_number_of_module_ctls", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_number_of_module_ctls"));
            sv_get_number_of_modules = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_get_number_of_modules", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_number_of_modules"));
            sv_get_number_of_patterns = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_get_number_of_patterns", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_number_of_patterns"));
            sv_get_pattern_data = (ReturnsIntPtrTakesIntInt)(_handler.GetFunctionByName("sv_get_pattern_data", typeof(ReturnsIntPtrTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_pattern_data"));
            sv_get_pattern_event = (ReturnsintTakesIntIntIntIntInt)(_handler.GetFunctionByName("sv_get_pattern_event", typeof(ReturnsintTakesIntIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_pattern_event"));
            sv_get_pattern_lines = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_get_pattern_lines", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_pattern_lines"));
            sv_get_pattern_name = (ReturnsIntPtrTakesIntInt)(_handler.GetFunctionByName("sv_get_pattern_name", typeof(ReturnsIntPtrTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_pattern_name"));
            sv_get_pattern_tracks = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_get_pattern_tracks", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_pattern_tracks"));
            sv_get_pattern_x = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_get_pattern_x", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_pattern_x"));
            sv_get_pattern_y = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_get_pattern_y", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_pattern_y"));
            sv_get_sample_rate = (ReturnsintTakesVoid)(_handler.GetFunctionByName("sv_get_sample_rate", typeof(ReturnsintTakesVoid)) ?? throw new InvalidOperationException("Failed to load function sv_get_sample_rate"));
            sv_get_song_bpm = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_get_song_bpm", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_song_bpm"));
            sv_get_song_length_frames = (ReturnsuintTakesInt)(_handler.GetFunctionByName("sv_get_song_length_frames", typeof(ReturnsuintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_song_length_frames"));
            sv_get_song_length_lines = (ReturnsuintTakesInt)(_handler.GetFunctionByName("sv_get_song_length_lines", typeof(ReturnsuintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_song_length_lines"));
            sv_get_song_name = (ReturnsIntPtrTakesInt)(_handler.GetFunctionByName("sv_get_song_name", typeof(ReturnsIntPtrTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_song_name"));
            sv_get_song_tpl = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_get_song_tpl", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_song_tpl"));
            sv_get_ticks = (ReturnsuintTakesVoid)(_handler.GetFunctionByName("sv_get_ticks", typeof(ReturnsuintTakesVoid)) ?? throw new InvalidOperationException("Failed to load function sv_get_ticks"));
            sv_get_ticks_per_second = (ReturnsuintTakesVoid)(_handler.GetFunctionByName("sv_get_ticks_per_second", typeof(ReturnsuintTakesVoid)) ?? throw new InvalidOperationException("Failed to load function sv_get_ticks_per_second"));
            sv_get_time_map = (ReturnsintTakesIntIntIntIntPtrInt)(_handler.GetFunctionByName("sv_get_time_map", typeof(ReturnsintTakesIntIntIntIntPtrInt)) ?? throw new InvalidOperationException("Failed to load function sv_get_time_map"));
            sv_init = (ReturnsintTakesIntPtrIntIntUint)(_handler.GetFunctionByName("sv_init", typeof(ReturnsintTakesIntPtrIntIntUint)) ?? throw new InvalidOperationException("Failed to load function sv_init"));
            sv_load = (ReturnsintTakesIntIntPtr)(_handler.GetFunctionByName("sv_load", typeof(ReturnsintTakesIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_load"));
            sv_load_from_memory = (ReturnsintTakesIntIntPtrUint)(_handler.GetFunctionByName("sv_load_from_memory", typeof(ReturnsintTakesIntIntPtrUint)) ?? throw new InvalidOperationException("Failed to load function sv_load_from_memory"));
            sv_load_module = (ReturnsintTakesIntIntPtrIntIntInt)(_handler.GetFunctionByName("sv_load_module", typeof(ReturnsintTakesIntIntPtrIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_load_module"));
            sv_load_module_from_memory = (ReturnsintTakesIntIntPtrUintIntIntInt)(_handler.GetFunctionByName("sv_load_module_from_memory", typeof(ReturnsintTakesIntIntPtrUintIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_load_module_from_memory"));
            sv_lock_slot = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_lock_slot", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_lock_slot"));
            sv_metamodule_load = (ReturnsintTakesIntIntIntPtr)(_handler.GetFunctionByName("sv_metamodule_load", typeof(ReturnsintTakesIntIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_metamodule_load"));
            sv_metamodule_load_from_memory = (ReturnsintTakesIntIntIntPtrUint)(_handler.GetFunctionByName("sv_metamodule_load_from_memory", typeof(ReturnsintTakesIntIntIntPtrUint)) ?? throw new InvalidOperationException("Failed to load function sv_metamodule_load_from_memory"));
            sv_module_curve = (ReturnsintTakesIntIntIntIntPtrIntInt)(_handler.GetFunctionByName("sv_module_curve", typeof(ReturnsintTakesIntIntIntIntPtrIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_module_curve"));
            sv_new_module = (ReturnsintTakesIntIntPtrIntPtrIntIntInt)(_handler.GetFunctionByName("sv_new_module", typeof(ReturnsintTakesIntIntPtrIntPtrIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_new_module"));
            sv_new_pattern = (ReturnsintTakesIntIntIntIntIntIntIntIntPtr)(_handler.GetFunctionByName("sv_new_pattern", typeof(ReturnsintTakesIntIntIntIntIntIntIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_new_pattern"));
            sv_open_slot = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_open_slot", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_open_slot"));
            sv_pattern_mute = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_pattern_mute", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_pattern_mute"));
            sv_pause = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_pause", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_pause"));
            sv_play = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_play", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_play"));
            sv_play_from_beginning = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_play_from_beginning", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_play_from_beginning"));
            sv_remove_module = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_remove_module", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_remove_module"));
            sv_remove_pattern = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_remove_pattern", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_remove_pattern"));
            sv_resume = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_resume", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_resume"));
            sv_rewind = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_rewind", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_rewind"));
            sv_sampler_load = (ReturnsintTakesIntIntIntPtrInt)(_handler.GetFunctionByName("sv_sampler_load", typeof(ReturnsintTakesIntIntIntPtrInt)) ?? throw new InvalidOperationException("Failed to load function sv_sampler_load"));
            sv_sampler_load_from_memory = (ReturnsintTakesIntIntIntPtrUintInt)(_handler.GetFunctionByName("sv_sampler_load_from_memory", typeof(ReturnsintTakesIntIntIntPtrUintInt)) ?? throw new InvalidOperationException("Failed to load function sv_sampler_load_from_memory"));
            sv_sampler_par = (ReturnsintTakesIntIntIntIntIntInt)(_handler.GetFunctionByName("sv_sampler_par", typeof(ReturnsintTakesIntIntIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_sampler_par"));
            sv_save = (ReturnsintTakesIntIntPtr)(_handler.GetFunctionByName("sv_save", typeof(ReturnsintTakesIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_save"));
            sv_save_to_memory = (ReturnsIntPtrTakesIntIntPtr)(_handler.GetFunctionByName("sv_save_to_memory", typeof(ReturnsIntPtrTakesIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_save_to_memory"));
            sv_send_event = (ReturnsintTakesIntIntIntIntIntIntInt)(_handler.GetFunctionByName("sv_send_event", typeof(ReturnsintTakesIntIntIntIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_send_event"));
            sv_set_autostop = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_set_autostop", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_autostop"));
            sv_set_event_t = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_set_event_t", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_event_t"));
            sv_set_module_color = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_set_module_color", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_module_color"));
            sv_set_module_ctl_value = (ReturnsintTakesIntIntIntIntInt)(_handler.GetFunctionByName("sv_set_module_ctl_value", typeof(ReturnsintTakesIntIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_module_ctl_value"));
            sv_set_module_finetune = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_set_module_finetune", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_module_finetune"));
            sv_set_module_name = (ReturnsintTakesIntIntIntPtr)(_handler.GetFunctionByName("sv_set_module_name", typeof(ReturnsintTakesIntIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_set_module_name"));
            sv_set_module_relnote = (ReturnsintTakesIntIntInt)(_handler.GetFunctionByName("sv_set_module_relnote", typeof(ReturnsintTakesIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_module_relnote"));
            sv_set_module_xy = (ReturnsintTakesIntIntIntInt)(_handler.GetFunctionByName("sv_set_module_xy", typeof(ReturnsintTakesIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_module_xy"));
            sv_set_pattern_event = (ReturnsintTakesIntIntIntIntIntIntIntIntInt)(_handler.GetFunctionByName("sv_set_pattern_event", typeof(ReturnsintTakesIntIntIntIntIntIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_pattern_event"));
            sv_set_pattern_name = (ReturnsintTakesIntIntIntPtr)(_handler.GetFunctionByName("sv_set_pattern_name", typeof(ReturnsintTakesIntIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_set_pattern_name"));
            sv_set_pattern_size = (ReturnsintTakesIntIntIntInt)(_handler.GetFunctionByName("sv_set_pattern_size", typeof(ReturnsintTakesIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_pattern_size"));
            sv_set_pattern_xy = (ReturnsintTakesIntIntIntInt)(_handler.GetFunctionByName("sv_set_pattern_xy", typeof(ReturnsintTakesIntIntIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_set_pattern_xy"));
            sv_set_song_name = (ReturnsintTakesIntIntPtr)(_handler.GetFunctionByName("sv_set_song_name", typeof(ReturnsintTakesIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_set_song_name"));
            sv_stop = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_stop", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_stop"));
            sv_sync_resume = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_sync_resume", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_sync_resume"));
            sv_unlock_slot = (ReturnsintTakesInt)(_handler.GetFunctionByName("sv_unlock_slot", typeof(ReturnsintTakesInt)) ?? throw new InvalidOperationException("Failed to load function sv_unlock_slot"));
            sv_update_input = (ReturnsintTakesVoid)(_handler.GetFunctionByName("sv_update_input", typeof(ReturnsintTakesVoid)) ?? throw new InvalidOperationException("Failed to load function sv_update_input"));
            sv_volume = (ReturnsintTakesIntInt)(_handler.GetFunctionByName("sv_volume", typeof(ReturnsintTakesIntInt)) ?? throw new InvalidOperationException("Failed to load function sv_volume"));
            sv_vplayer_load = (ReturnsintTakesIntIntIntPtr)(_handler.GetFunctionByName("sv_vplayer_load", typeof(ReturnsintTakesIntIntIntPtr)) ?? throw new InvalidOperationException("Failed to load function sv_vplayer_load"));
            sv_vplayer_load_from_memory = (ReturnsintTakesIntIntIntPtrUint)(_handler.GetFunctionByName("sv_vplayer_load_from_memory", typeof(ReturnsintTakesIntIntIntPtrUint)) ?? throw new InvalidOperationException("Failed to load function sv_vplayer_load_from_memory"));
        }

        private void SetAllDelegatesToNull()
        {
            sv_audio_callback = null;
            sv_audio_callback2 = null;
            sv_close_slot = null;
            sv_connect_module = null;
            sv_deinit = null;
            sv_disconnect_module = null;
            sv_end_of_song = null;
            sv_find_module = null;
            sv_find_pattern = null;
            sv_get_autostop = null;
            sv_get_base_version = null;
            sv_get_current_line = null;
            sv_get_current_line2 = null;
            sv_get_current_signal_level = null;
            sv_get_log = null;
            sv_get_module_color = null;
            sv_get_module_ctl_group = null;
            sv_get_module_ctl_max = null;
            sv_get_module_ctl_min = null;
            sv_get_module_ctl_name = null;
            sv_get_module_ctl_offset = null;
            sv_get_module_ctl_type = null;
            sv_get_module_ctl_value = null;
            sv_get_module_finetune = null;
            sv_get_module_flags = null;
            sv_get_module_inputs = null;
            sv_get_module_name = null;
            sv_get_module_outputs = null;
            sv_get_module_scope2 = null;
            sv_get_module_type = null;
            sv_get_module_xy = null;
            sv_get_number_of_module_ctls = null;
            sv_get_number_of_modules = null;
            sv_get_number_of_patterns = null;
            sv_get_pattern_data = null;
            sv_get_pattern_event = null;
            sv_get_pattern_lines = null;
            sv_get_pattern_name = null;
            sv_get_pattern_tracks = null;
            sv_get_pattern_x = null;
            sv_get_pattern_y = null;
            sv_get_sample_rate = null;
            sv_get_song_bpm = null;
            sv_get_song_length_frames = null;
            sv_get_song_length_lines = null;
            sv_get_song_name = null;
            sv_get_song_tpl = null;
            sv_get_ticks = null;
            sv_get_ticks_per_second = null;
            sv_get_time_map = null;
            sv_init = null;
            sv_load = null;
            sv_load_from_memory = null;
            sv_load_module = null;
            sv_load_module_from_memory = null;
            sv_lock_slot = null;
            sv_metamodule_load = null;
            sv_metamodule_load_from_memory = null;
            sv_module_curve = null;
            sv_new_module = null;
            sv_new_pattern = null;
            sv_open_slot = null;
            sv_pattern_mute = null;
            sv_pause = null;
            sv_play = null;
            sv_play_from_beginning = null;
            sv_remove_module = null;
            sv_remove_pattern = null;
            sv_resume = null;
            sv_rewind = null;
            sv_sampler_load = null;
            sv_sampler_load_from_memory = null;
            sv_sampler_par = null;
            sv_save = null;
            sv_save_to_memory = null;
            sv_send_event = null;
            sv_set_autostop = null;
            sv_set_event_t = null;
            sv_set_module_color = null;
            sv_set_module_ctl_value = null;
            sv_set_module_finetune = null;
            sv_set_module_name = null;
            sv_set_module_relnote = null;
            sv_set_module_xy = null;
            sv_set_pattern_event = null;
            sv_set_pattern_name = null;
            sv_set_pattern_size = null;
            sv_set_pattern_xy = null;
            sv_set_song_name = null;
            sv_stop = null;
            sv_sync_resume = null;
            sv_unlock_slot = null;
            sv_update_input = null;
            sv_volume = null;
            sv_vplayer_load = null;
            sv_vplayer_load_from_memory = null;
        }
    }
}
