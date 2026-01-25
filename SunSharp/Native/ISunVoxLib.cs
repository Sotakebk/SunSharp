namespace SunSharp.Native
{
    /// <summary>
    /// Friendlier interface for SunVox native library functions.
    /// See the <see cref="SunVoxLibNativeWrapper"/> for the default, preferred implementation.
    /// </summary>
    public partial interface ISunVoxLib
    {
        /// <inheritdoc cref="SunVoxLibNativeWrapper.Initialize"/>
        SunVoxVersion Initialize(int sampleRate, string? config = null, AudioChannels channels = AudioChannels.Stereo, SunVoxInitOptions options = SunVoxInitOptions.None);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.Deinitialize"/>
        void Deinitialize();

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetLog"/>
        string? GetLog(int size);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetTicks"/>
        uint GetTicks();

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetTicksPerSecond"/>
        uint GetTicksPerSecond();

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetSampleRate"/>
        int GetSampleRate();

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetSongBaseVersion"/>
        SunVoxVersion GetSongBaseVersion(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.UpdateInputDevices"/>
        void UpdateInputDevices();

        /// <inheritdoc cref="SunVoxLibNativeWrapper.AudioCallback(float[], AudioChannels, int, uint)"/>
        bool AudioCallback(float[] outputBuffer, AudioChannels channels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.AudioCallback(float[], AudioChannels, int, uint)"/>
        bool AudioCallback(short[] outputBuffer, AudioChannels channels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels,
            float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.IsPlaying"/>
        bool IsPlaying(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetAutomaticStop"/>
        bool GetAutomaticStop(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetCurrentLine"/>
        int GetCurrentLine(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetCurrentLineWithTenthPart"/>
        int GetCurrentLineWithTenthPart(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetCurrentSignalLevel"/>
        int GetCurrentSignalLevel(int slotId, AudioChannel channel);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetSongBpm"/>
        int GetSongBpm(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetSongLengthInFrames"/>
        uint GetSongLengthInFrames(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetSongLengthInLines"/>
        uint GetSongLengthInLines(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetSongName"/>
        string? GetSongName(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetSongName"/>
        void SetSongName(int slotId, string newName);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetSongTpl"/>
        int GetSongTpl(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SaveToFile"/>
        void SaveToFile(int slotId, string path);

        ///// <inheritdoc cref="SunVoxLibNativeWrapper.SaveToMemory"/>
        //byte[] SaveToMemory(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SendEvent(int, int, PatternEvent)"/>
        void SendEvent(int slotId, int track, PatternEvent data);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SendEvent(int, int, int, int, int, int, int)"/>
        void SendEvent(int slotId, int track, int nn = 0, int vv = 0, int mm = 0, int ccee = 0, int xxyy = 0);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetSendEventTimestamp"/>
        void SetSendEventTimestamp(int slotId, bool reset, int t);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.Volume"/>
        int Volume(int slotId, int volume);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetTimeMap"/>
        uint[] GetTimeMap(int slotId, int startLine, int length, TimeMapType type);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.Load(int, string)"/>
        void Load(int slotId, string path);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.Load(int, byte[])"/>
        void Load(int slotId, byte[] data);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.OpenSlot"/>
        void OpenSlot(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.CloseSlot"/>
        void CloseSlot(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LockSlot"/>
        void LockSlot(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.UnlockSlot"/>
        void UnlockSlot(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetAutomaticStop"/>
        void SetAutomaticStop(int slotId, bool autoStop);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.StopPlayback"/>
        void StopPlayback(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.StartPlayback"/>
        void StartPlayback(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.StartPlaybackFromBeginning"/>
        void StartPlaybackFromBeginning(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.Rewind"/>
        void Rewind(int slotId, int line);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.PauseAudioStream"/>
        void PauseAudioStream(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.ResumeAudioStream"/>
        void ResumeAudioStream(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.ResumeStreamOnSyncEffect"/>
        void ResumeStreamOnSyncEffect(int slotId);
    }
}
