using System.Linq;
using AwesomeAssertions.Execution;
using CodeGeneration.Logic;
using SunSharp;

namespace CodeGeneration.Tests.Logic;

public class ModuleDataTests
{
    private readonly string _moduleDataFilePath = PathHelper.GetProjectFilePath("CodeGeneration/Logic/ModuleData.g.json");

    [Test]
    public void ModuleData_AllControllersWithEnum_HaveMatchingEnums()
    {
        var moduleData = ModuleDataLoader.LoadFromFile(_moduleDataFilePath);
        moduleData.Should().NotBeNull();

        var enums = typeof(SunVox).Assembly
            .GetTypes()
            .Where(t => t.IsEnum && t.IsPublic)
            .Where(t => t.Namespace != null && t.Namespace.StartsWith("SunSharp.Modules"))
            .ToDictionary(t => t.Name, t => t);

        void AssertOnController(string moduleName, ControllerDescription controller)
        {
            using var assertionScope = new AssertionScope();
            var enumName = controller.EnumName ?? throw new();

            enums.TryGetValue(enumName, out var matchingEnum);
            matchingEnum.Should().NotBeNull($"Controller '{controller.InternalName}' in module '{moduleName}' references enum {enumName}, but such enum is not available");
            if (matchingEnum == null)
            {
                return;
            }

            var values = matchingEnum.GetEnumValues();
            values.Length.Should().BeGreaterThan(0, $"Controller '{controller.InternalName}' in module '{moduleName}' references enum {enumName}, but enum does not have any values.");
            var intValues = values.Cast<int>().ToArray();

            var minEnumValue = intValues.Min(v => v);
            var maxEnumValue = intValues.Max(v => v);
            minEnumValue.Should().Be(controller.MinValue, $"Controller '{controller.InternalName}' in module '{moduleName}' has a min value of {controller.MinValue}, but enum '{enumName}' has a min value of {minEnumValue}");
            maxEnumValue.Should().Be(controller.MaxValue, $"Controller '{controller.InternalName}' in module '{moduleName}' has a max value of {controller.MaxValue}, but enum '{enumName}' has a max value of {maxEnumValue}");
        }

        using var assertionScope = new AssertionScope();
        foreach (var (moduleName, module) in moduleData.Modules)
        {
            foreach (var (controllerId, controller) in module.Controllers)
            {
                if (controller.EnumName != null)
                {
                    AssertOnController(moduleName, controller);
                }
            }
        }
    }

    [Test]
    public void ModuleData_AllCurves_HaveAllData()
    {
        var moduleData = ModuleDataLoader.LoadFromFile(_moduleDataFilePath);
        moduleData.Should().NotBeNull();

        using var assertionScope = new AssertionScope();
        foreach (var (moduleName, module) in moduleData.Modules)
        {
            foreach (var (curveId, curve) in module.Curves)
            {
                curve.MinValue.Should().NotBeNull($"Curve {curveId} '{curve.FriendlyName}' in module '{moduleName}' is missing MinValue");
                curve.MaxValue.Should().NotBeNull($"Curve {curveId} '{curve.FriendlyName}' in module '{moduleName}' is missing MaxValue");
                curve.FriendlyName.Should().NotMatchRegex("Curve[\\d]+", $"Curve {curveId} '{curve.FriendlyName}' in module '{moduleName}' should have it's name set");
            }
        }
    }

    [Test]
    public void ModuleData_AllModules_HaveCorrespondingKnownModuleType()
    {
        var moduleData = ModuleDataLoader.LoadFromFile(_moduleDataFilePath);
        moduleData.Should().NotBeNull();

        using var assertionScope = new AssertionScope();
        foreach (var (moduleName, module) in moduleData.Modules)
        {
            var knownModuleType = KnownModuleTypes.GetKnownModuleType(moduleName);
            knownModuleType.Should().NotBeNull($"Module '{moduleName}' does not have corresponding KnownModuleType");
        }
    }
}

