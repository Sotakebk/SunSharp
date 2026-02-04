using System;
using SunSharp.Modules;
using SunSharp.Native;

namespace SunSharp
{
    public sealed class SlotAlreadyOpenException : Exception
    {
        public SlotAlreadyOpenException()
        {
        }

        public SlotAlreadyOpenException(int index) : base($"Slot ID={index} is already open.")
        {
        }

        public SlotAlreadyOpenException(string message) : base(message)
        {
        }

        public SlotAlreadyOpenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public sealed class SlotAlreadyClosedException : Exception
    {
        public SlotAlreadyClosedException()
        {
        }

        public SlotAlreadyClosedException(int index) : base($"Slot ID={index} is already closed.")
        {
        }

        public SlotAlreadyClosedException(string message) : base(message)
        {
        }

        public SlotAlreadyClosedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <inheritdoc cref="Slot"/>
    public interface ISlot
    {
        /// <inheritdoc cref="Slot.Id"/>
        int Id { get; }

        /// <inheritdoc cref="Slot.VirtualPattern"/>
        IVirtualPattern VirtualPattern { get; }

        /// <inheritdoc cref="Slot.Timeline"/>
        ITimeline Timeline { get; }

        /// <inheritdoc cref="Slot.Synthesizer"/>
        ISynthesizer Synthesizer { get; }

        /// <inheritdoc cref="Slot.SunVox"/>
        ISunVox SunVox { get; }

        /// <inheritdoc cref="Slot.IsOpen"/>
        bool IsOpen { get; }

        /// <inheritdoc cref="Slot.AcquireLock"/>
        IDisposable AcquireLock();

        /// <inheritdoc cref="Slot.Lock"/>
        void Lock();

        /// <inheritdoc cref="Slot.Unlock"/>
        void Unlock();

        /// <inheritdoc cref="Slot.Open"/>
        void Open();

        /// <inheritdoc cref="Slot.Close"/>
        void Close();

        /// <inheritdoc cref="Slot.Load(string)"/>
        void Load(string path);

        /// <inheritdoc cref="Slot.Load(byte[])"/>
        void Load(byte[] data);

        /// <inheritdoc cref="Slot.SaveToFile"/>
        void SaveToFile(string path);

        /// <inheritdoc cref="Slot.StartPlayback"/>
        void StartPlayback();

        /// <inheritdoc cref="Slot.StartPlaybackFromBeginning"/>
        void StartPlaybackFromBeginning();

        /// <inheritdoc cref="Slot.StopPlayback"/>
        void StopPlayback();

        /// <inheritdoc cref="Slot.ResumeStreamOnSyncEffect"/>
        void ResumeStreamOnSyncEffect();

        /// <inheritdoc cref="Slot.PauseAudioStream"/>
        void PauseAudioStream();

        /// <inheritdoc cref="Slot.ResumeAudioStream"/>
        void ResumeAudioStream();

        /// <inheritdoc cref="Slot.SetAutomaticStop"/>
        void SetAutomaticStop(bool enable);

        /// <inheritdoc cref="Slot.GetAutomaticStop"/>
        bool GetAutomaticStop();

        /// <inheritdoc cref="Slot.IsPlaying"/>
        bool IsPlaying();

        /// <inheritdoc cref="Slot.Rewind"/>
        void Rewind(int lineNumber);

        /// <inheritdoc cref="Slot.GetCurrentLine"/>
        int GetCurrentLine();

        /// <inheritdoc cref="Slot.GetCurrentLineWithTenthPart"/>
        int GetCurrentLineWithTenthPart();

        /// <inheritdoc cref="Slot.GetCurrentSignalLevel"/>
        int GetCurrentSignalLevel(AudioChannel channel = AudioChannel.Left);

        /// <inheritdoc cref="Slot.GetVolume"/>
        int GetVolume();

        /// <inheritdoc cref="Slot.SetVolume"/>
        void SetVolume(int value);

        /// <inheritdoc cref="Slot.GetSongBpm"/>
        int GetSongBpm();

        /// <inheritdoc cref="Slot.GetSongTpl"/>
        int GetSongTpl();

        /// <inheritdoc cref="Slot.GetSongLengthInLines"/>
        uint GetSongLengthInLines();

        /// <inheritdoc cref="Slot.GetSongLengthInFrames"/>
        uint GetSongLengthInFrames();

        /// <inheritdoc cref="Slot.GetSongName"/>
        string? GetSongName();

        /// <inheritdoc cref="Slot.SetSongName"/>
        void SetSongName(string value);

        /// <inheritdoc cref="Slot.GetTimeMapFrames"/>
        uint[] GetTimeMapFrames(int startLine, int length);

        /// <inheritdoc cref="Slot.GetTimeMapSpeed"/>
        Speed[] GetTimeMapSpeed(int startLine, int length);
    }

    /// <summary>
    /// Represents a SunVox slot.
    /// </summary>
    public sealed class Slot : ISlot
    {
        /// <summary>
        /// Gets the slot ID.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The number of times this slot has been opened.
        /// </summary>
        internal uint OpenCount { get; private set; }

        /// <summary>
        /// Virtual, 16-track pattern for sending events to the engine.
        /// </summary>
        public VirtualPattern VirtualPattern { get; }

        /// <summary>
        /// Project timeline, containing all the existing patterns.
        /// </summary>
        public Timeline Timeline { get; }

        /// <summary>
        /// Project synthesizer, containing all the existing modules.
        /// </summary>
        public Synthesizer Synthesizer { get; }

        /// <summary>
        /// SunVox instance this slot belongs to.
        /// </summary>
#if SUNSHARP_RELEASE
        public SunVox SunVox { get; }
#else
        public ISunVox SunVox { get; }
#endif
        /// <inheritdoc/>
        IVirtualPattern ISlot.VirtualPattern => VirtualPattern;

        /// <inheritdoc/>
        ITimeline ISlot.Timeline => Timeline;

        /// <inheritdoc/>
        ISynthesizer ISlot.Synthesizer => Synthesizer;

        /// <inheritdoc/>
        ISunVox ISlot.SunVox => SunVox;

        /// <summary>
        /// Underlying library instance.
        /// </summary>
#if SUNSHARP_RELEASE
        public SunVoxLib Library { get; }
#else
        public ISunVoxLib Library { get; }
#endif

        /// <summary>
        /// Gets a value indicating whether the slot is currently open.
        /// </summary>
        public bool IsOpen { get; private set; }

        private readonly object _slotManagementLock;
#if SUNSHARP_RELEASE
        internal Slot(int id, object slotManagementLock, SunVox sunVox)
#else
        internal Slot(int id, object slotManagementLock, ISunVox sunVox)
#endif
        {
            Id = id;
            _slotManagementLock = slotManagementLock;
            SunVox = sunVox;
            Library = sunVox.Library;
            VirtualPattern = new VirtualPattern(this);
            Timeline = new Timeline(this);
            Synthesizer = new Synthesizer(this);
        }

        #region locks

        /// <inheritdoc cref="ISunVoxLib.LockSlot"/>
        public void Lock() => Library.LockSlot(Id);

        /// <inheritdoc cref="ISunVoxLib.UnlockSlot"/>
        public void Unlock() => Library.UnlockSlot(Id);

        /// <summary>
        /// Can be used instead of the <see cref="Lock"/> and <see cref="Unlock"/> methods,
        /// taking advantage of the <see langword="using"/> keyword.
        /// </summary>
        public IDisposable AcquireLock()
        {
            lock (_slotManagementLock)
            {
                return new SlotLock(this, _slotManagementLock, OpenCount);
            }

        }

        #endregion locks

        #region open, close

        /// <summary>
        /// Opens the slot for use. Uses the shared slot management lock for thread safety.
        /// </summary>
        /// <remarks>
        /// Calls <see cref="ISunVoxLibC.sv_open_slot(int)"/>.
        /// </remarks>
        public void Open()
        {
            lock (_slotManagementLock)
            {
                if (IsOpen)
                {
                    throw new SlotAlreadyOpenException(Id);
                }
                Library.OpenSlot(Id);
                OpenCount = unchecked(OpenCount + 1);
                IsOpen = true;
            }
        }

        /// <summary>
        /// Closes the slot. Uses the shared slot management lock for thread safety.
        /// </summary>
        /// <remarks>
        /// Calls <see cref="ISunVoxLibC.sv_close_slot(int)"/>.
        /// </remarks>
        public void Close()
        {
            lock (_slotManagementLock)
            {
                if (!IsOpen)
                {
                    throw new SlotAlreadyClosedException(Id);
                }

                IsOpen = false;
                Library.CloseSlot(Id);
            }
        }

        #endregion open, close

        #region loading, saving

        /// <inheritdoc cref="ISunVoxLib.Load(int, string)"/>
        public void Load(string path)
        {
            Library.Load(Id, path);
        }

        /// <inheritdoc cref="ISunVoxLib.Load(int, byte[])"/>
        public void Load(byte[] data)
        {
            Library.Load(Id, data);
        }

        /// <inheritdoc cref="ISunVoxLib.SaveToFile"/>
        public void SaveToFile(string path)
        {
            Library.SaveToFile(Id, path);
        }

        #endregion loading, saving

        #region playing, stopping

        /// <inheritdoc cref="ISunVoxLib.StartPlayback"/>
        public void StartPlayback()
        {
            Library.StartPlayback(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.StartPlaybackFromBeginning"/>
        public void StartPlaybackFromBeginning()
        {
            Library.StartPlaybackFromBeginning(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.StopPlayback"/>
        public void StopPlayback()
        {
            Library.StopPlayback(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.ResumeStreamOnSyncEffect"/>
        public void ResumeStreamOnSyncEffect()
        {
            Library.ResumeStreamOnSyncEffect(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.PauseAudioStream"/>
        public void PauseAudioStream()
        {
            Library.PauseAudioStream(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.ResumeAudioStream"/>
        public void ResumeAudioStream()
        {
            Library.ResumeAudioStream(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetAutomaticStop"/>
        public void SetAutomaticStop(bool enable)
        {
            Library.SetAutomaticStop(Id, enable);
        }

        /// <inheritdoc cref="ISunVoxLib.GetAutomaticStop"/>
        public bool GetAutomaticStop()
        {
            return Library.GetAutomaticStop(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.IsPlaying"/>
        public bool IsPlaying()
        {
            return Library.IsPlaying(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.Rewind"/>
        public void Rewind(int lineNumber)
        {
            Library.Rewind(Id, lineNumber);
        }

        /// <inheritdoc cref="ISunVoxLib.GetCurrentLine"/>
        public int GetCurrentLine()
        {
            return Library.GetCurrentLine(Id);
        }

        /// <summary>
        /// Get current line in fixed point format (with tenth part).
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.GetCurrentLineWithTenthPart"/>
        public int GetCurrentLineWithTenthPart()
        {
            return Library.GetCurrentLineWithTenthPart(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetCurrentSignalLevel"/>
        public int GetCurrentSignalLevel(AudioChannel channel = AudioChannel.Left)
        {
            return Library.GetCurrentSignalLevel(Id, channel);
        }

        #endregion playing, stopping

        #region song properties

        /// <inheritdoc cref="ISunVoxLib.Volume"/>
        public int GetVolume()
        {
            return Library.Volume(Id, -1);
        }

        /// <inheritdoc cref="ISunVoxLib.Volume"/>
        public void SetVolume(int value)
        {
            Library.Volume(Id, value);
        }

        /// <inheritdoc cref="ISunVoxLib.GetSongBpm"/>
        public int GetSongBpm()
        {
            return Library.GetSongBpm(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetSongTpl"/>
        public int GetSongTpl()
        {
            return Library.GetSongTpl(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetSongLengthInLines"/>
        public uint GetSongLengthInLines()
        {
            return Library.GetSongLengthInLines(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetSongLengthInFrames"/>
        public uint GetSongLengthInFrames()
        {
            return Library.GetSongLengthInFrames(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetSongName"/>
        public string? GetSongName()
        {
            return Library.GetSongName(Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetSongName"/>
        public void SetSongName(string value)
        {
            Library.SetSongName(Id, value);
        }

        /// <inheritdoc cref="ISunVoxLib.GetTimeMapFrames"/>
        public uint[] GetTimeMapFrames(int startLine, int length)
        {
            return Library.GetTimeMapFrames(Id, startLine, length);
        }

        /// <inheritdoc cref="ISunVoxLib.GetTimeMapSpeed"/>
        public Speed[] GetTimeMapSpeed(int startLine, int length)
        {
            return Library.GetTimeMapSpeed(Id, startLine, length);
        }

        #endregion song properties
    }
}
