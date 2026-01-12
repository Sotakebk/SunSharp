/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// LFO - Low Frequency Oscillator. Can work as amplitude/balance modulator or as standalone generator.
    /// </summary>
    public partial interface ILfoModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-512
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 0 'Volume'
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 'Type'
        /// </summary>
        LfoType GetFilterType();

        /// <summary>
        /// Original name: 1 'Type'
        /// </summary>
        void SetFilterType(LfoType value);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Amplitude'
        /// </summary>
        int GetAmplitude(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Amplitude'
        /// </summary>
        void SetAmplitude(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-256
        /// Original name: 3 'Freq'
        /// </summary>
        int GetFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-256
        /// Original name: 3 'Freq'
        /// </summary>
        void SetFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 'Waveform'
        /// </summary>
        LfoWaveform GetWaveform();

        /// <summary>
        /// Original name: 4 'Waveform'
        /// </summary>
        void SetWaveform(LfoWaveform value);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 5 'Set phase'
        /// </summary>
        int GetSetPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 5 'Set phase'
        /// </summary>
        void SetSetPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 6 'Channels'
        /// </summary>
        Channels GetChannels();

        /// <summary>
        /// Original name: 6 'Channels'
        /// </summary>
        void SetChannels(Channels value);

        /// <summary>
        /// Original name: 7 'Frequency unit'
        /// </summary>
        LfoFrequencyUnit GetFrequencyUnit();

        /// <summary>
        /// Original name: 7 'Frequency unit'
        /// </summary>
        void SetFrequencyUnit(LfoFrequencyUnit value);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 8 'Duty cycle'
        /// </summary>
        int GetDutyCycle(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 8 'Duty cycle'
        /// </summary>
        void SetDutyCycle(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 9 'Generator'
        /// </summary>
        Toggle GetGenerator();

        /// <summary>
        /// Original name: 9 'Generator'
        /// </summary>
        void SetGenerator(Toggle value);

        /// <summary>
        /// Value range: 0-200
        /// Original name: 10 'Freq scale'
        /// </summary>
        int GetFreqScale(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-200
        /// Original name: 10 'Freq scale'
        /// </summary>
        void SetFreqScale(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 11 'Smooth transitions'
        /// </summary>
        LfoSmoothTransitions GetSmoothTransitions();

        /// <summary>
        /// Original name: 11 'Smooth transitions'
        /// </summary>
        void SetSmoothTransitions(LfoSmoothTransitions value);

        /// <summary>
        /// Original name: 12 'Sine quality'
        /// </summary>
        LfoSineQuality GetSineQuality();

        /// <summary>
        /// Original name: 12 'Sine quality'
        /// </summary>
        void SetSineQuality(LfoSineQuality value);
    }

    /// <inheritdoc cref="ILfoModuleHandle"/>
    public readonly partial struct LfoModuleHandle : ILfoModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public LfoModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(LfoModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Lfo;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Lfo;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="ILfoModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.GetFilterType" />
        public LfoType GetFilterType() => (LfoType)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.SetFilterType" />
        public void SetFilterType(LfoType value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.GetAmplitude" />
        public int GetAmplitude(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.SetAmplitude" />
        public void SetAmplitude(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.GetFreq" />
        public int GetFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.SetFreq" />
        public void SetFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.GetWaveform" />
        public LfoWaveform GetWaveform() => (LfoWaveform)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.SetWaveform" />
        public void SetWaveform(LfoWaveform value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.GetSetPhase" />
        public int GetSetPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.SetSetPhase" />
        public void SetSetPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.GetChannels" />
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.SetChannels" />
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.GetFrequencyUnit" />
        public LfoFrequencyUnit GetFrequencyUnit() => (LfoFrequencyUnit)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.SetFrequencyUnit" />
        public void SetFrequencyUnit(LfoFrequencyUnit value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.GetDutyCycle" />
        public int GetDutyCycle(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.SetDutyCycle" />
        public void SetDutyCycle(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.GetGenerator" />
        public Toggle GetGenerator() => (Toggle)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.SetGenerator" />
        public void SetGenerator(Toggle value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.GetFreqScale" />
        public int GetFreqScale(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.SetFreqScale" />
        public void SetFreqScale(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="ILfoModuleHandle.GetSmoothTransitions" />
        public LfoSmoothTransitions GetSmoothTransitions() => (LfoSmoothTransitions)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.SetSmoothTransitions" />
        public void SetSmoothTransitions(LfoSmoothTransitions value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.GetSineQuality" />
        public LfoSineQuality GetSineQuality() => (LfoSineQuality)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILfoModuleHandle.SetSineQuality" />
        public void SetSineQuality(LfoSineQuality value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
