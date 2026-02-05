using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CodeGeneration;

public sealed class GeneratorResult
{
    public required string GeneratorName { get; init; }
    public required string TargetPath { get; init; }
    public required string? SourceCode { get; init; }
    public required Exception? Exception { get; init; }

    [MemberNotNullWhen(true, nameof(SourceCode))]
    public required bool ChangesNecessary { get; init; }

    [MemberNotNullWhen(true, nameof(Exception))]
    public required bool Successful { get; init; }

    public static GeneratorResult SuccessWithChanges(string generatorName, string targetPath, string sourceCode)
    {
        return new GeneratorResult
        {
            GeneratorName = generatorName,
            TargetPath = targetPath,
            SourceCode = sourceCode,
            ChangesNecessary = true,
            Successful = true,
            Exception = null
        };
    }

    public static GeneratorResult SuccessNoChanges(string generatorName, string targetPath)
    {
        return new GeneratorResult
        {
            GeneratorName = generatorName,
            TargetPath = targetPath,
            SourceCode = null,
            ChangesNecessary = false,
            Successful = true,
            Exception = null
        };
    }

    public static GeneratorResult Failure(string generatorName, Exception exception)
    {
        return new GeneratorResult
        {
            GeneratorName = generatorName,
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
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var tempFile = Path.Combine(Path.GetDirectoryName(TargetPath)!, Path.GetRandomFileName());
        var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
        await File.WriteAllTextAsync(tempFile, SourceCode, encoding, cancellationToken).ConfigureAwait(false);
        File.Copy(tempFile, TargetPath, overwrite: true);
        File.Delete(tempFile);
    }
}
