using CodeGeneration.Logic;

namespace CodeGeneration.Generators.ModuleHandles;

public class FmxModuleGenerator : BasicModuleGenerator
{
    public FmxModuleGenerator(string internalName, KnownModuleData moduleData)
        : base(internalName, moduleData)
    {
    }

    protected override void GenerateInterfaceControllerGettersSetters()
    {
        foreach (var (i, c) in ModuleDescription.Controllers)
        {
            if (i > 8 && i < 114)
            {
                continue;
            }

            AppendLine();
            GenerateInterfaceGetter(i, c);
            AppendLine();
            GenerateInterfaceSetter(i, c);
        }
    }

    protected override void GenerateModuleControllerGettersSetters()
    {
        foreach (var (i, c) in ModuleDescription.Controllers)
        {
            if (i > 8 && i < 114)
            {
                continue;
            }

            AppendLine();
            GenerateStructGetter(i, c);
            AppendLine();
            GenerateStructSetter(i, c);
        }
    }
}
