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
        NN = 0,
        Note = NN,
        VV = 1,
        Velocity = VV,
        MM = 2,
        Module = MM,
        CCEE = 3,
        ControllerEffect = CCEE,
        XXYY = 4,
        Parameter = XXYY
    }

    public enum TimeMapType
    {
        Speed = SunVoxConstants.SV_TIME_MAP_SPEED,
        FrameCount = SunVoxConstants.SV_TIME_MAP_FRAMECNT
    }

    public enum ValueScalingMode
    {
        Real = 0,
        Column = 1,
        Displayed = 2
    }

    public enum ControllerType
    {
        Real = 0,
        Enum = 1
    }

    [Flags]
    [SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix",
        Justification = "Corresponds to SV_INIT_FLAG flags, this just makes sense.")]
    public enum InitFlags : uint
    {
        None = 0,

        /// <summary>
        /// Less information will be written to standard output.
        /// </summary>
        NoDebugOutput = SunVoxConstants.SV_INIT_FLAG_NO_DEBUG_OUTPUT,

        /// <summary>
        /// No automatic sound management, sv_audio_callback must be used.
        /// </summary>
        UserAudioCallback = SunVoxConstants.SV_INIT_FLAG_USER_AUDIO_CALLBACK,

        /// <summary>
        /// Sets the format which must be used with sv_audio_callback to <see cref="short" />.
        /// May not apply without <see cref="UserAudioCallback" />. Mutually exclusive with <see cref="AudioFloat32" />.
        /// </summary>
        AudioInt16 = SunVoxConstants.SV_INIT_FLAG_AUDIO_INT16,

        /// <summary>
        /// Sets the format which must be used with sv_audio_callback to <see cref="float" />.
        /// May not apply without <see cref="UserAudioCallback" />. Mutually exclusive with <see cref="AudioInt16" />.
        /// </summary>
        AudioFloat32 = SunVoxConstants.SV_INIT_FLAG_AUDIO_FLOAT32,

        /// <summary>
        /// Audio callback and other methods will be called from one thread.
        /// Applies if <see cref="UserAudioCallback" /> is set.
        /// </summary>
        OneThread = SunVoxConstants.SV_INIT_FLAG_ONE_THREAD
    }
}
