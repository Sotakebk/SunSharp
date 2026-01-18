using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeGeneration.Tests;

internal class GeneratorTests
{
    public static IEnumerable<DiscoveredGenerator> Generators => GeneratorDiscovery.GetGenerators();

    [TestCaseSource(nameof(Generators))]
    public async Task TestGenerator(DiscoveredGenerator generator)
    {
        var result = await generator.GenerateAsync();

        result.Exception.Should().BeNull();
        result.Successful.Should().BeTrue();
        result.ChangesNecessary.Should().BeFalse();
    }
}
