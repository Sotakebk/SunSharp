/*
 * IMPORTANT!
 * Do not modify this file manually. It was generated automatically by the CodeGeneration project.
*/

using SunSharp;

namespace SunSharp.Modules
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

    public enum LoopOnNoteOn : ushort
    {
        Restart = 0,
        RestartCurrentIteration = 1,
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
        public ModuleHandle ModuleHandle { get; private set; }

        public ADSRModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve() => (ADSRCurveType)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve(ADSRCurveType value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve() => (ADSRCurveType)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve(ADSRCurveType value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Generator, AmplitudeModulatorMono, AmplitudeModulatorStereo </para>
        /// </summary>
        public ADSRMode GetMode() => (ADSRMode)ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Generator, AmplitudeModulatorMono, AmplitudeModulatorStereo </para>
        /// </summary>
        public void SetMode(ADSRMode value) => ModuleHandle.SetControllerValue(13, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, StopOnLastNote, Stop </para>
        /// </summary>
        public ADSROnNoteOffBehaviour GetOnNoteOff() => (ADSROnNoteOffBehaviour)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, StopOnLastNote, Stop </para>
        /// </summary>
        public void SetOnNoteOff(ADSROnNoteOffBehaviour value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteON
        /// <para> Possible values: DoNothing, StartOnFirstNote, Start </para>
        /// </summary>
        public ADSROnNoteOnBehaviour GetOnNoteOn() => (ADSROnNoteOnBehaviour)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteON
        /// <para> Possible values: DoNothing, StartOnFirstNote, Start </para>
        /// </summary>
        public void SetOnNoteOn(ADSROnNoteOnBehaviour value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve() => (ADSRCurveType)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve(ADSRCurveType value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Possible values: Off, RestartAndVolumeChange, RestartAndVolumeChangeSmooth, VolumeChange </para>
        /// </summary>
        public ADSRSmoothTransitions GetSmoothTransitions() => (ADSRSmoothTransitions)ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Possible values: Off, RestartAndVolumeChange, RestartAndVolumeChangeSmooth, VolumeChange </para>
        /// </summary>
        public void SetSmoothTransitions(ADSRSmoothTransitions value) => ModuleHandle.SetControllerValue(14, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: State
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetState() => (Toggle)ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: State
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetState(Toggle value) => ModuleHandle.SetControllerValue(10, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain() => (ADSRSustainMode)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain(ADSRSustainMode value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal() => (Toggle)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal(Toggle value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct AmplifierModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public AmplifierModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Absolute
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetAbsolute() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Absolute
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetAbsolute(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Balance
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetBalance() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Balance
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetBalance(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bipolar DC Offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public int GetBipolarDCOffset() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bipolar DC Offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public void SetBipolarDCOffset(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: DC Offset
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetDCOffset() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: DC Offset
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetDCOffset(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Fine volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFineVolume() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Fine volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFineVolume(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 5000 </para>
        /// </summary>
        public int GetGain() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 5000 </para>
        /// </summary>
        public void SetGain(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Inverse
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetInverse() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Inverse
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetInverse(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetStereoWidth() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetStereoWidth(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct AnalogGeneratorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public AnalogGeneratorModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetAttack() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAttack(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetDutyCycle() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetDutyCycle(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Exponential envelope
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetExponentialEnvelope() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Exponential envelope
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetExponentialEnvelope(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFAttack() => ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.attack
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFAttack(int value) => ModuleHandle.SetControllerValue(13, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.envelope
        /// <para> Possible values: Off, SustainOff, SustainOn </para>
        /// </summary>
        public AnalogGeneratorEnvelopeMode GetFEnvelope() => (AnalogGeneratorEnvelopeMode)ModuleHandle.GetControllerValue(15, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.envelope
        /// <para> Possible values: Off, SustainOff, SustainOn </para>
        /// </summary>
        public void SetFEnvelope(AnalogGeneratorEnvelopeMode value) => ModuleHandle.SetControllerValue(15, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetFExponentialFreq() => (Toggle)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetFExponentialFreq(Toggle value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public int GetFFreq() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetFFreq(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Filter
        /// <para> Possible values: Off, LP12dB, HP12dB, BP12dB, BR12dB, LP24dB, HP24dB, BP24dB, BR24dB </para>
        /// </summary>
        public AnalogGeneratorFilterType GetFilter() => (AnalogGeneratorFilterType)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Filter
        /// <para> Possible values: Off, LP12dB, HP12dB, BP12dB, BR12dB, LP24dB, HP24dB, BP24dB, BR24dB </para>
        /// </summary>
        public void SetFilter(AnalogGeneratorFilterType value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFRelease() => ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFRelease(int value) => ModuleHandle.SetControllerValue(14, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public int GetFResonance() => ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public void SetFResonance(int value) => ModuleHandle.SetControllerValue(11, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(17, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(17, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetNoise() => ModuleHandle.GetControllerValue(18, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetNoise(int value) => ModuleHandle.SetControllerValue(18, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Osc2
        /// <para> Value range: -1000 to 1000 </para>
        /// </summary>
        public int GetOsc2() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Osc2
        /// <para> Value range: -1000 to 1000 </para>
        /// </summary>
        public void SetOsc2(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Osc2 mode
        /// <para> Possible values: Add, Sub, Mul, Min, Max, BitwiseAnd, BitwiseXor </para>
        /// </summary>
        public AnalogGeneratorOsc2Mode GetOsc2Mode() => (AnalogGeneratorOsc2Mode)ModuleHandle.GetControllerValue(20, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Osc2 mode
        /// <para> Possible values: Add, Sub, Mul, Min, Max, BitwiseAnd, BitwiseXor </para>
        /// </summary>
        public void SetOsc2Mode(AnalogGeneratorOsc2Mode value) => ModuleHandle.SetControllerValue(20, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Osc2 phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOsc2Phase() => ModuleHandle.GetControllerValue(21, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Osc2 phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOsc2Phase(int value) => ModuleHandle.SetControllerValue(21, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Osc2 volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOsc2Volume() => ModuleHandle.GetControllerValue(19, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Osc2 volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOsc2Volume(int value) => ModuleHandle.SetControllerValue(19, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(16, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(16, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetRelease() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetRelease(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustain() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustain(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Saw, Square, NoiseSampler, Drawn, Sin, Hsin, Asin, DrawnSpline, NoiseSamplerSpline, WhiteNoise, PinkNoise, RedNoise, BlueNosie, VioletNoise, GreyNoise, Harmonics </para>
        /// </summary>
        public AnalogGeneratorWaveform GetWaveform() => (AnalogGeneratorWaveform)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Saw, Square, NoiseSampler, Drawn, Sin, Hsin, Asin, DrawnSpline, NoiseSamplerSpline, WhiteNoise, PinkNoise, RedNoise, BlueNosie, VioletNoise, GreyNoise, Harmonics </para>
        /// </summary>
        public void SetWaveform(AnalogGeneratorWaveform value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read DrawnValues containing 32 values.
        /// <para> Value range: -1 to 1. </para>
        /// <para> Used for 'Drawn', 'DrawnSpline' and 'Harmonics'. </para>
        /// </summary>
        public void ReadDrawnValues(float[] buffer)
        {
            if (buffer.Length < 32)
                throw new System.ArgumentException("Buffer must be at least of size 32");

            ModuleHandle.ReadCurve(0, buffer);
        }

        /// <summary>
        /// Write DrawnValues containing 32 values.
        /// <para> Value range: -1 to 1. </para>
        /// <para> Used for 'Drawn', 'DrawnSpline' and 'Harmonics'. </para>
        /// </summary>
        public void WriteDrawnValues(float[] buffer)
        {
            if (buffer.Length < 32)
                throw new System.ArgumentException("Buffer must be at least of size 32");

            ModuleHandle.WriteCurve(0, buffer);
        }

        #endregion curves
    }

    public struct CompressorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public CompressorModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 500 </para>
        /// </summary>
        public int GetAttack() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 500 </para>
        /// </summary>
        public void SetAttack(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Peak, RMS, PeakZeroLatency </para>
        /// </summary>
        public CompressorMode GetMode() => (CompressorMode)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Peak, RMS, PeakZeroLatency </para>
        /// </summary>
        public void SetMode(CompressorMode value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public int GetRelease() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public void SetRelease(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Side-chain input
        /// <para> Value range: 0 to 32 </para>
        /// </summary>
        public int GetSideChainInput() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Side-chain input
        /// <para> Value range: 0 to 32 </para>
        /// </summary>
        public void SetSideChainInput(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Slope
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetSlope() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Slope
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetSlope(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetThreshold() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetThreshold(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct ControlToNoteModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public ControlToNoteModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public int GetFinetune() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public void SetFinetune(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public int GetFirstNote() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public void SetFirstNote(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: NoteOFF
        /// <para> Possible values: Nothing, OnMinPitch, OnMaxPitch </para>
        /// </summary>
        public ControlToNoteOffBehaviour GetNoteOff() => (ControlToNoteOffBehaviour)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: NoteOFF
        /// <para> Possible values: Nothing, OnMinPitch, OnMaxPitch </para>
        /// </summary>
        public void SetNoteOff(ControlToNoteOffBehaviour value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: NoteON
        /// <para> Possible values: Nothing, OnPitchChange </para>
        /// </summary>
        public ControlToNoteOnBehaviour GetNoteOn() => (ControlToNoteOnBehaviour)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: NoteON
        /// <para> Possible values: Nothing, OnPitchChange </para>
        /// </summary>
        public void SetNoteOn(ControlToNoteOnBehaviour value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPitch() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPitch(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public int GetRangeNumberOfSemitones() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 120 </para>
        /// </summary>
        public void SetRangeNumberOfSemitones(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Record notes
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetRecordNotes() => (Toggle)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Record notes
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetRecordNotes(Toggle value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: State
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetState() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: State
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetState(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetTranspose() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetTranspose(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVelocity() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocity(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct DcBlockerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public DcBlockerModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct DelayModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public DelayModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDelayL() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelayL(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay multiplier
        /// <para> Value range: 1 to 15 </para>
        /// </summary>
        public int GetDelayMultiplier() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay multiplier
        /// <para> Value range: 1 to 15 </para>
        /// </summary>
        public void SetDelayMultiplier(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDelayR() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelayR(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Possible values: SecondDivBy16384, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine, SecondDivBy44100, SecondDivBy48000, Sample </para>
        /// </summary>
        public DelayUnit GetDelayUnit() => (DelayUnit)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Possible values: SecondDivBy16384, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine, SecondDivBy44100, SecondDivBy48000, Sample </para>
        /// </summary>
        public void SetDelayUnit(DelayUnit value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetDry() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetDry(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Inverse
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetInverse() => (Toggle)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Inverse
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetInverse(Toggle value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolumeL() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume L
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeL(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolumeR() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume R
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolumeR(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetWet() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetWet(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct DistortionModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public DistortionModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Bit depth
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public int GetBitDepth() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bit depth
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetBitDepth(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: Clipping, Foldback, Foldback2, Foldback3, Overflow, Overflow2, SaturationFoldback, SaturationFoldbackSin, Saturation3, Saturation4, Saturation5 </para>
        /// </summary>
        public DistortionType GetDistortionType() => (DistortionType)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: Clipping, Foldback, Foldback2, Foldback3, Overflow, Overflow2, SaturationFoldback, SaturationFoldbackSin, Saturation3, Saturation4, Saturation5 </para>
        /// </summary>
        public void SetDistortionType(DistortionType value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 44100 </para>
        /// </summary>
        public int GetFreq() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 44100 </para>
        /// </summary>
        public void SetFreq(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetNoise() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Noise
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetNoise(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetPower() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetPower(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct DrumSynthModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public DrumSynthModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Bass length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetBassLength() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassLength(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetBassPanning() => ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetBassPanning(int value) => ModuleHandle.SetControllerValue(12, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetBassPower() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass power
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassPower(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetBassTone() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetBassTone(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetBassVolume() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bass volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetBassVolume(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Hihat length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetHihatLength() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Hihat length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetHihatLength(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Hihat panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetHihatPanning() => ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Hihat panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetHihatPanning(int value) => ModuleHandle.SetControllerValue(13, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Hihat volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetHihatVolume() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Hihat volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetHihatVolume(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 8 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 8 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Snare length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSnareLength() => ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Snare length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSnareLength(int value) => ModuleHandle.SetControllerValue(11, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Snare panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetSnarePanning() => ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Snare panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetSnarePanning(int value) => ModuleHandle.SetControllerValue(14, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Snare tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSnareTone() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Snare tone
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSnareTone(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Snare volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetSnareVolume() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Snare volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetSnareVolume(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct EchoModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public EchoModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDelay() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelay(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Possible values: SecondDivBy256, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public EchoDelayUnit GetDelayUnit() => (EchoDelayUnit)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay unit
        /// <para> Possible values: SecondDivBy256, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetDelayUnit(EchoDelayUnit value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDry() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFeedback() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public int GetFFreq() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: F.freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public void SetFFreq(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Filter
        /// <para> Possible values: Off, LP6dB, HP6dB </para>
        /// </summary>
        public EchoFilter GetFilter() => (EchoFilter)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Filter
        /// <para> Possible values: Off, LP6dB, HP6dB </para>
        /// </summary>
        public void SetFilter(EchoFilter value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetRightChannelOffset() => (Toggle)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetRightChannelOffset(Toggle value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Value range: 0 to 32768 </para>
        /// <para> Delay/32768 </para>
        /// </summary>
        public int GetRightChannelOffsetDelay() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Right channel offset
        /// <para> Value range: 0 to 32768 </para>
        /// <para> Delay/32768 </para>
        /// </summary>
        public void SetRightChannelOffsetDelay(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetWet() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct EQModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public EQModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: High
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetHigh() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: High
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetHigh(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Low
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetLow() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Low
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetLow(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Middle
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetMiddle() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Middle
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMiddle(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct FeedbackModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public FeedbackModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct FFTModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public FFTModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetAllPassFilter() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetAllPassFilter(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Buffer (samples)
        /// <para> Possible values: x64, x128, x256, x512, x1024, x2048, x4096, x8192 </para>
        /// </summary>
        public FFTBufferSize GetBufferSamples() => (FFTBufferSize)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Buffer (samples)
        /// <para> Possible values: x64, x128, x256, x512, x1024, x2048, x4096, x8192 </para>
        /// </summary>
        public void SetBufferSamples(FFTBufferSize value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Buf overlap
        /// <para> Possible values: None, x2, x4 </para>
        /// </summary>
        public FFTBufferOverlap GetBufOverlap() => (FFTBufferOverlap)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Buf overlap
        /// <para> Possible values: None, x2, x4 </para>
        /// </summary>
        public void SetBufOverlap(FFTBufferOverlap value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Deform1
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetDeform1() => ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Deform1
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDeform1(int value) => ModuleHandle.SetControllerValue(12, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Deform2
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetDeform2() => ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Deform2
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetDeform2(int value) => ModuleHandle.SetControllerValue(13, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq shift
        /// <para> Value range: -4096 to 4096 </para>
        /// </summary>
        public int GetFreqShift() => ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq shift
        /// <para> Value range: -4096 to 4096 </para>
        /// </summary>
        public void SetFreqShift(int value) => ModuleHandle.SetControllerValue(11, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Frequency spread
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFrequencySpread() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Frequency spread
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFrequencySpread(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: HP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetHPCutoff() => ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: HP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetHPCutoff(int value) => ModuleHandle.SetControllerValue(14, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetLPCutoff() => ModuleHandle.GetControllerValue(15, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LP cutoff
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetLPCutoff(int value) => ModuleHandle.SetControllerValue(15, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Noise reduction
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoiseReduction() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Noise reduction
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoiseReduction(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Phase gain (norm=16384)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhaseGainNorm16384() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Phase gain (norm=16384)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhaseGainNorm16384(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomPhase() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhase(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random phase (lite)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomPhaseLite() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random phase (lite)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhaseLite(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Possible values: Hz8000, Hz11025, Hz16000, Hz22050, Hz32000, Hz44100, Hz48000, Hz88200, Hz96000, Hz192000 </para>
        /// </summary>
        public FFTSampleRate GetSampleRate() => (FFTSampleRate)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Possible values: Hz8000, Hz11025, Hz16000, Hz22050, Hz32000, Hz44100, Hz48000, Hz88200, Hz96000, Hz192000 </para>
        /// </summary>
        public void SetSampleRate(FFTSampleRate value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(16, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(16, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct FilterModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public FilterModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetExponentialFreq() => (Toggle)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetExponentialFreq(Toggle value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: LP, HP, BP, Notch </para>
        /// </summary>
        public FilterType GetFilterType() => (FilterType)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: LP, HP, BP, Notch </para>
        /// </summary>
        public void SetFilterType(FilterType value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public int GetFrequency() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetFrequency(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Impulse
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public int GetImpulse() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Impulse
        /// <para> Value range: 0 to 14000 </para>
        /// </summary>
        public void SetImpulse(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetLFOAmp() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetLFOAmp(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetLFOFreq() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetLFOFreq(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public FilterLFOFrequencyUnit GetLFOFreqUnit() => (FilterLFOFrequencyUnit)ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetLFOFreqUnit(FilterLFOFrequencyUnit value) => ModuleHandle.SetControllerValue(13, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Sin, Saw, Saw2, Square, Random </para>
        /// </summary>
        public FilterLFOWaveform GetLFOWaveform() => (FilterLFOWaveform)ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Sin, Saw, Saw2, Square, Random </para>
        /// </summary>
        public void SetLFOWaveform(FilterLFOWaveform value) => ModuleHandle.SetControllerValue(14, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMix() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMix(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public int GetResonance() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Resonance
        /// <para> Value range: 0 to 1530 </para>
        /// </summary>
        public void SetResonance(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetResponse() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetResponse(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public FilterRollOff GetRollOff() => (FilterRollOff)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public void SetRollOff(FilterRollOff value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetLFOPhase() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct FilterProModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public FilterProModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetExponentialFreq() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Exponential freq
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetExponentialFreq(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: LP, HP, BPConstSkirtGain, BPConstPeakGain, Notch, AllPass, Peaking, LowShelf, HighShelf, LP6dB, HP6dB </para>
        /// </summary>
        public FilterProType GetFilterType() => (FilterProType)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: LP, HP, BPConstSkirtGain, BPConstPeakGain, Notch, AllPass, Peaking, LowShelf, HighShelf, LP6dB, HP6dB </para>
        /// </summary>
        public void SetFilterType(FilterProType value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public int GetFreq() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 0 to 22000 </para>
        /// </summary>
        public void SetFreq(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq finetune
        /// <para> Value range: -1000 to 1000 </para>
        /// </summary>
        public int GetFreqFinetune() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq finetune
        /// <para> Value range: -1000 to 1000 </para>
        /// </summary>
        public void SetFreqFinetune(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetFreqScale() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetFreqScale(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public int GetGain() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public void SetGain(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetLFOAmp() => ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetLFOAmp(int value) => ModuleHandle.SetControllerValue(13, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetLFOFreq() => ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetLFOFreq(int value) => ModuleHandle.SetControllerValue(12, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public FilterLFOFrequencyUnit GetLFOFreqUnit() => (FilterLFOFrequencyUnit)ModuleHandle.GetControllerValue(16, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetLFOFreqUnit(FilterLFOFrequencyUnit value) => ModuleHandle.SetControllerValue(16, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Sin, Saw, Saw2, Square, Random </para>
        /// </summary>
        public FilterLFOWaveform GetLFOWaveform() => (FilterLFOWaveform)ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Sin, Saw, Saw2, Square, Random </para>
        /// </summary>
        public void SetLFOWaveform(FilterLFOWaveform value) => ModuleHandle.SetControllerValue(14, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetMix() => ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetMix(int value) => ModuleHandle.SetControllerValue(11, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Stereo, Mono, StereoSmoothing, MonoSmoothing </para>
        /// </summary>
        public FilterProMode GetMode() => (FilterProMode)ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Stereo, Mono, StereoSmoothing, MonoSmoothing </para>
        /// </summary>
        public void SetMode(FilterProMode value) => ModuleHandle.SetControllerValue(10, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Q
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetQ() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Q
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetQ(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public int GetResponse() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public FilterProRollOff GetRollOff() => (FilterProRollOff)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public void SetRollOff(FilterProRollOff value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetLFOPhase() => ModuleHandle.GetControllerValue(15, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(int value) => ModuleHandle.SetControllerValue(15, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct FlangerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public FlangerModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 8 to 1000 </para>
        /// </summary>
        public int GetDelay() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Delay
        /// <para> Value range: 8 to 1000 </para>
        /// </summary>
        public void SetDelay(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDry() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFeedback() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetLFOAmp() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO amp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetLFOAmp(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetLFOFreq() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetLFOFreq(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public FlangerLFOFrequencyUnit GetLFOFreqUnit() => (FlangerLFOFrequencyUnit)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO freq unit
        /// <para> Possible values: FiveHundredthHz, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetLFOFreqUnit(FlangerLFOFrequencyUnit value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Hsin, Sin </para>
        /// </summary>
        public FlangerLFOWaveform GetLFOWaveform() => (FlangerLFOWaveform)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LFO waveform
        /// <para> Possible values: Hsin, Sin </para>
        /// </summary>
        public void SetLFOWaveform(FlangerLFOWaveform value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetResponse() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetResponse(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetLFOPhase() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set LFO phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetLFOPhase(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetWet() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct FMModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public FMModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: C.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetCAttack() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCAttack(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetCDecay() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCDecay(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public int GetCFreqRatio() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public void SetCFreqRatio(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetCRelease() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetCRelease(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetCSustain() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCSustain(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetCVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: C.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetMAttack() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMAttack(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetMDecay() => ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Decay
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMDecay(int value) => ModuleHandle.SetControllerValue(11, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public int GetMFreqRatio() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Freq ratio
        /// <para> Value range: 0 to 16 </para>
        /// </summary>
        public void SetMFreqRatio(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(16, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(16, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetMRelease() => ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetMRelease(int value) => ModuleHandle.SetControllerValue(13, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Scaling per key
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public int GetMScalingPerKey() => ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Scaling per key
        /// <para> Value range: 0 to 4 </para>
        /// </summary>
        public void SetMScalingPerKey(int value) => ModuleHandle.SetControllerValue(14, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Self-modulation
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMSelfModulation() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Self-modulation
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMSelfModulation(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMSustain() => ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Sustain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMSustain(int value) => ModuleHandle.SetControllerValue(12, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMVolume() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: M.Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMVolume(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(15, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(15, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct FMXModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public FMXModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
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

            return ModuleHandle.GetControllerValue(9 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(9 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(14 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(14 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(19 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(19 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(24 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(24 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(29 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(29 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (ADSRCurveType)ModuleHandle.GetControllerValue(34 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve(int index, ADSRCurveType value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(34 + index - 1, (int)value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (ADSRCurveType)ModuleHandle.GetControllerValue(39 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve(int index, ADSRCurveType value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(39 + index - 1, (int)value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (ADSRCurveType)ModuleHandle.GetControllerValue(44 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve(int index, ADSRCurveType value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(44 + index - 1, (int)value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustain(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(24 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustain(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(24 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (Toggle)ModuleHandle.GetControllerValue(54 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal(int index, Toggle value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(54 + index - 1, (int)value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(59 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(59 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(64 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(64 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(69 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(69 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (FMXWaveform)ModuleHandle.GetControllerValue(74 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform(int index, FMXWaveform value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(74 + index - 1, (int)value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(79 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(79 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(84 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(84 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(89 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(89 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(94 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(94 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(99 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(99 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return ModuleHandle.GetControllerValue(104 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback(int index, int value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(104 + index - 1, value, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType(int index)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            return (FMXModulationType)ModuleHandle.GetControllerValue(109 + index - 1, ValueScalingMode.Displayed);
        }

        /// <summary>
        /// <para> index range: 1 to 5 </para>
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType(int index, FMXModulationType value)
        {
            if (index < 1 || index > 5)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            ModuleHandle.SetControllerValue(109 + index - 1, (int)value, ValueScalingMode.Displayed);
        }

        #endregion module type-specific methods

        #region controllers

        /// <summary>
        /// Original name: ADSR smooth transitions
        /// <para> Possible values: Off, RestartAndVolumeChange, RestartAndVolumeChangeSmooth, VolumeChange </para>
        /// </summary>
        public ADSRSmoothTransitions GetADSRSmoothTransitions() => (ADSRSmoothTransitions)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: ADSR smooth transitions
        /// <para> Possible values: Off, RestartAndVolumeChange, RestartAndVolumeChangeSmooth, VolumeChange </para>
        /// </summary>
        public void SetADSRSmoothTransitions(ADSRSmoothTransitions value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack1() => ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack1(int value) => ModuleHandle.SetControllerValue(14, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack2() => ModuleHandle.GetControllerValue(15, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack2(int value) => ModuleHandle.SetControllerValue(15, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack3() => ModuleHandle.GetControllerValue(16, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack3(int value) => ModuleHandle.SetControllerValue(16, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack4() => ModuleHandle.GetControllerValue(17, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack4(int value) => ModuleHandle.SetControllerValue(17, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetAttack5() => ModuleHandle.GetControllerValue(18, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Attack
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetAttack5(int value) => ModuleHandle.SetControllerValue(18, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve1() => (ADSRCurveType)ModuleHandle.GetControllerValue(34, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve1(ADSRCurveType value) => ModuleHandle.SetControllerValue(34, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve2() => (ADSRCurveType)ModuleHandle.GetControllerValue(35, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve2(ADSRCurveType value) => ModuleHandle.SetControllerValue(35, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve3() => (ADSRCurveType)ModuleHandle.GetControllerValue(36, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve3(ADSRCurveType value) => ModuleHandle.SetControllerValue(36, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve4() => (ADSRCurveType)ModuleHandle.GetControllerValue(37, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve4(ADSRCurveType value) => ModuleHandle.SetControllerValue(37, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetAttackCurve5() => (ADSRCurveType)ModuleHandle.GetControllerValue(38, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Attack curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetAttackCurve5(ADSRCurveType value) => ModuleHandle.SetControllerValue(38, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch1() => ModuleHandle.GetControllerValue(94, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch1(int value) => ModuleHandle.SetControllerValue(94, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch2() => ModuleHandle.GetControllerValue(95, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch2(int value) => ModuleHandle.SetControllerValue(95, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch3() => ModuleHandle.GetControllerValue(96, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch3(int value) => ModuleHandle.SetControllerValue(96, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch4() => ModuleHandle.GetControllerValue(97, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch4(int value) => ModuleHandle.SetControllerValue(97, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public int GetConstantPitch5() => ModuleHandle.GetControllerValue(98, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Constant pitch
        /// <para> Value range: -8192 to 8192 </para>
        /// </summary>
        public void SetConstantPitch5(int value) => ModuleHandle.SetControllerValue(98, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay1() => ModuleHandle.GetControllerValue(19, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay1(int value) => ModuleHandle.SetControllerValue(19, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay2() => ModuleHandle.GetControllerValue(20, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay2(int value) => ModuleHandle.SetControllerValue(20, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay3() => ModuleHandle.GetControllerValue(21, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay3(int value) => ModuleHandle.SetControllerValue(21, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay4() => ModuleHandle.GetControllerValue(22, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay4(int value) => ModuleHandle.SetControllerValue(22, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetDecay5() => ModuleHandle.GetControllerValue(23, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Decay
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetDecay5(int value) => ModuleHandle.SetControllerValue(23, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve1() => (ADSRCurveType)ModuleHandle.GetControllerValue(39, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve1(ADSRCurveType value) => ModuleHandle.SetControllerValue(39, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve2() => (ADSRCurveType)ModuleHandle.GetControllerValue(40, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve2(ADSRCurveType value) => ModuleHandle.SetControllerValue(40, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve3() => (ADSRCurveType)ModuleHandle.GetControllerValue(41, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve3(ADSRCurveType value) => ModuleHandle.SetControllerValue(41, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve4() => (ADSRCurveType)ModuleHandle.GetControllerValue(42, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve4(ADSRCurveType value) => ModuleHandle.SetControllerValue(42, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetDecayCurve5() => (ADSRCurveType)ModuleHandle.GetControllerValue(43, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Decay curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetDecayCurve5(ADSRCurveType value) => ModuleHandle.SetControllerValue(43, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Envelope gain
        /// <para> Value range: 0 to 8000 </para>
        /// </summary>
        public int GetEnvelopeGain() => ModuleHandle.GetControllerValue(118, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Envelope gain
        /// <para> Value range: 0 to 8000 </para>
        /// </summary>
        public void SetEnvelopeGain(int value) => ModuleHandle.SetControllerValue(118, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey1() => ModuleHandle.GetControllerValue(59, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey1(int value) => ModuleHandle.SetControllerValue(59, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey2() => ModuleHandle.GetControllerValue(60, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey2(int value) => ModuleHandle.SetControllerValue(60, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey3() => ModuleHandle.GetControllerValue(61, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey3(int value) => ModuleHandle.SetControllerValue(61, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey4() => ModuleHandle.GetControllerValue(62, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey4(int value) => ModuleHandle.SetControllerValue(62, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetEnvelopeScalingPerKey5() => ModuleHandle.GetControllerValue(63, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Envelope scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetEnvelopeScalingPerKey5(int value) => ModuleHandle.SetControllerValue(63, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback1() => ModuleHandle.GetControllerValue(104, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback1(int value) => ModuleHandle.SetControllerValue(104, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback2() => ModuleHandle.GetControllerValue(105, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback2(int value) => ModuleHandle.SetControllerValue(105, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback3() => ModuleHandle.GetControllerValue(106, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback3(int value) => ModuleHandle.SetControllerValue(106, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback4() => ModuleHandle.GetControllerValue(107, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback4(int value) => ModuleHandle.SetControllerValue(107, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetFeedback5() => ModuleHandle.GetControllerValue(108, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Feedback
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetFeedback5(int value) => ModuleHandle.SetControllerValue(108, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply1() => ModuleHandle.GetControllerValue(89, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply1(int value) => ModuleHandle.SetControllerValue(89, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply2() => ModuleHandle.GetControllerValue(90, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply2(int value) => ModuleHandle.SetControllerValue(90, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply3() => ModuleHandle.GetControllerValue(91, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply3(int value) => ModuleHandle.SetControllerValue(91, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply4() => ModuleHandle.GetControllerValue(92, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply4(int value) => ModuleHandle.SetControllerValue(92, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public int GetFreqMultiply5() => ModuleHandle.GetControllerValue(93, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Freq multiply
        /// <para> Value range: 0 to 32000 </para>
        /// </summary>
        public void SetFreqMultiply5(int value) => ModuleHandle.SetControllerValue(93, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Input -> Custom waveform
        /// <para> Possible values: Off, SingleCycle, Continuous </para>
        /// </summary>
        public FMXCustomWaveform GetInputCustomWaveform() => (FMXCustomWaveform)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Input -> Custom waveform
        /// <para> Possible values: Off, SingleCycle, Continuous </para>
        /// </summary>
        public void SetInputCustomWaveform(FMXCustomWaveform value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Input -> Operator #
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public int GetInputOperatorNum() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Input -> Operator #
        /// <para> Value range: 0 to 5 </para>
        /// </summary>
        public void SetInputOperatorNum(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType1() => (FMXModulationType)ModuleHandle.GetControllerValue(109, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType1(FMXModulationType value) => ModuleHandle.SetControllerValue(109, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType2() => (FMXModulationType)ModuleHandle.GetControllerValue(110, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType2(FMXModulationType value) => ModuleHandle.SetControllerValue(110, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType3() => (FMXModulationType)ModuleHandle.GetControllerValue(111, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType3(FMXModulationType value) => ModuleHandle.SetControllerValue(111, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType4() => (FMXModulationType)ModuleHandle.GetControllerValue(112, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType4(FMXModulationType value) => ModuleHandle.SetControllerValue(112, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public FMXModulationType GetModulationType5() => (FMXModulationType)ModuleHandle.GetControllerValue(113, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Modulation type
        /// <para> Possible values: Phase, Frequency, Amplitude, Add, Sub, Min, Max, And, Xor, PhasePlus </para>
        /// </summary>
        public void SetModulationType5(FMXModulationType value) => ModuleHandle.SetControllerValue(113, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise1() => ModuleHandle.GetControllerValue(79, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise1(int value) => ModuleHandle.SetControllerValue(79, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise2() => ModuleHandle.GetControllerValue(80, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise2(int value) => ModuleHandle.SetControllerValue(80, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise3() => ModuleHandle.GetControllerValue(81, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise3(int value) => ModuleHandle.SetControllerValue(81, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise4() => ModuleHandle.GetControllerValue(82, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise4(int value) => ModuleHandle.SetControllerValue(82, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoise5() => ModuleHandle.GetControllerValue(83, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Noise
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoise5(int value) => ModuleHandle.SetControllerValue(83, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Noise filter (32768 - OFF)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetNoiseFilter() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Noise filter (32768 - OFF)
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetNoiseFilter(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Output mode
        /// <para> Value range: 0 to 31 </para>
        /// </summary>
        public int GetOutputMode1() => ModuleHandle.GetControllerValue(114, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Output mode
        /// <para> Value range: 0 to 31 </para>
        /// </summary>
        public void SetOutputMode1(int value) => ModuleHandle.SetControllerValue(114, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Output mode
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public int GetOutputMode2() => ModuleHandle.GetControllerValue(115, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Output mode
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public void SetOutputMode2(int value) => ModuleHandle.SetControllerValue(115, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Output mode
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public int GetOutputMode3() => ModuleHandle.GetControllerValue(116, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Output mode
        /// <para> Value range: 0 to 7 </para>
        /// </summary>
        public void SetOutputMode3(int value) => ModuleHandle.SetControllerValue(116, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Output mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public int GetOutputMode4() => ModuleHandle.GetControllerValue(117, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Output mode
        /// <para> Value range: 0 to 3 </para>
        /// </summary>
        public void SetOutputMode4(int value) => ModuleHandle.SetControllerValue(117, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase1() => ModuleHandle.GetControllerValue(84, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase1(int value) => ModuleHandle.SetControllerValue(84, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase2() => ModuleHandle.GetControllerValue(85, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase2(int value) => ModuleHandle.SetControllerValue(85, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase3() => ModuleHandle.GetControllerValue(86, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase3(int value) => ModuleHandle.SetControllerValue(86, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase4() => ModuleHandle.GetControllerValue(87, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase4(int value) => ModuleHandle.SetControllerValue(87, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase5() => ModuleHandle.GetControllerValue(88, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase5(int value) => ModuleHandle.SetControllerValue(88, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease1() => ModuleHandle.GetControllerValue(29, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease1(int value) => ModuleHandle.SetControllerValue(29, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease2() => ModuleHandle.GetControllerValue(30, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease2(int value) => ModuleHandle.SetControllerValue(30, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease3() => ModuleHandle.GetControllerValue(31, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease3(int value) => ModuleHandle.SetControllerValue(31, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease4() => ModuleHandle.GetControllerValue(32, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease4(int value) => ModuleHandle.SetControllerValue(32, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRelease5() => ModuleHandle.GetControllerValue(33, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Release
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRelease5(int value) => ModuleHandle.SetControllerValue(33, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve1() => (ADSRCurveType)ModuleHandle.GetControllerValue(44, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve1(ADSRCurveType value) => ModuleHandle.SetControllerValue(44, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve2() => (ADSRCurveType)ModuleHandle.GetControllerValue(45, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve2(ADSRCurveType value) => ModuleHandle.SetControllerValue(45, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve3() => (ADSRCurveType)ModuleHandle.GetControllerValue(46, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve3(ADSRCurveType value) => ModuleHandle.SetControllerValue(46, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve4() => (ADSRCurveType)ModuleHandle.GetControllerValue(47, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve4(ADSRCurveType value) => ModuleHandle.SetControllerValue(47, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public ADSRCurveType GetReleaseCurve5() => (ADSRCurveType)ModuleHandle.GetControllerValue(48, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Release curve
        /// <para> Possible values: Linear, Exp1, Exp2, Nexp1, Nexp2, Sin, Rect, SmoothRect, Bit2, Bit3, Bit4, Bit5 </para>
        /// </summary>
        public void SetReleaseCurve5(ADSRCurveType value) => ModuleHandle.SetControllerValue(48, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Possible values: Hz8000, Hz11025, Hz16000, Hz22050, Hz32000, Hz44100, Native </para>
        /// </summary>
        public FMXSampleRate GetSampleRate() => (FMXSampleRate)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Possible values: Hz8000, Hz11025, Hz16000, Hz22050, Hz32000, Hz44100, Native </para>
        /// </summary>
        public void SetSampleRate(FMXSampleRate value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation1() => ModuleHandle.GetControllerValue(99, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation1(int value) => ModuleHandle.SetControllerValue(99, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation2() => ModuleHandle.GetControllerValue(100, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation2(int value) => ModuleHandle.SetControllerValue(100, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation3() => ModuleHandle.GetControllerValue(101, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation3(int value) => ModuleHandle.SetControllerValue(101, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation4() => ModuleHandle.GetControllerValue(102, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation4(int value) => ModuleHandle.SetControllerValue(102, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSelfModulation5() => ModuleHandle.GetControllerValue(103, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Self-modulation
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSelfModulation5(int value) => ModuleHandle.SetControllerValue(103, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain1() => (ADSRSustainMode)ModuleHandle.GetControllerValue(49, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain1(ADSRSustainMode value) => ModuleHandle.SetControllerValue(49, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain2() => (ADSRSustainMode)ModuleHandle.GetControllerValue(50, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain2(ADSRSustainMode value) => ModuleHandle.SetControllerValue(50, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain3() => (ADSRSustainMode)ModuleHandle.GetControllerValue(51, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain3(ADSRSustainMode value) => ModuleHandle.SetControllerValue(51, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain4() => (ADSRSustainMode)ModuleHandle.GetControllerValue(52, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain4(ADSRSustainMode value) => ModuleHandle.SetControllerValue(52, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public ADSRSustainMode GetSustain5() => (ADSRSustainMode)ModuleHandle.GetControllerValue(53, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Sustain
        /// <para> Possible values: Off, On, Repeat </para>
        /// </summary>
        public void SetSustain5(ADSRSustainMode value) => ModuleHandle.SetControllerValue(53, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel1() => ModuleHandle.GetControllerValue(24, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel1(int value) => ModuleHandle.SetControllerValue(24, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel2() => ModuleHandle.GetControllerValue(25, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel2(int value) => ModuleHandle.SetControllerValue(25, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel3() => ModuleHandle.GetControllerValue(26, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel3(int value) => ModuleHandle.SetControllerValue(26, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel4() => ModuleHandle.GetControllerValue(27, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel4(int value) => ModuleHandle.SetControllerValue(27, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetSustainLevel5() => ModuleHandle.GetControllerValue(28, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Sustain level
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetSustainLevel5(int value) => ModuleHandle.SetControllerValue(28, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal1() => (Toggle)ModuleHandle.GetControllerValue(54, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal1(Toggle value) => ModuleHandle.SetControllerValue(54, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal2() => (Toggle)ModuleHandle.GetControllerValue(55, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal2(Toggle value) => ModuleHandle.SetControllerValue(55, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal3() => (Toggle)ModuleHandle.GetControllerValue(56, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal3(Toggle value) => ModuleHandle.SetControllerValue(56, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal4() => (Toggle)ModuleHandle.GetControllerValue(57, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal4(Toggle value) => ModuleHandle.SetControllerValue(57, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustainPedal5() => (Toggle)ModuleHandle.GetControllerValue(58, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Sustain pedal
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustainPedal5(Toggle value) => ModuleHandle.SetControllerValue(58, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity1() => ModuleHandle.GetControllerValue(69, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity1(int value) => ModuleHandle.SetControllerValue(69, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity2() => ModuleHandle.GetControllerValue(70, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity2(int value) => ModuleHandle.SetControllerValue(70, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity3() => ModuleHandle.GetControllerValue(71, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity3(int value) => ModuleHandle.SetControllerValue(71, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity4() => ModuleHandle.GetControllerValue(72, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity4(int value) => ModuleHandle.SetControllerValue(72, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVelocitySensitivity5() => ModuleHandle.GetControllerValue(73, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Velocity sensitivity
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVelocitySensitivity5(int value) => ModuleHandle.SetControllerValue(73, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume1() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume1(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume2() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume2(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume3() => ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume3(int value) => ModuleHandle.SetControllerValue(11, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume4() => ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume4(int value) => ModuleHandle.SetControllerValue(12, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetVolume5() => ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Volume
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetVolume5(int value) => ModuleHandle.SetControllerValue(13, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey1() => ModuleHandle.GetControllerValue(64, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey1(int value) => ModuleHandle.SetControllerValue(64, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey2() => ModuleHandle.GetControllerValue(65, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey2(int value) => ModuleHandle.SetControllerValue(65, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey3() => ModuleHandle.GetControllerValue(66, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey3(int value) => ModuleHandle.SetControllerValue(66, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey4() => ModuleHandle.GetControllerValue(67, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey4(int value) => ModuleHandle.SetControllerValue(67, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetVolumeScalingPerKey5() => ModuleHandle.GetControllerValue(68, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Volume scaling per key
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetVolumeScalingPerKey5(int value) => ModuleHandle.SetControllerValue(68, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform1() => (FMXWaveform)ModuleHandle.GetControllerValue(74, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform1(FMXWaveform value) => ModuleHandle.SetControllerValue(74, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform2() => (FMXWaveform)ModuleHandle.GetControllerValue(75, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform2(FMXWaveform value) => ModuleHandle.SetControllerValue(75, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform3() => (FMXWaveform)ModuleHandle.GetControllerValue(76, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform3(FMXWaveform value) => ModuleHandle.SetControllerValue(76, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform4() => (FMXWaveform)ModuleHandle.GetControllerValue(77, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform4(FMXWaveform value) => ModuleHandle.SetControllerValue(77, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public FMXWaveform GetWaveform5() => (FMXWaveform)ModuleHandle.GetControllerValue(78, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 Waveform
        /// <para> Possible values: Custom, Triangle, Triangle3, Saw, Saw3, Square, Sin, Hsin, Asin, Sin3 </para>
        /// </summary>
        public void SetWaveform5(FMXWaveform value) => ModuleHandle.SetControllerValue(78, (int)value, ValueScalingMode.Displayed);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read CustomWaveform containing 256 values.
        /// <para> Value range: -1 to 1. </para>
        /// <para> Used as a waveform where 'Custom' waveform type was applied. </para>
        /// </summary>
        public void ReadCustomWaveform(float[] buffer)
        {
            if (buffer.Length < 256)
                throw new System.ArgumentException("Buffer must be at least of size 256");

            ModuleHandle.ReadCurve(0, buffer);
        }

        /// <summary>
        /// Write CustomWaveform containing 256 values.
        /// <para> Value range: -1 to 1. </para>
        /// <para> Used as a waveform where 'Custom' waveform type was applied. </para>
        /// </summary>
        public void WriteCustomWaveform(float[] buffer)
        {
            if (buffer.Length < 256)
                throw new System.ArgumentException("Buffer must be at least of size 256");

            ModuleHandle.WriteCurve(0, buffer);
        }

        #endregion curves
    }

    public struct GeneratorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public GeneratorModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetAttack() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1022 </para>
        /// </summary>
        public int GetDutyCycle() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 1022 </para>
        /// </summary>
        public void SetDutyCycle(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq.modulation by input
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFreqModulationByInput() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq.modulation by input
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFreqModulationByInput(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetMode() => (Channels)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetMode(Channels value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 16 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetRelease() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustain() => (Toggle)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustain(Toggle value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Saw, Square, NoiseSampler, Drawn, Sin, Hsin, Asin, Rsin </para>
        /// </summary>
        public GeneratorWaveform GetWaveform() => (GeneratorWaveform)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Saw, Square, NoiseSampler, Drawn, Sin, Hsin, Asin, Rsin </para>
        /// </summary>
        public void SetWaveform(GeneratorWaveform value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct GlideModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public GlideModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: -600 to 600 </para>
        /// </summary>
        public int GetPitch() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: -600 to 600 </para>
        /// </summary>
        public void SetPitch(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetPitchScale() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetPitchScale(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetPolyphony() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetPolyphony(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Reset
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetReset() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Reset
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetReset(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Reset on 1st note
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetResetOnFirstNote() => (Toggle)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Reset on 1st note
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetResetOnFirstNote(Toggle value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public int GetResponse() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public int GetSampleRate() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct GPIOModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public GPIOModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: In
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetIn() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: In
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetIn(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: In amplitude
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public int GetInAmplitude() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: In amplitude
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetInAmplitude(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: In note
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public int GetInNote() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: In note
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public void SetInNote(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: In pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetInPin() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: In pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetInPin(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Out
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetOut() => (Toggle)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Out
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetOut(Toggle value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Out pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetOutPin() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Out pin
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetOutPin(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Out threshold
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public int GetOutThreshold() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Out threshold
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetOutThreshold(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct InputModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public InputModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct KickerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public KickerModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Acceleration
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetAcceleration() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Acceleration
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetAcceleration(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetAttack() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Boost
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetBoost() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Boost
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetBoost(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: No click
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetNoClick() => (Toggle)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: No click
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetNoClick(Toggle value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetRelease() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Square, Sin </para>
        /// </summary>
        public KickerWaveform GetWaveform() => (KickerWaveform)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Triangle, Square, Sin </para>
        /// </summary>
        public void SetWaveform(KickerWaveform value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct LFOModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public LFOModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetAmplitude() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAmplitude(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDutyCycle() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Duty cycle
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDutyCycle(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public int GetFreq() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public void SetFreq(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetFreqScale() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetFreqScale(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Possible values: HzDividedBy64, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public LFOFrequencyUnit GetFrequencyUnit() => (LFOFrequencyUnit)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Possible values: HzDividedBy64, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetFrequencyUnit(LFOFrequencyUnit value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Generator
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetGenerator() => (Toggle)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Generator
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetGenerator(Toggle value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: Amplitude, Panning </para>
        /// </summary>
        public LFOType GetLfoType() => (LFOType)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Type
        /// <para> Possible values: Amplitude, Panning </para>
        /// </summary>
        public void SetLfoType(LFOType value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetPhase() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetPhase(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sine quality
        /// <para> Possible values: Auto, Low, Middle, High </para>
        /// </summary>
        public LFOSineQuality GetSineQuality() => (LFOSineQuality)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sine quality
        /// <para> Possible values: Auto, Low, Middle, High </para>
        /// </summary>
        public void SetSineQuality(LFOSineQuality value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Possible values: Off, Waveform </para>
        /// </summary>
        public LFOSmoothTransitions GetSmoothTransitions() => (LFOSmoothTransitions)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Smooth transitions
        /// <para> Possible values: Off, Waveform </para>
        /// </summary>
        public void SetSmoothTransitions(LFOSmoothTransitions value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Sin, Square, Sin2, Saw, Saw2, Random, Triangle, RandomInterpolated </para>
        /// </summary>
        public LFOWaveform GetWaveform() => (LFOWaveform)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Waveform
        /// <para> Possible values: Sin, Square, Sin2, Saw, Saw2, Random, Triangle, RandomInterpolated </para>
        /// </summary>
        public void SetWaveform(LFOWaveform value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct LoopModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public LoopModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDelay() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Length
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDelay(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Length unit
        /// <para> Possible values: LineDivBy128, Line, HalfLine, OneThirdLine, Tick, Millisecond, Hz </para>
        /// </summary>
        public LoopTimeUnit GetLengthUnit() => (LoopTimeUnit)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Length unit
        /// <para> Possible values: LineDivBy128, Line, HalfLine, OneThirdLine, Tick, Millisecond, Hz </para>
        /// </summary>
        public void SetLengthUnit(LoopTimeUnit value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Max buffer size
        /// <para> Value range: 1 to 240 </para>
        /// <para> Max buffer size in seconds </para>
        /// </summary>
        public int GetMaxBufferSize() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Max buffer size
        /// <para> Value range: 1 to 240 </para>
        /// <para> Max buffer size in seconds </para>
        /// </summary>
        public void SetMaxBufferSize(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Normal, PingPong </para>
        /// </summary>
        public LoopMode GetMode() => (LoopMode)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: Normal, PingPong </para>
        /// </summary>
        public void SetMode(LoopMode value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteON
        /// <para> Possible values: Restart, RestartCurrentIteration </para>
        /// </summary>
        public LoopOnNoteOn GetOnNoteOn() => (LoopOnNoteOn)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteON
        /// <para> Possible values: Restart, RestartCurrentIteration </para>
        /// </summary>
        public void SetOnNoteOn(LoopOnNoteOn value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Repeat (128=endless)
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public int GetRepeats() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Repeat (128=endless)
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public void SetRepeats(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct MetaModuleModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public MetaModuleModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region module type-specific methods

        /// <inheritdoc cref="ModuleHandle.LoadIntoMetaModule(string)"/>
        public void LoadFile(string path) => ModuleHandle.LoadIntoMetaModule(path);

        /// <inheritdoc cref="ModuleHandle.LoadIntoMetaModule(byte[])"/>
        public void LoadFile(byte[] data) => ModuleHandle.LoadIntoMetaModule(data);

        #endregion module type-specific methods

        #region controllers

        /// <summary>
        /// Original name: BPM (Beats Per Minute)
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public int GetBPM() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: BPM (Beats Per Minute)
        /// <para> Value range: 1 to 1000 </para>
        /// </summary>
        public void SetBPM(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Input module
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public int GetInputModule() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Input module
        /// <para> Value range: 1 to 256 </para>
        /// </summary>
        public void SetInputModule(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Play patterns
        /// <para> Possible values: Off, OnRepeat, OnNoRepeat, OnRepeatEndless, OnNoRepeatEndless </para>
        /// </summary>
        public MetaModulePatternMode GetPlayPatterns() => (MetaModulePatternMode)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Play patterns
        /// <para> Possible values: Off, OnRepeat, OnNoRepeat, OnRepeatEndless, OnNoRepeatEndless </para>
        /// </summary>
        public void SetPlayPatterns(MetaModulePatternMode value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: TPL (Ticks Per Line)
        /// <para> Value range: 1 to 31 </para>
        /// </summary>
        public int GetTPL() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: TPL (Ticks Per Line)
        /// <para> Value range: 1 to 31 </para>
        /// </summary>
        public void SetTPL(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct ModulatorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public ModulatorModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Modulation type
        /// <para> Possible values: Amplitude, Phase, PhaseAbsolute </para>
        /// </summary>
        public ModulationType GetModulationType() => (ModulationType)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Modulation type
        /// <para> Possible values: Amplitude, Phase, PhaseAbsolute </para>
        /// </summary>
        public void SetModulationType(ModulationType value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct MultiControlModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public MultiControlModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetGain() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetGain(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public int GetOUTOffset() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public void SetOUTOffset(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Quantization
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetQuantization() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Quantization
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetQuantization(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public int GetResponse() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Response
        /// <para> Value range: 0 to 1000 </para>
        /// </summary>
        public void SetResponse(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public int GetSampleRate() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Value
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetValue() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Value
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetValue(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read Curve containing 257 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Modifies applied values. </para>
        /// </summary>
        public void ReadCurve(float[] buffer)
        {
            if (buffer.Length < 257)
                throw new System.ArgumentException("Buffer must be at least of size 257");

            ModuleHandle.ReadCurve(0, buffer);
        }

        /// <summary>
        /// Write Curve containing 257 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Modifies applied values. </para>
        /// </summary>
        public void WriteCurve(float[] buffer)
        {
            if (buffer.Length < 257)
                throw new System.ArgumentException("Buffer must be at least of size 257");

            ModuleHandle.WriteCurve(0, buffer);
        }

        #endregion curves
    }

    public struct MultiSynthModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public MultiSynthModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Curve2 influence
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetCurve2Influence() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Curve2 influence
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetCurve2Influence(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public int GetFinetune() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public void SetFinetune(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetPhase() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetPhase(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomPhase() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random phase
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomPhase(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random pitch
        /// <para> Value range: 0 to 4096 </para>
        /// </summary>
        public int GetRandomPitch() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random pitch
        /// <para> Value range: 0 to 4096 </para>
        /// </summary>
        public void SetRandomPitch(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random velocity
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomVelocity() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random velocity
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomVelocity(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetTranspose() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetTranspose(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVelocity() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Velocity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVelocity(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read NoteVelocityCurve containing 128 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Velocity to apply to arriving note. </para>
        /// </summary>
        public void ReadNoteVelocityCurve(float[] buffer)
        {
            if (buffer.Length < 128)
                throw new System.ArgumentException("Buffer must be at least of size 128");

            ModuleHandle.ReadCurve(0, buffer);
        }

        /// <summary>
        /// Write NoteVelocityCurve containing 128 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Velocity to apply to arriving note. </para>
        /// </summary>
        public void WriteNoteVelocityCurve(float[] buffer)
        {
            if (buffer.Length < 128)
                throw new System.ArgumentException("Buffer must be at least of size 128");

            ModuleHandle.WriteCurve(0, buffer);
        }

        /// <summary>
        /// Read VelocityToVelocityCurve containing 257 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Map velocity values. </para>
        /// </summary>
        public void ReadVelocityToVelocityCurve(float[] buffer)
        {
            if (buffer.Length < 257)
                throw new System.ArgumentException("Buffer must be at least of size 257");

            ModuleHandle.ReadCurve(1, buffer);
        }

        /// <summary>
        /// Write VelocityToVelocityCurve containing 257 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Map velocity values. </para>
        /// </summary>
        public void WriteVelocityToVelocityCurve(float[] buffer)
        {
            if (buffer.Length < 257)
                throw new System.ArgumentException("Buffer must be at least of size 257");

            ModuleHandle.WriteCurve(1, buffer);
        }

        #endregion curves
    }

    public struct OutputModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public OutputModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }
    }

    public struct PitchDetectorModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public PitchDetectorModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Alg1 Sensitivity (absolute threshold)
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public int GetAlg1Sensitivity() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Alg1 Sensitivity (absolute threshold)
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetAlg1Sensitivity(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Buffer (ms)
        /// <para> Possible values: Ms5, Ms10, Ms21, Ms42, Ms85 </para>
        /// </summary>
        public PitchDetectorBufferSize GetAlgBufferMs() => (PitchDetectorBufferSize)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Buffer (ms)
        /// <para> Possible values: Ms5, Ms10, Ms21, Ms42, Ms85 </para>
        /// </summary>
        public void SetAlgBufferMs(PitchDetectorBufferSize value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Buf overlap
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public int GetAlgBufOverlap() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Buf overlap
        /// <para> Value range: 0 to 100 </para>
        /// </summary>
        public void SetAlgBufOverlap(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Algorithm
        /// <para> Possible values: FastZeroCrossing, Autocorrelation, Cepstrum </para>
        /// </summary>
        public PitchDetectorAlgorithm GetAlgorithm() => (PitchDetectorAlgorithm)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Algorithm
        /// <para> Possible values: FastZeroCrossing, Autocorrelation, Cepstrum </para>
        /// </summary>
        public void SetAlgorithm(PitchDetectorAlgorithm value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Sample rate (Hz)
        /// <para> Possible values: Hz12000, Hz24000, Hz44100 </para>
        /// </summary>
        public PitchDetectorAlgSampleRate GetAlgSampleRateHz() => (PitchDetectorAlgSampleRate)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Alg1-2 Sample rate (Hz)
        /// <para> Possible values: Hz12000, Hz24000, Hz44100 </para>
        /// </summary>
        public void SetAlgSampleRateHz(PitchDetectorAlgSampleRate value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Detector finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public int GetDetectorFinetune() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Detector finetune
        /// <para> Value range: -256 to 256 </para>
        /// </summary>
        public void SetDetectorFinetune(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetGain() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetGain(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LP filter freq (0 - OFF)
        /// <para> Value range: 0 to 4000 </para>
        /// </summary>
        public int GetLPFilterFreq() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LP filter freq (0 - OFF)
        /// <para> Value range: 0 to 4000 </para>
        /// </summary>
        public void SetLPFilterFreq(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LP filter roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public FilterRollOff GetLPFilterRollOff() => (FilterRollOff)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: LP filter roll-off
        /// <para> Possible values: dB12, dB24, dB36, dB48 </para>
        /// </summary>
        public void SetLPFilterRollOff(FilterRollOff value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Microtones
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetMicrotones() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Microtones
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetMicrotones(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Record notes
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetRecordNotes() => (Toggle)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Record notes
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetRecordNotes(Toggle value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetThreshold() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetThreshold(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct PitchShifterModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public PitchShifterModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Bypass if pitch=0
        /// <para> Possible values: Off, SlowTransition, FastTransition </para>
        /// </summary>
        public PitchShifterBypassMode GetBypassIfPitchZero() => (PitchShifterBypassMode)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Bypass if pitch=0
        /// <para> Possible values: Off, SlowTransition, FastTransition </para>
        /// </summary>
        public void SetBypassIfPitchZero(PitchShifterBypassMode value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFeedback() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Grain size
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetGrainSize() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Grain size
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetGrainSize(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: -600 to 600 </para>
        /// </summary>
        public int GetPitch() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch
        /// <para> Value range: -600 to 600 </para>
        /// </summary>
        public void SetPitch(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public int GetPitchScale() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Pitch scale
        /// <para> Value range: 0 to 200 </para>
        /// </summary>
        public void SetPitchScale(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct PitchToControlModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public PitchToControlModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFirstNote() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: First note
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFirstNote(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: FrequencyHz, Pitch </para>
        /// </summary>
        public PitchToControlMode GetMode() => (PitchToControlMode)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: FrequencyHz, Pitch </para>
        /// </summary>
        public void SetMode(PitchToControlMode value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, PitchDown, PitchUp </para>
        /// </summary>
        public PitchToControlOnNoteOff GetOnNoteOff() => (PitchToControlOnNoteOff)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, PitchDown, PitchUp </para>
        /// </summary>
        public void SetOnNoteOff(PitchToControlOnNoteOff value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetOUTController() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOUTController(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOUTMax() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTMax(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOUTMin() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOUTMin(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetRangeNumberOfSemitones() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Range (number of semitones)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetRangeNumberOfSemitones(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct ReverbModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public ReverbModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetAllPassFilter() => (Toggle)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: All-pass filter
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetAllPassFilter(Toggle value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Damp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDamp() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Damp
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDamp(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetDry() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Dry
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetDry(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFeedback() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Feedback
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFeedback(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freeze
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetFreeze() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freeze
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetFreeze(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomSeed() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomSeed(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Room size
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public int GetRoomSize() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Room size
        /// <para> Value range: 0 to 128 </para>
        /// </summary>
        public void SetRoomSize(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetStereoWidth() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Stereo width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetStereoWidth(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetWet() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Wet
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetWet(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct SamplerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public SamplerModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region module type-specific methods

        /// <inheritdoc cref="ModuleHandle.LoadSamplerSample(byte[], int)"/>
        public void LoadSample(byte[] data, int sampleSlot = -1) => ModuleHandle.LoadSamplerSample(data, sampleSlot);

        /// <inheritdoc cref="ModuleHandle.LoadSamplerSample(string, int)"/>
        public void LoadSample(string path, int sampleSlot = -1) => ModuleHandle.LoadSamplerSample(path, sampleSlot);

        #endregion module type-specific methods

        #region controllers

        /// <summary>
        /// Original name: Envelope interpolation
        /// <para> Possible values: Off, Linear </para>
        /// </summary>
        public SamplerEnvelopeInterpolation GetEnvelopeInterpolation() => (SamplerEnvelopeInterpolation)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Envelope interpolation
        /// <para> Possible values: Off, Linear </para>
        /// </summary>
        public void SetEnvelopeInterpolation(SamplerEnvelopeInterpolation value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Rec threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public int GetRecThreshold() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Rec threshold
        /// <para> Value range: 0 to 10000 </para>
        /// </summary>
        public void SetRecThreshold(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample interpolation
        /// <para> Possible values: Off, Linear, Spline </para>
        /// </summary>
        public SamplerInterpolation GetSampleInterpolation() => (SamplerInterpolation)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample interpolation
        /// <para> Possible values: Off, Linear, Spline </para>
        /// </summary>
        public void SetSampleInterpolation(SamplerInterpolation value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct SoundToControlModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public SoundToControlModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Absolute
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetAbsolute() => (Toggle)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Absolute
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetAbsolute(Toggle value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Mono, Stereo </para>
        /// </summary>
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetGain() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Gain
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetGain(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: LQ, HQ </para>
        /// </summary>
        public SoundToControlMode GetMode() => (SoundToControlMode)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: LQ, HQ </para>
        /// </summary>
        public void SetMode(SoundToControlMode value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetOUTController() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOUTController(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOutMax() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMax(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOutMin() => ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMin(int value) => ModuleHandle.SetControllerValue(6, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public int GetSampleRate() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sample rate
        /// <para> Value range: 1 to 32768 </para>
        /// </summary>
        public void SetSampleRate(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Smooth
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSmooth() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Smooth
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSmooth(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct SpectraVoiceModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public SpectraVoiceModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetAttack() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Attack
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetAttack(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Harmonic
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public int GetHarmonic() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Harmonic
        /// <para> Value range: 0 to 15 </para>
        /// </summary>
        public void SetHarmonic(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: H.freq
        /// <para> Value range: 0 to 22050 </para>
        /// </summary>
        public int GetHarmonicFreq() => ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: H.freq
        /// <para> Value range: 0 to 22050 </para>
        /// </summary>
        public void SetHarmonicFreq(int value) => ModuleHandle.SetControllerValue(9, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: H.type
        /// <para> Possible values: Hsin, Rect, Org1, Org2, Org3, Org4, Sin, Random, Triangle1, Triangle2, Overtones1, Overtones2, Overtones3, Overtones4, Overtones1Plus, Overtones2Plus, Overtones3Plus, Overtones4Plus, Metal </para>
        /// </summary>
        public SpectraVoiceHarmonicType GetHarmonicType() => (SpectraVoiceHarmonicType)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: H.type
        /// <para> Possible values: Hsin, Rect, Org1, Org2, Org3, Org4, Sin, Random, Triangle1, Triangle2, Overtones1, Overtones2, Overtones3, Overtones4, Overtones1Plus, Overtones2Plus, Overtones3Plus, Overtones4Plus, Metal </para>
        /// </summary>
        public void SetHarmonicType(SpectraVoiceHarmonicType value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: H.volume
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetHarmonicVolume() => ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: H.volume
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetHarmonicVolume(int value) => ModuleHandle.SetControllerValue(10, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: H.width
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetHarmonicWidth() => ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: H.width
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetHarmonicWidth(int value) => ModuleHandle.SetControllerValue(11, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono, HQSpline </para>
        /// </summary>
        public SpectraVoiceMode GetMode() => (SpectraVoiceMode)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono, HQSpline </para>
        /// </summary>
        public void SetMode(SpectraVoiceMode value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetPanning() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Panning
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetPanning(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 32 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetRelease() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Release
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetRelease(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Spectrum resolution
        /// <para> Possible values: Size4096, Size8192, Size16384, Size32768, Size65536, Size131072 </para>
        /// </summary>
        public SpectraVoiceResolution GetSpectrumResolution() => (SpectraVoiceResolution)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Spectrum resolution
        /// <para> Possible values: Size4096, Size8192, Size16384, Size32768, Size65536, Size131072 </para>
        /// </summary>
        public void SetSpectrumResolution(SpectraVoiceResolution value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSustain() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Sustain
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSustain(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct VelocityToControlModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public VelocityToControlModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, VelocityDown, VelocityUp </para>
        /// </summary>
        public VelocityToControlOnNoteOff GetOnNoteOff() => (VelocityToControlOnNoteOff)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: On NoteOFF
        /// <para> Possible values: DoNothing, VelocityDown, VelocityUp </para>
        /// </summary>
        public void SetOnNoteOff(VelocityToControlOnNoteOff value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public int GetOutController() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT controller
        /// <para> Value range: 0 to 255 </para>
        /// </summary>
        public void SetOutController(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOutMax() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT max
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMax(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetOutMin() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT min
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetOutMin(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public int GetOutOffset() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: OUT offset
        /// <para> Value range: -16384 to 16384 </para>
        /// </summary>
        public void SetOutOffset(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct VibratoModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public VibratoModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetAmplitude() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Amplitude
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetAmplitude(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Exponential amplitude
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetExponentialAmplitude() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Exponential amplitude
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetExponentialAmplitude(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 2048 </para>
        /// </summary>
        public int GetFreq() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Freq
        /// <para> Value range: 1 to 2048 </para>
        /// </summary>
        public void SetFreq(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Possible values: HzDividedBy64, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public VibratoFrequencyUnit GetFrequencyUnit() => (VibratoFrequencyUnit)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Frequency unit
        /// <para> Possible values: HzDividedBy64, Millisecond, Hz, Tick, Line, HalfLine, OneThirdLine </para>
        /// </summary>
        public void SetFrequencyUnit(VibratoFrequencyUnit value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetSetPhase() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Set phase
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetSetPhase(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct VocalFilterModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public VocalFilterModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Channels
        /// <para> Possible values: Stereo, Mono </para>
        /// </summary>
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Formants
        /// <para> Value range: 1 to 5 </para>
        /// </summary>
        public int GetFormants() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Formants
        /// <para> Value range: 1 to 5 </para>
        /// </summary>
        public void SetFormants(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Formant width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetFormantWidth() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Formant width
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetFormantWidth(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Intensity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetIntensity() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Intensity
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetIntensity(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random frequency
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public int GetRandomFrequency() => ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random frequency
        /// <para> Value range: 0 to 1024 </para>
        /// </summary>
        public void SetRandomFrequency(int value) => ModuleHandle.SetControllerValue(7, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public int GetRandomSeed() => ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Random seed
        /// <para> Value range: 0 to 32768 </para>
        /// </summary>
        public void SetRandomSeed(int value) => ModuleHandle.SetControllerValue(8, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Voice type
        /// <para> Possible values: Soprano, Alto, Tenor, Bass </para>
        /// </summary>
        public VocalFilterVoiceType GetVoiceType() => (VocalFilterVoiceType)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Voice type
        /// <para> Possible values: Soprano, Alto, Tenor, Bass </para>
        /// </summary>
        public void SetVoiceType(VocalFilterVoiceType value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel (a,e,i,o,u)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetVowel() => ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel (a,e,i,o,u)
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetVowel(int value) => ModuleHandle.SetControllerValue(4, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel1
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel1() => (VocalFilterVowel)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel1
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel1(VocalFilterVowel value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel2
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel2() => (VocalFilterVowel)ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel2
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel2(VocalFilterVowel value) => ModuleHandle.SetControllerValue(10, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel3
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel3() => (VocalFilterVowel)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel3
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel3(VocalFilterVowel value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel4
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel4() => (VocalFilterVowel)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel4
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel4(VocalFilterVowel value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel5
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public VocalFilterVowel GetVowel5() => (VocalFilterVowel)ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Vowel5
        /// <para> Possible values: A, E, I, O, U </para>
        /// </summary>
        public void SetVowel5(VocalFilterVowel value) => ModuleHandle.SetControllerValue(13, (int)value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct VorbisPlayerModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public VorbisPlayerModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region module type-specific methods

        /// <inheritdoc cref="ModuleHandle.LoadIntoVorbisPLayer(string)"/>
        public void LoadVorbis(string path) => ModuleHandle.LoadIntoVorbisPLayer(path);

        /// <inheritdoc cref="ModuleHandle.LoadIntoVorbisPLayer(byte[])"/>
        public void LoadIntoVorbisPLayer(byte[] data) => ModuleHandle.LoadIntoVorbisPLayer(data);

        #endregion module type-specific methods

        #region controllers

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetFinetune() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Finetune
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetFinetune(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Interpolation
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetInterpolation() => (Toggle)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Interpolation
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetInterpolation(Toggle value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Original speed
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetOriginalSpeed() => (Toggle)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Original speed
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetOriginalSpeed(Toggle value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public int GetPolyphony() => ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Polyphony
        /// <para> Value range: 1 to 4 </para>
        /// </summary>
        public void SetPolyphony(int value) => ModuleHandle.SetControllerValue(5, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Repeat
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetRepeat() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Repeat
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetRepeat(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public int GetTranspose() => ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Transpose
        /// <para> Value range: -128 to 128 </para>
        /// </summary>
        public void SetTranspose(int value) => ModuleHandle.SetControllerValue(3, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        #endregion controllers
    }

    public struct WaveShaperModuleHandle : IModuleHandleWrapper
    {
        public ModuleHandle ModuleHandle { get; private set; }

        public WaveShaperModuleHandle(ModuleHandle module)
        {
            ModuleHandle = module;
        }

        #region controllers

        /// <summary>
        /// Original name: DC blocker
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetDCBlocker() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: DC blocker
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetDCBlocker(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Input volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetInputVolume() => ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Input volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetInputVolume(int value) => ModuleHandle.SetControllerValue(0, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public int GetMix() => ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mix
        /// <para> Value range: 0 to 256 </para>
        /// </summary>
        public void SetMix(int value) => ModuleHandle.SetControllerValue(1, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Mode
        /// <para> Possible values: HQ, HQMono, LQ, LQMono </para>
        /// </summary>
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Output volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public int GetOutputVolume() => ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Output volume
        /// <para> Value range: 0 to 512 </para>
        /// </summary>
        public void SetOutputVolume(int value) => ModuleHandle.SetControllerValue(2, value, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Symmetric
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public Toggle GetSymmetric() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: Symmetric
        /// <para> Possible values: Off, On </para>
        /// </summary>
        public void SetSymmetric(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        #endregion controllers

        #region curves

        /// <summary>
        /// Read Curve containing 256 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Maps input to output. </para>
        /// </summary>
        public void ReadCurve(float[] buffer)
        {
            if (buffer.Length < 256)
                throw new System.ArgumentException("Buffer must be at least of size 256");

            ModuleHandle.ReadCurve(0, buffer);
        }

        /// <summary>
        /// Write Curve containing 256 values.
        /// <para> Value range: 0 to 1. </para>
        /// <para> Maps input to output. </para>
        /// </summary>
        public void WriteCurve(float[] buffer)
        {
            if (buffer.Length < 256)
                throw new System.ArgumentException("Buffer must be at least of size 256");

            ModuleHandle.WriteCurve(0, buffer);
        }

        #endregion curves
    }
}
