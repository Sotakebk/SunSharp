using SunSharp.CodeGeneration.Logic;
using SunSharp.Native.Loader;

namespace SunSharp.CodeGeneration.Generators.NativeProxy;

public sealed class NativeInterfaceGenerator : BaseGenerator
{
    public override string FilePath => PathHelper.GetProjectFilePath("SunSharp/Native/Loader/NativeProxy.ISunVoxLibC.g.cs");

    private static string GetDelegateNameCode(ParsedFunction function)
    {
        var outName = TypeTranslator.TypeToCode(function.CSharpReturnType);
        var inName = string.Join(null, function.Parameters.Select(p => TypeTranslator.TypeToCode(p.CSharpType)));
        if (inName.Length == 0) inName = "Void";
        return $"Returns{outName}Takes{inName}";
    }

    private record DelegateDefinitionCode(string DelegateName, string Code);

    private static DelegateDefinitionCode GetDelegateDefinitionCode(ParsedFunction function)
    {
        var ret = TypeTranslator.TypeToCode(function.CSharpReturnType);
        var args = string.Join(", ", function.Parameters.Select((p, i) => $"{TypeTranslator.TypeToCode(p.CSharpType)} arg{i + 1}"));
        var name = GetDelegateNameCode(function);
        return new DelegateDefinitionCode(name, $"private delegate {ret} {name}({args});");
    }

    private static string GetInterfaceMethodCode(ParsedFunction function)
    {
        var ret = TypeTranslator.TypeToCode(function.CSharpReturnType);
        var pars = string.Join(", ", function.Parameters.Select(p => $"{TypeTranslator.TypeToCode(p.CSharpType)} {p.Name}"));
        var forwarded = string.Join(", ", function.Parameters.Select(p => p.Name));
        return $"{ret} ISunVoxLibC.{function.Name}({pars}) => {function.Name}?.Invoke({forwarded}) ?? throw GetNoDelegateException();";
    }

    protected override string GenerateBody()
    {
        var parsed = SunVoxHeaderParser.Parse();
        var functions = parsed.Functions
            .OrderBy(f => f.Name)
            .ToArray();

        AppendLineNoTab("#pragma warning disable CS0649");
        AppendLineNoTab("#nullable enable");
        AppendLine();
        AppendLine("using System;");
        AppendLine();
        AppendLine("namespace SunSharp.Native.Loader");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine($"public sealed partial class {nameof(Native.Loader.NativeProxy)} : ISunVoxLibC");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("#region delegate definitions");
                AppendLine();
                AppendDelegateDefinitions(functions);
                AppendLine();
                AppendLine("#endregion delegate definitions");
                AppendLine();
                AppendLine("#region delegates");
                AppendLine();
                foreach (var f in functions)
                {
                    AppendLine($"private {GetDelegateNameCode(f)}? {f.Name};");
                    AppendLine();
                }
                AppendLine("#endregion delegates");
                AppendLine();
                AppendLine("#region interface");
                AppendLine();
                foreach (var f in functions)
                {
                    AppendLine(GetInterfaceMethodCode(f));
                    AppendLine();
                }
                AppendLine("#endregion interface");
                AppendLine();
                AppendLoadMethod(functions);
                AppendLine();
                AppendUnloadMethod(functions);
            });
            AppendLine("}");
        });
        AppendLine("}");
        return Context.GetBuiltString();
    }

    private void AppendDelegateDefinitions(ParsedFunction[] functions)
    {
        var uniqueDefinitions = new Dictionary<string, DelegateDefinitionCode>();
        foreach (var f in functions)
        {
            var definition = GetDelegateDefinitionCode(f);
            uniqueDefinitions[definition.DelegateName] = definition;
        }

        var orderedDefinitions = uniqueDefinitions.Values
            .OrderBy(d => d.DelegateName)
            .Select(d => d.Code)
            .ToArray();

        for (var i = 0; i < orderedDefinitions.Length; i++)
        {
            AppendLine(orderedDefinitions[i]);
            if (i + 1 != orderedDefinitions.Length)
            {
                AppendLine();
            }
        }
    }

    private void AppendLoadMethod(ParsedFunction[] functions)
    {
        AppendLine("private void LoadInternal()");
        AppendLine("{");
        AddIndent(() =>
        {
            foreach (var f in functions.OrderBy(f => f.Name))
            {
                var delegateName = GetDelegateNameCode(f);
                AppendLine($"{f.Name} = ({delegateName})_handler.{nameof(ILibraryHandler.GetFunctionByName)}(\"{f.Name}\", typeof({delegateName}));");
            }
        });
        AppendLine("}");
    }

    private void AppendUnloadMethod(ParsedFunction[] functions)
    {
        AppendLine("private void UnloadInternal()");
        AppendLine("{");
        AddIndent(() =>
        {
            foreach (var f in functions.OrderBy(f => f.Name))
                AppendLine($"{f.Name} = null;");
        });
        AppendLine("}");
    }
}
