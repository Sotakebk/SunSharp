/*
 * Do not modify this file manually.
*/

#nullable enable

#if !SUNSHARP_GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// IIR Filter that can remove some unwanted frequency ranges.
    /// </summary>
    public partial interface IFilterModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 0 'Volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeVolumeEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 14000, real: 0 to 14000
        /// Original name: 1 'Freq'
        /// </summary>
        int GetFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 14000, real: 0 to 14000
        /// Original name: 1 'Freq'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 14000) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFreqEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 1530, real: 0 to 1530
        /// Original name: 2 'Resonance'
        /// </summary>
        int GetResonance(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 1530, real: 0 to 1530
        /// Original name: 2 'Resonance'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetResonance(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 1530) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeResonanceEvent(int value);

        /// <summary>
        /// Original name: 3 'Type'
        /// </summary>
        FilterType GetFilterType();

        /// <summary>
        /// Original name: 3 'Type'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFilterType(FilterType value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeFilterTypeEvent(FilterType value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 4 'Response'
        /// </summary>
        int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 4 'Response'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeResponseEvent(int value);

        /// <summary>
        /// Original name: 5 'Mode'
        /// </summary>
        Quality GetMode();

        /// <summary>
        /// Original name: 5 'Mode'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetMode(Quality value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeModeEvent(Quality value);

        /// <summary>
        /// Value range: displayed: 0 to 14000, real: 0 to 14000
        /// Original name: 6 'Impulse'
        /// </summary>
        int GetImpulse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 14000, real: 0 to 14000
        /// Original name: 6 'Impulse'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetImpulse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 14000) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeImpulseEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 7 'Mix'
        /// </summary>
        int GetMix(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 7 'Mix'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetMix(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeMixEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 1024, real: 0 to 1024
        /// Original name: 8 'LFO freq'
        /// </summary>
        int GetLfoFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 1024, real: 0 to 1024
        /// Original name: 8 'LFO freq'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetLfoFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 1024) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeLfoFreqEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 9 'LFO amp'
        /// </summary>
        int GetLfoAmp(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 9 'LFO amp'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetLfoAmp(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeLfoAmpEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 10 'Set LFO phase'
        /// </summary>
        int GetSetLfoPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 10 'Set LFO phase'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSetLfoPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSetLfoPhaseEvent(int value);

        /// <summary>
        /// Original name: 11 'Exponential freq'
        /// </summary>
        Toggle GetExponentialFreq();

        /// <summary>
        /// Original name: 11 'Exponential freq'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetExponentialFreq(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeExponentialFreqEvent(Toggle value);

        /// <summary>
        /// Original name: 12 'Roll-off'
        /// </summary>
        FilterRollOff GetRollOff();

        /// <summary>
        /// Original name: 12 'Roll-off'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRollOff(FilterRollOff value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeRollOffEvent(FilterRollOff value);

        /// <summary>
        /// Original name: 13 'LFO freq unit'
        /// </summary>
        FilterLfoFrequencyUnit GetLfoFreqUnit();

        /// <summary>
        /// Original name: 13 'LFO freq unit'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetLfoFreqUnit(FilterLfoFrequencyUnit value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeLfoFreqUnitEvent(FilterLfoFrequencyUnit value);

        /// <summary>
        /// Original name: 14 'LFO waveform'
        /// </summary>
        FilterLfoWaveform GetLfoWaveform();

        /// <summary>
        /// Original name: 14 'LFO waveform'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetLfoWaveform(FilterLfoWaveform value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeLfoWaveformEvent(FilterLfoWaveform value);
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

        /// <inheritdoc cref="SynthModuleHandle.GetInputModules()"/>
        public SynthModuleHandle[] GetInputModules() => ModuleHandle.GetInputModules();

        /// <inheritdoc cref="SynthModuleHandle.GetOutputModules()"/>
        public SynthModuleHandle[] GetOutputModules() => ModuleHandle.GetOutputModules();

        /// <inheritdoc cref="SynthModuleHandle.ConnectInput(SynthModuleHandle)"/>
        public void ConnectInput(SynthModuleHandle targetModule) => ModuleHandle.ConnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.ConnectOutput(SynthModuleHandle)"/>
        public void ConnectOutput(SynthModuleHandle targetModule) => ModuleHandle.ConnectOutput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectInput(SynthModuleHandle)"/>
        public void DisconnectInput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectOutput(SynthModuleHandle)"/>
        public void DisconnectOutput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectOutput(targetModule);

        #endregion

        /// <inheritdoc cref="IFilterModuleHandle.GetVolume(ValueScalingMode)" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetVolume(int, ValueScalingMode)" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeVolumeEvent" />
        public PatternEvent MakeVolumeEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetFreq(ValueScalingMode)" />
        public int GetFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetFreq(int, ValueScalingMode)" />
        public void SetFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeFreqEvent" />
        public PatternEvent MakeFreqEvent(int value)
        {
            value = value * 0x8000 / (14000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetResonance(ValueScalingMode)" />
        public int GetResonance(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetResonance(int, ValueScalingMode)" />
        public void SetResonance(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeResonanceEvent" />
        public PatternEvent MakeResonanceEvent(int value)
        {
            value = value * 0x8000 / (1530);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetFilterType()" />
        public FilterType GetFilterType() => (FilterType)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetFilterType(FilterType)" />
        public void SetFilterType(FilterType value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.MakeFilterTypeEvent" />
        public PatternEvent MakeFilterTypeEvent(FilterType value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetResponse(ValueScalingMode)" />
        public int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetResponse(int, ValueScalingMode)" />
        public void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeResponseEvent" />
        public PatternEvent MakeResponseEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetMode()" />
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetMode(Quality)" />
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.MakeModeEvent" />
        public PatternEvent MakeModeEvent(Quality value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetImpulse(ValueScalingMode)" />
        public int GetImpulse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetImpulse(int, ValueScalingMode)" />
        public void SetImpulse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeImpulseEvent" />
        public PatternEvent MakeImpulseEvent(int value)
        {
            value = value * 0x8000 / (14000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetMix(ValueScalingMode)" />
        public int GetMix(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetMix(int, ValueScalingMode)" />
        public void SetMix(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeMixEvent" />
        public PatternEvent MakeMixEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetLfoFreq(ValueScalingMode)" />
        public int GetLfoFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetLfoFreq(int, ValueScalingMode)" />
        public void SetLfoFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeLfoFreqEvent" />
        public PatternEvent MakeLfoFreqEvent(int value)
        {
            value = value * 0x8000 / (1024);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetLfoAmp(ValueScalingMode)" />
        public int GetLfoAmp(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetLfoAmp(int, ValueScalingMode)" />
        public void SetLfoAmp(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeLfoAmpEvent" />
        public PatternEvent MakeLfoAmpEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 9, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetSetLfoPhase(ValueScalingMode)" />
        public int GetSetLfoPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.SetSetLfoPhase(int, ValueScalingMode)" />
        public void SetSetLfoPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="IFilterModuleHandle.MakeSetLfoPhaseEvent" />
        public PatternEvent MakeSetLfoPhaseEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 10, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetExponentialFreq()" />
        public Toggle GetExponentialFreq() => (Toggle)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetExponentialFreq(Toggle)" />
        public void SetExponentialFreq(Toggle value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.MakeExponentialFreqEvent" />
        public PatternEvent MakeExponentialFreqEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 11, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetRollOff()" />
        public FilterRollOff GetRollOff() => (FilterRollOff)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetRollOff(FilterRollOff)" />
        public void SetRollOff(FilterRollOff value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.MakeRollOffEvent" />
        public PatternEvent MakeRollOffEvent(FilterRollOff value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 12, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetLfoFreqUnit()" />
        public FilterLfoFrequencyUnit GetLfoFreqUnit() => (FilterLfoFrequencyUnit)ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetLfoFreqUnit(FilterLfoFrequencyUnit)" />
        public void SetLfoFreqUnit(FilterLfoFrequencyUnit value) => ModuleHandle.SetControllerValue(13, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.MakeLfoFreqUnitEvent" />
        public PatternEvent MakeLfoFreqUnitEvent(FilterLfoFrequencyUnit value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 13, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFilterModuleHandle.GetLfoWaveform()" />
        public FilterLfoWaveform GetLfoWaveform() => (FilterLfoWaveform)ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.SetLfoWaveform(FilterLfoWaveform)" />
        public void SetLfoWaveform(FilterLfoWaveform value) => ModuleHandle.SetControllerValue(14, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFilterModuleHandle.MakeLfoWaveformEvent" />
        public PatternEvent MakeLfoWaveformEvent(FilterLfoWaveform value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 14, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }
    }
}
#endif
