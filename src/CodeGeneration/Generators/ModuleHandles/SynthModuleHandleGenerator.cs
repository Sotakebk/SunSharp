using CodeGeneration.Logic;
using SunSharp;

namespace CodeGeneration.Generators.ModuleHandles;

public sealed class SynthModuleHandleGenerator : BaseGenerator, IGeneratorProvider
{
    public static BaseGenerator[] GetGenerators()
    {
        return [new SynthModuleHandleGenerator()];
    }

    public override string FilePath => PathHelper.GetProjectFilePath("SunSharp/SynthModuleHandle.g.cs");

    public override string Name => $"{nameof(SynthModuleHandle)}.g.cs";

    protected override string GenerateBody()
    {
        CodeGenerationHelper.AppendHeader(Context);
        AppendLine("#if !SUNSHARP_GENERATION");
        AppendLine("using SunSharp.Modules;");
        AppendLine();
        AppendLine("namespace SunSharp");
        AppendLine("{");
        AddIndent(() =>
        {
            GenerateInterfacePart();
            AppendLine();
            GenerateStructPart();
        });
        AppendLine("}");
        AppendLine("#endif");
        return Context.GetBuiltString();
    }

    private void GenerateInterfacePart()
    {
        AppendLine($"public partial interface {nameof(ISynthModuleHandle)}");
        AppendLine("{");
        AddIndent(() =>
        {
            var first = true;
            foreach (var module in KnownModuleTypes.ModuleTypes)
            {
                if (!first)
                {
                    AppendLine();
                }
                AppendLine($"I{module.FriendlyName}ModuleHandle As{module.FriendlyName}();");
                first = false;
            }
        });
        AppendLine("}");
    }

    private void GenerateStructPart()
    {
        AppendLine($"public readonly partial struct {nameof(SynthModuleHandle)} : {nameof(ISynthModuleHandle)}");
        AppendLine("{");
        AddIndent(() =>
        {
            var first = true;
            foreach (var module in KnownModuleTypes.ModuleTypes)
            {
                if (!first)
                {
                    AppendLine();
                }
                AppendLine($"public {module.FriendlyName}ModuleHandle As{module.FriendlyName}() => new {module.FriendlyName}ModuleHandle(this);");
                AppendLine();
                AppendLine($"I{module.FriendlyName}ModuleHandle ISynthModuleHandle.As{module.FriendlyName}() => new {module.FriendlyName}ModuleHandle(this);");
                first = false;
            }
        });
        AppendLine("}");
    }
}
