using CodeGeneration.Logic;
using SunSharp.CodeGeneration.Logic;

namespace CodeGeneration.Generators;

internal class SunVoxLibWithLoggerGenerator : BaseGenerator, IGeneratorProvider
{
    public static BaseGenerator[] GetGenerators()
    {
        return [new SunVoxLibWithLoggerGenerator()];
    }

    public override string FilePath => PathHelper.GetProjectFilePath("SunSharp/Diagnostics/SunVoxLibWithLogger.g.cs");

    public override string Name => "SunVoxLibWithLogger.g.cs";

    private static string GetMethodSignature(ParsedFunction function)
    {
        var ret = TypeTranslator.TypeToCode(function.CSharpReturnType);
        var pars = string.Join(", ", function.Parameters.Select(p => $"{TypeTranslator.TypeToCode(p.CSharpType)} {p.Name}"));
        return $"{ret} ISunVoxLibC.{function.Name}({pars})";
    }

    private static string GetParametersString(ParsedFunction function)
    {
        return string.Join(", ", function.Parameters.Select(p => p.Name));
    }

    private static string GetParametersLogString(ParsedFunction function)
    {
        if (function.Parameters.Length == 0)
            return "null";

        var parts = function.Parameters.Select(p =>
        {
            if (p.CSharpType == typeof(IntPtr))
            {
                return $"{p.Name}=0x{{{p.Name}.ToString(\"X\")}}";
            }
            return $"{p.Name}={{{p.Name}}}";
        });
        return "$\"" + string.Join(", ", parts) + "\"";
    }

    protected override string GenerateBody()
    {
        var parsed = SunVoxHeaderParser.Parse();
        var functions = parsed.Functions
            .OrderBy(f => f.Name)
            .ToArray();

        CodeGenerationHelper.AppendHeader(Context);
        AppendLine("using System;");
        AppendLine("using SunSharp.Native;");
        AppendLine();
        AppendLine("namespace SunSharp.Diagnostics");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine("public sealed partial class SunVoxLibWithLogger : ISunVoxLibC");
            AppendLine("{");
            AddIndent(() =>
            {
                var first = true;
                foreach (var f in functions)
                {
                    if (!first)
                    {
                        AppendLine();
                    }
                    AppendMethod(f);
                    first = false;
                }
            });
            AppendLine("}");
        });
        AppendLine("}");

        return Context.GetBuiltString();
    }

    private void AppendMethod(ParsedFunction function)
    {
        AppendLine(GetMethodSignature(function));
        AppendLine("{");
        AddIndent(() =>
        {
            var hasReturnValue = function.CSharpReturnType != typeof(void);
            var parametersLog = GetParametersLogString(function);
            var parametersForwarded = GetParametersString(function);
            AppendLine($"FormattableString? parameters = {parametersLog};");
            AppendLine($"Log(\"Starting call.\", parameters, null);");

            if (hasReturnValue)
            {
                AppendLine($"var result = _lib.{function.Name}({parametersForwarded});");

                if (function.CSharpReturnType == typeof(IntPtr))
                {
                    AppendLine($"Log(\"Finished call.\", parameters, result.ToString(\"X\"));");
                }
                else
                {
                    AppendLine($"Log(\"Finished call.\", parameters, result);");
                }

                AppendLine("return result;");
            }
            else
            {
                AppendLine($"_lib.{function.Name}({parametersForwarded});");
                AppendLine($"Log(\"Finished call.\", parameters, null);");
            }
        });
        AppendLine("}");
        AppendLine();
    }
}
