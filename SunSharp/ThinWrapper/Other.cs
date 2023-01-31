using System;

namespace SunSharp.ThinWrapper
{
    internal class Constants
    {
        public const uint SV_INIT_FLAG_NO_DEBUG_OUTPUT = 1 << 0;
        public const uint SV_INIT_FLAG_USER_AUDIO_CALLBACK = 1 << 1;
        public const uint SV_INIT_FLAG_AUDIO_INT16 = 1 << 2;
        public const uint SV_INIT_FLAG_AUDIO_FLOAT32 = 1 << 3;
        public const uint SV_INIT_FLAG_ONE_THREAD = 1 << 4;

        public const int SV_TIME_MAP_SPEED = 0;
        public const int SV_TIME_MAP_FRAMECNT = 1;
    }

    public enum Channel : int
    {
        Mono = 0,
        Left = 0,
        Right = 1
    }

    public enum Channels : int
    {
        Mono = 1,
        Stereo = 2
    }

    public enum Column : int
    {
        NN = 0,
        VV = 1,
        MM = 2,
        CCEE = 3,
        XXYY = 4
    }

    [Flags]
    public enum InitFlags : uint
    {
        Default = 0,
        /// <summary>
        /// Less data will be written to standard output.
        /// </summary>
        NoDebugOutput = Constants.SV_INIT_FLAG_NO_DEBUG_OUTPUT,
        /// <summary>
        /// No automatic sound management, sv_audio_callback must be used.
        /// </summary>
        UserAudioCallback = Constants.SV_INIT_FLAG_USER_AUDIO_CALLBACK,
        /// <summary>
        /// Sets the format which must be used with sv_audio_callback to <see cref="short"/>.
        /// May not apply without <see cref="UserAudioCallback"/>. Mutually exclusive with <see cref="AudioFloat32"/>.
        /// </summary>
        AudioInt16 = Constants.SV_INIT_FLAG_AUDIO_INT16,
        /// <summary>
        /// Sets the format which must be used with sv_audio_callback to <see cref="float"/>.
        /// May not apply without <see cref="UserAudioCallback"/>. Mutually exclusive with <see cref="AudioInt16"/>.
        /// </summary>
        AudioFloat32 = Constants.SV_INIT_FLAG_AUDIO_FLOAT32,
        /// <summary>
        /// Audio callback and other methods will be called from one thread.
        /// Applies if <see cref="UserAudioCallback"/> is set.
        /// </summary>
        OneThread = Constants.SV_INIT_FLAG_ONE_THREAD
    }

    public enum TimeMapType : int
    {
        Speed = Constants.SV_TIME_MAP_SPEED,
        FrameCount = Constants.SV_TIME_MAP_FRAMECNT,
    }

    public readonly struct Version
    {
        public readonly byte Major, Minor, Minor2;

        public Version(byte major, byte minor, byte minor2)
        {
            Major = major;
            Minor = minor;
            Minor2 = minor2;
        }

        public Version(int code)
        {
            Major = (byte)(code >> 16 & 255);
            Minor = (byte)(code >> 8 & 255);
            Minor2 = (byte)(code & 255);
        }

        public override string ToString() => $"SunVox Lib v{Major}.{Minor}.{Minor2}";
    }
}
