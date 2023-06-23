using System;
using SunSharp.ThinWrapper;

namespace SunSharp.ObjectWrapper
{
    /// <summary>
    /// Represents a SunVox slot.
    /// </summary>
    public class Slot
    {
        private readonly Slots _slots;

        public int Id { get; }

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

        public SunVox SunVox { get; }

        /// <summary>
        /// Underlying library instance.
        /// </summary>
        public ISunVoxLib Library { get; }

        public bool IsOpen { get; private set; }

        internal Slot(int id, Slots slots, SunVox sunVox)
        {
            Id = id;
            _slots = slots;
            SunVox = sunVox;
            Library = sunVox.Library;
            VirtualPattern = new VirtualPattern(this);
            Timeline = new Timeline(this);
            Synthesizer = new Synthesizer(this);
        }

        #region locks

        /// <summary>
        /// Use to execute multiple operations in the 'same' SunVox time.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void RunInLock(Action action)
        {
            if (!IsOpen)
                throw new InvalidOperationException("Slot is closed.");

            Library.RunInLock(Id, action);
        }

        /// <inheritdoc cref="RunInLock(Action)"/>
        public T RunInLock<T>(Func<T> function)
        {
            if (!IsOpen)
                throw new InvalidOperationException("Slot is closed.");

            return Library.RunInLock(Id, function);
        }

        protected void Lock() => Library.LockSlot(Id);

        protected void Unlock() => Library.UnlockSlot(Id);

        #endregion locks

        #region open, close

        public void Open()
        {
            _slots.RunInOpeningLock(() =>
            {
                if (!IsOpen)
                {
                    Library.OpenSlot(Id);
                    IsOpen = true;
                    RunInLock(() => VirtualPattern.ResetEventTiming());
                }
            });
        }

        public void Close()
        {
            _slots.RunInOpeningLock(() =>
            {
                if (IsOpen)
                {
                    IsOpen = false;
                    Library.CloseSlot(Id);
                }
            });
        }

        #endregion open, close

        #region loading, saving

        /// <summary>
        /// Load a project from file.
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path) => RunInLock(() => Library.Load(Id, path));

        /// <summary>
        /// load a project from memory.
        /// </summary>
        /// <param name="data"></param>
        public void Load(byte[] data) => RunInLock(() => Library.Load(Id, data));

        /// <summary>
        /// Save a project to file.
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path) => RunInLock(() => Library.Save(Id, path));

        #endregion loading, saving

        #region playing, stopping

        public void Play()
        {
            RunInLock(() => Library.Play(Id));
        }

        public void PlayFromBeginning()
        {
            RunInLock(() => Library.PlayFromBeginning(Id));
        }

        public void Stop()
        {
            RunInLock(() => Library.Stop(Id));
        }

        public void ResumeOnSyncEffect()
        {
            RunInLock(() => Library.ResumeOnSyncEffect(Id));
        }

        public void PauseAudio()
        {
            RunInLock(() => Library.Pause(Id));
        }

        public void ResumeAudio()
        {
            RunInLock(() => Library.Resume(Id));
        }

        public void SetAutostop(bool enable)
        {
            RunInLock(() => Library.SetAutoStop(Id, enable));
        }

        public bool GetAutostop()
        {
            return Library.GetAutostop(Id);
        }

        public bool IsPlaying()
        {
            return Library.IsPlaying(Id);
        }

        public void Rewind(int lineNumber)
        {
            RunInLock(() => Library.Rewind(Id, lineNumber));
        }

        public int GetCurrentLine()
        {
            return Library.GetCurrentLine(Id);
        }

        /// <summary>
        /// Get current line in fixed point format (with tenth part).
        /// </summary>
        public int GetCurrentLineHundreds()
        {
            return Library.GetCurrentLine2(Id);
        }

        public int GetCurrentSignalLevel(AudioChannel channel = AudioChannel.Mono)
        {
            return Library.GetCurrentSignalLevel(Id, (int)channel);
        }

        #endregion playing, stopping

        #region song properties

        public int GetVolume()
        {
            return Library.Volume(Id, -1);
        }

        public void SetVolume(int value)
        {
            Library.Volume(Id, value);
        }

        public int GetSongBpm()
        {
            return Library.GetSongBpm(Id);
        }

        public void SetSongBpm(int value)
        {
            var xxyy = (ushort)Math.Min(Math.Max(0, value), 800);
            VirtualPattern.SendEventImmediately(0, new PatternEvent(Effect.SetBpm, xxyy));
        }

        public int GetSongTpl()
        {
            return Library.GetSongTpl(Id);
        }

        public void SetSongTpl(int value)
        {
            var xxyy = (ushort)Math.Min(Math.Max(1, value), 31);
            VirtualPattern.SendEventImmediately(0, new PatternEvent(Effect.SetPlayingSpeed, xxyy));
        }

        public int GetSongLengthInLines()
        {
            return Library.GetSongLengthInLines(Id);
        }

        public int GetSongLengthInFrames()
        {
            return Library.GetSongLengthInFrames(Id);
        }

        public string? GetSongName()
        {
            return Library.GetSongName(Id);
        }

        public void SetSongName(string name)
        {
            Library.SetSongName(Id, name);
        }

        /// <summary>
        /// Get the project time map.
        /// <para>For <paramref name="type"/> = <see cref="TimeMapType.Speed"/>, Nth value equals speed at the beginning of Nth line (Bpm | Tpl &lt;&lt; 16). </para>
        /// <para>For <paramref name="type"/> = <see cref="TimeMapType.FrameCount"/>, Nth value equals frame counter at the beginning of Nth line. </para>
        /// </summary>
        /// <param name="startLine"></param>
        /// <param name="length"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public uint[] GetTimeMap(int startLine, int length, TimeMapType type)
        {
            return Library.GetTimeMap(Id, startLine, length, type);
        }

        #endregion song properties
    }
}
