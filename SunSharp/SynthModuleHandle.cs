using SunSharp.Native;

namespace SunSharp
{
    /// <inheritdoc cref="SynthModuleHandle"/>
    public interface IGenericSynthModuleHandle
    {
        /// <inheritdoc cref="SynthModuleHandle.Id"/>
        int Id { get; }

        /// <inheritdoc cref="SynthModuleHandle.Slot"/>
        ISlot Slot { get; }

        /// <inheritdoc cref="SynthModuleHandle.GetFlags"/>
        ModuleFlags GetFlags();

        /// <inheritdoc cref="SynthModuleHandle.GetModuleType"/>
        SynthModuleType? GetModuleType();

        /// <inheritdoc cref="SynthModuleHandle.GetExists"/>
        bool GetExists();

        /// <inheritdoc cref="SynthModuleHandle.GetFineTune"/>
        FineTunePair GetFineTune();

        /// <inheritdoc cref="SynthModuleHandle.SetFineTune"/>
        void SetFineTune(FineTunePair fineTune);

        /// <inheritdoc cref="SynthModuleHandle.ReadScope"/>
        int ReadScope(AudioChannel channel, short[] buffer);

        /// <inheritdoc cref="SynthModuleHandle.GetName"/>
        string? GetName();

        /// <inheritdoc cref="SynthModuleHandle.SetName"/>
        void SetName(string name);

        /// <inheritdoc cref="SynthModuleHandle.GetPosition"/>
        (int x, int y) GetPosition();

        /// <inheritdoc cref="SynthModuleHandle.SetPosition"/>
        void SetPosition(int x, int y);

        /// <inheritdoc cref="SynthModuleHandle.GetColor"/>
        (byte R, byte G, byte B) GetColor();

        /// <inheritdoc cref="SynthModuleHandle.SetColor"/>
        void SetColor(byte r, byte g, byte b);

        /// <inheritdoc cref="SynthModuleHandle.GetInputs"/>
        int[] GetInputs();

        /// <inheritdoc cref="SynthModuleHandle.GetInputModules"/>
        ISynthModuleHandle[] GetInputModules();

        /// <inheritdoc cref="SynthModuleHandle.GetOutputs"/>
        int[] GetOutputs();

        /// <inheritdoc cref="SynthModuleHandle.GetOutputModules"/>
        ISynthModuleHandle[] GetOutputModules();

        /// <inheritdoc cref="SynthModuleHandle.ConnectInput(int)"/>
        void ConnectInput(int targetModuleId);

        /// <inheritdoc cref="SynthModuleHandle.ConnectInput(SynthModuleHandle)"/>
        void ConnectInput(ISynthModuleHandle targetModule);

        /// <inheritdoc cref="SynthModuleHandle.ConnectOutput(int)"/>
        void ConnectOutput(int targetModuleId);

        /// <inheritdoc cref="SynthModuleHandle.ConnectOutput(SynthModuleHandle)"/>
        void ConnectOutput(ISynthModuleHandle targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectInput(int)"/>
        void DisconnectInput(int targetModuleId);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectInput(SynthModuleHandle)"/>
        void DisconnectInput(ISynthModuleHandle targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectOutput(int)"/>
        void DisconnectOutput(int targetModuleId);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectOutput(SynthModuleHandle)"/>
        void DisconnectOutput(ISynthModuleHandle targetModule);

        /// <inheritdoc cref="SynthModuleHandle.MakeSetControllerValueEvent(byte, ushort)"/>
        PatternEvent MakeSetControllerValueEvent(byte controllerId, ushort value);

        /// <inheritdoc cref="SynthModuleHandle.MakeNoteEvent(Note, byte?)"/>
        PatternEvent MakeNoteEvent(Note note, byte? velocity = null);

        /// <inheritdoc cref="SynthModuleHandle.MakeSetPitchEvent(ushort, byte?)"/>
        PatternEvent MakeSetPitchEvent(ushort pitch, byte? velocity = null);

        /// <inheritdoc cref="SynthModuleHandle.MakeSetFrequencyEvent(double, byte?)"/>
        PatternEvent MakeSetFrequencyEvent(double frequency, byte? velocity = null);

        /// <inheritdoc cref="SynthModuleHandle.MakeEvent(Note, byte?, byte?, Effect, ushort)"/>
        PatternEvent MakeEvent(Note note = default, byte? velocity = null, byte? controller = null, Effect effect = Effect.None, ushort value = 0);
    }

    public partial interface ISynthModuleHandle : IGenericSynthModuleHandle
    {
        /// <inheritdoc cref="SynthModuleHandle.LoadSamplerSample(string, int?)"/>
        void LoadSamplerSample(string path, int? sampleSlot = null);

        /// <inheritdoc cref="SynthModuleHandle.LoadSamplerSample(byte[], int?)"/>
        void LoadSamplerSample(byte[] data, int? sampleSlot = null);

        /// <inheritdoc cref="SynthModuleHandle.LoadIntoMetaModule(string)"/>
        void LoadIntoMetaModule(string path);

        /// <inheritdoc cref="SynthModuleHandle.LoadIntoMetaModule(byte[])"/>
        void LoadIntoMetaModule(byte[] data);

        /// <inheritdoc cref="SynthModuleHandle.LoadIntoVorbisPlayer(string)"/>
        void LoadIntoVorbisPlayer(string path);

        /// <inheritdoc cref="SynthModuleHandle.LoadIntoVorbisPlayer(byte[])"/>
        void LoadIntoVorbisPlayer(byte[] data);

        /// <inheritdoc cref="SynthModuleHandle.WriteCurve"/>
        int WriteCurve(int curveId, float[] buffer);

        /// <inheritdoc cref="SynthModuleHandle.ReadCurve"/>
        int ReadCurve(int curveId, float[] buffer);

        /// <inheritdoc cref="SynthModuleHandle.GetControllerCount"/>
        int GetControllerCount();

        /// <inheritdoc cref="SynthModuleHandle.GetControllerName"/>
        string? GetControllerName(int controllerId);

        /// <inheritdoc cref="SynthModuleHandle.GetControllerValue"/>
        int GetControllerValue(int controllerId, ValueScalingMode scaling = ValueScalingMode.Displayed);

        /// <inheritdoc cref="SynthModuleHandle.SetControllerValue"/>
        void SetControllerValue(int controller, int value, ValueScalingMode scaling = ValueScalingMode.Displayed);

        /// <inheritdoc cref="SynthModuleHandle.GetControllerMinValue"/>
        int GetControllerMinValue(int controllerId, ValueScalingMode scaling);

        /// <inheritdoc cref="SynthModuleHandle.GetControllerMaxValue"/>
        int GetControllerMaxValue(int controllerId, ValueScalingMode scaling);

        /// <inheritdoc cref="SynthModuleHandle.GetControllerOffset"/>
        int GetControllerOffset(int controllerId);

        /// <inheritdoc cref="SynthModuleHandle.GetControllerType"/>
        ControllerType GetControllerType(int controllerId);

        /// <inheritdoc cref="SynthModuleHandle.GetControllerGroup"/>
        int GetControllerGroup(int controllerId);
    }

    /// <summary>
    /// Represents a handle to a generic synthesizer module, providing access to module properties
    /// and operations regardless of the underlying module type.
    /// </summary>
    public readonly partial struct SynthModuleHandle : ISynthModuleHandle
    {
#if RELEASE
        private readonly SunVoxLib _lib;
#else
        private readonly ISunVoxLib _lib;
#endif
        private readonly int _slotId;

        /// <summary>
        /// Gets the ID of the synthesizer module.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the slot associated with this instance.
        /// </summary>
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

        /// <inheritdoc cref="ISunVoxLib.GetModuleFlags"/>
        public ModuleFlags GetFlags()
        {
            return _lib.GetModuleFlags(_slotId, Id);
        }

        /// <summary>
        /// Returns the module type. If the module does not exist, returns <see langword="null"/>.
        /// If the module type is unknown (due to library mismatch or otherwise), returns <see cref="SynthModuleType.Unknown"/>.
        /// </summary>
        public SynthModuleType? GetModuleType()
        {
            var moduleType = _lib.GetModuleType(_slotId, Id);
            if (moduleType == null)
            {
                return null;
            }
            return SynthModuleTypeHelper.TypeFromInternalName(moduleType);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleExists"/>
        public bool GetExists()
        {
            return _lib.GetModuleExists(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleFineTune"/>
        public FineTunePair GetFineTune()
        {
            return _lib.GetModuleFineTune(_slotId, Id);
        }

        /// <summary>
        /// Sets the fine tune for the module.
        /// </summary>
        public void SetFineTune(FineTunePair fineTune)
        {
            _lib.SetModuleRelativeNote(_slotId, Id, fineTune.RelativeNote);
            _lib.SetModuleFineTune(_slotId, Id, fineTune.FineTune);
        }

        /// <summary>
        /// Read module scope view, and write it to a buffer.
        /// </summary>
        /// <returns>Number of samples successfully read.</returns>
        /// <inheritdoc cref="ISunVoxLib.ReadModuleScope"/>
        public int ReadScope(AudioChannel channel, short[] buffer)
        {
            return _lib.ReadModuleScope(_slotId, Id, channel, buffer);
        }

        #endregion general

        #region cosmetic

        /// <inheritdoc cref="ISunVoxLib.GetModuleName"/>
        public string? GetName()
        {
            return _lib.GetModuleName(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetModuleName"/>
        public void SetName(string name)
        {
            _lib.SetModuleName(_slotId, Id, name);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModulePosition"/>
        public (int x, int y) GetPosition()
        {
            return _lib.GetModulePosition(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetModulePosition"/>
        public void SetPosition(int x, int y)
        {
            _lib.SetModulePosition(_slotId, Id, x, y);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleColor"/>
        public (byte R, byte G, byte B) GetColor()
        {
            return _lib.GetModuleColor(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.SetModuleColor"/>
        public void SetColor(byte r, byte g, byte b)
        {
            _lib.SetModuleColor(_slotId, Id, r, g, b);
        }

        #endregion cosmetic

        #region connections

        /// <inheritdoc cref="ISunVoxLib.GetModuleInputs"/>
        public int[] GetInputs()
        {
            return _lib.GetModuleInputs(_slotId, Id);
        }

        /// <summary>
        /// Get the array of input modules connected to this module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.GetModuleInputs"/>
        public SynthModuleHandle[] GetInputModules()
        {
            return ToHandles(GetInputs());
        }

        ISynthModuleHandle[] IGenericSynthModuleHandle.GetInputModules()
        {
            return ToInterfaceHandles(GetInputs());
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleOutputs"/>
        public int[] GetOutputs()
        {
            return _lib.GetModuleOutputs(_slotId, Id);
        }

        /// <summary>
        /// Gets the array of output modules connected to this module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.GetModuleOutputs"/>
        public SynthModuleHandle[] GetOutputModules()
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

        /// <summary>
        /// Connect the input of this module to the output of another module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void ConnectInput(int targetModuleId)
        {
            _lib.ConnectModules(_slotId, targetModuleId, Id);
        }

        /// <summary>
        /// Connect the input of this module to the output of another module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void ConnectInput(SynthModuleHandle targetModule)
        {
            ConnectInput(targetModule.Id);
        }

        void IGenericSynthModuleHandle.ConnectInput(ISynthModuleHandle targetModule)
        {
            ConnectInput(targetModule.Id);
        }

        /// <summary>
        /// Connect the output of this module to the input of another module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void ConnectOutput(int targetModuleId)
        {
            _lib.ConnectModules(_slotId, Id, targetModuleId);
        }

        /// <summary>
        /// Connect the output of this module to the input of another module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void ConnectOutput(SynthModuleHandle targetModule)
        {
            ConnectOutput(targetModule.Id);
        }

        void IGenericSynthModuleHandle.ConnectOutput(ISynthModuleHandle targetModule)
        {
            ConnectOutput(targetModule.Id);
        }

        /// <summary>
        /// Disconnect the input of this module from the output of another module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void DisconnectInput(int targetModuleId)
        {
            _lib.DisconnectModules(_slotId, targetModuleId, Id);
        }

        /// <summary>
        /// Disconnect the input of this module from the output of another module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void DisconnectInput(SynthModuleHandle targetModule)
        {
            DisconnectInput(targetModule.Id);
        }

        void IGenericSynthModuleHandle.DisconnectInput(ISynthModuleHandle targetModule)
        {
            DisconnectInput(targetModule.Id);
        }

        /// <summary>
        /// Disconnect the output of this module from the input of another module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void DisconnectOutput(int targetModuleId)
        {
            _lib.DisconnectModules(_slotId, Id, targetModuleId);
        }

        /// <summary>
        /// Disconnect the output of this module from the input of another module.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.ConnectModules"/>
        public void DisconnectOutput(SynthModuleHandle targetModule)
        {
            DisconnectOutput(targetModule.Id);
        }

        void IGenericSynthModuleHandle.DisconnectOutput(ISynthModuleHandle targetModule)
        {
            DisconnectOutput(targetModule.Id);
        }

        #endregion connections

        #region specific data IO

        /// <summary>
        /// Load a sample (xi, wav, aiff) to a Sampler module from file.
        /// </summary>
        /// <remarks>
        /// Set <paramref name="sampleSlot"/> to <see langword="null"/> to apply the sample to all sample slots.
        /// </remarks>
        /// <inheritdoc cref="ISunVoxLib.LoadSamplerSample(int, int, string, int?)"/>
        public void LoadSamplerSample(string path, int? sampleSlot = null)
        {
            _lib.LoadSamplerSample(_slotId, Id, path, sampleSlot);
        }

        /// <summary>
        /// Load a sample (xi, wav, aiff) to a Sampler module from memory.
        /// </summary>
        /// <remarks>
        /// Set <paramref name="sampleSlot"/> to <see langword="null"/> to apply the sample to all sample slots.
        /// </remarks>
        /// <inheritdoc cref="ISunVoxLib.LoadSamplerSample(int, int, byte[], int?)"/>
        public void LoadSamplerSample(byte[] data, int? sampleSlot = null)
        {
            _lib.LoadSamplerSample(_slotId, Id, data, sampleSlot);
        }

        /// <inheritdoc cref="ISunVoxLib.LoadIntoMetaModule(int, int, string)"/>
        public void LoadIntoMetaModule(string path)
        {
            _lib.LoadIntoMetaModule(_slotId, Id, path);
        }

        /// <inheritdoc cref="ISunVoxLib.LoadIntoMetaModule(int, int, byte[])"/>
        public void LoadIntoMetaModule(byte[] data)
        {
            _lib.LoadIntoMetaModule(_slotId, Id, data);
        }

        /// <summary>
        /// Load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.LoadIntoVorbisPlayer(int, int, string)"/>
        public void LoadIntoVorbisPlayer(string path)
        {
            _lib.LoadIntoVorbisPlayer(_slotId, Id, path);
        }

        /// <summary>
        /// Load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        /// <inheritdoc cref="ISunVoxLib.LoadIntoVorbisPlayer(int, int, byte[])"/>
        public void LoadIntoVorbisPlayer(byte[] data)
        {
            _lib.LoadIntoVorbisPlayer(_slotId, Id, data);
        }

        /// <inheritdoc cref="ISunVoxLib.WriteModuleCurve"/>
        public int WriteCurve(int curveId, float[] buffer)
        {
            return _lib.WriteModuleCurve(_slotId, Id, curveId, buffer);
        }

        /// <inheritdoc cref="ISunVoxLib.ReadModuleCurve"/>
        public int ReadCurve(int curveId, float[] buffer)
        {
            return _lib.ReadModuleCurve(_slotId, Id, curveId, buffer);
        }

        #endregion specific data IO

        #region controllers

        /// <inheritdoc cref="ISunVoxLib.GetModuleControllerCount"/>
        public int GetControllerCount()
        {
            return _lib.GetModuleControllerCount(_slotId, Id);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleControllerName"/>
        public string? GetControllerName(int controllerId)
        {
            return _lib.GetModuleControllerName(_slotId, Id, controllerId);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleControllerValue"/>
        public int GetControllerValue(int controllerId, ValueScalingMode scaling = ValueScalingMode.Displayed)
        {
            return _lib.GetModuleControllerValue(_slotId, Id, controllerId, scaling);
        }

        /// <inheritdoc cref="ISunVoxLib.SetModuleControllerValue"/>
        public void SetControllerValue(int controller, int value, ValueScalingMode scaling = ValueScalingMode.Displayed)
        {
            _lib.SetModuleControllerValue(_slotId, Id, controller, value, scaling);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleControllerMinValue"/>
        public int GetControllerMinValue(int controllerId, ValueScalingMode scaling)
        {
            return _lib.GetModuleControllerMinValue(_slotId, Id, controllerId, scaling);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleControllerMaxValue"/>
        public int GetControllerMaxValue(int controllerId, ValueScalingMode scaling)
        {
            return _lib.GetModuleControllerMaxValue(_slotId, Id, controllerId, scaling);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleControllerOffset"/>
        public int GetControllerOffset(int controllerId)
        {
            return _lib.GetModuleControllerOffset(_slotId, Id, controllerId);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleControllerType"/>
        public ControllerType GetControllerType(int controllerId)
        {
            return _lib.GetModuleControllerType(_slotId, Id, controllerId);
        }

        /// <inheritdoc cref="ISunVoxLib.GetModuleControllerGroup"/>
        public int GetControllerGroup(int controllerId)
        {
            return _lib.GetModuleControllerGroup(_slotId, Id, controllerId);
        }

        #endregion controllers

        /// <inheritdoc cref="PatternEvent.ControllerEvent(int, byte, ushort)"/>
        public PatternEvent MakeSetControllerValueEvent(byte controllerId, ushort value)
        {
            return PatternEvent.ControllerEvent(Id, controllerId, value);
        }

        /// <inheritdoc cref="PatternEvent.NoteEvent(Note, int?, byte?)"/>
        public PatternEvent MakeNoteEvent(Note note, byte? velocity = null)
        {
            return PatternEvent.NoteEvent(note, Id, velocity);
        }

        /// <inheritdoc cref="PatternEvent.SetPitchEvent(int, ushort, byte?)"/>
        public PatternEvent MakeSetPitchEvent(ushort pitch, byte? velocity = null)
        {
            return PatternEvent.SetPitchEvent(Id, pitch, velocity);
        }

        /// <inheritdoc cref="PatternEvent.SetFrequencyEvent(int, double, byte?)"/>
        public PatternEvent MakeSetFrequencyEvent(double frequency, byte? velocity = null)
        {
            return PatternEvent.SetFrequencyEvent(Id, frequency, velocity);
        }

        /// <inheritdoc cref="PatternEvent.NewEvent(Note, byte?, int?, byte?, Effect, ushort)"/>
        public PatternEvent MakeEvent(Note note = default, byte? velocity = null, byte? controller = null, Effect effect = Effect.None, ushort value = 0)
        {
            return PatternEvent.NewEvent(note, velocity, Id, controller, effect, value);
        }
    }
}
