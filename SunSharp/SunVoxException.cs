using System;

namespace SunSharp
{
    /// <summary>
    /// This exception signifies that SunVox returned an unexpected value,
    /// which may be caused by being in the wrong state when calling methods.
    /// In case of issues, please check STDOUT of the process hosting the SunVox library,
    /// as more information may be provided there.
    /// </summary>
    /// <inheritdoc />
    public sealed class SunVoxException : Exception
    {
        private readonly uint _code;
        private readonly string? _method;

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
