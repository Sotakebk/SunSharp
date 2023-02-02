namespace CodeGeneration
{
    public partial class ModuleTypes
    {
        public static ICollection<(int value, string friendlyName, string internalName)> GetModuleTypes() =>
            new (int, string, string)[]
            {
                (1,"AnalogGenerator",  "Analog generator"),
                (2,"DrumSynth",  "DrumSynth"),
                (3, "FM",  "FM"),
                (4, "FMX",  "FMX"),
                (5, "Generator",  "Generator"),
                (6, "Input",  "Input"),
                (7, "Kicker",  "Kicker"),
                (8, "VorbisPlayer",  "Vorbis player"),
                (9, "Sampler",  "Sampler"),
                (10, "SpectraVoice",  "SpectraVoice"),

                (64, "Amplifier",  "Amplifier"),
                (65, "Compressor",  "Compressor"),
                (66, "DcBlocker",  "DC Blocker"),
                (67, "Delay",  "Delay"),
                (68, "Distortion",  "Distortion"),
                (69, "Echo",  "Echo"),
                (70, "EQ",  "EQ"),
                (71, "FFT",  "FFT"),
                (72, "Filter",  "Filter"),
                (73, "FilterPro",  "Filter Pro"),
                (74, "Flanger",  "Flanger"),
                (75, "LFO",  "LFO"),
                (76, "Loop",  "Loop"),
                (77, "Modulator",  "Modulator"),
                (78, "PitchShifter",  "Pitch shifter"),
                (79, "Reverb",  "Reverb"),
                (80, "VocalFilter",  "Vocal filter"),
                (81, "Vibrato",  "Vibrato"),
                (82, "WaveShaper",  "WaveShaper"),
                (128, "ADSR",  "ADSR"),
                (129, "ControlToNote",  "Ctl2Note"),
                (130, "Feedback",  "Feedback"),
                (131, "Glide",  "Glide"),
                (132, "GPIO",  "GPIO"),
                (133, "MetaModule",  "MetaModule"),
                (134, "MultiControl",  "MultiCtl"),
                (135, "MultiSynth",  "MultiSynth"),
                (136, "PitchToControl",  "Pitch2Ctl"),
                (137, "PitchDetector",  "Pitch Detector"),
                (138, "SoundToControl",  "Sound2Ctl"),
                (139, "VelocityToControl",  "Velocity2Ctl"),

                (-1, "Output",  "Output"),
            };

        private static ICollection<(int value, string friendlyName, string internalName)> _privateCollection = GetModuleTypes();

        public static string GetFriendlyName(string internalName)
        {
            return _privateCollection.FirstOrDefault(t => t.internalName == internalName).friendlyName;
        }
    }
}
