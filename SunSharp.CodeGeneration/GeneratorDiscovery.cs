using SunSharp.CodeGeneration.Generators;

namespace SunSharp.CodeGeneration;

public static class GeneratorDiscovery
{
    public static IReadOnlyList<DiscoveredGenerator> GetGenerators(string? nameFilter = null)
    {
        var assembly = typeof(GeneratorDiscovery).Assembly;
        var query = assembly.GetTypes()
            .Where(t => t.IsAssignableTo(typeof(BaseGenerator)))
            .Where(t => !t.IsAbstract);

        if (!string.IsNullOrWhiteSpace(nameFilter))
        {
            query = query.Where(t => t.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase));
        }

        return query
            .OrderBy(t => t.Name)
            .Select(t => new DiscoveredGenerator(t))
            .ToArray();
    }
}

public sealed class DiscoveredGenerator
{
    public Type GeneratorType { get; }
    public string Name => GeneratorType.Name;

    internal DiscoveredGenerator(Type generatorType)
    {
        GeneratorType = generatorType;
    }

    public async Task<GeneratorResult> GenerateAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            var instance = (BaseGenerator?)Activator.CreateInstance(GeneratorType)
                           ?? throw new InvalidOperationException($"Could not create instance of '{GeneratorType}'.");

            var source = instance.Generate();
            var targetPath = instance.FilePath;

            string? originalFileContent = null;
            if (File.Exists(targetPath))
            {
                originalFileContent = await File.ReadAllTextAsync(targetPath, cancellationToken).ConfigureAwait(false);
            }

            var sourceCodeIsTheSame = string.Equals(source, originalFileContent, StringComparison.Ordinal);
            return sourceCodeIsTheSame
                ? GeneratorResult.SuccessNoChanges(GeneratorType, targetPath)
                : GeneratorResult.SuccessWithChanges(GeneratorType, targetPath, source);
        }
        catch (OperationCanceledException oce)
        {
            return GeneratorResult.Failure(GeneratorType, oce);
        }
        catch (Exception ex)
        {
            return GeneratorResult.Failure(GeneratorType, ex);
        }
    }

    public override string ToString() => Name;
}
