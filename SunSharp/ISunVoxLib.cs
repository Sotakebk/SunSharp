namespace SunSharp
{
    public partial interface ISunVoxLib
    {
        /// <summary>
        /// Initialize the engine. May be called again to re-initialize the engine.
        /// </summary>
        /// <param name="sampleRate">Sample rate. If not using audio callback, may be set to -1.</param>
        /// <param name="config">
        /// Configuration, which may include input and output devices. See SunVox Lib documentation for
        /// details.
        /// </param>
        /// <param name="channels">Channels to be used.</param>
        /// <param name="flags">Initialization flags.</param>
        /// <returns>The version of underlying library.</returns>
        LibraryVersion Initialize(int sampleRate, string? config = null, AudioChannels channels = AudioChannels.Stereo, InitFlags flags = InitFlags.None);

        /// <summary>
        /// Deinitializes the library, frees resources.
        /// </summary>
        void Deinitialize();

        /// <summary>
        /// Get first <paramref name="size" /> characters of engine logs.
        /// </summary>
        /// <param name="size">Character count to be read.</param>
        /// <returns></returns>
        string? GetLog(int size);

        /// <summary>
        /// Use this method to get the current tick counter (from 0 to 0xFFFFFFFF). <br />
        /// SunVox engine uses system-provided time space, measured in system ticks (don't confuse it with the project ticks).
        /// </summary>
        /// <returns></returns>
        uint GetTicks();

        /// <summary>
        /// Use this method to get the number of system ticks per second. <br />
        /// SunVox engine uses system-provided time space, measured in system ticks (don't confuse it with the project ticks).
        /// </summary>
        /// <returns></returns>
        uint GetTicksPerSecond();

        /// <summary>
        /// Get the current sample rate.
        /// </summary>
        /// <returns></returns>
        int GetSampleRate();

        /// <summary>
        /// Handle input ON/OFF requests to enable/disable input ports of the sound card (for example, after the module
        /// creation). <br />
        /// Call it from the main thread only, where the SunVox sound stream is not locked.
        /// </summary>
        void UpdateInputDevices();

        /// <summary>
        /// Get the next piece of audio. <br />
        /// If audio is stereo, the samples will be interlaced, and the buffer size must be a multiple of two.
        /// </summary>
        /// <param name="outputBuffer">Buffer to write sound data to.</param>
        /// <param name="channels">Channels the library was initialized with.</param>
        /// <param name="latency">Audio latency (in frames).</param>
        /// <param name="outTime">Buffer output time (in system ticks).</param>
        /// <returns><see langword="false" /> if buffer was filled with zeros.</returns>
        bool AudioCallback(float[] outputBuffer, AudioChannels channels, int latency, uint outTime);

        /// <inheritdoc cref="AudioCallback(float[], AudioChannels, int, uint)" />
        bool AudioCallback(short[] outputBuffer, AudioChannels channels, int latency, uint outTime);

        /// <summary>
        /// Get the next piece of audio. <br />
        /// If audio is stereo, the samples will be interlaced, and the buffer size must be a multiple of two.
        /// Sends equal size buffer of an input device, which will be applied to any input modules.
        /// </summary>
        /// <param name="outputBuffer">Buffer to write sound data to.</param>
        /// <param name="outputChannels">Channels the library was initialized with.</param>
        /// <param name="inputBuffer">Buffer to read sound data from.</param>
        /// <param name="inputChannels">Input data channels.</param>
        /// <param name="latency">Audio latency (in frames).</param>
        /// <param name="outTime">Buffer output time (in system ticks).</param>
        /// <returns><see langword="false" /> if buffer was filled with zeros.</returns>
        bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)" />
        bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)" />
        bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels,
            float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)" />
        bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        bool IsPlaying(int slotId);

        /// <summary>
        /// Get current behaviour for reaching the end of project timeline.
        /// </summary>
        /// <returns><see langword="true" /> if project is set to stop after reaching the end.</returns>
        bool GetAutostop(int slotId);

        /// <summary>
        /// Get current line number on the timeline.
        /// </summary>
        /// <param name="slotId"></param>
        /// <returns></returns>
        int GetCurrentLine(int slotId);

        /// <summary>
        /// Get current line in fixed point format (with tenth part).
        /// </summary>
        int GetCurrentLineWithTenthPart(int slotId);

        /// <summary>
        /// Get current signal level from the output module.
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        int GetCurrentSignalLevel(int slotId, int channel);

        /// <summary>
        /// Get the project BPM (Beats Per Minute).
        /// </summary>
        /// <param name="slotId"></param>
        /// <returns></returns>
        int GetSongBpm(int slotId);

        /// <summary>
        /// Get the project length in frames. <br />
        /// A frame is a pair of audio signal samples (left and right channel amplitudes).
        /// The sample rate 44100 Hz means that you hear 44100 frames per second.
        /// </summary>
        /// <param name="slotId"></param>
        /// <returns></returns>
        uint GetSongLengthInFrames(int slotId);

        /// <summary>
        /// Get the project length in frames or lines.
        /// </summary>
        /// <param name="slotId"></param>
        /// <returns></returns>
        uint GetSongLengthInLines(int slotId);

        string? GetSongName(int slotId);

        void SetSongName(int slotId, string newName);

        /// <summary>
        /// Get the project TPL (Ticks Per Line).
        /// </summary>
        /// <param name="slotId"></param>
        /// <returns></returns>
        int GetSongTpl(int slotId);

        /// <summary>
        /// Save the SunVox project.
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="path"></param>
        void Save(int slotId, string path);

        /// <summary>
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="track"></param>
        /// <param name="data"></param>
        void SendEvent(int slotId, int track, PatternEvent data);

        /// <summary>
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="track"></param>
        /// <param name="nn"></param>
        /// <param name="vv"></param>
        /// <param name="mm"></param>
        /// <param name="ccee"></param>
        /// <param name="xxyy"></param>
        void SendEvent(int slotId, int track, int nn = 0, int vv = 0, int mm = 0, int ccee = 0, int xxyy = 0);

        /// <summary>
        /// Set the timestamp of events to be sent.
        /// <br />
        /// Every event you send has a timestamp - this is the time when the event was generated (for example, when a key was
        /// pressed).
        /// <br />
        /// If <paramref name="t" /> is zero, the event will be heard as soon as possible, which is delayed by double the sound
        /// latency.
        /// <br />
        /// If <paramref name="t" /> is nonzero, the event will be additionally delayed by this many ticks.
        /// <br />
        /// See also: <seealso cref="GetTicksPerSecond" />.
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="reset"></param>
        /// <param name="t"></param>
        void SetSendEventTimestamp(int slotId, bool reset = true, int t = 0);

        /// <summary>
        /// Get and set volume. Call with <paramref name="volume" /> = -1 to only get the value.
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="volume">Value in range 0-256.</param>
        /// <returns>Previous volume in range 0-256.</returns>
        int Volume(int slotId, int volume);

        /// <summary>
        /// Get the project time map.
        /// <br />
        /// For <paramref name="type" /> = <see cref="TimeMapType.Speed" />, Nth value equals speed at the beginning of Nth
        /// line (Bpm | Tpl &lt;&lt; 16).
        /// <br />
        /// For <paramref name="type" /> = <see cref="TimeMapType.FrameCount" />, Nth value equals frame counter at the
        /// beginning of Nth line.
        /// </summary>
        uint[] GetTimeMap(int slotId, int startLine, int length, TimeMapType type);

        /// <summary>
        /// Load a project from file.
        /// </summary>
        /// <param name="slotId">Target slot ID.</param>
        /// <param name="path">Path to the file; may be relative or absolute.</param>
        void Load(int slotId, string path);

        /// <summary>
        /// Load a project from memory.
        /// </summary>
        void Load(int slotId, byte[] data);

        /// <summary>
        /// Open slot. Each slot can contain one independent implementation of the SunVox engine.
        /// You can use several slots simultaneously (for example, one slot for music and another for effects).
        /// Max number of slots: 16.
        /// </summary>
        /// <param name="slotId">A value between 0 and 15.</param>
        void OpenSlot(int slotId);

        /// <summary>
        /// Close the slot.
        /// </summary>
        /// <param name="slotId"></param>
        void CloseSlot(int slotId);

        /// <summary>
        /// Enter a lock block.
        /// Use to send multiple events at the same time, read or write data from multiple threads.
        /// Remember to call <see cref="ISunVoxLib.UnlockSlot" />!
        /// </summary>
        void LockSlot(int slotId);

        /// <summary>
        /// Leave a lock block.
        /// </summary>
        void UnlockSlot(int slotId);

        /// <summary>
        /// Set/get autostop mode. When autostop is off, the project plays endlessly in a loop.
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="autoStop"></param>
        void SetAutoStop(int slotId, bool autoStop);

        /// <summary>
        /// First call - stop playing; second call - reset all SunVox activity and switch the engine to standby mode.
        /// </summary>
        /// <param name="slotId"></param>
        void StopPlayback(int slotId); // TODO confirm name

        /// <summary>
        /// Start playing the project from the current position.
        /// </summary>
        /// <param name="slotId"></param>
        void StartPlayback(int slotId); // TODO confirm name

        /// <summary>
        /// Start playing the project from the beginning (line 0).
        /// </summary>
        /// <param name="slotId"></param>
        void StartPlaybackFromBeginning(int slotId); // TODO confirm name

        /// <summary>
        /// Jump to the specified position (line number on the timeline).
        /// </summary>
        /// <param name="slotId"></param>
        /// <param name="line"></param>
        void Rewind(int slotId, int line); // TODO confirm name

        /// <summary>
        /// Pause the audio stream on the specified slot.
        /// </summary>
        /// <param name="slotId"></param>
        void PauseStream(int slotId); // TODO confirm name

        /// <summary>
        /// Resume the audio stream on the specified slot.
        /// </summary>
        /// <param name="slotId"></param>
        void ResumeStream(int slotId); // TODO confirm name

        /// <summary>
        /// Wait for sync (pattern effect 0x33 on any slot) and resume the audio stream on the specified slot.
        /// </summary>
        /// <param name="slotId"></param>
        void ResumeStreamOnSyncEffect(int slotId); // TODO confirm name
    }
}
