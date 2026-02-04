using System.Diagnostics.CodeAnalysis;

[assembly: Parallelizable(ParallelScope.All)]
[assembly: ExcludeFromCodeCoverage(Justification = "This is a project that contains tests for code that generates code for the main project.")]
