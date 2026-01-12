using CodeGeneration.Logic;
using SunSharp.CodeGeneration.Logic;

namespace CodeGeneration.Generators;

public sealed class SunVoxHeaderInterfaceGenerator : BaseGenerator, IGeneratorProvider
{
    public static BaseGenerator[] GetGenerators()
    {
        return [new SunVoxHeaderInterfaceGenerator()];
    }

    public override string FilePath => PathHelper.GetProjectFilePath("SunSharp/Native/ISunVoxLibC.g.cs");

    public override string Name => "ISunVoxLibC.g.cs";

    protected override string GenerateBody()
    {
        var parsed = SunVoxHeaderParser.Parse();

        CodeGenerationHelper.AppendHeader(Context);
        AppendLine("#pragma warning disable CA1707 // Identifiers should not contain underscores");
        AppendLine("#pragma warning disable CA1716 // Identifiers should not match keywords");
        AppendLine("#pragma warning disable IDE1006 // Naming Styles");
        AppendLine();
        AppendLine("using System;");
        AppendLine();
        AppendLine("namespace SunSharp.Native");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine("public interface ISunVoxLibC");
            AppendLine("{");
            AddIndent(() =>
            {
                for (var i = 0; i < parsed.Functions.Length; i++)
                {
                    var f = parsed.Functions[i];
                    AppendLine("/// <summary>");
                    AppendLine($"/// {EscapeForXmlDoc(f.OriginalPrototype.Trim())}");
                    AppendLine("/// </summary>");
                    var signature = GetCSharpSignature(f);
                    AppendLine(signature);
                    if (i + 1 != parsed.Functions.Length)
                    {
                        AppendLine();
                    }
                }
            });
            AppendLine("}");
        });
        AppendLine("}");
        return Context.GetBuiltString();
    }

    private static string GetCSharpSignature(ParsedFunction function)
    {
        var parameters = string.Join(
            ", ",
            function.Parameters.Select(p => TypeTranslator.TypeToCode(p.CSharpType) + " " + p.Name)
        );
        return $"{TypeTranslator.TypeToCode(function.CSharpReturnType)} {function.Name}({parameters});";
    }

    private static string EscapeForXmlDoc(string value)
    {
        return System.Security.SecurityElement.Escape(value);
    }
}
