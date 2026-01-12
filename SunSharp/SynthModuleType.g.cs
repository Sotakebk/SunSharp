/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp
{
    public enum SynthModuleType
    {
        Adsr = 30,
        Amplifier = 11,
        AnalogGenerator = 1,
        Compressor = 12,
        ControlToNote = 31,
        DcBlocker = 13,
        Delay = 14,
        Distortion = 15,
        DrumSynth = 2,
        Echo = 16,
        Eq = 17,
        Feedback = 32,
        Fft = 18,
        Filter = 19,
        FilterPro = 20,
        Flanger = 21,
        Fm = 3,
        Fmx = 4,
        Generator = 5,
        Glide = 33,
        Gpio = 34,
        Input = 6,
        Kicker = 7,
        Lfo = 22,
        Loop = 23,
        MetaModule = 35,
        Modulator = 24,
        MultiControl = 36,
        MultiSynth = 37,
        Output = -1,
        PitchDetector = 39,
        PitchShifter = 25,
        PitchToControl = 38,
        Reverb = 26,
        Sampler = 9,
        SoundToControl = 40,
        SpectraVoice = 10,
        VelocityToControl = 41,
        Vibrato = 28,
        VocalFilter = 27,
        VorbisPlayer = 8,
        WaveShaper = 29,
        Unknown = 0,
    }

    public static class SynthModuleTypeHelper
    {
        /// <summary>
        /// Gets the internal name for a given SynthModuleType.
        /// </summary>
        /// <remarks>
        /// In case of unknown SynthModuleType, returns "unknown".
        /// </remarks>
        public static string InternalNameFromType(SynthModuleType type)
        {
            switch (type)
            {
                case SynthModuleType.Adsr: return "ADSR";
                case SynthModuleType.Amplifier: return "Amplifier";
                case SynthModuleType.AnalogGenerator: return "Analog generator";
                case SynthModuleType.Compressor: return "Compressor";
                case SynthModuleType.ControlToNote: return "Ctl2Note";
                case SynthModuleType.DcBlocker: return "DC Blocker";
                case SynthModuleType.Delay: return "Delay";
                case SynthModuleType.Distortion: return "Distortion";
                case SynthModuleType.DrumSynth: return "DrumSynth";
                case SynthModuleType.Echo: return "Echo";
                case SynthModuleType.Eq: return "EQ";
                case SynthModuleType.Feedback: return "Feedback";
                case SynthModuleType.Fft: return "FFT";
                case SynthModuleType.Filter: return "Filter";
                case SynthModuleType.FilterPro: return "Filter Pro";
                case SynthModuleType.Flanger: return "Flanger";
                case SynthModuleType.Fm: return "FM";
                case SynthModuleType.Fmx: return "FMX";
                case SynthModuleType.Generator: return "Generator";
                case SynthModuleType.Glide: return "Glide";
                case SynthModuleType.Gpio: return "GPIO";
                case SynthModuleType.Input: return "Input";
                case SynthModuleType.Kicker: return "Kicker";
                case SynthModuleType.Lfo: return "LFO";
                case SynthModuleType.Loop: return "Loop";
                case SynthModuleType.MetaModule: return "MetaModule";
                case SynthModuleType.Modulator: return "Modulator";
                case SynthModuleType.MultiControl: return "MultiCtl";
                case SynthModuleType.MultiSynth: return "MultiSynth";
                case SynthModuleType.Output: return "Output";
                case SynthModuleType.PitchDetector: return "Pitch Detector";
                case SynthModuleType.PitchShifter: return "Pitch shifter";
                case SynthModuleType.PitchToControl: return "Pitch2Ctl";
                case SynthModuleType.Reverb: return "Reverb";
                case SynthModuleType.Sampler: return "Sampler";
                case SynthModuleType.SoundToControl: return "Sound2Ctl";
                case SynthModuleType.SpectraVoice: return "SpectraVoice";
                case SynthModuleType.VelocityToControl: return "Velocity2Ctl";
                case SynthModuleType.Vibrato: return "Vibrato";
                case SynthModuleType.VocalFilter: return "Vocal filter";
                case SynthModuleType.VorbisPlayer: return "Vorbis player";
                case SynthModuleType.WaveShaper: return "WaveShaper";
                default: return "unknown";
            }
        }

        /// <summary>
        /// Gets the SynthModuleType for a given internal name.
        /// </summary>
        /// <remarks>
        /// In case of unknown internal name, returns SynthModuleType.Unknown.
        /// </remarks>
        public static SynthModuleType TypeFromInternalName(string internalName)
        {
            switch (internalName)
            {
                case "ADSR": return SynthModuleType.Adsr;
                case "Amplifier": return SynthModuleType.Amplifier;
                case "Analog generator": return SynthModuleType.AnalogGenerator;
                case "Compressor": return SynthModuleType.Compressor;
                case "Ctl2Note": return SynthModuleType.ControlToNote;
                case "DC Blocker": return SynthModuleType.DcBlocker;
                case "Delay": return SynthModuleType.Delay;
                case "Distortion": return SynthModuleType.Distortion;
                case "DrumSynth": return SynthModuleType.DrumSynth;
                case "Echo": return SynthModuleType.Echo;
                case "EQ": return SynthModuleType.Eq;
                case "Feedback": return SynthModuleType.Feedback;
                case "FFT": return SynthModuleType.Fft;
                case "Filter": return SynthModuleType.Filter;
                case "Filter Pro": return SynthModuleType.FilterPro;
                case "Flanger": return SynthModuleType.Flanger;
                case "FM": return SynthModuleType.Fm;
                case "FMX": return SynthModuleType.Fmx;
                case "Generator": return SynthModuleType.Generator;
                case "Glide": return SynthModuleType.Glide;
                case "GPIO": return SynthModuleType.Gpio;
                case "Input": return SynthModuleType.Input;
                case "Kicker": return SynthModuleType.Kicker;
                case "LFO": return SynthModuleType.Lfo;
                case "Loop": return SynthModuleType.Loop;
                case "MetaModule": return SynthModuleType.MetaModule;
                case "Modulator": return SynthModuleType.Modulator;
                case "MultiCtl": return SynthModuleType.MultiControl;
                case "MultiSynth": return SynthModuleType.MultiSynth;
                case "Output": return SynthModuleType.Output;
                case "Pitch Detector": return SynthModuleType.PitchDetector;
                case "Pitch shifter": return SynthModuleType.PitchShifter;
                case "Pitch2Ctl": return SynthModuleType.PitchToControl;
                case "Reverb": return SynthModuleType.Reverb;
                case "Sampler": return SynthModuleType.Sampler;
                case "Sound2Ctl": return SynthModuleType.SoundToControl;
                case "SpectraVoice": return SynthModuleType.SpectraVoice;
                case "Velocity2Ctl": return SynthModuleType.VelocityToControl;
                case "Vibrato": return SynthModuleType.Vibrato;
                case "Vocal filter": return SynthModuleType.VocalFilter;
                case "Vorbis player": return SynthModuleType.VorbisPlayer;
                case "WaveShaper": return SynthModuleType.WaveShaper;
                default: return SynthModuleType.Unknown;
            }
        }

        /// <summary>
        /// Checks if value of <see cref="SynthModuleType"/> is valid.
        /// </summary>
        public static bool IsValid(SynthModuleType type)
        {
            return (int)type >= -1 && (int)type <= 41;
        }

        public static string ToInternalName(this SynthModuleType type)
        {
            return InternalNameFromType(type);
        }
    }
}
#endif
