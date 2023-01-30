/*
 * IMPORTANT!
 * Please run CodeGeneration each time this file is manually changed.
*/

namespace CodeGeneration
{
    public partial class Data
    {
        public static Data GetData()
        {
            var data = new Data();

            data.Enums = new EnumDescription[]
            {
                new EnumDescription(
                    "ADSRCurveType",
                    new []{
                        (0, "Linear"),
                        (1, "Exp1"),
                        (2, "Exp2"),
                        (3, "Nexp1"),
                        (4, "Nexp2"),
                        (5, "Sin"),
                    }
                ),
                new EnumDescription(
                    "ADSRMode",
                    new []{
                        (0, "Generator"),
                        (1, "AmplitudeModulatorMono"),
                        (2, "AmplitudeModulatorStereo"),
                    }
                ),
                new EnumDescription(
                    "ADSROnNoteOffBehaviour",
                    new []{
                        (0, "DoNothing"),
                        (1, "StopOnLastNote"),
                        (2, "Stop"),
                    }
                ),
                new EnumDescription(
                    "ADSROnNoteOnBehaviour",
                    new []{
                        (0, "DoNothing"),
                        (1, "StartOnFirstNote"),
                        (2, "Start"),
                    }
                ),
                new EnumDescription(
                    "ADSRSmoothTransitions",
                    new []{
                        (0, "Off"),
                        (1, "RestartAndVolumeChange"),
                        (2, "RestartAndVolumeChangeSmooth"),
                        (3, "VolumeChange"),
                    }
                ),
                new EnumDescription(
                    "AnalogGeneratorEnvelopeMode",
                    new []{
                        (0, "Off"),
                        (1, "SustainOff"),
                        (2, "SustainOn"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
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
                new EnumDescription(
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
                new EnumDescription(
                    "Channels",
                    new []{
                        (0, "Stereo"),
                        (1, "Mono"),
                    }
                ),
                new EnumDescription(
                    "ChannelsInverted",
                    new []{
                        (0, "Mono"),
                        (1, "Stereo"),
                    }
                ),
                new EnumDescription(
                    "CompressorMode",
                    new []{
                        (0, "Peak"),
                        (1, "RMS"),
                        (2, "PeakZeroLatency"),
                    }
                ),
                new EnumDescription(
                    "ControlToNoteOffBehaviour",
                    new []{
                        (0, "Nothing"),
                        (1, "OnMinPitch"),
                        (2, "OnMaxPitch"),
                    }
                ),
                new EnumDescription(
                    "ControlToNoteOnBehaviour",
                    new []{
                        (0, "Nothing"),
                        (1, "OnPitchChange"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
                    "DistortionType",
                    new []{
                        (0, "Clipping"),
                        (1, "Foldback"),
                        (2, "Foldback2"),
                        (3, "Foldback3"),
                        (4, "Overflow"),
                        (5, "Overflow2"),
                    }
                ),
                new EnumDescription(
                    "EchoFilter",
                    new []{
                        (0, "Off"),
                        (1, "LP6dB"),
                        (2, "HP6dB"),
                    }
                ),
                new EnumDescription(
                    "FFTBufferOverlap",
                    new []{
                        (0, "None"),
                        (1, "x2"),
                        (2, "x4"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
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
                new EnumDescription(
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
                new EnumDescription(
                    "FilterLFOWaveform",
                    new []{
                        (0, "Sin"),
                        (1, "Saw"),
                        (2, "Saw2"),
                        (3, "Square"),
                        (4, "Random"),
                    }
                ),
                new EnumDescription(
                    "FilterProMode",
                    new []{
                        (0, "Stereo"),
                        (1, "Mono"),
                        (2, "StereoSmoothing"),
                        (3, "MonoSmoothing"),
                    }
                ),
                new EnumDescription(
                    "FilterProRollOff",
                    new []{
                        (0, "dB12"),
                        (1, "dB24"),
                        (2, "dB36"),
                        (3, "dB48"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
                    "FilterRollOff",
                    new []{
                        (0, "dB12"),
                        (1, "dB24"),
                        (2, "dB36"),
                        (3, "dB48"),
                    }
                ),
                new EnumDescription(
                    "FilterType",
                    new []{
                        (0, "LP"),
                        (1, "HP"),
                        (2, "BP"),
                        (3, "Notch"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
                    "FlangerLFOWaveform",
                    new []{
                        (0, "Hsin"),
                        (1, "Sin"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
                    "FMXSustainMode",
                    new []{
                        (0, "Off"),
                        (1, "On"),
                        (2, "Repeat"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
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
                new EnumDescription(
                    "KickerWaveform",
                    new []{
                        (0, "Triangle"),
                        (1, "Square"),
                        (2, "Sin"),
                    }
                ),
                new EnumDescription(
                    "LFOSineQuality",
                    new []{
                        (0, "Auto"),
                        (1, "Low"),
                        (2, "Middle"),
                        (3, "High"),
                    }
                ),
                new EnumDescription(
                    "LFOSmoothTransitions",
                    new []{
                        (0, "Off"),
                        (1, "Waveform"),
                    }
                ),
                new EnumDescription(
                    "LFOType",
                    new []{
                        (0, "Amplitude"),
                        (1, "Panning"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
                    "LoopMode",
                    new []{
                        (0, "Normal"),
                        (1, "PingPong"),
                    }
                ),
                new EnumDescription(
                    "MetaModulePatternMode",
                    new []{
                        (0, "Off"),
                        (1, "OnRepeat"),
                        (2, "OnNoRepeat"),
                        (3, "OnRepeatEndless"),
                        (4, "OnNoRepeatEndless"),
                    }
                ),
                new EnumDescription(
                    "ModulationType",
                    new []{
                        (0, "Amplitude"),
                        (1, "Phase"),
                        (2, "PhaseAbsolute"),
                    }
                ),
                new EnumDescription(
                    "PitchDetectorAlgorithm",
                    new []{
                        (0, "FastZeroCrossing"),
                        (1, "Autocorrelation"),
                        (2, "Cepstrum"),
                    }
                ),
                new EnumDescription(
                    "PitchDetectorAlgSampleRate",
                    new []{
                        (0, "Hz12000"),
                        (1, "Hz24000"),
                        (2, "Hz44100"),
                    }
                ),
                new EnumDescription(
                    "PitchShifterBypassMode",
                    new []{
                        (0, "Off"),
                        (1, "SlowTransition"),
                        (2, "FastTransition"),
                    }
                ),
                new EnumDescription(
                    "PitchToControlMode",
                    new []{
                        (0, "FrequencyHz"),
                        (1, "Pitch"),
                    }
                ),
                new EnumDescription(
                    "PitchToControlOnNoteOff",
                    new []{
                        (0, "DoNothing"),
                        (1, "PitchDown"),
                        (2, "PitchUp"),
                    }
                ),
                new EnumDescription(
                    "Quality",
                    new []{
                        (0, "HQ"),
                        (1, "HQMono"),
                        (2, "LQ"),
                        (3, "LQMono"),
                    }
                ),
                new EnumDescription(
                    "SamplerEnvelopeInterpolation",
                    new []{
                        (0, "Off"),
                        (1, "Linear"),
                    }
                ),
                new EnumDescription(
                    "SamplerInterpolation",
                    new []{
                        (0, "Off"),
                        (1, "Linear"),
                        (2, "Spline"),
                    }
                ),
                new EnumDescription(
                    "SoundToControlMode",
                    new []{
                        (0, "LQ"),
                        (1, "HQ"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
                    "SpectraVoiceMode",
                    new []{
                        (0, "HQ"),
                        (1, "HQMono"),
                        (2, "LQ"),
                        (3, "LQMono"),
                        (4, "HQSpline"),
                    }
                ),
                new EnumDescription(
                    "Toggle",
                    new []{
                        (0, "Off"),
                        (1, "On"),
                    }
                ),
                new EnumDescription(
                    "ToggleInverse",
                    new []{
                        (0, "On"),
                        (1, "Off"),
                    }
                ),
                new EnumDescription(
                    "VelocityToControlOnNoteOff",
                    new []{
                        (0, "DoNothing"),
                        (1, "VelocityDown"),
                        (2, "VelocityUp"),
                    }
                ),
                new EnumDescription(
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
                new EnumDescription(
                    "VocalFilterVoiceType",
                    new []{
                        (0, "Soprano"),
                        (1, "Alto"),
                        (2, "Tenor"),
                        (3, "Bass"),
                    }
                ),
                new EnumDescription(
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

            data.Modules = new ModuleDescription[]
            {
                new ModuleDescription(
                    "ADSR",
                    "ADSR",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 32768),
                        new ControllerDescription(1, "Attack", "Attack", "", 0, 10000),
                        new ControllerDescription(2, "Decay", "Decay", "", 0, 10000),
                        new ControllerDescription(3, "SustainLevel", "Sustain level", "", 0, 32768),
                        new ControllerDescription(4, "Release", "Release", "", 0, 10000),
                        new ControllerDescription(5, "AttackCurve", "Attack curve", "", 0, 5),
                        new ControllerDescription(6, "DecayCurve", "Decay curve", "", 0, 5),
                        new ControllerDescription(7, "ReleaseCurve", "Release curve", "", 0, 5),
                        new ControllerDescription(8, "Sustain", "Sustain", "", 0, 2),
                        new ControllerDescription(9, "SustainPedal", "Sustain pedal", "", 0, 1),
                        new ControllerDescription(10, "State", "State", "", 0, 1),
                        new ControllerDescription(11, "OnNoteOn", "On NoteON", "", 0, 2),
                        new ControllerDescription(12, "OnNoteOff", "On NoteOFF", "", 0, 2),
                        new ControllerDescription(13, "Mode", "Mode", "", 0, 2),
                        new ControllerDescription(14, "SmoothTransitions", "Smooth transitions", "", 0, 3),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Amplifier",
                    "Amplifier",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 1024),
                        new ControllerDescription(1, "Balance", "Balance", "", 0, 256),
                        new ControllerDescription(2, "DCOffset", "DC Offset", "", 0, 256),
                        new ControllerDescription(3, "Inverse", "Inverse", "", 0, 1),
                        new ControllerDescription(4, "StereoWidth", "Stereo width", "", 0, 256),
                        new ControllerDescription(5, "Absolute", "Absolute", "", 0, 1),
                        new ControllerDescription(6, "FineVolume", "Fine volume", "", 0, 32768),
                        new ControllerDescription(7, "Gain", "Gain", "", 0, 5000),
                        new ControllerDescription(8, "BipolarDCOffset", "Bipolar DC Offset", "", 0, 32768),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "AnalogGenerator",
                    "Analog generator",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 256),
                        new ControllerDescription(1, "Waveform", "Waveform", "", 0, 16),
                        new ControllerDescription(2, "Panning", "Panning", "", 0, 256),
                        new ControllerDescription(3, "Attack", "Attack", "", 0, 256),
                        new ControllerDescription(4, "Release", "Release", "", 0, 256),
                        new ControllerDescription(5, "Sustain", "Sustain", "", 0, 1),
                        new ControllerDescription(6, "ExponentialEnvelope", "Exponential envelope", "", 0, 1),
                        new ControllerDescription(7, "DutyCycle", "Duty cycle", "", 0, 1024),
                        new ControllerDescription(8, "Osc2", "Osc2", "", 0, 2000),
                        new ControllerDescription(9, "Filter", "Filter", "", 0, 8),
                        new ControllerDescription(10, "FFreq", "F.freq", "", 0, 14000),
                        new ControllerDescription(11, "FResonance", "F.resonance", "", 0, 1530),
                        new ControllerDescription(12, "FExponentialFreq", "F.exponential freq", "", 0, 1),
                        new ControllerDescription(13, "FAttack", "F.attack", "", 0, 256),
                        new ControllerDescription(14, "FRelease", "F.release", "", 0, 256),
                        new ControllerDescription(15, "FEnvelope", "F.envelope", "", 0, 2),
                        new ControllerDescription(16, "Polyphony", "Polyphony", "", 1, 32),
                        new ControllerDescription(17, "Mode", "Mode", "", 0, 3),
                        new ControllerDescription(18, "Noise", "Noise", "", 0, 256),
                        new ControllerDescription(19, "Osc2Volume", "Osc2 volume", "", 0, 32768),
                        new ControllerDescription(20, "Osc2Mode", "Osc2 mode", "", 0, 6),
                        new ControllerDescription(21, "Osc2Phase", "Osc2 phase", "", 0, 32768),
                    },
                    new List<CurveDescription>()
                    {
                        new CurveDescription(0, "DrawnValues", "Used for 'Drawn', 'DrawnSpline' and 'Harmonics'.", -1, 1, 32),
                    }
                ),
                new ModuleDescription(
                    "Compressor",
                    "Compressor",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 512),
                        new ControllerDescription(1, "Threshold", "Threshold", "", 0, 512),
                        new ControllerDescription(2, "Slope", "Slope", "", 0, 200),
                        new ControllerDescription(3, "Attack", "Attack", "", 0, 500),
                        new ControllerDescription(4, "Release", "Release", "", 1, 1000),
                        new ControllerDescription(5, "Mode", "Mode", "", 0, 2),
                        new ControllerDescription(6, "SideChainInput", "Side-chain input", "", 0, 32),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "ControlToNote",
                    "Ctl2Note",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Pitch", "Pitch", "", 0, 32768),
                        new ControllerDescription(1, "FirstNote", "First note", "", 0, 120),
                        new ControllerDescription(2, "RangeNumberOfSemitones", "Range (number of semitones)", "", 0, 120),
                        new ControllerDescription(3, "Transpose", "Transpose", "", 0, 256),
                        new ControllerDescription(4, "Finetune", "Finetune", "", 0, 512),
                        new ControllerDescription(5, "Velocity", "Velocity", "", 0, 256),
                        new ControllerDescription(6, "State", "State", "", 0, 1),
                        new ControllerDescription(7, "NoteOn", "NoteON", "", 0, 1),
                        new ControllerDescription(8, "NoteOff", "NoteOFF", "", 0, 2),
                        new ControllerDescription(9, "RecordNotes", "Record notes", "", 0, 1),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "DcBlocker",
                    "DC Blocker",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Channels", "Channels", "", 0, 1),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Delay",
                    "Delay",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Dry", "Dry", "", 0, 512),
                        new ControllerDescription(1, "Wet", "Wet", "", 0, 512),
                        new ControllerDescription(2, "DelayL", "Delay L", "", 0, 256),
                        new ControllerDescription(3, "DelayR", "Delay R", "", 0, 256),
                        new ControllerDescription(4, "VolumeL", "Volume L", "", 0, 256),
                        new ControllerDescription(5, "VolumeR", "Volume R", "", 0, 256),
                        new ControllerDescription(6, "Channels", "Channels", "", 0, 1, "Channels"),
                        new ControllerDescription(7, "Inverse", "Inverse", "", 0, 1, "Toggle"),
                        new ControllerDescription(8, "DelayUnit", "Delay unit", "", 0, 32768, "DelayUnit"),
                        new ControllerDescription(9, "DelayMultiplier", "Delay multiplier", "", 0, 32768),
                        new ControllerDescription(10, "Feedback", "Feedback", "", 0, 32768),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Distortion",
                    "Distortion",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 256),
                        new ControllerDescription(1, "Type", "Type", "", 0, 5, "DistortionType"),
                        new ControllerDescription(2, "Power", "Power", "", 0, 256),
                        new ControllerDescription(3, "BitDepth", "Bit depth", "", 1, 16),
                        new ControllerDescription(4, "Freq", "Freq", "", 0, 44100),
                        new ControllerDescription(5, "Noise", "Noise", "", 0, 256),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "DrumSynth",
                    "DrumSynth",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 512),
                        new ControllerDescription(1, "Panning", "Panning", "", 0, 256),
                        new ControllerDescription(2, "Polyphony", "Polyphony", "", 1, 8),
                        new ControllerDescription(3, "BassVolume", "Bass volume", "", 0, 512),
                        new ControllerDescription(4, "BassPower", "Bass power", "", 0, 256),
                        new ControllerDescription(5, "BassTone", "Bass tone", "", 0, 256),
                        new ControllerDescription(6, "BassLength", "Bass length", "", 0, 256),
                        new ControllerDescription(7, "HihatVolume", "Hihat volume", "", 0, 512),
                        new ControllerDescription(8, "HihatLength", "Hihat length", "", 0, 256),
                        new ControllerDescription(9, "SnareVolume", "Snare volume", "", 0, 512),
                        new ControllerDescription(10, "SnareTone", "Snare tone", "", 0, 256),
                        new ControllerDescription(11, "SnareLength", "Snare length", "", 0, 256),
                        new ControllerDescription(12, "BassPanning", "Bass panning", "", 0, 256),
                        new ControllerDescription(13, "HihatPanning", "Hihat panning", "", 0, 256),
                        new ControllerDescription(14, "SnarePanning", "Snare panning", "", 0, 256),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Echo",
                    "Echo",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Dry", "Dry", "", 0, 256),
                        new ControllerDescription(1, "Wet", "Wet", "", 0, 256),
                        new ControllerDescription(2, "Feedback", "Feedback", "", 0, 256),
                        new ControllerDescription(3, "Delay", "Delay", "", 0, 256),
                        new ControllerDescription(4, "RightChannelOffset", "Right channel offset", "", 0, 1, "Toggle"),
                        new ControllerDescription(5, "DelayUnit", "Delay unit", "", 0, 32768),
                        new ControllerDescription(6, "RightChannelOffsetDelay", "Right channel offset", "Delay/32768", 0, 32768),
                        new ControllerDescription(7, "Filter", "Filter", "", 0, 2, "EchoFilter"),
                        new ControllerDescription(8, "FFreq", "F.freq", "", 0, 22000),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "EQ",
                    "EQ",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Low", "Low", "", 0, 512),
                        new ControllerDescription(1, "Middle", "Middle", "", 0, 512),
                        new ControllerDescription(2, "High", "High", "", 0, 512),
                        new ControllerDescription(3, "Channels", "Channels", "", 0, 1, "Channels"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Feedback",
                    "Feedback",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 10000),
                        new ControllerDescription(1, "Channels", "Channels", "", 0, 1, "Channels"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "FFT",
                    "FFT",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "SampleRate", "Sample rate", "", 0, 9, "FFTSampleRate"),
                        new ControllerDescription(1, "Channels", "Channels", "", 0, 1, "ChannelsInverted"),
                        new ControllerDescription(2, "BufferSamples", "Buffer (samples)", "", 0, 7, "FFTBufferSize"),
                        new ControllerDescription(3, "BufOverlap", "Buf overlap", "", 0, 2, "FFTBufferOverlap"),
                        new ControllerDescription(4, "Feedback", "Feedback", "", 0, 32768),
                        new ControllerDescription(5, "NoiseReduction", "Noise reduction", "", 0, 32768),
                        new ControllerDescription(6, "PhaseGainNorm16384", "Phase gain (norm=16384)", "", 0, 32768),
                        new ControllerDescription(7, "AllPassFilter", "All-pass filter", "", 0, 32768),
                        new ControllerDescription(8, "FrequencySpread", "Frequency spread", "", 0, 32768),
                        new ControllerDescription(9, "RandomPhase", "Random phase", "", 0, 32768),
                        new ControllerDescription(10, "RandomPhaseLite", "Random phase (lite)", "", 0, 32768),
                        new ControllerDescription(11, "FreqShift", "Freq shift", "", 0, 8192),
                        new ControllerDescription(12, "Deform1", "Deform1", "", 0, 32768),
                        new ControllerDescription(13, "Deform2", "Deform2", "", 0, 32768),
                        new ControllerDescription(14, "HPCutoff", "HP cutoff", "", 0, 32768),
                        new ControllerDescription(15, "LPCutoff", "LP cutoff", "", 0, 32768),
                        new ControllerDescription(16, "Volume", "Volume", "", 0, 32768),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Filter",
                    "Filter",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 256),
                        new ControllerDescription(1, "Freq", "Freq", "", 0, 14000),
                        new ControllerDescription(2, "Resonance", "Resonance", "", 0, 1530),
                        new ControllerDescription(3, "Type", "Type", "", 0, 3, "FilterType"),
                        new ControllerDescription(4, "Response", "Response", "", 0, 256),
                        new ControllerDescription(5, "Mode", "Mode", "", 0, 3, "Quality"),
                        new ControllerDescription(6, "Impulse", "Impulse", "", 0, 14000),
                        new ControllerDescription(7, "Mix", "Mix", "", 0, 256),
                        new ControllerDescription(8, "LFOFreq", "LFO freq", "", 0, 1024),
                        new ControllerDescription(9, "LFOAmp", "LFO amp", "", 0, 256),
                        new ControllerDescription(10, "SetLFOPhase", "Set LFO phase", "", 0, 256),
                        new ControllerDescription(11, "ExponentialFreq", "Exponential freq", "", 0, 1, "Toggle"),
                        new ControllerDescription(12, "RollOff", "Roll-off", "", 0, 3, "FilterRollOff"),
                        new ControllerDescription(13, "LFOFreqUnit", "LFO freq unit", "", 0, 6, "FilterLFOFrequencyUnit"),
                        new ControllerDescription(14, "LFOWaveform", "LFO waveform", "", 0, 4, "FilterLFOWaveform"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "FilterPro",
                    "Filter Pro",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 32768),
                        new ControllerDescription(1, "Type", "Type", "", 0, 10, "FilterProType"),
                        new ControllerDescription(2, "Freq", "Freq", "", 0, 22000),
                        new ControllerDescription(3, "FreqFinetune", "Freq finetune", "", 0, 2000),
                        new ControllerDescription(4, "FreqScale", "Freq scale", "", 0, 200),
                        new ControllerDescription(5, "ExponentialFreq", "Exponential freq", "", 0, 1, "Toggle"),
                        new ControllerDescription(6, "Q", "Q", "", 0, 32768),
                        new ControllerDescription(7, "Gain", "Gain", "", 0, 32768),
                        new ControllerDescription(8, "RollOff", "Roll-off", "", 0, 3, "FilterProRollOff"),
                        new ControllerDescription(9, "Response", "Response", "", 0, 1000),
                        new ControllerDescription(10, "Mode", "Mode", "", 0, 3, "FilterProMode"),
                        new ControllerDescription(11, "Mix", "Mix", "", 0, 32768),
                        new ControllerDescription(12, "LFOFreq", "LFO freq", "", 0, 1024),
                        new ControllerDescription(13, "LFOAmp", "LFO amp", "", 0, 32768),
                        new ControllerDescription(14, "LFOWaveform", "LFO waveform", "", 0, 4, "FilterLFOWaveform"),
                        new ControllerDescription(15, "SetLFOPhase", "Set LFO phase", "", 0, 256),
                        new ControllerDescription(16, "LFOFreqUnit", "LFO freq unit", "", 0, 6, "FilterLFOFrequencyUnit"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Flanger",
                    "Flanger",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Dry", "Dry", "", 0, 256),
                        new ControllerDescription(1, "Wet", "Wet", "", 0, 256),
                        new ControllerDescription(2, "Feedback", "Feedback", "", 0, 256),
                        new ControllerDescription(3, "Delay", "Delay", "", 8, 1000),
                        new ControllerDescription(4, "Response", "Response", "", 0, 256),
                        new ControllerDescription(5, "LFOFreq", "LFO freq", "", 0, 512),
                        new ControllerDescription(6, "LFOAmp", "LFO amp", "", 0, 256),
                        new ControllerDescription(7, "LFOWaveform", "LFO waveform", "", 0, 1, "FlangerLFOWaveform"),
                        new ControllerDescription(8, "SetLFOPhase", "Set LFO phase", "", 0, 256),
                        new ControllerDescription(9, "LFOFreqUnit", "LFO freq unit", "", 0, 6, "FlangerLFOFrequencyUnit"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "FM",
                    "FM",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "CVolume", "C.Volume", "", 0, 256),
                        new ControllerDescription(1, "MVolume", "M.Volume", "", 0, 256),
                        new ControllerDescription(2, "Panning", "Panning", "", 0, 256),
                        new ControllerDescription(3, "CFreqRatio", "C.Freq ratio", "", 0, 16),
                        new ControllerDescription(4, "MFreqRatio", "M.Freq ratio", "", 0, 16),
                        new ControllerDescription(5, "MSelfModulation", "M.Self-modulation", "", 0, 256),
                        new ControllerDescription(6, "CAttack", "C.Attack", "", 0, 512),
                        new ControllerDescription(7, "CDecay", "C.Decay", "", 0, 512),
                        new ControllerDescription(8, "CSustain", "C.Sustain", "", 0, 256),
                        new ControllerDescription(9, "CRelease", "C.Release", "", 0, 512),
                        new ControllerDescription(10, "MAttack", "M.Attack", "", 0, 512),
                        new ControllerDescription(11, "MDecay", "M.Decay", "", 0, 512),
                        new ControllerDescription(12, "MSustain", "M.Sustain", "", 0, 256),
                        new ControllerDescription(13, "MRelease", "M.Release", "", 0, 512),
                        new ControllerDescription(14, "MScalingPerKey", "M.Scaling per key", "", 0, 4),
                        new ControllerDescription(15, "Polyphony", "Polyphony", "", 1, 16),
                        new ControllerDescription(16, "Mode", "Mode", "", 0, 3, "Quality"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "FMX",
                    "FMX",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 32768),
                        new ControllerDescription(1, "Panning", "Panning", "", 0, 256),
                        new ControllerDescription(2, "SampleRate", "Sample rate", "", 0, 6),
                        new ControllerDescription(3, "Polyphony", "Polyphony", "", 1, 32),
                        new ControllerDescription(4, "Channels", "Channels", "", 0, 1),
                        new ControllerDescription(5, "InputOperatorNum", "Input -> Operator #", "", 0, 5),
                        new ControllerDescription(6, "InputCustomWaveform", "Input -> Custom waveform", "", 0, 2),
                        new ControllerDescription(7, "ADSRSmoothTransitions", "ADSR smooth transitions", "", 0, 3),
                        new ControllerDescription(8, "NoiseFilter", "Noise filter (32768 - OFF)", "", 0, 32768),
                        new ControllerDescription(9, "Volume1", "1 Volume", "", 0, 32768),
                        new ControllerDescription(10, "Volume2", "2 Volume", "", 0, 32768),
                        new ControllerDescription(11, "Volume3", "3 Volume", "", 0, 32768),
                        new ControllerDescription(12, "Volume4", "4 Volume", "", 0, 32768),
                        new ControllerDescription(13, "Volume5", "5 Volume", "", 0, 32768),
                        new ControllerDescription(14, "Attack1", "1 Attack", "", 0, 10000),
                        new ControllerDescription(15, "Attack2", "2 Attack", "", 0, 10000),
                        new ControllerDescription(16, "Attack3", "3 Attack", "", 0, 10000),
                        new ControllerDescription(17, "Attack4", "4 Attack", "", 0, 10000),
                        new ControllerDescription(18, "Attack5", "5 Attack", "", 0, 10000),
                        new ControllerDescription(19, "Decay1", "1 Decay", "", 0, 10000),
                        new ControllerDescription(20, "Decay2", "2 Decay", "", 0, 10000),
                        new ControllerDescription(21, "Decay3", "3 Decay", "", 0, 10000),
                        new ControllerDescription(22, "Decay4", "4 Decay", "", 0, 10000),
                        new ControllerDescription(23, "Decay5", "5 Decay", "", 0, 10000),
                        new ControllerDescription(24, "SustainLevel1", "1 Sustain level", "", 0, 32768),
                        new ControllerDescription(25, "SustainLevel2", "2 Sustain level", "", 0, 32768),
                        new ControllerDescription(26, "SustainLevel3", "3 Sustain level", "", 0, 32768),
                        new ControllerDescription(27, "SustainLevel4", "4 Sustain level", "", 0, 32768),
                        new ControllerDescription(28, "SustainLevel5", "5 Sustain level", "", 0, 32768),
                        new ControllerDescription(29, "Release1", "1 Release", "", 0, 10000),
                        new ControllerDescription(30, "Release2", "2 Release", "", 0, 10000),
                        new ControllerDescription(31, "Release3", "3 Release", "", 0, 10000),
                        new ControllerDescription(32, "Release4", "4 Release", "", 0, 10000),
                        new ControllerDescription(33, "Release5", "5 Release", "", 0, 10000),
                        new ControllerDescription(34, "AttackCurve1", "1 Attack curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(35, "AttackCurve2", "2 Attack curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(36, "AttackCurve3", "3 Attack curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(37, "AttackCurve4", "4 Attack curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(38, "AttackCurve5", "5 Attack curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(39, "DecayCurve1", "1 Decay curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(40, "DecayCurve2", "2 Decay curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(41, "DecayCurve3", "3 Decay curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(42, "DecayCurve4", "4 Decay curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(43, "DecayCurve5", "5 Decay curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(44, "ReleaseCurve1", "1 Release curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(45, "ReleaseCurve2", "2 Release curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(46, "ReleaseCurve3", "3 Release curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(47, "ReleaseCurve4", "4 Release curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(48, "ReleaseCurve5", "5 Release curve", "", 0, 5, "ADSRCurveType"),
                        new ControllerDescription(49, "Sustain1", "1 Sustain", "", 0, 2, "FMXSustainMode"),
                        new ControllerDescription(50, "Sustain2", "2 Sustain", "", 0, 2, "FMXSustainMode"),
                        new ControllerDescription(51, "Sustain3", "3 Sustain", "", 0, 2, "FMXSustainMode"),
                        new ControllerDescription(52, "Sustain4", "4 Sustain", "", 0, 2, "FMXSustainMode"),
                        new ControllerDescription(53, "Sustain5", "5 Sustain", "", 0, 2, "FMXSustainMode"),
                        new ControllerDescription(54, "SustainPedal1", "1 Sustain pedal", "", 0, 1, "Toggle"),
                        new ControllerDescription(55, "SustainPedal2", "2 Sustain pedal", "", 0, 1, "Toggle"),
                        new ControllerDescription(56, "SustainPedal3", "3 Sustain pedal", "", 0, 1, "Toggle"),
                        new ControllerDescription(57, "SustainPedal4", "4 Sustain pedal", "", 0, 1, "Toggle"),
                        new ControllerDescription(58, "SustainPedal5", "5 Sustain pedal", "", 0, 1, "Toggle"),
                        new ControllerDescription(59, "EnvelopeScalingPerKey1", "1 Envelope scaling per key", "", 0, 256),
                        new ControllerDescription(60, "EnvelopeScalingPerKey2", "2 Envelope scaling per key", "", 0, 256),
                        new ControllerDescription(61, "EnvelopeScalingPerKey3", "3 Envelope scaling per key", "", 0, 256),
                        new ControllerDescription(62, "EnvelopeScalingPerKey4", "4 Envelope scaling per key", "", 0, 256),
                        new ControllerDescription(63, "EnvelopeScalingPerKey5", "5 Envelope scaling per key", "", 0, 256),
                        new ControllerDescription(64, "VolumeScalingPerKey1", "1 Volume scaling per key", "", 0, 256),
                        new ControllerDescription(65, "VolumeScalingPerKey2", "2 Volume scaling per key", "", 0, 256),
                        new ControllerDescription(66, "VolumeScalingPerKey3", "3 Volume scaling per key", "", 0, 256),
                        new ControllerDescription(67, "VolumeScalingPerKey4", "4 Volume scaling per key", "", 0, 256),
                        new ControllerDescription(68, "VolumeScalingPerKey5", "5 Volume scaling per key", "", 0, 256),
                        new ControllerDescription(69, "VelocitySensitivity1", "1 Velocity sensitivity", "", 0, 256),
                        new ControllerDescription(70, "VelocitySensitivity2", "2 Velocity sensitivity", "", 0, 256),
                        new ControllerDescription(71, "VelocitySensitivity3", "3 Velocity sensitivity", "", 0, 256),
                        new ControllerDescription(72, "VelocitySensitivity4", "4 Velocity sensitivity", "", 0, 256),
                        new ControllerDescription(73, "VelocitySensitivity5", "5 Velocity sensitivity", "", 0, 256),
                        new ControllerDescription(74, "Waveform1", "1 Waveform", "", 0, 9, "FMXWaveform"),
                        new ControllerDescription(75, "Waveform2", "2 Waveform", "", 0, 9, "FMXWaveform"),
                        new ControllerDescription(76, "Waveform3", "3 Waveform", "", 0, 9, "FMXWaveform"),
                        new ControllerDescription(77, "Waveform4", "4 Waveform", "", 0, 9, "FMXWaveform"),
                        new ControllerDescription(78, "Waveform5", "5 Waveform", "", 0, 9, "FMXWaveform"),
                        new ControllerDescription(79, "Noise1", "1 Noise", "", 0, 32768),
                        new ControllerDescription(80, "Noise2", "2 Noise", "", 0, 32768),
                        new ControllerDescription(81, "Noise3", "3 Noise", "", 0, 32768),
                        new ControllerDescription(82, "Noise4", "4 Noise", "", 0, 32768),
                        new ControllerDescription(83, "Noise5", "5 Noise", "", 0, 32768),
                        new ControllerDescription(84, "Phase1", "1 Phase", "", 0, 32768),
                        new ControllerDescription(85, "Phase2", "2 Phase", "", 0, 32768),
                        new ControllerDescription(86, "Phase3", "3 Phase", "", 0, 32768),
                        new ControllerDescription(87, "Phase4", "4 Phase", "", 0, 32768),
                        new ControllerDescription(88, "Phase5", "5 Phase", "", 0, 32768),
                        new ControllerDescription(89, "FreqMultiply1", "1 Freq multiply", "", 0, 32000),
                        new ControllerDescription(90, "FreqMultiply2", "2 Freq multiply", "", 0, 32000),
                        new ControllerDescription(91, "FreqMultiply3", "3 Freq multiply", "", 0, 32000),
                        new ControllerDescription(92, "FreqMultiply4", "4 Freq multiply", "", 0, 32000),
                        new ControllerDescription(93, "FreqMultiply5", "5 Freq multiply", "", 0, 32000),
                        new ControllerDescription(94, "ConstantPitch1", "1 Constant pitch", "", 0, 16384),
                        new ControllerDescription(95, "ConstantPitch2", "2 Constant pitch", "", 0, 16384),
                        new ControllerDescription(96, "ConstantPitch3", "3 Constant pitch", "", 0, 16384),
                        new ControllerDescription(97, "ConstantPitch4", "4 Constant pitch", "", 0, 16384),
                        new ControllerDescription(98, "ConstantPitch5", "5 Constant pitch", "", 0, 16384),
                        new ControllerDescription(99, "SelfModulation1", "1 Self-modulation", "", 0, 32768),
                        new ControllerDescription(100, "SelfModulation2", "2 Self-modulation", "", 0, 32768),
                        new ControllerDescription(101, "SelfModulation3", "3 Self-modulation", "", 0, 32768),
                        new ControllerDescription(102, "SelfModulation4", "4 Self-modulation", "", 0, 32768),
                        new ControllerDescription(103, "SelfModulation5", "5 Self-modulation", "", 0, 32768),
                        new ControllerDescription(104, "Feedback1", "1 Feedback", "", 0, 32768),
                        new ControllerDescription(105, "Feedback2", "2 Feedback", "", 0, 32768),
                        new ControllerDescription(106, "Feedback3", "3 Feedback", "", 0, 32768),
                        new ControllerDescription(107, "Feedback4", "4 Feedback", "", 0, 32768),
                        new ControllerDescription(108, "Feedback5", "5 Feedback", "", 0, 32768),
                        new ControllerDescription(109, "ModulationType1", "1 Modulation type", "", 0, 9, "FMXModulationType"),
                        new ControllerDescription(110, "ModulationType2", "2 Modulation type", "", 0, 9, "FMXModulationType"),
                        new ControllerDescription(111, "ModulationType3", "3 Modulation type", "", 0, 9, "FMXModulationType"),
                        new ControllerDescription(112, "ModulationType4", "4 Modulation type", "", 0, 9, "FMXModulationType"),
                        new ControllerDescription(113, "ModulationType5", "5 Modulation type", "", 0, 9, "FMXModulationType"),
                        new ControllerDescription(114, "OutputMode1", "1 Output mode", "", 0, 31),
                        new ControllerDescription(115, "OutputMode2", "2 Output mode", "", 0, 15),
                        new ControllerDescription(116, "OutputMode3", "3 Output mode", "", 0, 7),
                        new ControllerDescription(117, "OutputMode4", "4 Output mode", "", 0, 3),
                        new ControllerDescription(118, "EnvelopeGain", "Envelope gain", "", 0, 8000),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Generator",
                    "Generator",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 256),
                        new ControllerDescription(1, "Waveform", "Waveform", "", 0, 8, "GeneratorWaveform"),
                        new ControllerDescription(2, "Panning", "Panning", "", 0, 256),
                        new ControllerDescription(3, "Attack", "Attack", "", 0, 512),
                        new ControllerDescription(4, "Release", "Release", "", 0, 512),
                        new ControllerDescription(5, "Polyphony", "Polyphony", "", 1, 16),
                        new ControllerDescription(6, "Mode", "Mode", "", 0, 1, "Channels"),
                        new ControllerDescription(7, "Sustain", "Sustain", "", 0, 1, "Toggle"),
                        new ControllerDescription(8, "FreqModulationByInput", "Freq.modulation by input", "", 0, 256),
                        new ControllerDescription(9, "DutyCycle", "Duty cycle", "", 0, 1022),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Glide",
                    "Glide",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Response", "Response", "", 0, 1000),
                        new ControllerDescription(1, "SampleRate", "Sample rate", "", 1, 32768),
                        new ControllerDescription(2, "ResetOnFirstNote", "Reset on 1st note", "", 0, 1, "Toggle"),
                        new ControllerDescription(3, "Polyphony", "Polyphony", "", 0, 1, "Toggle"),
                        new ControllerDescription(4, "Pitch", "Pitch", "", 0, 1200),
                        new ControllerDescription(5, "PitchScale", "Pitch scale", "", 0, 200),
                        new ControllerDescription(6, "Reset", "Reset", "", 0, 1, "Toggle"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "GPIO",
                    "GPIO",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Out", "Out", "", 0, 1, "Toggle"),
                        new ControllerDescription(1, "OutPin", "Out pin", "", 0, 256),
                        new ControllerDescription(2, "OutThreshold", "Out threshold", "", 0, 100),
                        new ControllerDescription(3, "In", "In", "", 0, 1, "Toggle"),
                        new ControllerDescription(4, "InPin", "In pin", "", 0, 256),
                        new ControllerDescription(5, "InNote", "In note", "", 0, 128),
                        new ControllerDescription(6, "InAmplitude", "In amplitude", "", 0, 100),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Input",
                    "Input",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 1024),
                        new ControllerDescription(1, "Channels", "Channels", "", 0, 1, "ChannelsInverted"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Kicker",
                    "Kicker",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 256),
                        new ControllerDescription(1, "Waveform", "Waveform", "", 0, 2, "KickerWaveform"),
                        new ControllerDescription(2, "Panning", "Panning", "", 0, 256),
                        new ControllerDescription(3, "Attack", "Attack", "", 0, 512),
                        new ControllerDescription(4, "Release", "Release", "", 0, 512),
                        new ControllerDescription(5, "Boost", "Boost", "", 0, 1024),
                        new ControllerDescription(6, "Acceleration", "Acceleration", "", 0, 1024),
                        new ControllerDescription(7, "Polyphony", "Polyphony", "", 1, 4),
                        new ControllerDescription(8, "NoClick", "No click", "", 0, 1, "Toggle"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "LFO",
                    "LFO",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 512),
                        new ControllerDescription(1, "Type", "Type", "", 0, 1, "LFOType"),
                        new ControllerDescription(2, "Amplitude", "Amplitude", "", 0, 256),
                        new ControllerDescription(3, "Freq", "Freq", "", 1, 256),
                        new ControllerDescription(4, "Waveform", "Waveform", "", 0, 7, "LFOWaveform"),
                        new ControllerDescription(5, "SetPhase", "Set phase", "", 0, 256),
                        new ControllerDescription(6, "Channels", "Channels", "", 0, 1, "Channels"),
                        new ControllerDescription(7, "FrequencyUnit", "Frequency unit", "", 0, 32768),
                        new ControllerDescription(8, "DutyCycle", "Duty cycle", "", 0, 256),
                        new ControllerDescription(9, "Generator", "Generator", "", 0, 1, "Toggle"),
                        new ControllerDescription(10, "FreqScale", "Freq scale", "", 0, 200),
                        new ControllerDescription(11, "SmoothTransitions", "Smooth transitions", "", 0, 1, "LFOSmoothTransitions"),
                        new ControllerDescription(12, "SineQuality", "Sine quality", "", 0, 3, "LFOSineQuality"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Loop",
                    "Loop",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 256),
                        new ControllerDescription(1, "Delay", "Delay", "", 0, 256),
                        new ControllerDescription(2, "Channels", "Channels", "", 0, 1, "ChannelsInverted"),
                        new ControllerDescription(3, "Repeats", "Repeats", "", 0, 64),
                        new ControllerDescription(4, "Mode", "Mode", "", 0, 1, "LoopMode"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "MetaModule",
                    "MetaModule",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 1024),
                        new ControllerDescription(1, "InputModule", "Input module", "", 1, 256),
                        new ControllerDescription(2, "PlayPatterns", "Play patterns", "", 0, 4, "MetaModulePatternMode"),
                        new ControllerDescription(3, "BPM", "BPM (Beats Per Minute)", "", 125, 32768),
                        new ControllerDescription(4, "TPL", "TPL (Ticks Per Line)", "", 6, 7),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Modulator",
                    "Modulator",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 512),
                        new ControllerDescription(1, "ModulationType", "Modulation type", "", 0, 2, "ModulationType"),
                        new ControllerDescription(2, "Channels", "Channels", "", 0, 1, "Channels"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "MultiControl",
                    "MultiCtl",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Value", "Value", "", 0, 32768),
                        new ControllerDescription(1, "Gain", "Gain", "", 0, 1024),
                        new ControllerDescription(2, "Quantization", "Quantization", "", 0, 32768),
                        new ControllerDescription(3, "OUTOffset", "OUT offset", "", 0, 32768),
                        new ControllerDescription(4, "Response", "Response", "", 0, 1000),
                        new ControllerDescription(5, "SampleRate", "Sample rate", "", 1, 32768),
                    },
                    new List<CurveDescription>()
                    {
                        new CurveDescription(0, "Curve", "Modifies applied values.", 0, 1, 257),
                    }
                ),
                new ModuleDescription(
                    "MultiSynth",
                    "MultiSynth",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Transpose", "Transpose", "", 0, 256),
                        new ControllerDescription(1, "RandomPitch", "Random pitch", "", 0, 4096),
                        new ControllerDescription(2, "Velocity", "Velocity", "", 0, 256),
                        new ControllerDescription(3, "Finetune", "Finetune", "", 0, 512),
                        new ControllerDescription(4, "RandomPhase", "Random phase", "", 0, 32768),
                        new ControllerDescription(5, "RandomVelocity", "Random velocity", "", 0, 32768),
                        new ControllerDescription(6, "Phase", "Phase", "", 0, 32768),
                        new ControllerDescription(7, "Curve2Influence", "Curve2 influence", "", 0, 256),
                    },
                    new List<CurveDescription>()
                    {
                        new CurveDescription(0, "NoteVelocityCurve", "Velocity to apply to arriving note.", 0, 1, 128),
                        new CurveDescription(1, "VelocityToVelocityCurve", "Map velocity values.", 0, 1, 257),
                    }
                ),
                new ModuleDescription(
                    "Output",
                    "Output",
                    "",
                    new List<ControllerDescription>()
                    {
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "PitchDetector",
                    "Pitch Detector",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Algorithm", "Algorithm", "", 0, 2, "PitchDetectorAlgorithm"),
                        new ControllerDescription(1, "Threshold", "Threshold", "", 0, 10000),
                        new ControllerDescription(2, "Gain", "Gain", "", 0, 256),
                        new ControllerDescription(3, "Microtones", "Microtones", "", 0, 1, "Toggle"),
                        new ControllerDescription(4, "DetectorFinetune", "Detector finetune", "", 0, 512),
                        new ControllerDescription(5, "LPFilterFreq", "LP filter freq (0 - OFF)", "", 0, 4000),
                        new ControllerDescription(6, "LPFilterRollOff", "LP filter roll-off", "", 0, 3, "FilterRollOff"),
                        new ControllerDescription(7, "AlgSampleRateHz", "Alg1-2 Sample rate (Hz)", "", 0, 2, "PitchDetectorAlgSampleRate"),
                        new ControllerDescription(8, "AlgBufferMs", "Alg1-2 Buffer (ms)", "", 0, 4),
                        new ControllerDescription(9, "AlgBufOverlap", "Alg1-2 Buf overlap", "", 0, 100),
                        new ControllerDescription(10, "Alg1Sensitivity", "Alg1 Sensitivity (absolute threshold)", "", 0, 100),
                        new ControllerDescription(11, "RecordNotes", "Record notes", "", 0, 1, "Toggle"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "PitchShifter",
                    "Pitch shifter",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 512),
                        new ControllerDescription(1, "Pitch", "Pitch", "", 0, 1200),
                        new ControllerDescription(2, "PitchScale", "Pitch scale", "", 0, 200),
                        new ControllerDescription(3, "Feedback", "Feedback", "", 0, 256),
                        new ControllerDescription(4, "GrainSize", "Grain size", "", 0, 256),
                        new ControllerDescription(5, "Mode", "Mode", "", 0, 3, "Quality"),
                        new ControllerDescription(6, "BypassIfPitchZero", "Bypass if pitch=0", "", 0, 2, "PitchShifterBypassMode"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "PitchToControl",
                    "Pitch2Ctl",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Mode", "Mode", "", 0, 1, "PitchToControlMode"),
                        new ControllerDescription(1, "OnNoteOff", "On NoteOFF", "", 0, 2, "PitchToControlOnNoteOff"),
                        new ControllerDescription(2, "FirstNote", "First note", "", 0, 256),
                        new ControllerDescription(3, "RangeNumberOfSemitones", "Range (number of semitones)", "", 0, 256),
                        new ControllerDescription(4, "OUTMin", "OUT min", "", 0, 32768),
                        new ControllerDescription(5, "OUTMax", "OUT max", "", 0, 32768),
                        new ControllerDescription(6, "OUTController", "OUT controller", "", 0, 255),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Reverb",
                    "Reverb",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Dry", "Dry", "", 0, 256),
                        new ControllerDescription(1, "Wet", "Wet", "", 0, 256),
                        new ControllerDescription(2, "Feedback", "Feedback", "", 0, 256),
                        new ControllerDescription(3, "Damp", "Damp", "", 0, 256),
                        new ControllerDescription(4, "StereoWidth", "Stereo width", "", 0, 256),
                        new ControllerDescription(5, "Freeze", "Freeze", "", 0, 1, "Toggle"),
                        new ControllerDescription(6, "Mode", "Mode", "", 0, 3, "Quality"),
                        new ControllerDescription(7, "AllPassFilter", "All-pass filter", "", 0, 1, "Toggle"),
                        new ControllerDescription(8, "RoomSize", "Room size", "", 0, 128),
                        new ControllerDescription(9, "RandomSeed", "Random seed", "", 0, 32768),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Sampler",
                    "Sampler",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 512),
                        new ControllerDescription(1, "Panning", "Panning", "", 0, 256),
                        new ControllerDescription(2, "SampleInterpolation", "Sample interpolation", "", 0, 2, "SamplerInterpolation"),
                        new ControllerDescription(3, "EnvelopeInterpolation", "Envelope interpolation", "", 0, 1, "SamplerEnvelopeInterpolation"),
                        new ControllerDescription(4, "Polyphony", "Polyphony", "", 1, 32),
                        new ControllerDescription(5, "RecThreshold", "Rec threshold", "", 0, 10000),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "SoundToControl",
                    "Sound2Ctl",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "SampleRate", "Sample rate", "", 1, 32768),
                        new ControllerDescription(1, "Channels", "Channels", "", 0, 1, "ChannelsInverted"),
                        new ControllerDescription(2, "Absolute", "Absolute", "", 0, 1, "Toggle"),
                        new ControllerDescription(3, "Gain", "Gain", "", 0, 1024),
                        new ControllerDescription(4, "Smooth", "Smooth", "", 0, 256),
                        new ControllerDescription(5, "Mode", "Mode", "", 0, 1, "SoundToControlMode"),
                        new ControllerDescription(6, "OUTMin", "OUT min", "", 0, 32768),
                        new ControllerDescription(7, "OUTMax", "OUT max", "", 0, 32768),
                        new ControllerDescription(8, "OUTController", "OUT controller", "", 0, 255),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "SpectraVoice",
                    "SpectraVoice",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 256),
                        new ControllerDescription(1, "Panning", "Panning", "", 0, 256),
                        new ControllerDescription(2, "Attack", "Attack", "", 0, 512),
                        new ControllerDescription(3, "Release", "Release", "", 0, 512),
                        new ControllerDescription(4, "Polyphony", "Polyphony", "", 1, 32),
                        new ControllerDescription(5, "Mode", "Mode", "", 0, 4, "SpectraVoiceMode"),
                        new ControllerDescription(6, "Sustain", "Sustain", "", 0, 1, "Toggle"),
                        new ControllerDescription(7, "SpectrumResolution", "Spectrum resolution", "", 0, 5),
                        new ControllerDescription(8, "Harmonic", "Harmonic", "", 0, 32768),
                        new ControllerDescription(9, "HarmonicFreq", "H.freq", "", 0, 22050),
                        new ControllerDescription(10, "HarmonicVolume", "H.volume", "", 0, 255),
                        new ControllerDescription(11, "HarmonicWidth", "H.width", "", 0, 255),
                        new ControllerDescription(12, "HarmonicType", "H.type", "", 0, 18, "SpectraVoiceHarmonicType"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "VelocityToControl",
                    "Velocity2Ctl",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "OnNoteOff", "On NoteOFF", "", 0, 2, "VelocityToControlOnNoteOff"),
                        new ControllerDescription(1, "OutMin", "OUT min", "", 0, 32768),
                        new ControllerDescription(2, "OutMax", "OUT max", "", 0, 32768),
                        new ControllerDescription(3, "OutOffset", "OUT offset", "", 0, 32768),
                        new ControllerDescription(4, "OutController", "OUT controller", "", 0, 255),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "Vibrato",
                    "Vibrato",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 256),
                        new ControllerDescription(1, "Amplitude", "Amplitude", "", 0, 256),
                        new ControllerDescription(2, "Freq", "Freq", "", 1, 2048),
                        new ControllerDescription(3, "Channels", "Channels", "", 0, 1, "Channels"),
                        new ControllerDescription(4, "SetPhase", "Set phase", "", 0, 256),
                        new ControllerDescription(5, "FrequencyUnit", "Frequency unit", "", 0, 32768, "VibratoFrequencyUnit"),
                        new ControllerDescription(6, "ExponentialAmplitude", "Exponential amplitude", "", 0, 1, "Toggle"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "VocalFilter",
                    "Vocal filter",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 512),
                        new ControllerDescription(1, "FormantWidth", "Formant width", "", 0, 256),
                        new ControllerDescription(2, "Intensity", "Intensity", "", 0, 256),
                        new ControllerDescription(3, "Formants", "Formants", "", 1, 5),
                        new ControllerDescription(4, "Vowel", "Vowel (a,e,i,o,u)", "", 0, 256),
                        new ControllerDescription(5, "VoiceType", "Voice type", "", 0, 3, "VocalFilterVoiceType"),
                        new ControllerDescription(6, "Channels", "Channels", "", 0, 1, "Channels"),
                        new ControllerDescription(7, "RandomFrequency", "Random frequency", "", 0, 1024),
                        new ControllerDescription(8, "RandomSeed", "Random seed", "", 0, 32768),
                        new ControllerDescription(9, "Vowel1", "Vowel1", "", 0, 4, "VocalFilterVowel"),
                        new ControllerDescription(10, "Vowel2", "Vowel2", "", 0, 4, "VocalFilterVowel"),
                        new ControllerDescription(11, "Vowel3", "Vowel3", "", 0, 4, "VocalFilterVowel"),
                        new ControllerDescription(12, "Vowel4", "Vowel4", "", 0, 4, "VocalFilterVowel"),
                        new ControllerDescription(13, "Vowel5", "Vowel5", "", 0, 4, "VocalFilterVowel"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "VorbisPlayer",
                    "Vorbis player",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "Volume", "Volume", "", 0, 512),
                        new ControllerDescription(1, "OriginalSpeed", "Original speed", "", 0, 1, "Toggle"),
                        new ControllerDescription(2, "Finetune", "Finetune", "", -128, 128),
                        new ControllerDescription(3, "Transpose", "Transpose", "", 0, 256),
                        new ControllerDescription(4, "Interpolation", "Interpolation", "", 0, 1, "Toggle"),
                        new ControllerDescription(5, "Polyphony", "Polyphony", "", 1, 4),
                        new ControllerDescription(6, "Repeat", "Repeat", "", 0, 1, "Toggle"),
                    },
                    new List<CurveDescription>()
                    {
                    }
                ),
                new ModuleDescription(
                    "WaveShaper",
                    "WaveShaper",
                    "",
                    new List<ControllerDescription>()
                    {
                        new ControllerDescription(0, "InputVolume", "Input volume", "", 0, 512),
                        new ControllerDescription(1, "Mix", "Mix", "", 0, 256),
                        new ControllerDescription(2, "OutputVolume", "Output volume", "", 0, 512),
                        new ControllerDescription(3, "Symmetric", "Symmetric", "", 0, 1, "Toggle"),
                        new ControllerDescription(4, "Mode", "Mode", "", 0, 3, "Quality"),
                        new ControllerDescription(5, "DCBlocker", "DC blocker", "", 0, 1, "Toggle"),
                    },
                    new List<CurveDescription>()
                    {
                        new CurveDescription(0, "Curve", "Maps input to output.", 0, 1, 256),
                    }
                ),
            };

            return data;
        }
    }
}
