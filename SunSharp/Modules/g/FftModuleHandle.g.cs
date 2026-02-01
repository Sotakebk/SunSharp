/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// FFT-based frequency transformator.
    /// </summary>
    public partial interface IFftModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Original name: 0 'Sample rate'
        /// </summary>
        FftSampleRate GetSampleRate();

        /// <summary>
        /// Original name: 0 'Sample rate'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSampleRate(FftSampleRate value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeSampleRateEvent(FftSampleRate value);

        /// <summary>
        /// Original name: 1 'Channels'
        /// </summary>
        ChannelsInverted GetChannels();

        /// <summary>
        /// Original name: 1 'Channels'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetChannels(ChannelsInverted value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeChannelsEvent(ChannelsInverted value);

        /// <summary>
        /// Original name: 2 'Buffer (samples)'
        /// </summary>
        FftBufferSize GetBufferSamples();

        /// <summary>
        /// Original name: 2 'Buffer (samples)'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetBufferSamples(FftBufferSize value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeBufferSamplesEvent(FftBufferSize value);

        /// <summary>
        /// Original name: 3 'Buf overlap'
        /// </summary>
        FftBufferOverlap GetBufOverlap();

        /// <summary>
        /// Original name: 3 'Buf overlap'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetBufOverlap(FftBufferOverlap value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeBufOverlapEvent(FftBufferOverlap value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 4 'Feedback'
        /// </summary>
        int GetFeedback(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 4 'Feedback'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFeedback(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFeedbackEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 5 'Noise reduction'
        /// </summary>
        int GetNoiseReduction(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 5 'Noise reduction'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetNoiseReduction(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeNoiseReductionEvent(int value);

        /// <summary>
        /// Original name: 6 'Phase gain (norm=16384)'
        /// </summary>
        int GetPhaseGainNorm16384(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 6 'Phase gain (norm=16384)'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPhaseGainNorm16384(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakePhaseGainNorm16384Event(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 7 'All-pass filter'
        /// </summary>
        int GetAllPassFilter(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 7 'All-pass filter'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetAllPassFilter(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeAllPassFilterEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 8 'Frequency spread'
        /// </summary>
        int GetFrequencySpread(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 8 'Frequency spread'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFrequencySpread(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFrequencySpreadEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 9 'Random phase'
        /// </summary>
        int GetRandomPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 9 'Random phase'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRandomPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeRandomPhaseEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 10 'Random phase (lite)'
        /// </summary>
        int GetRandomPhaseLite(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 10 'Random phase (lite)'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRandomPhaseLite(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeRandomPhaseLiteEvent(int value);

        /// <summary>
        /// Value range: displayed: -4096 to 4096, real: 0 to 8192
        /// Original name: 11 'Freq shift'
        /// </summary>
        int GetFreqShift(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -4096 to 4096, real: 0 to 8192
        /// Original name: 11 'Freq shift'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFreqShift(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-4096 to 4096) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFreqShiftEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 12 'Deform1'
        /// </summary>
        int GetDeform1(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 12 'Deform1'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetDeform1(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeDeform1Event(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 13 'Deform2'
        /// </summary>
        int GetDeform2(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 13 'Deform2'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetDeform2(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeDeform2Event(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 14 'HP cutoff'
        /// </summary>
        int GetHpCutoff(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 14 'HP cutoff'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetHpCutoff(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeHpCutoffEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 15 'LP cutoff'
        /// </summary>
        int GetLpCutoff(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 15 'LP cutoff'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetLpCutoff(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeLpCutoffEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 16 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 16 'Volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeVolumeEvent(int value);
    }

    /// <inheritdoc cref="IFftModuleHandle"/>
    public readonly partial struct FftModuleHandle : IFftModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public FftModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(FftModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Fft;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Fft;
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

        /// <inheritdoc cref="IFftModuleHandle.GetSampleRate" />
        public FftSampleRate GetSampleRate() => (FftSampleRate)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFftModuleHandle.SetSampleRate" />
        public void SetSampleRate(FftSampleRate value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFftModuleHandle.MakeSampleRateEvent" />
        public PatternEvent MakeSampleRateEvent(FftSampleRate value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetChannels" />
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFftModuleHandle.SetChannels" />
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFftModuleHandle.MakeChannelsEvent" />
        public PatternEvent MakeChannelsEvent(ChannelsInverted value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetBufferSamples" />
        public FftBufferSize GetBufferSamples() => (FftBufferSize)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFftModuleHandle.SetBufferSamples" />
        public void SetBufferSamples(FftBufferSize value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFftModuleHandle.MakeBufferSamplesEvent" />
        public PatternEvent MakeBufferSamplesEvent(FftBufferSize value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetBufOverlap" />
        public FftBufferOverlap GetBufOverlap() => (FftBufferOverlap)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFftModuleHandle.SetBufOverlap" />
        public void SetBufOverlap(FftBufferOverlap value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFftModuleHandle.MakeBufOverlapEvent" />
        public PatternEvent MakeBufOverlapEvent(FftBufferOverlap value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetFeedback" />
        public int GetFeedback(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetFeedback" />
        public void SetFeedback(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeFeedbackEvent" />
        public PatternEvent MakeFeedbackEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetNoiseReduction" />
        public int GetNoiseReduction(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetNoiseReduction" />
        public void SetNoiseReduction(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeNoiseReductionEvent" />
        public PatternEvent MakeNoiseReductionEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetPhaseGainNorm16384" />
        public int GetPhaseGainNorm16384(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetPhaseGainNorm16384" />
        public void SetPhaseGainNorm16384(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakePhaseGainNorm16384Event" />
        public PatternEvent MakePhaseGainNorm16384Event(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetAllPassFilter" />
        public int GetAllPassFilter(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetAllPassFilter" />
        public void SetAllPassFilter(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeAllPassFilterEvent" />
        public PatternEvent MakeAllPassFilterEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetFrequencySpread" />
        public int GetFrequencySpread(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetFrequencySpread" />
        public void SetFrequencySpread(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeFrequencySpreadEvent" />
        public PatternEvent MakeFrequencySpreadEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetRandomPhase" />
        public int GetRandomPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetRandomPhase" />
        public void SetRandomPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeRandomPhaseEvent" />
        public PatternEvent MakeRandomPhaseEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 9, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetRandomPhaseLite" />
        public int GetRandomPhaseLite(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetRandomPhaseLite" />
        public void SetRandomPhaseLite(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeRandomPhaseLiteEvent" />
        public PatternEvent MakeRandomPhaseLiteEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 10, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetFreqShift" />
        public int GetFreqShift(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(11, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetFreqShift" />
        public void SetFreqShift(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(11, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeFreqShiftEvent" />
        public PatternEvent MakeFreqShiftEvent(int value)
        {
            value -= -4096;
            value = value * 0x8000 / (8192);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 11, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetDeform1" />
        public int GetDeform1(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(12, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetDeform1" />
        public void SetDeform1(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(12, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeDeform1Event" />
        public PatternEvent MakeDeform1Event(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 12, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetDeform2" />
        public int GetDeform2(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(13, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetDeform2" />
        public void SetDeform2(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(13, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeDeform2Event" />
        public PatternEvent MakeDeform2Event(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 13, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetHpCutoff" />
        public int GetHpCutoff(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(14, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetHpCutoff" />
        public void SetHpCutoff(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(14, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeHpCutoffEvent" />
        public PatternEvent MakeHpCutoffEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 14, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetLpCutoff" />
        public int GetLpCutoff(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(15, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetLpCutoff" />
        public void SetLpCutoff(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(15, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeLpCutoffEvent" />
        public PatternEvent MakeLpCutoffEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 15, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFftModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(16, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(16, value, valueScalingMode);

        /// <inheritdoc cref="IFftModuleHandle.MakeVolumeEvent" />
        public PatternEvent MakeVolumeEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 16, (ushort)Math.Clamp(value, 0, 0x8000));
        }
    }
}
#endif
