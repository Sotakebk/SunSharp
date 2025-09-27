using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeAssertions;
using NUnit.Framework;

namespace SunSharp.CodeGeneration.Tests;

internal class GeneratorTests
{
    public static IEnumerable<DiscoveredGenerator> Generators => GeneratorDiscovery.GetGenerators();

    [TestCaseSource(nameof(Generators))]
    public async Task Test(DiscoveredGenerator generator)
    {
        var result = await generator.GenerateAsync();

        result.Successful.Should().BeTrue();
        result.ChangesNecessary.Should().BeFalse();
    }
}
