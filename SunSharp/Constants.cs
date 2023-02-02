namespace SunSharp
{
    internal static class Constants
    {
        public const uint SV_INIT_FLAG_NO_DEBUG_OUTPUT = 1 << 0;
        public const uint SV_INIT_FLAG_USER_AUDIO_CALLBACK = 1 << 1;
        public const uint SV_INIT_FLAG_AUDIO_INT16 = 1 << 2;
        public const uint SV_INIT_FLAG_AUDIO_FLOAT32 = 1 << 3;
        public const uint SV_INIT_FLAG_ONE_THREAD = 1 << 4;

        public const int SV_TIME_MAP_SPEED = 0;
        public const int SV_TIME_MAP_FRAMECNT = 1;
    }
}
