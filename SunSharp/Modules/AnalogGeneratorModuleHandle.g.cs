/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Generator with 32 double alias-free oscillators, 12/24dB filters, envelopes, and smooth change of parameters. The sound quality of this module is better at a sample rate of 44100Hz.
    /// </summary>
    public partial interface IAnalogGeneratorModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-256
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 0 'Volume'
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 'Waveform'
        /// </summary>
        AnalogGeneratorWaveform GetWaveform();

        /// <summary>
        /// Original name: 1 'Waveform'
        /// </summary>
        void SetWaveform(AnalogGeneratorWaveform value);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 2 'Panning'
        /// </summary>
        int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 2 'Panning'
        /// </summary>
        void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 3 'Attack'
        /// </summary>
        int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 3 'Attack'
        /// </summary>
        void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'Release'
        /// </summary>
        int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'Release'
        /// </summary>
        void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Sustain'
        /// </summary>
        Toggle GetSustain();

        /// <summary>
        /// Original name: 5 'Sustain'
        /// </summary>
        void SetSustain(Toggle value);

        /// <summary>
        /// Original name: 6 'Exponential envelope'
        /// </summary>
        Toggle GetExponentialEnvelope();

        /// <summary>
        /// Original name: 6 'Exponential envelope'
        /// </summary>
        void SetExponentialEnvelope(Toggle value);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 7 'Duty cycle'
        /// </summary>
        int GetDutyCycle(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 7 'Duty cycle'
        /// </summary>
        void SetDutyCycle(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Pitch deviation of the additional oscillator (off in the zero position).
        /// One semitone = 64.
        /// <br>
        /// Value range: displayed: -1000-1000, real: 0-2000
        /// Original name: 8 'Osc2'
        /// </summary>
        int GetSecondaryOscillatorPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Pitch deviation of the additional oscillator (off in the zero position).
        /// One semitone = 64.
        /// <br>
        /// Value range: displayed: -1000-1000, real: 0-2000
        /// Original name: 8 'Osc2'
        /// </summary>
        void SetSecondaryOscillatorPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 9 'Filter'
        /// </summary>
        AnalogGeneratorFilterType GetFilter();

        /// <summary>
        /// Original name: 9 'Filter'
        /// </summary>
        void SetFilter(AnalogGeneratorFilterType value);

        /// <summary>
        /// Value range: 0-14000
        /// Original name: 10 'F.freq'
        /// </summary>
        int GetFilterFrequency(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-14000
        /// Original name: 10 'F.freq'
        /// </summary>
        void SetFilterFrequency(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1530
        /// Original name: 11 'F.resonance'
        /// </summary>
        int GetFilterResonance(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1530
        /// Original name: 11 'F.resonance'
        /// </summary>
        void SetFilterResonance(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 12 'F.exponential freq'
        /// </summary>
        Toggle GetFilterExponentialFrequency();

        /// <summary>
        /// Original name: 12 'F.exponential freq'
        /// </summary>
        void SetFilterExponentialFrequency(Toggle value);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 13 'F.attack'
        /// </summary>
        int GetFilterAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 13 'F.attack'
        /// </summary>
        void SetFilterAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 14 'F.release'
        /// </summary>
        int GetFilterRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 14 'F.release'
        /// </summary>
        void SetFilterRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 15 'F.envelope'
        /// </summary>
        AnalogGeneratorEnvelopeMode GetFilterEnvelope();

        /// <summary>
        /// Original name: 15 'F.envelope'
        /// </summary>
        void SetFilterEnvelope(AnalogGeneratorEnvelopeMode value);

        /// <summary>
        /// Value range: 1-32
        /// Original name: 16 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32
        /// Original name: 16 'Polyphony'
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

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
        /// </summary>
        void SetMode(Quality value);

        /// <summary>
        /// Amount of white noise added to the signal.
        /// <br>
        /// Value range: 0-256
        /// Original name: 18 'Noise'
        /// </summary>
        int GetNoise(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Amount of white noise added to the signal.
        /// <br>
        /// Value range: 0-256
        /// Original name: 18 'Noise'
        /// </summary>
        void SetNoise(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 19 'Osc2 volume'
        /// </summary>
        int GetSecondaryOscillatorVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 19 'Osc2 volume'
        /// </summary>
        void SetSecondaryOscillatorVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 20 'Osc2 mode'
        /// </summary>
        AnalogGeneratorSecondaryOscillatorMode GetSecondaryOscillatorMode();

        /// <summary>
        /// Original name: 20 'Osc2 mode'
        /// </summary>
        void SetSecondaryOscillatorMode(AnalogGeneratorSecondaryOscillatorMode value);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 21 'Osc2 phase'
        /// </summary>
        int GetSecondaryOscillatorPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 21 'Osc2 phase'
        /// </summary>
        void SetSecondaryOscillatorPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

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

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetWaveform" />
        public AnalogGeneratorWaveform GetWaveform() => (AnalogGeneratorWaveform)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetWaveform" />
        public void SetWaveform(AnalogGeneratorWaveform value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetPanning" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetPanning" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetAttack" />
        public int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetAttack" />
        public void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetRelease" />
        public int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetRelease" />
        public void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSustain" />
        public Toggle GetSustain() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSustain" />
        public void SetSustain(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetExponentialEnvelope" />
        public Toggle GetExponentialEnvelope() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetExponentialEnvelope" />
        public void SetExponentialEnvelope(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetDutyCycle" />
        public int GetDutyCycle(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetDutyCycle" />
        public void SetDutyCycle(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSecondaryOscillatorPitch" />
        public int GetSecondaryOscillatorPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSecondaryOscillatorPitch" />
        public void SetSecondaryOscillatorPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilter" />
        public AnalogGeneratorFilterType GetFilter() => (AnalogGeneratorFilterType)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilter" />
        public void SetFilter(AnalogGeneratorFilterType value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterFrequency" />
        public int GetFilterFrequency(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterFrequency" />
        public void SetFilterFrequency(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterResonance" />
        public int GetFilterResonance(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(11, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterResonance" />
        public void SetFilterResonance(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(11, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterExponentialFrequency" />
        public Toggle GetFilterExponentialFrequency() => (Toggle)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterExponentialFrequency" />
        public void SetFilterExponentialFrequency(Toggle value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterAttack" />
        public int GetFilterAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(13, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterAttack" />
        public void SetFilterAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(13, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterRelease" />
        public int GetFilterRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(14, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterRelease" />
        public void SetFilterRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(14, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetFilterEnvelope" />
        public AnalogGeneratorEnvelopeMode GetFilterEnvelope() => (AnalogGeneratorEnvelopeMode)ModuleHandle.GetControllerValue(15, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetFilterEnvelope" />
        public void SetFilterEnvelope(AnalogGeneratorEnvelopeMode value) => ModuleHandle.SetControllerValue(15, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetPolyphony" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(16, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetPolyphony" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(16, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetMode" />
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(17, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetMode" />
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(17, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetNoise" />
        public int GetNoise(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(18, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetNoise" />
        public void SetNoise(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(18, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSecondaryOscillatorVolume" />
        public int GetSecondaryOscillatorVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(19, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSecondaryOscillatorVolume" />
        public void SetSecondaryOscillatorVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(19, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSecondaryOscillatorMode" />
        public AnalogGeneratorSecondaryOscillatorMode GetSecondaryOscillatorMode() => (AnalogGeneratorSecondaryOscillatorMode)ModuleHandle.GetControllerValue(20, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSecondaryOscillatorMode" />
        public void SetSecondaryOscillatorMode(AnalogGeneratorSecondaryOscillatorMode value) => ModuleHandle.SetControllerValue(20, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.GetSecondaryOscillatorPhase" />
        public int GetSecondaryOscillatorPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(21, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.SetSecondaryOscillatorPhase" />
        public void SetSecondaryOscillatorPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(21, value, valueScalingMode);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.ReadCurveSynth"
        public int ReadCurveSynth(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IAnalogGeneratorModuleHandle.WriteCurveSynth"
        public int WriteCurveSynth(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);
    }
}
#endif
