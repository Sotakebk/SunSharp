/*
 * Do not modify this file manually.
*/

#nullable enable

#if !SUNSHARP_GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// 5-operator Frequency Modulation (FM) Synthesizer.
    /// </summary>
    public partial interface IFmxModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 0 'Volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeVolumeEvent(int value);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 1 'Panning'
        /// </summary>
        int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 1 'Panning'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-128 to 128) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakePanningEvent(int value);

        /// <summary>
        /// Original name: 2 'Sample rate'
        /// </summary>
        FmxSampleRate GetSampleRate();

        /// <summary>
        /// Original name: 2 'Sample rate'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSampleRate(FmxSampleRate value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeSampleRateEvent(FmxSampleRate value);

        /// <summary>
        /// Original name: 3 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 'Polyphony'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakePolyphonyEvent(int value);

        /// <summary>
        /// Original name: 4 'Channels'
        /// </summary>
        ChannelsInverted GetChannels();

        /// <summary>
        /// Original name: 4 'Channels'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetChannels(ChannelsInverted value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeChannelsEvent(ChannelsInverted value);

        /// <summary>
        /// Original name: 5 'Input -> Operator #'
        /// </summary>
        int GetInputOperator(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Input -> Operator #'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetInputOperator(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeInputOperatorEvent(int value);

        /// <summary>
        /// Original name: 6 'Input -> Custom waveform'
        /// </summary>
        FmxCustomWaveform GetInputCustomWaveform();

        /// <summary>
        /// Original name: 6 'Input -> Custom waveform'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetInputCustomWaveform(FmxCustomWaveform value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeInputCustomWaveformEvent(FmxCustomWaveform value);

        /// <summary>
        /// Original name: 7 'ADSR smooth transitions'
        /// </summary>
        AdsrSmoothTransitions GetAdsrSmoothTransitions();

        /// <summary>
        /// Original name: 7 'ADSR smooth transitions'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetAdsrSmoothTransitions(AdsrSmoothTransitions value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeAdsrSmoothTransitionsEvent(AdsrSmoothTransitions value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 8 'Noise filter (32768 - OFF)'
        /// </summary>
        int GetNoiseFilterOff32768(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 8 'Noise filter (32768 - OFF)'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetNoiseFilterOff32768(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeNoiseFilterOff32768Event(int value);

        /// <summary>
        /// Original name: 114 '1 Output mode'
        /// </summary>
        int GetOutputMode1(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 114 '1 Output mode'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetOutputMode1(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeOutputMode1Event(int value);

        /// <summary>
        /// Original name: 115 '2 Output mode'
        /// </summary>
        int GetOutputMode2(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 115 '2 Output mode'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetOutputMode2(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeOutputMode2Event(int value);

        /// <summary>
        /// Original name: 116 '3 Output mode'
        /// </summary>
        int GetOutputMode3(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 116 '3 Output mode'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetOutputMode3(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeOutputMode3Event(int value);

        /// <summary>
        /// Original name: 117 '4 Output mode'
        /// </summary>
        int GetOutputMode4(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 117 '4 Output mode'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetOutputMode4(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeOutputMode4Event(int value);

        /// <summary>
        /// Value range: displayed: 0 to 8000, real: 0 to 8000
        /// Original name: 118 'Envelope gain'
        /// </summary>
        int GetEnvelopeGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 8000, real: 0 to 8000
        /// Original name: 118 'Envelope gain'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetEnvelopeGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 8000) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeEnvelopeGainEvent(int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 9.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 9-13 '1 Volume'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorVolume(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 9.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 9-13 '1 Volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorVolume(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 9.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 9-13 '1 Volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorVolumeEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 14.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 14-18 '1 Attack'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorAttack(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 14.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 14-18 '1 Attack'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorAttack(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 14.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 14-18 '1 Attack'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorAttackEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 19.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 19-23 '1 Decay'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorDecay(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 19.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 19-23 '1 Decay'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorDecay(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 19.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 19-23 '1 Decay'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorDecayEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 24.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 24-28 '1 Sustain level'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorSustainLevel(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 24.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 24-28 '1 Sustain level'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorSustainLevel(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 24.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 24-28 '1 Sustain level'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorSustainLevelEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 29.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 29-33 '1 Release'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorRelease(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 29.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 29-33 '1 Release'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorRelease(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 29.
        /// <br/>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name pattern: 29-33 '1 Release'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorReleaseEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 34.
        /// <br/>
        /// Original name pattern: 34-38 '1 Attack curve'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        AdsrCurveType GetOperatorAttackCurve(int index);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 34.
        /// <br/>
        /// Original name pattern: 34-38 '1 Attack curve'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorAttackCurve(int index, AdsrCurveType value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 34.
        /// <br/>
        /// Original name pattern: 34-38 '1 Attack curve'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorAttackCurveEvent(int index, AdsrCurveType value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 39.
        /// <br/>
        /// Original name pattern: 39-43 '1 Decay curve'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        AdsrCurveType GetOperatorDecayCurve(int index);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 39.
        /// <br/>
        /// Original name pattern: 39-43 '1 Decay curve'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorDecayCurve(int index, AdsrCurveType value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 39.
        /// <br/>
        /// Original name pattern: 39-43 '1 Decay curve'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorDecayCurveEvent(int index, AdsrCurveType value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 44.
        /// <br/>
        /// Original name pattern: 44-48 '1 Release curve'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        AdsrCurveType GetOperatorReleaseCurve(int index);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 44.
        /// <br/>
        /// Original name pattern: 44-48 '1 Release curve'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorReleaseCurve(int index, AdsrCurveType value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 44.
        /// <br/>
        /// Original name pattern: 44-48 '1 Release curve'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorReleaseCurveEvent(int index, AdsrCurveType value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 49.
        /// <br/>
        /// Original name pattern: 49-53 '1 Sustain'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        AdsrSustainMode GetOperatorSustain(int index);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 49.
        /// <br/>
        /// Original name pattern: 49-53 '1 Sustain'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorSustain(int index, AdsrSustainMode value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 49.
        /// <br/>
        /// Original name pattern: 49-53 '1 Sustain'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorSustainEvent(int index, AdsrSustainMode value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 54.
        /// <br/>
        /// Original name pattern: 54-58 '1 Sustain pedal'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        Toggle GetOperatorSustainPedal(int index);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 54.
        /// <br/>
        /// Original name pattern: 54-58 '1 Sustain pedal'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorSustainPedal(int index, Toggle value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 54.
        /// <br/>
        /// Original name pattern: 54-58 '1 Sustain pedal'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorSustainPedalEvent(int index, Toggle value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 59.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 59-63 '1 Envelope scaling per key'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorEnvelopeScalingPerKey(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 59.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 59-63 '1 Envelope scaling per key'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorEnvelopeScalingPerKey(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 59.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 59-63 '1 Envelope scaling per key'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorEnvelopeScalingPerKeyEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 64.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 64-68 '1 Volume scaling per key'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorVolumeScalingPerKey(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 64.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 64-68 '1 Volume scaling per key'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorVolumeScalingPerKey(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 64.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 64-68 '1 Volume scaling per key'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorVolumeScalingPerKeyEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 69.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 69-73 '1 Velocity sensitivity'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorVelocitySensitivity(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 69.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 69-73 '1 Velocity sensitivity'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorVelocitySensitivity(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 69.
        /// <br/>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name pattern: 69-73 '1 Velocity sensitivity'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorVelocitySensitivityEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 74.
        /// <br/>
        /// Original name pattern: 74-78 '1 Waveform'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        FmxWaveform GetOperatorWaveform(int index);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 74.
        /// <br/>
        /// Original name pattern: 74-78 '1 Waveform'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorWaveform(int index, FmxWaveform value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 74.
        /// <br/>
        /// Original name pattern: 74-78 '1 Waveform'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorWaveformEvent(int index, FmxWaveform value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 79.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 79-83 '1 Noise'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorNoise(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 79.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 79-83 '1 Noise'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorNoise(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 79.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 79-83 '1 Noise'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorNoiseEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 84.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 84-88 '1 Phase'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorPhase(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 84.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 84-88 '1 Phase'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorPhase(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 84.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 84-88 '1 Phase'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorPhaseEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 89.
        /// <br/>
        /// Value range: displayed: 0 to 32000, real: 0 to 32000
        /// Original name pattern: 89-93 '1 Freq multiply'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorFrequencyMultiply(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 89.
        /// <br/>
        /// Value range: displayed: 0 to 32000, real: 0 to 32000
        /// Original name pattern: 89-93 '1 Freq multiply'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorFrequencyMultiply(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 89.
        /// <br/>
        /// Value range: displayed: 0 to 32000, real: 0 to 32000
        /// Original name pattern: 89-93 '1 Freq multiply'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorFrequencyMultiplyEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 94.
        /// <br/>
        /// Value range: displayed: -8192 to 8192, real: 0 to 16384
        /// Original name pattern: 94-98 '1 Constant pitch'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorConstantPitch(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 94.
        /// <br/>
        /// Value range: displayed: -8192 to 8192, real: 0 to 16384
        /// Original name pattern: 94-98 '1 Constant pitch'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorConstantPitch(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 94.
        /// <br/>
        /// Value range: displayed: -8192 to 8192, real: 0 to 16384
        /// Original name pattern: 94-98 '1 Constant pitch'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorConstantPitchEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 99.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 99-103 '1 Self-modulation'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorSelfModulation(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 99.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 99-103 '1 Self-modulation'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorSelfModulation(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 99.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 99-103 '1 Self-modulation'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorSelfModulationEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 104.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 104-108 '1 Feedback'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        int GetOperatorFeedback(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 104.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 104-108 '1 Feedback'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorFeedback(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 104.
        /// <br/>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name pattern: 104-108 '1 Feedback'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorFeedbackEvent(int index, int value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 109.
        /// <br/>
        /// Original name pattern: 109-113 '1 Modulation type'
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        FmxModulationType GetOperatorModulationType(int index);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 109.
        /// <br/>
        /// Original name pattern: 109-113 '1 Modulation type'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        void SetOperatorModulationType(int index, FmxModulationType value);

        /// <summary>
        /// This method accesses one of 5 grouped controllers starting at controller 109.
        /// <br/>
        /// Original name pattern: 109-113 '1 Modulation type'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        /// <param name="index">Index of the controller in the group (0-4)</param>
        PatternEvent MakeOperatorModulationTypeEvent(int index, FmxModulationType value);

        /// <summary>
        /// <para>
        /// Used as a waveform where 'Custom' waveform type was applied.
        /// </para>
        /// <para>
        /// Write to curve 0 of Fmx.
        /// </para>
        /// The curve contains 256 values in range of -1 to 1.
        /// </summary>
        int WriteCurveCustomWaveform(float[] buffer);

        /// <summary>
        /// <para>
        /// Used as a waveform where 'Custom' waveform type was applied.
        /// </para>
        /// <para>
        /// Read from curve 0 of Fmx.
        /// </para>
        /// The curve contains 256 values in range of -1 to 1.
        /// </summary>
        int ReadCurveCustomWaveform(float[] buffer);
    }

    /// <inheritdoc cref="IFmxModuleHandle"/>
    public readonly partial struct FmxModuleHandle : IFmxModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public FmxModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(FmxModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Fmx;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Fmx;
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

        /// <inheritdoc cref="IFmxModuleHandle.GetVolume(ValueScalingMode)" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetVolume(int, ValueScalingMode)" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakeVolumeEvent" />
        public PatternEvent MakeVolumeEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetPanning(ValueScalingMode)" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetPanning(int, ValueScalingMode)" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakePanningEvent" />
        public PatternEvent MakePanningEvent(int value)
        {
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetSampleRate()" />
        public FmxSampleRate GetSampleRate() => (FmxSampleRate)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.SetSampleRate(FmxSampleRate)" />
        public void SetSampleRate(FmxSampleRate value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.MakeSampleRateEvent" />
        public PatternEvent MakeSampleRateEvent(FmxSampleRate value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetPolyphony(ValueScalingMode)" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetPolyphony(int, ValueScalingMode)" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakePolyphonyEvent" />
        public PatternEvent MakePolyphonyEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetChannels()" />
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.SetChannels(ChannelsInverted)" />
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.MakeChannelsEvent" />
        public PatternEvent MakeChannelsEvent(ChannelsInverted value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetInputOperator(ValueScalingMode)" />
        public int GetInputOperator(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetInputOperator(int, ValueScalingMode)" />
        public void SetInputOperator(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakeInputOperatorEvent" />
        public PatternEvent MakeInputOperatorEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetInputCustomWaveform()" />
        public FmxCustomWaveform GetInputCustomWaveform() => (FmxCustomWaveform)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.SetInputCustomWaveform(FmxCustomWaveform)" />
        public void SetInputCustomWaveform(FmxCustomWaveform value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.MakeInputCustomWaveformEvent" />
        public PatternEvent MakeInputCustomWaveformEvent(FmxCustomWaveform value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetAdsrSmoothTransitions()" />
        public AdsrSmoothTransitions GetAdsrSmoothTransitions() => (AdsrSmoothTransitions)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.SetAdsrSmoothTransitions(AdsrSmoothTransitions)" />
        public void SetAdsrSmoothTransitions(AdsrSmoothTransitions value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.MakeAdsrSmoothTransitionsEvent" />
        public PatternEvent MakeAdsrSmoothTransitionsEvent(AdsrSmoothTransitions value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetNoiseFilterOff32768(ValueScalingMode)" />
        public int GetNoiseFilterOff32768(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetNoiseFilterOff32768(int, ValueScalingMode)" />
        public void SetNoiseFilterOff32768(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakeNoiseFilterOff32768Event" />
        public PatternEvent MakeNoiseFilterOff32768Event(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOutputMode1(ValueScalingMode)" />
        public int GetOutputMode1(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(114, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetOutputMode1(int, ValueScalingMode)" />
        public void SetOutputMode1(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(114, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakeOutputMode1Event" />
        public PatternEvent MakeOutputMode1Event(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 114, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOutputMode2(ValueScalingMode)" />
        public int GetOutputMode2(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(115, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetOutputMode2(int, ValueScalingMode)" />
        public void SetOutputMode2(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(115, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakeOutputMode2Event" />
        public PatternEvent MakeOutputMode2Event(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 115, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOutputMode3(ValueScalingMode)" />
        public int GetOutputMode3(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(116, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetOutputMode3(int, ValueScalingMode)" />
        public void SetOutputMode3(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(116, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakeOutputMode3Event" />
        public PatternEvent MakeOutputMode3Event(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 116, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOutputMode4(ValueScalingMode)" />
        public int GetOutputMode4(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(117, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetOutputMode4(int, ValueScalingMode)" />
        public void SetOutputMode4(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(117, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakeOutputMode4Event" />
        public PatternEvent MakeOutputMode4Event(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 117, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetEnvelopeGain(ValueScalingMode)" />
        public int GetEnvelopeGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(118, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetEnvelopeGain(int, ValueScalingMode)" />
        public void SetEnvelopeGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(118, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.MakeEnvelopeGainEvent" />
        public PatternEvent MakeEnvelopeGainEvent(int value)
        {
            value = value * 0x8000 / (8000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 118, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorVolume(int, ValueScalingMode)" />
        public int GetOperatorVolume(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(9 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorVolume(int, int, ValueScalingMode)" />
        public void SetOperatorVolume(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(9 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorVolumeEvent" />
        public PatternEvent MakeOperatorVolumeEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(9 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorAttack(int, ValueScalingMode)" />
        public int GetOperatorAttack(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(14 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorAttack(int, int, ValueScalingMode)" />
        public void SetOperatorAttack(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(14 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorAttackEvent" />
        public PatternEvent MakeOperatorAttackEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (10000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(14 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorDecay(int, ValueScalingMode)" />
        public int GetOperatorDecay(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(19 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorDecay(int, int, ValueScalingMode)" />
        public void SetOperatorDecay(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(19 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorDecayEvent" />
        public PatternEvent MakeOperatorDecayEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (10000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(19 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorSustainLevel(int, ValueScalingMode)" />
        public int GetOperatorSustainLevel(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(24 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorSustainLevel(int, int, ValueScalingMode)" />
        public void SetOperatorSustainLevel(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(24 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorSustainLevelEvent" />
        public PatternEvent MakeOperatorSustainLevelEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(24 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorRelease(int, ValueScalingMode)" />
        public int GetOperatorRelease(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(29 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorRelease(int, int, ValueScalingMode)" />
        public void SetOperatorRelease(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(29 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorReleaseEvent" />
        public PatternEvent MakeOperatorReleaseEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (10000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(29 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorAttackCurve(int)" />
        public AdsrCurveType GetOperatorAttackCurve(int index)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return (AdsrCurveType)ModuleHandle.GetControllerValue((byte)(34 + index), ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorAttackCurve(int, AdsrCurveType)" />
        public void SetOperatorAttackCurve(int index, AdsrCurveType value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(34 + index), (int)value, ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorAttackCurveEvent" />
        public PatternEvent MakeOperatorAttackCurveEvent(int index, AdsrCurveType value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(34 + index), (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorDecayCurve(int)" />
        public AdsrCurveType GetOperatorDecayCurve(int index)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return (AdsrCurveType)ModuleHandle.GetControllerValue((byte)(39 + index), ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorDecayCurve(int, AdsrCurveType)" />
        public void SetOperatorDecayCurve(int index, AdsrCurveType value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(39 + index), (int)value, ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorDecayCurveEvent" />
        public PatternEvent MakeOperatorDecayCurveEvent(int index, AdsrCurveType value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(39 + index), (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorReleaseCurve(int)" />
        public AdsrCurveType GetOperatorReleaseCurve(int index)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return (AdsrCurveType)ModuleHandle.GetControllerValue((byte)(44 + index), ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorReleaseCurve(int, AdsrCurveType)" />
        public void SetOperatorReleaseCurve(int index, AdsrCurveType value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(44 + index), (int)value, ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorReleaseCurveEvent" />
        public PatternEvent MakeOperatorReleaseCurveEvent(int index, AdsrCurveType value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(44 + index), (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorSustain(int)" />
        public AdsrSustainMode GetOperatorSustain(int index)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return (AdsrSustainMode)ModuleHandle.GetControllerValue((byte)(49 + index), ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorSustain(int, AdsrSustainMode)" />
        public void SetOperatorSustain(int index, AdsrSustainMode value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(49 + index), (int)value, ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorSustainEvent" />
        public PatternEvent MakeOperatorSustainEvent(int index, AdsrSustainMode value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(49 + index), (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorSustainPedal(int)" />
        public Toggle GetOperatorSustainPedal(int index)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return (Toggle)ModuleHandle.GetControllerValue((byte)(54 + index), ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorSustainPedal(int, Toggle)" />
        public void SetOperatorSustainPedal(int index, Toggle value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(54 + index), (int)value, ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorSustainPedalEvent" />
        public PatternEvent MakeOperatorSustainPedalEvent(int index, Toggle value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(54 + index), (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorEnvelopeScalingPerKey(int, ValueScalingMode)" />
        public int GetOperatorEnvelopeScalingPerKey(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(59 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorEnvelopeScalingPerKey(int, int, ValueScalingMode)" />
        public void SetOperatorEnvelopeScalingPerKey(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(59 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorEnvelopeScalingPerKeyEvent" />
        public PatternEvent MakeOperatorEnvelopeScalingPerKeyEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(59 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorVolumeScalingPerKey(int, ValueScalingMode)" />
        public int GetOperatorVolumeScalingPerKey(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(64 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorVolumeScalingPerKey(int, int, ValueScalingMode)" />
        public void SetOperatorVolumeScalingPerKey(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(64 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorVolumeScalingPerKeyEvent" />
        public PatternEvent MakeOperatorVolumeScalingPerKeyEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(64 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorVelocitySensitivity(int, ValueScalingMode)" />
        public int GetOperatorVelocitySensitivity(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(69 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorVelocitySensitivity(int, int, ValueScalingMode)" />
        public void SetOperatorVelocitySensitivity(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(69 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorVelocitySensitivityEvent" />
        public PatternEvent MakeOperatorVelocitySensitivityEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(69 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorWaveform(int)" />
        public FmxWaveform GetOperatorWaveform(int index)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return (FmxWaveform)ModuleHandle.GetControllerValue((byte)(74 + index), ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorWaveform(int, FmxWaveform)" />
        public void SetOperatorWaveform(int index, FmxWaveform value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(74 + index), (int)value, ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorWaveformEvent" />
        public PatternEvent MakeOperatorWaveformEvent(int index, FmxWaveform value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(74 + index), (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorNoise(int, ValueScalingMode)" />
        public int GetOperatorNoise(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(79 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorNoise(int, int, ValueScalingMode)" />
        public void SetOperatorNoise(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(79 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorNoiseEvent" />
        public PatternEvent MakeOperatorNoiseEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(79 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorPhase(int, ValueScalingMode)" />
        public int GetOperatorPhase(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(84 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorPhase(int, int, ValueScalingMode)" />
        public void SetOperatorPhase(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(84 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorPhaseEvent" />
        public PatternEvent MakeOperatorPhaseEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(84 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorFrequencyMultiply(int, ValueScalingMode)" />
        public int GetOperatorFrequencyMultiply(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(89 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorFrequencyMultiply(int, int, ValueScalingMode)" />
        public void SetOperatorFrequencyMultiply(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(89 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorFrequencyMultiplyEvent" />
        public PatternEvent MakeOperatorFrequencyMultiplyEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (32000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(89 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorConstantPitch(int, ValueScalingMode)" />
        public int GetOperatorConstantPitch(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(94 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorConstantPitch(int, int, ValueScalingMode)" />
        public void SetOperatorConstantPitch(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(94 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorConstantPitchEvent" />
        public PatternEvent MakeOperatorConstantPitchEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value -= -8192;
            value = value * 0x8000 / (16384);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(94 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorSelfModulation(int, ValueScalingMode)" />
        public int GetOperatorSelfModulation(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(99 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorSelfModulation(int, int, ValueScalingMode)" />
        public void SetOperatorSelfModulation(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(99 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorSelfModulationEvent" />
        public PatternEvent MakeOperatorSelfModulationEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(99 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorFeedback(int, ValueScalingMode)" />
        public int GetOperatorFeedback(int index, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ModuleHandle.GetControllerValue((byte)(104 + index), valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorFeedback(int, int, ValueScalingMode)" />
        public void SetOperatorFeedback(int index, int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(104 + index), value, valueScalingMode);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorFeedbackEvent" />
        public PatternEvent MakeOperatorFeedbackEvent(int index, int value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(104 + index), (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.GetOperatorModulationType(int)" />
        public FmxModulationType GetOperatorModulationType(int index)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return (FmxModulationType)ModuleHandle.GetControllerValue((byte)(109 + index), ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.SetOperatorModulationType(int, FmxModulationType)" />
        public void SetOperatorModulationType(int index, FmxModulationType value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ModuleHandle.SetControllerValue((byte)(109 + index), (int)value, ValueScalingMode.Displayed);
        }

        /// <inheritdoc cref="IFmxModuleHandle.MakeOperatorModulationTypeEvent" />
        public PatternEvent MakeOperatorModulationTypeEvent(int index, FmxModulationType value)
        {
            if (index < 0 || index > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return PatternEvent.ControllerEvent(ModuleHandle.Id, (byte)(109 + index), (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IFmxModuleHandle.ReadCurveCustomWaveform"/>
        public int ReadCurveCustomWaveform(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IFmxModuleHandle.WriteCurveCustomWaveform"/>
        public int WriteCurveCustomWaveform(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);
    }
}
#endif
