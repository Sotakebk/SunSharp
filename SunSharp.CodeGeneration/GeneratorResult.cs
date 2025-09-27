using System.Diagnostics.CodeAnalysis;

namespace SunSharp.CodeGeneration;

public sealed class GeneratorResult
{
    public required Type GeneratorType { get; init; }
    public required string TargetPath { get; init; }
    public required string? SourceCode { get; init; }
    public required Exception? Exception { get; init; }

    [MemberNotNullWhen(true, nameof(SourceCode))]
    public required bool ChangesNecessary { get; init; }

    [MemberNotNullWhen(true, nameof(Exception))]
    public required bool Successful { get; init; }

    public static GeneratorResult SuccessWithChanges(Type generatorType, string targetPath, string sourceCode)
    {
        return new GeneratorResult
        {
            GeneratorType = generatorType,
            TargetPath = targetPath,
            SourceCode = sourceCode,
            ChangesNecessary = true,
            Successful = true,
            Exception = null
        };
    }

    public static GeneratorResult SuccessNoChanges(Type generatorType, string targetPath)
    {
        return new GeneratorResult
        {
            GeneratorType = generatorType,
            TargetPath = targetPath,
            SourceCode = null,
            ChangesNecessary = false,
            Successful = true,
            Exception = null
        };
    }

    public static GeneratorResult Failure(Type generatorType, Exception exception)
    {
        return new GeneratorResult
        {
            GeneratorType = generatorType,
            TargetPath = string.Empty,
            SourceCode = null,
            ChangesNecessary = false,
            Successful = false,
            Exception = exception
        };
    }

    public async Task ApplyAsync(CancellationToken cancellationToken = default)
    {
        if (!Successful)
        {
            throw new InvalidOperationException("Cannot apply an unsuccessful generator result.");
        }
        if (!ChangesNecessary)
        {
            return;
        }

        var directory = Path.GetDirectoryName(TargetPath);
        if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);

        var tempFile = Path.Combine(Path.GetDirectoryName(TargetPath)!, Path.GetRandomFileName());
        await File.WriteAllTextAsync(tempFile, SourceCode!, cancellationToken).ConfigureAwait(false);
        File.Copy(tempFile, TargetPath, overwrite: true);
        File.Delete(tempFile);
    }
}
