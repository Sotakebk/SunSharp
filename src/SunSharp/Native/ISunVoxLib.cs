namespace SunSharp.Native
{
    /// <inheritdoc cref="SunVoxLib"/>
    public partial interface ISunVoxLib
    {
        /// <inheritdoc cref="SunVoxLib.Initialize"/>
        SunVoxVersion Initialize(int sampleRate, string? config = null, AudioChannels channels = AudioChannels.Stereo, SunVoxInitOptions options = SunVoxInitOptions.None);

        /// <inheritdoc cref="SunVoxLib.Deinitialize"/>
        void Deinitialize();

        /// <inheritdoc cref="SunVoxLib.GetLog"/>
        string? GetLog(int size);

        /// <inheritdoc cref="SunVoxLib.GetTicks"/>
        uint GetTicks();

        /// <inheritdoc cref="SunVoxLib.GetTicksPerSecond"/>
        uint GetTicksPerSecond();

        /// <inheritdoc cref="SunVoxLib.GetSampleRate"/>
        int GetSampleRate();

        /// <inheritdoc cref="SunVoxLib.GetSongBaseVersion"/>
        SunVoxVersion GetSongBaseVersion(int slotId);

        /// <inheritdoc cref="SunVoxLib.UpdateInputDevices"/>
        void UpdateInputDevices();

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[], AudioChannels, int, uint)"/>
        bool AudioCallback(float[] outputBuffer, AudioChannels channels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[], AudioChannels, int, uint)"/>
        bool AudioCallback(short[] outputBuffer, AudioChannels channels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        bool AudioCallback(float[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels,
            float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[], AudioChannels, float[], AudioChannels, int, uint)"/>
        bool AudioCallback(short[] outputBuffer, AudioChannels outputChannels,
            short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVoxLib.IsPlaying"/>
        bool IsPlaying(int slotId);

        /// <inheritdoc cref="SunVoxLib.GetAutomaticStop"/>
        bool GetAutomaticStop(int slotId);

        /// <inheritdoc cref="SunVoxLib.GetCurrentLine"/>
        int GetCurrentLine(int slotId);

        /// <inheritdoc cref="SunVoxLib.GetCurrentLineWithTenthPart"/>
        int GetCurrentLineWithTenthPart(int slotId);

        /// <inheritdoc cref="SunVoxLib.GetCurrentSignalLevel"/>
        int GetCurrentSignalLevel(int slotId, AudioChannel channel);

        /// <inheritdoc cref="SunVoxLib.GetSongBpm"/>
        int GetSongBpm(int slotId);

        /// <inheritdoc cref="SunVoxLib.GetSongLengthInFrames"/>
        uint GetSongLengthInFrames(int slotId);

        /// <inheritdoc cref="SunVoxLib.GetSongLengthInLines"/>
        uint GetSongLengthInLines(int slotId);

        /// <inheritdoc cref="SunVoxLib.GetSongName"/>
        string? GetSongName(int slotId);

        /// <inheritdoc cref="SunVoxLib.SetSongName"/>
        void SetSongName(int slotId, string value);

        /// <inheritdoc cref="SunVoxLib.GetSongTpl"/>
        int GetSongTpl(int slotId);

        /// <inheritdoc cref="SunVoxLib.SaveToFile"/>
        void SaveToFile(int slotId, string path);

        ///// <inheritdoc cref="SunVoxLibNativeWrapper.SaveToMemory"/>
        //byte[] SaveToMemory(int slotId);

        /// <inheritdoc cref="SunVoxLib.SendEvent(int, int, PatternEvent)"/>
        void SendEvent(int slotId, int track, PatternEvent data);

        /// <inheritdoc cref="SunVoxLib.SendEvent(int, int, int, int, int, int, int)"/>
        void SendEvent(int slotId, int track, int nn = 0, int vv = 0, int mm = 0, int ccee = 0, int xxyy = 0);

        /// <inheritdoc cref="SunVoxLib.SetEventTiming"/>
        void SetEventTiming(int slotId, int timestamp);

        /// <inheritdoc cref="SunVoxLib.ResetEventTiming"/>
        public void ResetEventTiming(int slotId);

        /// <inheritdoc cref="SunVoxLib.Volume"/>
        int Volume(int slotId, int volume);

        /// <inheritdoc cref="SunVoxLib.GetTimeMapFrames"/>
        uint[] GetTimeMapFrames(int slotId, int startLine, int length);

        /// <inheritdoc cref="SunVoxLib.GetTimeMapSpeed"/>
        Speed[] GetTimeMapSpeed(int slotId, int startLine, int length);

        /// <inheritdoc cref="SunVoxLib.Load(int, string)"/>
        void Load(int slotId, string path);

        /// <inheritdoc cref="SunVoxLib.Load(int, byte[])"/>
        void Load(int slotId, byte[] data);

        /// <inheritdoc cref="SunVoxLib.OpenSlot"/>
        void OpenSlot(int slotId);

        /// <inheritdoc cref="SunVoxLib.CloseSlot"/>
        void CloseSlot(int slotId);

        /// <inheritdoc cref="SunVoxLib.LockSlot"/>
        void LockSlot(int slotId);

        /// <inheritdoc cref="SunVoxLib.UnlockSlot"/>
        void UnlockSlot(int slotId);

        /// <inheritdoc cref="SunVoxLib.SetAutomaticStop"/>
        void SetAutomaticStop(int slotId, bool enable);

        /// <inheritdoc cref="SunVoxLib.StopPlayback"/>
        void StopPlayback(int slotId);

        /// <inheritdoc cref="SunVoxLib.StartPlayback"/>
        void StartPlayback(int slotId);

        /// <inheritdoc cref="SunVoxLib.StartPlaybackFromBeginning"/>
        void StartPlaybackFromBeginning(int slotId);

        /// <inheritdoc cref="SunVoxLib.Rewind"/>
        void Rewind(int slotId, int line);

        /// <inheritdoc cref="SunVoxLib.PauseAudioStream"/>
        void PauseAudioStream(int slotId);

        /// <inheritdoc cref="SunVoxLib.ResumeAudioStream"/>
        void ResumeAudioStream(int slotId);

        /// <inheritdoc cref="SunVoxLib.ResumeStreamOnSyncEffect"/>
        void ResumeStreamOnSyncEffect(int slotId);
    }
}
