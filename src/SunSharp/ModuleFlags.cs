using System.Runtime.InteropServices;

namespace SunSharp
{
    /// <summary>
    /// Represents the flags and properties of a SunVox module.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public readonly struct ModuleFlags
    {
        internal const uint SV_MODULE_FLAG_EXISTS = 1 << 0;
        internal const uint SV_MODULE_FLAG_GENERATOR = 1 << 1;
        internal const uint SV_MODULE_FLAG_EFFECT = 1 << 2;
        internal const uint SV_MODULE_FLAG_MUTE = 1 << 3;
        internal const uint SV_MODULE_FLAG_SOLO = 1 << 4;
        internal const uint SV_MODULE_FLAG_BYPASS = 1 << 5;

        internal const int SV_MODULE_INPUTS_OFF = 16;
        internal const uint SV_MODULE_INPUTS_MASK = 255u << 16;
        internal const int SV_MODULE_OUTPUTS_OFF = 16 + 8;
        internal const uint SV_MODULE_OUTPUTS_MASK = 255u << (16 + 8);

        [field: FieldOffset(0)] public uint Value { get; }

        public bool Exists => (Value & SV_MODULE_FLAG_EXISTS) != 0;

        /// <summary>
        /// Whether this module receives notes and outputs sound.
        /// </summary>
        public bool Generator => (Value & SV_MODULE_FLAG_GENERATOR) != 0;

        /// <summary>
        /// Whether this module receives sound and outputs sound.
        /// </summary>
        public bool Effect => (Value & SV_MODULE_FLAG_EFFECT) != 0;

        public bool Mute => (Value & SV_MODULE_FLAG_MUTE) != 0;
        public bool Solo => (Value & SV_MODULE_FLAG_SOLO) != 0;
        public bool Bypass => (Value & SV_MODULE_FLAG_BYPASS) != 0;

        /// <summary>
        /// Upper count of inputs connected to this module at this time.
        /// </summary>
        /// <remarks>
        /// The actual input count may be less or equal to this value.
        /// Does not inform about a module's maximum input capacity.
        /// </remarks>
        public int InputUpperCount => (int)((Value & SV_MODULE_INPUTS_MASK) >> SV_MODULE_INPUTS_OFF);

        /// <summary>
        /// Upper count of outputs connected to this module at this time.
        /// </summary>
        /// <remarks>
        /// The actual input count may be less or equal to this value.
        /// Does not inform about a module's maximum output capacity.
        /// </remarks>
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
