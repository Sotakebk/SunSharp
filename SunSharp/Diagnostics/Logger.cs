using System;
using System.Diagnostics.CodeAnalysis;

namespace SunSharp.Diagnostics
{
    /// <summary>
    /// To be used for logging method calls and their parameters/results. Potentially useful for debugging interop issues.
    /// Used in tandem with <see cref="SunVoxLibWithLogger"/>.
    /// </summary>
    public interface ILogger
    {
        void Log(string message, string methodName, string? parameters, string? result);
    }

    /// <inheritdoc cref="ILogger"/>
    [ExcludeFromCodeCoverage]
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, string methodName, string? parameters, string? result)
        {
            if (result == null)
            {
                Console.WriteLine($"[{DateTime.Now}] {message} | Method: {methodName} | Parameters: {parameters ?? "<none>"}");
            }
            else
            {
                Console.WriteLine($"[{DateTime.Now}] {message} | Method: {methodName} | Parameters: {parameters ?? "<none>"} | Result: {result}");
            }
        }
    }
}
