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

        private delegate IntPtr ReturnsIntPtrTakesint(int arg1);

        private delegate IntPtr ReturnsIntPtrTakesintint(int arg1, int arg2);

        private delegate IntPtr ReturnsIntPtrTakesintintint(int arg1, int arg2, int arg3);

        private delegate int ReturnsintTakesint(int arg1);

        private delegate int ReturnsintTakesintint(int arg1, int arg2);

        private delegate int ReturnsintTakesintintint(int arg1, int arg2, int arg3);

        private delegate int ReturnsintTakesintintintint(int arg1, int arg2, int arg3, int arg4);

        private delegate int ReturnsintTakesintintintintint(int arg1, int arg2, int arg3, int arg4, int arg5);

        private delegate int ReturnsintTakesintintintintintintint(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7);

        private delegate int ReturnsintTakesintintintintintintintintint(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9);

        private delegate int ReturnsintTakesintintintintintintintIntPtr(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, IntPtr arg8);

        private delegate int ReturnsintTakesintintintIntPtrint(int arg1, int arg2, int arg3, IntPtr arg4, int arg5);

        private delegate int ReturnsintTakesintintintIntPtrintint(int arg1, int arg2, int arg3, IntPtr arg4, int arg5, int arg6);

        private delegate int ReturnsintTakesintintIntPtr(int arg1, int arg2, IntPtr arg3);

        private delegate int ReturnsintTakesintintIntPtrint(int arg1, int arg2, IntPtr arg3, int arg4);

        private delegate int ReturnsintTakesintintIntPtruint(int arg1, int arg2, IntPtr arg3, uint arg4);

        private delegate int ReturnsintTakesintintIntPtruintint(int arg1, int arg2, IntPtr arg3, uint arg4, int arg5);

        private delegate int ReturnsintTakesintIntPtr(int arg1, IntPtr arg2);

        private delegate int ReturnsintTakesintIntPtrintintint(int arg1, IntPtr arg2, int arg3, int arg4, int arg5);

        private delegate int ReturnsintTakesintIntPtrIntPtrintintint(int arg1, IntPtr arg2, IntPtr arg3, int arg4, int arg5, int arg6);

        private delegate int ReturnsintTakesintIntPtruint(int arg1, IntPtr arg2, uint arg3);

        private delegate int ReturnsintTakesintIntPtruintintintint(int arg1, IntPtr arg2, uint arg3, int arg4, int arg5, int arg6);

        private delegate int ReturnsintTakesIntPtrintintuint(IntPtr arg1, int arg2, int arg3, uint arg4);

        private delegate int ReturnsintTakesIntPtrintintuintintintIntPtr(IntPtr arg1, int arg2, int arg3, uint arg4, int arg5, int arg6, IntPtr arg7);

        private delegate int ReturnsintTakesVoid();

        private delegate uint ReturnsuintTakesint(int arg1);

        private delegate uint ReturnsuintTakesintint(int arg1, int arg2);

        private delegate uint ReturnsuintTakesintintintIntPtruint(int arg1, int arg2, int arg3, IntPtr arg4, uint arg5);

        private delegate uint ReturnsuintTakesVoid();

        #endregion delegate definitions

        #region delegates

        private ReturnsintTakesIntPtrintintuint? sv_audio_callback;

        private ReturnsintTakesIntPtrintintuintintintIntPtr? sv_audio_callback2;

        private ReturnsintTakesint? sv_close_slot;

        private ReturnsintTakesintintint? sv_connect_module;

        private ReturnsintTakesVoid? sv_deinit;

        private ReturnsintTakesintintint? sv_disconnect_module;

        private ReturnsintTakesint? sv_end_of_song;

        private ReturnsintTakesintIntPtr? sv_find_module;

        private ReturnsintTakesintIntPtr? sv_find_pattern;

        private ReturnsintTakesint? sv_get_autostop;

        private ReturnsintTakesint? sv_get_current_line;

        private ReturnsintTakesint? sv_get_current_line2;

        private ReturnsintTakesintint? sv_get_current_signal_level;

        private ReturnsIntPtrTakesint? sv_get_log;

        private ReturnsintTakesintint? sv_get_module_color;

        private ReturnsintTakesintintint? sv_get_module_ctl_group;

        private ReturnsintTakesintintintint? sv_get_module_ctl_max;

        private ReturnsintTakesintintintint? sv_get_module_ctl_min;

        private ReturnsIntPtrTakesintintint? sv_get_module_ctl_name;

        private ReturnsintTakesintintint? sv_get_module_ctl_offset;

        private ReturnsintTakesintintint? sv_get_module_ctl_type;

        private ReturnsintTakesintintintint? sv_get_module_ctl_value;

        private ReturnsuintTakesintint? sv_get_module_finetune;

        private ReturnsuintTakesintint? sv_get_module_flags;

        private ReturnsIntPtrTakesintint? sv_get_module_inputs;

        private ReturnsIntPtrTakesintint? sv_get_module_name;

        private ReturnsIntPtrTakesintint? sv_get_module_outputs;

        private ReturnsuintTakesintintintIntPtruint? sv_get_module_scope2;

        private ReturnsIntPtrTakesintint? sv_get_module_type;

        private ReturnsuintTakesintint? sv_get_module_xy;

        private ReturnsintTakesintint? sv_get_number_of_module_ctls;

        private ReturnsintTakesint? sv_get_number_of_modules;

        private ReturnsintTakesint? sv_get_number_of_patterns;

        private ReturnsIntPtrTakesintint? sv_get_pattern_data;

        private ReturnsintTakesintintintintint? sv_get_pattern_event;

        private ReturnsintTakesintint? sv_get_pattern_lines;

        private ReturnsIntPtrTakesintint? sv_get_pattern_name;

        private ReturnsintTakesintint? sv_get_pattern_tracks;

        private ReturnsintTakesintint? sv_get_pattern_x;

        private ReturnsintTakesintint? sv_get_pattern_y;

        private ReturnsintTakesVoid? sv_get_sample_rate;

        private ReturnsintTakesint? sv_get_song_bpm;

        private ReturnsuintTakesint? sv_get_song_length_frames;

        private ReturnsuintTakesint? sv_get_song_length_lines;

        private ReturnsIntPtrTakesint? sv_get_song_name;

        private ReturnsintTakesint? sv_get_song_tpl;

        private ReturnsuintTakesVoid? sv_get_ticks;

        private ReturnsuintTakesVoid? sv_get_ticks_per_second;

        private ReturnsintTakesintintintIntPtrint? sv_get_time_map;

        private ReturnsintTakesIntPtrintintuint? sv_init;

        private ReturnsintTakesintIntPtr? sv_load;

        private ReturnsintTakesintIntPtruint? sv_load_from_memory;

        private ReturnsintTakesintIntPtrintintint? sv_load_module;

        private ReturnsintTakesintIntPtruintintintint? sv_load_module_from_memory;

        private ReturnsintTakesint? sv_lock_slot;

        private ReturnsintTakesintintIntPtr? sv_metamodule_load;

        private ReturnsintTakesintintIntPtruint? sv_metamodule_load_from_memory;

        private ReturnsintTakesintintintIntPtrintint? sv_module_curve;

        private ReturnsintTakesintIntPtrIntPtrintintint? sv_new_module;

        private ReturnsintTakesintintintintintintintIntPtr? sv_new_pattern;

        private ReturnsintTakesint? sv_open_slot;

        private ReturnsintTakesintintint? sv_pattern_mute;

        private ReturnsintTakesint? sv_pause;

        private ReturnsintTakesint? sv_play;

        private ReturnsintTakesint? sv_play_from_beginning;

        private ReturnsintTakesintint? sv_remove_module;

        private ReturnsintTakesintint? sv_remove_pattern;

        private ReturnsintTakesint? sv_resume;

        private ReturnsintTakesintint? sv_rewind;

        private ReturnsintTakesintintIntPtrint? sv_sampler_load;

        private ReturnsintTakesintintIntPtruintint? sv_sampler_load_from_memory;

        private ReturnsintTakesintIntPtr? sv_save;

        private ReturnsintTakesintintintintintintint? sv_send_event;

        private ReturnsintTakesintint? sv_set_autostop;

        private ReturnsintTakesintintint? sv_set_event_t;

        private ReturnsintTakesintintint? sv_set_module_color;

        private ReturnsintTakesintintintintint? sv_set_module_ctl_value;

        private ReturnsintTakesintintint? sv_set_module_finetune;

        private ReturnsintTakesintintIntPtr? sv_set_module_name;

        private ReturnsintTakesintintint? sv_set_module_relnote;

        private ReturnsintTakesintintintint? sv_set_module_xy;

        private ReturnsintTakesintintintintintintintintint? sv_set_pattern_event;

        private ReturnsintTakesintintIntPtr? sv_set_pattern_name;

        private ReturnsintTakesintintintint? sv_set_pattern_size;

        private ReturnsintTakesintintintint? sv_set_pattern_xy;

        private ReturnsintTakesintIntPtr? sv_set_song_name;

        private ReturnsintTakesint? sv_stop;

        private ReturnsintTakesint? sv_sync_resume;

        private ReturnsintTakesint? sv_unlock_slot;

        private ReturnsintTakesVoid? sv_update_input;

        private ReturnsintTakesintint? sv_volume;

        private ReturnsintTakesintintIntPtr? sv_vplayer_load;

        private ReturnsintTakesintintIntPtruint? sv_vplayer_load_from_memory;

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

        int ISunVoxLibC.sv_sampler_load(int slot, int mod_num, IntPtr file_name, int sample_slot) => sv_sampler_load?.Invoke(slot, mod_num, file_name, sample_slot) ?? throw GetNoDelegateException();

        int ISunVoxLibC.sv_sampler_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size, int sample_slot) => sv_sampler_load_from_memory?.Invoke(slot, mod_num, data, data_size, sample_slot) ?? throw GetNoDelegateException();

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
            sv_audio_callback = (ReturnsintTakesIntPtrintintuint)_handler.GetFunctionByName("sv_audio_callback", typeof(ReturnsintTakesIntPtrintintuint));
            sv_audio_callback2 = (ReturnsintTakesIntPtrintintuintintintIntPtr)_handler.GetFunctionByName("sv_audio_callback2", typeof(ReturnsintTakesIntPtrintintuintintintIntPtr));
            sv_close_slot = (ReturnsintTakesint)_handler.GetFunctionByName("sv_close_slot", typeof(ReturnsintTakesint));
            sv_connect_module = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_connect_module", typeof(ReturnsintTakesintintint));
            sv_deinit = (ReturnsintTakesVoid)_handler.GetFunctionByName("sv_deinit", typeof(ReturnsintTakesVoid));
            sv_disconnect_module = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_disconnect_module", typeof(ReturnsintTakesintintint));
            sv_end_of_song = (ReturnsintTakesint)_handler.GetFunctionByName("sv_end_of_song", typeof(ReturnsintTakesint));
            sv_find_module = (ReturnsintTakesintIntPtr)_handler.GetFunctionByName("sv_find_module", typeof(ReturnsintTakesintIntPtr));
            sv_find_pattern = (ReturnsintTakesintIntPtr)_handler.GetFunctionByName("sv_find_pattern", typeof(ReturnsintTakesintIntPtr));
            sv_get_autostop = (ReturnsintTakesint)_handler.GetFunctionByName("sv_get_autostop", typeof(ReturnsintTakesint));
            sv_get_current_line = (ReturnsintTakesint)_handler.GetFunctionByName("sv_get_current_line", typeof(ReturnsintTakesint));
            sv_get_current_line2 = (ReturnsintTakesint)_handler.GetFunctionByName("sv_get_current_line2", typeof(ReturnsintTakesint));
            sv_get_current_signal_level = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_get_current_signal_level", typeof(ReturnsintTakesintint));
            sv_get_log = (ReturnsIntPtrTakesint)_handler.GetFunctionByName("sv_get_log", typeof(ReturnsIntPtrTakesint));
            sv_get_module_color = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_get_module_color", typeof(ReturnsintTakesintint));
            sv_get_module_ctl_group = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_get_module_ctl_group", typeof(ReturnsintTakesintintint));
            sv_get_module_ctl_max = (ReturnsintTakesintintintint)_handler.GetFunctionByName("sv_get_module_ctl_max", typeof(ReturnsintTakesintintintint));
            sv_get_module_ctl_min = (ReturnsintTakesintintintint)_handler.GetFunctionByName("sv_get_module_ctl_min", typeof(ReturnsintTakesintintintint));
            sv_get_module_ctl_name = (ReturnsIntPtrTakesintintint)_handler.GetFunctionByName("sv_get_module_ctl_name", typeof(ReturnsIntPtrTakesintintint));
            sv_get_module_ctl_offset = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_get_module_ctl_offset", typeof(ReturnsintTakesintintint));
            sv_get_module_ctl_type = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_get_module_ctl_type", typeof(ReturnsintTakesintintint));
            sv_get_module_ctl_value = (ReturnsintTakesintintintint)_handler.GetFunctionByName("sv_get_module_ctl_value", typeof(ReturnsintTakesintintintint));
            sv_get_module_finetune = (ReturnsuintTakesintint)_handler.GetFunctionByName("sv_get_module_finetune", typeof(ReturnsuintTakesintint));
            sv_get_module_flags = (ReturnsuintTakesintint)_handler.GetFunctionByName("sv_get_module_flags", typeof(ReturnsuintTakesintint));
            sv_get_module_inputs = (ReturnsIntPtrTakesintint)_handler.GetFunctionByName("sv_get_module_inputs", typeof(ReturnsIntPtrTakesintint));
            sv_get_module_name = (ReturnsIntPtrTakesintint)_handler.GetFunctionByName("sv_get_module_name", typeof(ReturnsIntPtrTakesintint));
            sv_get_module_outputs = (ReturnsIntPtrTakesintint)_handler.GetFunctionByName("sv_get_module_outputs", typeof(ReturnsIntPtrTakesintint));
            sv_get_module_scope2 = (ReturnsuintTakesintintintIntPtruint)_handler.GetFunctionByName("sv_get_module_scope2", typeof(ReturnsuintTakesintintintIntPtruint));
            sv_get_module_type = (ReturnsIntPtrTakesintint)_handler.GetFunctionByName("sv_get_module_type", typeof(ReturnsIntPtrTakesintint));
            sv_get_module_xy = (ReturnsuintTakesintint)_handler.GetFunctionByName("sv_get_module_xy", typeof(ReturnsuintTakesintint));
            sv_get_number_of_module_ctls = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_get_number_of_module_ctls", typeof(ReturnsintTakesintint));
            sv_get_number_of_modules = (ReturnsintTakesint)_handler.GetFunctionByName("sv_get_number_of_modules", typeof(ReturnsintTakesint));
            sv_get_number_of_patterns = (ReturnsintTakesint)_handler.GetFunctionByName("sv_get_number_of_patterns", typeof(ReturnsintTakesint));
            sv_get_pattern_data = (ReturnsIntPtrTakesintint)_handler.GetFunctionByName("sv_get_pattern_data", typeof(ReturnsIntPtrTakesintint));
            sv_get_pattern_event = (ReturnsintTakesintintintintint)_handler.GetFunctionByName("sv_get_pattern_event", typeof(ReturnsintTakesintintintintint));
            sv_get_pattern_lines = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_get_pattern_lines", typeof(ReturnsintTakesintint));
            sv_get_pattern_name = (ReturnsIntPtrTakesintint)_handler.GetFunctionByName("sv_get_pattern_name", typeof(ReturnsIntPtrTakesintint));
            sv_get_pattern_tracks = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_get_pattern_tracks", typeof(ReturnsintTakesintint));
            sv_get_pattern_x = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_get_pattern_x", typeof(ReturnsintTakesintint));
            sv_get_pattern_y = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_get_pattern_y", typeof(ReturnsintTakesintint));
            sv_get_sample_rate = (ReturnsintTakesVoid)_handler.GetFunctionByName("sv_get_sample_rate", typeof(ReturnsintTakesVoid));
            sv_get_song_bpm = (ReturnsintTakesint)_handler.GetFunctionByName("sv_get_song_bpm", typeof(ReturnsintTakesint));
            sv_get_song_length_frames = (ReturnsuintTakesint)_handler.GetFunctionByName("sv_get_song_length_frames", typeof(ReturnsuintTakesint));
            sv_get_song_length_lines = (ReturnsuintTakesint)_handler.GetFunctionByName("sv_get_song_length_lines", typeof(ReturnsuintTakesint));
            sv_get_song_name = (ReturnsIntPtrTakesint)_handler.GetFunctionByName("sv_get_song_name", typeof(ReturnsIntPtrTakesint));
            sv_get_song_tpl = (ReturnsintTakesint)_handler.GetFunctionByName("sv_get_song_tpl", typeof(ReturnsintTakesint));
            sv_get_ticks = (ReturnsuintTakesVoid)_handler.GetFunctionByName("sv_get_ticks", typeof(ReturnsuintTakesVoid));
            sv_get_ticks_per_second = (ReturnsuintTakesVoid)_handler.GetFunctionByName("sv_get_ticks_per_second", typeof(ReturnsuintTakesVoid));
            sv_get_time_map = (ReturnsintTakesintintintIntPtrint)_handler.GetFunctionByName("sv_get_time_map", typeof(ReturnsintTakesintintintIntPtrint));
            sv_init = (ReturnsintTakesIntPtrintintuint)_handler.GetFunctionByName("sv_init", typeof(ReturnsintTakesIntPtrintintuint));
            sv_load = (ReturnsintTakesintIntPtr)_handler.GetFunctionByName("sv_load", typeof(ReturnsintTakesintIntPtr));
            sv_load_from_memory = (ReturnsintTakesintIntPtruint)_handler.GetFunctionByName("sv_load_from_memory", typeof(ReturnsintTakesintIntPtruint));
            sv_load_module = (ReturnsintTakesintIntPtrintintint)_handler.GetFunctionByName("sv_load_module", typeof(ReturnsintTakesintIntPtrintintint));
            sv_load_module_from_memory = (ReturnsintTakesintIntPtruintintintint)_handler.GetFunctionByName("sv_load_module_from_memory", typeof(ReturnsintTakesintIntPtruintintintint));
            sv_lock_slot = (ReturnsintTakesint)_handler.GetFunctionByName("sv_lock_slot", typeof(ReturnsintTakesint));
            sv_metamodule_load = (ReturnsintTakesintintIntPtr)_handler.GetFunctionByName("sv_metamodule_load", typeof(ReturnsintTakesintintIntPtr));
            sv_metamodule_load_from_memory = (ReturnsintTakesintintIntPtruint)_handler.GetFunctionByName("sv_metamodule_load_from_memory", typeof(ReturnsintTakesintintIntPtruint));
            sv_module_curve = (ReturnsintTakesintintintIntPtrintint)_handler.GetFunctionByName("sv_module_curve", typeof(ReturnsintTakesintintintIntPtrintint));
            sv_new_module = (ReturnsintTakesintIntPtrIntPtrintintint)_handler.GetFunctionByName("sv_new_module", typeof(ReturnsintTakesintIntPtrIntPtrintintint));
            sv_new_pattern = (ReturnsintTakesintintintintintintintIntPtr)_handler.GetFunctionByName("sv_new_pattern", typeof(ReturnsintTakesintintintintintintintIntPtr));
            sv_open_slot = (ReturnsintTakesint)_handler.GetFunctionByName("sv_open_slot", typeof(ReturnsintTakesint));
            sv_pattern_mute = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_pattern_mute", typeof(ReturnsintTakesintintint));
            sv_pause = (ReturnsintTakesint)_handler.GetFunctionByName("sv_pause", typeof(ReturnsintTakesint));
            sv_play = (ReturnsintTakesint)_handler.GetFunctionByName("sv_play", typeof(ReturnsintTakesint));
            sv_play_from_beginning = (ReturnsintTakesint)_handler.GetFunctionByName("sv_play_from_beginning", typeof(ReturnsintTakesint));
            sv_remove_module = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_remove_module", typeof(ReturnsintTakesintint));
            sv_remove_pattern = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_remove_pattern", typeof(ReturnsintTakesintint));
            sv_resume = (ReturnsintTakesint)_handler.GetFunctionByName("sv_resume", typeof(ReturnsintTakesint));
            sv_rewind = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_rewind", typeof(ReturnsintTakesintint));
            sv_sampler_load = (ReturnsintTakesintintIntPtrint)_handler.GetFunctionByName("sv_sampler_load", typeof(ReturnsintTakesintintIntPtrint));
            sv_sampler_load_from_memory = (ReturnsintTakesintintIntPtruintint)_handler.GetFunctionByName("sv_sampler_load_from_memory", typeof(ReturnsintTakesintintIntPtruintint));
            sv_save = (ReturnsintTakesintIntPtr)_handler.GetFunctionByName("sv_save", typeof(ReturnsintTakesintIntPtr));
            sv_send_event = (ReturnsintTakesintintintintintintint)_handler.GetFunctionByName("sv_send_event", typeof(ReturnsintTakesintintintintintintint));
            sv_set_autostop = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_set_autostop", typeof(ReturnsintTakesintint));
            sv_set_event_t = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_set_event_t", typeof(ReturnsintTakesintintint));
            sv_set_module_color = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_set_module_color", typeof(ReturnsintTakesintintint));
            sv_set_module_ctl_value = (ReturnsintTakesintintintintint)_handler.GetFunctionByName("sv_set_module_ctl_value", typeof(ReturnsintTakesintintintintint));
            sv_set_module_finetune = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_set_module_finetune", typeof(ReturnsintTakesintintint));
            sv_set_module_name = (ReturnsintTakesintintIntPtr)_handler.GetFunctionByName("sv_set_module_name", typeof(ReturnsintTakesintintIntPtr));
            sv_set_module_relnote = (ReturnsintTakesintintint)_handler.GetFunctionByName("sv_set_module_relnote", typeof(ReturnsintTakesintintint));
            sv_set_module_xy = (ReturnsintTakesintintintint)_handler.GetFunctionByName("sv_set_module_xy", typeof(ReturnsintTakesintintintint));
            sv_set_pattern_event = (ReturnsintTakesintintintintintintintintint)_handler.GetFunctionByName("sv_set_pattern_event", typeof(ReturnsintTakesintintintintintintintintint));
            sv_set_pattern_name = (ReturnsintTakesintintIntPtr)_handler.GetFunctionByName("sv_set_pattern_name", typeof(ReturnsintTakesintintIntPtr));
            sv_set_pattern_size = (ReturnsintTakesintintintint)_handler.GetFunctionByName("sv_set_pattern_size", typeof(ReturnsintTakesintintintint));
            sv_set_pattern_xy = (ReturnsintTakesintintintint)_handler.GetFunctionByName("sv_set_pattern_xy", typeof(ReturnsintTakesintintintint));
            sv_set_song_name = (ReturnsintTakesintIntPtr)_handler.GetFunctionByName("sv_set_song_name", typeof(ReturnsintTakesintIntPtr));
            sv_stop = (ReturnsintTakesint)_handler.GetFunctionByName("sv_stop", typeof(ReturnsintTakesint));
            sv_sync_resume = (ReturnsintTakesint)_handler.GetFunctionByName("sv_sync_resume", typeof(ReturnsintTakesint));
            sv_unlock_slot = (ReturnsintTakesint)_handler.GetFunctionByName("sv_unlock_slot", typeof(ReturnsintTakesint));
            sv_update_input = (ReturnsintTakesVoid)_handler.GetFunctionByName("sv_update_input", typeof(ReturnsintTakesVoid));
            sv_volume = (ReturnsintTakesintint)_handler.GetFunctionByName("sv_volume", typeof(ReturnsintTakesintint));
            sv_vplayer_load = (ReturnsintTakesintintIntPtr)_handler.GetFunctionByName("sv_vplayer_load", typeof(ReturnsintTakesintintIntPtr));
            sv_vplayer_load_from_memory = (ReturnsintTakesintintIntPtruint)_handler.GetFunctionByName("sv_vplayer_load_from_memory", typeof(ReturnsintTakesintintIntPtruint));
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
