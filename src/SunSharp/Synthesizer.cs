using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SunSharp.Modules;
using SunSharp.Native;

namespace SunSharp
{
    /// <inheritdoc cref="Synthesizer"/>
    public interface ISynthesizer : IEnumerable<ISynthModuleHandle>
    {
        /// <inheritdoc cref="Synthesizer.Slot"/>
        ISlot Slot { get; }

#if !SUNSHARP_GENERATION
        /// <inheritdoc cref="Synthesizer.Output"/>
        IOutputModuleHandle Output { get; }
#endif

        /// <inheritdoc cref="Synthesizer.GetUpperModuleCount"/>
        int GetUpperModuleCount();

        /// <inheritdoc cref="Synthesizer.GetModuleExists"/>
        bool GetModuleExists(int moduleId);

        /// <inheritdoc cref="Synthesizer.GetModuleFlags"/>
        ModuleFlags GetModuleFlags(int moduleId);

        /// <inheritdoc cref="Synthesizer.GetModule"/>
        ISynthModuleHandle GetModule(int moduleId);

        /// <inheritdoc cref="Synthesizer.TryGetModule(int, out SynthModuleHandle?)"/>
        bool TryGetModule(int moduleId, [NotNullWhen(true)] out ISynthModuleHandle? moduleHandle);

        /// <inheritdoc cref="Synthesizer.TryGetModule(string, out SynthModuleHandle?)"/>
        bool TryGetModule(string name, [NotNullWhen(true)] out ISynthModuleHandle? moduleHandle);

        /// <inheritdoc cref="Synthesizer.CreateModule"/>
        ISynthModuleHandle CreateModule(SynthModuleType type, string name, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="Synthesizer.LoadModule(byte[], int, int, int)"/>
        ISynthModuleHandle LoadModule(byte[] data, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="Synthesizer.LoadModule(string, int, int, int)"/>
        ISynthModuleHandle LoadModule(string path, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="Synthesizer.RemoveModule(int)"/>
        void RemoveModule(int moduleId);

        /// <inheritdoc cref="Synthesizer.RemoveModule(SynthModuleHandle)"/>
        void RemoveModule(ISynthModuleHandle moduleHandle);

        /// <inheritdoc cref="Synthesizer.ConnectModule(int, int)"/>
        void ConnectModule(int sourceId, int destinationId);

        /// <inheritdoc cref="Synthesizer.ConnectModule(SynthModuleHandle, SynthModuleHandle)"/>
        void ConnectModule(ISynthModuleHandle source, ISynthModuleHandle destination);

        /// <inheritdoc cref="Synthesizer.DisconnectModule(int, int)"/>
        void DisconnectModule(int sourceId, int destinationId);

        /// <inheritdoc cref="Synthesizer.DisconnectModule(SynthModuleHandle, SynthModuleHandle)"/>
        void DisconnectModule(ISynthModuleHandle source, ISynthModuleHandle destination);
    }

    /// <summary>
    /// Project synthesizer, containing all the existing modules.
    /// </summary>
    public class Synthesizer : ISynthesizer, IEnumerable<SynthModuleHandle>
    {
#if SUNSHARP_RELEASE
        private readonly SunVoxLib _lib;
#else
        private readonly ISunVoxLib _lib;
#endif
        private readonly int _slotId;

        /// <summary>
        /// Gets the slot this synthesizer belongs to.
        /// </summary>
        public Slot Slot { get; }

        ISlot ISynthesizer.Slot => Slot;

#if !SUNSHARP_GENERATION

        public OutputModuleHandle Output => GetModule(0).AsOutput();

        IOutputModuleHandle ISynthesizer.Output => GetModule(0).AsOutput();
#endif

        internal Synthesizer(Slot slot)
        {
            Slot = slot;
            _lib = slot.SunVox.Library;
            _slotId = slot.Id;
        }

        /// <inheritdoc cref="ISunVoxLib.GetUpperModuleCount"/>
        public int GetUpperModuleCount()
        {
            return _lib.GetUpperModuleCount(_slotId);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleExists"/>
        public bool GetModuleExists(int moduleId)
        {
            return _lib.GetModuleExists(_slotId, moduleId);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleFlags"/>
        public ModuleFlags GetModuleFlags(int moduleId)
        {
            return _lib.GetModuleFlags(_slotId, moduleId);
        }

        /// <summary>
        /// Returns a handle to the module with the specified ID.
        /// The underlying module may not exist.
        /// </summary>
        public SynthModuleHandle GetModule(int moduleId)
        {
            return new SynthModuleHandle(Slot, moduleId);
        }

        /// <inheritdoc cref="GetModule(int)"/>
        ISynthModuleHandle ISynthesizer.GetModule(int moduleId)
        {
            return GetModule(moduleId);
        }

        /// <summary>
        /// Returns a handle to the module with the specified ID, if it exists.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.GetModuleExists(int, int)"/>
        public bool TryGetModule(int moduleId, [NotNullWhen(true)] out SynthModuleHandle? moduleHandle)
        {
            if (_lib.GetModuleExists(_slotId, moduleId))
            {
                moduleHandle = new SynthModuleHandle(Slot, moduleId);
                return true;
            }

            moduleHandle = null;
            return false;
        }

        /// <inheritdoc cref="ISunVoxLib.FindModule(int, string)"/>
        public bool TryGetModule(string name, [NotNullWhen(true)] out SynthModuleHandle? moduleHandle)
        {
            var moduleId = _lib.FindModule(_slotId, name);
            if (moduleId != null)
            {
                moduleHandle = new SynthModuleHandle(Slot, moduleId.Value);
                return true;
            }

            moduleHandle = null;
            return false;
        }

        /// <inheritdoc/>
        bool ISynthesizer.TryGetModule(int moduleId, [NotNullWhen(true)] out ISynthModuleHandle? moduleHandle)
        {
            if (TryGetModule(moduleId, out var foundModuleHandle))
            {
                moduleHandle = foundModuleHandle;
                return true;
            }

            moduleHandle = null;
            return false;
        }

        /// <inheritdoc cref="TryGetModule(int, out SynthModuleHandle?)"/>
        bool ISynthesizer.TryGetModule(string name, [NotNullWhen(true)] out ISynthModuleHandle? moduleHandle)
        {
            if (TryGetModule(name, out var foundModuleHandle))
            {
                moduleHandle = foundModuleHandle;
                return true;
            }

            moduleHandle = null;
            return false;
        }

        /// <inheritdoc cref="ISunVoxLib.CreateModule(int, SynthModuleType, string, int, int, int)"/>
        public SynthModuleHandle CreateModule(SynthModuleType type, string name, int x = 0, int y = 0, int z = 0)
        {
            bool lockAcquired = false;
            try
            {
                _lib.LockSlot(_slotId);
                lockAcquired = true;

                var moduleId = _lib.CreateModule(_slotId, type, name, x, y, z);
                return new SynthModuleHandle(Slot, moduleId);
            }
            finally
            {
                if (lockAcquired)
                {
                    _lib.UnlockSlot(_slotId);
                }
            }
        }

        /// <inheritdoc cref="CreateModule(SynthModuleType, string, int, int, int)"/>
        ISynthModuleHandle ISynthesizer.CreateModule(SynthModuleType type, string name, int x, int y, int z)
        {
            return CreateModule(type, name, x, y, z);
        }

        /// <inheritdoc cref="ISunVoxLib.LoadModule(int, byte[], int, int, int)"/>
        public SynthModuleHandle LoadModule(byte[] data, int x = 0, int y = 0, int z = 0)
        {
            var moduleId = _lib.LoadModule(_slotId, data, x, y, z);
            return new SynthModuleHandle(Slot, moduleId);
        }

        /// <inheritdoc cref="ISunVoxLib.LoadModule(int, string, int, int, int)"/>
        public SynthModuleHandle LoadModule(string path, int x = 0, int y = 0, int z = 0)
        {
            var moduleId = _lib.LoadModule(_slotId, path, x, y, z);
            return new SynthModuleHandle(Slot, moduleId);
        }

        /// <inheritdoc/>
        ISynthModuleHandle ISynthesizer.LoadModule(byte[] data, int x, int y, int z)
        {
            return LoadModule(data, x, y, z);
        }

        /// <inheritdoc/>
        ISynthModuleHandle ISynthesizer.LoadModule(string path, int x, int y, int z)
        {
            return LoadModule(path, x, y, z);
        }

        /// <inheritdoc cref="ISunVoxLib.RemoveModule"/>
        public void RemoveModule(int moduleId)
        {
            _lib.RemoveModule(_slotId, moduleId);
        }

        /// <inheritdoc cref="RemoveModule(int)"/>
        public void RemoveModule(SynthModuleHandle moduleHandle)
        {
            RemoveModule(moduleHandle.Id);
        }

        /// <inheritdoc cref="RemoveModule(int)"/>
        void ISynthesizer.RemoveModule(ISynthModuleHandle moduleHandle)
        {
            RemoveModule(moduleHandle.Id);
        }

        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void ConnectModule(int sourceId, int destinationId)
        {
            _lib.ConnectModules(_slotId, sourceId, destinationId);
        }

        /// <inheritdoc cref="ConnectModule(int, int)"/>
        public void ConnectModule(SynthModuleHandle source, SynthModuleHandle destination)
        {
            ConnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc cref="ConnectModule(int, int)"/>
        void ISynthesizer.ConnectModule(ISynthModuleHandle source, ISynthModuleHandle destination)
        {
            ConnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc cref="ISunVoxLib.DisconnectModules"/>
        public void DisconnectModule(int sourceId, int destinationId)
        {
            _lib.DisconnectModules(_slotId, sourceId, destinationId);
        }

        /// <inheritdoc cref="DisconnectModule(int, int)"/>
        public void DisconnectModule(SynthModuleHandle source, SynthModuleHandle destination)
        {
            DisconnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc cref="DisconnectModule(int, int)"/>
        void ISynthesizer.DisconnectModule(ISynthModuleHandle source, ISynthModuleHandle destination)
        {
            DisconnectModule(source.Id, destination.Id);
        }

        public IEnumerator<SynthModuleHandle> GetEnumerator()
        {
            for (var i = 0; i < GetUpperModuleCount(); i++)
            {
                if (TryGetModule(i, out var moduleHandle))
                {
                    yield return moduleHandle.Value;
                }
            }
        }

        IEnumerator<ISynthModuleHandle> IEnumerable<ISynthModuleHandle>.GetEnumerator()
        {
            foreach (var moduleHandle in this)
            {
                yield return moduleHandle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
