using CodeGeneration.Logic;

namespace CodeGeneration.Generators;

internal class SynthModuleTypeGenerator : BaseGenerator, IGeneratorProvider
{
    public static BaseGenerator[] GetGenerators()
    {
        return [new SynthModuleTypeGenerator()];
    }

    public override string FilePath => PathHelper.GetProjectFilePath("SunSharp/SynthModuleType.g.cs");

    public override string Name => "SynthModuleType.g.cs";

    protected override string GenerateBody()
    {
        CodeGenerationHelper.AppendHeader(Context);
        AppendLine("#if !SUNSHARP_GENERATION");
        AppendLine("namespace SunSharp");
        AppendLine("{");
        AddIndent(() =>
        {
            GenerateEnum();
            AppendLine();
            GenerateHelper();
        });
        AppendLine("}");
        AppendLine("#endif");
        return Context.GetBuiltString();
    }

    private void GenerateEnum()
    {
        AppendLine("public enum SynthModuleType");
        AppendLine("{");
        AddIndent(() =>
        {
            foreach (var value in KnownModuleTypes.ModuleTypes.OrderBy(t => t.FriendlyName))
            {
                AppendLine($"{value.FriendlyName} = {value.Index},");
            }
            AppendLine($"Unknown = 0,");
        });
        AppendLine("}");
    }

    private void GenerateHelper()
    {
        AppendLine("public static class SynthModuleTypeHelper");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine("/// <summary>");
            AppendLine("/// Gets the internal name for a given SynthModuleType.");
            AppendLine("/// </summary>");
            AppendLine("/// <remarks>");
            AppendLine("/// In case of unknown SynthModuleType, returns \"unknown\".");
            AppendLine("/// </remarks>");
            AppendLine("public static string InternalNameFromType(SynthModuleType type)");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("switch (type)");
                AppendLine("{");
                AddIndent(() =>
                {
                    foreach (var value in KnownModuleTypes.ModuleTypes.OrderBy(t => t.FriendlyName))
                    {
                        AppendLine($"case SynthModuleType.{value.FriendlyName}: return \"{value.InternalName}\";");
                    }
                    AppendLine($"default: return \"unknown\";");
                });
                AppendLine("}");
            });
            AppendLine("}");
            AppendLine();

            AppendLine("/// <summary>");
            AppendLine("/// Gets the SynthModuleType for a given internal name.");
            AppendLine("/// </summary>");
            AppendLine("/// <remarks>");
            AppendLine("/// In case of unknown internal name, returns SynthModuleType.Unknown.");
            AppendLine("/// </remarks>");
            AppendLine("public static SynthModuleType TypeFromInternalName(string internalName)");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("switch (internalName)");
                AppendLine("{");
                AddIndent(() =>
                {
                    foreach (var value in KnownModuleTypes.ModuleTypes.OrderBy(t => t.FriendlyName))
                        AppendLine($"case \"{value.InternalName}\": return SynthModuleType.{value.FriendlyName};");
                    AppendLine($"default: return SynthModuleType.Unknown;");
                });
                AppendLine("}");
            });
            AppendLine("}");
            AppendLine();
            AppendLine("/// <summary>");
            AppendLine("/// Checks if value of <see cref=\"SynthModuleType\"/> is valid.");
            AppendLine("/// </summary>");
            AppendLine("public static bool IsValid(SynthModuleType type)");
            AppendLine("{");
            AddIndent(() =>
            {
                var min = KnownModuleTypes.ModuleTypes.Select(i => i.Index).Min();
                var max = KnownModuleTypes.ModuleTypes.Select(i => i.Index).Max();
                AppendLine($"return (int)type >= {min} && (int)type <= {max};");
            });
            AppendLine("}");
            AppendLine();
            AppendLine("public static string ToInternalName(this SynthModuleType type)");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("return InternalNameFromType(type);");
            });
            AppendLine("}");
        });
        AppendLine("}");
    }
}
