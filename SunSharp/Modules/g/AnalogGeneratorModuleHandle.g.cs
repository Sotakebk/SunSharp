/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// Generator with 32 double alias-free oscillators, 12/24dB filters, envelopes, and smooth change of parameters. The sound quality of this module is better at a sample rate of 44100Hz.
    /// </summary>
    public partial interface IAnalogGeneratorModuleHandle : ITypedModuleHandle
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
        AnalogGeneratorWaveform GetWaveform();

        /// <summary>
        /// Original name: 1 'Waveform'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetWaveform(AnalogGeneratorWaveform value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeWaveformEvent(AnalogGeneratorWaveform value);

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
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 3 'Attack'
        /// </summary>
        int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 3 'Attack'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeAttackEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 4 'Release'
        /// </summary>
        int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 4 'Release'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeReleaseEvent(int value);

        /// <summary>
        /// Original name: 5 'Sustain'
        /// </summary>
        Toggle GetSustain();

        /// <summary>
        /// Original name: 5 'Sustain'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSustain(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeSustainEvent(Toggle value);

        /// <summary>
        /// Original name: 6 'Exponential envelope'
        /// </summary>
        Toggle GetExponentialEnvelope();

        /// <summary>
        /// Original name: 6 'Exponential envelope'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetExponentialEnvelope(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeExponentialEnvelopeEvent(Toggle value);

        /// <summary>
        /// Value range: displayed: 0 to 1024, real: 0 to 1024
        /// Original name: 7 'Duty cycle'
        /// </summary>
        int GetDutyCycle(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 1024, real: 0 to 1024
        /// Original name: 7 'Duty cycle'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetDutyCycle(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 1024) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeDutyCycleEvent(int value);

        /// <summary>
        /// Pitch deviation of the additional oscillator (off in the zero position).
        /// One semitone = 64.
        /// <br>
        /// Value range: displayed: -1000 to 1000, real: 0 to 2000
        /// Original name: 8 'Osc2'
        /// </summary>
        int GetSecondaryOscillatorPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Pitch deviation of the additional oscillator (off in the zero position).
        /// One semitone = 64.
        /// <br>
        /// Value range: displayed: -1000 to 1000, real: 0 to 2000
        /// Original name: 8 'Osc2'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSecondaryOscillatorPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Pitch deviation of the additional oscillator (off in the zero position).
        /// One semitone = 64.
        /// <br>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-1000 to 1000) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSecondaryOscillatorPitchEvent(int value);

        /// <summary>
        /// Original name: 9 'Filter'
        /// </summary>
        AnalogGeneratorFilterType GetFilter();

        /// <summary>
        /// Original name: 9 'Filter'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFilter(AnalogGeneratorFilterType value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeFilterEvent(AnalogGeneratorFilterType value);

        /// <summary>
        /// Value range: displayed: 0 to 14000, real: 0 to 14000
        /// Original name: 10 'F.freq'
        /// </summary>
        int GetFilterFrequency(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 14000, real: 0 to 14000
        /// Original name: 10 'F.freq'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFilterFrequency(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 14000) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFilterFrequencyEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 1530, real: 0 to 1530
        /// Original name: 11 'F.resonance'
        /// </summary>
        int GetFilterResonance(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 1530, real: 0 to 1530
        /// Original name: 11 'F.resonance'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFilterResonance(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 1530) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFilterResonanceEvent(int value);

        /// <summary>
        /// Original name: 12 'F.exponential freq'
        /// </summary>
        Toggle GetFilterExponentialFrequency();

        /// <summary>
        /// Original name: 12 'F.exponential freq'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFilterExponentialFrequency(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeFilterExponentialFrequencyEvent(Toggle value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 13 'F.attack'
        /// </summary>
        int GetFilterAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 13 'F.attack'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFilterAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFilterAttackEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 14 'F.release'
        /// </summary>
        int GetFilterRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 14 'F.release'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFilterRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFilterReleaseEvent(int value);

        /// <summary>
        /// Original name: 15 'F.envelope'
        /// </summary>
        AnalogGeneratorEnvelopeMode GetFilterEnvelope();

        /// <summary>
        /// Original name: 15 'F.envelope'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFilterEnvelope(AnalogGeneratorEnvelopeMode value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeFilterEnvelopeEvent(AnalogGeneratorEnvelopeMode value);

        /// <summary>
        /// Original name: 16 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 16 'Polyphony'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakePolyphonyEvent(int value);

        /// <summary>
        /// Quality mode of the module.
        /// <br>
        /// Original name: 17 'Mode'
        /// </summary>
        Quality GetMode();

        /// <summary>
        /// Quality mode of the module.
        /// <br>
        /// Original name: 17 'Mode'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetMode(Quality value);

        /// <summary>
        /// Quality mode of the module.
        /// <br>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeModeEvent(Quality value);

        /// <summary>
        /// Amount of white noise added to the signal.
        /// <br>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 18 'Noise'
        /// </summary>
        int GetNoise(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Amount of white noise added to the signal.
        /// <br>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 18 'Noise'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetNoise(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Amount of white noise added to the signal.
        /// <br>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeNoiseEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 19 'Osc2 volume'
        /// </summary>
        int GetSecondaryOscillatorVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 19 'Osc2 volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSecondaryOscillatorVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSecondaryOscillatorVolumeEvent(int value);

        /// <summary>
        /// Original name: 20 'Osc2 mode'
        /// </summary>
        AnalogGeneratorSecondaryOscillatorMode GetSecondaryOscillatorMode();

        /// <summary>
        /// Original name: 20 'Osc2 mode'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSecondaryOscillatorMode(AnalogGeneratorSecondaryOscillatorMode value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeSecondaryOscillatorModeEvent(AnalogGeneratorSecondaryOscillatorMode value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 21 'Osc2 phase'
        /// </summary>
        int GetSecondaryOscillatorPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 21 'Osc2 phase'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSecondaryOscillatorPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSecondaryOscillatorPhaseEvent(int value);

        /// <summary>
        /// Used for 'Drawn', 'DrawnSpline' and 'Harmonics' waveforms.
        /// <br>
        /// <br> Write to curve 0 of AnalogGenerator.
        /// <br> The curve contains 32 values in range of -1 to 1.
        /// </summary>
        int WriteCurveSynth(float[] buffer);

        /// <summary>
        /// Used for 'Drawn', 'DrawnSpline' and 'Harmonics' waveforms.
        /// <br>
        /// <br> Read from curve 0 of AnalogGenerator.
        /// <br> The curve contains 32 values in range of -1 to 1.
        /// </summary>
        int ReadCurveSynth(float[] buffer);
    }

    /// <inheritdoc cref="IAnalogGeneratorModuleHandle"/>
    public readonly partial struct AnalogGeneratorModuleHandle : IAnalogGeneratorModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public AnalogGeneratorModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(AnalogGeneratorModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.AnalogGenerator;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.AnalogGenerator;
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

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeVolumeEvent" />
        public PatternEvent MakeVolumeEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetWaveform" />
        public AnalogGeneratorWaveform GetWaveform() => (AnalogGeneratorWaveform)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetWaveform" />
        public void SetWaveform(AnalogGeneratorWaveform value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeWaveformEvent" />
        public PatternEvent MakeWaveformEvent(AnalogGeneratorWaveform value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetPanning" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetPanning" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakePanningEvent" />
        public PatternEvent MakePanningEvent(int value)
        {
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetAttack" />
        public int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetAttack" />
        public void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeAttackEvent" />
        public PatternEvent MakeAttackEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetRelease" />
        public int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetRelease" />
        public void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeReleaseEvent" />
        public PatternEvent MakeReleaseEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSustain" />
        public Toggle GetSustain() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSustain" />
        public void SetSustain(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeSustainEvent" />
        public PatternEvent MakeSustainEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetExponentialEnvelope" />
        public Toggle GetExponentialEnvelope() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetExponentialEnvelope" />
        public void SetExponentialEnvelope(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeExponentialEnvelopeEvent" />
        public PatternEvent MakeExponentialEnvelopeEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetDutyCycle" />
        public int GetDutyCycle(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetDutyCycle" />
        public void SetDutyCycle(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeDutyCycleEvent" />
        public PatternEvent MakeDutyCycleEvent(int value)
        {
            value = value * 0x8000 / (1024);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSecondaryOscillatorPitch" />
        public int GetSecondaryOscillatorPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSecondaryOscillatorPitch" />
        public void SetSecondaryOscillatorPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeSecondaryOscillatorPitchEvent" />
        public PatternEvent MakeSecondaryOscillatorPitchEvent(int value)
        {
            value -= -1000;
            value = value * 0x8000 / (2000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilter" />
        public AnalogGeneratorFilterType GetFilter() => (AnalogGeneratorFilterType)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilter" />
        public void SetFilter(AnalogGeneratorFilterType value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeFilterEvent" />
        public PatternEvent MakeFilterEvent(AnalogGeneratorFilterType value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 9, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterFrequency" />
        public int GetFilterFrequency(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterFrequency" />
        public void SetFilterFrequency(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeFilterFrequencyEvent" />
        public PatternEvent MakeFilterFrequencyEvent(int value)
        {
            value = value * 0x8000 / (14000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 10, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterResonance" />
        public int GetFilterResonance(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(11, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterResonance" />
        public void SetFilterResonance(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(11, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeFilterResonanceEvent" />
        public PatternEvent MakeFilterResonanceEvent(int value)
        {
            value = value * 0x8000 / (1530);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 11, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterExponentialFrequency" />
        public Toggle GetFilterExponentialFrequency() => (Toggle)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterExponentialFrequency" />
        public void SetFilterExponentialFrequency(Toggle value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeFilterExponentialFrequencyEvent" />
        public PatternEvent MakeFilterExponentialFrequencyEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 12, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterAttack" />
        public int GetFilterAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(13, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterAttack" />
        public void SetFilterAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(13, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeFilterAttackEvent" />
        public PatternEvent MakeFilterAttackEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 13, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterRelease" />
        public int GetFilterRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(14, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterRelease" />
        public void SetFilterRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(14, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeFilterReleaseEvent" />
        public PatternEvent MakeFilterReleaseEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 14, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterEnvelope" />
        public AnalogGeneratorEnvelopeMode GetFilterEnvelope() => (AnalogGeneratorEnvelopeMode)ModuleHandle.GetControllerValue(15, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterEnvelope" />
        public void SetFilterEnvelope(AnalogGeneratorEnvelopeMode value) => ModuleHandle.SetControllerValue(15, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeFilterEnvelopeEvent" />
        public PatternEvent MakeFilterEnvelopeEvent(AnalogGeneratorEnvelopeMode value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 15, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetPolyphony" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(16, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetPolyphony" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(16, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakePolyphonyEvent" />
        public PatternEvent MakePolyphonyEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 16, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetMode" />
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(17, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetMode" />
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(17, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeModeEvent" />
        public PatternEvent MakeModeEvent(Quality value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 17, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetNoise" />
        public int GetNoise(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(18, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetNoise" />
        public void SetNoise(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(18, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeNoiseEvent" />
        public PatternEvent MakeNoiseEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 18, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSecondaryOscillatorVolume" />
        public int GetSecondaryOscillatorVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(19, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSecondaryOscillatorVolume" />
        public void SetSecondaryOscillatorVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(19, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeSecondaryOscillatorVolumeEvent" />
        public PatternEvent MakeSecondaryOscillatorVolumeEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 19, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSecondaryOscillatorMode" />
        public AnalogGeneratorSecondaryOscillatorMode GetSecondaryOscillatorMode() => (AnalogGeneratorSecondaryOscillatorMode)ModuleHandle.GetControllerValue(20, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSecondaryOscillatorMode" />
        public void SetSecondaryOscillatorMode(AnalogGeneratorSecondaryOscillatorMode value) => ModuleHandle.SetControllerValue(20, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeSecondaryOscillatorModeEvent" />
        public PatternEvent MakeSecondaryOscillatorModeEvent(AnalogGeneratorSecondaryOscillatorMode value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 20, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSecondaryOscillatorPhase" />
        public int GetSecondaryOscillatorPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(21, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSecondaryOscillatorPhase" />
        public void SetSecondaryOscillatorPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(21, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.MakeSecondaryOscillatorPhaseEvent" />
        public PatternEvent MakeSecondaryOscillatorPhaseEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 21, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.ReadCurveSynth"
        public int ReadCurveSynth(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.WriteCurveSynth"
        public int WriteCurveSynth(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);
    }
}
#endif
