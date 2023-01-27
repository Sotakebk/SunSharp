using SunSharp.ThinWrapper;
using System.Collections;
using System.Collections.Generic;

namespace SunSharp.ObjectWrapper
{
    public class Synthesizer : IEnumerable<Module>
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

        public bool TryGetModule(int moduleId, out Module module)
        {
            if (_lib.GetModuleExists(_id, moduleId))
            {
                module = new Module(this, moduleId);
                return true;
            }
            else
            {
                module = default;
                return false;
            }
        }

        public bool TryGetModule(string name, out Module module)
        {
            int moduleId = _lib.FindModule(_id, name);
            if (moduleId > -1)
            {
                module = new Module(this, moduleId);
                return true;
            }
            else
            {
                module = default;
                return false;
            }
        }

        public Module CreateModule(ModuleType type, string name, int x = 0, int y = 0, int z = 0)
        {
            return _slot.RunInLock(() =>
            {
                var moduleId = _lib.CreateModule(_id, type.ToString().Replace('_', ' '), name, x, y, z);
                return new Module(this, moduleId);
            });
        }

        public Module LoadModule(byte[] data, int x = 0, int y = 0, int z = 0)
        {
            return _slot.RunInLock(() =>
            {
                var moduleId = _lib.LoadModule(_id, data, x, y, z);
                return new Module(this, moduleId);
            });
        }

        public Module LoadModule(string path, int x = 0, int y = 0, int z = 0)
        {
            return _slot.RunInLock(() =>
            {
                var moduleId = _lib.LoadModule(_id, path, x, y, z);
                return new Module(this, moduleId);
            });
        }

        public void RemoveModule(int moduleId)
        {
            _slot.RunInLock(() =>
            {
                _lib.RemoveModule(_id, moduleId);
            });
        }

        public void RemoveModule(Module module) => RemoveModule(module.Id);

        public void ConnectModule(int sourceId, int destinationId)
        {
            _slot.RunInLock(() =>
            {
                _lib.ConnectModule(_id, sourceId, destinationId);
            });
        }

        public void ConnectModule(Module source, Module destination) => ConnectModule(source.Id, destination.Id);

        public void DisconnectModule(int sourceId, int destinationId)
        {
            _slot.RunInLock(() =>
            {
                _lib.DisconnectModule(_id, sourceId, destinationId);
            });
        }

        public void DisconnectModule(Module source, Module destination) => DisconnectModule(source.Id, destination.Id);

        public IEnumerator<Module> GetEnumerator()
        {
            for (int i = 0; i < GetUpperModuleCount(); i++)
                if (TryGetModule(i, out var p))
                    yield return p;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
