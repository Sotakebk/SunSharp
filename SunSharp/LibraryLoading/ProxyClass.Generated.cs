using System;
using System.Reflection;

namespace SunSharp.LibraryLoading
{
    public class ProxyClass : ISunVoxLib
    {
        public ProxyClass(Func<string, Type, Delegate> GetDelegate)
        {
            var type = GetType();
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (typeof(Delegate).IsAssignableFrom(field.FieldType))
                {
                    field.SetValue(this, GetDelegate(field.Name, field.FieldType));
                }
            }
        }

        #region delegate definitions

        private delegate int o_Int_i_Int_Int_Int_Int_Int_Int_Int_Int_Int(int _int, int _int1, int _int2, int _int3, int _int4, int _int5, int _int6, int _int7, int _int8);

        private delegate int o_Int_i_Int_Int_Int_Int_Int_Int_Int_IntPtr(int _int, int _int1, int _int2, int _int3, int _int4, int _int5, int _int6, IntPtr _IntPtr);

        private delegate int o_Int_i_Int_Int_Int_Int_Int_Int_Int(int _int, int _int1, int _int2, int _int3, int _int4, int _int5, int _int6);

        private delegate int o_Int_i_Int_Int_Int_Int_Int(int _int, int _int1, int _int2, int _int3, int _int4);

        private delegate int o_Int_i_Int_Int_Int_Int(int _int, int _int1, int _int2, int _int3);

        private delegate int o_Int_i_Int_Int_Int_IntPtr_Int_Int(int _int, int _int1, int _int2, IntPtr _IntPtr, int _int3, int _int4);

        private delegate int o_Int_i_Int_Int_Int_IntPtr_Int(int _int, int _int1, int _int2, IntPtr _IntPtr, int _int3);

        private delegate int o_Int_i_Int_Int_Int(int _int, int _int1, int _int2);

        private delegate int o_Int_i_Int_Int_IntPtr_Int(int _int, int _int1, IntPtr _IntPtr, int _int2);

        private delegate int o_Int_i_Int_Int_IntPtr_Uint_Int(int _int, int _int1, IntPtr _IntPtr, uint _uint, int _int2);

        private delegate int o_Int_i_Int_Int_IntPtr_Uint(int _int, int _int1, IntPtr _IntPtr, uint _uint);

        private delegate int o_Int_i_Int_Int_IntPtr(int _int, int _int1, IntPtr _IntPtr);

        private delegate int o_Int_i_Int_Int(int _int, int _int1);

        private delegate int o_Int_i_Int_IntPtr_Int_Int_Int(int _int, IntPtr _IntPtr, int _int1, int _int2, int _int3);

        private delegate int o_Int_i_Int_IntPtr_IntPtr_Int_Int_Int(int _int, IntPtr _IntPtr, IntPtr _IntPtr1, int _int1, int _int2, int _int3);

        private delegate int o_Int_i_Int_IntPtr_Uint_Int_Int_Int(int _int, IntPtr _IntPtr, uint _uint, int _int1, int _int2, int _int3);

        private delegate int o_Int_i_Int_IntPtr_Uint(int _int, IntPtr _IntPtr, uint _uint);

        private delegate int o_Int_i_Int_IntPtr(int _int, IntPtr _IntPtr);

        private delegate int o_Int_i_Int(int _int);

        private delegate int o_Int_i_IntPtr_Int_Int_Uint_Int_Int_IntPtr(IntPtr _IntPtr, int _int, int _int1, uint _uint, int _int2, int _int3, IntPtr _IntPtr1);

        private delegate int o_Int_i_IntPtr_Int_Int_Uint(IntPtr _IntPtr, int _int, int _int1, uint _uint);

        private delegate int o_Int_i_Void();

        private delegate IntPtr o_IntPtr_i_Int_Int_Int(int _int, int _int1, int _int2);

        private delegate IntPtr o_IntPtr_i_Int_Int(int _int, int _int1);

        private delegate IntPtr o_IntPtr_i_Int(int _int);

        private delegate uint o_Uint_i_Int_Int_Int_IntPtr_Uint(int _int, int _int1, int _int2, IntPtr _IntPtr, uint _uint);

        private delegate uint o_Uint_i_Int_Int(int _int, int _int1);

        private delegate uint o_Uint_i_Int(int _int);

        private delegate uint o_Uint_i_Void();

        #endregion delegate definitions

        #region delegates

#pragma warning disable CS0649

        private o_Int_i_Int sv_close_slot;

        private o_Int_i_Int sv_end_of_song;

        private o_Int_i_Int sv_get_autostop;

        private o_Int_i_Int sv_get_current_line;

        private o_Int_i_Int sv_get_current_line2;

        private o_Int_i_Int sv_get_number_of_modules;

        private o_Int_i_Int sv_get_number_of_patterns;

        private o_Int_i_Int sv_get_song_bpm;

        private o_Int_i_Int sv_get_song_tpl;

        private o_Int_i_Int sv_lock_slot;

        private o_Int_i_Int sv_open_slot;

        private o_Int_i_Int sv_pause;

        private o_Int_i_Int sv_play_from_beginning;

        private o_Int_i_Int sv_play;

        private o_Int_i_Int sv_resume;

        private o_Int_i_Int sv_stop;

        private o_Int_i_Int sv_sync_resume;

        private o_Int_i_Int sv_unlock_slot;

        private o_Int_i_Int_Int sv_get_current_signal_level;

        private o_Int_i_Int_Int sv_get_module_color;

        private o_Int_i_Int_Int sv_get_number_of_module_ctls;

        private o_Int_i_Int_Int sv_get_pattern_lines;

        private o_Int_i_Int_Int sv_get_pattern_tracks;

        private o_Int_i_Int_Int sv_get_pattern_x;

        private o_Int_i_Int_Int sv_get_pattern_y;

        private o_Int_i_Int_Int sv_remove_module;

        private o_Int_i_Int_Int sv_remove_pattern;

        private o_Int_i_Int_Int sv_rewind;

        private o_Int_i_Int_Int sv_set_autostop;

        private o_Int_i_Int_Int sv_volume;

        private o_Int_i_Int_Int_Int sv_connect_module;

        private o_Int_i_Int_Int_Int sv_disconnect_module;

        private o_Int_i_Int_Int_Int sv_get_module_ctl_group;

        private o_Int_i_Int_Int_Int sv_get_module_ctl_offset;

        private o_Int_i_Int_Int_Int sv_get_module_ctl_type;

        private o_Int_i_Int_Int_Int sv_pattern_mute;

        private o_Int_i_Int_Int_Int sv_set_event_t;

        private o_Int_i_Int_Int_Int sv_set_module_color;

        private o_Int_i_Int_Int_Int sv_set_module_finetune;

        private o_Int_i_Int_Int_Int sv_set_module_relnote;

        private o_Int_i_Int_Int_Int_Int sv_get_module_ctl_max;

        private o_Int_i_Int_Int_Int_Int sv_get_module_ctl_min;

        private o_Int_i_Int_Int_Int_Int sv_get_module_ctl_value;

        private o_Int_i_Int_Int_Int_Int sv_set_module_xy;

        private o_Int_i_Int_Int_Int_Int sv_set_pattern_size;

        private o_Int_i_Int_Int_Int_Int sv_set_pattern_xy;

        private o_Int_i_Int_Int_Int_Int_Int sv_get_pattern_event;

        private o_Int_i_Int_Int_Int_Int_Int sv_set_module_ctl_value;

        private o_Int_i_Int_Int_Int_Int_Int_Int_Int sv_send_event;

        private o_Int_i_Int_Int_Int_Int_Int_Int_Int_Int_Int sv_set_pattern_event;

        private o_Int_i_Int_Int_Int_Int_Int_Int_Int_IntPtr sv_new_pattern;

        private o_Int_i_Int_Int_Int_IntPtr_Int sv_get_time_map;

        private o_Int_i_Int_Int_Int_IntPtr_Int_Int sv_module_curve;

        private o_Int_i_Int_Int_IntPtr sv_metamodule_load;

        private o_Int_i_Int_Int_IntPtr sv_set_module_name;

        private o_Int_i_Int_Int_IntPtr sv_set_pattern_name;

        private o_Int_i_Int_Int_IntPtr sv_vplayer_load;

        private o_Int_i_Int_Int_IntPtr_Int sv_sampler_load;

        private o_Int_i_Int_Int_IntPtr_Uint sv_metamodule_load_from_memory;

        private o_Int_i_Int_Int_IntPtr_Uint sv_vplayer_load_from_memory;

        private o_Int_i_Int_Int_IntPtr_Uint_Int sv_sampler_load_from_memory;

        private o_Int_i_Int_IntPtr sv_find_module;

        private o_Int_i_Int_IntPtr sv_find_pattern;

        private o_Int_i_Int_IntPtr sv_load;

        private o_Int_i_Int_IntPtr sv_save;

        private o_Int_i_Int_IntPtr sv_set_song_name;

        private o_Int_i_Int_IntPtr_Int_Int_Int sv_load_module;

        private o_Int_i_Int_IntPtr_IntPtr_Int_Int_Int sv_new_module;

        private o_Int_i_Int_IntPtr_Uint sv_load_from_memory;

        private o_Int_i_Int_IntPtr_Uint_Int_Int_Int sv_load_module_from_memory;

        private o_Int_i_IntPtr_Int_Int_Uint sv_audio_callback;

        private o_Int_i_IntPtr_Int_Int_Uint sv_init;

        private o_Int_i_IntPtr_Int_Int_Uint_Int_Int_IntPtr sv_audio_callback2;

        private o_Int_i_Void sv_deinit;

        private o_Int_i_Void sv_get_sample_rate;

        private o_Int_i_Void sv_update_input;

        private o_IntPtr_i_Int sv_get_log;

        private o_IntPtr_i_Int sv_get_song_name;

        private o_IntPtr_i_Int_Int sv_get_module_inputs;

        private o_IntPtr_i_Int_Int sv_get_module_name;

        private o_IntPtr_i_Int_Int sv_get_module_outputs;

        private o_IntPtr_i_Int_Int sv_get_module_type;

        private o_IntPtr_i_Int_Int sv_get_pattern_data;

        private o_IntPtr_i_Int_Int sv_get_pattern_name;

        private o_IntPtr_i_Int_Int_Int sv_get_module_ctl_name;

        private o_Uint_i_Int sv_get_song_length_frames;

        private o_Uint_i_Int sv_get_song_length_lines;

        private o_Uint_i_Int_Int sv_get_module_finetune;

        private o_Uint_i_Int_Int sv_get_module_flags;

        private o_Uint_i_Int_Int sv_get_module_xy;

        private o_Uint_i_Int_Int_Int_IntPtr_Uint sv_get_module_scope2;

        private o_Uint_i_Void sv_get_ticks_per_second;

        private o_Uint_i_Void sv_get_ticks;

#pragma warning restore CS0649

        #endregion delegates

        #region interface

        int ISunVoxLib.sv_audio_callback(IntPtr buf, int frames, int latency, uint out_time) => sv_audio_callback(buf, frames, latency, out_time);

        int ISunVoxLib.sv_audio_callback2(IntPtr buf, int frames, int latency, uint out_time, int in_type, int in_channels, IntPtr in_buf) => sv_audio_callback2(buf, frames, latency, out_time, in_type, in_channels, in_buf);

        int ISunVoxLib.sv_close_slot(int slot) => sv_close_slot(slot);

        int ISunVoxLib.sv_connect_module(int slot, int source, int destination) => sv_connect_module(slot, source, destination);

        int ISunVoxLib.sv_deinit() => sv_deinit();

        int ISunVoxLib.sv_disconnect_module(int slot, int source, int destination) => sv_disconnect_module(slot, source, destination);

        int ISunVoxLib.sv_end_of_song(int slot) => sv_end_of_song(slot);

        int ISunVoxLib.sv_find_module(int slot, IntPtr name) => sv_find_module(slot, name);

        int ISunVoxLib.sv_find_pattern(int slot, IntPtr name) => sv_find_pattern(slot, name);

        int ISunVoxLib.sv_get_autostop(int slot) => sv_get_autostop(slot);

        int ISunVoxLib.sv_get_current_line(int slot) => sv_get_current_line(slot);

        int ISunVoxLib.sv_get_current_line2(int slot) => sv_get_current_line2(slot);

        int ISunVoxLib.sv_get_current_signal_level(int slot, int channel) => sv_get_current_signal_level(slot, channel);

        int ISunVoxLib.sv_get_module_color(int slot, int mod_num) => sv_get_module_color(slot, mod_num);

        int ISunVoxLib.sv_get_module_ctl_group(int slot, int mod_num, int ctl_num) => sv_get_module_ctl_group(slot, mod_num, ctl_num);

        int ISunVoxLib.sv_get_module_ctl_max(int slot, int mod_num, int ctl_num, int scaled) => sv_get_module_ctl_max(slot, mod_num, ctl_num, scaled);

        int ISunVoxLib.sv_get_module_ctl_min(int slot, int mod_num, int ctl_num, int scaled) => sv_get_module_ctl_min(slot, mod_num, ctl_num, scaled);

        int ISunVoxLib.sv_get_module_ctl_offset(int slot, int mod_num, int ctl_num) => sv_get_module_ctl_offset(slot, mod_num, ctl_num);

        int ISunVoxLib.sv_get_module_ctl_type(int slot, int mod_num, int ctl_num) => sv_get_module_ctl_type(slot, mod_num, ctl_num);

        int ISunVoxLib.sv_get_module_ctl_value(int slot, int mod_num, int ctl_num, int scaled) => sv_get_module_ctl_value(slot, mod_num, ctl_num, scaled);

        int ISunVoxLib.sv_get_number_of_module_ctls(int slot, int mod_num) => sv_get_number_of_module_ctls(slot, mod_num);

        int ISunVoxLib.sv_get_number_of_modules(int slot) => sv_get_number_of_modules(slot);

        int ISunVoxLib.sv_get_number_of_patterns(int slot) => sv_get_number_of_patterns(slot);

        int ISunVoxLib.sv_get_pattern_event(int slot, int pat_num, int track, int line, int column) => sv_get_pattern_event(slot, pat_num, track, line, column);

        int ISunVoxLib.sv_get_pattern_lines(int slot, int pat_num) => sv_get_pattern_lines(slot, pat_num);

        int ISunVoxLib.sv_get_pattern_tracks(int slot, int pat_num) => sv_get_pattern_tracks(slot, pat_num);

        int ISunVoxLib.sv_get_pattern_x(int slot, int pat_num) => sv_get_pattern_x(slot, pat_num);

        int ISunVoxLib.sv_get_pattern_y(int slot, int pat_num) => sv_get_pattern_y(slot, pat_num);

        int ISunVoxLib.sv_get_sample_rate() => sv_get_sample_rate();

        int ISunVoxLib.sv_get_song_bpm(int slot) => sv_get_song_bpm(slot);

        int ISunVoxLib.sv_get_song_tpl(int slot) => sv_get_song_tpl(slot);

        int ISunVoxLib.sv_get_time_map(int slot, int start_line, int len, IntPtr dest, int flags) => sv_get_time_map(slot, start_line, len, dest, flags);

        int ISunVoxLib.sv_init(IntPtr config, int freq, int channels, uint flags) => sv_init(config, freq, channels, flags);

        int ISunVoxLib.sv_load_from_memory(int slot, IntPtr data, uint data_size) => sv_load_from_memory(slot, data, data_size);

        int ISunVoxLib.sv_load_module_from_memory(int slot, IntPtr data, uint data_size, int x, int y, int z) => sv_load_module_from_memory(slot, data, data_size, x, y, z);

        int ISunVoxLib.sv_load_module(int slot, IntPtr file_name, int x, int y, int z) => sv_load_module(slot, file_name, x, y, z);

        int ISunVoxLib.sv_load(int slot, IntPtr name) => sv_load(slot, name);

        int ISunVoxLib.sv_lock_slot(int slot) => sv_lock_slot(slot);

        int ISunVoxLib.sv_metamodule_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size) => sv_metamodule_load_from_memory(slot, mod_num, data, data_size);

        int ISunVoxLib.sv_metamodule_load(int slot, int mod_num, IntPtr file_name) => sv_metamodule_load(slot, mod_num, file_name);

        int ISunVoxLib.sv_module_curve(int slot, int mod_num, int curve_num, IntPtr data, int len, int w) => sv_module_curve(slot, mod_num, curve_num, data, len, w);

        int ISunVoxLib.sv_new_module(int slot, IntPtr type, IntPtr name, int x, int y, int z) => sv_new_module(slot, type, name, x, y, z);

        int ISunVoxLib.sv_new_pattern(int slot, int clone, int x, int y, int tracks, int lines, int icon_seed, IntPtr name) => sv_new_pattern(slot, clone, x, y, tracks, lines, icon_seed, name);

        int ISunVoxLib.sv_open_slot(int slot) => sv_open_slot(slot);

        int ISunVoxLib.sv_pattern_mute(int slot, int pat_num, int mute) => sv_pattern_mute(slot, pat_num, mute);

        int ISunVoxLib.sv_pause(int slot) => sv_pause(slot);

        int ISunVoxLib.sv_play_from_beginning(int slot) => sv_play_from_beginning(slot);

        int ISunVoxLib.sv_play(int slot) => sv_play(slot);

        int ISunVoxLib.sv_remove_module(int slot, int mod_num) => sv_remove_module(slot, mod_num);

        int ISunVoxLib.sv_remove_pattern(int slot, int pat_num) => sv_remove_pattern(slot, pat_num);

        int ISunVoxLib.sv_resume(int slot) => sv_resume(slot);

        int ISunVoxLib.sv_rewind(int slot, int line_num) => sv_rewind(slot, line_num);

        int ISunVoxLib.sv_sampler_load_from_memory(int slot, int sampler_module, IntPtr data, uint data_size, int sample_slot) => sv_sampler_load_from_memory(slot, sampler_module, data, data_size, sample_slot);

        int ISunVoxLib.sv_sampler_load(int slot, int sampler_module, IntPtr file_name, int sample_slot) => sv_sampler_load(slot, sampler_module, file_name, sample_slot);

        int ISunVoxLib.sv_save(int slot, IntPtr name) => sv_save(slot, name);

        int ISunVoxLib.sv_send_event(int slot, int track_num, int note, int vel, int module, int ctl, int ctl_val) => sv_send_event(slot, track_num, note, vel, module, ctl, ctl_val);

        int ISunVoxLib.sv_set_autostop(int slot, int autostop) => sv_set_autostop(slot, autostop);

        int ISunVoxLib.sv_set_event_t(int slot, int set, int t) => sv_set_event_t(slot, set, t);

        int ISunVoxLib.sv_set_module_color(int slot, int mod_num, int color) => sv_set_module_color(slot, mod_num, color);

        int ISunVoxLib.sv_set_module_ctl_value(int slot, int mod_num, int ctl_num, int val, int scaled) => sv_set_module_ctl_value(slot, mod_num, ctl_num, val, scaled);

        int ISunVoxLib.sv_set_module_finetune(int slot, int mod_num, int finetune) => sv_set_module_finetune(slot, mod_num, finetune);

        int ISunVoxLib.sv_set_module_name(int slot, int mod_num, IntPtr name) => sv_set_module_name(slot, mod_num, name);

        int ISunVoxLib.sv_set_module_relnote(int slot, int mod_num, int relative_note) => sv_set_module_relnote(slot, mod_num, relative_note);

        int ISunVoxLib.sv_set_module_xy(int slot, int mod_num, int x, int y) => sv_set_module_xy(slot, mod_num, x, y);

        int ISunVoxLib.sv_set_pattern_event(int slot, int pat_num, int track, int line, int nn, int vv, int mm, int ccee, int xxyy) => sv_set_pattern_event(slot, pat_num, track, line, nn, vv, mm, ccee, xxyy);

        int ISunVoxLib.sv_set_pattern_name(int slot, int pat_num, IntPtr name) => sv_set_pattern_name(slot, pat_num, name);

        int ISunVoxLib.sv_set_pattern_size(int slot, int pat_num, int tracks, int lines) => sv_set_pattern_size(slot, pat_num, tracks, lines);

        int ISunVoxLib.sv_set_pattern_xy(int slot, int pat_num, int x, int y) => sv_set_pattern_xy(slot, pat_num, x, y);

        int ISunVoxLib.sv_set_song_name(int slot, IntPtr name) => sv_set_song_name(slot, name);

        int ISunVoxLib.sv_stop(int slot) => sv_stop(slot);

        int ISunVoxLib.sv_sync_resume(int slot) => sv_sync_resume(slot);

        int ISunVoxLib.sv_unlock_slot(int slot) => sv_unlock_slot(slot);

        int ISunVoxLib.sv_update_input() => sv_update_input();

        int ISunVoxLib.sv_volume(int slot, int vol) => sv_volume(slot, vol);

        int ISunVoxLib.sv_vplayer_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size) => sv_vplayer_load_from_memory(slot, mod_num, data, data_size);

        int ISunVoxLib.sv_vplayer_load(int slot, int mod_num, IntPtr file_name) => sv_vplayer_load(slot, mod_num, file_name);

        IntPtr ISunVoxLib.sv_get_log(int size) => sv_get_log(size);

        IntPtr ISunVoxLib.sv_get_module_ctl_name(int slot, int mod_num, int ctl_num) => sv_get_module_ctl_name(slot, mod_num, ctl_num);

        IntPtr ISunVoxLib.sv_get_module_inputs(int slot, int mod_num) => sv_get_module_inputs(slot, mod_num);

        IntPtr ISunVoxLib.sv_get_module_name(int slot, int mod_num) => sv_get_module_name(slot, mod_num);

        IntPtr ISunVoxLib.sv_get_module_outputs(int slot, int mod_num) => sv_get_module_outputs(slot, mod_num);

        IntPtr ISunVoxLib.sv_get_module_type(int slot, int mod_num) => sv_get_module_type(slot, mod_num);

        IntPtr ISunVoxLib.sv_get_pattern_data(int slot, int pat_num) => sv_get_pattern_data(slot, pat_num);

        IntPtr ISunVoxLib.sv_get_pattern_name(int slot, int pat_num) => sv_get_pattern_name(slot, pat_num);

        IntPtr ISunVoxLib.sv_get_song_name(int slot) => sv_get_song_name(slot);

        uint ISunVoxLib.sv_get_module_finetune(int slot, int mod_num) => sv_get_module_finetune(slot, mod_num);

        uint ISunVoxLib.sv_get_module_flags(int slot, int mod_num) => sv_get_module_flags(slot, mod_num);

        uint ISunVoxLib.sv_get_module_scope2(int slot, int mod_num, int channel, IntPtr dest_buf, uint samples_to_read) => sv_get_module_scope2(slot, mod_num, channel, dest_buf, samples_to_read);

        uint ISunVoxLib.sv_get_module_xy(int slot, int mod_num) => sv_get_module_xy(slot, mod_num);

        uint ISunVoxLib.sv_get_song_length_frames(int slot) => sv_get_song_length_frames(slot);

        uint ISunVoxLib.sv_get_song_length_lines(int slot) => sv_get_song_length_lines(slot);

        uint ISunVoxLib.sv_get_ticks_per_second() => sv_get_ticks_per_second();

        uint ISunVoxLib.sv_get_ticks() => sv_get_ticks();

        #endregion interface
    }
}
