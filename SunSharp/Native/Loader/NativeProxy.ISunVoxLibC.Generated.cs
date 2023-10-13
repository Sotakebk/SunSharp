#pragma warning disable CS0649
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

        private delegate int ReturnsIntTakesInt(int arg1);

        private delegate int ReturnsIntTakesIntInt(int arg1, int arg2);

        private delegate int ReturnsIntTakesIntIntInt(int arg1, int arg2, int arg3);

        private delegate int ReturnsIntTakesIntIntIntInt(int arg1, int arg2, int arg3, int arg4);

        private delegate int ReturnsIntTakesIntIntIntIntInt(int arg1, int arg2, int arg3, int arg4, int arg5);

        private delegate int ReturnsIntTakesIntIntIntIntIntIntInt(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7);

        private delegate int ReturnsIntTakesIntIntIntIntIntIntIntIntInt(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9);

        private delegate int ReturnsIntTakesIntIntIntIntIntIntIntIntPtr(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, IntPtr arg8);

        private delegate int ReturnsIntTakesIntIntIntIntPtrInt(int arg1, int arg2, int arg3, IntPtr arg4, int arg5);

        private delegate int ReturnsIntTakesIntIntIntIntPtrIntInt(int arg1, int arg2, int arg3, IntPtr arg4, int arg5, int arg6);

        private delegate int ReturnsIntTakesIntIntIntPtr(int arg1, int arg2, IntPtr arg3);

        private delegate int ReturnsIntTakesIntIntIntPtrInt(int arg1, int arg2, IntPtr arg3, int arg4);

        private delegate int ReturnsIntTakesIntIntIntPtrUint(int arg1, int arg2, IntPtr arg3, uint arg4);

        private delegate int ReturnsIntTakesIntIntIntPtrUintInt(int arg1, int arg2, IntPtr arg3, uint arg4, int arg5);

        private delegate int ReturnsIntTakesIntIntPtr(int arg1, IntPtr arg2);

        private delegate int ReturnsIntTakesIntIntPtrIntIntInt(int arg1, IntPtr arg2, int arg3, int arg4, int arg5);

        private delegate int ReturnsIntTakesIntIntPtrIntPtrIntIntInt(int arg1, IntPtr arg2, IntPtr arg3, int arg4, int arg5, int arg6);

        private delegate int ReturnsIntTakesIntIntPtrUint(int arg1, IntPtr arg2, uint arg3);

        private delegate int ReturnsIntTakesIntIntPtrUintIntIntInt(int arg1, IntPtr arg2, uint arg3, int arg4, int arg5, int arg6);

        private delegate int ReturnsIntTakesIntPtrIntIntUint(IntPtr arg1, int arg2, int arg3, uint arg4);

        private delegate int ReturnsIntTakesIntPtrIntIntUintIntIntIntPtr(IntPtr arg1, int arg2, int arg3, uint arg4, int arg5, int arg6, IntPtr arg7);

        private delegate int ReturnsIntTakesVoid();

        private delegate uint ReturnsUintTakesInt(int arg1);

        private delegate uint ReturnsUintTakesIntInt(int arg1, int arg2);

        private delegate uint ReturnsUintTakesIntIntIntIntPtrUint(int arg1, int arg2, int arg3, IntPtr arg4, uint arg5);

        private delegate uint ReturnsUintTakesVoid();

        #endregion delegate definitions

        #region delegates

        private ReturnsIntTakesIntPtrIntIntUint? sv_audio_callback;

        private ReturnsIntTakesIntPtrIntIntUintIntIntIntPtr? sv_audio_callback2;

        private ReturnsIntTakesInt? sv_close_slot;

        private ReturnsIntTakesIntIntInt? sv_connect_module;

        private ReturnsIntTakesVoid? sv_deinit;

        private ReturnsIntTakesIntIntInt? sv_disconnect_module;

        private ReturnsIntTakesInt? sv_end_of_song;

        private ReturnsIntTakesIntIntPtr? sv_find_module;

        private ReturnsIntTakesIntIntPtr? sv_find_pattern;

        private ReturnsIntTakesInt? sv_get_autostop;

        private ReturnsIntTakesInt? sv_get_current_line;

        private ReturnsIntTakesInt? sv_get_current_line2;

        private ReturnsIntTakesIntInt? sv_get_current_signal_level;

        private ReturnsIntPtrTakesInt? sv_get_log;

        private ReturnsIntTakesIntInt? sv_get_module_color;

        private ReturnsIntTakesIntIntInt? sv_get_module_ctl_group;

        private ReturnsIntTakesIntIntIntInt? sv_get_module_ctl_max;

        private ReturnsIntTakesIntIntIntInt? sv_get_module_ctl_min;

        private ReturnsIntPtrTakesIntIntInt? sv_get_module_ctl_name;

        private ReturnsIntTakesIntIntInt? sv_get_module_ctl_offset;

        private ReturnsIntTakesIntIntInt? sv_get_module_ctl_type;

        private ReturnsIntTakesIntIntIntInt? sv_get_module_ctl_value;

        private ReturnsUintTakesIntInt? sv_get_module_finetune;

        private ReturnsUintTakesIntInt? sv_get_module_flags;

        private ReturnsIntPtrTakesIntInt? sv_get_module_inputs;

        private ReturnsIntPtrTakesIntInt? sv_get_module_name;

        private ReturnsIntPtrTakesIntInt? sv_get_module_outputs;

        private ReturnsUintTakesIntIntIntIntPtrUint? sv_get_module_scope2;

        private ReturnsIntPtrTakesIntInt? sv_get_module_type;

        private ReturnsUintTakesIntInt? sv_get_module_xy;

        private ReturnsIntTakesIntInt? sv_get_number_of_module_ctls;

        private ReturnsIntTakesInt? sv_get_number_of_modules;

        private ReturnsIntTakesInt? sv_get_number_of_patterns;

        private ReturnsIntPtrTakesIntInt? sv_get_pattern_data;

        private ReturnsIntTakesIntIntIntIntInt? sv_get_pattern_event;

        private ReturnsIntTakesIntInt? sv_get_pattern_lines;

        private ReturnsIntPtrTakesIntInt? sv_get_pattern_name;

        private ReturnsIntTakesIntInt? sv_get_pattern_tracks;

        private ReturnsIntTakesIntInt? sv_get_pattern_x;

        private ReturnsIntTakesIntInt? sv_get_pattern_y;

        private ReturnsIntTakesVoid? sv_get_sample_rate;

        private ReturnsIntTakesInt? sv_get_song_bpm;

        private ReturnsUintTakesInt? sv_get_song_length_frames;

        private ReturnsUintTakesInt? sv_get_song_length_lines;

        private ReturnsIntPtrTakesInt? sv_get_song_name;

        private ReturnsIntTakesInt? sv_get_song_tpl;

        private ReturnsUintTakesVoid? sv_get_ticks;

        private ReturnsUintTakesVoid? sv_get_ticks_per_second;

        private ReturnsIntTakesIntIntIntIntPtrInt? sv_get_time_map;

        private ReturnsIntTakesIntPtrIntIntUint? sv_init;

        private ReturnsIntTakesIntIntPtr? sv_load;

        private ReturnsIntTakesIntIntPtrUint? sv_load_from_memory;

        private ReturnsIntTakesIntIntPtrIntIntInt? sv_load_module;

        private ReturnsIntTakesIntIntPtrUintIntIntInt? sv_load_module_from_memory;

        private ReturnsIntTakesInt? sv_lock_slot;

        private ReturnsIntTakesIntIntIntPtr? sv_metamodule_load;

        private ReturnsIntTakesIntIntIntPtrUint? sv_metamodule_load_from_memory;

        private ReturnsIntTakesIntIntIntIntPtrIntInt? sv_module_curve;

        private ReturnsIntTakesIntIntPtrIntPtrIntIntInt? sv_new_module;

        private ReturnsIntTakesIntIntIntIntIntIntIntIntPtr? sv_new_pattern;

        private ReturnsIntTakesInt? sv_open_slot;

        private ReturnsIntTakesIntIntInt? sv_pattern_mute;

        private ReturnsIntTakesInt? sv_pause;

        private ReturnsIntTakesInt? sv_play;

        private ReturnsIntTakesInt? sv_play_from_beginning;

        private ReturnsIntTakesIntInt? sv_remove_module;

        private ReturnsIntTakesIntInt? sv_remove_pattern;

        private ReturnsIntTakesInt? sv_resume;

        private ReturnsIntTakesIntInt? sv_rewind;

        private ReturnsIntTakesIntIntIntPtrInt? sv_sampler_load;

        private ReturnsIntTakesIntIntIntPtrUintInt? sv_sampler_load_from_memory;

        private ReturnsIntTakesIntIntPtr? sv_save;

        private ReturnsIntTakesIntIntIntIntIntIntInt? sv_send_event;

        private ReturnsIntTakesIntInt? sv_set_autostop;

        private ReturnsIntTakesIntIntInt? sv_set_event_t;

        private ReturnsIntTakesIntIntInt? sv_set_module_color;

        private ReturnsIntTakesIntIntIntIntInt? sv_set_module_ctl_value;

        private ReturnsIntTakesIntIntInt? sv_set_module_finetune;

        private ReturnsIntTakesIntIntIntPtr? sv_set_module_name;

        private ReturnsIntTakesIntIntInt? sv_set_module_relnote;

        private ReturnsIntTakesIntIntIntInt? sv_set_module_xy;

        private ReturnsIntTakesIntIntIntIntIntIntIntIntInt? sv_set_pattern_event;

        private ReturnsIntTakesIntIntIntPtr? sv_set_pattern_name;

        private ReturnsIntTakesIntIntIntInt? sv_set_pattern_size;

        private ReturnsIntTakesIntIntIntInt? sv_set_pattern_xy;

        private ReturnsIntTakesIntIntPtr? sv_set_song_name;

        private ReturnsIntTakesInt? sv_stop;

        private ReturnsIntTakesInt? sv_sync_resume;

        private ReturnsIntTakesInt? sv_unlock_slot;

        private ReturnsIntTakesVoid? sv_update_input;

        private ReturnsIntTakesIntInt? sv_volume;

        private ReturnsIntTakesIntIntIntPtr? sv_vplayer_load;

        private ReturnsIntTakesIntIntIntPtrUint? sv_vplayer_load_from_memory;

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

        int ISunVoxLibC.sv_sampler_load(int slot, int sampler_module, IntPtr file_name, int sample_slot) => sv_sampler_load?.Invoke(slot, sampler_module, file_name, sample_slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_sampler_load_from_memory(int slot, int sampler_module, IntPtr data, uint data_size, int sample_slot) => sv_sampler_load_from_memory?.Invoke(slot, sampler_module, data, data_size, sample_slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_save(int slot, IntPtr name) => sv_save?.Invoke(slot, name) ?? throw GetNoDelegateException();

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

        private void LoadInternal()
        {
            sv_audio_callback = (ReturnsIntTakesIntPtrIntIntUint)_handler.GetFunctionByName("sv_audio_callback", typeof(ReturnsIntTakesIntPtrIntIntUint));
            sv_audio_callback2 = (ReturnsIntTakesIntPtrIntIntUintIntIntIntPtr)_handler.GetFunctionByName("sv_audio_callback2", typeof(ReturnsIntTakesIntPtrIntIntUintIntIntIntPtr));
            sv_close_slot = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_close_slot", typeof(ReturnsIntTakesInt));
            sv_connect_module = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_connect_module", typeof(ReturnsIntTakesIntIntInt));
            sv_deinit = (ReturnsIntTakesVoid)_handler.GetFunctionByName("sv_deinit", typeof(ReturnsIntTakesVoid));
            sv_disconnect_module = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_disconnect_module", typeof(ReturnsIntTakesIntIntInt));
            sv_end_of_song = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_end_of_song", typeof(ReturnsIntTakesInt));
            sv_find_module = (ReturnsIntTakesIntIntPtr)_handler.GetFunctionByName("sv_find_module", typeof(ReturnsIntTakesIntIntPtr));
            sv_find_pattern = (ReturnsIntTakesIntIntPtr)_handler.GetFunctionByName("sv_find_pattern", typeof(ReturnsIntTakesIntIntPtr));
            sv_get_autostop = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_get_autostop", typeof(ReturnsIntTakesInt));
            sv_get_current_line = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_get_current_line", typeof(ReturnsIntTakesInt));
            sv_get_current_line2 = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_get_current_line2", typeof(ReturnsIntTakesInt));
            sv_get_current_signal_level = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_get_current_signal_level", typeof(ReturnsIntTakesIntInt));
            sv_get_log = (ReturnsIntPtrTakesInt)_handler.GetFunctionByName("sv_get_log", typeof(ReturnsIntPtrTakesInt));
            sv_get_module_color = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_get_module_color", typeof(ReturnsIntTakesIntInt));
            sv_get_module_ctl_group = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_get_module_ctl_group", typeof(ReturnsIntTakesIntIntInt));
            sv_get_module_ctl_max = (ReturnsIntTakesIntIntIntInt)_handler.GetFunctionByName("sv_get_module_ctl_max", typeof(ReturnsIntTakesIntIntIntInt));
            sv_get_module_ctl_min = (ReturnsIntTakesIntIntIntInt)_handler.GetFunctionByName("sv_get_module_ctl_min", typeof(ReturnsIntTakesIntIntIntInt));
            sv_get_module_ctl_name = (ReturnsIntPtrTakesIntIntInt)_handler.GetFunctionByName("sv_get_module_ctl_name", typeof(ReturnsIntPtrTakesIntIntInt));
            sv_get_module_ctl_offset = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_get_module_ctl_offset", typeof(ReturnsIntTakesIntIntInt));
            sv_get_module_ctl_type = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_get_module_ctl_type", typeof(ReturnsIntTakesIntIntInt));
            sv_get_module_ctl_value = (ReturnsIntTakesIntIntIntInt)_handler.GetFunctionByName("sv_get_module_ctl_value", typeof(ReturnsIntTakesIntIntIntInt));
            sv_get_module_finetune = (ReturnsUintTakesIntInt)_handler.GetFunctionByName("sv_get_module_finetune", typeof(ReturnsUintTakesIntInt));
            sv_get_module_flags = (ReturnsUintTakesIntInt)_handler.GetFunctionByName("sv_get_module_flags", typeof(ReturnsUintTakesIntInt));
            sv_get_module_inputs = (ReturnsIntPtrTakesIntInt)_handler.GetFunctionByName("sv_get_module_inputs", typeof(ReturnsIntPtrTakesIntInt));
            sv_get_module_name = (ReturnsIntPtrTakesIntInt)_handler.GetFunctionByName("sv_get_module_name", typeof(ReturnsIntPtrTakesIntInt));
            sv_get_module_outputs = (ReturnsIntPtrTakesIntInt)_handler.GetFunctionByName("sv_get_module_outputs", typeof(ReturnsIntPtrTakesIntInt));
            sv_get_module_scope2 = (ReturnsUintTakesIntIntIntIntPtrUint)_handler.GetFunctionByName("sv_get_module_scope2", typeof(ReturnsUintTakesIntIntIntIntPtrUint));
            sv_get_module_type = (ReturnsIntPtrTakesIntInt)_handler.GetFunctionByName("sv_get_module_type", typeof(ReturnsIntPtrTakesIntInt));
            sv_get_module_xy = (ReturnsUintTakesIntInt)_handler.GetFunctionByName("sv_get_module_xy", typeof(ReturnsUintTakesIntInt));
            sv_get_number_of_module_ctls = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_get_number_of_module_ctls", typeof(ReturnsIntTakesIntInt));
            sv_get_number_of_modules = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_get_number_of_modules", typeof(ReturnsIntTakesInt));
            sv_get_number_of_patterns = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_get_number_of_patterns", typeof(ReturnsIntTakesInt));
            sv_get_pattern_data = (ReturnsIntPtrTakesIntInt)_handler.GetFunctionByName("sv_get_pattern_data", typeof(ReturnsIntPtrTakesIntInt));
            sv_get_pattern_event = (ReturnsIntTakesIntIntIntIntInt)_handler.GetFunctionByName("sv_get_pattern_event", typeof(ReturnsIntTakesIntIntIntIntInt));
            sv_get_pattern_lines = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_get_pattern_lines", typeof(ReturnsIntTakesIntInt));
            sv_get_pattern_name = (ReturnsIntPtrTakesIntInt)_handler.GetFunctionByName("sv_get_pattern_name", typeof(ReturnsIntPtrTakesIntInt));
            sv_get_pattern_tracks = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_get_pattern_tracks", typeof(ReturnsIntTakesIntInt));
            sv_get_pattern_x = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_get_pattern_x", typeof(ReturnsIntTakesIntInt));
            sv_get_pattern_y = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_get_pattern_y", typeof(ReturnsIntTakesIntInt));
            sv_get_sample_rate = (ReturnsIntTakesVoid)_handler.GetFunctionByName("sv_get_sample_rate", typeof(ReturnsIntTakesVoid));
            sv_get_song_bpm = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_get_song_bpm", typeof(ReturnsIntTakesInt));
            sv_get_song_length_frames = (ReturnsUintTakesInt)_handler.GetFunctionByName("sv_get_song_length_frames", typeof(ReturnsUintTakesInt));
            sv_get_song_length_lines = (ReturnsUintTakesInt)_handler.GetFunctionByName("sv_get_song_length_lines", typeof(ReturnsUintTakesInt));
            sv_get_song_name = (ReturnsIntPtrTakesInt)_handler.GetFunctionByName("sv_get_song_name", typeof(ReturnsIntPtrTakesInt));
            sv_get_song_tpl = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_get_song_tpl", typeof(ReturnsIntTakesInt));
            sv_get_ticks = (ReturnsUintTakesVoid)_handler.GetFunctionByName("sv_get_ticks", typeof(ReturnsUintTakesVoid));
            sv_get_ticks_per_second = (ReturnsUintTakesVoid)_handler.GetFunctionByName("sv_get_ticks_per_second", typeof(ReturnsUintTakesVoid));
            sv_get_time_map = (ReturnsIntTakesIntIntIntIntPtrInt)_handler.GetFunctionByName("sv_get_time_map", typeof(ReturnsIntTakesIntIntIntIntPtrInt));
            sv_init = (ReturnsIntTakesIntPtrIntIntUint)_handler.GetFunctionByName("sv_init", typeof(ReturnsIntTakesIntPtrIntIntUint));
            sv_load = (ReturnsIntTakesIntIntPtr)_handler.GetFunctionByName("sv_load", typeof(ReturnsIntTakesIntIntPtr));
            sv_load_from_memory = (ReturnsIntTakesIntIntPtrUint)_handler.GetFunctionByName("sv_load_from_memory", typeof(ReturnsIntTakesIntIntPtrUint));
            sv_load_module = (ReturnsIntTakesIntIntPtrIntIntInt)_handler.GetFunctionByName("sv_load_module", typeof(ReturnsIntTakesIntIntPtrIntIntInt));
            sv_load_module_from_memory = (ReturnsIntTakesIntIntPtrUintIntIntInt)_handler.GetFunctionByName("sv_load_module_from_memory", typeof(ReturnsIntTakesIntIntPtrUintIntIntInt));
            sv_lock_slot = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_lock_slot", typeof(ReturnsIntTakesInt));
            sv_metamodule_load = (ReturnsIntTakesIntIntIntPtr)_handler.GetFunctionByName("sv_metamodule_load", typeof(ReturnsIntTakesIntIntIntPtr));
            sv_metamodule_load_from_memory = (ReturnsIntTakesIntIntIntPtrUint)_handler.GetFunctionByName("sv_metamodule_load_from_memory", typeof(ReturnsIntTakesIntIntIntPtrUint));
            sv_module_curve = (ReturnsIntTakesIntIntIntIntPtrIntInt)_handler.GetFunctionByName("sv_module_curve", typeof(ReturnsIntTakesIntIntIntIntPtrIntInt));
            sv_new_module = (ReturnsIntTakesIntIntPtrIntPtrIntIntInt)_handler.GetFunctionByName("sv_new_module", typeof(ReturnsIntTakesIntIntPtrIntPtrIntIntInt));
            sv_new_pattern = (ReturnsIntTakesIntIntIntIntIntIntIntIntPtr)_handler.GetFunctionByName("sv_new_pattern", typeof(ReturnsIntTakesIntIntIntIntIntIntIntIntPtr));
            sv_open_slot = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_open_slot", typeof(ReturnsIntTakesInt));
            sv_pattern_mute = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_pattern_mute", typeof(ReturnsIntTakesIntIntInt));
            sv_pause = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_pause", typeof(ReturnsIntTakesInt));
            sv_play = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_play", typeof(ReturnsIntTakesInt));
            sv_play_from_beginning = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_play_from_beginning", typeof(ReturnsIntTakesInt));
            sv_remove_module = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_remove_module", typeof(ReturnsIntTakesIntInt));
            sv_remove_pattern = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_remove_pattern", typeof(ReturnsIntTakesIntInt));
            sv_resume = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_resume", typeof(ReturnsIntTakesInt));
            sv_rewind = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_rewind", typeof(ReturnsIntTakesIntInt));
            sv_sampler_load = (ReturnsIntTakesIntIntIntPtrInt)_handler.GetFunctionByName("sv_sampler_load", typeof(ReturnsIntTakesIntIntIntPtrInt));
            sv_sampler_load_from_memory = (ReturnsIntTakesIntIntIntPtrUintInt)_handler.GetFunctionByName("sv_sampler_load_from_memory", typeof(ReturnsIntTakesIntIntIntPtrUintInt));
            sv_save = (ReturnsIntTakesIntIntPtr)_handler.GetFunctionByName("sv_save", typeof(ReturnsIntTakesIntIntPtr));
            sv_send_event = (ReturnsIntTakesIntIntIntIntIntIntInt)_handler.GetFunctionByName("sv_send_event", typeof(ReturnsIntTakesIntIntIntIntIntIntInt));
            sv_set_autostop = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_set_autostop", typeof(ReturnsIntTakesIntInt));
            sv_set_event_t = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_set_event_t", typeof(ReturnsIntTakesIntIntInt));
            sv_set_module_color = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_set_module_color", typeof(ReturnsIntTakesIntIntInt));
            sv_set_module_ctl_value = (ReturnsIntTakesIntIntIntIntInt)_handler.GetFunctionByName("sv_set_module_ctl_value", typeof(ReturnsIntTakesIntIntIntIntInt));
            sv_set_module_finetune = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_set_module_finetune", typeof(ReturnsIntTakesIntIntInt));
            sv_set_module_name = (ReturnsIntTakesIntIntIntPtr)_handler.GetFunctionByName("sv_set_module_name", typeof(ReturnsIntTakesIntIntIntPtr));
            sv_set_module_relnote = (ReturnsIntTakesIntIntInt)_handler.GetFunctionByName("sv_set_module_relnote", typeof(ReturnsIntTakesIntIntInt));
            sv_set_module_xy = (ReturnsIntTakesIntIntIntInt)_handler.GetFunctionByName("sv_set_module_xy", typeof(ReturnsIntTakesIntIntIntInt));
            sv_set_pattern_event = (ReturnsIntTakesIntIntIntIntIntIntIntIntInt)_handler.GetFunctionByName("sv_set_pattern_event", typeof(ReturnsIntTakesIntIntIntIntIntIntIntIntInt));
            sv_set_pattern_name = (ReturnsIntTakesIntIntIntPtr)_handler.GetFunctionByName("sv_set_pattern_name", typeof(ReturnsIntTakesIntIntIntPtr));
            sv_set_pattern_size = (ReturnsIntTakesIntIntIntInt)_handler.GetFunctionByName("sv_set_pattern_size", typeof(ReturnsIntTakesIntIntIntInt));
            sv_set_pattern_xy = (ReturnsIntTakesIntIntIntInt)_handler.GetFunctionByName("sv_set_pattern_xy", typeof(ReturnsIntTakesIntIntIntInt));
            sv_set_song_name = (ReturnsIntTakesIntIntPtr)_handler.GetFunctionByName("sv_set_song_name", typeof(ReturnsIntTakesIntIntPtr));
            sv_stop = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_stop", typeof(ReturnsIntTakesInt));
            sv_sync_resume = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_sync_resume", typeof(ReturnsIntTakesInt));
            sv_unlock_slot = (ReturnsIntTakesInt)_handler.GetFunctionByName("sv_unlock_slot", typeof(ReturnsIntTakesInt));
            sv_update_input = (ReturnsIntTakesVoid)_handler.GetFunctionByName("sv_update_input", typeof(ReturnsIntTakesVoid));
            sv_volume = (ReturnsIntTakesIntInt)_handler.GetFunctionByName("sv_volume", typeof(ReturnsIntTakesIntInt));
            sv_vplayer_load = (ReturnsIntTakesIntIntIntPtr)_handler.GetFunctionByName("sv_vplayer_load", typeof(ReturnsIntTakesIntIntIntPtr));
            sv_vplayer_load_from_memory = (ReturnsIntTakesIntIntIntPtrUint)_handler.GetFunctionByName("sv_vplayer_load_from_memory", typeof(ReturnsIntTakesIntIntIntPtrUint));
        }

        private void UnloadInternal()
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
            sv_save = null;
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
