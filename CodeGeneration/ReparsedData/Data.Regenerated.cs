/*
 * IMPORTANT!
 * Please run CodeGeneration each time this file is manually changed.
*/

using CodeGeneration.Generators;

namespace CodeGeneration.ReparsedData
{
    public partial class Data
    {
        public static Data GetData()
        {
            var data = new Data();

            data.Enums = new EnumDesc[]
            {
                new EnumDesc(
                    "ADSRCurveType",
                    new []{
                        (0, "Linear"),
                        (1, "Exp1"),
                        (2, "Exp2"),
                        (3, "Nexp1"),
                        (4, "Nexp2"),
                        (5, "Sin"),
                        (6, "Rect"),
                        (7, "SmoothRect"),
                        (8, "Bit2"),
                        (9, "Bit3"),
                        (10, "Bit4"),
                        (11, "Bit5"),
                    }
                ),
                new EnumDesc(
                    "ADSRMode",
                    new []{
                        (0, "Generator"),
                        (1, "AmplitudeModulatorMono"),
                        (2, "AmplitudeModulatorStereo"),
                    }
                ),
                new EnumDesc(
                    "ADSROnNoteOffBehaviour",
                    new []{
                        (0, "DoNothing"),
                        (1, "StopOnLastNote"),
                        (2, "Stop"),
                    }
                ),
                new EnumDesc(
                    "ADSROnNoteOnBehaviour",
                    new []{
                        (0, "DoNothing"),
                        (1, "StartOnFirstNote"),
                        (2, "Start"),
                    }
                ),
                new EnumDesc(
                    "ADSRSmoothTransitions",
                    new []{
                        (0, "Off"),
                        (1, "RestartAndVolumeChange"),
                        (2, "RestartAndVolumeChangeSmooth"),
                        (3, "VolumeChange"),
                    }
                ),
                new EnumDesc(
                    "ADSRSustainMode",
                    new []{
                        (0, "Off"),
                        (1, "On"),
                        (2, "Repeat"),
                    }
                ),
                new EnumDesc(
                    "AnalogGeneratorEnvelopeMode",
                    new []{
                        (0, "Off"),
                        (1, "SustainOff"),
                        (2, "SustainOn"),
                    }
                ),
                new EnumDesc(
                    "AnalogGeneratorFilterType",
                    new []{
                        (0, "Off"),
                        (1, "LP12dB"),
                        (2, "HP12dB"),
                        (3, "BP12dB"),
                        (4, "BR12dB"),
                        (5, "LP24dB"),
                        (6, "HP24dB"),
                        (7, "BP24dB"),
                        (8, "BR24dB"),
                    }
                ),
                new EnumDesc(
                    "AnalogGeneratorOsc2Mode",
                    new []{
                        (0, "Add"),
                        (1, "Sub"),
                        (2, "Mul"),
                        (3, "Min"),
                        (4, "Max"),
                        (5, "BitwiseAnd"),
                        (6, "BitwiseXor"),
                    }
                ),
                new EnumDesc(
                    "AnalogGeneratorWaveform",
                    new []{
                        (0, "Triangle"),
                        (1, "Saw"),
                        (2, "Square"),
                        (3, "NoiseSampler"),
                        (4, "Drawn"),
                        (5, "Sin"),
                        (6, "Hsin"),
                        (7, "Asin"),
                        (8, "DrawnSpline"),
                        (9, "NoiseSamplerSpline"),
                        (10, "WhiteNoise"),
                        (11, "PinkNoise"),
                        (12, "RedNoise"),
                        (13, "BlueNosie"),
                        (14, "VioletNoise"),
                        (15, "GreyNoise"),
                        (16, "Harmonics"),
                    }
                ),
                new EnumDesc(
                    "Channels",
                    new []{
                        (0, "Stereo"),
                        (1, "Mono"),
                    }
                ),
                new EnumDesc(
                    "ChannelsInverted",
                    new []{
                        (0, "Mono"),
                        (1, "Stereo"),
                    }
                ),
                new EnumDesc(
                    "CompressorMode",
                    new []{
                        (0, "Peak"),
                        (1, "RMS"),
                        (2, "PeakZeroLatency"),
                    }
                ),
                new EnumDesc(
                    "ControlToNoteOffBehaviour",
                    new []{
                        (0, "Nothing"),
                        (1, "OnMinPitch"),
                        (2, "OnMaxPitch"),
                    }
                ),
                new EnumDesc(
                    "ControlToNoteOnBehaviour",
                    new []{
                        (0, "Nothing"),
                        (1, "OnPitchChange"),
                    }
                ),
                new EnumDesc(
                    "DelayUnit",
                    new []{
                        (0, "SecondDivBy16384"),
                        (1, "Millisecond"),
                        (2, "Hz"),
                        (3, "Tick"),
                        (4, "Line"),
                        (5, "HalfLine"),
                        (6, "OneThirdLine"),
                        (7, "SecondDivBy44100"),
                        (8, "SecondDivBy48000"),
                        (9, "Sample"),
                    }
                ),
                new EnumDesc(
                    "DistortionType",
                    new []{
                        (0, "Clipping"),
                        (1, "Foldback"),
                        (2, "Foldback2"),
                        (3, "Foldback3"),
                        (4, "Overflow"),
                        (5, "Overflow2"),
                        (6, "SaturationFoldback"),
                        (7, "SaturationFoldbackSin"),
                        (8, "Saturation3"),
                        (9, "Saturation4"),
                        (10, "Saturation5"),
                    }
                ),
                new EnumDesc(
                    "EchoDelayUnit",
                    new []{
                        (0, "SecondDivBy256"),
                        (1, "Millisecond"),
                        (2, "Hz"),
                        (3, "Tick"),
                        (4, "Line"),
                        (5, "HalfLine"),
                        (6, "OneThirdLine"),
                    }
                ),
                new EnumDesc(
                    "EchoFilter",
                    new []{
                        (0, "Off"),
                        (1, "LP6dB"),
                        (2, "HP6dB"),
                    }
                ),
                new EnumDesc(
                    "FFTBufferOverlap",
                    new []{
                        (0, "None"),
                        (1, "x2"),
                        (2, "x4"),
                    }
                ),
                new EnumDesc(
                    "FFTBufferSize",
                    new []{
                        (0, "x64"),
                        (1, "x128"),
                        (2, "x256"),
                        (3, "x512"),
                        (4, "x1024"),
                        (5, "x2048"),
                        (6, "x4096"),
                        (7, "x8192"),
                    }
                ),
                new EnumDesc(
                    "FFTSampleRate",
                    new []{
                        (0, "Hz8000"),
                        (1, "Hz11025"),
                        (2, "Hz16000"),
                        (3, "Hz22050"),
                        (4, "Hz32000"),
                        (5, "Hz44100"),
                        (6, "Hz48000"),
                        (7, "Hz88200"),
                        (8, "Hz96000"),
                        (9, "Hz192000"),
                    }
                ),
                new EnumDesc(
                    "FilterLFOFrequencyUnit",
                    new []{
                        (0, "FiveHundredthHz"),
                        (1, "Millisecond"),
                        (2, "Hz"),
                        (3, "Tick"),
                        (4, "Line"),
                        (5, "HalfLine"),
                        (6, "OneThirdLine"),
                    }
                ),
                new EnumDesc(
                    "FilterLFOWaveform",
                    new []{
                        (0, "Sin"),
                        (1, "Saw"),
                        (2, "Saw2"),
                        (3, "Square"),
                        (4, "Random"),
                    }
                ),
                new EnumDesc(
                    "FilterProMode",
                    new []{
                        (0, "Stereo"),
                        (1, "Mono"),
                        (2, "StereoSmoothing"),
                        (3, "MonoSmoothing"),
                    }
                ),
                new EnumDesc(
                    "FilterProRollOff",
                    new []{
                        (0, "dB12"),
                        (1, "dB24"),
                        (2, "dB36"),
                        (3, "dB48"),
                    }
                ),
                new EnumDesc(
                    "FilterProType",
                    new []{
                        (0, "LP"),
                        (1, "HP"),
                        (2, "BPConstSkirtGain"),
                        (3, "BPConstPeakGain"),
                        (4, "Notch"),
                        (5, "AllPass"),
                        (6, "Peaking"),
                        (7, "LowShelf"),
                        (8, "HighShelf"),
                        (9, "LP6dB"),
                        (10, "HP6dB"),
                    }
                ),
                new EnumDesc(
                    "FilterRollOff",
                    new []{
                        (0, "dB12"),
                        (1, "dB24"),
                        (2, "dB36"),
                        (3, "dB48"),
                    }
                ),
                new EnumDesc(
                    "FilterType",
                    new []{
                        (0, "LP"),
                        (1, "HP"),
                        (2, "BP"),
                        (3, "Notch"),
                    }
                ),
                new EnumDesc(
                    "FlangerLFOFrequencyUnit",
                    new []{
                        (0, "FiveHundredthHz"),
                        (1, "Millisecond"),
                        (2, "Hz"),
                        (3, "Tick"),
                        (4, "Line"),
                        (5, "HalfLine"),
                        (6, "OneThirdLine"),
                    }
                ),
                new EnumDesc(
                    "FlangerLFOWaveform",
                    new []{
                        (0, "Hsin"),
                        (1, "Sin"),
                    }
                ),
                new EnumDesc(
                    "FMXCustomWaveform",
                    new []{
                        (0, "Off"),
                        (1, "SingleCycle"),
                        (2, "Continuous"),
                    }
                ),
                new EnumDesc(
                    "FMXModulationType",
                    new []{
                        (0, "Phase"),
                        (1, "Frequency"),
                        (2, "Amplitude"),
                        (3, "Add"),
                        (4, "Sub"),
                        (5, "Min"),
                        (6, "Max"),
                        (7, "And"),
                        (8, "Xor"),
                        (9, "PhasePlus"),
                    }
                ),
                new EnumDesc(
                    "FMXSampleRate",
                    new []{
                        (0, "Hz8000"),
                        (1, "Hz11025"),
                        (2, "Hz16000"),
                        (3, "Hz22050"),
                        (4, "Hz32000"),
                        (5, "Hz44100"),
                        (6, "Native"),
                    }
                ),
                new EnumDesc(
                    "FMXWaveform",
                    new []{
                        (0, "Custom"),
                        (1, "Triangle"),
                        (2, "Triangle3"),
                        (3, "Saw"),
                        (4, "Saw3"),
                        (5, "Square"),
                        (6, "Sin"),
                        (7, "Hsin"),
                        (8, "Asin"),
                        (9, "Sin3"),
                    }
                ),
                new EnumDesc(
                    "GeneratorWaveform",
                    new []{
                        (0, "Triangle"),
                        (1, "Saw"),
                        (2, "Square"),
                        (3, "NoiseSampler"),
                        (4, "Drawn"),
                        (5, "Sin"),
                        (6, "Hsin"),
                        (7, "Asin"),
                        (8, "Rsin"),
                    }
                ),
                new EnumDesc(
                    "KickerWaveform",
                    new []{
                        (0, "Triangle"),
                        (1, "Square"),
                        (2, "Sin"),
                    }
                ),
                new EnumDesc(
                    "LFOFrequencyUnit",
                    new []{
                        (0, "HzDividedBy64"),
                        (1, "Millisecond"),
                        (2, "Hz"),
                        (3, "Tick"),
                        (4, "Line"),
                        (5, "HalfLine"),
                        (6, "OneThirdLine"),
                    }
                ),
                new EnumDesc(
                    "LFOSineQuality",
                    new []{
                        (0, "Auto"),
                        (1, "Low"),
                        (2, "Middle"),
                        (3, "High"),
                    }
                ),
                new EnumDesc(
                    "LFOSmoothTransitions",
                    new []{
                        (0, "Off"),
                        (1, "Waveform"),
                    }
                ),
                new EnumDesc(
                    "LFOType",
                    new []{
                        (0, "Amplitude"),
                        (1, "Panning"),
                    }
                ),
                new EnumDesc(
                    "LFOWaveform",
                    new []{
                        (0, "Sin"),
                        (1, "Square"),
                        (2, "Sin2"),
                        (3, "Saw"),
                        (4, "Saw2"),
                        (5, "Random"),
                        (6, "Triangle"),
                        (7, "RandomInterpolated"),
                    }
                ),
                new EnumDesc(
                    "LoopMode",
                    new []{
                        (0, "Normal"),
                        (1, "PingPong"),
                    }
                ),
                new EnumDesc(
                    "LoopTimeUnit",
                    new []{
                        (0, "LineDivBy128"),
                        (1, "Line"),
                        (2, "HalfLine"),
                        (3, "OneThirdLine"),
                        (4, "Tick"),
                        (5, "Millisecond"),
                        (6, "Hz"),
                    }
                ),
                new EnumDesc(
                    "MetaModulePatternMode",
                    new []{
                        (0, "Off"),
                        (1, "OnRepeat"),
                        (2, "OnNoRepeat"),
                        (3, "OnRepeatEndless"),
                        (4, "OnNoRepeatEndless"),
                    }
                ),
                new EnumDesc(
                    "ModulationType",
                    new []{
                        (0, "Amplitude"),
                        (1, "Phase"),
                        (2, "PhaseAbsolute"),
                    }
                ),
                new EnumDesc(
                    "PitchDetectorAlgorithm",
                    new []{
                        (0, "FastZeroCrossing"),
                        (1, "Autocorrelation"),
                        (2, "Cepstrum"),
                    }
                ),
                new EnumDesc(
                    "PitchDetectorAlgSampleRate",
                    new []{
                        (0, "Hz12000"),
                        (1, "Hz24000"),
                        (2, "Hz44100"),
                    }
                ),
                new EnumDesc(
                    "PitchDetectorBufferSize",
                    new []{
                        (0, "Ms5"),
                        (1, "Ms10"),
                        (2, "Ms21"),
                        (3, "Ms42"),
                        (4, "Ms85"),
                    }
                ),
                new EnumDesc(
                    "PitchShifterBypassMode",
                    new []{
                        (0, "Off"),
                        (1, "SlowTransition"),
                        (2, "FastTransition"),
                    }
                ),
                new EnumDesc(
                    "PitchToControlMode",
                    new []{
                        (0, "FrequencyHz"),
                        (1, "Pitch"),
                    }
                ),
                new EnumDesc(
                    "PitchToControlOnNoteOff",
                    new []{
                        (0, "DoNothing"),
                        (1, "PitchDown"),
                        (2, "PitchUp"),
                    }
                ),
                new EnumDesc(
                    "Quality",
                    new []{
                        (0, "HQ"),
                        (1, "HQMono"),
                        (2, "LQ"),
                        (3, "LQMono"),
                    }
                ),
                new EnumDesc(
                    "SamplerEnvelopeInterpolation",
                    new []{
                        (0, "Off"),
                        (1, "Linear"),
                    }
                ),
                new EnumDesc(
                    "SamplerInterpolation",
                    new []{
                        (0, "Off"),
                        (1, "Linear"),
                        (2, "Spline"),
                    }
                ),
                new EnumDesc(
                    "SoundToControlMode",
                    new []{
                        (0, "LQ"),
                        (1, "HQ"),
                    }
                ),
                new EnumDesc(
                    "SpectraVoiceHarmonicType",
                    new []{
                        (0, "Hsin"),
                        (1, "Rect"),
                        (2, "Org1"),
                        (3, "Org2"),
                        (4, "Org3"),
                        (5, "Org4"),
                        (6, "Sin"),
                        (7, "Random"),
                        (8, "Triangle1"),
                        (9, "Triangle2"),
                        (10, "Overtones1"),
                        (11, "Overtones2"),
                        (12, "Overtones3"),
                        (13, "Overtones4"),
                        (14, "Overtones1Plus"),
                        (15, "Overtones2Plus"),
                        (16, "Overtones3Plus"),
                        (17, "Overtones4Plus"),
                        (18, "Metal"),
                    }
                ),
                new EnumDesc(
                    "SpectraVoiceMode",
                    new []{
                        (0, "HQ"),
                        (1, "HQMono"),
                        (2, "LQ"),
                        (3, "LQMono"),
                        (4, "HQSpline"),
                    }
                ),
                new EnumDesc(
                    "SpectraVoiceResolution",
                    new []{
                        (0, "Size4096"),
                        (1, "Size8192"),
                        (2, "Size16384"),
                        (3, "Size32768"),
                        (4, "Size65536"),
                        (5, "Size131072"),
                    }
                ),
                new EnumDesc(
                    "Toggle",
                    new []{
                        (0, "Off"),
                        (1, "On"),
                    }
                ),
                new EnumDesc(
                    "ToggleInverse",
                    new []{
                        (0, "On"),
                        (1, "Off"),
                    }
                ),
                new EnumDesc(
                    "VelocityToControlOnNoteOff",
                    new []{
                        (0, "DoNothing"),
                        (1, "VelocityDown"),
                        (2, "VelocityUp"),
                    }
                ),
                new EnumDesc(
                    "VibratoFrequencyUnit",
                    new []{
                        (0, "HzDividedBy64"),
                        (1, "Millisecond"),
                        (2, "Hz"),
                        (3, "Tick"),
                        (4, "Line"),
                        (5, "HalfLine"),
                        (6, "OneThirdLine"),
                    }
                ),
                new EnumDesc(
                    "VocalFilterVoiceType",
                    new []{
                        (0, "Soprano"),
                        (1, "Alto"),
                        (2, "Tenor"),
                        (3, "Bass"),
                    }
                ),
                new EnumDesc(
                    "VocalFilterVowel",
                    new []{
                        (0, "A"),
                        (1, "E"),
                        (2, "I"),
                        (3, "O"),
                        (4, "U"),
                    }
                ),
            };

            data.Modules = new ModuleDesc[]
            {
                new ModuleDesc(
                    "ADSR",
                    "ADSR",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 32768),
                        new CtlDesc(1, "Attack", "Attack", "", 0, 10000),
                        new CtlDesc(2, "Decay", "Decay", "", 0, 10000),
                        new CtlDesc(3, "SustainLevel", "Sustain level", "", 0, 32768),
                        new CtlDesc(4, "Release", "Release", "", 0, 10000),
                        new CtlDesc(5, "AttackCurve", "Attack curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(6, "DecayCurve", "Decay curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(7, "ReleaseCurve", "Release curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(8, "Sustain", "Sustain", "", 0, 2, enumTypeName: "ADSRSustainMode"),
                        new CtlDesc(9, "SustainPedal", "Sustain pedal", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(10, "State", "State", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(11, "OnNoteOn", "On NoteON", "", 0, 2, enumTypeName: "ADSROnNoteOnBehaviour"),
                        new CtlDesc(12, "OnNoteOff", "On NoteOFF", "", 0, 2, enumTypeName: "ADSROnNoteOffBehaviour"),
                        new CtlDesc(13, "Mode", "Mode", "", 0, 2, enumTypeName: "ADSRMode"),
                        new CtlDesc(14, "SmoothTransitions", "Smooth transitions", "", 0, 3, enumTypeName: "ADSRSmoothTransitions"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Amplifier",
                    "Amplifier",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 1024),
                        new CtlDesc(1, "Balance", "Balance", "", -128, 128),
                        new CtlDesc(2, "DCOffset", "DC Offset", "", -128, 128),
                        new CtlDesc(3, "Inverse", "Inverse", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(4, "StereoWidth", "Stereo width", "", 0, 256),
                        new CtlDesc(5, "Absolute", "Absolute", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(6, "FineVolume", "Fine volume", "", 0, 32768),
                        new CtlDesc(7, "Gain", "Gain", "", 0, 5000),
                        new CtlDesc(8, "BipolarDCOffset", "Bipolar DC Offset", "", -16384, 16384),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "AnalogGenerator",
                    "Analog generator",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 256),
                        new CtlDesc(1, "Waveform", "Waveform", "", 0, 16, enumTypeName: "AnalogGeneratorWaveform"),
                        new CtlDesc(2, "Panning", "Panning", "", -128, 128),
                        new CtlDesc(3, "Attack", "Attack", "", 0, 256),
                        new CtlDesc(4, "Release", "Release", "", 0, 256),
                        new CtlDesc(5, "Sustain", "Sustain", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(6, "ExponentialEnvelope", "Exponential envelope", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(7, "DutyCycle", "Duty cycle", "", 0, 1024),
                        new CtlDesc(8, "Osc2", "Osc2", "", -1000, 1000),
                        new CtlDesc(9, "Filter", "Filter", "", 0, 8, enumTypeName: "AnalogGeneratorFilterType"),
                        new CtlDesc(10, "FFreq", "F.freq", "", 0, 14000),
                        new CtlDesc(11, "FResonance", "F.resonance", "", 0, 1530),
                        new CtlDesc(12, "FExponentialFreq", "F.exponential freq", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(13, "FAttack", "F.attack", "", 0, 256),
                        new CtlDesc(14, "FRelease", "F.release", "", 0, 256),
                        new CtlDesc(15, "FEnvelope", "F.envelope", "", 0, 2, enumTypeName: "AnalogGeneratorEnvelopeMode"),
                        new CtlDesc(16, "Polyphony", "Polyphony", "", 1, 32, ignoreInternalEnum: true),
                        new CtlDesc(17, "Mode", "Mode", "", 0, 3, enumTypeName: "Quality"),
                        new CtlDesc(18, "Noise", "Noise", "", 0, 256),
                        new CtlDesc(19, "Osc2Volume", "Osc2 volume", "", 0, 32768),
                        new CtlDesc(20, "Osc2Mode", "Osc2 mode", "", 0, 6, enumTypeName: "AnalogGeneratorOsc2Mode"),
                        new CtlDesc(21, "Osc2Phase", "Osc2 phase", "", 0, 32768),
                    },
                    new List<CurveDesc>()
                    {
                        new CurveDesc(0, "DrawnValues", "Used for 'Drawn', 'DrawnSpline' and 'Harmonics'.", -1, 1, 32),
                    },
                    null
                ),
                new ModuleDesc(
                    "Compressor",
                    "Compressor",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 512),
                        new CtlDesc(1, "Threshold", "Threshold", "", 0, 512),
                        new CtlDesc(2, "Slope", "Slope", "", 0, 200),
                        new CtlDesc(3, "Attack", "Attack", "", 0, 500),
                        new CtlDesc(4, "Release", "Release", "", 1, 1000),
                        new CtlDesc(5, "Mode", "Mode", "", 0, 2, enumTypeName: "CompressorMode"),
                        new CtlDesc(6, "SideChainInput", "Side-chain input", "", 0, 32, ignoreInternalEnum: true),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "ControlToNote",
                    "Ctl2Note",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Pitch", "Pitch", "", 0, 32768),
                        new CtlDesc(1, "FirstNote", "First note", "", 0, 120, ignoreInternalEnum: true),
                        new CtlDesc(2, "RangeNumberOfSemitones", "Range (number of semitones)", "", 0, 120, ignoreInternalEnum: true),
                        new CtlDesc(3, "Transpose", "Transpose", "", -128, 128, ignoreInternalEnum: true),
                        new CtlDesc(4, "Finetune", "Finetune", "", -256, 256),
                        new CtlDesc(5, "Velocity", "Velocity", "", 0, 256),
                        new CtlDesc(6, "State", "State", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(7, "NoteOn", "NoteON", "", 0, 1, enumTypeName: "ControlToNoteOnBehaviour"),
                        new CtlDesc(8, "NoteOff", "NoteOFF", "", 0, 2, enumTypeName: "ControlToNoteOffBehaviour"),
                        new CtlDesc(9, "RecordNotes", "Record notes", "", 0, 1, enumTypeName: "Toggle"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "DcBlocker",
                    "DC Blocker",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Channels", "Channels", "", 0, 1, enumTypeName: "Channels"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Delay",
                    "Delay",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Dry", "Dry", "", 0, 512),
                        new CtlDesc(1, "Wet", "Wet", "", 0, 512),
                        new CtlDesc(2, "DelayL", "Delay L", "", 0, 256),
                        new CtlDesc(3, "DelayR", "Delay R", "", 0, 256),
                        new CtlDesc(4, "VolumeL", "Volume L", "", 0, 256),
                        new CtlDesc(5, "VolumeR", "Volume R", "", 0, 256),
                        new CtlDesc(6, "Channels", "Channels", "", 0, 1, enumTypeName: "Channels"),
                        new CtlDesc(7, "Inverse", "Inverse", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(8, "DelayUnit", "Delay unit", "", 0, 9, enumTypeName: "DelayUnit"),
                        new CtlDesc(9, "DelayMultiplier", "Delay multiplier", "", 1, 15, ignoreInternalEnum: true),
                        new CtlDesc(10, "Feedback", "Feedback", "", 0, 32768),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Distortion",
                    "Distortion",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 256),
                        new CtlDesc(1, "DistortionType", "Type", "", 0, 10, enumTypeName: "DistortionType"),
                        new CtlDesc(2, "Power", "Power", "", 0, 256),
                        new CtlDesc(3, "BitDepth", "Bit depth", "", 1, 16, ignoreInternalEnum: true),
                        new CtlDesc(4, "Freq", "Freq", "", 0, 44100),
                        new CtlDesc(5, "Noise", "Noise", "", 0, 256),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "DrumSynth",
                    "DrumSynth",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 512),
                        new CtlDesc(1, "Panning", "Panning", "", -128, 128),
                        new CtlDesc(2, "Polyphony", "Polyphony", "", 1, 8, ignoreInternalEnum: true),
                        new CtlDesc(3, "BassVolume", "Bass volume", "", 0, 512),
                        new CtlDesc(4, "BassPower", "Bass power", "", 0, 256),
                        new CtlDesc(5, "BassTone", "Bass tone", "", 0, 256),
                        new CtlDesc(6, "BassLength", "Bass length", "", 0, 256),
                        new CtlDesc(7, "HihatVolume", "Hihat volume", "", 0, 512),
                        new CtlDesc(8, "HihatLength", "Hihat length", "", 0, 256),
                        new CtlDesc(9, "SnareVolume", "Snare volume", "", 0, 512),
                        new CtlDesc(10, "SnareTone", "Snare tone", "", 0, 256),
                        new CtlDesc(11, "SnareLength", "Snare length", "", 0, 256),
                        new CtlDesc(12, "BassPanning", "Bass panning", "", -128, 128),
                        new CtlDesc(13, "HihatPanning", "Hihat panning", "", -128, 128),
                        new CtlDesc(14, "SnarePanning", "Snare panning", "", -128, 128),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Echo",
                    "Echo",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Dry", "Dry", "", 0, 256),
                        new CtlDesc(1, "Wet", "Wet", "", 0, 256),
                        new CtlDesc(2, "Feedback", "Feedback", "", 0, 256),
                        new CtlDesc(3, "Delay", "Delay", "", 0, 256),
                        new CtlDesc(4, "RightChannelOffset", "Right channel offset", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(5, "DelayUnit", "Delay unit", "", 0, 6, enumTypeName: "EchoDelayUnit"),
                        new CtlDesc(6, "RightChannelOffsetDelay", "Right channel offset", "Delay/32768", 0, 32768),
                        new CtlDesc(7, "Filter", "Filter", "", 0, 2, enumTypeName: "EchoFilter"),
                        new CtlDesc(8, "FFreq", "F.freq", "", 0, 22000),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "EQ",
                    "EQ",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Low", "Low", "", 0, 512),
                        new CtlDesc(1, "Middle", "Middle", "", 0, 512),
                        new CtlDesc(2, "High", "High", "", 0, 512),
                        new CtlDesc(3, "Channels", "Channels", "", 0, 1, enumTypeName: "Channels"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Feedback",
                    "Feedback",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 10000),
                        new CtlDesc(1, "Channels", "Channels", "", 0, 1, enumTypeName: "Channels"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "FFT",
                    "FFT",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "SampleRate", "Sample rate", "", 0, 9, enumTypeName: "FFTSampleRate"),
                        new CtlDesc(1, "Channels", "Channels", "", 0, 1, enumTypeName: "ChannelsInverted"),
                        new CtlDesc(2, "BufferSamples", "Buffer (samples)", "", 0, 7, enumTypeName: "FFTBufferSize"),
                        new CtlDesc(3, "BufOverlap", "Buf overlap", "", 0, 2, enumTypeName: "FFTBufferOverlap"),
                        new CtlDesc(4, "Feedback", "Feedback", "", 0, 32768),
                        new CtlDesc(5, "NoiseReduction", "Noise reduction", "", 0, 32768),
                        new CtlDesc(6, "PhaseGainNorm16384", "Phase gain (norm=16384)", "", 0, 32768, ignoreInternalEnum: true),
                        new CtlDesc(7, "AllPassFilter", "All-pass filter", "", 0, 32768),
                        new CtlDesc(8, "FrequencySpread", "Frequency spread", "", 0, 32768),
                        new CtlDesc(9, "RandomPhase", "Random phase", "", 0, 32768),
                        new CtlDesc(10, "RandomPhaseLite", "Random phase (lite)", "", 0, 32768),
                        new CtlDesc(11, "FreqShift", "Freq shift", "", -4096, 4096),
                        new CtlDesc(12, "Deform1", "Deform1", "", 0, 32768),
                        new CtlDesc(13, "Deform2", "Deform2", "", 0, 32768),
                        new CtlDesc(14, "HPCutoff", "HP cutoff", "", 0, 32768),
                        new CtlDesc(15, "LPCutoff", "LP cutoff", "", 0, 32768),
                        new CtlDesc(16, "Volume", "Volume", "", 0, 32768),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Filter",
                    "Filter",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 256),
                        new CtlDesc(1, "Frequency", "Freq", "", 0, 14000),
                        new CtlDesc(2, "Resonance", "Resonance", "", 0, 1530),
                        new CtlDesc(3, "FilterType", "Type", "", 0, 3, enumTypeName: "FilterType"),
                        new CtlDesc(4, "Response", "Response", "", 0, 256),
                        new CtlDesc(5, "Mode", "Mode", "", 0, 3, enumTypeName: "Quality"),
                        new CtlDesc(6, "Impulse", "Impulse", "", 0, 14000),
                        new CtlDesc(7, "Mix", "Mix", "", 0, 256),
                        new CtlDesc(8, "LFOFreq", "LFO freq", "", 0, 1024),
                        new CtlDesc(9, "LFOAmp", "LFO amp", "", 0, 256),
                        new CtlDesc(10, "SetLFOPhase", "Set LFO phase", "", 0, 256),
                        new CtlDesc(11, "ExponentialFreq", "Exponential freq", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(12, "RollOff", "Roll-off", "", 0, 3, enumTypeName: "FilterRollOff"),
                        new CtlDesc(13, "LFOFreqUnit", "LFO freq unit", "", 0, 6, enumTypeName: "FilterLFOFrequencyUnit"),
                        new CtlDesc(14, "LFOWaveform", "LFO waveform", "", 0, 4, enumTypeName: "FilterLFOWaveform"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "FilterPro",
                    "Filter Pro",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 32768),
                        new CtlDesc(1, "FilterType", "Type", "", 0, 10, enumTypeName: "FilterProType"),
                        new CtlDesc(2, "Freq", "Freq", "", 0, 22000),
                        new CtlDesc(3, "FreqFinetune", "Freq finetune", "", -1000, 1000),
                        new CtlDesc(4, "FreqScale", "Freq scale", "", 0, 200),
                        new CtlDesc(5, "ExponentialFreq", "Exponential freq", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(6, "Q", "Q", "", 0, 32768),
                        new CtlDesc(7, "Gain", "Gain", "", -16384, 16384),
                        new CtlDesc(8, "RollOff", "Roll-off", "", 0, 3, enumTypeName: "FilterProRollOff"),
                        new CtlDesc(9, "Response", "Response", "", 0, 1000),
                        new CtlDesc(10, "Mode", "Mode", "", 0, 3, enumTypeName: "FilterProMode"),
                        new CtlDesc(11, "Mix", "Mix", "", 0, 32768),
                        new CtlDesc(12, "LFOFreq", "LFO freq", "", 0, 1024),
                        new CtlDesc(13, "LFOAmp", "LFO amp", "", 0, 32768),
                        new CtlDesc(14, "LFOWaveform", "LFO waveform", "", 0, 4, enumTypeName: "FilterLFOWaveform"),
                        new CtlDesc(15, "SetLFOPhase", "Set LFO phase", "", 0, 256),
                        new CtlDesc(16, "LFOFreqUnit", "LFO freq unit", "", 0, 6, enumTypeName: "FilterLFOFrequencyUnit"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Flanger",
                    "Flanger",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Dry", "Dry", "", 0, 256),
                        new CtlDesc(1, "Wet", "Wet", "", 0, 256),
                        new CtlDesc(2, "Feedback", "Feedback", "", 0, 256),
                        new CtlDesc(3, "Delay", "Delay", "", 8, 1000),
                        new CtlDesc(4, "Response", "Response", "", 0, 256),
                        new CtlDesc(5, "LFOFreq", "LFO freq", "", 0, 512),
                        new CtlDesc(6, "LFOAmp", "LFO amp", "", 0, 256),
                        new CtlDesc(7, "LFOWaveform", "LFO waveform", "", 0, 1, enumTypeName: "FlangerLFOWaveform"),
                        new CtlDesc(8, "SetLFOPhase", "Set LFO phase", "", 0, 256),
                        new CtlDesc(9, "LFOFreqUnit", "LFO freq unit", "", 0, 6, enumTypeName: "FlangerLFOFrequencyUnit"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "FM",
                    "FM",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "CVolume", "C.Volume", "", 0, 256),
                        new CtlDesc(1, "MVolume", "M.Volume", "", 0, 256),
                        new CtlDesc(2, "Panning", "Panning", "", -128, 128),
                        new CtlDesc(3, "CFreqRatio", "C.Freq ratio", "", 0, 16),
                        new CtlDesc(4, "MFreqRatio", "M.Freq ratio", "", 0, 16),
                        new CtlDesc(5, "MSelfModulation", "M.Self-modulation", "", 0, 256),
                        new CtlDesc(6, "CAttack", "C.Attack", "", 0, 512),
                        new CtlDesc(7, "CDecay", "C.Decay", "", 0, 512),
                        new CtlDesc(8, "CSustain", "C.Sustain", "", 0, 256),
                        new CtlDesc(9, "CRelease", "C.Release", "", 0, 512),
                        new CtlDesc(10, "MAttack", "M.Attack", "", 0, 512),
                        new CtlDesc(11, "MDecay", "M.Decay", "", 0, 512),
                        new CtlDesc(12, "MSustain", "M.Sustain", "", 0, 256),
                        new CtlDesc(13, "MRelease", "M.Release", "", 0, 512),
                        new CtlDesc(14, "MScalingPerKey", "M.Scaling per key", "", 0, 4),
                        new CtlDesc(15, "Polyphony", "Polyphony", "", 1, 16, ignoreInternalEnum: true),
                        new CtlDesc(16, "Mode", "Mode", "", 0, 3, enumTypeName: "Quality"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "FMX",
                    "FMX",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 32768),
                        new CtlDesc(1, "Panning", "Panning", "", -128, 128),
                        new CtlDesc(2, "SampleRate", "Sample rate", "", 0, 6, enumTypeName: "FMXSampleRate"),
                        new CtlDesc(3, "Polyphony", "Polyphony", "", 1, 32, ignoreInternalEnum: true),
                        new CtlDesc(4, "Channels", "Channels", "", 0, 1, enumTypeName: "ChannelsInverted"),
                        new CtlDesc(5, "InputOperatorNum", "Input -> Operator #", "", 0, 5, ignoreInternalEnum: true),
                        new CtlDesc(6, "InputCustomWaveform", "Input -> Custom waveform", "", 0, 2, enumTypeName: "FMXCustomWaveform"),
                        new CtlDesc(7, "ADSRSmoothTransitions", "ADSR smooth transitions", "", 0, 3, enumTypeName: "ADSRSmoothTransitions"),
                        new CtlDesc(8, "NoiseFilter", "Noise filter (32768 - OFF)", "", 0, 32768),
                        new CtlDesc(9, "Volume1", "1 Volume", "", 0, 32768),
                        new CtlDesc(10, "Volume2", "2 Volume", "", 0, 32768),
                        new CtlDesc(11, "Volume3", "3 Volume", "", 0, 32768),
                        new CtlDesc(12, "Volume4", "4 Volume", "", 0, 32768),
                        new CtlDesc(13, "Volume5", "5 Volume", "", 0, 32768),
                        new CtlDesc(14, "Attack1", "1 Attack", "", 0, 10000),
                        new CtlDesc(15, "Attack2", "2 Attack", "", 0, 10000),
                        new CtlDesc(16, "Attack3", "3 Attack", "", 0, 10000),
                        new CtlDesc(17, "Attack4", "4 Attack", "", 0, 10000),
                        new CtlDesc(18, "Attack5", "5 Attack", "", 0, 10000),
                        new CtlDesc(19, "Decay1", "1 Decay", "", 0, 10000),
                        new CtlDesc(20, "Decay2", "2 Decay", "", 0, 10000),
                        new CtlDesc(21, "Decay3", "3 Decay", "", 0, 10000),
                        new CtlDesc(22, "Decay4", "4 Decay", "", 0, 10000),
                        new CtlDesc(23, "Decay5", "5 Decay", "", 0, 10000),
                        new CtlDesc(24, "SustainLevel1", "1 Sustain level", "", 0, 32768),
                        new CtlDesc(25, "SustainLevel2", "2 Sustain level", "", 0, 32768),
                        new CtlDesc(26, "SustainLevel3", "3 Sustain level", "", 0, 32768),
                        new CtlDesc(27, "SustainLevel4", "4 Sustain level", "", 0, 32768),
                        new CtlDesc(28, "SustainLevel5", "5 Sustain level", "", 0, 32768),
                        new CtlDesc(29, "Release1", "1 Release", "", 0, 10000),
                        new CtlDesc(30, "Release2", "2 Release", "", 0, 10000),
                        new CtlDesc(31, "Release3", "3 Release", "", 0, 10000),
                        new CtlDesc(32, "Release4", "4 Release", "", 0, 10000),
                        new CtlDesc(33, "Release5", "5 Release", "", 0, 10000),
                        new CtlDesc(34, "AttackCurve1", "1 Attack curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(35, "AttackCurve2", "2 Attack curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(36, "AttackCurve3", "3 Attack curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(37, "AttackCurve4", "4 Attack curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(38, "AttackCurve5", "5 Attack curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(39, "DecayCurve1", "1 Decay curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(40, "DecayCurve2", "2 Decay curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(41, "DecayCurve3", "3 Decay curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(42, "DecayCurve4", "4 Decay curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(43, "DecayCurve5", "5 Decay curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(44, "ReleaseCurve1", "1 Release curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(45, "ReleaseCurve2", "2 Release curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(46, "ReleaseCurve3", "3 Release curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(47, "ReleaseCurve4", "4 Release curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(48, "ReleaseCurve5", "5 Release curve", "", 0, 11, enumTypeName: "ADSRCurveType"),
                        new CtlDesc(49, "Sustain1", "1 Sustain", "", 0, 2, enumTypeName: "ADSRSustainMode"),
                        new CtlDesc(50, "Sustain2", "2 Sustain", "", 0, 2, enumTypeName: "ADSRSustainMode"),
                        new CtlDesc(51, "Sustain3", "3 Sustain", "", 0, 2, enumTypeName: "ADSRSustainMode"),
                        new CtlDesc(52, "Sustain4", "4 Sustain", "", 0, 2, enumTypeName: "ADSRSustainMode"),
                        new CtlDesc(53, "Sustain5", "5 Sustain", "", 0, 2, enumTypeName: "ADSRSustainMode"),
                        new CtlDesc(54, "SustainPedal1", "1 Sustain pedal", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(55, "SustainPedal2", "2 Sustain pedal", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(56, "SustainPedal3", "3 Sustain pedal", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(57, "SustainPedal4", "4 Sustain pedal", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(58, "SustainPedal5", "5 Sustain pedal", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(59, "EnvelopeScalingPerKey1", "1 Envelope scaling per key", "", -128, 128),
                        new CtlDesc(60, "EnvelopeScalingPerKey2", "2 Envelope scaling per key", "", -128, 128),
                        new CtlDesc(61, "EnvelopeScalingPerKey3", "3 Envelope scaling per key", "", -128, 128),
                        new CtlDesc(62, "EnvelopeScalingPerKey4", "4 Envelope scaling per key", "", -128, 128),
                        new CtlDesc(63, "EnvelopeScalingPerKey5", "5 Envelope scaling per key", "", -128, 128),
                        new CtlDesc(64, "VolumeScalingPerKey1", "1 Volume scaling per key", "", -128, 128),
                        new CtlDesc(65, "VolumeScalingPerKey2", "2 Volume scaling per key", "", -128, 128),
                        new CtlDesc(66, "VolumeScalingPerKey3", "3 Volume scaling per key", "", -128, 128),
                        new CtlDesc(67, "VolumeScalingPerKey4", "4 Volume scaling per key", "", -128, 128),
                        new CtlDesc(68, "VolumeScalingPerKey5", "5 Volume scaling per key", "", -128, 128),
                        new CtlDesc(69, "VelocitySensitivity1", "1 Velocity sensitivity", "", -128, 128),
                        new CtlDesc(70, "VelocitySensitivity2", "2 Velocity sensitivity", "", -128, 128),
                        new CtlDesc(71, "VelocitySensitivity3", "3 Velocity sensitivity", "", -128, 128),
                        new CtlDesc(72, "VelocitySensitivity4", "4 Velocity sensitivity", "", -128, 128),
                        new CtlDesc(73, "VelocitySensitivity5", "5 Velocity sensitivity", "", -128, 128),
                        new CtlDesc(74, "Waveform1", "1 Waveform", "", 0, 9, enumTypeName: "FMXWaveform"),
                        new CtlDesc(75, "Waveform2", "2 Waveform", "", 0, 9, enumTypeName: "FMXWaveform"),
                        new CtlDesc(76, "Waveform3", "3 Waveform", "", 0, 9, enumTypeName: "FMXWaveform"),
                        new CtlDesc(77, "Waveform4", "4 Waveform", "", 0, 9, enumTypeName: "FMXWaveform"),
                        new CtlDesc(78, "Waveform5", "5 Waveform", "", 0, 9, enumTypeName: "FMXWaveform"),
                        new CtlDesc(79, "Noise1", "1 Noise", "", 0, 32768),
                        new CtlDesc(80, "Noise2", "2 Noise", "", 0, 32768),
                        new CtlDesc(81, "Noise3", "3 Noise", "", 0, 32768),
                        new CtlDesc(82, "Noise4", "4 Noise", "", 0, 32768),
                        new CtlDesc(83, "Noise5", "5 Noise", "", 0, 32768),
                        new CtlDesc(84, "Phase1", "1 Phase", "", 0, 32768),
                        new CtlDesc(85, "Phase2", "2 Phase", "", 0, 32768),
                        new CtlDesc(86, "Phase3", "3 Phase", "", 0, 32768),
                        new CtlDesc(87, "Phase4", "4 Phase", "", 0, 32768),
                        new CtlDesc(88, "Phase5", "5 Phase", "", 0, 32768),
                        new CtlDesc(89, "FreqMultiply1", "1 Freq multiply", "", 0, 32000),
                        new CtlDesc(90, "FreqMultiply2", "2 Freq multiply", "", 0, 32000),
                        new CtlDesc(91, "FreqMultiply3", "3 Freq multiply", "", 0, 32000),
                        new CtlDesc(92, "FreqMultiply4", "4 Freq multiply", "", 0, 32000),
                        new CtlDesc(93, "FreqMultiply5", "5 Freq multiply", "", 0, 32000),
                        new CtlDesc(94, "ConstantPitch1", "1 Constant pitch", "", -8192, 8192),
                        new CtlDesc(95, "ConstantPitch2", "2 Constant pitch", "", -8192, 8192),
                        new CtlDesc(96, "ConstantPitch3", "3 Constant pitch", "", -8192, 8192),
                        new CtlDesc(97, "ConstantPitch4", "4 Constant pitch", "", -8192, 8192),
                        new CtlDesc(98, "ConstantPitch5", "5 Constant pitch", "", -8192, 8192),
                        new CtlDesc(99, "SelfModulation1", "1 Self-modulation", "", 0, 32768),
                        new CtlDesc(100, "SelfModulation2", "2 Self-modulation", "", 0, 32768),
                        new CtlDesc(101, "SelfModulation3", "3 Self-modulation", "", 0, 32768),
                        new CtlDesc(102, "SelfModulation4", "4 Self-modulation", "", 0, 32768),
                        new CtlDesc(103, "SelfModulation5", "5 Self-modulation", "", 0, 32768),
                        new CtlDesc(104, "Feedback1", "1 Feedback", "", 0, 32768),
                        new CtlDesc(105, "Feedback2", "2 Feedback", "", 0, 32768),
                        new CtlDesc(106, "Feedback3", "3 Feedback", "", 0, 32768),
                        new CtlDesc(107, "Feedback4", "4 Feedback", "", 0, 32768),
                        new CtlDesc(108, "Feedback5", "5 Feedback", "", 0, 32768),
                        new CtlDesc(109, "ModulationType1", "1 Modulation type", "", 0, 9, enumTypeName: "FMXModulationType"),
                        new CtlDesc(110, "ModulationType2", "2 Modulation type", "", 0, 9, enumTypeName: "FMXModulationType"),
                        new CtlDesc(111, "ModulationType3", "3 Modulation type", "", 0, 9, enumTypeName: "FMXModulationType"),
                        new CtlDesc(112, "ModulationType4", "4 Modulation type", "", 0, 9, enumTypeName: "FMXModulationType"),
                        new CtlDesc(113, "ModulationType5", "5 Modulation type", "", 0, 9, enumTypeName: "FMXModulationType"),
                        new CtlDesc(114, "OutputMode1", "1 Output mode", "", 0, 31, ignoreInternalEnum: true),
                        new CtlDesc(115, "OutputMode2", "2 Output mode", "", 0, 15, ignoreInternalEnum: true),
                        new CtlDesc(116, "OutputMode3", "3 Output mode", "", 0, 7, ignoreInternalEnum: true),
                        new CtlDesc(117, "OutputMode4", "4 Output mode", "", 0, 3, ignoreInternalEnum: true),
                        new CtlDesc(118, "EnvelopeGain", "Envelope gain", "", 0, 8000),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    new AddCodeDesc<FMXAdditionalCodeGenerator>()
                ),
                new ModuleDesc(
                    "Generator",
                    "Generator",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 256),
                        new CtlDesc(1, "Waveform", "Waveform", "", 0, 8, enumTypeName: "GeneratorWaveform"),
                        new CtlDesc(2, "Panning", "Panning", "", -128, 128),
                        new CtlDesc(3, "Attack", "Attack", "", 0, 512),
                        new CtlDesc(4, "Release", "Release", "", 0, 512),
                        new CtlDesc(5, "Polyphony", "Polyphony", "", 1, 16, ignoreInternalEnum: true),
                        new CtlDesc(6, "Mode", "Mode", "", 0, 1, enumTypeName: "Channels"),
                        new CtlDesc(7, "Sustain", "Sustain", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(8, "FreqModulationByInput", "Freq.modulation by input", "", 0, 256),
                        new CtlDesc(9, "DutyCycle", "Duty cycle", "", 0, 1022),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Glide",
                    "Glide",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Response", "Response", "", 0, 1000),
                        new CtlDesc(1, "SampleRate", "Sample rate", "", 1, 32768),
                        new CtlDesc(2, "ResetOnFirstNote", "Reset on 1st note", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(3, "Polyphony", "Polyphony", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(4, "Pitch", "Pitch", "", -600, 600),
                        new CtlDesc(5, "PitchScale", "Pitch scale", "", 0, 200),
                        new CtlDesc(6, "Reset", "Reset", "", 0, 1, enumTypeName: "Toggle"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "GPIO",
                    "GPIO",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Out", "Out", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(1, "OutPin", "Out pin", "", 0, 256, ignoreInternalEnum: true),
                        new CtlDesc(2, "OutThreshold", "Out threshold", "", 0, 100),
                        new CtlDesc(3, "In", "In", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(4, "InPin", "In pin", "", 0, 256, ignoreInternalEnum: true),
                        new CtlDesc(5, "InNote", "In note", "", 0, 128, ignoreInternalEnum: true),
                        new CtlDesc(6, "InAmplitude", "In amplitude", "", 0, 100),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Input",
                    "Input",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 1024),
                        new CtlDesc(1, "Channels", "Channels", "", 0, 1, enumTypeName: "ChannelsInverted"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Kicker",
                    "Kicker",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 256),
                        new CtlDesc(1, "Waveform", "Waveform", "", 0, 2, enumTypeName: "KickerWaveform"),
                        new CtlDesc(2, "Panning", "Panning", "", -128, 128),
                        new CtlDesc(3, "Attack", "Attack", "", 0, 512),
                        new CtlDesc(4, "Release", "Release", "", 0, 512),
                        new CtlDesc(5, "Boost", "Boost", "", 0, 1024),
                        new CtlDesc(6, "Acceleration", "Acceleration", "", 0, 1024),
                        new CtlDesc(7, "Polyphony", "Polyphony", "", 1, 4, ignoreInternalEnum: true),
                        new CtlDesc(8, "NoClick", "No click", "", 0, 1, enumTypeName: "Toggle"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "LFO",
                    "LFO",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 512),
                        new CtlDesc(1, "LfoType", "Type", "", 0, 1, enumTypeName: "LFOType"),
                        new CtlDesc(2, "Amplitude", "Amplitude", "", 0, 256),
                        new CtlDesc(3, "Freq", "Freq", "", 1, 256),
                        new CtlDesc(4, "Waveform", "Waveform", "", 0, 7, enumTypeName: "LFOWaveform"),
                        new CtlDesc(5, "SetPhase", "Set phase", "", 0, 256),
                        new CtlDesc(6, "Channels", "Channels", "", 0, 1, enumTypeName: "Channels"),
                        new CtlDesc(7, "FrequencyUnit", "Frequency unit", "", 0, 6, enumTypeName: "LFOFrequencyUnit"),
                        new CtlDesc(8, "DutyCycle", "Duty cycle", "", 0, 256),
                        new CtlDesc(9, "Generator", "Generator", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(10, "FreqScale", "Freq scale", "", 0, 200),
                        new CtlDesc(11, "SmoothTransitions", "Smooth transitions", "", 0, 1, enumTypeName: "LFOSmoothTransitions"),
                        new CtlDesc(12, "SineQuality", "Sine quality", "", 0, 3, enumTypeName: "LFOSineQuality"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Loop",
                    "Loop",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 256),
                        new CtlDesc(1, "Delay", "Length", "", 0, 256),
                        new CtlDesc(2, "Channels", "Channels", "", 0, 1, enumTypeName: "ChannelsInverted"),
                        new CtlDesc(3, "Repeats", "Repeat (128=endless)", "", 0, 128, ignoreInternalEnum: true),
                        new CtlDesc(4, "Mode", "Mode", "", 0, 1, enumTypeName: "LoopMode"),
                        new CtlDesc(5, "LengthUnit", "Length unit", "", 0, 6, enumTypeName: "LoopTimeUnit"),
                        new CtlDesc(6, "MaxBufferSize", "Max buffer size", "Max buffer size in seconds", 1, 240, ignoreInternalEnum: true),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "MetaModule",
                    "MetaModule",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 1024),
                        new CtlDesc(1, "InputModule", "Input module", "", 1, 256, ignoreInternalEnum: true),
                        new CtlDesc(2, "PlayPatterns", "Play patterns", "", 0, 4, enumTypeName: "MetaModulePatternMode"),
                        new CtlDesc(3, "BPM", "BPM (Beats Per Minute)", "", 1, 1000, ignoreInternalEnum: true),
                        new CtlDesc(4, "TPL", "TPL (Ticks Per Line)", "", 1, 31, ignoreInternalEnum: true),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    new AddCodeDesc<MetaModuleAdditionalCodeGenerator>()
                ),
                new ModuleDesc(
                    "Modulator",
                    "Modulator",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 512),
                        new CtlDesc(1, "ModulationType", "Modulation type", "", 0, 2, enumTypeName: "ModulationType"),
                        new CtlDesc(2, "Channels", "Channels", "", 0, 1, enumTypeName: "Channels"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "MultiControl",
                    "MultiCtl",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Value", "Value", "", 0, 32768),
                        new CtlDesc(1, "Gain", "Gain", "", 0, 1024),
                        new CtlDesc(2, "Quantization", "Quantization", "", 0, 32768),
                        new CtlDesc(3, "OUTOffset", "OUT offset", "", -16384, 16384),
                        new CtlDesc(4, "Response", "Response", "", 0, 1000),
                        new CtlDesc(5, "SampleRate", "Sample rate", "", 1, 32768),
                    },
                    new List<CurveDesc>()
                    {
                        new CurveDesc(0, "Curve", "Modifies applied values.", 0, 1, 257),
                    },
                    null
                ),
                new ModuleDesc(
                    "MultiSynth",
                    "MultiSynth",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Transpose", "Transpose", "", -128, 128, ignoreInternalEnum: true),
                        new CtlDesc(1, "RandomPitch", "Random pitch", "", 0, 4096),
                        new CtlDesc(2, "Velocity", "Velocity", "", 0, 256),
                        new CtlDesc(3, "Finetune", "Finetune", "", -256, 256),
                        new CtlDesc(4, "RandomPhase", "Random phase", "", 0, 32768),
                        new CtlDesc(5, "RandomVelocity", "Random velocity", "", 0, 32768),
                        new CtlDesc(6, "Phase", "Phase", "", 0, 32768),
                        new CtlDesc(7, "Curve2Influence", "Curve2 influence", "", 0, 256),
                    },
                    new List<CurveDesc>()
                    {
                        new CurveDesc(0, "NoteVelocityCurve", "Velocity to apply to arriving note.", 0, 1, 128),
                        new CurveDesc(1, "VelocityToVelocityCurve", "Map velocity values.", 0, 1, 257),
                    },
                    null
                ),
                new ModuleDesc(
                    "Output",
                    "Output",
                    "",
                    new List<CtlDesc>()
                    {
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "PitchDetector",
                    "Pitch Detector",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Algorithm", "Algorithm", "", 0, 2, enumTypeName: "PitchDetectorAlgorithm"),
                        new CtlDesc(1, "Threshold", "Threshold", "", 0, 10000),
                        new CtlDesc(2, "Gain", "Gain", "", 0, 256),
                        new CtlDesc(3, "Microtones", "Microtones", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(4, "DetectorFinetune", "Detector finetune", "", -256, 256),
                        new CtlDesc(5, "LPFilterFreq", "LP filter freq (0 - OFF)", "", 0, 4000),
                        new CtlDesc(6, "LPFilterRollOff", "LP filter roll-off", "", 0, 3, enumTypeName: "FilterRollOff"),
                        new CtlDesc(7, "AlgSampleRateHz", "Alg1-2 Sample rate (Hz)", "", 0, 2, enumTypeName: "PitchDetectorAlgSampleRate"),
                        new CtlDesc(8, "AlgBufferMs", "Alg1-2 Buffer (ms)", "", 0, 4, enumTypeName: "PitchDetectorBufferSize"),
                        new CtlDesc(9, "AlgBufOverlap", "Alg1-2 Buf overlap", "", 0, 100),
                        new CtlDesc(10, "Alg1Sensitivity", "Alg1 Sensitivity (absolute threshold)", "", 0, 100),
                        new CtlDesc(11, "RecordNotes", "Record notes", "", 0, 1, enumTypeName: "Toggle"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "PitchShifter",
                    "Pitch shifter",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 512),
                        new CtlDesc(1, "Pitch", "Pitch", "", -600, 600),
                        new CtlDesc(2, "PitchScale", "Pitch scale", "", 0, 200),
                        new CtlDesc(3, "Feedback", "Feedback", "", 0, 256),
                        new CtlDesc(4, "GrainSize", "Grain size", "", 0, 256),
                        new CtlDesc(5, "Mode", "Mode", "", 0, 3, enumTypeName: "Quality"),
                        new CtlDesc(6, "BypassIfPitchZero", "Bypass if pitch=0", "", 0, 2, enumTypeName: "PitchShifterBypassMode"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "PitchToControl",
                    "Pitch2Ctl",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Mode", "Mode", "", 0, 1, enumTypeName: "PitchToControlMode"),
                        new CtlDesc(1, "OnNoteOff", "On NoteOFF", "", 0, 2, enumTypeName: "PitchToControlOnNoteOff"),
                        new CtlDesc(2, "FirstNote", "First note", "", 0, 256, ignoreInternalEnum: true),
                        new CtlDesc(3, "RangeNumberOfSemitones", "Range (number of semitones)", "", 0, 256, ignoreInternalEnum: true),
                        new CtlDesc(4, "OUTMin", "OUT min", "", 0, 32768),
                        new CtlDesc(5, "OUTMax", "OUT max", "", 0, 32768),
                        new CtlDesc(6, "OUTController", "OUT controller", "", 0, 255, ignoreInternalEnum: true),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Reverb",
                    "Reverb",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Dry", "Dry", "", 0, 256),
                        new CtlDesc(1, "Wet", "Wet", "", 0, 256),
                        new CtlDesc(2, "Feedback", "Feedback", "", 0, 256),
                        new CtlDesc(3, "Damp", "Damp", "", 0, 256),
                        new CtlDesc(4, "StereoWidth", "Stereo width", "", 0, 256),
                        new CtlDesc(5, "Freeze", "Freeze", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(6, "Mode", "Mode", "", 0, 3, enumTypeName: "Quality"),
                        new CtlDesc(7, "AllPassFilter", "All-pass filter", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(8, "RoomSize", "Room size", "", 0, 128),
                        new CtlDesc(9, "RandomSeed", "Random seed", "", 0, 32768, ignoreInternalEnum: true),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Sampler",
                    "Sampler",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 512),
                        new CtlDesc(1, "Panning", "Panning", "", -128, 128),
                        new CtlDesc(2, "SampleInterpolation", "Sample interpolation", "", 0, 2, enumTypeName: "SamplerInterpolation"),
                        new CtlDesc(3, "EnvelopeInterpolation", "Envelope interpolation", "", 0, 1, enumTypeName: "SamplerEnvelopeInterpolation"),
                        new CtlDesc(4, "Polyphony", "Polyphony", "", 1, 32, ignoreInternalEnum: true),
                        new CtlDesc(5, "RecThreshold", "Rec threshold", "", 0, 10000),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    new AddCodeDesc<SamplerAdditionalCodeGenerator>()
                ),
                new ModuleDesc(
                    "SoundToControl",
                    "Sound2Ctl",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "SampleRate", "Sample rate", "", 1, 32768),
                        new CtlDesc(1, "Channels", "Channels", "", 0, 1, enumTypeName: "ChannelsInverted"),
                        new CtlDesc(2, "Absolute", "Absolute", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(3, "Gain", "Gain", "", 0, 1024),
                        new CtlDesc(4, "Smooth", "Smooth", "", 0, 256),
                        new CtlDesc(5, "Mode", "Mode", "", 0, 1, enumTypeName: "SoundToControlMode"),
                        new CtlDesc(6, "OutMin", "OUT min", "", 0, 32768),
                        new CtlDesc(7, "OutMax", "OUT max", "", 0, 32768),
                        new CtlDesc(8, "OUTController", "OUT controller", "", 0, 255, ignoreInternalEnum: true),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "SpectraVoice",
                    "SpectraVoice",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 256),
                        new CtlDesc(1, "Panning", "Panning", "", -128, 128),
                        new CtlDesc(2, "Attack", "Attack", "", 0, 512),
                        new CtlDesc(3, "Release", "Release", "", 0, 512),
                        new CtlDesc(4, "Polyphony", "Polyphony", "", 1, 32, ignoreInternalEnum: true),
                        new CtlDesc(5, "Mode", "Mode", "", 0, 4, enumTypeName: "SpectraVoiceMode"),
                        new CtlDesc(6, "Sustain", "Sustain", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(7, "SpectrumResolution", "Spectrum resolution", "", 0, 5, enumTypeName: "SpectraVoiceResolution"),
                        new CtlDesc(8, "Harmonic", "Harmonic", "", 0, 15, ignoreInternalEnum: true),
                        new CtlDesc(9, "HarmonicFreq", "H.freq", "", 0, 22050, ignoreInternalEnum: true),
                        new CtlDesc(10, "HarmonicVolume", "H.volume", "", 0, 255, ignoreInternalEnum: true),
                        new CtlDesc(11, "HarmonicWidth", "H.width", "", 0, 255, ignoreInternalEnum: true),
                        new CtlDesc(12, "HarmonicType", "H.type", "", 0, 18, enumTypeName: "SpectraVoiceHarmonicType"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "VelocityToControl",
                    "Velocity2Ctl",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "OnNoteOff", "On NoteOFF", "", 0, 2, enumTypeName: "VelocityToControlOnNoteOff"),
                        new CtlDesc(1, "OutMin", "OUT min", "", 0, 32768),
                        new CtlDesc(2, "OutMax", "OUT max", "", 0, 32768),
                        new CtlDesc(3, "OutOffset", "OUT offset", "", -16384, 16384),
                        new CtlDesc(4, "OutController", "OUT controller", "", 0, 255, ignoreInternalEnum: true),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "Vibrato",
                    "Vibrato",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 256),
                        new CtlDesc(1, "Amplitude", "Amplitude", "", 0, 256),
                        new CtlDesc(2, "Freq", "Freq", "", 1, 2048),
                        new CtlDesc(3, "Channels", "Channels", "", 0, 1, enumTypeName: "Channels"),
                        new CtlDesc(4, "SetPhase", "Set phase", "", 0, 256),
                        new CtlDesc(5, "FrequencyUnit", "Frequency unit", "", 0, 6, enumTypeName: "VibratoFrequencyUnit"),
                        new CtlDesc(6, "ExponentialAmplitude", "Exponential amplitude", "", 0, 1, enumTypeName: "Toggle"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "VocalFilter",
                    "Vocal filter",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 512),
                        new CtlDesc(1, "FormantWidth", "Formant width", "", 0, 256),
                        new CtlDesc(2, "Intensity", "Intensity", "", 0, 256),
                        new CtlDesc(3, "Formants", "Formants", "", 1, 5, ignoreInternalEnum: true),
                        new CtlDesc(4, "Vowel", "Vowel (a,e,i,o,u)", "", 0, 256),
                        new CtlDesc(5, "VoiceType", "Voice type", "", 0, 3, enumTypeName: "VocalFilterVoiceType"),
                        new CtlDesc(6, "Channels", "Channels", "", 0, 1, enumTypeName: "Channels"),
                        new CtlDesc(7, "RandomFrequency", "Random frequency", "", 0, 1024),
                        new CtlDesc(8, "RandomSeed", "Random seed", "", 0, 32768),
                        new CtlDesc(9, "Vowel1", "Vowel1", "", 0, 4, enumTypeName: "VocalFilterVowel"),
                        new CtlDesc(10, "Vowel2", "Vowel2", "", 0, 4, enumTypeName: "VocalFilterVowel"),
                        new CtlDesc(11, "Vowel3", "Vowel3", "", 0, 4, enumTypeName: "VocalFilterVowel"),
                        new CtlDesc(12, "Vowel4", "Vowel4", "", 0, 4, enumTypeName: "VocalFilterVowel"),
                        new CtlDesc(13, "Vowel5", "Vowel5", "", 0, 4, enumTypeName: "VocalFilterVowel"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    null
                ),
                new ModuleDesc(
                    "VorbisPlayer",
                    "Vorbis player",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "Volume", "Volume", "", 0, 512),
                        new CtlDesc(1, "OriginalSpeed", "Original speed", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(2, "Finetune", "Finetune", "", -128, 128),
                        new CtlDesc(3, "Transpose", "Transpose", "", -128, 128, ignoreInternalEnum: true),
                        new CtlDesc(4, "Interpolation", "Interpolation", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(5, "Polyphony", "Polyphony", "", 1, 4, ignoreInternalEnum: true),
                        new CtlDesc(6, "Repeat", "Repeat", "", 0, 1, enumTypeName: "Toggle"),
                    },
                    new List<CurveDesc>()
                    {
                    },
                    new AddCodeDesc<VorbisPlayerAdditionalGenerator>()
                ),
                new ModuleDesc(
                    "WaveShaper",
                    "WaveShaper",
                    "",
                    new List<CtlDesc>()
                    {
                        new CtlDesc(0, "InputVolume", "Input volume", "", 0, 512),
                        new CtlDesc(1, "Mix", "Mix", "", 0, 256),
                        new CtlDesc(2, "OutputVolume", "Output volume", "", 0, 512),
                        new CtlDesc(3, "Symmetric", "Symmetric", "", 0, 1, enumTypeName: "Toggle"),
                        new CtlDesc(4, "Mode", "Mode", "", 0, 3, enumTypeName: "Quality"),
                        new CtlDesc(5, "DCBlocker", "DC blocker", "", 0, 1, enumTypeName: "Toggle"),
                    },
                    new List<CurveDesc>()
                    {
                        new CurveDesc(0, "Curve", "Maps input to output.", 0, 1, 256),
                    },
                    null
                ),
            };

            return data;
        }
    }
}
