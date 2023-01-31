namespace SunSharp.ThinWrapper
{
    public readonly struct ModuleFlags
    {
        private const uint SV_MODULE_FLAG_EXISTS = 1 << 0;
        private const uint SV_MODULE_FLAG_EFFECT = 1 << 1;
        private const uint SV_MODULE_FLAG_MUTE = 1 << 2;
        private const uint SV_MODULE_FLAG_SOLO = 1 << 3;
        private const uint SV_MODULE_FLAG_BYPASS = 1 << 4;

        private const int SV_MODULE_INPUTS_OFF = 16;
        private const uint SV_MODULE_INPUTS_MASK = 255u << 16;
        private const int SV_MODULE_OUTPUTS_OFF = 16 + 8;
        private const uint SV_MODULE_OUTPUTS_MASK = 255u << 16 + 8;

        public readonly uint Value;

        public bool Exists => (Value & SV_MODULE_FLAG_EXISTS) != 0;
        public bool Effect => (Value & SV_MODULE_FLAG_EFFECT) != 0;
        public bool Mute => (Value & SV_MODULE_FLAG_MUTE) != 0;
        public bool Solo => (Value & SV_MODULE_FLAG_SOLO) != 0;
        public bool Bypass => (Value & SV_MODULE_FLAG_BYPASS) != 0;

        /// <summary>
        /// Actual input count may be less or equal.
        /// </summary>
        public int InputUpperCount => (int)((Value & SV_MODULE_INPUTS_MASK) >> SV_MODULE_INPUTS_OFF);

        /// <summary>
        /// Actual output count may be less or equal
        /// </summary>
        public int OutputUpperCount => (int)((Value & SV_MODULE_OUTPUTS_MASK) >> SV_MODULE_OUTPUTS_OFF);

        public ModuleFlags(uint value)
        {
            Value = value;
        }

        public static implicit operator ModuleFlags(uint value)
        {
            return new ModuleFlags(value);
        }

        public static implicit operator uint(ModuleFlags flags)
        {
            return flags.Value;
        }
    }
}
