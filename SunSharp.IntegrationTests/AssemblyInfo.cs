using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.None)]
[assembly: ExcludeFromCodeCoverage(Justification = "Test code assembly.")]
