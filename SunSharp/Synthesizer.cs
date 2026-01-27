using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SunSharp.Native;

namespace SunSharp
{
    /// <inheritdoc cref="Synthesizer"/>
    public interface ISynthesizer : IEnumerable<ISynthModuleHandle>
    {
        /// <inheritdoc cref="Synthesizer.Slot"/>
        ISlot Slot { get; }

        /// <inheritdoc cref="Synthesizer.GetUpperModuleCount"/>
        int GetUpperModuleCount();

        /// <inheritdoc cref="Synthesizer.GetModuleExists"/>
        bool GetModuleExists(int moduleId);

        /// <inheritdoc cref="Synthesizer.GetModuleFlags"/>
        ModuleFlags GetModuleFlags(int moduleId);

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
#if RELEASE
        private readonly SunVoxLib _lib;
#else
        private readonly ISunVoxLib _lib;
#endif
        private readonly int _id;

        /// <summary>
        /// Gets the slot this synthesizer belongs to.
        /// </summary>
        public Slot Slot { get; }

        ISlot ISynthesizer.Slot => Slot;

        internal Synthesizer(Slot slot)
        {
            Slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
        }

        /// <inheritdoc cref="ISunVoxLib.GetUpperModuleCount"/>
        public int GetUpperModuleCount()
        {
            return _lib.GetUpperModuleCount(_id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleExists"/>
        public bool GetModuleExists(int moduleId)
        {
            return _lib.GetModuleExists(_id, moduleId);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleFlags"/>
        public ModuleFlags GetModuleFlags(int moduleId)
        {
            return _lib.GetModuleFlags(_id, moduleId);
        }

        /// <summary>
        /// Tries to get a module by ID.
        /// </summary>
        public bool TryGetModule(int moduleId, [NotNullWhen(true)] out SynthModuleHandle? moduleHandle)
        {
            if (_lib.GetModuleExists(_id, moduleId))
            {
                moduleHandle = new SynthModuleHandle(Slot, moduleId);
                return true;
            }

            moduleHandle = null;
            return false;
        }

        /// <summary>
        /// Tries to get a module by name.
        /// </summary>
        public bool TryGetModule(string name, [NotNullWhen(true)] out SynthModuleHandle? moduleHandle)
        {
            var moduleId = _lib.FindModule(_id, name);
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

        /// <inheritdoc/>
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
            using (Slot.AcquireLock())
            {
                var moduleId = _lib.CreateModule(_id, type, name, x, y, z);
                return new SynthModuleHandle(Slot, moduleId);
            }
        }

        /// <inheritdoc/>
        ISynthModuleHandle ISynthesizer.CreateModule(SynthModuleType type, string name, int x, int y, int z)
        {
            return CreateModule(type, name, x, y, z);
        }

        /// <summary>
        /// Load a module or sample from memory. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.LoadModule(int, byte[], int, int, int)"/>
        public SynthModuleHandle LoadModule(byte[] data, int x = 0, int y = 0, int z = 0)
        {
            using (Slot.AcquireLock())
            {
                var moduleId = _lib.LoadModule(_id, data, x, y, z);
                return new SynthModuleHandle(Slot, moduleId);
            }
        }

        /// <summary>
        /// Load a module or sample from file. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.LoadModule(int, string, int, int, int)"/>
        public SynthModuleHandle LoadModule(string path, int x = 0, int y = 0, int z = 0)
        {
            using (Slot.AcquireLock())
            {
                var moduleId = _lib.LoadModule(_id, path, x, y, z);
                return new SynthModuleHandle(Slot, moduleId);
            }
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
            using (Slot.AcquireLock())
            {
                _lib.RemoveModule(_id, moduleId);
            }
        }

        /// <summary>
        /// Removes a module from the synthesizer.
        /// </summary>
        public void RemoveModule(SynthModuleHandle moduleHandle)
        {
            RemoveModule(moduleHandle.Id);
        }

        /// <inheritdoc/>
        void ISynthesizer.RemoveModule(ISynthModuleHandle moduleHandle)
        {
            RemoveModule(moduleHandle.Id);
        }

        /// <inheritdoc cref="ISunVoxLib.ConnectModule"/>
        public void ConnectModule(int sourceId, int destinationId)
        {
            using (Slot.AcquireLock())
            {
                _lib.ConnectModule(_id, sourceId, destinationId);
            }
        }

        /// <summary>
        /// Connects two modules.
        /// </summary>
        public void ConnectModule(SynthModuleHandle source, SynthModuleHandle destination)
        {
            ConnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc/>
        void ISynthesizer.ConnectModule(ISynthModuleHandle source, ISynthModuleHandle destination)
        {
            ConnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc cref="ISunVoxLib.DisconnectModule"/>
        public void DisconnectModule(int sourceId, int destinationId)
        {
            using (Slot.AcquireLock())
            {
                _lib.DisconnectModule(_id, sourceId, destinationId);
            }
        }

        /// <summary>
        /// Disconnects two modules.
        /// </summary>
        public void DisconnectModule(SynthModuleHandle source, SynthModuleHandle destination)
        {
            DisconnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc/>
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
