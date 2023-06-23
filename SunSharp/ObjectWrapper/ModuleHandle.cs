using System.Linq;
using SunSharp.ThinWrapper;

namespace SunSharp.ObjectWrapper
{
    /// <summary>
    /// Represents a module. The underlying SunVox module may or may not exist!
    /// </summary>
    public readonly struct ModuleHandle
    {
        private readonly ISunVoxLib _lib;
        private readonly int _slotId;

        public int Id { get; }

        public Slot Slot { get; }

        public ModuleHandle(Synthesizer synthesizer, int id)
        {
            Slot = synthesizer.Slot;
            _slotId = Slot.Id;
            _lib = synthesizer.Slot.Library;
            Id = id;
        }

        #region general

        public ModuleFlags GetFlags() => _lib.GetModuleFlags(_slotId, Id);

        public ModuleType GetModuleType() => ModuleTypeHelper.TypeFromInternalName(_lib.GetModuleType(_slotId, Id));

        public bool GetExists() => _lib.GetModuleExists(_slotId, Id);

        public FineTunePair GetFineTune() => _lib.GetModuleFineTune(_slotId, Id);

        public void SetFineTune(FineTunePair pair)
        {
            _lib.SetModuleRelativeNote(_slotId, Id, pair.RelativeNote);
            _lib.SetModuleFineTune(_slotId, Id, pair.FineTune);
        }

        /// <summary>
        /// Read module scope view, and write it to a buffer.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="buffer"></param>
        /// <returns>Number of samples successfully read.</returns>
        public int ReadScope(AudioChannel channel, short[] buffer)
        {
            return _lib.ReadModuleScope(_slotId, Id, (int)channel, buffer);
        }

        #endregion general

        #region cosmetic

        public string? GetName() => _lib.GetModuleName(_slotId, Id);

        public void SetName(string name) => _lib.SetModuleName(_slotId, Id, name);

        public (int x, int y) GetPosition() => _lib.GetModulePosition(_slotId, Id);

        public void SetPosition(int x, int y) => _lib.SetModulePosition(_slotId, Id, x, y);

        public (byte r, byte g, byte b) GetColor() => _lib.GetModuleColor(_slotId, Id);

        public void SetColor(byte r, byte g, byte b) => _lib.SetModuleColor(_slotId, Id, r, g, b);

        #endregion cosmetic

        #region connections

        public int[] GetInputs() => _lib.GetModuleInputs(_slotId, Id);

        public ModuleHandle[] GetInputModules()
        {
            var synthesizer = Slot.Synthesizer;
            return _lib.GetModuleInputs(_slotId, Id).Select(i => new ModuleHandle(synthesizer, i)).ToArray();
        }

        public int[] GetOutputs() => _lib.GetModuleInputs(_slotId, Id);

        public ModuleHandle[] GetModuleOutputs()
        {
            var synthesizer = Slot.Synthesizer;
            return _lib.GetModuleOutputs(_slotId, Id).Select(i => new ModuleHandle(synthesizer, i)).ToArray();
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
            var id = Id;
            Slot.RunInLock(() => { lib.LoadSamplerSample(slotId, id, path, sampleSlot); });
        }

        /// <summary>
        /// Load a sample (xi, wav, aiff) to a Sampler module from memory.
        /// Set <paramref name="sampleSlot"/> to -1 to apply the sample to all sample slots.
        /// </summary>
        public void LoadSamplerSample(byte[] data, int sampleSlot = -1)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            Slot.RunInLock(() => { lib.LoadSamplerSample(slotId, id, data, sampleSlot); });
        }

        /// <summary>
        /// load a file into the MetaModule. Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        public void LoadIntoMetaModule(string path)
        {
            _lib.LoadIntoMetaModule(_slotId, Id, path);
        }

        /// <summary>
        /// load a file from memory into the MetaModule. Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        public void LoadIntoMetaModule(byte[] data)
        {
            _lib.LoadIntoMetaModule(_slotId, Id, data);
        }

        /// <summary>
        /// load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        public void LoadIntoVorbisPLayer(string path)
        {
            _lib.LoadIntoVorbisPLayer(_slotId, Id, path);
        }

        /// <summary>
        /// load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        public void LoadIntoVorbisPLayer(byte[] data)
        {
            _lib.LoadIntoVorbisPLayer(_slotId, Id, data);
        }

        public int WriteCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            return Slot.RunInLock(() => lib.WriteModuleCurve(slotId, id, curveId, buffer));
        }

        public int ReadCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            return Slot.RunInLock(() => lib.ReadModuleCurve(slotId, id, curveId, buffer));
        }

        #endregion specific data IO

        #region controllers

        public int GetControllerCount()
        {
            return _lib.GetModuleControllerCount(_slotId, Id);
        }

        public string? GetControllerName(int controllerId)
        {
            return _lib.GetModuleControllerName(_slotId, Id, controllerId);
        }

        public int GetControllerValue(int controllerId, ValueScalingType scaling = ValueScalingType.Displayed)
        {
            return _lib.GetModuleControllerValue(_slotId, Id, controllerId, scaling);
        }

        public void SetControllerValue(int controller, int value, ValueScalingType scaling = ValueScalingType.Displayed)
        {
            _lib.SetModuleControllerValue(_slotId, Id, controller, value, scaling);
        }

        public int GetControllerMinValue(int controllerId, ValueScalingType scaling)
        {
            return _lib.GetModuleControllerMinValue(_slotId, Id, controllerId, scaling);
        }

        public int GetControllerMaxValue(int controllerId, ValueScalingType scaling)
        {
            return _lib.GetModuleControllerMaxValue(_slotId, Id, controllerId, scaling);
        }

        public int GetControllerOffset(int controllerId)
        {
            return _lib.GetModuleControllerOffset(_slotId, Id, controllerId);
        }

        public ControllerType GetControllerType(int controllerId)
        {
            return _lib.GetModuleControllerType(_slotId, Id, controllerId);
        }

        public int GetControllerGroup(int controllerId)
        {
            return _lib.GetModuleControllerGroup(_slotId, Id, controllerId);
        }

        #endregion controllers
    }
}
