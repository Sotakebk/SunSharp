/*
 * IMPORTANT!
 * Do not modify this file manually. It was generated automatically by the CodeGeneration project.
*/

namespace SunSharp.ObjectWrapper.Modules
{
    #region enums

    public enum ADSRCurveType : ushort
    {
        Linear = 0,
        Exp1 = 1,
        Exp2 = 2,
        Nexp1 = 3,
        Nexp2 = 4,
        Sin = 5,
    }

    public enum ADSRMode : ushort
    {
        Generator = 0,
        AmplitudeModulatorMono = 1,
        AmplitudeModulatorStereo = 2,
    }

    public enum ADSROnNoteOffBehaviour : ushort
    {
        DoNothing = 0,
        StopOnLastNote = 1,
        Stop = 2,
    }

    public enum ADSROnNoteOnBehaviour : ushort
    {
        DoNothing = 0,
        StartOnFirstNote = 1,
        Start = 2,
    }

    public enum ADSRSmoothTransitions : ushort
    {
        Off = 0,
        RestartAndVolumeChange = 1,
        RestartAndVolumeChangeSmooth = 2,
        VolumeChange = 3,
    }

    public enum AnalogGeneratorEnvelopeMode : ushort
    {
        Off = 0,
        SustainOff = 1,
        SustainOn = 2,
    }

    public enum AnalogGeneratorFilterType : ushort
    {
        Off = 0,
        LP12dB = 1,
        HP12dB = 2,
        BP12dB = 3,
        BR12dB = 4,
        LP24dB = 5,
        HP24dB = 6,
        BP24dB = 7,
        BR24dB = 8,
    }

    public enum AnalogGeneratorOsc2Mode : ushort
    {
        Add = 0,
        Sub = 1,
        Mul = 2,
        Min = 3,
        Max = 4,
        BitwiseAnd = 5,
        BitwiseXor = 6,
    }

    public enum AnalogGeneratorWaveform : ushort
    {
        Triangle = 0,
        Saw = 1,
        Square = 2,
        NoiseSampler = 3,
        Drawn = 4,
        Sin = 5,
        Hsin = 6,
        Asin = 7,
        DrawnSpline = 8,
        NoiseSamplerSpline = 9,
        WhiteNoise = 10,
        PinkNoise = 11,
        RedNoise = 12,
        BlueNosie = 13,
        VioletNoise = 14,
        GreyNoise = 15,
        Harmonics = 16,
    }

    public enum Channels : ushort
    {
        Stereo = 0,
        Mono = 1,
    }

    public enum ChannelsInverted : ushort
    {
        Mono = 0,
        Stereo = 1,
    }

    public enum CompressorMode : ushort
    {
        Peak = 0,
        RMS = 1,
        PeakZeroLatency = 2,
    }

    public enum ControlToNoteOffBehaviour : ushort
    {
        Nothing = 0,
        OnMinPitch = 1,
        OnMaxPitch = 2,
    }

    public enum ControlToNoteOnBehaviour : ushort
    {
        Nothing = 0,
        OnPitchChange = 1,
    }

    public enum DelayUnit : ushort
    {
        SecondDivBy16384 = 0,
        Millisecond = 1,
        Hz = 2,
        Tick = 3,
        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
        SecondDivBy44100 = 7,
        SecondDivBy48000 = 8,
        Sample = 9,
    }

    public enum DistortionType : ushort
    {
        Clipping = 0,
        Foldback = 1,
        Foldback2 = 2,
        Foldback3 = 3,
        Overflow = 4,
        Overflow2 = 5,
    }

    public enum EchoFilter : ushort
    {
        Off = 0,
        LP6dB = 1,
        HP6dB = 2,
    }

    public enum FFTBufferOverlap : ushort
    {
        None = 0,
        x2 = 1,
        x4 = 2,
    }

    public enum FFTBufferSize : ushort
    {
        x64 = 0,
        x128 = 1,
        x256 = 2,
        x512 = 3,
        x1024 = 4,
        x2048 = 5,
        x4096 = 6,
        x8192 = 7,
    }

    public enum FFTSampleRate : ushort
    {
        Hz8000 = 0,
        Hz11025 = 1,
        Hz16000 = 2,
        Hz22050 = 3,
        Hz32000 = 4,
        Hz44100 = 5,
        Hz48000 = 6,
        Hz88200 = 7,
        Hz96000 = 8,
        Hz192000 = 9,
    }

    public enum FilterLFOFrequencyUnit : ushort
    {
        FiveHundredthHz = 0,
        Millisecond = 1,
        Hz = 2,
        Tick = 3,
        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
    }

    public enum FilterLFOWaveform : ushort
    {
        Sin = 0,
        Saw = 1,
        Saw2 = 2,
        Square = 3,
        Random = 4,
    }

    public enum FilterProMode : ushort
    {
        Stereo = 0,
        Mono = 1,
        StereoSmoothing = 2,
        MonoSmoothing = 3,
    }

    public enum FilterProRollOff : ushort
    {
        dB12 = 0,
        dB24 = 1,
        dB36 = 2,
        dB48 = 3,
    }

    public enum FilterProType : ushort
    {
        LP = 0,
        HP = 1,
        BPConstSkirtGain = 2,
        BPConstPeakGain = 3,
        Notch = 4,
        AllPass = 5,
        Peaking = 6,
        LowShelf = 7,
        HighShelf = 8,
        LP6dB = 9,
        HP6dB = 10,
    }

    public enum FilterRollOff : ushort
    {
        dB12 = 0,
        dB24 = 1,
        dB36 = 2,
        dB48 = 3,
    }

    public enum FilterType : ushort
    {
        LP = 0,
        HP = 1,
        BP = 2,
        Notch = 3,
    }

    public enum FlangerLFOFrequencyUnit : ushort
    {
        FiveHundredthHz = 0,
        Millisecond = 1,
        Hz = 2,
        Tick = 3,
        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
    }

    public enum FlangerLFOWaveform : ushort
    {
        Hsin = 0,
        Sin = 1,
    }

    public enum FMXModulationType : ushort
    {
        Phase = 0,
        Frequency = 1,
        Amplitude = 2,
        Add = 3,
        Sub = 4,
        Min = 5,
        Max = 6,
        And = 7,
        Xor = 8,
        PhasePlus = 9,
    }

    public enum FMXSustainMode : ushort
    {
        Off = 0,
        On = 1,
        Repeat = 2,
    }

    public enum FMXWaveform : ushort
    {
        Custom = 0,
        Triangle = 1,
        Triangle3 = 2,
        Saw = 3,
        Saw3 = 4,
        Square = 5,
        Sin = 6,
        Hsin = 7,
        Asin = 8,
        Sin3 = 9,
    }

    public enum GeneratorWaveform : ushort
    {
        Triangle = 0,
        Saw = 1,
        Square = 2,
        NoiseSampler = 3,
        Drawn = 4,
        Sin = 5,
        Hsin = 6,
        Asin = 7,
        Rsin = 8,
    }

    public enum KickerWaveform : ushort
    {
        Triangle = 0,
        Square = 1,
        Sin = 2,
    }

    public enum LFOSineQuality : ushort
    {
        Auto = 0,
        Low = 1,
        Middle = 2,
        High = 3,
    }

    public enum LFOSmoothTransitions : ushort
    {
        Off = 0,
        Waveform = 1,
    }

    public enum LFOType : ushort
    {
        Amplitude = 0,
        Panning = 1,
    }

    public enum LFOWaveform : ushort
    {
        Sin = 0,
        Square = 1,
        Sin2 = 2,
        Saw = 3,
        Saw2 = 4,
        Random = 5,
        Triangle = 6,
        RandomInterpolated = 7,
    }

    public enum LoopMode : ushort
    {
        Normal = 0,
        PingPong = 1,
    }

    public enum MetaModulePatternMode : ushort
    {
        Off = 0,
        OnRepeat = 1,
        OnNoRepeat = 2,
        OnRepeatEndless = 3,
        OnNoRepeatEndless = 4,
    }

    public enum ModulationType : ushort
    {
        Amplitude = 0,
        Phase = 1,
        PhaseAbsolute = 2,
    }

    public enum PitchDetectorAlgorithm : ushort
    {
        FastZeroCrossing = 0,
        Autocorrelation = 1,
        Cepstrum = 2,
    }

    public enum PitchDetectorAlgSampleRate : ushort
    {
        Hz12000 = 0,
        Hz24000 = 1,
        Hz44100 = 2,
    }

    public enum PitchShifterBypassMode : ushort
    {
        Off = 0,
        SlowTransition = 1,
        FastTransition = 2,
    }

    public enum PitchToControlMode : ushort
    {
        FrequencyHz = 0,
        Pitch = 1,
    }

    public enum PitchToControlOnNoteOff : ushort
    {
        DoNothing = 0,
        PitchDown = 1,
        PitchUp = 2,
    }

    public enum Quality : ushort
    {
        HQ = 0,
        HQMono = 1,
        LQ = 2,
        LQMono = 3,
    }

    public enum SamplerEnvelopeInterpolation : ushort
    {
        Off = 0,
        Linear = 1,
    }

    public enum SamplerInterpolation : ushort
    {
        Off = 0,
        Linear = 1,
        Spline = 2,
    }

    public enum SoundToControlMode : ushort
    {
        LQ = 0,
        HQ = 1,
    }

    public enum SpectraVoiceHarmonicType : ushort
    {
        Hsin = 0,
        Rect = 1,
        Org1 = 2,
        Org2 = 3,
        Org3 = 4,
        Org4 = 5,
        Sin = 6,
        Random = 7,
        Triangle1 = 8,
        Triangle2 = 9,
        Overtones1 = 10,
        Overtones2 = 11,
        Overtones3 = 12,
        Overtones4 = 13,
        Overtones1Plus = 14,
        Overtones2Plus = 15,
        Overtones3Plus = 16,
        Overtones4Plus = 17,
        Metal = 18,
    }

    public enum SpectraVoiceMode : ushort
    {
        HQ = 0,
        HQMono = 1,
        LQ = 2,
        LQMono = 3,
        HQSpline = 4,
    }

    public enum Toggle : ushort
    {
        Off = 0,
        On = 1,
    }

    public enum ToggleInverse : ushort
    {
        On = 0,
        Off = 1,
    }

    public enum VelocityToControlOnNoteOff : ushort
    {
        DoNothing = 0,
        VelocityDown = 1,
        VelocityUp = 2,
    }

    public enum VibratoFrequencyUnit : ushort
    {
        HzDividedBy64 = 0,
        Millisecond = 1,
        Hz = 2,
        Tick = 3,
        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
    }

    public enum VocalFilterVoiceType : ushort
    {
        Soprano = 0,
        Alto = 1,
        Tenor = 2,
        Bass = 3,
    }

    public enum VocalFilterVowel : ushort
    {
        A = 0,
        E = 1,
        I = 2,
        O = 3,
        U = 4,
    }

    #endregion enums

    public static class ModuleExtensions
    {
        public static ADSRModule AsADSRModule(this Module module) => new ADSRModule(module);

        public static AmplifierModule AsAmplifierModule(this Module module) => new AmplifierModule(module);

        public static AnalogGeneratorModule AsAnalogGeneratorModule(this Module module) => new AnalogGeneratorModule(module);

        public static CompressorModule AsCompressorModule(this Module module) => new CompressorModule(module);

        public static ControlToNoteModule AsControlToNoteModule(this Module module) => new ControlToNoteModule(module);

        public static DcBlockerModule AsDcBlockerModule(this Module module) => new DcBlockerModule(module);

        public static DelayModule AsDelayModule(this Module module) => new DelayModule(module);

        public static DistortionModule AsDistortionModule(this Module module) => new DistortionModule(module);

        public static DrumSynthModule AsDrumSynthModule(this Module module) => new DrumSynthModule(module);

        public static EchoModule AsEchoModule(this Module module) => new EchoModule(module);

        public static EQModule AsEQModule(this Module module) => new EQModule(module);

        public static FeedbackModule AsFeedbackModule(this Module module) => new FeedbackModule(module);

        public static FFTModule AsFFTModule(this Module module) => new FFTModule(module);

        public static FilterModule AsFilterModule(this Module module) => new FilterModule(module);

        public static FilterProModule AsFilterProModule(this Module module) => new FilterProModule(module);

        public static FlangerModule AsFlangerModule(this Module module) => new FlangerModule(module);

        public static FMModule AsFMModule(this Module module) => new FMModule(module);

        public static FMXModule AsFMXModule(this Module module) => new FMXModule(module);

        public static GeneratorModule AsGeneratorModule(this Module module) => new GeneratorModule(module);

        public static GlideModule AsGlideModule(this Module module) => new GlideModule(module);

        public static GPIOModule AsGPIOModule(this Module module) => new GPIOModule(module);

        public static InputModule AsInputModule(this Module module) => new InputModule(module);

        public static KickerModule AsKickerModule(this Module module) => new KickerModule(module);

        public static LFOModule AsLFOModule(this Module module) => new LFOModule(module);

        public static LoopModule AsLoopModule(this Module module) => new LoopModule(module);

        public static MetaModuleModule AsMetaModuleModule(this Module module) => new MetaModuleModule(module);

        public static ModulatorModule AsModulatorModule(this Module module) => new ModulatorModule(module);

        public static MultiControlModule AsMultiControlModule(this Module module) => new MultiControlModule(module);

        public static MultiSynthModule AsMultiSynthModule(this Module module) => new MultiSynthModule(module);

        public static OutputModule AsOutputModule(this Module module) => new OutputModule(module);

        public static PitchDetectorModule AsPitchDetectorModule(this Module module) => new PitchDetectorModule(module);

        public static PitchShifterModule AsPitchShifterModule(this Module module) => new PitchShifterModule(module);

        public static PitchToControlModule AsPitchToControlModule(this Module module) => new PitchToControlModule(module);

        public static ReverbModule AsReverbModule(this Module module) => new ReverbModule(module);

        public static SamplerModule AsSamplerModule(this Module module) => new SamplerModule(module);

        public static SoundToControlModule AsSoundToControlModule(this Module module) => new SoundToControlModule(module);

        public static SpectraVoiceModule AsSpectraVoiceModule(this Module module) => new SpectraVoiceModule(module);

        public static VelocityToControlModule AsVelocityToControlModule(this Module module) => new VelocityToControlModule(module);

        public static VibratoModule AsVibratoModule(this Module module) => new VibratoModule(module);

        public static VocalFilterModule AsVocalFilterModule(this Module module) => new VocalFilterModule(module);

        public static VorbisPlayerModule AsVorbisPlayerModule(this Module module) => new VorbisPlayerModule(module);

        public static WaveShaperModule AsWaveShaperModule(this Module module) => new WaveShaperModule(module);
    }

    public struct ADSRModule
    {
        public Module Module { get; private set; }

        public ADSRModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetAttack() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetAttackCurve() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetAttackCurve(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetDecay() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetDecayCurve() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetDecayCurve(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetMode(ushort value) => Module.SetControllerValue(13, (ushort)value);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetOnNoteOff() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetOnNoteOff(ushort value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: On NoteON
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetOnNoteOn() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: On NoteON
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetOnNoteOn(ushort value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetRelease() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetReleaseCurve() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetReleaseCurve(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetSmoothTransitions() => (ushort)Module.GetControllerValue(14, true);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetSmoothTransitions(ushort value) => Module.SetControllerValue(14, (ushort)value);

        /// <summary>
        /// Original name: State
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetState() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: State
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetState(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetSustain() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetSustain(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSustainLevel() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustainPedal() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustainPedal(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct AmplifierModule
    {
        public Module Module { get; private set; }

        public AmplifierModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Absolute
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetAbsolute() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Absolute
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetAbsolute(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Balance
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetBalance() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Balance
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBalance(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Bipolar DC Offset
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetBipolarDCOffset() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Bipolar DC Offset
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetBipolarDCOffset(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: DC Offset
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDCOffset() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: DC Offset
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDCOffset(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Fine volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFineVolume() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Fine volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFineVolume(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 5000 </para>
        /// </summary>
        public ushort GetGain() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 5000 </para>
        /// </summary>
        public void SetGain(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Inverse
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetInverse() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Inverse
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetInverse(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetStereoWidth() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetStereoWidth(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct AnalogGeneratorModule
    {
        public Module Module { get; private set; }

        public AnalogGeneratorModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetAttack() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAttack(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetDutyCycle() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetDutyCycle(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Exponential envelope
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetExponentialEnvelope() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Exponential envelope
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetExponentialEnvelope(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: F.attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFAttack() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: F.attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFAttack(ushort value) => Module.SetControllerValue(13, (ushort)value);

        /// <summary>
        /// Original name: F.envelope
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetFEnvelope() => (ushort)Module.GetControllerValue(15, true);

        /// <summary>
        /// Original name: F.envelope
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetFEnvelope(ushort value) => Module.SetControllerValue(15, (ushort)value);

        /// <summary>
        /// Original name: F.exponential freq
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetFExponentialFreq() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: F.exponential freq
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetFExponentialFreq(ushort value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public ushort GetFFreq() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetFFreq(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Filter
        /// <para> Value range: 0 to 8 </para>
        /// </summary>
        public ushort GetFilter() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Filter
        /// <para> Value range: 0 to 8 </para>
        /// </summary>
        public void SetFilter(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: F.release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFRelease() => (ushort)Module.GetControllerValue(14, true);

        /// <summary>
        /// Original name: F.release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFRelease(ushort value) => Module.SetControllerValue(14, (ushort)value);

        /// <summary>
        /// Original name: F.resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public ushort GetFResonance() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: F.resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public void SetFResonance(ushort value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(17, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetMode(ushort value) => Module.SetControllerValue(17, (ushort)value);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetNoise() => (ushort)Module.GetControllerValue(18, true);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetNoise(ushort value) => Module.SetControllerValue(18, (ushort)value);

        /// <summary>
        /// Original name: Osc2
        /// <para> Value range: 0 to 2000 </para>
        /// </summary>
        public ushort GetOsc2() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Osc2
        /// <para> Value range: 0 to 2000 </para>
        /// </summary>
        public void SetOsc2(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Osc2 mode
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public ushort GetOsc2Mode() => (ushort)Module.GetControllerValue(20, true);

        /// <summary>
        /// Original name: Osc2 mode
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public void SetOsc2Mode(ushort value) => Module.SetControllerValue(20, (ushort)value);

        /// <summary>
        /// Original name: Osc2 phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOsc2Phase() => (ushort)Module.GetControllerValue(21, true);

        /// <summary>
        /// Original name: Osc2 phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOsc2Phase(ushort value) => Module.SetControllerValue(21, (ushort)value);

        /// <summary>
        /// Original name: Osc2 volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOsc2Volume() => (ushort)Module.GetControllerValue(19, true);

        /// <summary>
        /// Original name: Osc2 volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOsc2Volume(ushort value) => Module.SetControllerValue(19, (ushort)value);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPanning() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPanning(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(16, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(16, (ushort)value);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetRelease() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetRelease(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Sustain
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustain() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Sustain
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustain(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Waveform
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public ushort GetWaveform() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Waveform
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public void SetWaveform(ushort value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read DrawnValues containing 32 values.
        /// <para> Value range: -1 to 1. </para>
        /// <para> Value range: Used for 'Drawn', 'DrawnSpline' and 'Harmonics'. </para>
        /// </summary>
        public void ReadDrawnValues(float[] buffer)
        {
            if (buffer.Length < 32)
                throw new System.ArgumentException("Buffer must be at least of size 32");

            Module.ReadModuleCurve(0, buffer);
        }

        /// <summary>
        /// Write DrawnValues containing 32 values.
        /// <para> Value range: -1 to 1. </para>
        /// <para> Value range: Used for 'Drawn', 'DrawnSpline' and 'Harmonics'. </para>
        /// </summary>
        public void WriteDrawnValues(float[] buffer)
        {
            if (buffer.Length < 32)
                throw new System.ArgumentException("Buffer must be at least of size 32");

            Module.WriteModuleCurve(0, buffer);
        }

        #endregion curves
    }

    public struct CompressorModule
    {
        public Module Module { get; private set; }

        public CompressorModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 500 </para>
        /// </summary>
        public ushort GetAttack() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 500 </para>
        /// </summary>
        public void SetAttack(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetMode(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public ushort GetRelease() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public void SetRelease(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Side-chain input
        /// <para> Value range: 0 to 32 </para>
        /// </summary>
        public ushort GetSideChainInput() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Side-chain input
        /// <para> Value range: 0 to 32 </para>
        /// </summary>
        public void SetSideChainInput(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Slope
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public ushort GetSlope() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Slope
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetSlope(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetThreshold() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetThreshold(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct ControlToNoteModule
    {
        public Module Module { get; private set; }

        public ControlToNoteModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetFinetune() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetFinetune(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public ushort GetFirstNote() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public void SetFirstNote(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: NoteOFF
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetNoteOff() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: NoteOFF
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetNoteOff(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: NoteON
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetNoteOn() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: NoteON
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetNoteOn(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetPitch() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPitch(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public ushort GetRangeNumberOfSemitones() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public void SetRangeNumberOfSemitones(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Record notes
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetRecordNotes() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Record notes
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetRecordNotes(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: State
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetState() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: State
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetState(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetTranspose() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetTranspose(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVelocity() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocity(ushort value) => Module.SetControllerValue(5, (ushort)value);

        #endregion controllers
    }

    public struct DcBlockerModule
    {
        public Module Module { get; private set; }

        public DcBlockerModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct DelayModule
    {
        public Module Module { get; private set; }

        public DelayModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Delay L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDelayL() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Delay L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelayL(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Delay multiplier
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetDelayMultiplier() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Delay multiplier
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDelayMultiplier(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Delay R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDelayR() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Delay R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelayR(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetDelayUnit() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDelayUnit(DelayUnit value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetDry() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetDry(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFeedback() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Inverse
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetInverse() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Inverse
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetInverse(Toggle value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Volume L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolumeL() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Volume L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeL(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Volume R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolumeR() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Volume R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeR(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetWet() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetWet(ushort value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct DistortionModule
    {
        public Module Module { get; private set; }

        public DistortionModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Bit depth
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public ushort GetBitDepth() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Bit depth
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetBitDepth(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Type
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetDistortionType() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Type
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetDistortionType(DistortionType value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 44100 </para>
        /// </summary>
        public ushort GetFreq() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 44100 </para>
        /// </summary>
        public void SetFreq(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetNoise() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetNoise(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPower() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPower(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct DrumSynthModule
    {
        public Module Module { get; private set; }

        public DrumSynthModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Bass length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetBassLength() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Bass length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassLength(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Bass panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetBassPanning() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: Bass panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassPanning(ushort value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: Bass power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetBassPower() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Bass power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassPower(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Bass tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetBassTone() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Bass tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassTone(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Bass volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetBassVolume() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Bass volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetBassVolume(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Hihat length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetHihatLength() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Hihat length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetHihatLength(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Hihat panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetHihatPanning() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: Hihat panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetHihatPanning(ushort value) => Module.SetControllerValue(13, (ushort)value);

        /// <summary>
        /// Original name: Hihat volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetHihatVolume() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Hihat volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetHihatVolume(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPanning() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPanning(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 8 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 8 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Snare length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSnareLength() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: Snare length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSnareLength(ushort value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Snare panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSnarePanning() => (ushort)Module.GetControllerValue(14, true);

        /// <summary>
        /// Original name: Snare panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSnarePanning(ushort value) => Module.SetControllerValue(14, (ushort)value);

        /// <summary>
        /// Original name: Snare tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSnareTone() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: Snare tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSnareTone(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Snare volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetSnareVolume() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Snare volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetSnareVolume(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct EchoModule
    {
        public Module Module { get; private set; }

        public EchoModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDelay() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelay(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetDelayUnit() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDelayUnit(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDry() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFeedback() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public ushort GetFFreq() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public void SetFFreq(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Filter
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetFilter() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Filter
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetFilter(EchoFilter value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetRightChannelOffset() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetRightChannelOffset(Toggle value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Value range: 0 to 32768 </para>
        /// <para> Delay/32768 </para>
        /// </summary>
        public ushort GetRightChannelOffsetDelay() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Value range: 0 to 32768 </para>
        /// <para> Delay/32768 </para>
        /// </summary>
        public void SetRightChannelOffsetDelay(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetWet() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(ushort value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct EQModule
    {
        public Module Module { get; private set; }

        public EQModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: High
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetHigh() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: High
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetHigh(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Low
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetLow() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Low
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetLow(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Middle
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetMiddle() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Middle
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMiddle(ushort value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct FeedbackModule
    {
        public Module Module { get; private set; }

        public FeedbackModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct FFTModule
    {
        public Module Module { get; private set; }

        public FFTModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetAllPassFilter() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetAllPassFilter(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Buffer (samples)
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public ushort GetBufferSamples() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Buffer (samples)
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public void SetBufferSamples(FFTBufferSize value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Buf overlap
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetBufOverlap() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Buf overlap
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetBufOverlap(FFTBufferOverlap value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Deform1
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetDeform1() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: Deform1
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDeform1(ushort value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: Deform2
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetDeform2() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: Deform2
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDeform2(ushort value) => Module.SetControllerValue(13, (ushort)value);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFeedback() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Freq shift
        /// <para> Value range: 0 to 8192 </para>
        /// </summary>
        public ushort GetFreqShift() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: Freq shift
        /// <para> Value range: 0 to 8192 </para>
        /// </summary>
        public void SetFreqShift(ushort value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Frequency spread
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFrequencySpread() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Frequency spread
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFrequencySpread(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: HP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetHPCutoff() => (ushort)Module.GetControllerValue(14, true);

        /// <summary>
        /// Original name: HP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetHPCutoff(ushort value) => Module.SetControllerValue(14, (ushort)value);

        /// <summary>
        /// Original name: LP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetLPCutoff() => (ushort)Module.GetControllerValue(15, true);

        /// <summary>
        /// Original name: LP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetLPCutoff(ushort value) => Module.SetControllerValue(15, (ushort)value);

        /// <summary>
        /// Original name: Noise reduction
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetNoiseReduction() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Noise reduction
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoiseReduction(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Phase gain (norm=16384)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetPhaseGainNorm16384() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Phase gain (norm=16384)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhaseGainNorm16384(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetRandomPhase() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhase(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Random phase (lite)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetRandomPhaseLite() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: Random phase (lite)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhaseLite(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetSampleRate() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetSampleRate(FFTSampleRate value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(16, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(16, (ushort)value);

        #endregion controllers
    }

    public struct FilterModule
    {
        public Module Module { get; private set; }

        public FilterModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetExponentialFreq() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetExponentialFreq(Toggle value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Type
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetFilterType() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Type
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetFilterType(FilterType value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public ushort GetFreq() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetFreq(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Impulse
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public ushort GetImpulse() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Impulse
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetImpulse(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetLFOAmp() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetLFOAmp(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetLFOFreq() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetLFOFreq(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public ushort GetLFOFreqUnit() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public void SetLFOFreqUnit(FilterLFOFrequencyUnit value) => Module.SetControllerValue(13, (ushort)value);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetLFOWaveform() => (ushort)Module.GetControllerValue(14, true);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetLFOWaveform(FilterLFOWaveform value) => Module.SetControllerValue(14, (ushort)value);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetMix() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMix(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public ushort GetResonance() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public void SetResonance(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetResponse() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetResponse(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetRollOff() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetRollOff(FilterRollOff value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSetLFOPhase() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct FilterProModule
    {
        public Module Module { get; private set; }

        public FilterProModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetExponentialFreq() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetExponentialFreq(Toggle value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Type
        /// <para> Value range: 0 to 10 </para>
        /// </summary>
        public ushort GetFilterType() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Type
        /// <para> Value range: 0 to 10 </para>
        /// </summary>
        public void SetFilterType(FilterProType value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public ushort GetFreq() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public void SetFreq(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Freq finetune
        /// <para> Value range: 0 to 2000 </para>
        /// </summary>
        public ushort GetFreqFinetune() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Freq finetune
        /// <para> Value range: 0 to 2000 </para>
        /// </summary>
        public void SetFreqFinetune(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public ushort GetFreqScale() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetFreqScale(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetGain() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetGain(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetLFOAmp() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetLFOAmp(ushort value) => Module.SetControllerValue(13, (ushort)value);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetLFOFreq() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetLFOFreq(ushort value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public ushort GetLFOFreqUnit() => (ushort)Module.GetControllerValue(16, true);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public void SetLFOFreqUnit(FilterLFOFrequencyUnit value) => Module.SetControllerValue(16, (ushort)value);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetLFOWaveform() => (ushort)Module.GetControllerValue(14, true);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetLFOWaveform(FilterLFOWaveform value) => Module.SetControllerValue(14, (ushort)value);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetMix() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetMix(ushort value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetMode(FilterProMode value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Q
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetQ() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Q
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetQ(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public ushort GetResponse() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetRollOff() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetRollOff(FilterProRollOff value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSetLFOPhase() => (ushort)Module.GetControllerValue(15, true);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(ushort value) => Module.SetControllerValue(15, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct FlangerModule
    {
        public Module Module { get; private set; }

        public FlangerModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 8 to 1000 </para>
        /// </summary>
        public ushort GetDelay() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 8 to 1000 </para>
        /// </summary>
        public void SetDelay(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDry() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFeedback() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetLFOAmp() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetLFOAmp(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetLFOFreq() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetLFOFreq(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public ushort GetLFOFreqUnit() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public void SetLFOFreqUnit(FlangerLFOFrequencyUnit value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetLFOWaveform() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetLFOWaveform(FlangerLFOWaveform value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetResponse() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetResponse(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSetLFOPhase() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetWet() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(ushort value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct FMModule
    {
        public Module Module { get; private set; }

        public FMModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: C.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetCAttack() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: C.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCAttack(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: C.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetCDecay() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: C.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCDecay(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: C.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public ushort GetCFreqRatio() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: C.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public void SetCFreqRatio(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: C.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetCRelease() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: C.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCRelease(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: C.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetCSustain() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: C.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCSustain(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: C.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetCVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: C.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: M.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetMAttack() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: M.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMAttack(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: M.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetMDecay() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: M.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMDecay(ushort value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: M.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public ushort GetMFreqRatio() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: M.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public void SetMFreqRatio(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(16, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(16, (ushort)value);

        /// <summary>
        /// Original name: M.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetMRelease() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: M.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMRelease(ushort value) => Module.SetControllerValue(13, (ushort)value);

        /// <summary>
        /// Original name: M.Scaling per key
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetMScalingPerKey() => (ushort)Module.GetControllerValue(14, true);

        /// <summary>
        /// Original name: M.Scaling per key
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetMScalingPerKey(ushort value) => Module.SetControllerValue(14, (ushort)value);

        /// <summary>
        /// Original name: M.Self-modulation
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetMSelfModulation() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: M.Self-modulation
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMSelfModulation(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: M.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetMSustain() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: M.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMSustain(ushort value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: M.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetMVolume() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: M.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMVolume(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPanning() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPanning(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(15, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(15, (ushort)value);

        #endregion controllers
    }

    public struct FMXModule
    {
        public Module Module { get; private set; }

        public FMXModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: ADSR smooth transitions
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetADSRSmoothTransitions() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: ADSR smooth transitions
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetADSRSmoothTransitions(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: 1 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetAttack1() => (ushort)Module.GetControllerValue(14, true);

        /// <summary>
        /// Original name: 1 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack1(ushort value) => Module.SetControllerValue(14, (ushort)value);

        /// <summary>
        /// Original name: 2 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetAttack2() => (ushort)Module.GetControllerValue(15, true);

        /// <summary>
        /// Original name: 2 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack2(ushort value) => Module.SetControllerValue(15, (ushort)value);

        /// <summary>
        /// Original name: 3 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetAttack3() => (ushort)Module.GetControllerValue(16, true);

        /// <summary>
        /// Original name: 3 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack3(ushort value) => Module.SetControllerValue(16, (ushort)value);

        /// <summary>
        /// Original name: 4 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetAttack4() => (ushort)Module.GetControllerValue(17, true);

        /// <summary>
        /// Original name: 4 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack4(ushort value) => Module.SetControllerValue(17, (ushort)value);

        /// <summary>
        /// Original name: 5 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetAttack5() => (ushort)Module.GetControllerValue(18, true);

        /// <summary>
        /// Original name: 5 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack5(ushort value) => Module.SetControllerValue(18, (ushort)value);

        /// <summary>
        /// Original name: 1 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetAttackCurve1() => (ushort)Module.GetControllerValue(34, true);

        /// <summary>
        /// Original name: 1 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetAttackCurve1(ADSRCurveType value) => Module.SetControllerValue(34, (ushort)value);

        /// <summary>
        /// Original name: 2 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetAttackCurve2() => (ushort)Module.GetControllerValue(35, true);

        /// <summary>
        /// Original name: 2 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetAttackCurve2(ADSRCurveType value) => Module.SetControllerValue(35, (ushort)value);

        /// <summary>
        /// Original name: 3 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetAttackCurve3() => (ushort)Module.GetControllerValue(36, true);

        /// <summary>
        /// Original name: 3 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetAttackCurve3(ADSRCurveType value) => Module.SetControllerValue(36, (ushort)value);

        /// <summary>
        /// Original name: 4 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetAttackCurve4() => (ushort)Module.GetControllerValue(37, true);

        /// <summary>
        /// Original name: 4 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetAttackCurve4(ADSRCurveType value) => Module.SetControllerValue(37, (ushort)value);

        /// <summary>
        /// Original name: 5 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetAttackCurve5() => (ushort)Module.GetControllerValue(38, true);

        /// <summary>
        /// Original name: 5 Attack curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetAttackCurve5(ADSRCurveType value) => Module.SetControllerValue(38, (ushort)value);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: 1 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public ushort GetConstantPitch1() => (ushort)Module.GetControllerValue(94, true);

        /// <summary>
        /// Original name: 1 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public void SetConstantPitch1(ushort value) => Module.SetControllerValue(94, (ushort)value);

        /// <summary>
        /// Original name: 2 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public ushort GetConstantPitch2() => (ushort)Module.GetControllerValue(95, true);

        /// <summary>
        /// Original name: 2 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public void SetConstantPitch2(ushort value) => Module.SetControllerValue(95, (ushort)value);

        /// <summary>
        /// Original name: 3 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public ushort GetConstantPitch3() => (ushort)Module.GetControllerValue(96, true);

        /// <summary>
        /// Original name: 3 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public void SetConstantPitch3(ushort value) => Module.SetControllerValue(96, (ushort)value);

        /// <summary>
        /// Original name: 4 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public ushort GetConstantPitch4() => (ushort)Module.GetControllerValue(97, true);

        /// <summary>
        /// Original name: 4 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public void SetConstantPitch4(ushort value) => Module.SetControllerValue(97, (ushort)value);

        /// <summary>
        /// Original name: 5 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public ushort GetConstantPitch5() => (ushort)Module.GetControllerValue(98, true);

        /// <summary>
        /// Original name: 5 Constant pitch
        /// <para> Value range: 0 to 16384 </para>
        /// </summary>
        public void SetConstantPitch5(ushort value) => Module.SetControllerValue(98, (ushort)value);

        /// <summary>
        /// Original name: 1 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetDecay1() => (ushort)Module.GetControllerValue(19, true);

        /// <summary>
        /// Original name: 1 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay1(ushort value) => Module.SetControllerValue(19, (ushort)value);

        /// <summary>
        /// Original name: 2 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetDecay2() => (ushort)Module.GetControllerValue(20, true);

        /// <summary>
        /// Original name: 2 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay2(ushort value) => Module.SetControllerValue(20, (ushort)value);

        /// <summary>
        /// Original name: 3 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetDecay3() => (ushort)Module.GetControllerValue(21, true);

        /// <summary>
        /// Original name: 3 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay3(ushort value) => Module.SetControllerValue(21, (ushort)value);

        /// <summary>
        /// Original name: 4 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetDecay4() => (ushort)Module.GetControllerValue(22, true);

        /// <summary>
        /// Original name: 4 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay4(ushort value) => Module.SetControllerValue(22, (ushort)value);

        /// <summary>
        /// Original name: 5 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetDecay5() => (ushort)Module.GetControllerValue(23, true);

        /// <summary>
        /// Original name: 5 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay5(ushort value) => Module.SetControllerValue(23, (ushort)value);

        /// <summary>
        /// Original name: 1 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetDecayCurve1() => (ushort)Module.GetControllerValue(39, true);

        /// <summary>
        /// Original name: 1 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetDecayCurve1(ADSRCurveType value) => Module.SetControllerValue(39, (ushort)value);

        /// <summary>
        /// Original name: 2 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetDecayCurve2() => (ushort)Module.GetControllerValue(40, true);

        /// <summary>
        /// Original name: 2 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetDecayCurve2(ADSRCurveType value) => Module.SetControllerValue(40, (ushort)value);

        /// <summary>
        /// Original name: 3 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetDecayCurve3() => (ushort)Module.GetControllerValue(41, true);

        /// <summary>
        /// Original name: 3 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetDecayCurve3(ADSRCurveType value) => Module.SetControllerValue(41, (ushort)value);

        /// <summary>
        /// Original name: 4 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetDecayCurve4() => (ushort)Module.GetControllerValue(42, true);

        /// <summary>
        /// Original name: 4 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetDecayCurve4(ADSRCurveType value) => Module.SetControllerValue(42, (ushort)value);

        /// <summary>
        /// Original name: 5 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetDecayCurve5() => (ushort)Module.GetControllerValue(43, true);

        /// <summary>
        /// Original name: 5 Decay curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetDecayCurve5(ADSRCurveType value) => Module.SetControllerValue(43, (ushort)value);

        /// <summary>
        /// Original name: Envelope gain
        /// <para> Value range: 0 to 8000 </para>
        /// </summary>
        public ushort GetEnvelopeGain() => (ushort)Module.GetControllerValue(118, true);

        /// <summary>
        /// Original name: Envelope gain
        /// <para> Value range: 0 to 8000 </para>
        /// </summary>
        public void SetEnvelopeGain(ushort value) => Module.SetControllerValue(118, (ushort)value);

        /// <summary>
        /// Original name: 1 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetEnvelopeScalingPerKey1() => (ushort)Module.GetControllerValue(59, true);

        /// <summary>
        /// Original name: 1 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey1(ushort value) => Module.SetControllerValue(59, (ushort)value);

        /// <summary>
        /// Original name: 2 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetEnvelopeScalingPerKey2() => (ushort)Module.GetControllerValue(60, true);

        /// <summary>
        /// Original name: 2 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey2(ushort value) => Module.SetControllerValue(60, (ushort)value);

        /// <summary>
        /// Original name: 3 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetEnvelopeScalingPerKey3() => (ushort)Module.GetControllerValue(61, true);

        /// <summary>
        /// Original name: 3 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey3(ushort value) => Module.SetControllerValue(61, (ushort)value);

        /// <summary>
        /// Original name: 4 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetEnvelopeScalingPerKey4() => (ushort)Module.GetControllerValue(62, true);

        /// <summary>
        /// Original name: 4 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey4(ushort value) => Module.SetControllerValue(62, (ushort)value);

        /// <summary>
        /// Original name: 5 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetEnvelopeScalingPerKey5() => (ushort)Module.GetControllerValue(63, true);

        /// <summary>
        /// Original name: 5 Envelope scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey5(ushort value) => Module.SetControllerValue(63, (ushort)value);

        /// <summary>
        /// Original name: 1 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFeedback1() => (ushort)Module.GetControllerValue(104, true);

        /// <summary>
        /// Original name: 1 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback1(ushort value) => Module.SetControllerValue(104, (ushort)value);

        /// <summary>
        /// Original name: 2 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFeedback2() => (ushort)Module.GetControllerValue(105, true);

        /// <summary>
        /// Original name: 2 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback2(ushort value) => Module.SetControllerValue(105, (ushort)value);

        /// <summary>
        /// Original name: 3 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFeedback3() => (ushort)Module.GetControllerValue(106, true);

        /// <summary>
        /// Original name: 3 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback3(ushort value) => Module.SetControllerValue(106, (ushort)value);

        /// <summary>
        /// Original name: 4 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFeedback4() => (ushort)Module.GetControllerValue(107, true);

        /// <summary>
        /// Original name: 4 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback4(ushort value) => Module.SetControllerValue(107, (ushort)value);

        /// <summary>
        /// Original name: 5 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFeedback5() => (ushort)Module.GetControllerValue(108, true);

        /// <summary>
        /// Original name: 5 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback5(ushort value) => Module.SetControllerValue(108, (ushort)value);

        /// <summary>
        /// Original name: 1 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public ushort GetFreqMultiply1() => (ushort)Module.GetControllerValue(89, true);

        /// <summary>
        /// Original name: 1 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply1(ushort value) => Module.SetControllerValue(89, (ushort)value);

        /// <summary>
        /// Original name: 2 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public ushort GetFreqMultiply2() => (ushort)Module.GetControllerValue(90, true);

        /// <summary>
        /// Original name: 2 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply2(ushort value) => Module.SetControllerValue(90, (ushort)value);

        /// <summary>
        /// Original name: 3 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public ushort GetFreqMultiply3() => (ushort)Module.GetControllerValue(91, true);

        /// <summary>
        /// Original name: 3 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply3(ushort value) => Module.SetControllerValue(91, (ushort)value);

        /// <summary>
        /// Original name: 4 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public ushort GetFreqMultiply4() => (ushort)Module.GetControllerValue(92, true);

        /// <summary>
        /// Original name: 4 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply4(ushort value) => Module.SetControllerValue(92, (ushort)value);

        /// <summary>
        /// Original name: 5 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public ushort GetFreqMultiply5() => (ushort)Module.GetControllerValue(93, true);

        /// <summary>
        /// Original name: 5 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply5(ushort value) => Module.SetControllerValue(93, (ushort)value);

        /// <summary>
        /// Original name: Input -> Custom waveform
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetInputCustomWaveform() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Input -> Custom waveform
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetInputCustomWaveform(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Input -> Operator #
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetInputOperatorNum() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Input -> Operator #
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetInputOperatorNum(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: 1 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetModulationType1() => (ushort)Module.GetControllerValue(109, true);

        /// <summary>
        /// Original name: 1 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetModulationType1(FMXModulationType value) => Module.SetControllerValue(109, (ushort)value);

        /// <summary>
        /// Original name: 2 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetModulationType2() => (ushort)Module.GetControllerValue(110, true);

        /// <summary>
        /// Original name: 2 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetModulationType2(FMXModulationType value) => Module.SetControllerValue(110, (ushort)value);

        /// <summary>
        /// Original name: 3 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetModulationType3() => (ushort)Module.GetControllerValue(111, true);

        /// <summary>
        /// Original name: 3 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetModulationType3(FMXModulationType value) => Module.SetControllerValue(111, (ushort)value);

        /// <summary>
        /// Original name: 4 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetModulationType4() => (ushort)Module.GetControllerValue(112, true);

        /// <summary>
        /// Original name: 4 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetModulationType4(FMXModulationType value) => Module.SetControllerValue(112, (ushort)value);

        /// <summary>
        /// Original name: 5 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetModulationType5() => (ushort)Module.GetControllerValue(113, true);

        /// <summary>
        /// Original name: 5 Modulation type
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetModulationType5(FMXModulationType value) => Module.SetControllerValue(113, (ushort)value);

        /// <summary>
        /// Original name: 1 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetNoise1() => (ushort)Module.GetControllerValue(79, true);

        /// <summary>
        /// Original name: 1 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise1(ushort value) => Module.SetControllerValue(79, (ushort)value);

        /// <summary>
        /// Original name: 2 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetNoise2() => (ushort)Module.GetControllerValue(80, true);

        /// <summary>
        /// Original name: 2 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise2(ushort value) => Module.SetControllerValue(80, (ushort)value);

        /// <summary>
        /// Original name: 3 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetNoise3() => (ushort)Module.GetControllerValue(81, true);

        /// <summary>
        /// Original name: 3 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise3(ushort value) => Module.SetControllerValue(81, (ushort)value);

        /// <summary>
        /// Original name: 4 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetNoise4() => (ushort)Module.GetControllerValue(82, true);

        /// <summary>
        /// Original name: 4 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise4(ushort value) => Module.SetControllerValue(82, (ushort)value);

        /// <summary>
        /// Original name: 5 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetNoise5() => (ushort)Module.GetControllerValue(83, true);

        /// <summary>
        /// Original name: 5 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise5(ushort value) => Module.SetControllerValue(83, (ushort)value);

        /// <summary>
        /// Original name: Noise filter (32768 - OFF)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetNoiseFilter() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Noise filter (32768 - OFF)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoiseFilter(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: 1 Output mode
        /// <para> Value range: 0 to 31 </para>
        /// </summary>
        public ushort GetOutputMode1() => (ushort)Module.GetControllerValue(114, true);

        /// <summary>
        /// Original name: 1 Output mode
        /// <para> Value range: 0 to 31 </para>
        /// </summary>
        public void SetOutputMode1(ushort value) => Module.SetControllerValue(114, (ushort)value);

        /// <summary>
        /// Original name: 2 Output mode
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public ushort GetOutputMode2() => (ushort)Module.GetControllerValue(115, true);

        /// <summary>
        /// Original name: 2 Output mode
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public void SetOutputMode2(ushort value) => Module.SetControllerValue(115, (ushort)value);

        /// <summary>
        /// Original name: 3 Output mode
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public ushort GetOutputMode3() => (ushort)Module.GetControllerValue(116, true);

        /// <summary>
        /// Original name: 3 Output mode
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public void SetOutputMode3(ushort value) => Module.SetControllerValue(116, (ushort)value);

        /// <summary>
        /// Original name: 4 Output mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetOutputMode4() => (ushort)Module.GetControllerValue(117, true);

        /// <summary>
        /// Original name: 4 Output mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetOutputMode4(ushort value) => Module.SetControllerValue(117, (ushort)value);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPanning() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPanning(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: 1 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetPhase1() => (ushort)Module.GetControllerValue(84, true);

        /// <summary>
        /// Original name: 1 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase1(ushort value) => Module.SetControllerValue(84, (ushort)value);

        /// <summary>
        /// Original name: 2 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetPhase2() => (ushort)Module.GetControllerValue(85, true);

        /// <summary>
        /// Original name: 2 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase2(ushort value) => Module.SetControllerValue(85, (ushort)value);

        /// <summary>
        /// Original name: 3 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetPhase3() => (ushort)Module.GetControllerValue(86, true);

        /// <summary>
        /// Original name: 3 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase3(ushort value) => Module.SetControllerValue(86, (ushort)value);

        /// <summary>
        /// Original name: 4 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetPhase4() => (ushort)Module.GetControllerValue(87, true);

        /// <summary>
        /// Original name: 4 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase4(ushort value) => Module.SetControllerValue(87, (ushort)value);

        /// <summary>
        /// Original name: 5 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetPhase5() => (ushort)Module.GetControllerValue(88, true);

        /// <summary>
        /// Original name: 5 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase5(ushort value) => Module.SetControllerValue(88, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: 1 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetRelease1() => (ushort)Module.GetControllerValue(29, true);

        /// <summary>
        /// Original name: 1 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease1(ushort value) => Module.SetControllerValue(29, (ushort)value);

        /// <summary>
        /// Original name: 2 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetRelease2() => (ushort)Module.GetControllerValue(30, true);

        /// <summary>
        /// Original name: 2 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease2(ushort value) => Module.SetControllerValue(30, (ushort)value);

        /// <summary>
        /// Original name: 3 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetRelease3() => (ushort)Module.GetControllerValue(31, true);

        /// <summary>
        /// Original name: 3 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease3(ushort value) => Module.SetControllerValue(31, (ushort)value);

        /// <summary>
        /// Original name: 4 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetRelease4() => (ushort)Module.GetControllerValue(32, true);

        /// <summary>
        /// Original name: 4 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease4(ushort value) => Module.SetControllerValue(32, (ushort)value);

        /// <summary>
        /// Original name: 5 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetRelease5() => (ushort)Module.GetControllerValue(33, true);

        /// <summary>
        /// Original name: 5 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease5(ushort value) => Module.SetControllerValue(33, (ushort)value);

        /// <summary>
        /// Original name: 1 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetReleaseCurve1() => (ushort)Module.GetControllerValue(44, true);

        /// <summary>
        /// Original name: 1 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetReleaseCurve1(ADSRCurveType value) => Module.SetControllerValue(44, (ushort)value);

        /// <summary>
        /// Original name: 2 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetReleaseCurve2() => (ushort)Module.GetControllerValue(45, true);

        /// <summary>
        /// Original name: 2 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetReleaseCurve2(ADSRCurveType value) => Module.SetControllerValue(45, (ushort)value);

        /// <summary>
        /// Original name: 3 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetReleaseCurve3() => (ushort)Module.GetControllerValue(46, true);

        /// <summary>
        /// Original name: 3 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetReleaseCurve3(ADSRCurveType value) => Module.SetControllerValue(46, (ushort)value);

        /// <summary>
        /// Original name: 4 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetReleaseCurve4() => (ushort)Module.GetControllerValue(47, true);

        /// <summary>
        /// Original name: 4 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetReleaseCurve4(ADSRCurveType value) => Module.SetControllerValue(47, (ushort)value);

        /// <summary>
        /// Original name: 5 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetReleaseCurve5() => (ushort)Module.GetControllerValue(48, true);

        /// <summary>
        /// Original name: 5 Release curve
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetReleaseCurve5(ADSRCurveType value) => Module.SetControllerValue(48, (ushort)value);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public ushort GetSampleRate() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 0 to 6 </para>
        /// </summary>
        public void SetSampleRate(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: 1 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSelfModulation1() => (ushort)Module.GetControllerValue(99, true);

        /// <summary>
        /// Original name: 1 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation1(ushort value) => Module.SetControllerValue(99, (ushort)value);

        /// <summary>
        /// Original name: 2 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSelfModulation2() => (ushort)Module.GetControllerValue(100, true);

        /// <summary>
        /// Original name: 2 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation2(ushort value) => Module.SetControllerValue(100, (ushort)value);

        /// <summary>
        /// Original name: 3 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSelfModulation3() => (ushort)Module.GetControllerValue(101, true);

        /// <summary>
        /// Original name: 3 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation3(ushort value) => Module.SetControllerValue(101, (ushort)value);

        /// <summary>
        /// Original name: 4 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSelfModulation4() => (ushort)Module.GetControllerValue(102, true);

        /// <summary>
        /// Original name: 4 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation4(ushort value) => Module.SetControllerValue(102, (ushort)value);

        /// <summary>
        /// Original name: 5 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSelfModulation5() => (ushort)Module.GetControllerValue(103, true);

        /// <summary>
        /// Original name: 5 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation5(ushort value) => Module.SetControllerValue(103, (ushort)value);

        /// <summary>
        /// Original name: 1 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetSustain1() => (ushort)Module.GetControllerValue(49, true);

        /// <summary>
        /// Original name: 1 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetSustain1(FMXSustainMode value) => Module.SetControllerValue(49, (ushort)value);

        /// <summary>
        /// Original name: 2 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetSustain2() => (ushort)Module.GetControllerValue(50, true);

        /// <summary>
        /// Original name: 2 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetSustain2(FMXSustainMode value) => Module.SetControllerValue(50, (ushort)value);

        /// <summary>
        /// Original name: 3 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetSustain3() => (ushort)Module.GetControllerValue(51, true);

        /// <summary>
        /// Original name: 3 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetSustain3(FMXSustainMode value) => Module.SetControllerValue(51, (ushort)value);

        /// <summary>
        /// Original name: 4 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetSustain4() => (ushort)Module.GetControllerValue(52, true);

        /// <summary>
        /// Original name: 4 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetSustain4(FMXSustainMode value) => Module.SetControllerValue(52, (ushort)value);

        /// <summary>
        /// Original name: 5 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetSustain5() => (ushort)Module.GetControllerValue(53, true);

        /// <summary>
        /// Original name: 5 Sustain
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetSustain5(FMXSustainMode value) => Module.SetControllerValue(53, (ushort)value);

        /// <summary>
        /// Original name: 1 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSustainLevel1() => (ushort)Module.GetControllerValue(24, true);

        /// <summary>
        /// Original name: 1 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel1(ushort value) => Module.SetControllerValue(24, (ushort)value);

        /// <summary>
        /// Original name: 2 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSustainLevel2() => (ushort)Module.GetControllerValue(25, true);

        /// <summary>
        /// Original name: 2 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel2(ushort value) => Module.SetControllerValue(25, (ushort)value);

        /// <summary>
        /// Original name: 3 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSustainLevel3() => (ushort)Module.GetControllerValue(26, true);

        /// <summary>
        /// Original name: 3 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel3(ushort value) => Module.SetControllerValue(26, (ushort)value);

        /// <summary>
        /// Original name: 4 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSustainLevel4() => (ushort)Module.GetControllerValue(27, true);

        /// <summary>
        /// Original name: 4 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel4(ushort value) => Module.SetControllerValue(27, (ushort)value);

        /// <summary>
        /// Original name: 5 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetSustainLevel5() => (ushort)Module.GetControllerValue(28, true);

        /// <summary>
        /// Original name: 5 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel5(ushort value) => Module.SetControllerValue(28, (ushort)value);

        /// <summary>
        /// Original name: 1 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustainPedal1() => (ushort)Module.GetControllerValue(54, true);

        /// <summary>
        /// Original name: 1 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustainPedal1(Toggle value) => Module.SetControllerValue(54, (ushort)value);

        /// <summary>
        /// Original name: 2 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustainPedal2() => (ushort)Module.GetControllerValue(55, true);

        /// <summary>
        /// Original name: 2 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustainPedal2(Toggle value) => Module.SetControllerValue(55, (ushort)value);

        /// <summary>
        /// Original name: 3 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustainPedal3() => (ushort)Module.GetControllerValue(56, true);

        /// <summary>
        /// Original name: 3 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustainPedal3(Toggle value) => Module.SetControllerValue(56, (ushort)value);

        /// <summary>
        /// Original name: 4 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustainPedal4() => (ushort)Module.GetControllerValue(57, true);

        /// <summary>
        /// Original name: 4 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustainPedal4(Toggle value) => Module.SetControllerValue(57, (ushort)value);

        /// <summary>
        /// Original name: 5 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustainPedal5() => (ushort)Module.GetControllerValue(58, true);

        /// <summary>
        /// Original name: 5 Sustain pedal
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustainPedal5(Toggle value) => Module.SetControllerValue(58, (ushort)value);

        /// <summary>
        /// Original name: 1 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVelocitySensitivity1() => (ushort)Module.GetControllerValue(69, true);

        /// <summary>
        /// Original name: 1 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocitySensitivity1(ushort value) => Module.SetControllerValue(69, (ushort)value);

        /// <summary>
        /// Original name: 2 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVelocitySensitivity2() => (ushort)Module.GetControllerValue(70, true);

        /// <summary>
        /// Original name: 2 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocitySensitivity2(ushort value) => Module.SetControllerValue(70, (ushort)value);

        /// <summary>
        /// Original name: 3 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVelocitySensitivity3() => (ushort)Module.GetControllerValue(71, true);

        /// <summary>
        /// Original name: 3 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocitySensitivity3(ushort value) => Module.SetControllerValue(71, (ushort)value);

        /// <summary>
        /// Original name: 4 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVelocitySensitivity4() => (ushort)Module.GetControllerValue(72, true);

        /// <summary>
        /// Original name: 4 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocitySensitivity4(ushort value) => Module.SetControllerValue(72, (ushort)value);

        /// <summary>
        /// Original name: 5 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVelocitySensitivity5() => (ushort)Module.GetControllerValue(73, true);

        /// <summary>
        /// Original name: 5 Velocity sensitivity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocitySensitivity5(ushort value) => Module.SetControllerValue(73, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: 1 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume1() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: 1 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume1(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: 2 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume2() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: 2 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume2(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: 3 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume3() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: 3 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume3(ushort value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: 4 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume4() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: 4 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume4(ushort value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: 5 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetVolume5() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: 5 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume5(ushort value) => Module.SetControllerValue(13, (ushort)value);

        /// <summary>
        /// Original name: 1 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolumeScalingPerKey1() => (ushort)Module.GetControllerValue(64, true);

        /// <summary>
        /// Original name: 1 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeScalingPerKey1(ushort value) => Module.SetControllerValue(64, (ushort)value);

        /// <summary>
        /// Original name: 2 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolumeScalingPerKey2() => (ushort)Module.GetControllerValue(65, true);

        /// <summary>
        /// Original name: 2 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeScalingPerKey2(ushort value) => Module.SetControllerValue(65, (ushort)value);

        /// <summary>
        /// Original name: 3 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolumeScalingPerKey3() => (ushort)Module.GetControllerValue(66, true);

        /// <summary>
        /// Original name: 3 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeScalingPerKey3(ushort value) => Module.SetControllerValue(66, (ushort)value);

        /// <summary>
        /// Original name: 4 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolumeScalingPerKey4() => (ushort)Module.GetControllerValue(67, true);

        /// <summary>
        /// Original name: 4 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeScalingPerKey4(ushort value) => Module.SetControllerValue(67, (ushort)value);

        /// <summary>
        /// Original name: 5 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolumeScalingPerKey5() => (ushort)Module.GetControllerValue(68, true);

        /// <summary>
        /// Original name: 5 Volume scaling per key
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeScalingPerKey5(ushort value) => Module.SetControllerValue(68, (ushort)value);

        /// <summary>
        /// Original name: 1 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetWaveform1() => (ushort)Module.GetControllerValue(74, true);

        /// <summary>
        /// Original name: 1 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetWaveform1(FMXWaveform value) => Module.SetControllerValue(74, (ushort)value);

        /// <summary>
        /// Original name: 2 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetWaveform2() => (ushort)Module.GetControllerValue(75, true);

        /// <summary>
        /// Original name: 2 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetWaveform2(FMXWaveform value) => Module.SetControllerValue(75, (ushort)value);

        /// <summary>
        /// Original name: 3 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetWaveform3() => (ushort)Module.GetControllerValue(76, true);

        /// <summary>
        /// Original name: 3 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetWaveform3(FMXWaveform value) => Module.SetControllerValue(76, (ushort)value);

        /// <summary>
        /// Original name: 4 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetWaveform4() => (ushort)Module.GetControllerValue(77, true);

        /// <summary>
        /// Original name: 4 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetWaveform4(FMXWaveform value) => Module.SetControllerValue(77, (ushort)value);

        /// <summary>
        /// Original name: 5 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public ushort GetWaveform5() => (ushort)Module.GetControllerValue(78, true);

        /// <summary>
        /// Original name: 5 Waveform
        /// <para> Value range: 0 to 9 </para>
        /// </summary>
        public void SetWaveform5(FMXWaveform value) => Module.SetControllerValue(78, (ushort)value);

        #endregion controllers
    }

    public struct GeneratorModule
    {
        public Module Module { get; private set; }

        public GeneratorModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetAttack() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1022 </para>
        /// </summary>
        public ushort GetDutyCycle() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1022 </para>
        /// </summary>
        public void SetDutyCycle(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Freq.modulation by input
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFreqModulationByInput() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Freq.modulation by input
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFreqModulationByInput(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetMode(Channels value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPanning() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPanning(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetRelease() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Sustain
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustain() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Sustain
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustain(Toggle value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Waveform
        /// <para> Value range: 0 to 8 </para>
        /// </summary>
        public ushort GetWaveform() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Waveform
        /// <para> Value range: 0 to 8 </para>
        /// </summary>
        public void SetWaveform(GeneratorWaveform value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct GlideModule
    {
        public Module Module { get; private set; }

        public GlideModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 1200 </para>
        /// </summary>
        public ushort GetPitch() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 1200 </para>
        /// </summary>
        public void SetPitch(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public ushort GetPitchScale() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetPitchScale(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetPolyphony(Toggle value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Reset
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetReset() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Reset
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetReset(Toggle value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Reset on 1st note
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetResetOnFirstNote() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Reset on 1st note
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetResetOnFirstNote(Toggle value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public ushort GetResponse() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public ushort GetSampleRate() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(ushort value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct GPIOModule
    {
        public Module Module { get; private set; }

        public GPIOModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: In
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetIn() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: In
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetIn(Toggle value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: In amplitude
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public ushort GetInAmplitude() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: In amplitude
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetInAmplitude(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: In note
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public ushort GetInNote() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: In note
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public void SetInNote(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: In pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetInPin() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: In pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetInPin(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Out
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetOut() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Out
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetOut(Toggle value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Out pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetOutPin() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Out pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetOutPin(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Out threshold
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public ushort GetOutThreshold() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Out threshold
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetOutThreshold(ushort value) => Module.SetControllerValue(2, (ushort)value);

        #endregion controllers
    }

    public struct InputModule
    {
        public Module Module { get; private set; }

        public InputModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct KickerModule
    {
        public Module Module { get; private set; }

        public KickerModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Acceleration
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetAcceleration() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Acceleration
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetAcceleration(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetAttack() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Boost
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetBoost() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Boost
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetBoost(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: No click
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetNoClick() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: No click
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetNoClick(Toggle value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPanning() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPanning(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetRelease() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Waveform
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetWaveform() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Waveform
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetWaveform(KickerWaveform value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct LFOModule
    {
        public Module Module { get; private set; }

        public LFOModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetAmplitude() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAmplitude(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDutyCycle() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDutyCycle(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public ushort GetFreq() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public void SetFreq(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public ushort GetFreqScale() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetFreqScale(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFrequencyUnit() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFrequencyUnit(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Generator
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetGenerator() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Generator
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetGenerator(Toggle value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Type
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetLfoType() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Type
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetLfoType(LFOType value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSetPhase() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetPhase(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Sine quality
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetSineQuality() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: Sine quality
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetSineQuality(LFOSineQuality value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSmoothTransitions() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSmoothTransitions(LFOSmoothTransitions value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Waveform
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public ushort GetWaveform() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Waveform
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public void SetWaveform(LFOWaveform value) => Module.SetControllerValue(4, (ushort)value);

        #endregion controllers
    }

    public struct LoopModule
    {
        public Module Module { get; private set; }

        public LoopModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDelay() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelay(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetMode(LoopMode value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Repeats
        /// <para> Value range: 0 to 64 </para>
        /// </summary>
        public ushort GetRepeats() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Repeats
        /// <para> Value range: 0 to 64 </para>
        /// </summary>
        public void SetRepeats(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct MetaModuleModule
    {
        public Module Module { get; private set; }

        public MetaModuleModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: BPM (Beats Per Minute)
        /// <para> Value range: 125 to 32768 </para>
        /// </summary>
        public ushort GetBPM() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: BPM (Beats Per Minute)
        /// <para> Value range: 125 to 32768 </para>
        /// </summary>
        public void SetBPM(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Input module
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public ushort GetInputModule() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Input module
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public void SetInputModule(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Play patterns
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetPlayPatterns() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Play patterns
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetPlayPatterns(MetaModulePatternMode value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: TPL (Ticks Per Line)
        /// <para> Value range: 6 to 7 </para>
        /// </summary>
        public ushort GetTPL() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: TPL (Ticks Per Line)
        /// <para> Value range: 6 to 7 </para>
        /// </summary>
        public void SetTPL(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct ModulatorModule
    {
        public Module Module { get; private set; }

        public ModulatorModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Modulation type
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetModulationType() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Modulation type
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetModulationType(ModulationType value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct MultiControlModule
    {
        public Module Module { get; private set; }

        public MultiControlModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetGain() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetGain(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOUTOffset() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTOffset(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Quantization
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetQuantization() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Quantization
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetQuantization(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public ushort GetResponse() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public ushort GetSampleRate() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Value
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetValue() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Value
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetValue(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read Curve containing 257 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Value range: Modifies applied values. </para>
        /// </summary>
        public void ReadCurve(float[] buffer)
        {
            if (buffer.Length < 257)
                throw new System.ArgumentException("Buffer must be at least of size 257");

            Module.ReadModuleCurve(0, buffer);
        }

        /// <summary>
        /// Write Curve containing 257 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Value range: Modifies applied values. </para>
        /// </summary>
        public void WriteCurve(float[] buffer)
        {
            if (buffer.Length < 257)
                throw new System.ArgumentException("Buffer must be at least of size 257");

            Module.WriteModuleCurve(0, buffer);
        }

        #endregion curves
    }

    public struct MultiSynthModule
    {
        public Module Module { get; private set; }

        public MultiSynthModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Curve2 influence
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetCurve2Influence() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Curve2 influence
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCurve2Influence(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetFinetune() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetFinetune(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetPhase() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetRandomPhase() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhase(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Random pitch
        /// <para> Value range: 0 to 4096 </para>
        /// </summary>
        public ushort GetRandomPitch() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Random pitch
        /// <para> Value range: 0 to 4096 </para>
        /// </summary>
        public void SetRandomPitch(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Random velocity
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetRandomVelocity() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Random velocity
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomVelocity(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetTranspose() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetTranspose(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVelocity() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocity(ushort value) => Module.SetControllerValue(2, (ushort)value);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read NoteVelocityCurve containing 128 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Value range: Velocity to apply to arriving note. </para>
        /// </summary>
        public void ReadNoteVelocityCurve(float[] buffer)
        {
            if (buffer.Length < 128)
                throw new System.ArgumentException("Buffer must be at least of size 128");

            Module.ReadModuleCurve(0, buffer);
        }

        /// <summary>
        /// Write NoteVelocityCurve containing 128 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Value range: Velocity to apply to arriving note. </para>
        /// </summary>
        public void WriteNoteVelocityCurve(float[] buffer)
        {
            if (buffer.Length < 128)
                throw new System.ArgumentException("Buffer must be at least of size 128");

            Module.WriteModuleCurve(0, buffer);
        }

        /// <summary>
        /// Read VelocityToVelocityCurve containing 257 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Value range: Map velocity values. </para>
        /// </summary>
        public void ReadVelocityToVelocityCurve(float[] buffer)
        {
            if (buffer.Length < 257)
                throw new System.ArgumentException("Buffer must be at least of size 257");

            Module.ReadModuleCurve(1, buffer);
        }

        /// <summary>
        /// Write VelocityToVelocityCurve containing 257 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Value range: Map velocity values. </para>
        /// </summary>
        public void WriteVelocityToVelocityCurve(float[] buffer)
        {
            if (buffer.Length < 257)
                throw new System.ArgumentException("Buffer must be at least of size 257");

            Module.WriteModuleCurve(1, buffer);
        }

        #endregion curves
    }

    public struct OutputModule
    {
        public Module Module { get; private set; }

        public OutputModule(Module module)
        {
            Module = module;
        }
    }

    public struct PitchDetectorModule
    {
        public Module Module { get; private set; }

        public PitchDetectorModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Alg1 Sensitivity (absolute threshold)
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public ushort GetAlg1Sensitivity() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: Alg1 Sensitivity (absolute threshold)
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetAlg1Sensitivity(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Alg1-2 Buffer (ms)
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetAlgBufferMs() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Alg1-2 Buffer (ms)
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetAlgBufferMs(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Alg1-2 Buf overlap
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public ushort GetAlgBufOverlap() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Alg1-2 Buf overlap
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetAlgBufOverlap(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Algorithm
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetAlgorithm() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Algorithm
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetAlgorithm(PitchDetectorAlgorithm value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Alg1-2 Sample rate (Hz)
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetAlgSampleRateHz() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Alg1-2 Sample rate (Hz)
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetAlgSampleRateHz(PitchDetectorAlgSampleRate value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Detector finetune
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetDetectorFinetune() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Detector finetune
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetDetectorFinetune(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetGain() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetGain(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: LP filter freq (0 - OFF)
        /// <para> Value range: 0 to 4000 </para>
        /// </summary>
        public ushort GetLPFilterFreq() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: LP filter freq (0 - OFF)
        /// <para> Value range: 0 to 4000 </para>
        /// </summary>
        public void SetLPFilterFreq(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: LP filter roll-off
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetLPFilterRollOff() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: LP filter roll-off
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetLPFilterRollOff(FilterRollOff value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Microtones
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetMicrotones() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Microtones
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetMicrotones(Toggle value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Record notes
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetRecordNotes() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: Record notes
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetRecordNotes(Toggle value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetThreshold() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetThreshold(ushort value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct PitchShifterModule
    {
        public Module Module { get; private set; }

        public PitchShifterModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Bypass if pitch=0
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetBypassIfPitchZero() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Bypass if pitch=0
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetBypassIfPitchZero(PitchShifterBypassMode value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFeedback() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Grain size
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetGrainSize() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Grain size
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetGrainSize(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 1200 </para>
        /// </summary>
        public ushort GetPitch() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 1200 </para>
        /// </summary>
        public void SetPitch(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public ushort GetPitchScale() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetPitchScale(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct PitchToControlModule
    {
        public Module Module { get; private set; }

        public PitchToControlModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFirstNote() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFirstNote(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetMode(PitchToControlMode value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetOnNoteOff() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetOnNoteOff(PitchToControlOnNoteOff value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public ushort GetOUTController() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOUTController(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOUTMax() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTMax(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOUTMin() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTMin(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetRangeNumberOfSemitones() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetRangeNumberOfSemitones(ushort value) => Module.SetControllerValue(3, (ushort)value);

        #endregion controllers
    }

    public struct ReverbModule
    {
        public Module Module { get; private set; }

        public ReverbModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetAllPassFilter() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetAllPassFilter(Toggle value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Damp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDamp() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Damp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDamp(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetDry() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFeedback() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Freeze
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetFreeze() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Freeze
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetFreeze(Toggle value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetRandomSeed() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomSeed(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Room size
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public ushort GetRoomSize() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Room size
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public void SetRoomSize(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetStereoWidth() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetStereoWidth(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetWet() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(ushort value) => Module.SetControllerValue(1, (ushort)value);

        #endregion controllers
    }

    public struct SamplerModule
    {
        public Module Module { get; private set; }

        public SamplerModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Envelope interpolation
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetEnvelopeInterpolation() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Envelope interpolation
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetEnvelopeInterpolation(SamplerEnvelopeInterpolation value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPanning() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPanning(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Rec threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public ushort GetRecThreshold() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Rec threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRecThreshold(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Sample interpolation
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetSampleInterpolation() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Sample interpolation
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetSampleInterpolation(SamplerInterpolation value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct SoundToControlModule
    {
        public Module Module { get; private set; }

        public SoundToControlModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Absolute
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetAbsolute() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Absolute
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetAbsolute(Toggle value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetGain() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetGain(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetMode(SoundToControlMode value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public ushort GetOUTController() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOUTController(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOUTMax() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTMax(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOUTMin() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTMin(ushort value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public ushort GetSampleRate() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Smooth
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSmooth() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Smooth
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSmooth(ushort value) => Module.SetControllerValue(4, (ushort)value);

        #endregion controllers
    }

    public struct SpectraVoiceModule
    {
        public Module Module { get; private set; }

        public SpectraVoiceModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetAttack() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Harmonic
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetHarmonic() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Harmonic
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetHarmonic(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: H.freq
        /// <para> Value range: 0 to 22050 </para>
        /// </summary>
        public ushort GetHarmonicFreq() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: H.freq
        /// <para> Value range: 0 to 22050 </para>
        /// </summary>
        public void SetHarmonicFreq(ushort value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: H.type
        /// <para> Value range: 0 to 18 </para>
        /// </summary>
        public ushort GetHarmonicType() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: H.type
        /// <para> Value range: 0 to 18 </para>
        /// </summary>
        public void SetHarmonicType(SpectraVoiceHarmonicType value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: H.volume
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public ushort GetHarmonicVolume() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: H.volume
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetHarmonicVolume(ushort value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: H.width
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public ushort GetHarmonicWidth() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: H.width
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetHarmonicWidth(ushort value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetMode(SpectraVoiceMode value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetPanning() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPanning(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetRelease() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Spectrum resolution
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public ushort GetSpectrumResolution() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Spectrum resolution
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetSpectrumResolution(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Sustain
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSustain() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Sustain
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSustain(Toggle value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct VelocityToControlModule
    {
        public Module Module { get; private set; }

        public VelocityToControlModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public ushort GetOnNoteOff() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Value range: 0 to 2 </para>
        /// </summary>
        public void SetOnNoteOff(VelocityToControlOnNoteOff value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public ushort GetOutController() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOutController(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOutMax() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMax(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOutMin() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMin(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetOutOffset() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutOffset(ushort value) => Module.SetControllerValue(3, (ushort)value);

        #endregion controllers
    }

    public struct VibratoModule
    {
        public Module Module { get; private set; }

        public VibratoModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetAmplitude() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAmplitude(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Exponential amplitude
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetExponentialAmplitude() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Exponential amplitude
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetExponentialAmplitude(Toggle value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 2048 </para>
        /// </summary>
        public ushort GetFreq() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 2048 </para>
        /// </summary>
        public void SetFreq(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetFrequencyUnit() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFrequencyUnit(VibratoFrequencyUnit value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetSetPhase() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetPhase(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct VocalFilterModule
    {
        public Module Module { get; private set; }

        public VocalFilterModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetChannels() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Channels
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Formants
        /// <para> Value range: 1 to 5 </para>
        /// </summary>
        public ushort GetFormants() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Formants
        /// <para> Value range: 1 to 5 </para>
        /// </summary>
        public void SetFormants(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Formant width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetFormantWidth() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Formant width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFormantWidth(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Intensity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetIntensity() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Intensity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetIntensity(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Random frequency
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public ushort GetRandomFrequency() => (ushort)Module.GetControllerValue(7, true);

        /// <summary>
        /// Original name: Random frequency
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetRandomFrequency(ushort value) => Module.SetControllerValue(7, (ushort)value);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public ushort GetRandomSeed() => (ushort)Module.GetControllerValue(8, true);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomSeed(ushort value) => Module.SetControllerValue(8, (ushort)value);

        /// <summary>
        /// Original name: Voice type
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetVoiceType() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Voice type
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetVoiceType(VocalFilterVoiceType value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Vowel (a,e,i,o,u)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetVowel() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Vowel (a,e,i,o,u)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVowel(ushort value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Vowel1
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetVowel1() => (ushort)Module.GetControllerValue(9, true);

        /// <summary>
        /// Original name: Vowel1
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetVowel1(VocalFilterVowel value) => Module.SetControllerValue(9, (ushort)value);

        /// <summary>
        /// Original name: Vowel2
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetVowel2() => (ushort)Module.GetControllerValue(10, true);

        /// <summary>
        /// Original name: Vowel2
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetVowel2(VocalFilterVowel value) => Module.SetControllerValue(10, (ushort)value);

        /// <summary>
        /// Original name: Vowel3
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetVowel3() => (ushort)Module.GetControllerValue(11, true);

        /// <summary>
        /// Original name: Vowel3
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetVowel3(VocalFilterVowel value) => Module.SetControllerValue(11, (ushort)value);

        /// <summary>
        /// Original name: Vowel4
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetVowel4() => (ushort)Module.GetControllerValue(12, true);

        /// <summary>
        /// Original name: Vowel4
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetVowel4(VocalFilterVowel value) => Module.SetControllerValue(12, (ushort)value);

        /// <summary>
        /// Original name: Vowel5
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public ushort GetVowel5() => (ushort)Module.GetControllerValue(13, true);

        /// <summary>
        /// Original name: Vowel5
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetVowel5(VocalFilterVowel value) => Module.SetControllerValue(13, (ushort)value);

        #endregion controllers
    }

    public struct VorbisPlayerModule
    {
        public Module Module { get; private set; }

        public VorbisPlayerModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public ushort GetFinetune() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetFinetune(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Interpolation
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetInterpolation() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Interpolation
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetInterpolation(Toggle value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Original speed
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetOriginalSpeed() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Original speed
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetOriginalSpeed(Toggle value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public ushort GetPolyphony() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public void SetPolyphony(ushort value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Repeat
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetRepeat() => (ushort)Module.GetControllerValue(6, true);

        /// <summary>
        /// Original name: Repeat
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetRepeat(Toggle value) => Module.SetControllerValue(6, (ushort)value);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetTranspose() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetTranspose(ushort value) => Module.SetControllerValue(3, (ushort)value);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        #endregion controllers
    }

    public struct WaveShaperModule
    {
        public Module Module { get; private set; }

        public WaveShaperModule(Module module)
        {
            Module = module;
        }

        #region controllers

        /// <summary>
        /// Original name: DC blocker
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetDCBlocker() => (ushort)Module.GetControllerValue(5, true);

        /// <summary>
        /// Original name: DC blocker
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetDCBlocker(Toggle value) => Module.SetControllerValue(5, (ushort)value);

        /// <summary>
        /// Original name: Input volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetInputVolume() => (ushort)Module.GetControllerValue(0, true);

        /// <summary>
        /// Original name: Input volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetInputVolume(ushort value) => Module.SetControllerValue(0, (ushort)value);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public ushort GetMix() => (ushort)Module.GetControllerValue(1, true);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMix(ushort value) => Module.SetControllerValue(1, (ushort)value);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public ushort GetMode() => (ushort)Module.GetControllerValue(4, true);

        /// <summary>
        /// Original name: Mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(4, (ushort)value);

        /// <summary>
        /// Original name: Output volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public ushort GetOutputVolume() => (ushort)Module.GetControllerValue(2, true);

        /// <summary>
        /// Original name: Output volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetOutputVolume(ushort value) => Module.SetControllerValue(2, (ushort)value);

        /// <summary>
        /// Original name: Symmetric
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public ushort GetSymmetric() => (ushort)Module.GetControllerValue(3, true);

        /// <summary>
        /// Original name: Symmetric
        /// <para> Value range: 0 to 1 </para>
        /// </summary>
        public void SetSymmetric(Toggle value) => Module.SetControllerValue(3, (ushort)value);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read Curve containing 256 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Value range: Maps input to output. </para>
        /// </summary>
        public void ReadCurve(float[] buffer)
        {
            if (buffer.Length < 256)
                throw new System.ArgumentException("Buffer must be at least of size 256");

            Module.ReadModuleCurve(0, buffer);
        }

        /// <summary>
        /// Write Curve containing 256 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Value range: Maps input to output. </para>
        /// </summary>
        public void WriteCurve(float[] buffer)
        {
            if (buffer.Length < 256)
                throw new System.ArgumentException("Buffer must be at least of size 256");

            Module.WriteModuleCurve(0, buffer);
        }

        #endregion curves
    }
}
