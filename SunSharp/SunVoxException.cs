using System;

namespace SunSharp
{
    /// <summary>
    /// Represents errors that occur when the SunVox library returns an unexpected value or is called in an invalid
    /// state.
    /// </summary>
    /// <remarks>
    /// Additional diagnostic information may be available in the standard output of the process
    /// hosting the SunVox library. Check STDOUT for details if this exception is thrown.
    /// </remarks>
    public sealed class SunVoxException : Exception
    {
        private readonly uint _code;
        private readonly string? _method;

        public SunVoxException()
        {
        }

        public SunVoxException(string message) : base(message)
        {
        }

        public SunVoxException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public SunVoxException(uint code, string? method = null)
        {
            _code = code;
            _method = method;
        }

        public SunVoxException(int code, string? method = null) : this((uint)code, method)
        {
        }

        public override string Message => $"Error code: {_code:X}, method: '{_method ?? "unknown"}'.";
    }
}
