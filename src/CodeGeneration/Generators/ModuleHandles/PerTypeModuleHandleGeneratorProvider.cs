using CodeGeneration.Logic;

namespace CodeGeneration.Generators.ModuleHandles;

public sealed class PerTypeModuleHandleGeneratorProvider : IGeneratorProvider
{
    public static BaseGenerator[] GetGenerators()
    {
        var moduleData = ModuleDataLoader.LoadFromFile(PathHelper.GetProjectFilePath("CodeGeneration/Logic/ModuleData.g.json"));
        if (moduleData == null)
        {
            return [];
        }

        return [.. KnownModuleTypes.ModuleTypes.Select(t => FromKnownModule(t, moduleData))];
    }

    private static BaseGenerator FromKnownModule(KnownModuleType moduleType, KnownModuleData moduleData)
    {
        return moduleType.GetCustomGenerator?.Invoke(moduleData)
            ?? new BasicModuleGenerator(moduleType.InternalName, moduleData);
    }
}
