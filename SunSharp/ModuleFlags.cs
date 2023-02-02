namespace SunSharp
{
    public readonly struct ModuleFlags
    {
        private const uint SV_MODULE_FLAG_EXISTS = 1 << 0;
        private const uint SV_MODULE_FLAG_GENERATOR = 1 << 1;
        private const uint SV_MODULE_FLAG_EFFECT = 1 << 2;
        private const uint SV_MODULE_FLAG_MUTE = 1 << 3;
        private const uint SV_MODULE_FLAG_SOLO = 1 << 4;
        private const uint SV_MODULE_FLAG_BYPASS = 1 << 5;

        private const int SV_MODULE_INPUTS_OFF = 16;
        private const uint SV_MODULE_INPUTS_MASK = 255u << 16;
        private const int SV_MODULE_OUTPUTS_OFF = 16 + 8;
        private const uint SV_MODULE_OUTPUTS_MASK = 255u << 16 + 8;

        private readonly uint _value;

        public uint Value => _value;

        public bool Exists => (_value & SV_MODULE_FLAG_EXISTS) != 0;

        /// <summary>
        /// This module receives notes and outputs sound.
        /// </summary>
        public bool Generator => (_value & SV_MODULE_FLAG_GENERATOR) != 0;

        /// <summary>
        /// This module receives sound and outputs sound.
        /// </summary>
        public bool Effect => (_value & SV_MODULE_FLAG_EFFECT) != 0;

        public bool Mute => (_value & SV_MODULE_FLAG_MUTE) != 0;
        public bool Solo => (_value & SV_MODULE_FLAG_SOLO) != 0;
        public bool Bypass => (_value & SV_MODULE_FLAG_BYPASS) != 0;

        /// <summary>
        /// Actual input count may be less or equal.
        /// </summary>
        public int InputUpperCount => (int)((_value & SV_MODULE_INPUTS_MASK) >> SV_MODULE_INPUTS_OFF);

        /// <summary>
        /// Actual output count may be less or equal
        /// </summary>
        public int OutputUpperCount => (int)((_value & SV_MODULE_OUTPUTS_MASK) >> SV_MODULE_OUTPUTS_OFF);

        public ModuleFlags(uint value)
        {
            _value = value;
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
