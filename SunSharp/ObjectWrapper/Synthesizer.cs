using System.Collections;
using System.Collections.Generic;
using SunSharp.ThinWrapper;

namespace SunSharp.ObjectWrapper
{
    public class Synthesizer : IEnumerable<ModuleHandle>
    {
        private readonly ISunVoxLib _lib;
        private readonly Slot _slot;
        private readonly int _id;

        public Slot Slot => _slot;

        internal Synthesizer(Slot slot)
        {
            _slot = slot;
            _lib = slot.SunVox.Library;
            _id = slot.Id;
        }

        public int GetUpperModuleCount() => _lib.GetUpperModuleCount(_id);

        public bool GetModuleExists(int moduleId) => _lib.GetModuleExists(_id, moduleId);

        public ModuleFlags GetModuleFlags(int moduleId) => _lib.GetModuleFlags(_id, moduleId);

        public bool TryGetModule(int moduleId, out ModuleHandle module)
        {
            if (_lib.GetModuleExists(_id, moduleId))
            {
                module = new ModuleHandle(this, moduleId);
                return true;
            }
            else
            {
                module = default;
                return false;
            }
        }

        public bool TryGetModule(string name, out ModuleHandle module)
        {
            int moduleId = _lib.FindModule(_id, name);
            if (moduleId > -1)
            {
                module = new ModuleHandle(this, moduleId);
                return true;
            }
            else
            {
                module = default;
                return false;
            }
        }

        public ModuleHandle CreateModule(ModuleType type, string name, int x = 0, int y = 0, int z = 0)
        {
            return _slot.RunInLock(() =>
            {
                var moduleId = _lib.CreateModule(_id, ModuleTypeHelper.InternalNameFromType(type), name, x, y, z);
                return new ModuleHandle(this, moduleId);
            });
        }

        /// <summary>
        /// load a module or sample. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public ModuleHandle LoadModule(byte[] data, int x = 0, int y = 0, int z = 0)
        {
            return _slot.RunInLock(() =>
            {
                var moduleId = _lib.LoadModule(_id, data, x, y, z);
                return new ModuleHandle(this, moduleId);
            });
        }

        /// <summary>
        /// load a module or sample. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public ModuleHandle LoadModule(string path, int x = 0, int y = 0, int z = 0)
        {
            return _slot.RunInLock(() =>
            {
                var moduleId = _lib.LoadModule(_id, path, x, y, z);
                return new ModuleHandle(this, moduleId);
            });
        }

        public void RemoveModule(int moduleId)
        {
            _slot.RunInLock(() => { _lib.RemoveModule(_id, moduleId); });
        }

        public void RemoveModule(ModuleHandle module) => RemoveModule(module.Id);

        public void ConnectModule(int sourceId, int destinationId)
        {
            _slot.RunInLock(() => { _lib.ConnectModule(_id, sourceId, destinationId); });
        }

        public void ConnectModule(ModuleHandle source, ModuleHandle destination) =>
            ConnectModule(source.Id, destination.Id);

        public void DisconnectModule(int sourceId, int destinationId)
        {
            _slot.RunInLock(() => { _lib.DisconnectModule(_id, sourceId, destinationId); });
        }

        public void DisconnectModule(ModuleHandle source, ModuleHandle destination) =>
            DisconnectModule(source.Id, destination.Id);

        public IEnumerator<ModuleHandle> GetEnumerator()
        {
            for (int i = 0; i < GetUpperModuleCount(); i++)
                if (TryGetModule(i, out var p))
                    yield return p;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
