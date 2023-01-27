using SunSharp.ThinWrapper;
using System;

namespace SunSharp.ObjectWrapper
{
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
        public VirtualPattern VirtualPattern => _virtualPattern;
        public Timeline Timeline => _timeline;
        public Synthesizer Synthesizer => _synthesizer;
        public SunVox SunVox => _sunVox;
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

        public void RunInLock(Action action)
        {
            if (!IsOpen)
                throw new InvalidOperationException("Slot is closed.");

            _lib.RunInLock(_id, action);
        }

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

        public void Load(string path) => _lib.Load(_id, path);

        public void Load(byte[] data) => _lib.Load(_id, data);

        public void Save(string path) => _lib.Save(_id, path);

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
            return RunInLock(() => _lib.GetAutostop(_id));
        }

        public bool IsPlaying()
        {
            return RunInLock(() => !_lib.EndOfSong(_id));
        }

        public void Rewind(int lineNumber)
        {
            RunInLock(() => _lib.Rewind(_id, lineNumber));
        }

        public int GetCurrentLine()
        {
            return _lib.GetCurrentLine(_id);
        }

        public int GetCurrentLineHundreds()
        {
            return RunInLock(() => _lib.GetCurrentLine2(_id));
        }

        public int GetCurrentSignalLevel(Channel channel = Channel.Mono)
        {
            return RunInLock(() => _lib.GetCurrentSignalLevel(_id, (int)channel));
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
            var xxyy = (short)Math.Min(Math.Max(0, value), 800);
            RunInLock(() =>
            {
                _virtualPattern.SendEventImmediately(0, new Event(Effect.SetBPM, xxyy));
            });
        }

        public int GetSongTpl()
        {
            return RunInLock(() => _lib.GetSongTpl(_id));
        }

        public void SetSongTpl(int value)
        {
            var xxyy = (short)Math.Min(Math.Max(1, value), 31);
            RunInLock(() =>
            {
                _virtualPattern.SendEventImmediately(0, new Event(Effect.SetPlayingSpeed, xxyy));
            });
        }

        public int GetSongLengthInLines()
        {
            return RunInLock(() => _lib.GetSongLengthLines(_id));
        }

        public int GetSongLengthInFrames()
        {
            return RunInLock(() => _lib.GetSongLengthFrames(_id));
        }

        public string GetSongName()
        {
            return RunInLock(() => _lib.GetSongName(_id));
        }

        public uint[] GetTimeMap(int startLine, int length, TimeMapType type)
        {
            return _lib.GetTimeMap(_id, startLine, length, type);
        }

        #endregion song properties
    }
}
