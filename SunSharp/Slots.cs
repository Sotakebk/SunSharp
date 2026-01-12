using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SunSharp
{
    public interface ISlots : IEnumerable<Slot>
    {
        /// <summary>
        /// Get a reference to a slot. There are 16 slots, so index must be in range 0-15.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> </exception>
        ISlot this[int i] { get; }

        /// <summary>
        /// Try to get and open a new slot.
        /// </summary>
        /// <returns> <see langword="false"/> if failed to find an unused slot. </returns>
        bool TryOpenNewSlot([NotNullWhen(true)] out ISlot? slot);
    }

    public readonly struct Slots : ISlots
    {
        public const int SlotCount = 16;

        private readonly Slot[] _slots;
        public object SlotManagementLock { get; }

        public Slots(SunVox sunVox)
        {
            _slots = new Slot[SlotCount];
            SlotManagementLock = new object();
            for (var i = 0; i < SlotCount; i++)
            {
                _slots[i] = new Slot(i, this, sunVox);
            }
        }

        /// <inheritdoc/>
        public Slot this[int i]
        {
            get
            {
                if (i < 0 || i >= SlotCount)
                {
                    throw new ArgumentOutOfRangeException(nameof(i), i, $"Possible values: 0-{SlotCount}.");
                }

                return _slots[i];
            }
        }

        ISlot ISlots.this[int i] => this[i];

        /// <inheritdoc/>
        public bool TryOpenNewSlot([NotNullWhen(true)] out Slot? slot)
        {
            lock (SlotManagementLock)
            {
                slot = _slots.FirstOrDefault(s => !s.IsOpen);
                slot?.Open();
                return slot != null;
            }
        }

        bool ISlots.TryOpenNewSlot([NotNullWhen(true)] out ISlot? slot)
        {
            var result = TryOpenNewSlot(out Slot? typedSlot);
            slot = typedSlot;
            return result;
        }

        public IEnumerator<Slot> GetEnumerator() => ((IEnumerable<Slot>)_slots).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _slots.GetEnumerator();
    }
}
