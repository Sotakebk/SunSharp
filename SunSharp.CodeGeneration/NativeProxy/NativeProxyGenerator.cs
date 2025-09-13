using System.Linq;
using System.Reflection;
using SunSharp.CodeGeneration.CodeGenerationTools;
using SunSharp.Native;
using SunSharp.Native.Loader;
using static SunSharp.CodeGeneration.NativeProxy.TypeNameTranslation;

namespace SunSharp.CodeGeneration.NativeProxy;

public sealed class NativeProxyGenerator : BaseGenerator
{
    private DelegateDefinition[] _delegateDefinitions = [];
    private MethodDefinition[] _methodDefinitions = [];

    private static string GetDelegateNameCode(DelegateDefinition definition)
    {
        var @out = TranslateToCapitalizedName(definition.ReturnType);
        var @in = string.Join(null, definition.Parameters.Select(static t => TranslateToCapitalizedName(t)));
        @in = @in.Length == 0 ? "Void" : @in;
        return $"Returns{@out}Takes{@in}";
    }

    private static string GetDelegateDefinitionCode(DelegateDefinition definition)
    {
        var returnType = TranslateToFriendlyName(definition.ReturnType);
        var friendlyArguments = string.Join(", ",
            definition.Parameters.Select(static (t, i) => $"{TranslateToFriendlyName(t)} arg{i + 1}"));

        return $"private delegate {returnType} {GetDelegateNameCode(definition)}({friendlyArguments});";
    }

    private static string GetMethodDefinitionCode(MethodDefinition definition)
    {
        var returnType = TranslateToFriendlyName(definition.CorrespondingDelegate.ReturnType);

        var pars = definition.MethodInfo.GetParameters()
            .Select(static p => $"{TranslateToFriendlyName(p.ParameterType)} {p.Name}")
            .ToArray();
        var joinedPars = string.Join(", ", pars);
        var forwardedPars = definition.MethodInfo.GetParameters().Select(static p => p.Name);
        var joinedForwardedPars = string.Join(", ", forwardedPars);
        return
            $"{returnType} {nameof(ISunVoxLibC)}.{definition.MethodInfo.Name}({joinedPars}) => {definition.MethodInfo.Name}?.Invoke({joinedForwardedPars}) ?? throw GetNoDelegateException();";
    }

    private static string GetDelegateForMethodDefinitionCode(MethodDefinition methodDefinition)
    {
        return
            $"private {GetDelegateNameCode(methodDefinition.CorrespondingDelegate)}? {methodDefinition.MethodInfo.Name};";
    }

    private void ReadData()
    {
        var type = typeof(ISunVoxLibC);

        _delegateDefinitions = [.. type.GetMethods()
            .Select(static m =>
                new DelegateDefinition(m.ReturnType,
                    [..
                        m.GetParameters().Select(static p => p.ParameterType)
                    ])
            )
            .DistinctBy(GetDelegateNameCode)];

        _methodDefinitions = [.. type.GetMethods()
            .Select(static m => new MethodDefinition(m,
                new DelegateDefinition(m.ReturnType,
                    [..
                        m.GetParameters().Select(static p => p.ParameterType)]
                    ))
            )
        ];
    }

    protected override string GenerateBody()
    {
        ReadData();

        AppendLineNoTab("#pragma warning disable CS0649");
        AppendLineNoTab("#nullable enable");
        AppendLine();
        AppendLine("using System;");
        AppendLine();
        AppendLine("namespace SunSharp.Native.Loader");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine($"public sealed partial class {nameof(Native.Loader.NativeProxy)} : {nameof(ISunVoxLibC)}");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("#region delegate definitions");
                AppendLine();

                foreach (var d in _delegateDefinitions.OrderBy(static d => GetDelegateNameCode(d)))
                    AppendDelegateDefinition(d);

                AppendLine("#endregion delegate definitions");
                AppendLine();
                AppendLine("#region delegates");
                AppendLine();

                foreach (var m in _methodDefinitions.OrderBy(static m => m.MethodInfo.Name))
                    AppendDelegateForMethodDefinition(m);

                AppendLine("#endregion delegates");
                AppendLine();
                AppendLine("#region interface");
                AppendLine();
                foreach (var m in _methodDefinitions.OrderBy(static m => m.MethodInfo.Name)) AppendMethodDefinition(m);

                AppendLine("#endregion interface");
                AppendLine();
                AppendLoadMethod();
                AppendLine();
                AppendUnloadMethod();
            });
            AppendLine("}");
        });
        AppendLine("}");

        return Context.GetBuiltString();
    }

    private void AppendUnloadMethod()
    {
        AppendLine("private void UnloadInternal()");
        AppendLine("{");
        AddIndent(() =>
        {
            foreach (var methodDefinition in _methodDefinitions.OrderBy(static m => m.MethodInfo.Name))
                AppendLine($"{methodDefinition.MethodInfo.Name} = null;");
        });
        AppendLine("}");
    }

    private void AppendLoadMethod()
    {
        AppendLine("private void LoadInternal()");
        AppendLine("{");
        AddIndent(() =>
        {
            foreach (var methodDefinition in _methodDefinitions.OrderBy(static m => m.MethodInfo.Name))
            {
                var name = methodDefinition.MethodInfo.Name;
                var delegateName = GetDelegateNameCode(methodDefinition.CorrespondingDelegate);
                AppendLine(
                    $"{name} = ({delegateName})_handler.{nameof(ILibraryHandler.GetFunctionByName)}(\"{name}\", typeof({delegateName}));");
            }
        });
        AppendLine("}");
    }

    private void AppendMethodDefinition(MethodDefinition methodDefinition)
    {
        AppendLine(GetMethodDefinitionCode(methodDefinition));
        AppendLine();
    }

    private void AppendDelegateForMethodDefinition(MethodDefinition methodDefinition)
    {
        AppendLine(GetDelegateForMethodDefinitionCode(methodDefinition));
        AppendLine();
    }

    private void AppendDelegateDefinition(DelegateDefinition delegateDefinition)
    {
        AppendLine(GetDelegateDefinitionCode(delegateDefinition));
        AppendLine();
    }

    private record DelegateDefinition(Type ReturnType, Type[] Parameters);

    private record MethodDefinition(MethodInfo MethodInfo, DelegateDefinition CorrespondingDelegate);
}
