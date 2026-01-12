/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Formant filter - designed to simulate the human vocal tract.
    /// </summary>
    public partial interface IVocalFilterModuleHandle : ITypedModuleHandle
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
        /// Value range: 0-256
        /// Original name: 1 'Formant width'
        /// </summary>
        int GetFormantWidth(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Formant width'
        /// </summary>
        void SetFormantWidth(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Intensity'
        /// </summary>
        int GetIntensity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Intensity'
        /// </summary>
        void SetIntensity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-5
        /// Original name: 3 'Formants'
        /// </summary>
        int GetFormants(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-5
        /// Original name: 3 'Formants'
        /// </summary>
        void SetFormants(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'Vowel (a,e,i,o,u)'
        /// </summary>
        int GetVowelAEIOU(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'Vowel (a,e,i,o,u)'
        /// </summary>
        void SetVowelAEIOU(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Voice type'
        /// </summary>
        VocalFilterVoiceType GetVoiceType();

        /// <summary>
        /// Original name: 5 'Voice type'
        /// </summary>
        void SetVoiceType(VocalFilterVoiceType value);

        /// <summary>
        /// Original name: 6 'Channels'
        /// </summary>
        Channels GetChannels();

        /// <summary>
        /// Original name: 6 'Channels'
        /// </summary>
        void SetChannels(Channels value);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 7 'Random frequency'
        /// </summary>
        int GetRandomFrequency(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 7 'Random frequency'
        /// </summary>
        void SetRandomFrequency(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 8 'Random seed'
        /// </summary>
        int GetRandomSeed(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 8 'Random seed'
        /// </summary>
        void SetRandomSeed(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 9 'Vowel1'
        /// </summary>
        VocalFilterVowel GetVowel1();

        /// <summary>
        /// Original name: 9 'Vowel1'
        /// </summary>
        void SetVowel1(VocalFilterVowel value);

        /// <summary>
        /// Original name: 10 'Vowel2'
        /// </summary>
        VocalFilterVowel GetVowel2();

        /// <summary>
        /// Original name: 10 'Vowel2'
        /// </summary>
        void SetVowel2(VocalFilterVowel value);

        /// <summary>
        /// Original name: 11 'Vowel3'
        /// </summary>
        VocalFilterVowel GetVowel3();

        /// <summary>
        /// Original name: 11 'Vowel3'
        /// </summary>
        void SetVowel3(VocalFilterVowel value);

        /// <summary>
        /// Original name: 12 'Vowel4'
        /// </summary>
        VocalFilterVowel GetVowel4();

        /// <summary>
        /// Original name: 12 'Vowel4'
        /// </summary>
        void SetVowel4(VocalFilterVowel value);

        /// <summary>
        /// Original name: 13 'Vowel5'
        /// </summary>
        VocalFilterVowel GetVowel5();

        /// <summary>
        /// Original name: 13 'Vowel5'
        /// </summary>
        void SetVowel5(VocalFilterVowel value);
    }

    /// <inheritdoc cref="IVocalFilterModuleHandle"/>
    public readonly partial struct VocalFilterModuleHandle : IVocalFilterModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public VocalFilterModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(VocalFilterModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.VocalFilter;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.VocalFilter;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetFormantWidth" />
        public int GetFormantWidth(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetFormantWidth" />
        public void SetFormantWidth(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetIntensity" />
        public int GetIntensity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetIntensity" />
        public void SetIntensity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetFormants" />
        public int GetFormants(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetFormants" />
        public void SetFormants(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetVowelAEIOU" />
        public int GetVowelAEIOU(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetVowelAEIOU" />
        public void SetVowelAEIOU(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetVoiceType" />
        public VocalFilterVoiceType GetVoiceType() => (VocalFilterVoiceType)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetVoiceType" />
        public void SetVoiceType(VocalFilterVoiceType value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetChannels" />
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetChannels" />
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetRandomFrequency" />
        public int GetRandomFrequency(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetRandomFrequency" />
        public void SetRandomFrequency(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetRandomSeed" />
        public int GetRandomSeed(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetRandomSeed" />
        public void SetRandomSeed(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetVowel1" />
        public VocalFilterVowel GetVowel1() => (VocalFilterVowel)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetVowel1" />
        public void SetVowel1(VocalFilterVowel value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetVowel2" />
        public VocalFilterVowel GetVowel2() => (VocalFilterVowel)ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetVowel2" />
        public void SetVowel2(VocalFilterVowel value) => ModuleHandle.SetControllerValue(10, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetVowel3" />
        public VocalFilterVowel GetVowel3() => (VocalFilterVowel)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetVowel3" />
        public void SetVowel3(VocalFilterVowel value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetVowel4" />
        public VocalFilterVowel GetVowel4() => (VocalFilterVowel)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetVowel4" />
        public void SetVowel4(VocalFilterVowel value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.GetVowel5" />
        public VocalFilterVowel GetVowel5() => (VocalFilterVowel)ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IVocalFilterModuleHandle.SetVowel5" />
        public void SetVowel5(VocalFilterVowel value) => ModuleHandle.SetControllerValue(13, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
