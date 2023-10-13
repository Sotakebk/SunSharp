using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.All)]
[assembly: ExcludeFromCodeCoverage(Justification = "Test code assembly.")]
