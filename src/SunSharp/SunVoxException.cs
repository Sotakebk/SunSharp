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
        public SunVoxException()
        {
        }

        public SunVoxException(string message)
            : base(message)
        {
        }

        public SunVoxException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SunVoxException(uint code, string? method = null)
            : this(ConstructMessage(code, method, null))
        {
        }

        public SunVoxException(int code, string? method = null)
            : this(ConstructMessage(unchecked((uint)code), method, null))
        {
        }

        public SunVoxException(int code, string method, string message)
            : base(ConstructMessage(unchecked((uint)code), method, message))
        {
        }

        public SunVoxException(long code, string method, string message)
            : base(ConstructMessage(unchecked((ulong)code), method, message))
        {
        }

        public SunVoxException(ulong code, string method, string message)
            : base(ConstructMessage(code, method, message))
        {
        }

        private static string ConstructMessage(ulong code, string? method, string? details)
        {
            if (details == null)
            {
                return $"Received error code {code:X} from method: {method ?? "unknown"}.";
            }
            else
            {
                return $"Received error code {code:X} from method: {method ?? "unknown"}. {details}";
            }
        }

        private static string ConstructMessage(uint code, string? method, string? details)
        {
            if (details == null)
            {
                return $"Received error code {code:X} from method: {method ?? "unknown"}.";
            }
            else
            {
                return $"Received error code {code:X} from method: {method ?? "unknown"}. {details}";
            }
        }
    }
}
