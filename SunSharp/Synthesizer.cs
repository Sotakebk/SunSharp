using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SunSharp.Native;

namespace SunSharp
{
    public interface ISynthesizer : IEnumerable<IModuleHandle>
    {
        ISlot Slot { get; }

        int GetUpperModuleCount();

        bool GetModuleExists(int moduleId);

        ModuleFlags GetModuleFlags(int moduleId);

        bool TryGetModule(int moduleId, [NotNullWhen(true)] out IModuleHandle? moduleHandle);

        bool TryGetModule(string name, [NotNullWhen(true)] out IModuleHandle? moduleHandle);

        IModuleHandle CreateModule(ModuleType type, string name, int x = 0, int y = 0, int z = 0);

        /// <summary>
        /// load a module or sample. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        IModuleHandle LoadModule(byte[] data, int x = 0, int y = 0, int z = 0);

        /// <summary>
        /// load a module or sample. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        IModuleHandle LoadModule(string path, int x = 0, int y = 0, int z = 0);

        void RemoveModule(int moduleId);

        void RemoveModule(IModuleHandle moduleHandle);

        void ConnectModule(int sourceId, int destinationId);

        void ConnectModule(IModuleHandle source, IModuleHandle destination);

        void DisconnectModule(int sourceId, int destinationId);

        void DisconnectModule(IModuleHandle source, IModuleHandle destination);
    }

    public class Synthesizer : ISynthesizer, IEnumerable<ModuleHandle>
    {
        private readonly ISunVoxLib _lib;
        private readonly int _id;

        public Slot Slot { get; }

        ISlot ISynthesizer.Slot => Slot;

        internal Synthesizer(Slot slot)
        {
            Slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
        }

        /// <inheritdoc/>
        public int GetUpperModuleCount()
        {
            return _lib.GetUpperModuleCount(_id);
        }

        /// <inheritdoc/>
        public bool GetModuleExists(int moduleId)
        {
            return _lib.GetModuleExists(_id, moduleId);
        }

        /// <inheritdoc/>
        public ModuleFlags GetModuleFlags(int moduleId)
        {
            return _lib.GetModuleFlags(_id, moduleId);
        }

        /// <inheritdoc cref="ISynthesizer.TryGetModule(int, out IModuleHandle?)"/>
        public bool TryGetModule(int moduleId, [NotNullWhen(true)] out ModuleHandle? moduleHandle)
        {
            if (_lib.GetModuleExists(_id, moduleId))
            {
                moduleHandle = new ModuleHandle(this, moduleId);
                return true;
            }

            moduleHandle = null;
            return false;
        }

        /// <inheritdoc cref="ISynthesizer.TryGetModule(string, out IModuleHandle?)"/>
        public bool TryGetModule(string name, [NotNullWhen(true)] out ModuleHandle? moduleHandle)
        {
            var moduleId = _lib.FindModule(_id, name);
            if (moduleId != null)
            {
                moduleHandle = new ModuleHandle(this, moduleId.Value);
                return true;
            }

            moduleHandle = null;
            return false;
        }

        /// <inheritdoc/>
        bool ISynthesizer.TryGetModule(int moduleId, [NotNullWhen(true)] out IModuleHandle? moduleHandle)
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
        bool ISynthesizer.TryGetModule(string name, [NotNullWhen(true)] out IModuleHandle? moduleHandle)
        {
            if (TryGetModule(name, out var foundModuleHandle))
            {
                moduleHandle = foundModuleHandle;
                return true;
            }

            moduleHandle = null;
            return false;
        }

        /// <inheritdoc cref="ISynthesizer.CreateModule"/>
        public ModuleHandle CreateModule(ModuleType type, string name, int x = 0, int y = 0, int z = 0)
        {
            using (Slot.AcquireLock())
            {
                var moduleId = _lib.CreateModule(_id, ModuleTypeHelper.InternalNameFromType(type), name, x, y, z);
                return new ModuleHandle(this, moduleId);
            }
        }

        /// <inheritdoc/>
        IModuleHandle ISynthesizer.CreateModule(ModuleType type, string name, int x, int y, int z)
        {
            return CreateModule(type, name, x, y, z);
        }

        /// <inheritdoc cref="ISynthesizer.LoadModule(byte[], int, int, int)"/>
        public ModuleHandle LoadModule(byte[] data, int x = 0, int y = 0, int z = 0)
        {
            using (Slot.AcquireLock())
            {
                var moduleId = _lib.LoadModule(_id, data, x, y, z);
                return new ModuleHandle(this, moduleId);
            }
        }

        /// <inheritdoc cref="ISynthesizer.LoadModule(string, int, int, int)"/>
        public ModuleHandle LoadModule(string path, int x = 0, int y = 0, int z = 0)
        {
            using (Slot.AcquireLock())
            {
                var moduleId = _lib.LoadModule(_id, path, x, y, z);
                return new ModuleHandle(this, moduleId);
            }
        }

        /// <inheritdoc/>
        IModuleHandle ISynthesizer.LoadModule(byte[] data, int x, int y, int z)
        {
            return LoadModule(data, x, y, z);
        }

        /// <inheritdoc/>
        IModuleHandle ISynthesizer.LoadModule(string path, int x, int y, int z)
        {
            return LoadModule(path, x, y, z);
        }

        /// <inheritdoc/>
        public void RemoveModule(int moduleId)
        {
            using (Slot.AcquireLock())
            {
                _lib.RemoveModule(_id, moduleId);
            }
        }

        /// <inheritdoc cref="ISynthesizer.RemoveModule(IModuleHandle)"/>
        public void RemoveModule(ModuleHandle moduleHandle)
        {
            RemoveModule(moduleHandle.Id);
        }

        /// <inheritdoc/>
        void ISynthesizer.RemoveModule(IModuleHandle moduleHandle)
        {
            RemoveModule(moduleHandle.Id);
        }

        /// <inheritdoc/>
        public void ConnectModule(int sourceId, int destinationId)
        {
            using (Slot.AcquireLock())
            {
                _lib.ConnectModule(_id, sourceId, destinationId);
            }
        }

        /// <inheritdoc cref="ISynthesizer.ConnectModule(IModuleHandle, IModuleHandle)"/>
        public void ConnectModule(ModuleHandle source, ModuleHandle destination)
        {
            ConnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc/>
        void ISynthesizer.ConnectModule(IModuleHandle source, IModuleHandle destination)
        {
            ConnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc/>
        public void DisconnectModule(int sourceId, int destinationId)
        {
            using (Slot.AcquireLock())
            {
                _lib.DisconnectModule(_id, sourceId, destinationId);
            }
        }

        /// <inheritdoc cref="ISynthesizer.DisconnectModule(IModuleHandle, IModuleHandle)"/>
        public void DisconnectModule(ModuleHandle source, ModuleHandle destination)
        {
            DisconnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc/>
        void ISynthesizer.DisconnectModule(IModuleHandle source, IModuleHandle destination)
        {
            DisconnectModule(source.Id, destination.Id);
        }

        public IEnumerator<ModuleHandle> GetEnumerator()
        {
            for (var i = 0; i < GetUpperModuleCount(); i++)
            {
                if (TryGetModule(i, out var moduleHandle))
                {
                    yield return moduleHandle.Value;
                }
            }
        }

        IEnumerator<IModuleHandle> IEnumerable<IModuleHandle>.GetEnumerator()
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
