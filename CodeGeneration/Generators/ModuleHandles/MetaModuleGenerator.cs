using CodeGeneration.Logic;

namespace CodeGeneration.Generators.ModuleHandles;

public class MetaModuleGenerator : BasicModuleGenerator
{
    public MetaModuleGenerator(string internalName, KnownModuleData moduleData)
        : base(internalName, moduleData)
    {
    }

    protected override void GenerateInterfaceControllerGettersSetters()
    {
        foreach (var (i, c) in ModuleDescription.Controllers)
        {
            if (i > 4)
            {
                break;
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
            if (i > 4)
            {
                break;
            }

            AppendLine();
            GenerateStructGetter(i, c);
            AppendLine();
            GenerateStructSetter(i, c);
        }
    }
}
