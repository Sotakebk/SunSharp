/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// 5-operator Frequency Modulation (FM) Synthesizer.
    /// </summary>
    public partial interface IFmxModuleHandle : ITypedModuleHandle
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
        /// Original name: 2 'Sample rate'
        /// </summary>
        FmxSampleRate GetSampleRate();

        /// <summary>
        /// Original name: 2 'Sample rate'
        /// </summary>
        void SetSampleRate(FmxSampleRate value);

        /// <summary>
        /// Value range: 1-32
        /// Original name: 3 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32
        /// Original name: 3 'Polyphony'
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 'Channels'
        /// </summary>
        ChannelsInverted GetChannels();

        /// <summary>
        /// Original name: 4 'Channels'
        /// </summary>
        void SetChannels(ChannelsInverted value);

        /// <summary>
        /// Value range: 0-5
        /// Original name: 5 'Input -> Operator #'
        /// </summary>
        int GetInputOperator(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-5
        /// Original name: 5 'Input -> Operator #'
        /// </summary>
        void SetInputOperator(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 6 'Input -> Custom waveform'
        /// </summary>
        FmxCustomWaveform GetInputCustomWaveform();

        /// <summary>
        /// Original name: 6 'Input -> Custom waveform'
        /// </summary>
        void SetInputCustomWaveform(FmxCustomWaveform value);

        /// <summary>
        /// Original name: 7 'ADSR smooth transitions'
        /// </summary>
        AdsrSmoothTransitions GetAdsrSmoothTransitions();

        /// <summary>
        /// Original name: 7 'ADSR smooth transitions'
        /// </summary>
        void SetAdsrSmoothTransitions(AdsrSmoothTransitions value);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 8 'Noise filter (32768 - OFF)'
        /// </summary>
        int GetNoiseFilterOff32768(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 8 'Noise filter (32768 - OFF)'
        /// </summary>
        void SetNoiseFilterOff32768(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-31
        /// Original name: 114 '1 Output mode'
        /// </summary>
        int GetOutputMode1(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-31
        /// Original name: 114 '1 Output mode'
        /// </summary>
        void SetOutputMode1(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-15
        /// Original name: 115 '2 Output mode'
        /// </summary>
        int GetOutputMode2(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-15
        /// Original name: 115 '2 Output mode'
        /// </summary>
        void SetOutputMode2(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-7
        /// Original name: 116 '3 Output mode'
        /// </summary>
        int GetOutputMode3(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-7
        /// Original name: 116 '3 Output mode'
        /// </summary>
        void SetOutputMode3(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-3
        /// Original name: 117 '4 Output mode'
        /// </summary>
        int GetOutputMode4(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-3
        /// Original name: 117 '4 Output mode'
        /// </summary>
        void SetOutputMode4(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-8000
        /// Original name: 118 'Envelope gain'
        /// </summary>
        int GetEnvelopeGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-8000
        /// Original name: 118 'Envelope gain'
        /// </summary>
        void SetEnvelopeGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Used as a waveform where 'Custom' waveform type was applied.
        /// <br>
        /// <br> Write to curve 0 of Fmx.
        /// <br> The curve contains 256 values in range of -1 to 1.
        /// </summary>
        int WriteCurveCustomWaveform(float[] buffer);

        /// <summary>
        /// Used as a waveform where 'Custom' waveform type was applied.
        /// <br>
        /// <br> Read from curve 0 of Fmx.
        /// <br> The curve contains 256 values in range of -1 to 1.
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

        /// <inheritdoc cref="IFmxModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetPanning" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetPanning" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetSampleRate" />
        public FmxSampleRate GetSampleRate() => (FmxSampleRate)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.SetSampleRate" />
        public void SetSampleRate(FmxSampleRate value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.GetPolyphony" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetPolyphony" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetChannels" />
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.SetChannels" />
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.GetInputOperator" />
        public int GetInputOperator(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetInputOperator" />
        public void SetInputOperator(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetInputCustomWaveform" />
        public FmxCustomWaveform GetInputCustomWaveform() => (FmxCustomWaveform)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.SetInputCustomWaveform" />
        public void SetInputCustomWaveform(FmxCustomWaveform value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.GetAdsrSmoothTransitions" />
        public AdsrSmoothTransitions GetAdsrSmoothTransitions() => (AdsrSmoothTransitions)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.SetAdsrSmoothTransitions" />
        public void SetAdsrSmoothTransitions(AdsrSmoothTransitions value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmxModuleHandle.GetNoiseFilterOff32768" />
        public int GetNoiseFilterOff32768(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetNoiseFilterOff32768" />
        public void SetNoiseFilterOff32768(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetOutputMode1" />
        public int GetOutputMode1(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(114, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetOutputMode1" />
        public void SetOutputMode1(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(114, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetOutputMode2" />
        public int GetOutputMode2(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(115, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetOutputMode2" />
        public void SetOutputMode2(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(115, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetOutputMode3" />
        public int GetOutputMode3(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(116, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetOutputMode3" />
        public void SetOutputMode3(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(116, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetOutputMode4" />
        public int GetOutputMode4(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(117, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetOutputMode4" />
        public void SetOutputMode4(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(117, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.GetEnvelopeGain" />
        public int GetEnvelopeGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(118, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.SetEnvelopeGain" />
        public void SetEnvelopeGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(118, value, valueScalingMode);

        /// <inheritdoc cref="IFmxModuleHandle.ReadCurveCustomWaveform"
        public int ReadCurveCustomWaveform(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IFmxModuleHandle.WriteCurveCustomWaveform"
        public int WriteCurveCustomWaveform(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);
    }
}
#endif
