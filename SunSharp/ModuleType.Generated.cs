/*
 * IMPORTANT!
 * Do not modify this file manually. It was generated automatically by the CodeGeneration project.
*/

namespace SunSharp
{
    public enum ModuleType
    {
        ADSR = 128,
        Amplifier = 64,
        AnalogGenerator = 1,
        Compressor = 65,
        ControlToNote = 129,
        DcBlocker = 66,
        Delay = 67,
        Distortion = 68,
        DrumSynth = 2,
        Echo = 69,
        EQ = 70,
        Feedback = 130,
        FFT = 71,
        Filter = 72,
        FilterPro = 73,
        Flanger = 74,
        FM = 3,
        FMX = 4,
        Generator = 5,
        Glide = 131,
        GPIO = 132,
        Input = 6,
        Kicker = 7,
        LFO = 75,
        Loop = 76,
        MetaModule = 133,
        Modulator = 77,
        MultiControl = 134,
        MultiSynth = 135,
        Output = -1,
        PitchDetector = 137,
        PitchShifter = 78,
        PitchToControl = 136,
        Reverb = 79,
        Sampler = 9,
        SoundToControl = 138,
        SpectraVoice = 10,
        VelocityToControl = 139,
        Vibrato = 81,
        VocalFilter = 80,
        VorbisPlayer = 8,
        WaveShaper = 82,
        Unknown = 0,
    }

    public static class ModuleTypeHelper
    {
        public static string InternalNameFromType(ModuleType type)
        {
            switch (type)
            {
                case ModuleType.ADSR: return "ADSR";
                case ModuleType.Amplifier: return "Amplifier";
                case ModuleType.AnalogGenerator: return "Analog generator";
                case ModuleType.Compressor: return "Compressor";
                case ModuleType.ControlToNote: return "Ctl2Note";
                case ModuleType.DcBlocker: return "DC Blocker";
                case ModuleType.Delay: return "Delay";
                case ModuleType.Distortion: return "Distortion";
                case ModuleType.DrumSynth: return "DrumSynth";
                case ModuleType.Echo: return "Echo";
                case ModuleType.EQ: return "EQ";
                case ModuleType.Feedback: return "Feedback";
                case ModuleType.FFT: return "FFT";
                case ModuleType.Filter: return "Filter";
                case ModuleType.FilterPro: return "Filter Pro";
                case ModuleType.Flanger: return "Flanger";
                case ModuleType.FM: return "FM";
                case ModuleType.FMX: return "FMX";
                case ModuleType.Generator: return "Generator";
                case ModuleType.Glide: return "Glide";
                case ModuleType.GPIO: return "GPIO";
                case ModuleType.Input: return "Input";
                case ModuleType.Kicker: return "Kicker";
                case ModuleType.LFO: return "LFO";
                case ModuleType.Loop: return "Loop";
                case ModuleType.MetaModule: return "MetaModule";
                case ModuleType.Modulator: return "Modulator";
                case ModuleType.MultiControl: return "MultiCtl";
                case ModuleType.MultiSynth: return "MultiSynth";
                case ModuleType.Output: return "Output";
                case ModuleType.PitchDetector: return "Pitch Detector";
                case ModuleType.PitchShifter: return "Pitch shifter";
                case ModuleType.PitchToControl: return "Pitch2Ctl";
                case ModuleType.Reverb: return "Reverb";
                case ModuleType.Sampler: return "Sampler";
                case ModuleType.SoundToControl: return "Sound2Ctl";
                case ModuleType.SpectraVoice: return "SpectraVoice";
                case ModuleType.VelocityToControl: return "Velocity2Ctl";
                case ModuleType.Vibrato: return "Vibrato";
                case ModuleType.VocalFilter: return "Vocal filter";
                case ModuleType.VorbisPlayer: return "Vorbis player";
                case ModuleType.WaveShaper: return "WaveShaper";
                default: return "unknown";
            }
        }

        public static ModuleType TypeFromInternalName(string internalName)
        {
            switch (internalName)
            {
                case "ADSR": return ModuleType.ADSR;
                case "Amplifier": return ModuleType.Amplifier;
                case "Analog generator": return ModuleType.AnalogGenerator;
                case "Compressor": return ModuleType.Compressor;
                case "Ctl2Note": return ModuleType.ControlToNote;
                case "DC Blocker": return ModuleType.DcBlocker;
                case "Delay": return ModuleType.Delay;
                case "Distortion": return ModuleType.Distortion;
                case "DrumSynth": return ModuleType.DrumSynth;
                case "Echo": return ModuleType.Echo;
                case "EQ": return ModuleType.EQ;
                case "Feedback": return ModuleType.Feedback;
                case "FFT": return ModuleType.FFT;
                case "Filter": return ModuleType.Filter;
                case "Filter Pro": return ModuleType.FilterPro;
                case "Flanger": return ModuleType.Flanger;
                case "FM": return ModuleType.FM;
                case "FMX": return ModuleType.FMX;
                case "Generator": return ModuleType.Generator;
                case "Glide": return ModuleType.Glide;
                case "GPIO": return ModuleType.GPIO;
                case "Input": return ModuleType.Input;
                case "Kicker": return ModuleType.Kicker;
                case "LFO": return ModuleType.LFO;
                case "Loop": return ModuleType.Loop;
                case "MetaModule": return ModuleType.MetaModule;
                case "Modulator": return ModuleType.Modulator;
                case "MultiCtl": return ModuleType.MultiControl;
                case "MultiSynth": return ModuleType.MultiSynth;
                case "Output": return ModuleType.Output;
                case "Pitch Detector": return ModuleType.PitchDetector;
                case "Pitch shifter": return ModuleType.PitchShifter;
                case "Pitch2Ctl": return ModuleType.PitchToControl;
                case "Reverb": return ModuleType.Reverb;
                case "Sampler": return ModuleType.Sampler;
                case "Sound2Ctl": return ModuleType.SoundToControl;
                case "SpectraVoice": return ModuleType.SpectraVoice;
                case "Velocity2Ctl": return ModuleType.VelocityToControl;
                case "Vibrato": return ModuleType.Vibrato;
                case "Vocal filter": return ModuleType.VocalFilter;
                case "Vorbis player": return ModuleType.VorbisPlayer;
                case "WaveShaper": return ModuleType.WaveShaper;
                default: return ModuleType.Unknown;
            }
        }
    }
}
