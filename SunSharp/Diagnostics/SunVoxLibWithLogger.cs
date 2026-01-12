/*
 * Do not modify this file manually.
*/

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using SunSharp.Native;

namespace SunSharp.Diagnostics
{
    /// <summary>
    /// Provides a wrapper for SunVox library operations that includes logging capabilities.
    /// </summary>
    /// <remarks>
    /// This class combines SunVox library functionality with an injected logger to record
    /// operations and errors. Use this type when you need to track SunVox API usage or diagnose
    /// issues through logging. All SunVox interactions performed via this wrapper will be logged
    /// using the provided logger instance.
    /// </remarks>
    public sealed partial class SunVoxLibWithLogger
    {
        private readonly ISunVoxLibC _lib;
        private readonly ILogger _logger;

        public SunVoxLibWithLogger(ISunVoxLibC library, ILogger logger)
        {
            _lib = library ?? throw new ArgumentNullException(nameof(library));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private void Log(string message, FormattableString? parameters, object? result, [CallerMemberName] string memberCallerName = "")
        {
            var p = parameters is null ? null : FormattableString.Invariant(parameters);
            var r = result is null ? null : Convert.ToString(result, CultureInfo.InvariantCulture);
            _logger.Log(message, memberCallerName, p, r);
        }
    }
}
