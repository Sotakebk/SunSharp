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
        Rect = 6,
        SmoothRect = 7,
        Bit2 = 8,
        Bit3 = 9,
        Bit4 = 10,
        Bit5 = 11,
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

    public enum ADSRSustainMode : ushort
    {
        Off = 0,
        On = 1,
        Repeat = 2,
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
        SaturationFoldback = 6,
        SaturationFoldbackSin = 7,
        Saturation3 = 8,
        Saturation4 = 9,
        Saturation5 = 10,
    }

    public enum EchoDelayUnit : ushort
    {
        SecondDivBy256 = 0,
        Millisecond = 1,
        Hz = 2,
        Tick = 3,
        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
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

    public enum FMXCustomWaveform : ushort
    {
        Off = 0,
        SingleCycle = 1,
        Continuous = 2,
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

    public enum FMXSampleRate : ushort
    {
        Hz8000 = 0,
        Hz11025 = 1,
        Hz16000 = 2,
        Hz22050 = 3,
        Hz32000 = 4,
        Hz44100 = 5,
        Native = 6,
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

    public enum LFOFrequencyUnit : ushort
    {
        HzDividedBy64 = 0,
        Millisecond = 1,
        Hz = 2,
        Tick = 3,
        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
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

    public enum LoopTimeUnit : ushort
    {
        LineDivBy128 = 0,
        Line = 1,
        HalfLine = 2,
        OneThirdLine = 3,
        Tick = 4,
        Millisecond = 5,
        Hz = 6,
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

    public enum PitchDetectorBufferSize : ushort
    {
        Ms5 = 0,
        Ms10 = 1,
        Ms21 = 2,
        Ms42 = 3,
        Ms85 = 4,
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

    public enum SpectraVoiceResolution : ushort
    {
        Size4096 = 0,
        Size8192 = 1,
        Size16384 = 2,
        Size32768 = 3,
        Size65536 = 4,
        Size131072 = 5,
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
        public static ADSRModuleHandle AsADSR(this ModuleHandle module) => new ADSRModuleHandle(module);

        public static AmplifierModuleHandle AsAmplifier(this ModuleHandle module) => new AmplifierModuleHandle(module);

        public static AnalogGeneratorModuleHandle AsAnalogGenerator(this ModuleHandle module) => new AnalogGeneratorModuleHandle(module);

        public static CompressorModuleHandle AsCompressor(this ModuleHandle module) => new CompressorModuleHandle(module);

        public static ControlToNoteModuleHandle AsControlToNote(this ModuleHandle module) => new ControlToNoteModuleHandle(module);

        public static DcBlockerModuleHandle AsDcBlocker(this ModuleHandle module) => new DcBlockerModuleHandle(module);

        public static DelayModuleHandle AsDelay(this ModuleHandle module) => new DelayModuleHandle(module);

        public static DistortionModuleHandle AsDistortion(this ModuleHandle module) => new DistortionModuleHandle(module);

        public static DrumSynthModuleHandle AsDrumSynth(this ModuleHandle module) => new DrumSynthModuleHandle(module);

        public static EchoModuleHandle AsEcho(this ModuleHandle module) => new EchoModuleHandle(module);

        public static EQModuleHandle AsEQ(this ModuleHandle module) => new EQModuleHandle(module);

        public static FeedbackModuleHandle AsFeedback(this ModuleHandle module) => new FeedbackModuleHandle(module);

        public static FFTModuleHandle AsFFT(this ModuleHandle module) => new FFTModuleHandle(module);

        public static FilterModuleHandle AsFilter(this ModuleHandle module) => new FilterModuleHandle(module);

        public static FilterProModuleHandle AsFilterPro(this ModuleHandle module) => new FilterProModuleHandle(module);

        public static FlangerModuleHandle AsFlanger(this ModuleHandle module) => new FlangerModuleHandle(module);

        public static FMModuleHandle AsFM(this ModuleHandle module) => new FMModuleHandle(module);

        public static FMXModuleHandle AsFMX(this ModuleHandle module) => new FMXModuleHandle(module);

        public static GeneratorModuleHandle AsGenerator(this ModuleHandle module) => new GeneratorModuleHandle(module);

        public static GlideModuleHandle AsGlide(this ModuleHandle module) => new GlideModuleHandle(module);

        public static GPIOModuleHandle AsGPIO(this ModuleHandle module) => new GPIOModuleHandle(module);

        public static InputModuleHandle AsInput(this ModuleHandle module) => new InputModuleHandle(module);

        public static KickerModuleHandle AsKicker(this ModuleHandle module) => new KickerModuleHandle(module);

        public static LFOModuleHandle AsLFO(this ModuleHandle module) => new LFOModuleHandle(module);

        public static LoopModuleHandle AsLoop(this ModuleHandle module) => new LoopModuleHandle(module);

        public static MetaModuleModuleHandle AsMetaModule(this ModuleHandle module) => new MetaModuleModuleHandle(module);

        public static ModulatorModuleHandle AsModulator(this ModuleHandle module) => new ModulatorModuleHandle(module);

        public static MultiControlModuleHandle AsMultiControl(this ModuleHandle module) => new MultiControlModuleHandle(module);

        public static MultiSynthModuleHandle AsMultiSynth(this ModuleHandle module) => new MultiSynthModuleHandle(module);

        public static OutputModuleHandle AsOutput(this ModuleHandle module) => new OutputModuleHandle(module);

        public static PitchDetectorModuleHandle AsPitchDetector(this ModuleHandle module) => new PitchDetectorModuleHandle(module);

        public static PitchShifterModuleHandle AsPitchShifter(this ModuleHandle module) => new PitchShifterModuleHandle(module);

        public static PitchToControlModuleHandle AsPitchToControl(this ModuleHandle module) => new PitchToControlModuleHandle(module);

        public static ReverbModuleHandle AsReverb(this ModuleHandle module) => new ReverbModuleHandle(module);

        public static SamplerModuleHandle AsSampler(this ModuleHandle module) => new SamplerModuleHandle(module);

        public static SoundToControlModuleHandle AsSoundToControl(this ModuleHandle module) => new SoundToControlModuleHandle(module);

        public static SpectraVoiceModuleHandle AsSpectraVoice(this ModuleHandle module) => new SpectraVoiceModuleHandle(module);

        public static VelocityToControlModuleHandle AsVelocityToControl(this ModuleHandle module) => new VelocityToControlModuleHandle(module);

        public static VibratoModuleHandle AsVibrato(this ModuleHandle module) => new VibratoModuleHandle(module);

        public static VocalFilterModuleHandle AsVocalFilter(this ModuleHandle module) => new VocalFilterModuleHandle(module);

        public static VorbisPlayerModuleHandle AsVorbisPlayer(this ModuleHandle module) => new VorbisPlayerModuleHandle(module);

        public static WaveShaperModuleHandle AsWaveShaper(this ModuleHandle module) => new WaveShaperModuleHandle(module);
    }

    public struct ADSRModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public ADSRModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve() => (ADSRCurveType)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve(ADSRCurveType value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve() => (ADSRCurveType)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve(ADSRCurveType value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Generator, AmplitudeModulatorMono, AmplitudeModulatorStereo </para>
        /// </summary>
        public ADSRMode GetMode() => (ADSRMode)Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Generator, AmplitudeModulatorMono, AmplitudeModulatorStereo </para>
        /// </summary>
        public void SetMode(ADSRMode value) => Module.SetControllerValue(13, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, StopOnLastNote, Stop </para>
        /// </summary>
        public ADSROnNoteOffBehaviour GetOnNoteOff() => (ADSROnNoteOffBehaviour)Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, StopOnLastNote, Stop </para>
        /// </summary>
        public void SetOnNoteOff(ADSROnNoteOffBehaviour value) => Module.SetControllerValue(12, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: On NoteON
        /// <para> Possible values: DoNothing, StartOnFirstNote, Start </para>
        /// </summary>
        public ADSROnNoteOnBehaviour GetOnNoteOn() => (ADSROnNoteOnBehaviour)Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: On NoteON
        /// <para> Possible values: DoNothing, StartOnFirstNote, Start </para>
        /// </summary>
        public void SetOnNoteOn(ADSROnNoteOnBehaviour value) => Module.SetControllerValue(11, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve() => (ADSRCurveType)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve(ADSRCurveType value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Possible values: Off, RestartAndVolumeChange, RestartAndVolumeChangeSmooth, VolumeChange </para>
        /// </summary>
        public ADSRSmoothTransitions GetSmoothTransitions() => (ADSRSmoothTransitions)Module.GetControllerValue(14, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Possible values: Off, RestartAndVolumeChange, RestartAndVolumeChangeSmooth, VolumeChange </para>
        /// </summary>
        public void SetSmoothTransitions(ADSRSmoothTransitions value) => Module.SetControllerValue(14, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: State
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetState() => (Toggle)Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: State
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetState(Toggle value) => Module.SetControllerValue(10, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain() => (ADSRSustainMode)Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain(ADSRSustainMode value) => Module.SetControllerValue(8, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal() => (Toggle)Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal(Toggle value) => Module.SetControllerValue(9, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct AmplifierModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public AmplifierModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Absolute
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetAbsolute() => (Toggle)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Absolute
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetAbsolute(Toggle value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Balance
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetBalance() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Balance
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetBalance(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bipolar DC Offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public int GetBipolarDCOffset() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bipolar DC Offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public void SetBipolarDCOffset(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: DC Offset
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetDCOffset() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: DC Offset
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetDCOffset(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Fine volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFineVolume() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Fine volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFineVolume(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 5000 </para>
        /// </summary>
        public int GetGain() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 5000 </para>
        /// </summary>
        public void SetGain(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Inverse
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetInverse() => (Toggle)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Inverse
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetInverse(Toggle value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetStereoWidth() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetStereoWidth(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct AnalogGeneratorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public AnalogGeneratorModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetAttack() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAttack(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetDutyCycle() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetDutyCycle(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Exponential envelope
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetExponentialEnvelope() => (Toggle)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Exponential envelope
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetExponentialEnvelope(Toggle value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFAttack() => Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFAttack(int value) => Module.SetControllerValue(13, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.envelope
        /// <para> Possible values: Off, SustainOff, SustainOn </para>
        /// </summary>
        public AnalogGeneratorEnvelopeMode GetFEnvelope() => (AnalogGeneratorEnvelopeMode)Module.GetControllerValue(15, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.envelope
        /// <para> Possible values: Off, SustainOff, SustainOn </para>
        /// </summary>
        public void SetFEnvelope(AnalogGeneratorEnvelopeMode value) => Module.SetControllerValue(15, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetFExponentialFreq() => (Toggle)Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetFExponentialFreq(Toggle value) => Module.SetControllerValue(12, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public int GetFFreq() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetFFreq(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Filter
        /// <para> Possible values: Off, LP12dB, HP12dB, BP12dB, BR12dB, LP24dB, HP24dB, BP24dB, BR24dB </para>
        /// </summary>
        public AnalogGeneratorFilterType GetFilter() => (AnalogGeneratorFilterType)Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Filter
        /// <para> Possible values: Off, LP12dB, HP12dB, BP12dB, BR12dB, LP24dB, HP24dB, BP24dB, BR24dB </para>
        /// </summary>
        public void SetFilter(AnalogGeneratorFilterType value) => Module.SetControllerValue(9, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFRelease() => Module.GetControllerValue(14, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFRelease(int value) => Module.SetControllerValue(14, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public int GetFResonance() => Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public void SetFResonance(int value) => Module.SetControllerValue(11, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)Module.GetControllerValue(17, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(17, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetNoise() => Module.GetControllerValue(18, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetNoise(int value) => Module.SetControllerValue(18, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Osc2
        /// <para> Value range: -1000 to 1000 </para>
        /// </summary>
        public int GetOsc2() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Osc2
        /// <para> Value range: -1000 to 1000 </para>
        /// </summary>
        public void SetOsc2(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Osc2 mode
        /// <para> Possible values: Add, Sub, Mul, Min, Max, BitwiseAnd, BitwiseXor </para>
        /// </summary>
        public AnalogGeneratorOsc2Mode GetOsc2Mode() => (AnalogGeneratorOsc2Mode)Module.GetControllerValue(20, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Osc2 mode
        /// <para> Possible values: Add, Sub, Mul, Min, Max, BitwiseAnd, BitwiseXor </para>
        /// </summary>
        public void SetOsc2Mode(AnalogGeneratorOsc2Mode value) => Module.SetControllerValue(20, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Osc2 phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOsc2Phase() => Module.GetControllerValue(21, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Osc2 phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOsc2Phase(int value) => Module.SetControllerValue(21, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Osc2 volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOsc2Volume() => Module.GetControllerValue(19, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Osc2 volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOsc2Volume(int value) => Module.SetControllerValue(19, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(16, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(16, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetRelease() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetRelease(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustain() => (Toggle)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustain(Toggle value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Saw, Square, NoiseSampler, Drawn, Sin, Hsin, Asin, DrawnSpline, NoiseSamplerSpline, WhiteNoise, PinkNoise, RedNoise, BlueNosie, VioletNoise, GreyNoise, Harmonics </para>
        /// </summary>
        public AnalogGeneratorWaveform GetWaveform() => (AnalogGeneratorWaveform)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Saw, Square, NoiseSampler, Drawn, Sin, Hsin, Asin, DrawnSpline, NoiseSamplerSpline, WhiteNoise, PinkNoise, RedNoise, BlueNosie, VioletNoise, GreyNoise, Harmonics </para>
        /// </summary>
        public void SetWaveform(AnalogGeneratorWaveform value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

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

            Module.ReadCurve(0, buffer);
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

            Module.WriteCurve(0, buffer);
        }

        #endregion curves
    }

    public struct CompressorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public CompressorModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 500 </para>
        /// </summary>
        public int GetAttack() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 500 </para>
        /// </summary>
        public void SetAttack(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Peak, RMS, PeakZeroLatency </para>
        /// </summary>
        public CompressorMode GetMode() => (CompressorMode)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Peak, RMS, PeakZeroLatency </para>
        /// </summary>
        public void SetMode(CompressorMode value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public int GetRelease() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public void SetRelease(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Side-chain input
        /// <para> Value range: 0 to 32 </para>
        /// </summary>
        public int GetSideChainInput() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Side-chain input
        /// <para> Value range: 0 to 32 </para>
        /// </summary>
        public void SetSideChainInput(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Slope
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetSlope() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Slope
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetSlope(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetThreshold() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetThreshold(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct ControlToNoteModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public ControlToNoteModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public int GetFinetune() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public void SetFinetune(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public int GetFirstNote() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public void SetFirstNote(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: NoteOFF
        /// <para> Possible values: Nothing, OnMinPitch, OnMaxPitch </para>
        /// </summary>
        public ControlToNoteOffBehaviour GetNoteOff() => (ControlToNoteOffBehaviour)Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: NoteOFF
        /// <para> Possible values: Nothing, OnMinPitch, OnMaxPitch </para>
        /// </summary>
        public void SetNoteOff(ControlToNoteOffBehaviour value) => Module.SetControllerValue(8, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: NoteON
        /// <para> Possible values: Nothing, OnPitchChange </para>
        /// </summary>
        public ControlToNoteOnBehaviour GetNoteOn() => (ControlToNoteOnBehaviour)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: NoteON
        /// <para> Possible values: Nothing, OnPitchChange </para>
        /// </summary>
        public void SetNoteOn(ControlToNoteOnBehaviour value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPitch() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPitch(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public int GetRangeNumberOfSemitones() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public void SetRangeNumberOfSemitones(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Record notes
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetRecordNotes() => (Toggle)Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Record notes
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetRecordNotes(Toggle value) => Module.SetControllerValue(9, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: State
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetState() => (Toggle)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: State
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetState(Toggle value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetTranspose() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetTranspose(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVelocity() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocity(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct DcBlockerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public DcBlockerModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(0, (int)value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct DelayModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public DelayModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDelayL() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelayL(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay multiplier
        /// <para> Value range: 1 to 15 </para>
        /// </summary>
        public int GetDelayMultiplier() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay multiplier
        /// <para> Value range: 1 to 15 </para>
        /// </summary>
        public void SetDelayMultiplier(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDelayR() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelayR(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Possible values: SecondDivBy16384, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine, SecondDivBy44100, SecondDivBy48000, Sample </para>
        /// </summary>
        public DelayUnit GetDelayUnit() => (DelayUnit)Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Possible values: SecondDivBy16384, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine, SecondDivBy44100, SecondDivBy48000, Sample </para>
        /// </summary>
        public void SetDelayUnit(DelayUnit value) => Module.SetControllerValue(8, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetDry() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetDry(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Inverse
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetInverse() => (Toggle)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Inverse
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetInverse(Toggle value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolumeL() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeL(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolumeR() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeR(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetWet() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetWet(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct DistortionModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public DistortionModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Bit depth
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public int GetBitDepth() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bit depth
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetBitDepth(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: Clipping, Foldback, Foldback2, Foldback3, Overflow, Overflow2, SaturationFoldback, SaturationFoldbackSin, Saturation3, Saturation4, Saturation5 </para>
        /// </summary>
        public DistortionType GetDistortionType() => (DistortionType)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: Clipping, Foldback, Foldback2, Foldback3, Overflow, Overflow2, SaturationFoldback, SaturationFoldbackSin, Saturation3, Saturation4, Saturation5 </para>
        /// </summary>
        public void SetDistortionType(DistortionType value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 44100 </para>
        /// </summary>
        public int GetFreq() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 44100 </para>
        /// </summary>
        public void SetFreq(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetNoise() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetNoise(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetPower() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPower(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct DrumSynthModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public DrumSynthModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Bass length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetBassLength() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassLength(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetBassPanning() => Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetBassPanning(int value) => Module.SetControllerValue(12, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetBassPower() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassPower(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetBassTone() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassTone(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetBassVolume() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bass volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetBassVolume(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Hihat length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetHihatLength() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Hihat length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetHihatLength(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Hihat panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetHihatPanning() => Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Hihat panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetHihatPanning(int value) => Module.SetControllerValue(13, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Hihat volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetHihatVolume() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Hihat volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetHihatVolume(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 8 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 8 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Snare length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSnareLength() => Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Snare length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSnareLength(int value) => Module.SetControllerValue(11, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Snare panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetSnarePanning() => Module.GetControllerValue(14, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Snare panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetSnarePanning(int value) => Module.SetControllerValue(14, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Snare tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSnareTone() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Snare tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSnareTone(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Snare volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetSnareVolume() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Snare volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetSnareVolume(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct EchoModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public EchoModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDelay() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelay(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Possible values: SecondDivBy256, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public EchoDelayUnit GetDelayUnit() => (EchoDelayUnit)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Possible values: SecondDivBy256, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetDelayUnit(EchoDelayUnit value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDry() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFeedback() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public int GetFFreq() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public void SetFFreq(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Filter
        /// <para> Possible values: Off, LP6dB, HP6dB </para>
        /// </summary>
        public EchoFilter GetFilter() => (EchoFilter)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Filter
        /// <para> Possible values: Off, LP6dB, HP6dB </para>
        /// </summary>
        public void SetFilter(EchoFilter value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetRightChannelOffset() => (Toggle)Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetRightChannelOffset(Toggle value) => Module.SetControllerValue(4, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Value range: 0 to 32768 </para>
        /// <para> Delay/32768 </para>
        /// </summary>
        public int GetRightChannelOffsetDelay() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Value range: 0 to 32768 </para>
        /// <para> Delay/32768 </para>
        /// </summary>
        public void SetRightChannelOffsetDelay(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetWet() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct EQModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public EQModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: High
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetHigh() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: High
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetHigh(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Low
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetLow() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Low
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetLow(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Middle
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetMiddle() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Middle
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMiddle(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct FeedbackModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public FeedbackModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct FFTModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public FFTModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetAllPassFilter() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetAllPassFilter(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Buffer (samples)
        /// <para> Possible values: x64, x128, x256, x512, x1024, x2048, x4096, x8192 </para>
        /// </summary>
        public FFTBufferSize GetBufferSamples() => (FFTBufferSize)Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Buffer (samples)
        /// <para> Possible values: x64, x128, x256, x512, x1024, x2048, x4096, x8192 </para>
        /// </summary>
        public void SetBufferSamples(FFTBufferSize value) => Module.SetControllerValue(2, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Buf overlap
        /// <para> Possible values: None, x2, x4 </para>
        /// </summary>
        public FFTBufferOverlap GetBufOverlap() => (FFTBufferOverlap)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Buf overlap
        /// <para> Possible values: None, x2, x4 </para>
        /// </summary>
        public void SetBufOverlap(FFTBufferOverlap value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Deform1
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetDeform1() => Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Deform1
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDeform1(int value) => Module.SetControllerValue(12, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Deform2
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetDeform2() => Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Deform2
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDeform2(int value) => Module.SetControllerValue(13, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq shift
        /// <para> Value range: -4096 to 4096 </para>
        /// </summary>
        public int GetFreqShift() => Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq shift
        /// <para> Value range: -4096 to 4096 </para>
        /// </summary>
        public void SetFreqShift(int value) => Module.SetControllerValue(11, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Frequency spread
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFrequencySpread() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Frequency spread
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFrequencySpread(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: HP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetHPCutoff() => Module.GetControllerValue(14, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: HP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetHPCutoff(int value) => Module.SetControllerValue(14, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetLPCutoff() => Module.GetControllerValue(15, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetLPCutoff(int value) => Module.SetControllerValue(15, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Noise reduction
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoiseReduction() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Noise reduction
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoiseReduction(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Phase gain (norm=16384)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhaseGainNorm16384() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Phase gain (norm=16384)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhaseGainNorm16384(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomPhase() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhase(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random phase (lite)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomPhaseLite() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random phase (lite)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhaseLite(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Possible values: Hz8000, Hz11025, Hz16000, Hz22050, Hz32000, Hz44100, Hz48000, Hz88200, Hz96000, Hz192000 </para>
        /// </summary>
        public FFTSampleRate GetSampleRate() => (FFTSampleRate)Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Possible values: Hz8000, Hz11025, Hz16000, Hz22050, Hz32000, Hz44100, Hz48000, Hz88200, Hz96000, Hz192000 </para>
        /// </summary>
        public void SetSampleRate(FFTSampleRate value) => Module.SetControllerValue(0, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(16, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(16, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct FilterModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public FilterModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetExponentialFreq() => (Toggle)Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetExponentialFreq(Toggle value) => Module.SetControllerValue(11, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: LP, HP, BP, Notch </para>
        /// </summary>
        public FilterType GetFilterType() => (FilterType)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: LP, HP, BP, Notch </para>
        /// </summary>
        public void SetFilterType(FilterType value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public int GetFrequency() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetFrequency(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Impulse
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public int GetImpulse() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Impulse
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetImpulse(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetLFOAmp() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetLFOAmp(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetLFOFreq() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetLFOFreq(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public FilterLFOFrequencyUnit GetLFOFreqUnit() => (FilterLFOFrequencyUnit)Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetLFOFreqUnit(FilterLFOFrequencyUnit value) => Module.SetControllerValue(13, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Sin, Saw, Saw2, Square, Random </para>
        /// </summary>
        public FilterLFOWaveform GetLFOWaveform() => (FilterLFOWaveform)Module.GetControllerValue(14, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Sin, Saw, Saw2, Square, Random </para>
        /// </summary>
        public void SetLFOWaveform(FilterLFOWaveform value) => Module.SetControllerValue(14, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMix() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMix(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public int GetResonance() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public void SetResonance(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetResponse() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetResponse(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public FilterRollOff GetRollOff() => (FilterRollOff)Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public void SetRollOff(FilterRollOff value) => Module.SetControllerValue(12, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetLFOPhase() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct FilterProModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public FilterProModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetExponentialFreq() => (Toggle)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetExponentialFreq(Toggle value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: LP, HP, BPConstSkirtGain, BPConstPeakGain, Notch, AllPass, Peaking, LowShelf, HighShelf, LP6dB, HP6dB </para>
        /// </summary>
        public FilterProType GetFilterType() => (FilterProType)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: LP, HP, BPConstSkirtGain, BPConstPeakGain, Notch, AllPass, Peaking, LowShelf, HighShelf, LP6dB, HP6dB </para>
        /// </summary>
        public void SetFilterType(FilterProType value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public int GetFreq() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public void SetFreq(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq finetune
        /// <para> Value range: -1000 to 1000 </para>
        /// </summary>
        public int GetFreqFinetune() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq finetune
        /// <para> Value range: -1000 to 1000 </para>
        /// </summary>
        public void SetFreqFinetune(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetFreqScale() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetFreqScale(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public int GetGain() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public void SetGain(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetLFOAmp() => Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetLFOAmp(int value) => Module.SetControllerValue(13, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetLFOFreq() => Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetLFOFreq(int value) => Module.SetControllerValue(12, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public FilterLFOFrequencyUnit GetLFOFreqUnit() => (FilterLFOFrequencyUnit)Module.GetControllerValue(16, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetLFOFreqUnit(FilterLFOFrequencyUnit value) => Module.SetControllerValue(16, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Sin, Saw, Saw2, Square, Random </para>
        /// </summary>
        public FilterLFOWaveform GetLFOWaveform() => (FilterLFOWaveform)Module.GetControllerValue(14, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Sin, Saw, Saw2, Square, Random </para>
        /// </summary>
        public void SetLFOWaveform(FilterLFOWaveform value) => Module.SetControllerValue(14, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetMix() => Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetMix(int value) => Module.SetControllerValue(11, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Stereo, Mono, StereoSmoothing, MonoSmoothing </para>
        /// </summary>
        public FilterProMode GetMode() => (FilterProMode)Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Stereo, Mono, StereoSmoothing, MonoSmoothing </para>
        /// </summary>
        public void SetMode(FilterProMode value) => Module.SetControllerValue(10, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Q
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetQ() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Q
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetQ(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public int GetResponse() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public FilterProRollOff GetRollOff() => (FilterProRollOff)Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public void SetRollOff(FilterProRollOff value) => Module.SetControllerValue(8, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetLFOPhase() => Module.GetControllerValue(15, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(int value) => Module.SetControllerValue(15, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct FlangerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public FlangerModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 8 to 1000 </para>
        /// </summary>
        public int GetDelay() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 8 to 1000 </para>
        /// </summary>
        public void SetDelay(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDry() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFeedback() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetLFOAmp() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetLFOAmp(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetLFOFreq() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetLFOFreq(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public FlangerLFOFrequencyUnit GetLFOFreqUnit() => (FlangerLFOFrequencyUnit)Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetLFOFreqUnit(FlangerLFOFrequencyUnit value) => Module.SetControllerValue(9, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Hsin, Sin </para>
        /// </summary>
        public FlangerLFOWaveform GetLFOWaveform() => (FlangerLFOWaveform)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Hsin, Sin </para>
        /// </summary>
        public void SetLFOWaveform(FlangerLFOWaveform value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetResponse() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetResponse(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetLFOPhase() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetWet() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct FMModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public FMModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: C.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetCAttack() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCAttack(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetCDecay() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCDecay(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public int GetCFreqRatio() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public void SetCFreqRatio(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetCRelease() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCRelease(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetCSustain() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCSustain(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetCVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: C.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetMAttack() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMAttack(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetMDecay() => Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMDecay(int value) => Module.SetControllerValue(11, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public int GetMFreqRatio() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public void SetMFreqRatio(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)Module.GetControllerValue(16, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(16, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetMRelease() => Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMRelease(int value) => Module.SetControllerValue(13, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Scaling per key
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public int GetMScalingPerKey() => Module.GetControllerValue(14, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Scaling per key
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetMScalingPerKey(int value) => Module.SetControllerValue(14, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Self-modulation
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMSelfModulation() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Self-modulation
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMSelfModulation(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMSustain() => Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMSustain(int value) => Module.SetControllerValue(12, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMVolume() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: M.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMVolume(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(15, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(15, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct FMXModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public FMXModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region module type-specific methods

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(9 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(9 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(14 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(14 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(19 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(19 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(24 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(24 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(29 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(29 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (ADSRCurveType)Module.GetControllerValue(34 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve(int index, ADSRCurveType value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(34 + index - 1, (int)value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (ADSRCurveType)Module.GetControllerValue(39 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve(int index, ADSRCurveType value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(39 + index - 1, (int)value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (ADSRCurveType)Module.GetControllerValue(44 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve(int index, ADSRCurveType value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(44 + index - 1, (int)value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustain(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(24 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustain(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(24 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (Toggle)Module.GetControllerValue(54 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal(int index, Toggle value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(54 + index - 1, (int)value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(59 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(59 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(64 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(64 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(69 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(69 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (FMXWaveform)Module.GetControllerValue(74 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform(int index, FMXWaveform value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(74 + index - 1, (int)value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(79 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(79 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(84 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(84 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(89 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(89 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(94 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(94 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(99 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(99 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return Module.GetControllerValue(104 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(104 + index - 1, value, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (FMXModulationType)Module.GetControllerValue(109 + index - 1, ValueScalingType.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType(int index, FMXModulationType value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            Module.SetControllerValue(109 + index - 1, (int)value, ValueScalingType.Displayed);
        }

        #endregion module type-specific methods


        #region controllers

        /// <summary>
        /// Original name: ADSR smooth transitions
        /// <para> Possible values: Off, RestartAndVolumeChange, RestartAndVolumeChangeSmooth, VolumeChange </para>
        /// </summary>
        public ADSRSmoothTransitions GetADSRSmoothTransitions() => (ADSRSmoothTransitions)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: ADSR smooth transitions
        /// <para> Possible values: Off, RestartAndVolumeChange, RestartAndVolumeChangeSmooth, VolumeChange </para>
        /// </summary>
        public void SetADSRSmoothTransitions(ADSRSmoothTransitions value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack1() => Module.GetControllerValue(14, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack1(int value) => Module.SetControllerValue(14, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack2() => Module.GetControllerValue(15, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack2(int value) => Module.SetControllerValue(15, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack3() => Module.GetControllerValue(16, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack3(int value) => Module.SetControllerValue(16, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack4() => Module.GetControllerValue(17, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack4(int value) => Module.SetControllerValue(17, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack5() => Module.GetControllerValue(18, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack5(int value) => Module.SetControllerValue(18, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve1() => (ADSRCurveType)Module.GetControllerValue(34, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve1(ADSRCurveType value) => Module.SetControllerValue(34, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve2() => (ADSRCurveType)Module.GetControllerValue(35, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve2(ADSRCurveType value) => Module.SetControllerValue(35, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve3() => (ADSRCurveType)Module.GetControllerValue(36, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve3(ADSRCurveType value) => Module.SetControllerValue(36, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve4() => (ADSRCurveType)Module.GetControllerValue(37, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve4(ADSRCurveType value) => Module.SetControllerValue(37, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve5() => (ADSRCurveType)Module.GetControllerValue(38, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve5(ADSRCurveType value) => Module.SetControllerValue(38, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(4, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch1() => Module.GetControllerValue(94, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch1(int value) => Module.SetControllerValue(94, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch2() => Module.GetControllerValue(95, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch2(int value) => Module.SetControllerValue(95, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch3() => Module.GetControllerValue(96, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch3(int value) => Module.SetControllerValue(96, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch4() => Module.GetControllerValue(97, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch4(int value) => Module.SetControllerValue(97, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch5() => Module.GetControllerValue(98, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch5(int value) => Module.SetControllerValue(98, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay1() => Module.GetControllerValue(19, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay1(int value) => Module.SetControllerValue(19, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay2() => Module.GetControllerValue(20, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay2(int value) => Module.SetControllerValue(20, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay3() => Module.GetControllerValue(21, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay3(int value) => Module.SetControllerValue(21, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay4() => Module.GetControllerValue(22, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay4(int value) => Module.SetControllerValue(22, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay5() => Module.GetControllerValue(23, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay5(int value) => Module.SetControllerValue(23, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve1() => (ADSRCurveType)Module.GetControllerValue(39, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve1(ADSRCurveType value) => Module.SetControllerValue(39, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve2() => (ADSRCurveType)Module.GetControllerValue(40, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve2(ADSRCurveType value) => Module.SetControllerValue(40, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve3() => (ADSRCurveType)Module.GetControllerValue(41, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve3(ADSRCurveType value) => Module.SetControllerValue(41, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve4() => (ADSRCurveType)Module.GetControllerValue(42, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve4(ADSRCurveType value) => Module.SetControllerValue(42, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve5() => (ADSRCurveType)Module.GetControllerValue(43, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve5(ADSRCurveType value) => Module.SetControllerValue(43, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Envelope gain
        /// <para> Value range: 0 to 8000 </para>
        /// </summary>
        public int GetEnvelopeGain() => Module.GetControllerValue(118, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Envelope gain
        /// <para> Value range: 0 to 8000 </para>
        /// </summary>
        public void SetEnvelopeGain(int value) => Module.SetControllerValue(118, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey1() => Module.GetControllerValue(59, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey1(int value) => Module.SetControllerValue(59, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey2() => Module.GetControllerValue(60, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey2(int value) => Module.SetControllerValue(60, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey3() => Module.GetControllerValue(61, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey3(int value) => Module.SetControllerValue(61, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey4() => Module.GetControllerValue(62, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey4(int value) => Module.SetControllerValue(62, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey5() => Module.GetControllerValue(63, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey5(int value) => Module.SetControllerValue(63, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback1() => Module.GetControllerValue(104, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback1(int value) => Module.SetControllerValue(104, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback2() => Module.GetControllerValue(105, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback2(int value) => Module.SetControllerValue(105, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback3() => Module.GetControllerValue(106, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback3(int value) => Module.SetControllerValue(106, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback4() => Module.GetControllerValue(107, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback4(int value) => Module.SetControllerValue(107, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback5() => Module.GetControllerValue(108, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback5(int value) => Module.SetControllerValue(108, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply1() => Module.GetControllerValue(89, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply1(int value) => Module.SetControllerValue(89, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply2() => Module.GetControllerValue(90, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply2(int value) => Module.SetControllerValue(90, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply3() => Module.GetControllerValue(91, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply3(int value) => Module.SetControllerValue(91, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply4() => Module.GetControllerValue(92, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply4(int value) => Module.SetControllerValue(92, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply5() => Module.GetControllerValue(93, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply5(int value) => Module.SetControllerValue(93, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Input -> Custom waveform
        /// <para> Possible values: Off, SingleCycle, Continuous </para>
        /// </summary>
        public FMXCustomWaveform GetInputCustomWaveform() => (FMXCustomWaveform)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Input -> Custom waveform
        /// <para> Possible values: Off, SingleCycle, Continuous </para>
        /// </summary>
        public void SetInputCustomWaveform(FMXCustomWaveform value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Input -> Operator #
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public int GetInputOperatorNum() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Input -> Operator #
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetInputOperatorNum(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType1() => (FMXModulationType)Module.GetControllerValue(109, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType1(FMXModulationType value) => Module.SetControllerValue(109, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType2() => (FMXModulationType)Module.GetControllerValue(110, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType2(FMXModulationType value) => Module.SetControllerValue(110, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType3() => (FMXModulationType)Module.GetControllerValue(111, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType3(FMXModulationType value) => Module.SetControllerValue(111, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType4() => (FMXModulationType)Module.GetControllerValue(112, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType4(FMXModulationType value) => Module.SetControllerValue(112, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType5() => (FMXModulationType)Module.GetControllerValue(113, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType5(FMXModulationType value) => Module.SetControllerValue(113, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise1() => Module.GetControllerValue(79, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise1(int value) => Module.SetControllerValue(79, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise2() => Module.GetControllerValue(80, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise2(int value) => Module.SetControllerValue(80, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise3() => Module.GetControllerValue(81, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise3(int value) => Module.SetControllerValue(81, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise4() => Module.GetControllerValue(82, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise4(int value) => Module.SetControllerValue(82, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise5() => Module.GetControllerValue(83, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise5(int value) => Module.SetControllerValue(83, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Noise filter (32768 - OFF)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoiseFilter() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Noise filter (32768 - OFF)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoiseFilter(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Output mode
        /// <para> Value range: 0 to 31 </para>
        /// </summary>
        public int GetOutputMode1() => Module.GetControllerValue(114, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Output mode
        /// <para> Value range: 0 to 31 </para>
        /// </summary>
        public void SetOutputMode1(int value) => Module.SetControllerValue(114, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Output mode
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public int GetOutputMode2() => Module.GetControllerValue(115, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Output mode
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public void SetOutputMode2(int value) => Module.SetControllerValue(115, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Output mode
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public int GetOutputMode3() => Module.GetControllerValue(116, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Output mode
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public void SetOutputMode3(int value) => Module.SetControllerValue(116, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Output mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public int GetOutputMode4() => Module.GetControllerValue(117, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Output mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetOutputMode4(int value) => Module.SetControllerValue(117, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase1() => Module.GetControllerValue(84, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase1(int value) => Module.SetControllerValue(84, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase2() => Module.GetControllerValue(85, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase2(int value) => Module.SetControllerValue(85, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase3() => Module.GetControllerValue(86, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase3(int value) => Module.SetControllerValue(86, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase4() => Module.GetControllerValue(87, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase4(int value) => Module.SetControllerValue(87, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase5() => Module.GetControllerValue(88, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase5(int value) => Module.SetControllerValue(88, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease1() => Module.GetControllerValue(29, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease1(int value) => Module.SetControllerValue(29, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease2() => Module.GetControllerValue(30, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease2(int value) => Module.SetControllerValue(30, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease3() => Module.GetControllerValue(31, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease3(int value) => Module.SetControllerValue(31, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease4() => Module.GetControllerValue(32, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease4(int value) => Module.SetControllerValue(32, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease5() => Module.GetControllerValue(33, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease5(int value) => Module.SetControllerValue(33, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve1() => (ADSRCurveType)Module.GetControllerValue(44, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve1(ADSRCurveType value) => Module.SetControllerValue(44, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve2() => (ADSRCurveType)Module.GetControllerValue(45, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve2(ADSRCurveType value) => Module.SetControllerValue(45, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve3() => (ADSRCurveType)Module.GetControllerValue(46, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve3(ADSRCurveType value) => Module.SetControllerValue(46, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve4() => (ADSRCurveType)Module.GetControllerValue(47, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve4(ADSRCurveType value) => Module.SetControllerValue(47, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve5() => (ADSRCurveType)Module.GetControllerValue(48, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve5(ADSRCurveType value) => Module.SetControllerValue(48, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Possible values: Hz8000, Hz11025, Hz16000, Hz22050, Hz32000, Hz44100, Native </para>
        /// </summary>
        public FMXSampleRate GetSampleRate() => (FMXSampleRate)Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Possible values: Hz8000, Hz11025, Hz16000, Hz22050, Hz32000, Hz44100, Native </para>
        /// </summary>
        public void SetSampleRate(FMXSampleRate value) => Module.SetControllerValue(2, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation1() => Module.GetControllerValue(99, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation1(int value) => Module.SetControllerValue(99, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation2() => Module.GetControllerValue(100, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation2(int value) => Module.SetControllerValue(100, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation3() => Module.GetControllerValue(101, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation3(int value) => Module.SetControllerValue(101, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation4() => Module.GetControllerValue(102, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation4(int value) => Module.SetControllerValue(102, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation5() => Module.GetControllerValue(103, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation5(int value) => Module.SetControllerValue(103, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain1() => (ADSRSustainMode)Module.GetControllerValue(49, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain1(ADSRSustainMode value) => Module.SetControllerValue(49, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain2() => (ADSRSustainMode)Module.GetControllerValue(50, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain2(ADSRSustainMode value) => Module.SetControllerValue(50, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain3() => (ADSRSustainMode)Module.GetControllerValue(51, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain3(ADSRSustainMode value) => Module.SetControllerValue(51, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain4() => (ADSRSustainMode)Module.GetControllerValue(52, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain4(ADSRSustainMode value) => Module.SetControllerValue(52, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain5() => (ADSRSustainMode)Module.GetControllerValue(53, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain5(ADSRSustainMode value) => Module.SetControllerValue(53, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel1() => Module.GetControllerValue(24, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel1(int value) => Module.SetControllerValue(24, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel2() => Module.GetControllerValue(25, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel2(int value) => Module.SetControllerValue(25, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel3() => Module.GetControllerValue(26, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel3(int value) => Module.SetControllerValue(26, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel4() => Module.GetControllerValue(27, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel4(int value) => Module.SetControllerValue(27, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel5() => Module.GetControllerValue(28, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel5(int value) => Module.SetControllerValue(28, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal1() => (Toggle)Module.GetControllerValue(54, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal1(Toggle value) => Module.SetControllerValue(54, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal2() => (Toggle)Module.GetControllerValue(55, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal2(Toggle value) => Module.SetControllerValue(55, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal3() => (Toggle)Module.GetControllerValue(56, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal3(Toggle value) => Module.SetControllerValue(56, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal4() => (Toggle)Module.GetControllerValue(57, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal4(Toggle value) => Module.SetControllerValue(57, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal5() => (Toggle)Module.GetControllerValue(58, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal5(Toggle value) => Module.SetControllerValue(58, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity1() => Module.GetControllerValue(69, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity1(int value) => Module.SetControllerValue(69, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity2() => Module.GetControllerValue(70, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity2(int value) => Module.SetControllerValue(70, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity3() => Module.GetControllerValue(71, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity3(int value) => Module.SetControllerValue(71, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity4() => Module.GetControllerValue(72, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity4(int value) => Module.SetControllerValue(72, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity5() => Module.GetControllerValue(73, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity5(int value) => Module.SetControllerValue(73, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume1() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume1(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume2() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume2(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume3() => Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume3(int value) => Module.SetControllerValue(11, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume4() => Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume4(int value) => Module.SetControllerValue(12, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume5() => Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume5(int value) => Module.SetControllerValue(13, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey1() => Module.GetControllerValue(64, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey1(int value) => Module.SetControllerValue(64, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey2() => Module.GetControllerValue(65, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey2(int value) => Module.SetControllerValue(65, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey3() => Module.GetControllerValue(66, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey3(int value) => Module.SetControllerValue(66, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey4() => Module.GetControllerValue(67, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey4(int value) => Module.SetControllerValue(67, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey5() => Module.GetControllerValue(68, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey5(int value) => Module.SetControllerValue(68, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform1() => (FMXWaveform)Module.GetControllerValue(74, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 1 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform1(FMXWaveform value) => Module.SetControllerValue(74, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform2() => (FMXWaveform)Module.GetControllerValue(75, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 2 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform2(FMXWaveform value) => Module.SetControllerValue(75, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform3() => (FMXWaveform)Module.GetControllerValue(76, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 3 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform3(FMXWaveform value) => Module.SetControllerValue(76, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform4() => (FMXWaveform)Module.GetControllerValue(77, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 4 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform4(FMXWaveform value) => Module.SetControllerValue(77, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform5() => (FMXWaveform)Module.GetControllerValue(78, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: 5 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform5(FMXWaveform value) => Module.SetControllerValue(78, (int)value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct GeneratorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public GeneratorModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetAttack() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1022 </para>
        /// </summary>
        public int GetDutyCycle() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1022 </para>
        /// </summary>
        public void SetDutyCycle(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq.modulation by input
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFreqModulationByInput() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq.modulation by input
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFreqModulationByInput(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetMode() => (Channels)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetMode(Channels value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetRelease() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustain() => (Toggle)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustain(Toggle value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Saw, Square, NoiseSampler, Drawn, Sin, Hsin, Asin, Rsin </para>
        /// </summary>
        public GeneratorWaveform GetWaveform() => (GeneratorWaveform)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Saw, Square, NoiseSampler, Drawn, Sin, Hsin, Asin, Rsin </para>
        /// </summary>
        public void SetWaveform(GeneratorWaveform value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct GlideModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public GlideModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: -600 to 600 </para>
        /// </summary>
        public int GetPitch() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: -600 to 600 </para>
        /// </summary>
        public void SetPitch(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetPitchScale() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetPitchScale(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetPolyphony() => (Toggle)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetPolyphony(Toggle value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Reset
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetReset() => (Toggle)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Reset
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetReset(Toggle value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Reset on 1st note
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetResetOnFirstNote() => (Toggle)Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Reset on 1st note
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetResetOnFirstNote(Toggle value) => Module.SetControllerValue(2, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public int GetResponse() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public int GetSampleRate() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct GPIOModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public GPIOModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: In
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetIn() => (Toggle)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: In
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetIn(Toggle value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: In amplitude
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public int GetInAmplitude() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: In amplitude
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetInAmplitude(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: In note
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public int GetInNote() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: In note
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public void SetInNote(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: In pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetInPin() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: In pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetInPin(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Out
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetOut() => (Toggle)Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Out
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetOut(Toggle value) => Module.SetControllerValue(0, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Out pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetOutPin() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Out pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetOutPin(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Out threshold
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public int GetOutThreshold() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Out threshold
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetOutThreshold(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct InputModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public InputModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct KickerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public KickerModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Acceleration
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetAcceleration() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Acceleration
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetAcceleration(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetAttack() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Boost
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetBoost() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Boost
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetBoost(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: No click
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetNoClick() => (Toggle)Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: No click
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetNoClick(Toggle value) => Module.SetControllerValue(8, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetRelease() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Square, Sin </para>
        /// </summary>
        public KickerWaveform GetWaveform() => (KickerWaveform)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Square, Sin </para>
        /// </summary>
        public void SetWaveform(KickerWaveform value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct LFOModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public LFOModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetAmplitude() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAmplitude(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDutyCycle() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDutyCycle(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public int GetFreq() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public void SetFreq(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetFreqScale() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetFreqScale(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Possible values: HzDividedBy64, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public LFOFrequencyUnit GetFrequencyUnit() => (LFOFrequencyUnit)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Possible values: HzDividedBy64, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetFrequencyUnit(LFOFrequencyUnit value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Generator
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetGenerator() => (Toggle)Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Generator
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetGenerator(Toggle value) => Module.SetControllerValue(9, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: Amplitude, Panning </para>
        /// </summary>
        public LFOType GetLfoType() => (LFOType)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: Amplitude, Panning </para>
        /// </summary>
        public void SetLfoType(LFOType value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetPhase() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetPhase(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sine quality
        /// <para> Possible values: Auto, Low, Middle, High </para>
        /// </summary>
        public LFOSineQuality GetSineQuality() => (LFOSineQuality)Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sine quality
        /// <para> Possible values: Auto, Low, Middle, High </para>
        /// </summary>
        public void SetSineQuality(LFOSineQuality value) => Module.SetControllerValue(12, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Possible values: Off, Waveform </para>
        /// </summary>
        public LFOSmoothTransitions GetSmoothTransitions() => (LFOSmoothTransitions)Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Possible values: Off, Waveform </para>
        /// </summary>
        public void SetSmoothTransitions(LFOSmoothTransitions value) => Module.SetControllerValue(11, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Sin, Square, Sin2, Saw, Saw2, Random, Triangle, RandomInterpolated </para>
        /// </summary>
        public LFOWaveform GetWaveform() => (LFOWaveform)Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Sin, Square, Sin2, Saw, Saw2, Random, Triangle, RandomInterpolated </para>
        /// </summary>
        public void SetWaveform(LFOWaveform value) => Module.SetControllerValue(4, (int)value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct LoopModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public LoopModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(2, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDelay() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelay(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Length unit
        /// <para> Possible values: LineDivBy128, Line, HalfLine, OneThirdLine, Tick, Millisecond, Hz </para>
        /// </summary>
        public LoopTimeUnit GetLengthUnit() => (LoopTimeUnit)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Length unit
        /// <para> Possible values: LineDivBy128, Line, HalfLine, OneThirdLine, Tick, Millisecond, Hz </para>
        /// </summary>
        public void SetLengthUnit(LoopTimeUnit value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Max buffer size
        /// <para> Value range: 1 to 240 </para>
        /// <para> Max buffer size in seconds </para>
        /// </summary>
        public int GetMaxBufferSize() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Max buffer size
        /// <para> Value range: 1 to 240 </para>
        /// <para> Max buffer size in seconds </para>
        /// </summary>
        public void SetMaxBufferSize(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Normal, PingPong </para>
        /// </summary>
        public LoopMode GetMode() => (LoopMode)Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Normal, PingPong </para>
        /// </summary>
        public void SetMode(LoopMode value) => Module.SetControllerValue(4, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Repeat (128=endless)
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public int GetRepeats() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Repeat (128=endless)
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public void SetRepeats(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct MetaModuleModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public MetaModuleModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region module type-specific methods

        /// <inheritdoc cref="ModuleHandle.LoadIntoMetaModule(string)"/>
        public void LoadFile(string path) => Module.LoadIntoMetaModule(path);

        /// <inheritdoc cref="ModuleHandle.LoadIntoMetaModule(byte[])"/>
        public void LoadFile(byte[] data) => Module.LoadIntoMetaModule(data);
        #endregion module type-specific methods


        #region controllers

        /// <summary>
        /// Original name: BPM (Beats Per Minute)
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public int GetBPM() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: BPM (Beats Per Minute)
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public void SetBPM(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Input module
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public int GetInputModule() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Input module
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public void SetInputModule(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Play patterns
        /// <para> Possible values: Off, OnRepeat, OnNoRepeat, OnRepeatEndless, OnNoRepeatEndless </para>
        /// </summary>
        public MetaModulePatternMode GetPlayPatterns() => (MetaModulePatternMode)Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Play patterns
        /// <para> Possible values: Off, OnRepeat, OnNoRepeat, OnRepeatEndless, OnNoRepeatEndless </para>
        /// </summary>
        public void SetPlayPatterns(MetaModulePatternMode value) => Module.SetControllerValue(2, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: TPL (Ticks Per Line)
        /// <para> Value range: 1 to 31 </para>
        /// </summary>
        public int GetTPL() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: TPL (Ticks Per Line)
        /// <para> Value range: 1 to 31 </para>
        /// </summary>
        public void SetTPL(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct ModulatorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public ModulatorModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(2, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Modulation type
        /// <para> Possible values: Amplitude, Phase, PhaseAbsolute </para>
        /// </summary>
        public ModulationType GetModulationType() => (ModulationType)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Modulation type
        /// <para> Possible values: Amplitude, Phase, PhaseAbsolute </para>
        /// </summary>
        public void SetModulationType(ModulationType value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct MultiControlModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public MultiControlModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetGain() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetGain(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public int GetOUTOffset() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public void SetOUTOffset(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Quantization
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetQuantization() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Quantization
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetQuantization(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public int GetResponse() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public int GetSampleRate() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Value
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetValue() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Value
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetValue(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

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

            Module.ReadCurve(0, buffer);
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

            Module.WriteCurve(0, buffer);
        }

        #endregion curves
    }

    public struct MultiSynthModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public MultiSynthModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Curve2 influence
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetCurve2Influence() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Curve2 influence
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCurve2Influence(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public int GetFinetune() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public void SetFinetune(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomPhase() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhase(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random pitch
        /// <para> Value range: 0 to 4096 </para>
        /// </summary>
        public int GetRandomPitch() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random pitch
        /// <para> Value range: 0 to 4096 </para>
        /// </summary>
        public void SetRandomPitch(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random velocity
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomVelocity() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random velocity
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomVelocity(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetTranspose() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetTranspose(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVelocity() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocity(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

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

            Module.ReadCurve(0, buffer);
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

            Module.WriteCurve(0, buffer);
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

            Module.ReadCurve(1, buffer);
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

            Module.WriteCurve(1, buffer);
        }

        #endregion curves
    }

    public struct OutputModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public OutputModuleHandle(ModuleHandle module)
        {
            Module = module;
        }

    }

    public struct PitchDetectorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public PitchDetectorModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Alg1 Sensitivity (absolute threshold)
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public int GetAlg1Sensitivity() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Alg1 Sensitivity (absolute threshold)
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetAlg1Sensitivity(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Buffer (ms)
        /// <para> Possible values: Ms5, Ms10, Ms21, Ms42, Ms85 </para>
        /// </summary>
        public PitchDetectorBufferSize GetAlgBufferMs() => (PitchDetectorBufferSize)Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Buffer (ms)
        /// <para> Possible values: Ms5, Ms10, Ms21, Ms42, Ms85 </para>
        /// </summary>
        public void SetAlgBufferMs(PitchDetectorBufferSize value) => Module.SetControllerValue(8, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Buf overlap
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public int GetAlgBufOverlap() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Buf overlap
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetAlgBufOverlap(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Algorithm
        /// <para> Possible values: FastZeroCrossing, Autocorrelation, Cepstrum </para>
        /// </summary>
        public PitchDetectorAlgorithm GetAlgorithm() => (PitchDetectorAlgorithm)Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Algorithm
        /// <para> Possible values: FastZeroCrossing, Autocorrelation, Cepstrum </para>
        /// </summary>
        public void SetAlgorithm(PitchDetectorAlgorithm value) => Module.SetControllerValue(0, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Sample rate (Hz)
        /// <para> Possible values: Hz12000, Hz24000, Hz44100 </para>
        /// </summary>
        public PitchDetectorAlgSampleRate GetAlgSampleRateHz() => (PitchDetectorAlgSampleRate)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Sample rate (Hz)
        /// <para> Possible values: Hz12000, Hz24000, Hz44100 </para>
        /// </summary>
        public void SetAlgSampleRateHz(PitchDetectorAlgSampleRate value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Detector finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public int GetDetectorFinetune() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Detector finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public void SetDetectorFinetune(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetGain() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetGain(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LP filter freq (0 - OFF)
        /// <para> Value range: 0 to 4000 </para>
        /// </summary>
        public int GetLPFilterFreq() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LP filter freq (0 - OFF)
        /// <para> Value range: 0 to 4000 </para>
        /// </summary>
        public void SetLPFilterFreq(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LP filter roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public FilterRollOff GetLPFilterRollOff() => (FilterRollOff)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: LP filter roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public void SetLPFilterRollOff(FilterRollOff value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Microtones
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetMicrotones() => (Toggle)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Microtones
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetMicrotones(Toggle value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Record notes
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetRecordNotes() => (Toggle)Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Record notes
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetRecordNotes(Toggle value) => Module.SetControllerValue(11, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetThreshold() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetThreshold(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct PitchShifterModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public PitchShifterModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Bypass if pitch=0
        /// <para> Possible values: Off, SlowTransition, FastTransition </para>
        /// </summary>
        public PitchShifterBypassMode GetBypassIfPitchZero() => (PitchShifterBypassMode)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Bypass if pitch=0
        /// <para> Possible values: Off, SlowTransition, FastTransition </para>
        /// </summary>
        public void SetBypassIfPitchZero(PitchShifterBypassMode value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFeedback() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Grain size
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetGrainSize() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Grain size
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetGrainSize(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: -600 to 600 </para>
        /// </summary>
        public int GetPitch() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: -600 to 600 </para>
        /// </summary>
        public void SetPitch(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetPitchScale() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetPitchScale(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct PitchToControlModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public PitchToControlModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFirstNote() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFirstNote(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: FrequencyHz, Pitch </para>
        /// </summary>
        public PitchToControlMode GetMode() => (PitchToControlMode)Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: FrequencyHz, Pitch </para>
        /// </summary>
        public void SetMode(PitchToControlMode value) => Module.SetControllerValue(0, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, PitchDown, PitchUp </para>
        /// </summary>
        public PitchToControlOnNoteOff GetOnNoteOff() => (PitchToControlOnNoteOff)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, PitchDown, PitchUp </para>
        /// </summary>
        public void SetOnNoteOff(PitchToControlOnNoteOff value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetOUTController() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOUTController(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOUTMax() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTMax(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOUTMin() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTMin(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetRangeNumberOfSemitones() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetRangeNumberOfSemitones(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct ReverbModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public ReverbModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetAllPassFilter() => (Toggle)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetAllPassFilter(Toggle value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Damp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDamp() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Damp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDamp(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDry() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFeedback() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freeze
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetFreeze() => (Toggle)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freeze
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetFreeze(Toggle value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomSeed() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomSeed(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Room size
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public int GetRoomSize() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Room size
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public void SetRoomSize(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetStereoWidth() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetStereoWidth(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetWet() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct SamplerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public SamplerModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region module type-specific methods

        /// <inheritdoc cref="ModuleHandle.LoadSamplerSample(byte[], int)"/>
        public void LoadSample(byte[] data, int sampleSlot = -1) => Module.LoadSamplerSample(data, sampleSlot);

        /// <inheritdoc cref="ModuleHandle.LoadSamplerSample(string, int)"/>
        public void LoadSample(string path, int sampleSlot = -1) => Module.LoadSamplerSample(path, sampleSlot);
        #endregion module type-specific methods


        #region controllers

        /// <summary>
        /// Original name: Envelope interpolation
        /// <para> Possible values: Off, Linear </para>
        /// </summary>
        public SamplerEnvelopeInterpolation GetEnvelopeInterpolation() => (SamplerEnvelopeInterpolation)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Envelope interpolation
        /// <para> Possible values: Off, Linear </para>
        /// </summary>
        public void SetEnvelopeInterpolation(SamplerEnvelopeInterpolation value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Rec threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRecThreshold() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Rec threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRecThreshold(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample interpolation
        /// <para> Possible values: Off, Linear, Spline </para>
        /// </summary>
        public SamplerInterpolation GetSampleInterpolation() => (SamplerInterpolation)Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample interpolation
        /// <para> Possible values: Off, Linear, Spline </para>
        /// </summary>
        public void SetSampleInterpolation(SamplerInterpolation value) => Module.SetControllerValue(2, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct SoundToControlModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public SoundToControlModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Absolute
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetAbsolute() => (Toggle)Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Absolute
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetAbsolute(Toggle value) => Module.SetControllerValue(2, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetGain() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetGain(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: LQ, HQ </para>
        /// </summary>
        public SoundToControlMode GetMode() => (SoundToControlMode)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: LQ, HQ </para>
        /// </summary>
        public void SetMode(SoundToControlMode value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetOUTController() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOUTController(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOutMax() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMax(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOutMin() => Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMin(int value) => Module.SetControllerValue(6, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public int GetSampleRate() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Smooth
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSmooth() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Smooth
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSmooth(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct SpectraVoiceModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public SpectraVoiceModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetAttack() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Harmonic
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public int GetHarmonic() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Harmonic
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public void SetHarmonic(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: H.freq
        /// <para> Value range: 0 to 22050 </para>
        /// </summary>
        public int GetHarmonicFreq() => Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: H.freq
        /// <para> Value range: 0 to 22050 </para>
        /// </summary>
        public void SetHarmonicFreq(int value) => Module.SetControllerValue(9, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: H.type
        /// <para> Possible values: Hsin, Rect, Org1, Org2, Org3, Org4, Sin, Random, Triangle1, Triangle2, Overtones1, Overtones2, Overtones3, Overtones4, Overtones1Plus, Overtones2Plus, Overtones3Plus, Overtones4Plus, Metal </para>
        /// </summary>
        public SpectraVoiceHarmonicType GetHarmonicType() => (SpectraVoiceHarmonicType)Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: H.type
        /// <para> Possible values: Hsin, Rect, Org1, Org2, Org3, Org4, Sin, Random, Triangle1, Triangle2, Overtones1, Overtones2, Overtones3, Overtones4, Overtones1Plus, Overtones2Plus, Overtones3Plus, Overtones4Plus, Metal </para>
        /// </summary>
        public void SetHarmonicType(SpectraVoiceHarmonicType value) => Module.SetControllerValue(12, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: H.volume
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetHarmonicVolume() => Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: H.volume
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetHarmonicVolume(int value) => Module.SetControllerValue(10, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: H.width
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetHarmonicWidth() => Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: H.width
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetHarmonicWidth(int value) => Module.SetControllerValue(11, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono, HQSpline </para>
        /// </summary>
        public SpectraVoiceMode GetMode() => (SpectraVoiceMode)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono, HQSpline </para>
        /// </summary>
        public void SetMode(SpectraVoiceMode value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetRelease() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Spectrum resolution
        /// <para> Possible values: Size4096, Size8192, Size16384, Size32768, Size65536, Size131072 </para>
        /// </summary>
        public SpectraVoiceResolution GetSpectrumResolution() => (SpectraVoiceResolution)Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Spectrum resolution
        /// <para> Possible values: Size4096, Size8192, Size16384, Size32768, Size65536, Size131072 </para>
        /// </summary>
        public void SetSpectrumResolution(SpectraVoiceResolution value) => Module.SetControllerValue(7, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustain() => (Toggle)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustain(Toggle value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct VelocityToControlModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public VelocityToControlModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, VelocityDown, VelocityUp </para>
        /// </summary>
        public VelocityToControlOnNoteOff GetOnNoteOff() => (VelocityToControlOnNoteOff)Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, VelocityDown, VelocityUp </para>
        /// </summary>
        public void SetOnNoteOff(VelocityToControlOnNoteOff value) => Module.SetControllerValue(0, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetOutController() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOutController(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOutMax() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMax(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOutMin() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMin(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public int GetOutOffset() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public void SetOutOffset(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct VibratoModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public VibratoModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetAmplitude() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAmplitude(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Exponential amplitude
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetExponentialAmplitude() => (Toggle)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Exponential amplitude
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetExponentialAmplitude(Toggle value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 2048 </para>
        /// </summary>
        public int GetFreq() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 2048 </para>
        /// </summary>
        public void SetFreq(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Possible values: HzDividedBy64, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public VibratoFrequencyUnit GetFrequencyUnit() => (VibratoFrequencyUnit)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Possible values: HzDividedBy64, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetFrequencyUnit(VibratoFrequencyUnit value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetPhase() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetPhase(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct VocalFilterModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public VocalFilterModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Formants
        /// <para> Value range: 1 to 5 </para>
        /// </summary>
        public int GetFormants() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Formants
        /// <para> Value range: 1 to 5 </para>
        /// </summary>
        public void SetFormants(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Formant width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFormantWidth() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Formant width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFormantWidth(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Intensity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetIntensity() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Intensity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetIntensity(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random frequency
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetRandomFrequency() => Module.GetControllerValue(7, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random frequency
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetRandomFrequency(int value) => Module.SetControllerValue(7, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomSeed() => Module.GetControllerValue(8, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomSeed(int value) => Module.SetControllerValue(8, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Voice type
        /// <para> Possible values: Soprano, Alto, Tenor, Bass </para>
        /// </summary>
        public VocalFilterVoiceType GetVoiceType() => (VocalFilterVoiceType)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Voice type
        /// <para> Possible values: Soprano, Alto, Tenor, Bass </para>
        /// </summary>
        public void SetVoiceType(VocalFilterVoiceType value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel (a,e,i,o,u)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVowel() => Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel (a,e,i,o,u)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVowel(int value) => Module.SetControllerValue(4, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel1
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel1() => (VocalFilterVowel)Module.GetControllerValue(9, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel1
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel1(VocalFilterVowel value) => Module.SetControllerValue(9, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel2
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel2() => (VocalFilterVowel)Module.GetControllerValue(10, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel2
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel2(VocalFilterVowel value) => Module.SetControllerValue(10, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel3
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel3() => (VocalFilterVowel)Module.GetControllerValue(11, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel3
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel3(VocalFilterVowel value) => Module.SetControllerValue(11, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel4
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel4() => (VocalFilterVowel)Module.GetControllerValue(12, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel4
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel4(VocalFilterVowel value) => Module.SetControllerValue(12, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel5
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel5() => (VocalFilterVowel)Module.GetControllerValue(13, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Vowel5
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel5(VocalFilterVowel value) => Module.SetControllerValue(13, (int)value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct VorbisPlayerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public VorbisPlayerModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region module type-specific methods

        /// <inheritdoc cref="ModuleHandle.LoadIntoVorbisPLayer(string)"/>
        public void LoadVorbis(string path) => Module.LoadIntoVorbisPLayer(path);

        /// <inheritdoc cref="ModuleHandle.LoadIntoVorbisPLayer(byte[])"/>
        public void LoadIntoVorbisPLayer(byte[] data) => Module.LoadIntoVorbisPLayer(data);
        #endregion module type-specific methods


        #region controllers

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetFinetune() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetFinetune(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Interpolation
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetInterpolation() => (Toggle)Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Interpolation
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetInterpolation(Toggle value) => Module.SetControllerValue(4, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Original speed
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetOriginalSpeed() => (Toggle)Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Original speed
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetOriginalSpeed(Toggle value) => Module.SetControllerValue(1, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public int GetPolyphony() => Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public void SetPolyphony(int value) => Module.SetControllerValue(5, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Repeat
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetRepeat() => (Toggle)Module.GetControllerValue(6, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Repeat
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetRepeat(Toggle value) => Module.SetControllerValue(6, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetTranspose() => Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetTranspose(int value) => Module.SetControllerValue(3, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        #endregion controllers
    }

    public struct WaveShaperModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle Module { get; private set; }

        public WaveShaperModuleHandle(ModuleHandle module)
        {
            Module = module;
        }


        #region controllers

        /// <summary>
        /// Original name: DC blocker
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetDCBlocker() => (Toggle)Module.GetControllerValue(5, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: DC blocker
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetDCBlocker(Toggle value) => Module.SetControllerValue(5, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Input volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetInputVolume() => Module.GetControllerValue(0, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Input volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetInputVolume(int value) => Module.SetControllerValue(0, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMix() => Module.GetControllerValue(1, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMix(int value) => Module.SetControllerValue(1, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)Module.GetControllerValue(4, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => Module.SetControllerValue(4, (int)value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Output volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetOutputVolume() => Module.GetControllerValue(2, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Output volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetOutputVolume(int value) => Module.SetControllerValue(2, value, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Symmetric
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSymmetric() => (Toggle)Module.GetControllerValue(3, ValueScalingType.Displayed);

        /// <summary>
        /// Original name: Symmetric
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSymmetric(Toggle value) => Module.SetControllerValue(3, (int)value, ValueScalingType.Displayed);

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

            Module.ReadCurve(0, buffer);
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

            Module.WriteCurve(0, buffer);
        }

        #endregion curves
    }
}
