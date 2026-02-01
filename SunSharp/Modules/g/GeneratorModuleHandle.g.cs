/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// Basic generator of different types of periodic signal waveforms with the volume envelope. This module can receive the incoming signal and use it for the frequency modulation.
    /// </summary>
    public partial interface IGeneratorModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 0 'Volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeVolumeEvent(int value);

        /// <summary>
        /// Original name: 1 'Waveform'
        /// </summary>
        GeneratorWaveform GetWaveform();

        /// <summary>
        /// Original name: 1 'Waveform'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetWaveform(GeneratorWaveform value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeWaveformEvent(GeneratorWaveform value);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 2 'Panning'
        /// </summary>
        int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 2 'Panning'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-128 to 128) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakePanningEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 3 'Attack'
        /// </summary>
        int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 3 'Attack'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 512) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeAttackEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 4 'Release'
        /// </summary>
        int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 4 'Release'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 512) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeReleaseEvent(int value);

        /// <summary>
        /// Original name: 5 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Polyphony'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakePolyphonyEvent(int value);

        /// <summary>
        /// Original name: 6 'Mode'
        /// </summary>
        Channels GetMode();

        /// <summary>
        /// Original name: 6 'Mode'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetMode(Channels value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeModeEvent(Channels value);

        /// <summary>
        /// Original name: 7 'Sustain'
        /// </summary>
        Toggle GetSustain();

        /// <summary>
        /// Original name: 7 'Sustain'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSustain(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeSustainEvent(Toggle value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 8 'Freq.modulation by input'
        /// </summary>
        int GetFreqModulationByInput(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 8 'Freq.modulation by input'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFreqModulationByInput(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFreqModulationByInputEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 1022, real: 0 to 1022
        /// Original name: 9 'Duty cycle'
        /// </summary>
        int GetDutyCycle(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 1022, real: 0 to 1022
        /// Original name: 9 'Duty cycle'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetDutyCycle(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 1022) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeDutyCycleEvent(int value);

        /// <summary>
        /// Used for 'Drawn', 'DrawnSpline' and 'Harmonics' waveforms.
        /// <br>
        /// <br> Write to curve 0 of Generator.
        /// <br> The curve contains 32 values in range of -1 to 1.
        /// </summary>
        int WriteCurveSynth(float[] buffer);

        /// <summary>
        /// Used for 'Drawn', 'DrawnSpline' and 'Harmonics' waveforms.
        /// <br>
        /// <br> Read from curve 0 of Generator.
        /// <br> The curve contains 32 values in range of -1 to 1.
        /// </summary>
        int ReadCurveSynth(float[] buffer);
    }

    /// <inheritdoc cref="IGeneratorModuleHandle"/>
    public readonly partial struct GeneratorModuleHandle : IGeneratorModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public GeneratorModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(GeneratorModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Generator;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Generator;
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

        /// <inheritdoc cref="IGeneratorModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakeVolumeEvent" />
        public PatternEvent MakeVolumeEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetWaveform" />
        public GeneratorWaveform GetWaveform() => (GeneratorWaveform)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetWaveform" />
        public void SetWaveform(GeneratorWaveform value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakeWaveformEvent" />
        public PatternEvent MakeWaveformEvent(GeneratorWaveform value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetPanning" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetPanning" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakePanningEvent" />
        public PatternEvent MakePanningEvent(int value)
        {
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetAttack" />
        public int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetAttack" />
        public void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakeAttackEvent" />
        public PatternEvent MakeAttackEvent(int value)
        {
            value = value * 0x8000 / (512);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetRelease" />
        public int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetRelease" />
        public void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakeReleaseEvent" />
        public PatternEvent MakeReleaseEvent(int value)
        {
            value = value * 0x8000 / (512);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetPolyphony" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetPolyphony" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakePolyphonyEvent" />
        public PatternEvent MakePolyphonyEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetMode" />
        public Channels GetMode() => (Channels)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetMode" />
        public void SetMode(Channels value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakeModeEvent" />
        public PatternEvent MakeModeEvent(Channels value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetSustain" />
        public Toggle GetSustain() => (Toggle)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetSustain" />
        public void SetSustain(Toggle value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakeSustainEvent" />
        public PatternEvent MakeSustainEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetFreqModulationByInput" />
        public int GetFreqModulationByInput(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetFreqModulationByInput" />
        public void SetFreqModulationByInput(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakeFreqModulationByInputEvent" />
        public PatternEvent MakeFreqModulationByInputEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.GetDutyCycle" />
        public int GetDutyCycle(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.SetDutyCycle" />
        public void SetDutyCycle(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IGeneratorModuleHandle.MakeDutyCycleEvent" />
        public PatternEvent MakeDutyCycleEvent(int value)
        {
            value = value * 0x8000 / (1022);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 9, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGeneratorModuleHandle.ReadCurveSynth"
        public int ReadCurveSynth(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IGeneratorModuleHandle.WriteCurveSynth"
        public int WriteCurveSynth(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);
    }
}
#endif
