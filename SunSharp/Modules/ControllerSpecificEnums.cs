namespace SunSharp.Modules
{
    /// <summary>
    /// ADSR envelope curve types.
    /// </summary>
    public enum AdsrCurveType
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

    /// <summary>
    /// ADSR operation modes.
    /// </summary>
    public enum AdsrMode
    {
        /// <summary>
        /// The envelope curve appears at the output of the module as an audio signal. Use Sound2Ctl
        /// to convert this signal into control commands (controllers automation).
        /// </summary>
        Generator = 0,

        /// <summary>
        /// The module works as a modulator: the amplitudes of the input signal and the envelope are
        /// multiplied (mono).
        /// </summary>
        AmplitudeModulatorMono = 1,

        /// <summary>
        /// The module works as a modulator: the amplitudes of the input signal and the envelope are
        /// multiplied (stereo).
        /// </summary>
        AmplitudeModulatorStereo = 2,
    }

    public enum AdsrOnNoteOffBehaviour
    {
        DoNothing = 0,
        StopOnLastNote = 1,
        Stop = 2,
    }

    public enum AdsrOnNoteOnBehaviour
    {
        DoNothing = 0,
        StartOnFirstNote = 1,
        Start = 2,
    }

    /// <summary>
    /// ADSR smooth transition modes.
    /// </summary>
    public enum AdsrSmoothTransitions
    {
        Off = 0,

        /// <summary>
        /// Soft (no clicks) restart of the envelope, smooth volume transitions.
        /// </summary>
        RestartAndVolumeChange = 1,

        /// <summary>
        /// Same as RestartAndVolumeChange, but the envelope restart is even smoother.
        /// </summary>
        RestartAndVolumeChangeSmooth = 2,

        /// <summary>
        /// The volume will change smoothly, but the envelope start is not smoothed.
        /// </summary>
        VolumeChange = 3,
    }

    /// <summary>
    /// ADSR sustain modes.
    /// </summary>
    public enum AdsrSustainMode
    {
        Off = 0,

        /// <summary>
        /// Suspension point (until the Note OFF) on the envelope.
        /// </summary>
        On = 1,

        /// <summary>
        /// Repeat the envelope until the module is stopped.
        /// </summary>
        Repeat = 2,
    }

    public enum AnalogGeneratorEnvelopeMode
    {
        Off = 0,
        SustainOff = 1,
        SustainOn = 2,
    }

    /// <summary>
    /// Analog Generator filter types.
    /// </summary>
    public enum AnalogGeneratorFilterType
    {
        Off = 0,
        LowPass12dB = 1,
        HighPass12dB = 2,
        BandPass12dB = 3,
        BandRejection12dB = 4,
        LowPass24dB = 5,
        HighPass24dB = 6,
        BandPass24dB = 7,
        Bandrejection24dB = 8,
    }

    /// <summary>
    /// Analog Generator secondary oscillator mixing modes.
    /// </summary>
    public enum AnalogGeneratorSecondaryOscillatorMode
    {
        Add = 0,
        Sub = 1,
        Mul = 2,
        Min = 3,
        Max = 4,

        /// <summary>
        /// Samples will be converted to 16-bit integers for bitwise operations.
        /// </summary>
        BitwiseAnd = 5,

        /// <summary>
        /// Samples will be converted to 16-bit integers for bitwise operations.
        /// </summary>
        BitwiseXor = 6,
    }

    public enum AnalogGeneratorWaveform
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
        BlueNoise = 13,
        VioletNoise = 14,
        GreyNoise = 15,

        /// <summary>
        /// Hand-drawn harmonic distribution. Remember, if you turn on all 32 harmonics, then the
        /// module's performance will slow down 32 times compared to a pure sine generator.
        /// </summary>
        Harmonics = 16,
    }

    public enum Channels
    {
        Stereo = 0,
        Mono = 1,
    }

    public enum ChannelsInverted
    {
        Mono = 0,
        Stereo = 1,
    }

    /// <summary>
    /// Compressor operation modes.
    /// </summary>
    public enum CompressorMode
    {
        Peak = 0,

        /// <summary>
        /// Root Mean Square sensing mode.
        /// </summary>
        Rms = 1,

        /// <summary>
        /// Peak sensing with zero latency for compression/limiting without delay.
        /// </summary>
        PeakZeroLatency = 2,
    }

    public enum ControlToNoteOffBehaviour
    {
        Nothing = 0,
        OnMinPitch = 1,
        OnMaxPitch = 2,
    }

    public enum ControlToNoteOnBehaviour
    {
        Nothing = 0,
        OnPitchChange = 1,
    }

    /// <summary>
    /// Time unit for Delay module.
    /// </summary>
    public enum DelayUnit
    {
        /// <summary>
        /// Seconds divided by 16384.
        /// </summary>
        SecondDividedBy16384 = 0,

        Millisecond = 1,
        Hz = 2,

        /// <summary>
        /// Smallest time interval in SunVox.
        /// </summary>
        Tick = 3,

        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,

        /// <summary>
        /// Seconds divided by 44100.
        /// </summary>
        SecondDividedBy44100 = 7,

        /// <summary>
        /// Seconds divided by 48000.
        /// </summary>
        SecondDividedBy48000 = 8,

        /// <summary>
        /// Delay length will depend on the sampling rate.
        /// </summary>
        Sample = 9,
    }

    public enum DistortionType
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

    /// <summary>
    /// Time unit for Echo module delay.
    /// </summary>
    public enum EchoDelayUnit
    {
        /// <summary>
        /// Seconds divided by 256.
        /// </summary>
        SecondDividedBy256 = 0,

        Millisecond = 1,
        Hz = 2,

        /// <summary>
        /// Smallest time interval in SunVox.
        /// </summary>
        Tick = 3,

        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
    }

    /// <summary>
    /// Echo filter types.
    /// </summary>
    public enum EchoFilter
    {
        Off = 0,
        LowPass6dB = 1,
        HighPass6dB = 2,
    }

    /// <summary>
    /// FFT buffer overlap settings. Less overlap = less CPU load; the more overlap, the softer the sound.
    /// </summary>
    public enum FftBufferOverlap
    {
        None = 0,
        X2 = 1,
        X4 = 2,
    }

    /// <summary>
    /// FFT buffer size. The larger the buffer, the more precisely the module works and the higher
    /// the delay.
    /// </summary>
    public enum FftBufferSize
    {
        X64 = 0,
        X128 = 1,
        X256 = 2,
        X512 = 3,
        X1024 = 4,
        X2048 = 5,
        X4096 = 6,
        X8192 = 7,
    }

    /// <summary>
    /// FFT sample rate. This value can be reduced if the CPU load is too high.
    /// </summary>
    public enum FftSampleRate
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

    public enum FilterLfoFrequencyUnit
    {
        /// <summary>
        /// Hz divided by 20. (Hz * 0.02).
        /// </summary>
        HzDividedBy50 = 0,

        Millisecond = 1,
        Hz = 2,

        /// <summary>
        /// Smallest time interval in SunVox.
        /// </summary>
        Tick = 3,

        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
    }

    public enum FilterLfoWaveform
    {
        Sin = 0,
        Saw = 1,
        Saw2 = 2,
        Square = 3,
        Random = 4,
    }

    public enum FilterProMode
    {
        Stereo = 0,
        Mono = 1,

        /// <summary>
        /// Stereo processing with additional parameter smoothing.
        /// </summary>
        StereoSmoothing = 2,

        /// <summary>
        /// Mono processing with additional parameter smoothing.
        /// </summary>
        MonoSmoothing = 3,
    }

    /// <summary>
    /// Filter Pro roll-off (dB per octave). Affects all types except peaking and low/high shelf.
    /// </summary>
    public enum FilterProRollOff
    {
        dB12 = 0,
        dB24 = 1,
        dB36 = 2,
        dB48 = 3,
    }

    /// <summary>
    /// Filter Pro filter types.
    /// </summary>
    public enum FilterProType
    {
        LowPass = 0,
        HighPass = 1,
        BandPassConstantSkirtGain = 2,
        BandPassConstantPeakGain = 3,
        Notch = 4,
        AllPass = 5,

        /// <summary>
        /// Use the Gain controller to amplify or attenuate the peak at the specified frequency.
        /// </summary>
        Peaking = 6,

        /// <summary>
        /// Use the Gain controller to amplify or attenuate the frequencies below the specified frequency.
        /// </summary>
        LowShelf = 7,

        /// <summary>
        /// Use the Gain controller to amplify or attenuate the frequencies above the specified frequency.
        /// </summary>
        HighShelf = 8,

        LowPass6dB = 9,
        HighPass6dB = 10,
    }

    public enum FilterRollOff
    {
        dB12 = 0,
        dB24 = 1,
        dB36 = 2,
        dB48 = 3,
    }

    public enum FilterType
    {
        LowPass = 0,
        HighPass = 1,
        BandPass = 2,
        Notch = 3,
    }

    public enum FlangerLfoFrequencyUnit
    {
        /// <summary>
        /// Hz divided by 20 (Hz * 0.05).
        /// </summary>
        HzDividedBy20 = 0,

        Millisecond = 1,
        Hz = 2,

        /// <summary>
        /// Smallest time interval in SunVox.
        /// </summary>
        Tick = 3,

        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
    }

    public enum FlangerLfoWaveform
    {
        Hsin = 0,
        Sin = 1,
    }

    public enum FmxCustomWaveform
    {
        Off = 0,

        /// <summary>
        /// Store 20ms of the input signal in the custom waveform once.
        /// </summary>
        SingleCycle = 1,

        /// <summary>
        /// Continuously store every 20ms of the incoming signal in the custom waveform.
        /// </summary>
        Continuous = 2,
    }

    /// <summary>
    /// FMX modulation types between operators.
    /// </summary>
    public enum FmxModulationType
    {
        Phase = 0,
        Frequency = 1,

        /// <summary>
        /// Multiplication.
        /// </summary>
        Amplitude = 2,

        Add = 3,
        Sub = 4,
        Min = 5,
        Max = 6,

        /// <summary>
        /// Samples will be converted to 16-bit integers for bitwise operations.
        /// </summary>
        And = 7,

        /// <summary>
        /// Samples will be converted to 16-bit integers for bitwise operations.
        /// </summary>
        Xor = 8,

        /// <summary>
        /// Phase modulation with envelope applied to self-modulation and feedback.
        /// </summary>
        PhasePlus = 9,
    }

    /// <summary>
    /// FMX sample rate. This value can be reduced if the CPU load is too high.
    /// </summary>
    public enum FmxSampleRate
    {
        Hz8000 = 0,
        Hz11025 = 1,
        Hz16000 = 2,
        Hz22050 = 3,
        Hz32000 = 4,
        Hz44100 = 5,

        /// <summary>
        /// Native sample rate from SunVox settings.
        /// </summary>
        Native = 6,
    }

    public enum FmxWaveform
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

    public enum GeneratorWaveform
    {
        Triangle = 0,
        Saw = 1,
        Square = 2,
        NoiseSampler = 3,
        Drawn = 4,
        Sin = 5,
        Hsin = 6,
        Asin = 7,

        /// <summary>
        /// Pulse-sine with duty cycle.
        /// </summary>
        Rsin = 8,
    }

    public enum KickerWaveform
    {
        Triangle = 0,
        Square = 1,
        Sin = 2,
    }

    public enum LfoFrequencyUnit
    {
        /// <summary>
        /// Hz divided by 64.
        /// </summary>
        HzDividedBy64 = 0,

        Millisecond = 1,
        Hz = 2,

        /// <summary>
        /// Smallest time interval in SunVox.
        /// </summary>
        Tick = 3,

        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
    }

    /// <summary>
    /// LFO sine waveform quality settings.
    /// </summary>
    public enum LfoSineQuality
    {
        Auto = 0,

        /// <summary>
        /// Wave table without interpolation.
        /// </summary>
        Low = 1,

        /// <summary>
        /// Wave table with interpolation.
        /// </summary>
        Middle = 2,

        /// <summary>
        /// Perfect sine.
        /// </summary>
        High = 3,
    }

    public enum LfoSmoothTransitions
    {
        /// <summary>
        /// Disable smooth transitions to get hard transitions inside the waveform.
        /// </summary>
        Off = 0,

        Waveform = 1,
    }

    /// <summary>
    /// LFO operation types.
    /// </summary>
    public enum LfoType
    {
        /// <summary>
        /// Amplitude modulation (tremolo).
        /// </summary>
        Amplitude = 0,

        /// <summary>
        /// Stereo balance modulation.
        /// </summary>
        Panning = 1,
    }

    public enum LfoWaveform
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

    public enum LoopMode
    {
        Normal = 0,
        PingPong = 1,
    }

    public enum LoopOnNoteOn
    {
        /// <summary>
        /// Restart with transition to zero iteration (record).
        /// </summary>
        Restart = 0,

        RestartCurrentIteration = 1,
    }

    public enum LoopTimeUnit
    {
        /// <summary>
        /// Line divided by 128.
        /// </summary>
        LineDivBy128 = 0,

        Line = 1,
        HalfLine = 2,
        OneThirdLine = 3,

        /// <summary>
        /// Smallest time interval in SunVox.
        /// </summary>
        Tick = 4,

        Millisecond = 5,
        Hz = 6,
    }

    /// <summary>
    /// MetaModule pattern playback modes.
    /// </summary>
    public enum MetaModulePatternMode
    {
        Off = 0,

        /// <summary>
        /// After receiving the first note, the MetaModule will start playing its internal project
        /// in a loop; after receiving the last release of the note, the MetaModule will stop playing.
        /// </summary>
        OnRepeat = 1,

        /// <summary>
        /// Same as OnRepeat mode, but the project is played only once.
        /// </summary>
        OnNoRepeat = 2,

        /// <summary>
        /// Same as OnRepeat, but playback never stops.
        /// </summary>
        OnRepeatEndless = 3,

        /// <summary>
        /// Same as OnNoRepeat, but playback never stops.
        /// </summary>
        OnNoRepeatEndless = 4,
    }

    /// <summary>
    /// Modulator modulation types.
    /// </summary>
    public enum ModulationType
    {
        Amplitude = 0,

        /// <summary>Default signal delay (when modulating inputs are silent) = 20ms; delay range:
        /// 40ms (mod.amp >= 1) ... 20ms (mod.amp = 0) ... 0ms (mod.amp <= -1).</summary>
        Phase = 1,

        /// <summary>Absolute amplitude values will be used. Default signal delay (when modulating
        /// inputs are silent) = 0ms; delay range: 40ms (mod.amp >= 1) ... 0ms (mod.amp = 0) ...
        /// 40ms (mod.amp <= -1).</summary>
        PhaseAbsolute = 2,
    }

    /// <summary>
    /// Pitch Detector algorithm types.
    /// </summary>
    public enum PitchDetectorAlgorithm
    {
        /// <summary>
        /// For basic periodic waveforms (sine, triangle, saw, square); the fastest with the lowest latency.
        /// </summary>
        FastZeroCrossing = 0,

        /// <summary>
        /// For sounds with a complex spectrum.
        /// </summary>
        Autocorrelation = 1,

        /// <summary>
        /// For sounds with a complex spectrum; compared to autocorrelation, it performs worse at
        /// low frequencies and better at high frequencies.
        /// </summary>
        Cepstrum = 2,
    }

    /// <summary>
    /// Pitch Detector sampling rate for algorithms 1 and 2. A lower value will reduce the CPU load,
    /// but also reduce the quality of detection.
    /// </summary>
    public enum PitchDetectorAlgSampleRate
    {
        Hz12000 = 0,
        Hz24000 = 1,
        Hz44100 = 2,
    }

    /// <summary>
    /// Pitch Detector buffer size for algorithms 1 and 2. Less buffer size = less latency; larger
    /// buffer size = better detection quality.
    /// </summary>
    public enum PitchDetectorBufferSize
    {
        Ms5 = 0,
        Ms10 = 1,
        Ms21 = 2,
        Ms42 = 3,
        Ms85 = 4,
    }

    /// <summary>
    /// Pitch Shifter bypass modes when pitch is zero.
    /// </summary>
    public enum PitchShifterBypassMode
    {
        Off = 0,
        SlowTransition = 1,
        FastTransition = 2,
    }

    /// <summary>
    /// Pitch2Ctl conversion modes.
    /// </summary>
    public enum PitchToControlMode
    {
        /// <summary>
        /// Use frequency (in Hz) of the incoming notes.
        /// </summary>
        FrequencyHz = 0,

        /// <summary>
        /// Use linear pitch (first note ... first note + number of semitones) of the incoming notes.
        /// </summary>
        Pitch = 1,
    }

    public enum PitchToControlOnNoteOff
    {
        DoNothing = 0,

        /// <summary>
        /// Pitch down to the OUT min.
        /// </summary>
        PitchDown = 1,

        /// <summary>
        /// Pitch up to the OUT max.
        /// </summary>
        PitchUp = 2,
    }

    /// <summary>
    /// Quality modes for various modules.
    /// </summary>
    public enum Quality
    {
        HighStereo = 0,
        HighMono = 1,
        LowStereo = 2,
        LowMono = 3,
    }

    public enum SamplerEnvelopeInterpolation
    {
        Off = 0,
        Linear = 1,
    }

    public enum SamplerInterpolation
    {
        Off = 0,
        Linear = 1,
        Spline = 2,
    }

    public enum SoundToControlMode
    {
        LowQuality = 0,
        HighQuality = 1,
    }

    public enum SpectraVoiceHarmonicType
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

        /// <summary>
        /// Random seed is set by H.width.
        /// </summary>
        Metal = 18,
    }

    public enum SpectraVoiceMode
    {
        HighQuality = 0,
        HighQualityMono = 1,
        LowQuality = 2,
        LowQualityMono = 3,
        HighQualitySpline = 4,
    }

    /// <summary>
    /// SpectraVoice spectrum resolution (number of samples).
    /// </summary>
    public enum SpectraVoiceResolution
    {
        Size4096 = 0,
        Size8192 = 1,
        Size16384 = 2,
        Size32768 = 3,
        Size65536 = 4,
        Size131072 = 5,
    }

    public enum Toggle
    {
        Off = 0,
        On = 1,
    }

    public enum ToggleInverse
    {
        On = 0,
        Off = 1,
    }

    public enum VelocityToControlOnNoteOff
    {
        DoNothing = 0,
        VelocityDown = 1,
        VelocityUp = 2,
    }

    public enum VibratoFrequencyUnit
    {
        /// <summary>
        /// Hz divided by 64.
        /// </summary>
        HzDividedBy64 = 0,
        Millisecond = 1,
        Hz = 2,

        /// <summary>
        /// Smallest time interval in SunVox.
        /// </summary>
        Tick = 3,
        Line = 4,
        HalfLine = 5,
        OneThirdLine = 6,
    }

    /// <summary>
    /// Vocal Filter voice types representing different vocal tract characteristics.
    /// </summary>
    public enum VocalFilterVoiceType
    {
        Soprano = 0,
        Alto = 1,
        Tenor = 2,
        Bass = 3,
    }

    /// <summary>
    /// Vocal Filter vowel types for formant simulation.
    /// </summary>
    public enum VocalFilterVowel
    {
        A = 0,
        E = 1,
        I = 2,
        O = 3,
        U = 4,
    }
}
