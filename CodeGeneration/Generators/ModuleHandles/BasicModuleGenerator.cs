using CodeGeneration.Logic;
using SunSharp;
using SunSharp.Modules;

namespace CodeGeneration.Generators.ModuleHandles;

public class BasicModuleGenerator : BaseGenerator
{
    protected readonly ModuleDescription ModuleDescription;
    protected readonly KnownModuleType KnownModuleType;
    protected readonly string FriendlyName;
    protected readonly string InterfaceName;
    protected readonly string StructName;

    public override string FilePath => PathHelper.GetProjectFilePath($"SunSharp/Modules/g/{FriendlyName}ModuleHandle.g.cs");

    public override string Name => $"{FriendlyName}ModuleHandle.g.cs";

    public BasicModuleGenerator(string internalName, KnownModuleData moduleData)
    {
        ModuleDescription = moduleData.Modules[internalName];
        KnownModuleType = KnownModuleTypes.GetKnownModuleType(internalName)
            ?? throw new();
        FriendlyName = KnownModuleType.FriendlyName;
        InterfaceName = $"I{KnownModuleType.FriendlyName}ModuleHandle";
        StructName = $"{KnownModuleType.FriendlyName}ModuleHandle";
    }

    protected override string GenerateBody()
    {
        var moduleData = ModuleDataLoader.LoadFromFile(PathHelper.GetProjectFilePath("CodeGeneration/Logic/ModuleData.g.json"));

        CodeGenerationHelper.AppendHeader(Context);
        AppendLine("#if !GENERATION");
        AppendLine();
        AppendLine("using System;");
        AppendLine();
        AppendLine("namespace SunSharp.Modules");
        AppendLine("{");
        AddIndent(() =>
        {
            GenerateModuleInterfaceCode();
            AppendLine();
            GenerateModuleStructCode();
        });
        AppendLine("}");
        AppendLine("#endif");
        return Context.GetBuiltString();
    }

    protected virtual void GenerateModuleInterfaceCode()
    {
        if (KnownModuleType.Description is not null)
        {
            AppendLine("/// <summary>");
            AppendLine($"/// {KnownModuleType.Description}");
            AppendLine("/// </summary>");
        }
        AppendLine($"public partial interface {InterfaceName} : {nameof(ITypedModuleHandle)}");
        AppendLine("{");
        AddIndent(() =>
        {
            GenerateInterfaceControllerGettersSettersEvents();
            GenerateInterfaceCurveWritesReads();
        });
        AppendLine("}");
    }

    protected virtual void GenerateInterfaceCurveWritesReads()
    {
        if (ModuleDescription.Curves.Count == 0)
        {
            return;
        }
        foreach (var (i, c) in ModuleDescription.Curves)
        {
            AppendLine();
            GenerateInterfaceCurveWrite(i, c);
            AppendLine();
            GenerateInterfaceCurveRead(i, c);
        }
    }

    protected virtual void GenerateInterfaceCurveRead(int i, CurveDescription c)
    {
        GenerateInterfaceCurveXmlDoc(i, c, false);
        AppendLine($"int ReadCurve{c.FriendlyName}(float[] buffer);");
    }

    protected virtual void GenerateInterfaceCurveWrite(int i, CurveDescription c)
    {
        GenerateInterfaceCurveXmlDoc(i, c, true);
        AppendLine($"int WriteCurve{c.FriendlyName}(float[] buffer);");
    }

    protected virtual void GenerateInterfaceCurveXmlDoc(int i, CurveDescription c, bool write)
    {
        AppendLine("/// <summary>");
        if (c.Description != null)
        {
            var descriptionLines = c.Description.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
            for (int l = 0; l < descriptionLines.Length; l++)
            {
                var line = descriptionLines[l];
                AppendLine($"/// {line}");
                if (l == descriptionLines.Length - 1)
                {
                    AppendLine("/// <br>");
                }
            }
        }
        if (write)
        {
            AppendLine($"/// <br> Write to curve {i} of {FriendlyName}.");
        }
        else
        {
            AppendLine($"/// <br> Read from curve {i} of {FriendlyName}.");
        }
        AppendLine($"/// <br> The curve contains {c.Size} values in range of {c.MinValue} to {c.MaxValue}.");
        AppendLine("/// </summary>");
    }

    protected virtual void GenerateInterfaceControllerGettersSettersEvents()
    {
        foreach (var (i, c) in ModuleDescription.Controllers)
        {
            AppendLine();
            GenerateInterfaceGetter(i, c);
            AppendLine();
            GenerateInterfaceSetter(i, c);
            AppendLine();
            GenerateInterfaceMakeEvent(i, c);
        }
    }

    protected virtual void GenerateInterfaceMakeEvent(int i, ControllerDescription c)
    {
        GenerateMakeEventXmlDoc(i, c);
        if (c.EnumName != null)
        {
            AppendLine($"{nameof(PatternEvent)} Make{c.FriendlyName}Event({c.EnumName} value);");
        }
        else
        {
            AppendLine($"{nameof(PatternEvent)} Make{c.FriendlyName}Event(int value);");
        }
    }

    private void GenerateMakeEventXmlDoc(int i, ControllerDescription c)
    {
        AppendLine("/// <summary>");
        if (c.Description is not null)
        {
            var descriptionLines = c.Description.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
            for (int l = 0; l < descriptionLines.Length; l++)
            {
                var line = descriptionLines[l];
                AppendLine($"/// {line}");
                if (l == descriptionLines.Length - 1)
                {
                    AppendLine("/// <br>");
                }
            }
        }
        AppendLine($"/// <para>This is a helper method to automatically handle turning target controller values into column values.</para>");
        if (c.ControllerType == ControllerType.Selector)
        {
            AppendLine($"/// <para>For this controller the input value is taken as is, only clamped to column value range.</para>");
        }
        else
        {
            AppendLine($"/// <para>For this controller the input value is mapped from displayed range ({c.MinDisplayedValue} to {c.MaxDisplayedValue}) to column range (0 to 0x8000). Out of range values are clamped.</para>");
        }
        AppendLine("/// </summary>");
    }

    protected virtual void GenerateInterfaceGetter(int i, ControllerDescription c)
    {
        GenerateGetterSetterXmlDoc(i, c, false);
        if (c.EnumName != null)
        {
            AppendLine($"{c.EnumName} Get{c.FriendlyName}();");
        }
        else
        {
            AppendLine($"int Get{c.FriendlyName}({nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed});");
        }
    }

    protected virtual void GenerateInterfaceSetter(int i, ControllerDescription c)
    {
        GenerateGetterSetterXmlDoc(i, c, true);
        if (c.EnumName != null)
        {
            AppendLine($"void Set{c.FriendlyName}({c.EnumName} value);");
        }
        else
        {
            AppendLine($"void Set{c.FriendlyName}(int value, {nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed});");
        }
    }

    protected virtual void GenerateGetterSetterXmlDoc(int i, ControllerDescription c, bool setter)
    {
        AppendLine("/// <summary>");
        if (c.Description is not null)
        {
            var descriptionLines = c.Description.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
            for (int l = 0; l < descriptionLines.Length; l++)
            {
                var line = descriptionLines[l];
                AppendLine($"/// {line}");
                if (l == descriptionLines.Length - 1)
                {
                    AppendLine("/// <br>");
                }
            }
        }
        if (c.ControllerType == ControllerType.Normal)
        {
            AppendLine($"/// Value range: displayed: {c.MinDisplayedValue} to {c.MaxDisplayedValue}, real: {c.MinValue} to {c.MaxValue}");
        }
        AppendLine($"/// Original name: {i} '{c.InternalName}'");
        if (setter)
        {
            AppendLine($"/// Note: equivalent <see cref=\"{nameof(IVirtualPattern)}.{nameof(IVirtualPattern.SendEvent)}\"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.");
        }
        AppendLine("/// </summary>");
    }

    public virtual void GenerateModuleStructCode()
    {
        AppendLine($"/// <inheritdoc cref=\"{InterfaceName}\"/>");
        AppendLine($"public readonly partial struct {StructName} : {InterfaceName}");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine("public SynthModuleHandle ModuleHandle { get; }");
            AppendLine();

            AppendLine($"public {StructName}({nameof(SynthModuleHandle)} moduleHandle)");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("ModuleHandle = moduleHandle;");
            });
            AppendLine("}");
            GenerateOperatorsAndStuff();
            GenerateGenericSynthModuleHandleImplementation();
            GenerateModuleStructMembers();
            GenerateStructCurveWritesReads();
        });
        AppendLine("}");
    }

    protected virtual void GenerateGenericSynthModuleHandleImplementation()
    {
        AppendLine();
        AppendLine("#region IGenericSynthModuleHandle implementation");
        AppendLine();

        var interfaceType = typeof(IGenericSynthModuleHandle);
        var nullabilityContext = new System.Reflection.NullabilityInfoContext();

        foreach (var property in interfaceType.GetProperties())
        {
            var nullabilityInfo = nullabilityContext.Create(property);
            var returnType = CodeGenerationHelper.GetTypeName(property.PropertyType, nullabilityInfo);
            AppendLine($"public {returnType} {property.Name} => ModuleHandle.{property.Name};");
            AppendLine();
        }

        var methodImplementations = BuildMethodImplementationDescriptors();

        foreach (var impl in methodImplementations)
        {
            GenerateMethodImplementation(impl);
        }

        AppendLine("#endregion");
    }

    private record MethodImplementationDescriptor(
        System.Reflection.MethodInfo Method,
        bool IsExplicitInterfaceImplementation,
        bool RequiresCastToInterface,
        string? InheritDocTarget = null
    )
    {
        private System.Reflection.NullabilityInfoContext? _nullabilityContext;

        public System.Reflection.NullabilityInfoContext NullabilityContext =>
            _nullabilityContext ??= new System.Reflection.NullabilityInfoContext();
    };

    private List<MethodImplementationDescriptor> BuildMethodImplementationDescriptors()
    {
        var descriptors = new List<MethodImplementationDescriptor>();
        var interfaceType = typeof(IGenericSynthModuleHandle);

        var additionalOverloads = GetAdditionalMethodOverloads();
        var collidingMethodNames = new HashSet<string>(additionalOverloads.Select(o => o.MethodName));

        foreach (var method in interfaceType.GetMethods().Where(m => !m.IsSpecialName))
        {
            var parameters = method.GetParameters();
            var parameterTypes = parameters.Select(p => p.ParameterType).ToArray();

            var matchingOnStruct = typeof(SynthModuleHandle).GetMethod(method.Name, parameterTypes);
            bool requiresCast = matchingOnStruct == null || matchingOnStruct.ReturnType != method.ReturnType;

            bool hasCollision = collidingMethodNames.Contains(method.Name);

            descriptors.Add(new MethodImplementationDescriptor(
                Method: method,
                IsExplicitInterfaceImplementation: hasCollision,
                RequiresCastToInterface: requiresCast
            ));
        }

        foreach (var (methodName, parameterTypes) in additionalOverloads)
        {
            var method = typeof(SynthModuleHandle).GetMethod(methodName, parameterTypes);
            if (method == null)
            {
                throw new InvalidOperationException($"Method {methodName} with specified parameters not found on {nameof(SynthModuleHandle)}");
            }

            descriptors.Add(new MethodImplementationDescriptor(
                Method: method,
                IsExplicitInterfaceImplementation: false,
                RequiresCastToInterface: false,
                InheritDocTarget: $"{nameof(SynthModuleHandle)}.{methodName}"
            ));
        }

        return descriptors;
    }

    private (string MethodName, Type[] ParameterTypes)[] GetAdditionalMethodOverloads()
    {
        return
        [
            (nameof(SynthModuleHandle.GetInputModules), []),
            (nameof(SynthModuleHandle.GetOutputModules), []),
            (nameof(SynthModuleHandle.ConnectInput), [typeof(SynthModuleHandle)]),
            (nameof(SynthModuleHandle.ConnectOutput), [typeof(SynthModuleHandle)]),
            (nameof(SynthModuleHandle.DisconnectInput), [typeof(SynthModuleHandle)]),
            (nameof(SynthModuleHandle.DisconnectOutput), [typeof(SynthModuleHandle)])
        ];
    }

    private void GenerateMethodImplementation(MethodImplementationDescriptor descriptor)
    {
        var method = descriptor.Method;
        var returnNullability = descriptor.NullabilityContext.Create(method.ReturnParameter);
        var returnType = CodeGenerationHelper.GetTypeName(method.ReturnType, returnNullability);
        var parameters = method.GetParameters();
        var paramList = string.Join(", ", parameters.Select(p =>
        {
            var paramNullability = descriptor.NullabilityContext.Create(p);
            var paramType = CodeGenerationHelper.GetTypeName(p.ParameterType, paramNullability);
            var paramDecl = $"{paramType} {p.Name}";

            if (p.HasDefaultValue)
            {
                paramDecl += $" = {CodeGenerationHelper.FormatDefaultValue(p.DefaultValue, p.ParameterType)}";
            }

            return paramDecl;
        }));
        var argList = string.Join(", ", parameters.Select(p => p.Name));

        if (descriptor.InheritDocTarget != null)
        {
            AppendLine($"/// <inheritdoc cref=\"{descriptor.InheritDocTarget}\"/>");
        }
        else
        {
            AppendLine($"/// <inheritdoc/>");
        }

        if (descriptor.IsExplicitInterfaceImplementation)
        {
            if (descriptor.RequiresCastToInterface)
            {
                AppendLine($"{returnType} {nameof(IGenericSynthModuleHandle)}.{method.Name}({paramList}) => (ModuleHandle as {nameof(IGenericSynthModuleHandle)}).{method.Name}({argList});");
            }
            else
            {
                AppendLine($"{returnType} {nameof(IGenericSynthModuleHandle)}.{method.Name}({paramList}) => ModuleHandle.{method.Name}({argList});");
            }
        }
        else
        {
            if (descriptor.RequiresCastToInterface)
            {
                AppendLine($"public {returnType} {method.Name}({paramList}) => (ModuleHandle as {nameof(IGenericSynthModuleHandle)}).{method.Name}({argList});");
            }
            else
            {
                AppendLine($"public {returnType} {method.Name}({paramList}) => ModuleHandle.{method.Name}({argList});");
            }
        }
        AppendLine();
    }

    protected virtual void GenerateStructCurveWritesReads()
    {
        if (ModuleDescription.Curves.Count == 0)
        {
            return;
        }
        foreach (var (i, c) in ModuleDescription.Curves)
        {
            AppendLine();
            AppendLine($"/// <inheritdoc cref=\"{InterfaceName}.ReadCurve{c.FriendlyName}\"");
            AppendLine($"public int ReadCurve{c.FriendlyName}(float[] buffer) => ModuleHandle.ReadCurve({i}, buffer);");
            AppendLine();
            AppendLine($"/// <inheritdoc cref=\"{InterfaceName}.WriteCurve{c.FriendlyName}\"");
            AppendLine($"public int WriteCurve{c.FriendlyName}(float[] buffer) => ModuleHandle.WriteCurve({i}, buffer);");
        }
    }

    protected virtual void GenerateOperatorsAndStuff()
    {
        AppendLine("");
        AppendLine($"public static implicit operator {nameof(SynthModuleHandle)}({StructName} handle)");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine("return handle.ModuleHandle;");
        });
        AppendLine("}");
        AppendLine("");
        AppendLine("/// <inheritdoc/>");
        AppendLine($"public bool IsCorrectHandleType()");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine($"return ModuleHandle.GetModuleType() == {nameof(SynthModuleType)}.{FriendlyName};");
        });
        AppendLine("}");
        AppendLine("");
        AppendLine("/// <inheritdoc/>");
        AppendLine($"public void AssertCorrectHandleType()");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine($"const {nameof(SynthModuleType)} expected = {nameof(SynthModuleType)}.{FriendlyName};");
            AppendLine($"var actual = ModuleHandle.GetModuleType();");
            AppendLine("if(actual != expected)");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine($"throw new {nameof(IncorrectSynthHandleTypeException)}(expected, actual);");
            });
            AppendLine("}");
        });
        AppendLine("}");
    }

    protected virtual void GenerateModuleStructMembers()
    {
        GenerateModuleControllerGettersSetters();
    }

    protected virtual void GenerateModuleControllerGettersSetters()
    {
        foreach (var (i, c) in ModuleDescription.Controllers)
        {
            AppendLine();
            GenerateStructGetter(i, c);
            AppendLine();
            GenerateStructSetter(i, c);
            AppendLine();
            GenerateStructMakeEvent(i, c);
        }
    }

    protected virtual void GenerateStructMakeEvent(int i, ControllerDescription c)
    {
        AppendLine($"/// <inheritdoc cref=\"{InterfaceName}.Make{c.FriendlyName}Event\" />");
        if (c.EnumName != null)
        {
            AppendLine($"public {nameof(PatternEvent)} Make{c.FriendlyName}Event({c.EnumName} value)");
            AppendLine("{");
            AddIndent(() =>
            {
                if (c.MinValue != 0 || c.MinDisplayedValue != 0 || c.Offset != 0 || c.MinValue != c.MinDisplayedValue)
                {
                    throw new Exception("Assumption about enum-controller values was violated.");
                }
                AppendLine($"return {nameof(PatternEvent)}.{nameof(PatternEvent.ControllerEvent)}(ModuleHandle.{nameof(SynthModuleHandle.Id)}, {i}, (ushort)Math.Clamp((int)value, 0, 0x8000));");
            });
            AppendLine("}");
        }
        else
        {
            AppendLine($"public {nameof(PatternEvent)} Make{c.FriendlyName}Event(int value)");
            AppendLine("{");
            AddIndent(() =>
            {
                if (c.ControllerType == ControllerType.Selector)
                {
                    // value can be set as is
                    // note: min may not be 0, but it's fine
                    AppendLine($"return {nameof(PatternEvent)}.{nameof(PatternEvent.ControllerEvent)}(ModuleHandle.{nameof(SynthModuleHandle.Id)}, {i}, (ushort)Math.Clamp(value, 0, 0x8000));");
                    return;
                }
                // follow the code from the library
                if (c.Offset != 0)
                {
                    AppendLine($"value -= {c.Offset};");
                }
                if (c.MinValue != 0)
                {
                    AppendLine($"value -= {c.MinValue};");
                }
                AppendLine($"value = value * 0x8000 / ({c.MaxValue - c.MinValue});");

                AppendLine($"return {nameof(PatternEvent)}.{nameof(PatternEvent.ControllerEvent)}(ModuleHandle.{nameof(SynthModuleHandle.Id)}, {i}, (ushort)Math.Clamp(value, 0, 0x8000));");
            });
            AppendLine("}");
        }
    }

    protected virtual void GenerateStructGetter(int i, ControllerDescription c)
    {
        AppendLine($"/// <inheritdoc cref=\"{InterfaceName}.Get{c.FriendlyName}\" />");
        if (c.EnumName != null)
        {
            AppendLine($"public {c.EnumName} Get{c.FriendlyName}() => ({c.EnumName})ModuleHandle.GetControllerValue({i}, ValueScalingMode.Displayed);");
        }
        else
        {
            AppendLine($"public int Get{c.FriendlyName}({nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed}) => ModuleHandle.GetControllerValue({i}, valueScalingMode);");
        }
    }

    protected virtual void GenerateStructSetter(int i, ControllerDescription c)
    {
        AppendLine($"/// <inheritdoc cref=\"{InterfaceName}.Set{c.FriendlyName}\" />");
        if (c.EnumName != null)
        {
            AppendLine($"public void Set{c.FriendlyName}({c.EnumName} value) => ModuleHandle.SetControllerValue({i}, (int)value, {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed});");
        }
        else
        {
            AppendLine($"public void Set{c.FriendlyName}(int value, {nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed}) => ModuleHandle.SetControllerValue({i}, value, valueScalingMode);");
        }
    }
}
