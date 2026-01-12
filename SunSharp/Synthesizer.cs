using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SunSharp.Native;

namespace SunSharp
{
    public interface ISynthesizer : IEnumerable<ISynthModuleHandle>
    {
        ISlot Slot { get; }

        int GetUpperModuleCount();

        bool GetModuleExists(int moduleId);

        ModuleFlags GetModuleFlags(int moduleId);

        bool TryGetModule(int moduleId, [NotNullWhen(true)] out ISynthModuleHandle? moduleHandle);

        bool TryGetModule(string name, [NotNullWhen(true)] out ISynthModuleHandle? moduleHandle);

        ISynthModuleHandle CreateModule(SynthModuleType type, string name, int x = 0, int y = 0, int z = 0);

        /// <summary>
        /// load a module or sample. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        ISynthModuleHandle LoadModule(byte[] data, int x = 0, int y = 0, int z = 0);

        /// <summary>
        /// load a module or sample. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        ISynthModuleHandle LoadModule(string path, int x = 0, int y = 0, int z = 0);

        void RemoveModule(int moduleId);

        void RemoveModule(ISynthModuleHandle moduleHandle);

        void ConnectModule(int sourceId, int destinationId);

        void ConnectModule(ISynthModuleHandle source, ISynthModuleHandle destination);

        void DisconnectModule(int sourceId, int destinationId);

        void DisconnectModule(ISynthModuleHandle source, ISynthModuleHandle destination);
    }

    public class Synthesizer : ISynthesizer, IEnumerable<SynthModuleHandle>
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

        /// <inheritdoc cref="ISynthesizer.TryGetModule(int, out ISynthModuleHandle?)"/>
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

        /// <inheritdoc cref="ISynthesizer.TryGetModule(string, out ISynthModuleHandle?)"/>
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

        /// <inheritdoc cref="ISynthesizer.CreateModule"/>
        public SynthModuleHandle CreateModule(SynthModuleType type, string name, int x = 0, int y = 0, int z = 0)
        {
            if (!Enum.IsDefined(typeof(SynthModuleType), type))
            {
                throw new ArgumentOutOfRangeException(nameof(type), "The specified ModuleType is not defined.");
            }

            using (Slot.AcquireLock())
            {
                var moduleId = _lib.CreateModule(_id, SynthModuleTypeHelper.InternalNameFromType(type), name, x, y, z);
                return new SynthModuleHandle(Slot, moduleId);
            }
        }

        /// <inheritdoc/>
        ISynthModuleHandle ISynthesizer.CreateModule(SynthModuleType type, string name, int x, int y, int z)
        {
            return CreateModule(type, name, x, y, z);
        }

        /// <inheritdoc cref="ISynthesizer.LoadModule(byte[], int, int, int)"/>
        public SynthModuleHandle LoadModule(byte[] data, int x = 0, int y = 0, int z = 0)
        {
            using (Slot.AcquireLock())
            {
                var moduleId = _lib.LoadModule(_id, data, x, y, z);
                return new SynthModuleHandle(Slot, moduleId);
            }
        }

        /// <inheritdoc cref="ISynthesizer.LoadModule(string, int, int, int)"/>
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

        /// <inheritdoc/>
        public void RemoveModule(int moduleId)
        {
            using (Slot.AcquireLock())
            {
                _lib.RemoveModule(_id, moduleId);
            }
        }

        /// <inheritdoc cref="ISynthesizer.RemoveModule(ISynthModuleHandle)"/>
        public void RemoveModule(SynthModuleHandle moduleHandle)
        {
            RemoveModule(moduleHandle.Id);
        }

        /// <inheritdoc/>
        void ISynthesizer.RemoveModule(ISynthModuleHandle moduleHandle)
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

        /// <inheritdoc cref="ISynthesizer.ConnectModule(ISynthModuleHandle, ISynthModuleHandle)"/>
        public void ConnectModule(SynthModuleHandle source, SynthModuleHandle destination)
        {
            ConnectModule(source.Id, destination.Id);
        }

        /// <inheritdoc/>
        void ISynthesizer.ConnectModule(ISynthModuleHandle source, ISynthModuleHandle destination)
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

        /// <inheritdoc cref="ISynthesizer.DisconnectModule(ISynthModuleHandle, ISynthModuleHandle)"/>
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
