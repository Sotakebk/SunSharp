using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.ObjectWrapper
{
    public class Slots : IEnumerable<Slot>
    {
        public const int SlotCount = 16;

        private readonly Slot[] _slots;
        private readonly object _lock;

        internal Slots(SunVox sunVox)
        {
            _lock = new object();
            _slots = new Slot[SlotCount];
            for (int i = 0; i < SlotCount; i++)
                _slots[i] = new Slot(i, this, sunVox);
        }

        public void RunInOpeningLock(Action action)
        {
            lock (_lock)
            {
                action();
            }
        }

        public T RunInOpeningLock<T>(Func<T> func)
        {
            lock (_lock)
            {
                return func();
            }
        }

        public Slot this[int i]
        {
            get
            {
                if (i < 0 || i >= SlotCount)
                    throw new ArgumentOutOfRangeException(nameof(i), i, $"Possible values: 0-{SlotCount}.");
                return _slots[i];
            }
        }

        public bool TryOpenNewSlot(out Slot slot)
        {
            slot = RunInOpeningLock(() =>
            {
                var _slot = _slots.FirstOrDefault(s => s.IsOpen);
                _slot?.Open();
                return _slot;
            });
            return slot != null;
        }

        public IEnumerator<Slot> GetEnumerator() => ((IEnumerable<Slot>)_slots).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _slots.GetEnumerator();
    }
}
