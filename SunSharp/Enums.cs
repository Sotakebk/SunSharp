using System;
using System.Diagnostics.CodeAnalysis;

namespace SunSharp
{
    public enum AudioChannel
    {
        Mono = 0,
        Left = Mono,
        Right = 1
    }

    public enum AudioChannels
    {
        Mono = 1,
        Stereo = 2
    }

    public enum Column
    {
        /// <summary>
        /// The 'Note' column (NN).
        /// </summary>
        Note = 0,

        /// <summary>
        /// The 'Velocity' column (VV).
        /// </summary>
        Velocity = 1,

        /// <summary>
        /// The 'Module' column (MM).
        /// </summary>
        Module = 2,

        /// <summary>
        /// The 'Controller Effect' column (CCEE).
        /// </summary>
        ControllerEffect = 3,

        /// <summary>
        /// The 'Parameter' column (XXYY).
        /// </summary>
        Parameter = 4
    }

    public enum TimeMapType
    {
        Speed = 0,
        FrameCount = 1
    }

    public enum ValueScalingMode
    {
        Real = 0,
        Column = 1,
        Displayed = 2
    }

    public enum ControllerType
    {
        /// <summary>
        /// Volume, frequency, resonance and other parameters with a continuous scale.
        /// In pattern events the value takes the whole range that is then mapped to the real parameter range.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Number of harmonics, waveform type, etc.
        /// In pattern events the value is an index of a discrete set of values.
        /// </summary>
        Selector = 1
    }

    [Flags]
    public enum SunVoxInitOptions : uint
    {
        None = 0,

        /// <summary>
        /// Less information will be written to standard output.
        /// </summary>
        NoDebugOutput = 1 << 0,

        /// <summary>
        /// No automatic sound management, sv_audio_callback must be used.
        /// </summary>
        UserAudioCallback = 1 << 1,

        /// <summary>
        /// Sets the format which must be used with sv_audio_callback to <see cref="short" />.
        /// May not apply without <see cref="UserAudioCallback" />. Mutually exclusive with <see cref="AudioFloat32" />.
        /// </summary>
        AudioInt16 = 1 << 2,

        /// <summary>
        /// Sets the format which must be used with sv_audio_callback to <see cref="float" />.
        /// May not apply without <see cref="UserAudioCallback" />. Mutually exclusive with <see cref="AudioInt16" />.
        /// </summary>
        AudioFloat32 = 1 << 3,

        /// <summary>
        /// Audio callback and other methods will be called from one thread.
        /// Applies if <see cref="UserAudioCallback" /> is set.
        /// </summary>
        OneThread = 1 << 4
    }

    [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "The enum is supposed to help with choosing a type.")]
    public enum OutputType
    {
        Float32 = 1,
        Int16 = 2
    }
}
