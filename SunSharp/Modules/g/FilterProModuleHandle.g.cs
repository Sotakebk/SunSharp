/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// High-quality 64-bit IIR Filter that can amplify, pass or attenuate some frequency ranges. This module is faster than Filter on modern CPUs and slower on older CPUs.
    /// </summary>
    public partial interface IFilterProModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 0 'Volume'
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 'Type'
        /// </summary>
        FilterProType GetFilterType();

        /// <summary>
        /// Original name: 1 'Type'
        /// </summary>
        void SetFilterType(FilterProType value);

        /// <summary>
        /// Value range: 0-22000
        /// Original name: 2 'Freq'
        /// </summary>
        int GetFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-22000
        /// Original name: 2 'Freq'
        /// </summary>
        void SetFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -1000-1000, real: 0-2000
        /// Original name: 3 'Freq finetune'
        /// </summary>
        int GetFreqFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -1000-1000, real: 0-2000
        /// Original name: 3 'Freq finetune'
        /// </summary>
        void SetFreqFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-200
        /// Original name: 4 'Freq scale'
        /// </summary>
        int GetFreqScale(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-200
        /// Original name: 4 'Freq scale'
        /// </summary>
        void SetFreqScale(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Exponential freq'
        /// </summary>
        Toggle GetExponentialFreq();

        /// <summary>
        /// Original name: 5 'Exponential freq'
        /// </summary>
        void SetExponentialFreq(Toggle value);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 6 'Q'
        /// </summary>
        int GetQ(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 6 'Q'
        /// </summary>
        void SetQ(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -16384-16384, real: 0-32768
        /// Original name: 7 'Gain'
        /// </summary>
        int GetGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -16384-16384, real: 0-32768
        /// Original name: 7 'Gain'
        /// </summary>
        void SetGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 8 'Roll-off'
        /// </summary>
        FilterProRollOff GetRollOff();

        /// <summary>
        /// Original name: 8 'Roll-off'
        /// </summary>
        void SetRollOff(FilterProRollOff value);

        /// <summary>
        /// Value range: 0-1000
        /// Original name: 9 'Response'
        /// </summary>
        int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1000
        /// Original name: 9 'Response'
        /// </summary>
        void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 10 'Mode'
        /// </summary>
        FilterProMode GetMode();

        /// <summary>
        /// Original name: 10 'Mode'
        /// </summary>
        void SetMode(FilterProMode value);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 11 'Mix'
        /// </summary>
        int GetMix(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 11 'Mix'
        /// </summary>
        void SetMix(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 12 'LFO freq'
        /// </summary>
        int GetLfoFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 12 'LFO freq'
        /// </summary>
        void SetLfoFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 13 'LFO amp'
        /// </summary>
        int GetLfoAmp(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 13 'LFO amp'
        /// </summary>
        void SetLfoAmp(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 14 'LFO waveform'
        /// </summary>
        FilterLfoWaveform GetLfoWaveform();

        /// <summary>
        /// Original name: 14 'LFO waveform'
        /// </summary>
        void SetLfoWaveform(FilterLfoWaveform value);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 15 'Set LFO phase'
        /// </summary>
        int GetSetLfoPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 15 'Set LFO phase'
        /// </summary>
        void SetSetLfoPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 16 'LFO freq unit'
        /// </summary>
        FilterLfoFrequencyUnit GetLfoFreqUnit();

        /// <summary>
        /// Original name: 16 'LFO freq unit'
        /// </summary>
        void SetLfoFreqUnit(FilterLfoFrequencyUnit value);
    }

    /// <inheritdoc cref="IFilterProModuleHandle"/>
    public readonly partial struct FilterProModuleHandle : IFilterProModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public FilterProModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(FilterProModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.FilterPro;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.FilterPro;
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

        /// <inheritdoc cref="IFilterProModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetFilterType" />
        public FilterProType GetFilterType() => (FilterProType)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.SetFilterType" />
        public void SetFilterType(FilterProType value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.GetFreq" />
        public int GetFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetFreq" />
        public void SetFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetFreqFinetune" />
        public int GetFreqFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetFreqFinetune" />
        public void SetFreqFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetFreqScale" />
        public int GetFreqScale(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetFreqScale" />
        public void SetFreqScale(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetExponentialFreq" />
        public Toggle GetExponentialFreq() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.SetExponentialFreq" />
        public void SetExponentialFreq(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.GetQ" />
        public int GetQ(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetQ" />
        public void SetQ(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetGain" />
        public int GetGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetGain" />
        public void SetGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetRollOff" />
        public FilterProRollOff GetRollOff() => (FilterProRollOff)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.SetRollOff" />
        public void SetRollOff(FilterProRollOff value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.GetResponse" />
        public int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetResponse" />
        public void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetMode" />
        public FilterProMode GetMode() => (FilterProMode)ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.SetMode" />
        public void SetMode(FilterProMode value) => ModuleHandle.SetControllerValue(10, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.GetMix" />
        public int GetMix(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(11, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetMix" />
        public void SetMix(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(11, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetLfoFreq" />
        public int GetLfoFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(12, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetLfoFreq" />
        public void SetLfoFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(12, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetLfoAmp" />
        public int GetLfoAmp(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(13, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetLfoAmp" />
        public void SetLfoAmp(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(13, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetLfoWaveform" />
        public FilterLfoWaveform GetLfoWaveform() => (FilterLfoWaveform)ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.SetLfoWaveform" />
        public void SetLfoWaveform(FilterLfoWaveform value) => ModuleHandle.SetControllerValue(14, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.GetSetLfoPhase" />
        public int GetSetLfoPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(15, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.SetSetLfoPhase" />
        public void SetSetLfoPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(15, value, valueScalingMode);

        /// <inheritdoc cref="IFilterProModuleHandle.GetLfoFreqUnit" />
        public FilterLfoFrequencyUnit GetLfoFreqUnit() => (FilterLfoFrequencyUnit)ModuleHandle.GetControllerValue(16, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterProModuleHandle.SetLfoFreqUnit" />
        public void SetLfoFreqUnit(FilterLfoFrequencyUnit value) => ModuleHandle.SetControllerValue(16, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
