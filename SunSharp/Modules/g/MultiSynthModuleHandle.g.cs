/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// This module sends the incoming events (notes, pitch change, phase change) to any number of connected modules (receivers).
    /// </summary>
    public partial interface IMultiSynthModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 0 'Transpose'
        /// </summary>
        int GetTranspose(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 0 'Transpose'
        /// </summary>
        void SetTranspose(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-4096
        /// Original name: 1 'Random pitch'
        /// </summary>
        int GetRandomPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-4096
        /// Original name: 1 'Random pitch'
        /// </summary>
        void SetRandomPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Velocity'
        /// </summary>
        int GetVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Velocity'
        /// </summary>
        void SetVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -256-256, real: 0-512
        /// Original name: 3 'Finetune'
        /// </summary>
        int GetFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -256-256, real: 0-512
        /// Original name: 3 'Finetune'
        /// </summary>
        void SetFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 4 'Random phase'
        /// </summary>
        int GetRandomPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 4 'Random phase'
        /// </summary>
        void SetRandomPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 5 'Random velocity'
        /// </summary>
        int GetRandomVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 5 'Random velocity'
        /// </summary>
        void SetRandomVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 6 'Phase'
        /// </summary>
        int GetPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 6 'Phase'
        /// </summary>
        void SetPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 7 'Curve2 influence'
        /// </summary>
        int GetCurve2Influence(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 7 'Curve2 influence'
        /// </summary>
        void SetCurve2Influence(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Velocity to apply to arriving note.
        /// <br>
        /// <br> Write to curve 0 of MultiSynth.
        /// <br> The curve contains 128 values in range of 0 to 1.
        /// </summary>
        int WriteCurveNoteToVelocity(float[] buffer);

        /// <summary>
        /// Velocity to apply to arriving note.
        /// <br>
        /// <br> Read from curve 0 of MultiSynth.
        /// <br> The curve contains 128 values in range of 0 to 1.
        /// </summary>
        int ReadCurveNoteToVelocity(float[] buffer);

        /// <summary>
        /// Map velocity values.
        /// <br>
        /// <br> Write to curve 1 of MultiSynth.
        /// <br> The curve contains 257 values in range of 0 to 1.
        /// </summary>
        int WriteCurveVelocityToVelocity(float[] buffer);

        /// <summary>
        /// Map velocity values.
        /// <br>
        /// <br> Read from curve 1 of MultiSynth.
        /// <br> The curve contains 257 values in range of 0 to 1.
        /// </summary>
        int ReadCurveVelocityToVelocity(float[] buffer);

        /// <summary>
        /// Map incoming note to a pitch value.
        /// <br>
        /// <br> Write to curve 2 of MultiSynth.
        /// <br> The curve contains 128 values in range of 0.2500038 to 0.74610513.
        /// </summary>
        int WriteCurveNoteToPitch(float[] buffer);

        /// <summary>
        /// Map incoming note to a pitch value.
        /// <br>
        /// <br> Read from curve 2 of MultiSynth.
        /// <br> The curve contains 128 values in range of 0.2500038 to 0.74610513.
        /// </summary>
        int ReadCurveNoteToPitch(float[] buffer);
    }

    /// <inheritdoc cref="IMultiSynthModuleHandle"/>
    public readonly partial struct MultiSynthModuleHandle : IMultiSynthModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public MultiSynthModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(MultiSynthModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.MultiSynth;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.MultiSynth;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        #region IGenericSynthModuleHandle implementation

        public int Id => ModuleHandle.Id;

        public ISlot Slot => ModuleHandle.Slot;

        /// <inheritdoc/>
        public ModuleFlags GetFlags() => ModuleHandle.GetFlags();

        /// <inheritdoc/>
        public SynthModuleType? GetModuleType() => ModuleHandle.GetModuleType();

        /// <inheritdoc/>
        public bool GetExists() => ModuleHandle.GetExists();

        /// <inheritdoc/>
        public FineTunePair GetFineTune() => ModuleHandle.GetFineTune();

        /// <inheritdoc/>
        public void SetFineTune(FineTunePair fineTune) => ModuleHandle.SetFineTune(fineTune);

        /// <inheritdoc/>
        public int ReadScope(AudioChannel channel, short[] buffer) => ModuleHandle.ReadScope(channel, buffer);

        /// <inheritdoc/>
        public string? GetName() => ModuleHandle.GetName();

        /// <inheritdoc/>
        public void SetName(string name) => ModuleHandle.SetName(name);

        /// <inheritdoc/>
        public (int, int) GetPosition() => ModuleHandle.GetPosition();

        /// <inheritdoc/>
        public void SetPosition(int x, int y) => ModuleHandle.SetPosition(x, y);

        /// <inheritdoc/>
        public (byte, byte, byte) GetColor() => ModuleHandle.GetColor();

        /// <inheritdoc/>
        public void SetColor(byte r, byte g, byte b) => ModuleHandle.SetColor(r, g, b);

        /// <inheritdoc/>
        public int[] GetInputs() => ModuleHandle.GetInputs();

        /// <inheritdoc/>
        ISynthModuleHandle[] IGenericSynthModuleHandle.GetInputModules() => (ModuleHandle as IGenericSynthModuleHandle).GetInputModules();

        /// <inheritdoc/>
        public int[] GetOutputs() => ModuleHandle.GetOutputs();

        /// <inheritdoc/>
        ISynthModuleHandle[] IGenericSynthModuleHandle.GetOutputModules() => (ModuleHandle as IGenericSynthModuleHandle).GetOutputModules();

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectInput(int targetModuleId) => ModuleHandle.ConnectInput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectInput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).ConnectInput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectOutput(int targetModuleId) => ModuleHandle.ConnectOutput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectOutput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).ConnectOutput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectInput(int targetModuleId) => ModuleHandle.DisconnectInput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectInput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).DisconnectInput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectOutput(int targetModuleId) => ModuleHandle.DisconnectOutput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectOutput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).DisconnectOutput(targetModule);

        /// <inheritdoc/>
        public PatternEvent MakeSetControllerValueEvent(byte controllerId, ushort value) => ModuleHandle.MakeSetControllerValueEvent(controllerId, value);

        /// <inheritdoc/>
        public PatternEvent MakeNoteEvent(Note note, byte? velocity = default) => ModuleHandle.MakeNoteEvent(note, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeSetPitchEvent(ushort pitch, byte? velocity = default) => ModuleHandle.MakeSetPitchEvent(pitch, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeSetFrequencyEvent(double frequency, byte? velocity = default) => ModuleHandle.MakeSetFrequencyEvent(frequency, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeEvent(Note note = default, byte? velocity = default, byte? controller = default, Effect effect = Effect.None, ushort value = 0) => ModuleHandle.MakeEvent(note, velocity, controller, effect, value);

        /// <inheritdoc cref="SynthModuleHandle.GetInputModules"/>
        public SynthModuleHandle[] GetInputModules() => ModuleHandle.GetInputModules();

        /// <inheritdoc cref="SynthModuleHandle.GetOutputModules"/>
        public SynthModuleHandle[] GetOutputModules() => ModuleHandle.GetOutputModules();

        /// <inheritdoc cref="SynthModuleHandle.ConnectInput"/>
        public void ConnectInput(SynthModuleHandle targetModule) => ModuleHandle.ConnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.ConnectOutput"/>
        public void ConnectOutput(SynthModuleHandle targetModule) => ModuleHandle.ConnectOutput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectInput"/>
        public void DisconnectInput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectOutput"/>
        public void DisconnectOutput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectOutput(targetModule);

        #endregion

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetTranspose" />
        public int GetTranspose(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetTranspose" />
        public void SetTranspose(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetRandomPitch" />
        public int GetRandomPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetRandomPitch" />
        public void SetRandomPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetVelocity" />
        public int GetVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetVelocity" />
        public void SetVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetFinetune" />
        public int GetFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetFinetune" />
        public void SetFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetRandomPhase" />
        public int GetRandomPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetRandomPhase" />
        public void SetRandomPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetRandomVelocity" />
        public int GetRandomVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetRandomVelocity" />
        public void SetRandomVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetPhase" />
        public int GetPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetPhase" />
        public void SetPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetCurve2Influence" />
        public int GetCurve2Influence(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetCurve2Influence" />
        public void SetCurve2Influence(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.ReadCurveNoteToVelocity"
        public int ReadCurveNoteToVelocity(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.WriteCurveNoteToVelocity"
        public int WriteCurveNoteToVelocity(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.ReadCurveVelocityToVelocity"
        public int ReadCurveVelocityToVelocity(float[] buffer) => ModuleHandle.ReadCurve(1, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.WriteCurveVelocityToVelocity"
        public int WriteCurveVelocityToVelocity(float[] buffer) => ModuleHandle.WriteCurve(1, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.ReadCurveNoteToPitch"
        public int ReadCurveNoteToPitch(float[] buffer) => ModuleHandle.ReadCurve(2, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.WriteCurveNoteToPitch"
        public int WriteCurveNoteToPitch(float[] buffer) => ModuleHandle.WriteCurve(2, buffer);
    }
}
#endif
