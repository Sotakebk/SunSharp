using System.Linq;
using AwesomeAssertions;
using CodeGeneration.Logic;
using NUnit.Framework;

namespace CodeGeneration.Tests.Logic;

public class KnownModuleTypesTests
{
    [Test]
    public void ModuleTypes_AreUniqueByIndexAndName()
    {
        KnownModuleTypes.ModuleTypes
            .Should()
            .OnlyHaveUniqueItems(t => t.Index, "Module types must be unique by index.");

        KnownModuleTypes.ModuleTypes
            .Should()
            .OnlyHaveUniqueItems(t => t.FriendlyName, "Module types must be unique by friendly name.");

        KnownModuleTypes.ModuleTypes
            .Should()
            .OnlyHaveUniqueItems(t => t.InternalName, "Module types must be unique by internal name.");
    }

    [Test]
    public void ModuleTypes_DoesNotContainUnknown()
    {
        KnownModuleTypes.ModuleTypes
            .Should()
            .NotContain(t => t.Index == 0, "Module types must not contain an entry for 'Unknown' (index 0).");
    }

    [Test]
    public void ModuleTypes_AreContinuousInIndex()
    {
        var indices = KnownModuleTypes.ModuleTypes
            .Select(t => t.Index)
            .OrderBy(i => i)
            .ToList();

        indices.Add(0);

        var min = indices.Min();
        var max = indices.Max();

        for (var i = min; i <= max; i++)
        {
            indices.Should().Contain(i, $"Module types must be continuous in index from {min} to {max}.");
        }
    }
}
