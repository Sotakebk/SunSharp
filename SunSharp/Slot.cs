using System;
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

    /// <summary>
    /// Represents a SunVox slot.
    /// </summary>
    public interface ISlot
    {
        int Id { get; }

        /// <summary>
        /// Virtual, 16-track pattern for sending events to the engine.
        /// </summary>
        IVirtualPattern VirtualPattern { get; }

        /// <summary>
        /// Project timeline, containing all the existing patterns.
        /// </summary>
        ITimeline Timeline { get; }

        /// <summary>
        /// Project synthesizer, containing all the existing modules.
        /// </summary>
        ISynthesizer Synthesizer { get; }

        /// <summary>
        /// SunVox instance this slot belongs to.
        /// </summary>
        ISunVox SunVox { get; }

        /// <summary>
        /// Underlying library instance.
        /// </summary>
        ISunVoxLib Library { get; }

        /// <summary>
        /// Gets a value indicating whether the slot is currently open.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Can be used instead of the <see cref="Lock"/> and <see cref="Unlock"/> methods,
        /// taking advantage of the <see langword="using"/> keyword.
        /// </summary>
        IDisposable AcquireLock();

        /// <summary>
        /// Locks the library-side reentrant mutex once.
        /// </summary>
        void Lock();

        /// <summary>
        /// Unlocks the library-side reentrant mutex once.
        /// </summary>
        void Unlock();

        /// <summary>
        /// Opens the slot for use. Uses the shared slot management lock for thread safety.
        /// </summary>
        void Open();

        /// <summary>
        /// Closes the slot. Uses the shared slot management lock for thread safety.
        /// </summary>
        void Close();

        /// <summary>
        /// Load a project from file.
        /// </summary>
        void Load(string path);

        /// <summary>
        /// load a project from memory.
        /// </summary>
        void Load(byte[] data);

        /// <summary>
        /// Save a project to file.
        /// </summary>
        void Save(string path);

        void StartPlayback();

        void StartPlaybackFromBeginning();

        void StopPlayback();

        void ResumeStreamOnSyncEffect();

        void PauseAudioStream();

        void ResumeAudioStream();

        void SetAutomaticStop(bool enable);

        bool GetAutomaticStop();

        bool IsPlaying();

        void Rewind(int lineNumber);

        int GetCurrentLine();

        /// <summary>
        /// Get current line in fixed point format (with tenth part).
        /// </summary>
        int GetCurrentLineWithTenthPart();

        int GetCurrentSignalLevel(AudioChannel channel = AudioChannel.Mono);

        int GetVolume();

        void SetVolume(int value);

        int GetSongBpm();

        /// <summary>
        /// Sets the beats per minute (BPM) for the current song.
        /// The value is clamped to the range [0, 800].
        /// </summary>
        void SetSongBpm(int value);

        int GetSongTpl();

        /// <summary>
        /// Sets song TPL (ticks per line) by sending a <see cref="Effect.SetPlayingSpeed"/> event.
        /// The value is clamped to the range [1, 31].
        /// </summary>
        void SetSongTpl(int value);

        uint GetSongLengthInLines();

        uint GetSongLengthInFrames();

        string? GetSongName();

        void SetSongName(string name);

        /// <summary>
        /// Get the project time map.
        /// </summary>
        /// <remarks>
        /// <para>For <paramref name="type"/> = <see cref="TimeMapType.Speed"/>, n-th value equals speed at the beginning of n-th line (Bpm | Tpl &lt;&lt; 16). </para>
        /// <para>For <paramref name="type"/> = <see cref="TimeMapType.FrameCount"/>, n-th value equals frame counter at the beginning of Nth line. </para>
        /// </remarks>
        uint[] GetTimeMap(int startLine, int length, TimeMapType type);
    }

    /// <inheritdoc/>
    public sealed class Slot : ISlot
    {
        /// <inheritdoc/>
        public int Id { get; }

        /// <inheritdoc cref="ISlot.VirtualPattern"/>
        public VirtualPattern VirtualPattern { get; }

        /// <inheritdoc cref="ISlot.Timeline" />
        public Timeline Timeline { get; }

        /// <inheritdoc cref="ISlot.Synthesizer"/>
        public Synthesizer Synthesizer { get; }

        /// <inheritdoc cref="ISlot.SunVox"/>
        public SunVox SunVox { get; }

        /// <inheritdoc/>
        IVirtualPattern ISlot.VirtualPattern => VirtualPattern;

        /// <inheritdoc/>
        ITimeline ISlot.Timeline => Timeline;

        /// <inheritdoc/>
        ISynthesizer ISlot.Synthesizer => Synthesizer;

        /// <inheritdoc/>
        ISunVox ISlot.SunVox => SunVox;

        /// <inheritdoc/>
        public ISunVoxLib Library { get; }

        /// <inheritdoc/>
        public bool IsOpen { get; private set; }

        private readonly object _slotManagementLock;

        internal Slot(int id, object slotManagementLock, SunVox sunVox)
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

        /// <inheritdoc/>
        public void Lock() => Library.LockSlot(Id);

        /// <inheritdoc/>
        public void Unlock() => Library.UnlockSlot(Id);

        /// <inheritdoc/>
        public IDisposable AcquireLock()
        {
            return new SlotLock(SunVox, Id);
        }

        #endregion locks

        #region open, close

        /// <inheritdoc/>
        public void Open()
        {
            lock (_slotManagementLock)
            {
                if (IsOpen)
                {
                    throw new SlotAlreadyOpenException(Id);
                }
                Library.OpenSlot(Id);
                IsOpen = true;
                using (AcquireLock())
                {
                    VirtualPattern.ResetEventTiming();
                }
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void Load(string path)
        {
            using (AcquireLock())
            {
                Library.Load(Id, path);
            }
        }

        /// <inheritdoc/>
        public void Load(byte[] data)
        {
            using (AcquireLock())
            {
                Library.Load(Id, data);
            }
        }

        /// <inheritdoc/>
        public void Save(string path)
        {
            using (AcquireLock())
            {
                Library.SaveToFile(Id, path);
            }
        }

        #endregion loading, saving

        #region playing, stopping

        /// <inheritdoc/>
        public void StartPlayback()
        {
            using (AcquireLock())
            {
                Library.StartPlayback(Id);
            }
        }

        /// <inheritdoc/>
        public void StartPlaybackFromBeginning()
        {
            using (AcquireLock())
            {
                Library.StartPlaybackFromBeginning(Id);
            }
        }

        /// <inheritdoc/>
        public void StopPlayback()
        {
            using (AcquireLock())
            {
                Library.StopPlayback(Id);
            }
        }

        /// <inheritdoc/>
        public void ResumeStreamOnSyncEffect()
        {
            using (AcquireLock())
            {
                Library.ResumeStreamOnSyncEffect(Id);
            }
        }

        /// <inheritdoc/>
        public void PauseAudioStream()
        {
            using (AcquireLock())
            {
                Library.PauseAudioStream(Id);
            }
        }

        /// <inheritdoc/>
        public void ResumeAudioStream()
        {
            using (AcquireLock())
            {
                Library.ResumeAudioStream(Id);
            }
        }

        /// <inheritdoc/>
        public void SetAutomaticStop(bool enable)
        {
            using (AcquireLock())
            {
                Library.SetAutomaticStop(Id, enable);
            }
        }

        /// <inheritdoc/>
        public bool GetAutomaticStop()
        {
            return Library.GetAutomaticStop(Id);
        }

        /// <inheritdoc/>
        public bool IsPlaying()
        {
            return Library.IsPlaying(Id);
        }

        /// <inheritdoc/>
        public void Rewind(int lineNumber)
        {
            using (AcquireLock())
            {
                Library.Rewind(Id, lineNumber);
            }
        }

        /// <inheritdoc/>
        public int GetCurrentLine()
        {
            return Library.GetCurrentLine(Id);
        }

        /// <inheritdoc/>
        public int GetCurrentLineWithTenthPart()
        {
            return Library.GetCurrentLineWithTenthPart(Id);
        }

        /// <inheritdoc/>
        public int GetCurrentSignalLevel(AudioChannel channel = AudioChannel.Mono)
        {
            return Library.GetCurrentSignalLevel(Id, channel);
        }

        #endregion playing, stopping

        #region song properties

        /// <inheritdoc/>
        public int GetVolume()
        {
            return Library.Volume(Id, -1);
        }

        /// <inheritdoc/>
        public void SetVolume(int value)
        {
            Library.Volume(Id, value);
        }

        /// <inheritdoc/>
        public int GetSongBpm()
        {
            return Library.GetSongBpm(Id);
        }

        /// <inheritdoc/>
        public void SetSongBpm(int value)
        {
            var xxyy = (ushort)Math.Min(Math.Max(0, value), 800);
            VirtualPattern.SendEventImmediately(0, PatternEvent.EffectEvent(null, Effect.SetBpm, xxyy));
        }

        /// <inheritdoc/>
        public int GetSongTpl()
        {
            return Library.GetSongTpl(Id);
        }

        /// <inheritdoc/>
        public void SetSongTpl(int value)
        {
            var xxyy = (ushort)Math.Min(Math.Max(1, value), 31);
            VirtualPattern.SendEventImmediately(0, PatternEvent.EffectEvent(null, Effect.SetPlayingSpeed, xxyy));
        }

        /// <inheritdoc/>
        public uint GetSongLengthInLines()
        {
            return Library.GetSongLengthInLines(Id);
        }

        /// <inheritdoc/>
        public uint GetSongLengthInFrames()
        {
            return Library.GetSongLengthInFrames(Id);
        }

        /// <inheritdoc/>
        public string? GetSongName()
        {
            return Library.GetSongName(Id);
        }

        /// <inheritdoc/>
        public void SetSongName(string name)
        {
            Library.SetSongName(Id, name);
        }

        /// <inheritdoc/>
        public uint[] GetTimeMap(int startLine, int length, TimeMapType type)
        {
            return Library.GetTimeMap(Id, startLine, length, type);
        }

        #endregion song properties
    }
}
