namespace SunSharp.ObjectWrapper
{
    public static class ModuleTypeExtensions
    {
        public static string ToInternalName(this ModuleType moduleType)
        {
            switch (moduleType)
            {
                case (ModuleType.AnalogGenerator): return "Analog_generator";
                case (ModuleType.DrumSynth): return "DrumSynth";
                case (ModuleType.FM): return "FM";
                case (ModuleType.FMX): return "FMX";
                case (ModuleType.Generator): return "Generator";
                case (ModuleType.Input): return "Input";
                case (ModuleType.Kicker): return "Kicker";
                case (ModuleType.VorbisPlayer): return "Vorbis_player";
                case (ModuleType.Sampler): return "Sampler";
                case (ModuleType.SpectraVoice): return "SpectraVoice";
                case (ModuleType.Amplifier): return "Amplifier";
                case (ModuleType.Compressor): return "Compressor";
                case (ModuleType.DcBlocker): return "DC_Blocker";
                case (ModuleType.Delay): return "Delay";
                case (ModuleType.Distortion): return "Distortion";
                case (ModuleType.Echo): return "Echo";
                case (ModuleType.EQ): return "EQ";
                case (ModuleType.FFT): return "FFT";
                case (ModuleType.Filter): return "Filter";
                case (ModuleType.FilterPro): return "Filter_Pro";
                case (ModuleType.Flanger): return "Flanger";
                case (ModuleType.LFO): return "LFO";
                case (ModuleType.Loop): return "Loop";
                case (ModuleType.Modulator): return "Modulator";
                case (ModuleType.PitchShifter): return "Pitch_shifter";
                case (ModuleType.Reverb): return "Reverb";
                case (ModuleType.VocalFilter): return "Vocal_filter";
                case (ModuleType.Vibrato): return "Vibrato";
                case (ModuleType.WaveShaper): return "WaveShaper";
                case (ModuleType.ADSR): return "ADSR";
                case (ModuleType.ControlToNote): return "Ctl2Note";
                case (ModuleType.Feedback): return "Feedback";
                case (ModuleType.Glide): return "Glide";
                case (ModuleType.GPIO): return "GPIO";
                case (ModuleType.MetaModule): return "MetaModule";
                case (ModuleType.MultiControl): return "MultiCtl";
                case (ModuleType.MultiSynth): return "MultiSynth";
                case (ModuleType.PitchToControl): return "Pitch2Ctl";
                case (ModuleType.PitchDetector): return "Pitch_Detector";
                case (ModuleType.SoundToControl): return "Sound2Ctl";
                case (ModuleType.VelocityToControl): return "Velocity2Ctl";
                default: return "Unknown";
            }
        }
    }
}
