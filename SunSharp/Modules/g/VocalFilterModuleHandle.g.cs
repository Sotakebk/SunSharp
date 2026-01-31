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
