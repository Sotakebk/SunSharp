/*
 * Do not modify this file manually.
*/

#nullable enable

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1716 // Identifiers should not match keywords
#pragma warning disable IDE1006 // Naming Styles

using System;

namespace SunSharp.Native
{
    public interface ISunVoxLibC
    {
        /// <summary>
        /// int sv_init( const char* config, int freq, int channels, uint32_t flags ) ;
        /// </summary>
        int sv_init(IntPtr config, int freq, int channels, uint flags);

        /// <summary>
        /// int sv_deinit( void ) ;
        /// </summary>
        int sv_deinit();

        /// <summary>
        /// int sv_get_sample_rate( void ) ;
        /// </summary>
        int sv_get_sample_rate();

        /// <summary>
        /// int sv_update_input( void ) ;
        /// </summary>
        int sv_update_input();

        /// <summary>
        /// int sv_audio_callback( void* buf, int frames, int latency, uint32_t out_time ) ;
        /// </summary>
        int sv_audio_callback(IntPtr buf, int frames, int latency, uint out_time);

        /// <summary>
        /// int sv_audio_callback2( void* buf, int frames, int latency, uint32_t out_time, int in_type, int in_channels, void* in_buf ) ;
        /// </summary>
        int sv_audio_callback2(IntPtr buf, int frames, int latency, uint out_time, int in_type, int in_channels, IntPtr in_buf);

        /// <summary>
        /// int sv_open_slot( int slot ) ;
        /// </summary>
        int sv_open_slot(int slot);

        /// <summary>
        /// int sv_close_slot( int slot ) ;
        /// </summary>
        int sv_close_slot(int slot);

        /// <summary>
        /// int sv_lock_slot( int slot ) ;
        /// </summary>
        int sv_lock_slot(int slot);

        /// <summary>
        /// int sv_unlock_slot( int slot ) ;
        /// </summary>
        int sv_unlock_slot(int slot);

        /// <summary>
        /// int sv_load( int slot, const char* name ) ;
        /// </summary>
        int sv_load(int slot, IntPtr name);

        /// <summary>
        /// int sv_load_from_memory( int slot, void* data, uint32_t data_size ) ;
        /// </summary>
        int sv_load_from_memory(int slot, IntPtr data, uint data_size);

        /// <summary>
        /// int sv_save( int slot, const char* name ) ;
        /// </summary>
        int sv_save(int slot, IntPtr name);

        /// <summary>
        /// int sv_play( int slot ) ;
        /// </summary>
        int sv_play(int slot);

        /// <summary>
        /// int sv_play_from_beginning( int slot ) ;
        /// </summary>
        int sv_play_from_beginning(int slot);

        /// <summary>
        /// int sv_stop( int slot ) ;
        /// </summary>
        int sv_stop(int slot);

        /// <summary>
        /// int sv_pause( int slot ) ;
        /// </summary>
        int sv_pause(int slot);

        /// <summary>
        /// int sv_resume( int slot ) ;
        /// </summary>
        int sv_resume(int slot);

        /// <summary>
        /// int sv_sync_resume( int slot ) ;
        /// </summary>
        int sv_sync_resume(int slot);

        /// <summary>
        /// int sv_set_autostop( int slot, int autostop ) ;
        /// </summary>
        int sv_set_autostop(int slot, int autostop);

        /// <summary>
        /// int sv_get_autostop( int slot ) ;
        /// </summary>
        int sv_get_autostop(int slot);

        /// <summary>
        /// int sv_end_of_song( int slot ) ;
        /// </summary>
        int sv_end_of_song(int slot);

        /// <summary>
        /// int sv_rewind( int slot, int line_num ) ;
        /// </summary>
        int sv_rewind(int slot, int line_num);

        /// <summary>
        /// int sv_volume( int slot, int vol ) ;
        /// </summary>
        int sv_volume(int slot, int vol);

        /// <summary>
        /// int sv_set_event_t( int slot, int set, int t ) ;
        /// </summary>
        int sv_set_event_t(int slot, int set, int t);

        /// <summary>
        /// int sv_send_event( int slot, int track_num, int note, int vel, int module, int ctl, int ctl_val ) ;
        /// </summary>
        int sv_send_event(int slot, int track_num, int note, int vel, int module, int ctl, int ctl_val);

        /// <summary>
        /// int sv_get_current_line( int slot ) ; /* Get current line number */
        /// </summary>
        int sv_get_current_line(int slot);

        /// <summary>
        /// int sv_get_current_line2( int slot ) ; /* Get current line number in fixed point format 27.5 */
        /// </summary>
        int sv_get_current_line2(int slot);

        /// <summary>
        /// int sv_get_current_signal_level( int slot, int channel ) ; /* From 0 to 255 */
        /// </summary>
        int sv_get_current_signal_level(int slot, int channel);

        /// <summary>
        /// const char* sv_get_song_name( int slot ) ;
        /// </summary>
        IntPtr sv_get_song_name(int slot);

        /// <summary>
        /// int sv_set_song_name( int slot, const char* name ) ;
        /// </summary>
        int sv_set_song_name(int slot, IntPtr name);

        /// <summary>
        /// int sv_get_song_bpm( int slot ) ;
        /// </summary>
        int sv_get_song_bpm(int slot);

        /// <summary>
        /// int sv_get_song_tpl( int slot ) ;
        /// </summary>
        int sv_get_song_tpl(int slot);

        /// <summary>
        /// uint32_t sv_get_song_length_frames( int slot ) ;
        /// </summary>
        uint sv_get_song_length_frames(int slot);

        /// <summary>
        /// uint32_t sv_get_song_length_lines( int slot ) ;
        /// </summary>
        uint sv_get_song_length_lines(int slot);

        /// <summary>
        /// int sv_get_time_map( int slot, int start_line, int len, uint32_t* dest, int flags ) ;
        /// </summary>
        int sv_get_time_map(int slot, int start_line, int len, IntPtr dest, int flags);

        /// <summary>
        /// int sv_new_module( int slot, const char* type, const char* name, int x, int y, int z ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_new_module(int slot, IntPtr type, IntPtr name, int x, int y, int z);

        /// <summary>
        /// int sv_remove_module( int slot, int mod_num ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_remove_module(int slot, int mod_num);

        /// <summary>
        /// int sv_connect_module( int slot, int source, int destination ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_connect_module(int slot, int source, int destination);

        /// <summary>
        /// int sv_disconnect_module( int slot, int source, int destination ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_disconnect_module(int slot, int source, int destination);

        /// <summary>
        /// int sv_load_module( int slot, const char* file_name, int x, int y, int z ) ;
        /// </summary>
        int sv_load_module(int slot, IntPtr file_name, int x, int y, int z);

        /// <summary>
        /// int sv_load_module_from_memory( int slot, void* data, uint32_t data_size, int x, int y, int z ) ;
        /// </summary>
        int sv_load_module_from_memory(int slot, IntPtr data, uint data_size, int x, int y, int z);

        /// <summary>
        /// int sv_sampler_load( int slot, int mod_num, const char* file_name, int sample_slot ) ;
        /// </summary>
        int sv_sampler_load(int slot, int mod_num, IntPtr file_name, int sample_slot);

        /// <summary>
        /// int sv_sampler_load_from_memory( int slot, int mod_num, void* data, uint32_t data_size, int sample_slot ) ;
        /// </summary>
        int sv_sampler_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size, int sample_slot);

        /// <summary>
        /// int sv_metamodule_load( int slot, int mod_num, const char* file_name ) ;
        /// </summary>
        int sv_metamodule_load(int slot, int mod_num, IntPtr file_name);

        /// <summary>
        /// int sv_metamodule_load_from_memory( int slot, int mod_num, void* data, uint32_t data_size ) ;
        /// </summary>
        int sv_metamodule_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size);

        /// <summary>
        /// int sv_vplayer_load( int slot, int mod_num, const char* file_name ) ;
        /// </summary>
        int sv_vplayer_load(int slot, int mod_num, IntPtr file_name);

        /// <summary>
        /// int sv_vplayer_load_from_memory( int slot, int mod_num, void* data, uint32_t data_size ) ;
        /// </summary>
        int sv_vplayer_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size);

        /// <summary>
        /// int sv_get_number_of_modules( int slot ) ;
        /// </summary>
        int sv_get_number_of_modules(int slot);

        /// <summary>
        /// int sv_find_module( int slot, const char* name ) ;
        /// </summary>
        int sv_find_module(int slot, IntPtr name);

        /// <summary>
        /// uint32_t sv_get_module_flags( int slot, int mod_num ) ; /* SV_MODULE_FLAG_* */
        /// </summary>
        uint sv_get_module_flags(int slot, int mod_num);

        /// <summary>
        /// int* sv_get_module_inputs( int slot, int mod_num ) ;
        /// </summary>
        IntPtr sv_get_module_inputs(int slot, int mod_num);

        /// <summary>
        /// int* sv_get_module_outputs( int slot, int mod_num ) ;
        /// </summary>
        IntPtr sv_get_module_outputs(int slot, int mod_num);

        /// <summary>
        /// const char* sv_get_module_type( int slot, int mod_num ) ;
        /// </summary>
        IntPtr sv_get_module_type(int slot, int mod_num);

        /// <summary>
        /// const char* sv_get_module_name( int slot, int mod_num ) ;
        /// </summary>
        IntPtr sv_get_module_name(int slot, int mod_num);

        /// <summary>
        /// int sv_set_module_name( int slot, int mod_num, const char* name ) ;
        /// </summary>
        int sv_set_module_name(int slot, int mod_num, IntPtr name);

        /// <summary>
        /// uint32_t sv_get_module_xy( int slot, int mod_num ) ;
        /// </summary>
        uint sv_get_module_xy(int slot, int mod_num);

        /// <summary>
        /// int sv_set_module_xy( int slot, int mod_num, int x, int y ) ;
        /// </summary>
        int sv_set_module_xy(int slot, int mod_num, int x, int y);

        /// <summary>
        /// int sv_get_module_color( int slot, int mod_num ) ;
        /// </summary>
        int sv_get_module_color(int slot, int mod_num);

        /// <summary>
        /// int sv_set_module_color( int slot, int mod_num, int color ) ;
        /// </summary>
        int sv_set_module_color(int slot, int mod_num, int color);

        /// <summary>
        /// uint32_t sv_get_module_finetune( int slot, int mod_num ) ;
        /// </summary>
        uint sv_get_module_finetune(int slot, int mod_num);

        /// <summary>
        /// int sv_set_module_finetune( int slot, int mod_num, int finetune ) ;
        /// </summary>
        int sv_set_module_finetune(int slot, int mod_num, int finetune);

        /// <summary>
        /// int sv_set_module_relnote( int slot, int mod_num, int relative_note ) ;
        /// </summary>
        int sv_set_module_relnote(int slot, int mod_num, int relative_note);

        /// <summary>
        /// uint32_t sv_get_module_scope2( int slot, int mod_num, int channel, int16_t* dest_buf, uint32_t samples_to_read ) ;
        /// </summary>
        uint sv_get_module_scope2(int slot, int mod_num, int channel, IntPtr dest_buf, uint samples_to_read);

        /// <summary>
        /// int sv_module_curve( int slot, int mod_num, int curve_num, float* data, int len, int w ) ;
        /// </summary>
        int sv_module_curve(int slot, int mod_num, int curve_num, IntPtr data, int len, int w);

        /// <summary>
        /// int sv_get_number_of_module_ctls( int slot, int mod_num ) ;
        /// </summary>
        int sv_get_number_of_module_ctls(int slot, int mod_num);

        /// <summary>
        /// const char* sv_get_module_ctl_name( int slot, int mod_num, int ctl_num ) ;
        /// </summary>
        IntPtr sv_get_module_ctl_name(int slot, int mod_num, int ctl_num);

        /// <summary>
        /// int sv_get_module_ctl_value( int slot, int mod_num, int ctl_num, int scaled ) ;
        /// </summary>
        int sv_get_module_ctl_value(int slot, int mod_num, int ctl_num, int scaled);

        /// <summary>
        /// int sv_set_module_ctl_value( int slot, int mod_num, int ctl_num, int val, int scaled ) ;
        /// </summary>
        int sv_set_module_ctl_value(int slot, int mod_num, int ctl_num, int val, int scaled);

        /// <summary>
        /// int sv_get_module_ctl_min( int slot, int mod_num, int ctl_num, int scaled ) ;
        /// </summary>
        int sv_get_module_ctl_min(int slot, int mod_num, int ctl_num, int scaled);

        /// <summary>
        /// int sv_get_module_ctl_max( int slot, int mod_num, int ctl_num, int scaled ) ;
        /// </summary>
        int sv_get_module_ctl_max(int slot, int mod_num, int ctl_num, int scaled);

        /// <summary>
        /// int sv_get_module_ctl_offset( int slot, int mod_num, int ctl_num ) ; /* Get display value offset */
        /// </summary>
        int sv_get_module_ctl_offset(int slot, int mod_num, int ctl_num);

        /// <summary>
        /// int sv_get_module_ctl_type( int slot, int mod_num, int ctl_num ) ; /* 0 - normal (scaled); 1 - selector (enum); */
        /// </summary>
        int sv_get_module_ctl_type(int slot, int mod_num, int ctl_num);

        /// <summary>
        /// int sv_get_module_ctl_group( int slot, int mod_num, int ctl_num ) ;
        /// </summary>
        int sv_get_module_ctl_group(int slot, int mod_num, int ctl_num);

        /// <summary>
        /// int sv_new_pattern( int slot, int clone, int x, int y, int tracks, int lines, int icon_seed, const char* name ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_new_pattern(int slot, int clone, int x, int y, int tracks, int lines, int icon_seed, IntPtr name);

        /// <summary>
        /// int sv_remove_pattern( int slot, int pat_num ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_remove_pattern(int slot, int pat_num);

        /// <summary>
        /// int sv_get_number_of_patterns( int slot ) ;
        /// </summary>
        int sv_get_number_of_patterns(int slot);

        /// <summary>
        /// int sv_find_pattern( int slot, const char* name ) ;
        /// </summary>
        int sv_find_pattern(int slot, IntPtr name);

        /// <summary>
        /// int sv_get_pattern_x( int slot, int pat_num ) ;
        /// </summary>
        int sv_get_pattern_x(int slot, int pat_num);

        /// <summary>
        /// int sv_get_pattern_y( int slot, int pat_num ) ;
        /// </summary>
        int sv_get_pattern_y(int slot, int pat_num);

        /// <summary>
        /// int sv_set_pattern_xy( int slot, int pat_num, int x, int y ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_set_pattern_xy(int slot, int pat_num, int x, int y);

        /// <summary>
        /// int sv_get_pattern_tracks( int slot, int pat_num ) ;
        /// </summary>
        int sv_get_pattern_tracks(int slot, int pat_num);

        /// <summary>
        /// int sv_get_pattern_lines( int slot, int pat_num ) ;
        /// </summary>
        int sv_get_pattern_lines(int slot, int pat_num);

        /// <summary>
        /// int sv_set_pattern_size( int slot, int pat_num, int tracks, int lines ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_set_pattern_size(int slot, int pat_num, int tracks, int lines);

        /// <summary>
        /// const char* sv_get_pattern_name( int slot, int pat_num ) ;
        /// </summary>
        IntPtr sv_get_pattern_name(int slot, int pat_num);

        /// <summary>
        /// int sv_set_pattern_name( int slot, int pat_num, const char* name ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_set_pattern_name(int slot, int pat_num, IntPtr name);

        /// <summary>
        /// sunvox_note* sv_get_pattern_data( int slot, int pat_num ) ;
        /// </summary>
        IntPtr sv_get_pattern_data(int slot, int pat_num);

        /// <summary>
        /// int sv_set_pattern_event( int slot, int pat_num, int track, int line, int nn, int vv, int mm, int ccee, int xxyy ) ;
        /// </summary>
        int sv_set_pattern_event(int slot, int pat_num, int track, int line, int nn, int vv, int mm, int ccee, int xxyy);

        /// <summary>
        /// int sv_get_pattern_event( int slot, int pat_num, int track, int line, int column ) ;
        /// </summary>
        int sv_get_pattern_event(int slot, int pat_num, int track, int line, int column);

        /// <summary>
        /// int sv_pattern_mute( int slot, int pat_num, int mute ) ; /* USE LOCK/UNLOCK! */
        /// </summary>
        int sv_pattern_mute(int slot, int pat_num, int mute);

        /// <summary>
        /// uint32_t sv_get_ticks( void ) ;
        /// </summary>
        uint sv_get_ticks();

        /// <summary>
        /// uint32_t sv_get_ticks_per_second( void ) ;
        /// </summary>
        uint sv_get_ticks_per_second();

        /// <summary>
        /// const char* sv_get_log( int size ) ;
        /// </summary>
        IntPtr sv_get_log(int size);
    }
}
