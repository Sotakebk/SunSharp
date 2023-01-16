using SunSharp.ObjectWrapper;
using SunSharp.ThinWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SunSharp.DerivedData
{
    public sealed class LockingMechanism
    {
        private readonly Slot _slot;
        private readonly ISunVoxLib _lib;
        private readonly int _slotId;
        private readonly object _lock;

        public LockingMechanism(ISunVoxLib lib, int slotId)
        {
            _slot = null;
            _lock = new object();
            _lib = lib;
            _slotId = slotId;
        }

        public LockingMechanism(Slot slot)
        {
            _slot = slot;
            _lock = null;
            _slotId = slot.Id;
            _lib = slot.Library;
        }

        public void RunInLock(Action action)
        {
            if (_slot != null)
            {
                _slot.RunInLock(action);
            }
            else
            {
                bool lockWasTaken = false;
                var temp = _lock;
                try
                {
                    Monitor.Enter(temp, ref lockWasTaken);
                    if (lockWasTaken)
                        _lib.LockSlot(_slotId);
                    action();
                }
                finally
                {
                    if (lockWasTaken)
                    {
                        _lib.UnlockSlot(_slotId);
                        Monitor.Exit(temp);
                    }
                }
            }
        }

        public T RunInLock<T>(Func<T> function)
        {
            if (_slot != null)
            {
                return _slot.RunInLock<T>(function);
            }
            else
            {
                bool lockWasTaken = false;
                var temp = _lock;
                try
                {
                    Monitor.Enter(temp, ref lockWasTaken);
                    if (lockWasTaken)
                        _lib.LockSlot(_slotId);
                    return function();
                }
                finally
                {
                    if (lockWasTaken)
                    {
                        _lib.UnlockSlot(_slotId);
                        Monitor.Exit(temp);
                    }
                }
            }
        }
    }

    public class SongData<T, V> : ISongData<T, V>
        where T : ModuleData
        where V : PatternData
    {
        #region properties

        public string Name { get; protected set; }
        public int BPM { get; protected set; }
        public int TPL { get; protected set; }
        public int Frames { get; protected set; }
        public int Lines { get; protected set; }
        public int CurrentLine { get; protected set; }
        public int FirstLine { get; protected set; }
        public int LastLine { get; protected set; }
        public bool IsLinear { get; protected set; }
        public bool IsDestructive { get; protected set; }
        public bool HasDynamicTempo { get; protected set; }
        public IReadOnlyCollection<T> Modules { get; protected set; }
        public IReadOnlyCollection<V> Patterns { get; protected set; }

        #endregion properties

        public SongData(ISunVoxLib lib, int slotId, LockingMechanism lockingMechanism)
        {
            lockingMechanism.RunInLock(() => ReadSong(lib, slotId, lockingMechanism));
        }

        protected virtual void ReadSong(ISunVoxLib lib, int slot, LockingMechanism lockingMechanism)
        {
            var moduleCount = lib.GetUpperModuleCount(slot);
            var modules = new List<ModuleData>(moduleCount);

            for (int i = 0; i < moduleCount; i++)
                if (lib.GetModuleExists(slot, i))
                    modules.Add(new ModuleData(lib, slot, i, lockingMechanism));

            var patternCount = lib.GetUpperPatternCount(slot);
            var patterns = new List<PatternData>(patternCount);

            for (int i = 0; i < patternCount; i++)
                if (lib.GetPatternExists(slot, i))
                    patterns.Add(new PatternData(lib, slot, i, lockingMechanism));

            Modules = (IReadOnlyCollection<T>)modules.ToArray();
            Patterns = (IReadOnlyCollection<V>)patterns.ToArray();

            BPM = lib.GetSongBpm(slot);
            CurrentLine = lib.GetCurrentLine(slot);
            FirstLine = Patterns.Min(p => p.Position.X);
            Frames = lib.GetSongLengthFrames(slot);
            HasDynamicTempo = Patterns.Any(p => p.HasDynamicTempo);
            IsDestructive = Patterns.Any(p => p.IsDestructive);
            IsLinear = Patterns.All(p => p.IsLinear);
            LastLine = Patterns.Max(p => p.Position.X + p.Lines);
            Lines = lib.GetSongLengthLines(slot);
            Name = lib.GetSongName(slot);
            TPL = lib.GetSongTpl(slot);
        }

        public static SongData<T, V> ReadSong(ISunVoxLib lib, int slotId)
        {
            var lockingMechanism = new LockingMechanism(lib, slotId);
            return new SongData<T, V>(lib, slotId, lockingMechanism);
        }

        public static SongData<T, V> ReadSong(Slot slot)
        {
            var lockingMechanism = new LockingMechanism(slot);
            return new SongData<T, V>(slot.Library, slot.Id, lockingMechanism);
        }
    }

    public class ModuleData : IModuleData
    {
        #region properties

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public (int X, int Y) Position { get; protected set; }
        public (int finetune, int relativeNote) Finetune { get; protected set; }
        public bool Solo { get; protected set; }
        public bool Mute { get; protected set; }
        public bool Bypass { get; protected set; }
        public (int R, int G, int B) Color { get; protected set; }
        public IReadOnlyCollection<(string name, int value)> Controllers { get; protected set; }
        public IReadOnlyCollection<int> Inputs { get; protected set; }
        public IReadOnlyCollection<int> Outputs { get; protected set; }

        #endregion properties

        internal ModuleData(ISunVoxLib lib, int slot, int moduleId, LockingMechanism lockingMechanism)
        {
            lockingMechanism.RunInLock(() => ReadModuleData(lib, slot, moduleId));
        }

        protected void ReadModuleData(ISunVoxLib lib, int slot, int moduleId)
        {
            var flags = lib.GetModuleFlags(slot, moduleId);
            var controllers = new (string name, int value)[lib.GetModuleControllerCount(slot, moduleId)];

            for (int i = 0; i < controllers.Length; i++)
            {
                var name = lib.GetModuleControllerName(slot, moduleId, i);
                var value = lib.GetModuleControllerValue(slot, moduleId, i, false);
                controllers[i] = (name, value);
            }

            Bypass = flags.Bypass;
            Color = lib.GetModuleColor(slot, moduleId);
            Controllers = controllers;
            Finetune = lib.GetModuleFinetune(slot, moduleId);
            Id = moduleId;
            Inputs = lib.GetModuleInputs(slot, moduleId);
            Mute = flags.Mute;
            Name = lib.GetModuleName(slot, moduleId);
            Outputs = lib.GetModuleOutputs(slot, moduleId);
            Position = lib.GetModulePosition(slot, moduleId);
            Solo = flags.Solo;
        }
    }

    public class PatternData : IPatternData
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public (int X, int Y) Position { get; protected set; }
        public int Lines { get; protected set; }
        public int Tracks { get; protected set; }
        public bool IsMuted { get; protected set; }
        public bool IsLinear { get; protected set; }
        public bool IsDestructive { get; protected set; }
        public bool HasDynamicTempo { get; protected set; }
        public IReadOnlyCollection<ReadOnlyEvent> Data { get; protected set; }

        public PatternData(ISunVoxLib lib, int slot, int patternId, LockingMechanism lockingMechanism)
        {
            lockingMechanism.RunInLock(() => ReadPatternData(lib, slot, patternId));
        }

        protected void ReadPatternData(ISunVoxLib lib, int slot, int patternId)
        {
            var data = lib.GetPatternData(slot, patternId).Cast<ReadOnlyEvent>().ToArray();
            bool isDestructive = false;
            bool isLinear = true;
            bool hasDynamicTempo = false;

            for (int i = 0; i < data.Length; i++)
            {
                var @event = data[i];
                isDestructive = @event.Effect.IsDestructive() || isDestructive;
                isLinear = isLinear && !@event.Effect.IsNonLinear();
                hasDynamicTempo = hasDynamicTempo || @event.Effect.ModifiesTime();
            }

            bool muted = lib.PatternMute(slot, patternId, false);
            lib.PatternMute(slot, patternId, muted);

            Data = data;
            HasDynamicTempo = hasDynamicTempo;
            Id = patternId;
            IsDestructive = isDestructive;
            IsLinear = isLinear;
            IsMuted = muted;
            Lines = lib.GetPatternLines(slot, patternId);
            Name = lib.GetPatternName(slot, patternId);
            Position = lib.GetPatternPosition(slot, patternId);
            Tracks = lib.GetPatternTracks(slot, patternId);
        }
    }
}
