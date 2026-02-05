using CodeGeneration.Generators;
using CodeGeneration.Generators.ModuleHandles;

namespace CodeGeneration.Logic;

public record KnownModuleType(int Index, string FriendlyName, string InternalName, string? Description = null, Func<KnownModuleData, BaseGenerator>? GetCustomGenerator = null)
{
    public KnownModuleType(int Index, string FriendlyName) : this(Index, FriendlyName, FriendlyName) { }
}

public static class KnownModuleTypes
{
    public static readonly KnownModuleType[] ModuleTypes = [
        new KnownModuleType(-1, "Output")
        {
            Description = "Audio output module."
        },
        // 0 is for unknown
        new KnownModuleType(1, "AnalogGenerator", InternalName: "Analog generator")
        {
            Description = "Generator with 32 double alias-free oscillators, 12/24dB filters, envelopes, and smooth change of parameters. The sound quality of this module is better at a sample rate of 44100Hz."
        },
        new KnownModuleType(2, "DrumSynth")
        {
            Description = "Drum synthesizer with variety of predefined sounds. The sound quality of this module is better at a sample rate of 44100Hz."
        },
        new KnownModuleType(3, "Fm", InternalName: "FM")
        {
            Description = "Frequency Modulation (FM) Synthesizer. Each voice of polyphony includes two operators with ADSR envelopes: 1) C (carrier) - base sine wave generator; 2) M (modulator) - sine wave that changes the frequency of the first operator. The sound quality of this module is better at a sample rate of 44100Hz."
        },
        new KnownModuleType(4, "Fmx", InternalName: "FMX")
        {
            Description = "5-operator Frequency Modulation (FM) Synthesizer.",
            GetCustomGenerator = (data) => new FmxModuleGenerator("FMX", data)
        },
        new KnownModuleType(5, "Generator")
        {
            Description = "Basic generator of different types of periodic signal waveforms with the volume envelope. This module can receive the incoming signal and use it for the frequency modulation."
        },
        new KnownModuleType(6, "Input")
        {
            Description = "Audio input from Microphone/Line-in. Compatibility: implemented in the iOS and Android versions only."
        },
        new KnownModuleType(7, "Kicker")
        {
            Description = "Drum kick synthesizer with waveform type, attack, release, boost and envelope acceleration controls."
        },
        new KnownModuleType(8, "VorbisPlayer", "Vorbis player")
        {
            Description = "OGG Vorbis player."
        },
        new KnownModuleType(9, "Sampler")
        {
            Description = "Sampler can play and record audio files. Supported file formats: WAV (PCM, uncompressed), AIFF (PCM, uncompressed), XI, OGG (Vorbis), MP3, FLAC, JPEG, RAW."
        },
        new KnownModuleType(10, "SpectraVoice")
        {
            Description = "SpectraVoice synthesizes sound with a complex spectrum. You can place 16 harmonics on the spectrum graph, specifying the position, amplitude, shape and width for each."
        },
        new KnownModuleType(11, "Amplifier")
        {
            Description = "Signal amplifier with various settings."
        },
        new KnownModuleType(12, "Compressor")
        {
            Description = "Side chain compressor"
        },
        new KnownModuleType(13, "DcBlocker", "DC Blocker")
        {
            Description = "DC blocking filter."
        },
        new KnownModuleType(14, "Delay")
        {
            Description = "This module delays the sound and the incoming events (note, pitch, phase, velocity). Max delay length = 1 min."
        },
        new KnownModuleType(15, "Distortion")
        {
            Description = "This module adds various types of distortion to the sound."
        },
        new KnownModuleType(16, "Echo")
        {
            Description = "Stereo echo. Maximum delay length: 4 seconds."
        },
        new KnownModuleType(17, "Eq",  InternalName: "EQ")
        {
            Description = "3Band equalizer."
        },
        new KnownModuleType(18, "Fft",  InternalName: "FFT")
        {
            Description = "FFT-based frequency transformator."
        },
        new KnownModuleType(19, "Filter")
        {
            Description = "IIR Filter that can remove some unwanted frequency ranges."
        },
        new KnownModuleType(20, "FilterPro", InternalName: "Filter Pro")
        {
            Description = "High-quality 64-bit IIR Filter that can amplify, pass or attenuate some frequency ranges. This module is faster than Filter on modern CPUs and slower on older CPUs."
        },
        new KnownModuleType(21, "Flanger")
        {
            Description = "Flanger effect."
        },
        new KnownModuleType(22, "Lfo", InternalName: "LFO")
        {
            Description = "LFO - Low Frequency Oscillator. Can work as amplitude/balance modulator or as standalone generator."
        },
        new KnownModuleType(23, "Loop")
        {
            Description = "This module repeats a fragment of the incoming sound a specified number of times."
        },
        new KnownModuleType(24, "Modulator")
        {
            Description = "Amplitude or Phase modulator. First input = Carrier. Other inputs = Modulators (will be mixed into a single signal)."
        },
        new KnownModuleType(25, "PitchShifter", InternalName: "Pitch shifter")
        {
            Description = "Pitch shifter is a module for changing the pitch of any sound in real time. The signal at the output of the module is always slightly delayed."
        },
        new KnownModuleType(26, "Reverb")
        {
            Description = "Reverb is a module that simulates the reverberation effect (echo with numerous reflections to make the sound more natural)."
        },
        new KnownModuleType(27, "VocalFilter", InternalName: "Vocal filter")
        {
            Description = "Formant filter - designed to simulate the human vocal tract."
        },
        new KnownModuleType(28, "Vibrato")
        {
            Description = "Vibrato effect."
        },
        new KnownModuleType(29, "WaveShaper")
        {
            Description = "In simple terms, WaveShaper allows you to change the shape of the input signal. In math terms, WaveShaper is the expression y = f( x ); where y - output; x - input; f - function with graph which you can see in the WaveShaper interface."
        },
        new KnownModuleType(30, "Adsr", InternalName: "ADSR")
        {
            Description = "ADSR envelope generator. The module can be started either by notes at the input (reacts to note ON/OFF), or by setting the 'State' controller to the 'start' value."
        },
        new KnownModuleType(31, "ControlToNote", InternalName: "Ctl2Note")
        {
            Description = "Ctl2Note converts the value of the 'Pitch' controller to a note (Note ON/OFF commands at the output)."
        },
        new KnownModuleType(32, "Feedback")
        {
            Description = "Generally the feedback is not allowed in SunVox: you can't create an endless loop between the modules. But you can do it by placing two Feedback modules inside of the loop."
        },
        new KnownModuleType(33, "Glide")
        {
            Description = "Glide is similar to the MultiSynth (which sends the input events to the connected output modules), but it also adds the commands of smooth transition between the notes."
        },
        new KnownModuleType(34, "Gpio",  InternalName: "GPIO")
        {
            Description = "With this module you can use the General-Purpose Input/Output (GPIO) pins of the device board. For example, you can send some signals to the LEDs, or receive the ON/OFF (1/0) messages from the buttons."
        },
        new KnownModuleType(35, "MetaModule")
        {
            Description = "MetaModule is a full-featured copy of SunVox in a single module. So you can include one SunVox-project into another recursively.",
            GetCustomGenerator = (data) => new MetaModuleGenerator("MetaModule", data)
        },
        new KnownModuleType(36, "MultiControl", InternalName: "MultiCtl")
        {
            Description = "With this module you can change the values of multiple controllers (in different modules) at once. Maximum number of connected controllers - 16."
        },
        new KnownModuleType(37, "MultiSynth")
        {
            Description = "This module sends the incoming events (notes, pitch change, phase change) to any number of connected modules (receivers)."
        },
        new KnownModuleType(38, "PitchToControl", InternalName: "Pitch2Ctl")
        {
            Description = "This module converts the incoming notes to the controller values (in some another connected module)."
        },
        new KnownModuleType(39, "PitchDetector", InternalName: "Pitch Detector")
        {
            Description = "Pitch Detector tries to detect the pitch of the incoming audio signal. The frequency and note will be displayed. Notes will be sent to the module output."
        },
        new KnownModuleType(40, "SoundToControl", InternalName: "Sound2Ctl")
        {
            Description = "This module converts the audio signal to the numeric value of any selected controller."
        },
        new KnownModuleType(41, "VelocityToControl", InternalName: "Velocity2Ctl")
        {
            Description = "This module converts the velocity parameter of the incoming notes to the controller values (in some another connected module)."
        },
    ];

    public static KnownModuleType? GetKnownModuleType(string internalName)
    {
        foreach (var knownModuleType in ModuleTypes)
        {
            if (knownModuleType.InternalName == internalName)
            {
                return knownModuleType;
            }
        }
        return null;
    }
}
