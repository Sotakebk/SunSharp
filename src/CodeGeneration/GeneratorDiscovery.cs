using System.Reflection;
using CodeGeneration.Generators;

namespace CodeGeneration;

public static class GeneratorDiscovery
{
    public static DiscoveredGenerator[] GetGenerators()
    {
        var assembly = typeof(GeneratorDiscovery).Assembly;
        var providerTypes = assembly.GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IGeneratorProvider)))
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .OrderBy(t => t.Name)
            .ToArray();

        var generators = new List<DiscoveredGenerator>();

        foreach (var providerType in providerTypes)
        {
            var method = providerType.GetMethod(nameof(IGeneratorProvider.GetGenerators),
                BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            if (method != null)
            {
                var generatorArray = (BaseGenerator[]?)method.Invoke(null, null);
                if (generatorArray != null)
                {
                    generators.AddRange(generatorArray.Select(g => new DiscoveredGenerator(g)));
                }
            }
        }

        return [.. generators];
    }
}

public class DiscoveredGenerator
{
    public string Name => _generatorInstance.Name;
    public int Priority => _generatorInstance.Priority;
    private readonly BaseGenerator _generatorInstance;

    public DiscoveredGenerator(BaseGenerator generator)
    {
        _generatorInstance = generator;
    }

    public async Task<GeneratorResult> GenerateAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var source = _generatorInstance.Generate();
            var targetPath = _generatorInstance.FilePath;

            string? originalFileContent = null;
            if (File.Exists(targetPath))
            {
                originalFileContent = await File.ReadAllTextAsync(targetPath, cancellationToken).ConfigureAwait(false);
            }

            var sourceCodeIsTheSame = string.Equals(source.ReplaceLineEndings(), originalFileContent?.ReplaceLineEndings(), StringComparison.Ordinal);
            return sourceCodeIsTheSame
                ? GeneratorResult.SuccessNoChanges(Name, targetPath)
                : GeneratorResult.SuccessWithChanges(Name, targetPath, source);
        }
        catch (OperationCanceledException oce)
        {
            return GeneratorResult.Failure(Name, oce);
        }
        catch (Exception ex)
        {
            return GeneratorResult.Failure(Name, ex);
        }
    }

    public override string ToString() => Name;
}
