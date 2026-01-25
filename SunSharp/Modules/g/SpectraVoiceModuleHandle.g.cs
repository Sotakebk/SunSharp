/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// SpectraVoice synthesizes sound with a complex spectrum. You can place 16 harmonics on the spectrum graph, specifying the position, amplitude, shape and width for each.
    /// </summary>
    public partial interface ISpectraVoiceModuleHandle : ITypedModuleHandle
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
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 1 'Panning'
        /// </summary>
        int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 1 'Panning'
        /// </summary>
        void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 2 'Attack'
        /// </summary>
        int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 2 'Attack'
        /// </summary>
        void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 3 'Release'
        /// </summary>
        int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 3 'Release'
        /// </summary>
        void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32
        /// Original name: 4 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32
        /// Original name: 4 'Polyphony'
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Mode'
        /// </summary>
        SpectraVoiceMode GetMode();

        /// <summary>
        /// Original name: 5 'Mode'
        /// </summary>
        void SetMode(SpectraVoiceMode value);

        /// <summary>
        /// Original name: 6 'Sustain'
        /// </summary>
        Toggle GetSustain();

        /// <summary>
        /// Original name: 6 'Sustain'
        /// </summary>
        void SetSustain(Toggle value);

        /// <summary>
        /// Original name: 7 'Spectrum resolution'
        /// </summary>
        SpectraVoiceResolution GetSpectrumResolution();

        /// <summary>
        /// Original name: 7 'Spectrum resolution'
        /// </summary>
        void SetSpectrumResolution(SpectraVoiceResolution value);

        /// <summary>
        /// Value range: 0-15
        /// Original name: 8 'Harmonic'
        /// </summary>
        int GetHarmonic(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-15
        /// Original name: 8 'Harmonic'
        /// </summary>
        void SetHarmonic(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-22050
        /// Original name: 9 'H.freq'
        /// </summary>
        int GetHFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-22050
        /// Original name: 9 'H.freq'
        /// </summary>
        void SetHFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-255
        /// Original name: 10 'H.volume'
        /// </summary>
        int GetHVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-255
        /// Original name: 10 'H.volume'
        /// </summary>
        void SetHVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-255
        /// Original name: 11 'H.width'
        /// </summary>
        int GetHWidth(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-255
        /// Original name: 11 'H.width'
        /// </summary>
        void SetHWidth(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 12 'H.type'
        /// </summary>
        SpectraVoiceHarmonicType GetHType();

        /// <summary>
        /// Original name: 12 'H.type'
        /// </summary>
        void SetHType(SpectraVoiceHarmonicType value);
    }

    /// <inheritdoc cref="ISpectraVoiceModuleHandle"/>
    public readonly partial struct SpectraVoiceModuleHandle : ISpectraVoiceModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public SpectraVoiceModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(SpectraVoiceModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.SpectraVoice;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.SpectraVoice;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetPanning" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetPanning" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetAttack" />
        public int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetAttack" />
        public void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetRelease" />
        public int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetRelease" />
        public void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetPolyphony" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetPolyphony" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetMode" />
        public SpectraVoiceMode GetMode() => (SpectraVoiceMode)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetMode" />
        public void SetMode(SpectraVoiceMode value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetSustain" />
        public Toggle GetSustain() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetSustain" />
        public void SetSustain(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetSpectrumResolution" />
        public SpectraVoiceResolution GetSpectrumResolution() => (SpectraVoiceResolution)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetSpectrumResolution" />
        public void SetSpectrumResolution(SpectraVoiceResolution value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetHarmonic" />
        public int GetHarmonic(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetHarmonic" />
        public void SetHarmonic(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetHFreq" />
        public int GetHFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetHFreq" />
        public void SetHFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetHVolume" />
        public int GetHVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetHVolume" />
        public void SetHVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetHWidth" />
        public int GetHWidth(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(11, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetHWidth" />
        public void SetHWidth(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(11, value, valueScalingMode);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.GetHType" />
        public SpectraVoiceHarmonicType GetHType() => (SpectraVoiceHarmonicType)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISpectraVoiceModuleHandle.SetHType" />
        public void SetHType(SpectraVoiceHarmonicType value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
