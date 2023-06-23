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

        /// <summary>
        /// Get a reference to a slot. There are 16 slots, so index must be in range 0-15.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Slot this[int i]
        {
            get
            {
                if (i < 0 || i >= SlotCount)
                    throw new ArgumentOutOfRangeException(nameof(i), i, $"Possible values: 0-{SlotCount}.");
                return _slots[i];
            }
        }

        internal Slots(SunVox sunVox)
        {
            _lock = new object();
            _slots = new Slot[SlotCount];
            for (int i = 0; i < SlotCount; i++)
                _slots[i] = new Slot(i, this, sunVox);
        }

        public void RunInOpeningLock(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            lock (_lock)
            {
                action();
            }
        }

        public T RunInOpeningLock<T>(Func<T> func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            lock (_lock)
            {
                return func();
            }
        }

        /// <summary>
        /// Try to get and open a new slot.
        /// </summary>
        /// <returns><see langword="null" /> if opening a closed slot failed. Otherwise, an open slot is returned. </returns>
        public Slot? TryOpenNewSlot()
        {
            return RunInOpeningLock(() =>
            {
                var slot = _slots.FirstOrDefault(s => !s.IsOpen);
                slot?.Open();
                return slot;
            });
        }

        public IEnumerator<Slot> GetEnumerator() => ((IEnumerable<Slot>)_slots).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _slots.GetEnumerator();
    }
}
