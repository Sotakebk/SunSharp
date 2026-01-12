using SunSharp.Native;

namespace SunSharp
{
    /// <summary>
    /// Represents a handle to a generic synthesizer module, providing access to module properties
    /// and operations regardless of the underlying module type.
    /// </summary>
    public interface IGenericSynthModuleHandle
    {
        /// <summary>
        /// Gets the ID of the synthessizer module.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the slot associated with this instance.
        /// </summary>
        ISlot Slot { get; }

        ModuleFlags GetFlags();

        /// <summary>
        /// Returns the module type. If the module does not exist, returns <see langword="null"/>.
        /// If the module type is unknown (due to library mismatch or otherwise), returns <see cref="SynthModuleType.Unknown"/>.
        /// </summary>
        /// <returns> </returns>
        SynthModuleType? GetModuleType();

        bool GetExists();

        FineTunePair GetFineTune();

        void SetFineTune(FineTunePair fineTune);

        /// <summary>
        /// Read module scope view, and write it to a buffer.
        /// </summary>
        /// <returns> Number of samples successfully read. </returns>
        int ReadScope(AudioChannel channel, short[] buffer);

        string? GetName();

        void SetName(string name);

        (int x, int y) GetPosition();

        void SetPosition(int x, int y);

        (byte R, byte G, byte B) GetColor();

        void SetColor(byte r, byte g, byte b);

        int[] GetInputs();

        ISynthModuleHandle[] GetInputModules();

        int[] GetOutputs();

        ISynthModuleHandle[] GetOutputModules();
    }

    public partial interface ISynthModuleHandle : IGenericSynthModuleHandle
    {
        /// <summary>
        /// Load a sample (xi, wav, aiff) to a Sampler module from file.
        /// </summary>
        /// <remarks>
        /// Set <paramref name="sampleSlot"/> to <see langword="null"/> to apply the sample to all
        /// sample slots.
        /// </remarks>
        void LoadSamplerSample(string path, int? sampleSlot = null);

        /// <summary>
        /// Load a sample (xi, wav, aiff) to a Sampler module from memory. Set <paramref
        /// name="sampleSlot"/> to -1 to apply the sample to all sample slots.
        /// </summary>
        void LoadSamplerSample(byte[] data, int? sampleSlot = null);

        /// <summary>
        /// load a file into the MetaModule. Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        void LoadIntoMetaModule(string path);

        /// <summary>
        /// load a file from memory into the MetaModule. Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        void LoadIntoMetaModule(byte[] data);

        /// <summary>
        /// load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        void LoadIntoVorbisPLayer(string path);

        /// <summary>
        /// load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        void LoadIntoVorbisPLayer(byte[] data);

        int WriteCurve(int curveId, float[] buffer);

        int ReadCurve(int curveId, float[] buffer);

        int GetControllerCount();

        string? GetControllerName(int controllerId);

        int GetControllerValue(int controllerId, ValueScalingMode scaling = ValueScalingMode.Displayed);

        void SetControllerValue(int controller, int value, ValueScalingMode scaling = ValueScalingMode.Displayed);

        int GetControllerMinValue(int controllerId, ValueScalingMode scaling);

        int GetControllerMaxValue(int controllerId, ValueScalingMode scaling);

        int GetControllerOffset(int controllerId);

        ControllerType GetControllerType(int controllerId);

        int GetControllerGroup(int controllerId);
    }

    /// <inheritdoc cref="ISynthModuleHandle"/>
    public readonly partial struct SynthModuleHandle : ISynthModuleHandle
    {
        private readonly ISunVoxLib _lib;
        private readonly int _slotId;

        /// <inheritdoc/>
        public int Id { get; }

        public Slot Slot { get; }

        ISlot IGenericSynthModuleHandle.Slot => Slot;

        public SynthModuleHandle(Slot slot, int id)
        {
            Slot = slot;
            _lib = slot.Library;
            _slotId = Slot.Id;
            Id = id;
        }

        #region general

        /// <inheritdoc/>
        public ModuleFlags GetFlags()
        {
            return _lib.GetModuleFlags(_slotId, Id);
        }

        /// <inheritdoc/>
        public SynthModuleType? GetModuleType()
        {
            var moduleType = _lib.GetModuleType(_slotId, Id);
            if (moduleType == null)
            {
                return null;
            }
            return SynthModuleTypeHelper.TypeFromInternalName(moduleType);
        }

        /// <inheritdoc/>
        public bool GetExists()
        {
            return _lib.GetModuleExists(_slotId, Id);
        }

        /// <inheritdoc/>
        public FineTunePair GetFineTune()
        {
            return _lib.GetModuleFineTune(_slotId, Id);
        }

        /// <inheritdoc/>
        public void SetFineTune(FineTunePair fineTune)
        {
            _lib.SetModuleRelativeNote(_slotId, Id, fineTune.RelativeNote);
            _lib.SetModuleFineTune(_slotId, Id, fineTune.FineTune);
        }

        /// <inheritdoc/>
        public int ReadScope(AudioChannel channel, short[] buffer)
        {
            return _lib.ReadModuleScope(_slotId, Id, channel, buffer);
        }

        #endregion general

        #region cosmetic

        /// <inheritdoc/>
        public string? GetName()
        {
            return _lib.GetModuleName(_slotId, Id);
        }

        /// <inheritdoc/>
        public void SetName(string name)
        {
            _lib.SetModuleName(_slotId, Id, name);
        }

        /// <inheritdoc/>
        public (int x, int y) GetPosition()
        {
            return _lib.GetModulePosition(_slotId, Id);
        }

        /// <inheritdoc/>
        public void SetPosition(int x, int y)
        {
            _lib.SetModulePosition(_slotId, Id, x, y);
        }

        /// <inheritdoc/>
        public (byte R, byte G, byte B) GetColor()
        {
            return _lib.GetModuleColor(_slotId, Id);
        }

        /// <inheritdoc/>
        public void SetColor(byte r, byte g, byte b)
        {
            _lib.SetModuleColor(_slotId, Id, r, g, b);
        }

        #endregion cosmetic

        #region connections

        /// <inheritdoc/>
        public int[] GetInputs()
        {
            return _lib.GetModuleInputs(_slotId, Id);
        }

        /// <inheritdoc cref="=IModuleHandle.GetInputModules"/>
        public SynthModuleHandle[] GetInputModules()
        {
            return ToHandles(GetInputs());
        }

        ISynthModuleHandle[] IGenericSynthModuleHandle.GetInputModules()
        {
            return ToInterfaceHandles(GetInputs());
        }

        /// <inheritdoc/>
        public int[] GetOutputs()
        {
            return _lib.GetModuleInputs(_slotId, Id);
        }

        /// <inheritdoc/>
        public SynthModuleHandle[] GetModuleOutputs()
        {
            return ToHandles(GetOutputs());
        }

        ISynthModuleHandle[] IGenericSynthModuleHandle.GetOutputModules()
        {
            return ToInterfaceHandles(GetOutputs());
        }

        private SynthModuleHandle[] ToHandles(int[] connections)
        {
            var handles = new SynthModuleHandle[connections.Length];
            for (var i = 0; i < connections.Length; i++)
            {
                handles[i] = new SynthModuleHandle(Slot, connections[i]);
            }
            return handles;
        }

        private ISynthModuleHandle[] ToInterfaceHandles(int[] connections)
        {
            var handles = new ISynthModuleHandle[connections.Length];
            for (var i = 0; i < connections.Length; i++)
            {
                handles[i] = new SynthModuleHandle(Slot, connections[i]);
            }
            return handles;
        }

        #endregion connections

        #region specific data IO

        /// <inheritdoc/>
        public void LoadSamplerSample(string path, int? sampleSlot = null)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            using (Slot.AcquireLock())
            {
                lib.LoadSamplerSample(slotId, id, path, sampleSlot);
            }
        }

        /// <inheritdoc/>
        public void LoadSamplerSample(byte[] data, int? sampleSlot = null)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            using (Slot.AcquireLock())
            {
                lib.LoadSamplerSample(slotId, id, data, sampleSlot);
            }
        }

        /// <inheritdoc/>
        public void LoadIntoMetaModule(string path)
        {
            _lib.LoadIntoMetaModule(_slotId, Id, path);
        }

        /// <inheritdoc/>
        public void LoadIntoMetaModule(byte[] data)
        {
            _lib.LoadIntoMetaModule(_slotId, Id, data);
        }

        /// <inheritdoc/>
        public void LoadIntoVorbisPLayer(string path)
        {
            _lib.LoadIntoVorbisPLayer(_slotId, Id, path);
        }

        /// <inheritdoc/>
        public void LoadIntoVorbisPLayer(byte[] data)
        {
            _lib.LoadIntoVorbisPLayer(_slotId, Id, data);
        }

        /// <inheritdoc/>
        public int WriteCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            using (Slot.AcquireLock())
            {
                return lib.WriteModuleCurve(slotId, id, curveId, buffer);
            }
        }

        /// <inheritdoc/>
        public int ReadCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = Id;
            using (Slot.AcquireLock())
            {
                return lib.ReadModuleCurve(slotId, id, curveId, buffer);
            }
        }

        #endregion specific data IO

        #region controllers

        /// <inheritdoc/>
        public int GetControllerCount()
        {
            return _lib.GetModuleControllerCount(_slotId, Id);
        }

        /// <inheritdoc/>
        public string? GetControllerName(int controllerId)
        {
            return _lib.GetModuleControllerName(_slotId, Id, controllerId);
        }

        /// <inheritdoc/>
        public int GetControllerValue(int controllerId, ValueScalingMode scaling = ValueScalingMode.Displayed)
        {
            return _lib.GetModuleControllerValue(_slotId, Id, controllerId, scaling);
        }

        /// <inheritdoc/>
        public void SetControllerValue(int controller, int value, ValueScalingMode scaling = ValueScalingMode.Displayed)
        {
            _lib.SetModuleControllerValue(_slotId, Id, controller, value, scaling);
        }

        /// <inheritdoc/>
        public int GetControllerMinValue(int controllerId, ValueScalingMode scaling)
        {
            return _lib.GetModuleControllerMinValue(_slotId, Id, controllerId, scaling);
        }

        /// <inheritdoc/>
        public int GetControllerMaxValue(int controllerId, ValueScalingMode scaling)
        {
            return _lib.GetModuleControllerMaxValue(_slotId, Id, controllerId, scaling);
        }

        /// <inheritdoc/>
        public int GetControllerOffset(int controllerId)
        {
            return _lib.GetModuleControllerOffset(_slotId, Id, controllerId);
        }

        /// <inheritdoc/>
        public ControllerType GetControllerType(int controllerId)
        {
            return _lib.GetModuleControllerType(_slotId, Id, controllerId);
        }

        /// <inheritdoc/>
        public int GetControllerGroup(int controllerId)
        {
            return _lib.GetModuleControllerGroup(_slotId, Id, controllerId);
        }

        #endregion controllers
    }
}
