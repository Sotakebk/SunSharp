#if SUNSHARP_GENERATION

namespace SunSharp
{
    public enum SynthModuleType
    {
        Unknown = 0,
    }

    public static class SynthModuleTypeHelper
    {
        /// <summary>
        /// Gets the internal name for a given SynthModuleType.
        /// </summary>
        /// <remarks>
        /// In case of unknown SynthModuleType, returns "unknown".
        /// </remarks>
        public static string InternalNameFromType(SynthModuleType type)
        {
            switch (type)
            {
                default: return "unknown";
            }
        }

        public static SynthModuleType TypeFromInternalName(string internalName)
        {
            switch (internalName)
            {
                default: return SynthModuleType.Unknown;
            }
        }

        public static bool IsValid(SynthModuleType type)
        {
            return (int)type >= -1 && (int)type <= 41;
        }

        public static string ToInternalName(this SynthModuleType type)
        {
            return InternalNameFromType(type);
        }
    }
}

#endif
