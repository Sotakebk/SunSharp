using SunSharp.ThinWrapper;
using System;

namespace SunSharp.ObjectWrapper
{
    /// <summary>
    /// Represents a SunVox slot.
    /// </summary>
    public class Slot
    {
        private readonly int _id;
        private readonly ISunVoxLib _lib;
        private readonly SunVox _sunVox;
        private readonly Slots _slots;
        private readonly VirtualPattern _virtualPattern;
        private readonly Timeline _timeline;
        private readonly Synthesizer _synthesizer;
        private readonly object _lock;

        public int Id => _id;

        /// <summary>
        /// Virtual, 16-track pattern for sending events to the engine.
        /// </summary>
        public VirtualPattern VirtualPattern => _virtualPattern;

        /// <summary>
        /// Project timeline, containing all the existing patterns.
        /// </summary>
        public Timeline Timeline => _timeline;

        /// <summary>
        /// Project synthesizer, containing all the existing modules.
        /// </summary>
        public Synthesizer Synthesizer => _synthesizer;
        public SunVox SunVox => _sunVox;

        /// <summary>
        /// Underlying library instance.
        /// </summary>
        public ISunVoxLib Library => _lib;
        public bool IsOpen { get; private set; }

        internal Slot(int id, Slots slots, SunVox sunVox)
        {
            _id = id;
            _lock = new object();
            _slots = slots;
            _sunVox = sunVox;
            _lib = sunVox.Library;
            _virtualPattern = new VirtualPattern(this);
            _timeline = new Timeline(this);
            _synthesizer = new Synthesizer(this);
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

            _lib.RunInLock(_id, action);
        }

        /// <inheritdoc cref="RunInLock(Action)"/>
        public T RunInLock<T>(Func<T> function)
        {
            if (!IsOpen)
                throw new InvalidOperationException("Slot is closed.");

            return _lib.RunInLock(_id, function);
        }

        protected void Lock() => _lib.LockSlot(_id);

        protected void Unlock() => _lib.UnlockSlot(_id);

        #endregion locks

        #region open, close

        public void Open()
        {
            _slots.RunInOpeningLock(() =>
            {
                if (!IsOpen)
                {
                    _lib.OpenSlot(Id);
                    IsOpen = true;
                    RunInLock(() => _virtualPattern.ResetEventTiming());
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
                    _lib.CloseSlot(_id);
                }
            });
        }

        #endregion open, close

        #region loading, saving

        /// <summary>
        /// Load a project from file.
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path) => RunInLock(() => _lib.Load(_id, path));

        /// <summary>
        /// load a project from memory.
        /// </summary>
        /// <param name="data"></param>
        public void Load(byte[] data) => RunInLock(() => _lib.Load(_id, data));

        /// <summary>
        /// Save a project to file.
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path) => RunInLock(() => _lib.Save(_id, path));

        #endregion loading, saving

        #region playing, stopping

        public void Play()
        {
            RunInLock(() => _lib.Play(_id));
        }

        public void PlayFromBeginning()
        {
            RunInLock(() => _lib.PlayFromBeginning(_id));
        }

        public void Stop()
        {
            RunInLock(() => _lib.Stop(_id));
        }

        public void ResumeOnSyncEffect()
        {
            RunInLock(() => _lib.ResumeOnSyncEffect(_id));
        }

        public void PauseAudio()
        {
            RunInLock(() => _lib.Pause(_id));
        }

        public void ResumeAudio()
        {
            RunInLock(() => _lib.Resume(_id));
        }

        public void SetAutostop(bool enable)
        {
            RunInLock(() => _lib.SetAutostop(_id, enable));
        }

        public bool GetAutostop()
        {
            return _lib.GetAutostop(_id);
        }

        public bool IsPlaying()
        {
            return _lib.IsPlaying(_id);
        }

        public void Rewind(int lineNumber)
        {
            RunInLock(() => _lib.Rewind(_id, lineNumber));
        }

        public int GetCurrentLine()
        {
            return _lib.GetCurrentLine(_id);
        }

        /// <summary>
        /// Get current line in fixed point format (with tenth part).
        /// </summary>
        public int GetCurrentLineHundreds()
        {
            return _lib.GetCurrentLine2(_id);
        }

        public int GetCurrentSignalLevel(Channel channel = Channel.Mono)
        {
            return _lib.GetCurrentSignalLevel(_id, (int)channel);
        }

        #endregion playing, stopping

        #region song properties

        public int GetVolume()
        {
            return RunInLock(() => _lib.Volume(_id, -1));
        }

        public void SetVolume(int value)
        {
            RunInLock(() => _lib.Volume(_id, value));
        }

        public int GetSongBpm()
        {
            return RunInLock(() => _lib.GetSongBpm(_id));
        }

        public void SetSongBpm(int value)
        {
            var xxyy = (ushort)Math.Min(Math.Max(0, value), 800);
            _virtualPattern.SendEventImmediately(0, new Event(Effect.SetBPM, xxyy));
        }

        public int GetSongTpl()
        {
            return _lib.GetSongTpl(_id);
        }

        public void SetSongTpl(int value)
        {
            var xxyy = (ushort)Math.Min(Math.Max(1, value), 31);
            _virtualPattern.SendEventImmediately(0, new Event(Effect.SetPlayingSpeed, xxyy));
        }

        public int GetSongLengthInLines()
        {
            return _lib.GetSongLengthInLines(_id);
        }

        public int GetSongLengthInFrames()
        {
            return _lib.GetSongLengthInFrames(_id);
        }

        public string GetSongName()
        {
            return _lib.GetSongName(_id);
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
            return _lib.GetTimeMap(_id, startLine, length, type);
        }

        #endregion song properties
    }
}
