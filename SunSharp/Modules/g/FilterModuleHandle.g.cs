/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// IIR Filter that can remove some unwanted frequency ranges.
    /// </summary>
    public partial interface IFilterModuleHandle : ITypedModuleHandle
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
        /// Value range: 0-14000
        /// Original name: 1 'Freq'
        /// </summary>
        int GetFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-14000
        /// Original name: 1 'Freq'
        /// </summary>
        void SetFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1530
        /// Original name: 2 'Resonance'
        /// </summary>
        int GetResonance(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1530
        /// Original name: 2 'Resonance'
        /// </summary>
        void SetResonance(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 'Type'
        /// </summary>
        FilterType GetFilterType();

        /// <summary>
        /// Original name: 3 'Type'
        /// </summary>
        void SetFilterType(FilterType value);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'Response'
        /// </summary>
        int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'Response'
        /// </summary>
        void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Mode'
        /// </summary>
        Quality GetMode();

        /// <summary>
        /// Original name: 5 'Mode'
        /// </summary>
        void SetMode(Quality value);

        /// <summary>
        /// Value range: 0-14000
        /// Original name: 6 'Impulse'
        /// </summary>
        int GetImpulse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-14000
        /// Original name: 6 'Impulse'
        /// </summary>
        void SetImpulse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 7 'Mix'
        /// </summary>
        int GetMix(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 7 'Mix'
        /// </summary>
        void SetMix(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 8 'LFO freq'
        /// </summary>
        int GetLfoFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 8 'LFO freq'
        /// </summary>
        void SetLfoFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 9 'LFO amp'
        /// </summary>
        int GetLfoAmp(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 9 'LFO amp'
        /// </summary>
        void SetLfoAmp(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 10 'Set LFO phase'
        /// </summary>
        int GetSetLfoPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 10 'Set LFO phase'
        /// </summary>
        void SetSetLfoPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 11 'Exponential freq'
        /// </summary>
        Toggle GetExponentialFreq();

        /// <summary>
        /// Original name: 11 'Exponential freq'
        /// </summary>
        void SetExponentialFreq(Toggle value);

        /// <summary>
        /// Original name: 12 'Roll-off'
        /// </summary>
        FilterRollOff GetRollOff();

        /// <summary>
        /// Original name: 12 'Roll-off'
        /// </summary>
        void SetRollOff(FilterRollOff value);

        /// <summary>
        /// Original name: 13 'LFO freq unit'
        /// </summary>
        FilterLfoFrequencyUnit GetLfoFreqUnit();

        /// <summary>
        /// Original name: 13 'LFO freq unit'
        /// </summary>
        void SetLfoFreqUnit(FilterLfoFrequencyUnit value);

        /// <summary>
        /// Original name: 14 'LFO waveform'
        /// </summary>
        FilterLfoWaveform GetLfoWaveform();

        /// <summary>
        /// Original name: 14 'LFO waveform'
        /// </summary>
        void SetLfoWaveform(FilterLfoWaveform value);
    }

    /// <inheritdoc cref="IFilterModuleHandle"/>
    public readonly partial struct FilterModuleHandle : IFilterModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public FilterModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(FilterModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Filter;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Filter;
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

        /// <inheritdoc cref="IFilterModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetFreq" />
        public int GetFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetFreq" />
        public void SetFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetResonance" />
        public int GetResonance(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetResonance" />
        public void SetResonance(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetFilterType" />
        public FilterType GetFilterType() => (FilterType)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetFilterType" />
        public void SetFilterType(FilterType value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.GetResponse" />
        public int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetResponse" />
        public void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetMode" />
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetMode" />
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.GetImpulse" />
        public int GetImpulse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetImpulse" />
        public void SetImpulse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetMix" />
        public int GetMix(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetMix" />
        public void SetMix(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetLfoFreq" />
        public int GetLfoFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetLfoFreq" />
        public void SetLfoFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetLfoAmp" />
        public int GetLfoAmp(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetLfoAmp" />
        public void SetLfoAmp(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetSetLfoPhase" />
        public int GetSetLfoPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetSetLfoPhase" />
        public void SetSetLfoPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.GetExponentialFreq" />
        public Toggle GetExponentialFreq() => (Toggle)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetExponentialFreq" />
        public void SetExponentialFreq(Toggle value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.GetRollOff" />
        public FilterRollOff GetRollOff() => (FilterRollOff)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetRollOff" />
        public void SetRollOff(FilterRollOff value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.GetLfoFreqUnit" />
        public FilterLfoFrequencyUnit GetLfoFreqUnit() => (FilterLfoFrequencyUnit)ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetLfoFreqUnit" />
        public void SetLfoFreqUnit(FilterLfoFrequencyUnit value) => ModuleHandle.SetControllerValue(13, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.GetLfoWaveform" />
        public FilterLfoWaveform GetLfoWaveform() => (FilterLfoWaveform)ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetLfoWaveform" />
        public void SetLfoWaveform(FilterLfoWaveform value) => ModuleHandle.SetControllerValue(14, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
