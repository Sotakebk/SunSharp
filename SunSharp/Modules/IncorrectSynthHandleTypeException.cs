using System;

namespace SunSharp.Modules
{
    public class IncorrectSynthHandleTypeException : Exception
    {
        public IncorrectSynthHandleTypeException() : base()
        {
        }

        public IncorrectSynthHandleTypeException(string message) : base(message)
        {
        }

        public IncorrectSynthHandleTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public IncorrectSynthHandleTypeException(SynthModuleType expected, SynthModuleType? actual)
            : base($"Expected underlying module type to be {expected}, but was {actual?.ToString() ?? "null"}.")
        {
        }
    }
}
