using SunSharp.ThinWrapper;
using System.Linq;

namespace SunSharp.ObjectWrapper
{
    /// <summary>
    /// Represents a module. The underlying SunVox module may or may not exist!
    /// </summary>
    public readonly struct ModuleHandle
    {
        private readonly ISunVoxLib _lib;
        private readonly Slot _slot;
        private readonly int _id;
        private readonly int _slotId;

        public int Id => _id;
        public Slot Slot => _slot;

        public ModuleHandle(Synthesizer synthesizer, int id)
        {
            _slot = synthesizer.Slot;
            _slotId = _slot.Id;
            _lib = synthesizer.Slot.Library;
            _id = id;
        }

        #region general

        public ModuleFlags GetFlags() => _lib.GetModuleFlags(_slotId, _id);

        public ModuleType GetModuleType() => ModuleTypeHelper.TypeFromInternalName(_lib.GetModuleType(_slotId, _id));

        public bool GetExists() => _lib.GetModuleExists(_slotId, _id);

        public (int finetune, int relativeNote) GetFinetune() => _lib.GetModuleFinetune(_slotId, _id);

        public void SetFinetune(int finetune, int relativeNote)
        {
            _lib.SetModuleRelativeNote(_slotId, _id, relativeNote);
            _lib.SetModuleFinetune(_slotId, _id, finetune);
        }

        /// <summary>
        /// Read module scope view, and write it to a buffer.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="buffer"></param>
        /// <returns>Number of samples successfully read.</returns>
        public int ReadScope(AudioChannel channel, short[] buffer)
        {
            return _lib.ReadModuleScope(_slotId, _id, (int)channel, buffer);
        }

        #endregion general

        #region cosmetic

        public string GetName() => _lib.GetModuleName(_slotId, _id);

        public void SetName(string name) => _lib.SetModuleName(_slotId, _id, name);

        public (int x, int y) GetPosition() => _lib.GetModulePosition(_slotId, _id);

        public void SetPosition(int x, int y) => _lib.SetModulePosition(_slotId, _id, x, y);

        public (byte R, byte G, byte B) GetColor() => _lib.GetModuleColor(_slotId, _id);

        public void SetColor(byte R, byte G, byte B) => _lib.SetModuleColor(_slotId, _id, R, G, B);

        #endregion cosmetic

        #region connections

        public int[] GetInputs() => _lib.GetModuleInputs(_slotId, _id);

        public ModuleHandle[] GetInputModules()
        {
            var synthesizer = _slot.Synthesizer;
            return _lib.GetModuleInputs(_slotId, _id).Select(i => new ModuleHandle(synthesizer, i)).ToArray();
        }

        public int[] GetOutputs() => _lib.GetModuleInputs(_slotId, _id);

        public ModuleHandle[] GetModuleOutputs()
        {
            var synthesizer = _slot.Synthesizer;
            return _lib.GetModuleOutputs(_slotId, _id).Select(i => new ModuleHandle(synthesizer, i)).ToArray();
        }

        #endregion connections

        #region specific data IO

        /// <summary>
        /// Load a sample (xi, wav, aiff) to a Sampler module from file.
        /// Set <paramref name="sampleSlot"/> to -1 to apply the sample to all sample slots.
        /// </summary>
        public void LoadSamplerSample(string path, int sampleSlot = -1)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.LoadSamplerSample(slotId, id, path, sampleSlot);
            });
        }

        /// <summary>
        /// Load a sample (xi, wav, aiff) to a Sampler module from memory.
        /// Set <paramref name="sampleSlot"/> to -1 to apply the sample to all sample slots.
        /// </summary>
        public void LoadSamplerSample(byte[] data, int sampleSlot = -1)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.LoadSamplerSample(slotId, id, data, sampleSlot);
            });
        }

        /// <summary>
        /// load a file into the MetaModule. Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        public void LoadIntoMetaModule(string path)
        {
            _lib.LoadIntoMetaModule(_slotId, _id, path);
        }

        /// <summary>
        /// load a file from memory into the MetaModule. Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        public void LoadIntoMetaModule(byte[] data)
        {
            _lib.LoadIntoMetaModule(_slotId, _id, data);
        }

        /// <summary>
        /// load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        public void LoadIntoVorbisPLayer(string path)
        {
            _lib.LoadIntoVorbisPLayer(_slotId, _id, path);
        }

        /// <summary>
        /// load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        public void LoadIntoVorbisPLayer(byte[] data)
        {
            _lib.LoadIntoVorbisPLayer(_slotId, _id, data);
        }

        public int WriteCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            return _slot.RunInLock(() =>
            {
                return lib.WriteModuleCurve(slotId, id, curveId, buffer);
            });
        }

        public int ReadCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            return _slot.RunInLock(() =>
            {
                return lib.ReadModuleCurve(slotId, id, curveId, buffer);
            });
        }

        #endregion specific data IO

        #region controllers

        public int GetControllerCount()
        {
            return _lib.GetModuleControllerCount(_slotId, _id);
        }

        public string GetControllerName(int controllerId)
        {
            return _lib.GetModuleControllerName(_slotId, _id, controllerId);
        }

        public int GetControllerValue(int controllerId, ValueScalingType scaling = ValueScalingType.Displayed)
        {
            return _lib.GetModuleControllerValue(_slotId, _id, controllerId, scaling);
        }

        public void SetControllerValue(int controller, int value, ValueScalingType scaling = ValueScalingType.Displayed)
        {
            _lib.SetModuleControllerValue(_slotId, _id, controller, value, scaling);
        }

        public int GetControllerMinValue(int controllerId, ValueScalingType scaling)
        {
            return _lib.GetModuleControllerMinValue(_slotId, _id, controllerId, scaling);
        }

        public int GetControllerMaxValue(int controllerId, ValueScalingType scaling)
        {
            return _lib.GetModuleControllerMaxValue(_slotId, _id, controllerId, scaling);
        }

        public int GetControllerOffset(int controllerId)
        {
            return _lib.GetModuleControllerOffset(_slotId, _id, controllerId);
        }

        public ControllerType GetControllerType(int controllerId)
        {
            return _lib.GetModuleControllerType(_slotId, _id, controllerId);
        }

        public int GetControllerGroup(int controllerId)
        {
            return _lib.GetModuleControllerGroup(_slotId, _id, controllerId);
        }

        #endregion controllers
    }
}
