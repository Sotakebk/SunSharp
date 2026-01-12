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

    public override string FilePath => PathHelper.GetProjectFilePath($"SunSharp/Modules/{FriendlyName}ModuleHandle.g.cs");

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
            GenerateInterfaceControllerGettersSetters();
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

    protected virtual void GenerateInterfaceControllerGettersSetters()
    {
        foreach (var (i, c) in ModuleDescription.Controllers)
        {
            AppendLine();
            GenerateInterfaceGetter(i, c);
            AppendLine();
            GenerateInterfaceSetter(i, c);
        }
    }

    protected virtual void GenerateInterfaceGetter(int i, ControllerDescription c)
    {
        GenerateGetterSetterXmlDoc(i, c);
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
        GenerateGetterSetterXmlDoc(i, c);
        if (c.EnumName != null)
        {
            AppendLine($"void Set{c.FriendlyName}({c.EnumName} value);");
        }
        else
        {
            AppendLine($"void Set{c.FriendlyName}(int value, {nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed});");
        }
    }

    protected virtual void GenerateGetterSetterXmlDoc(int i, ControllerDescription c)
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
        if (c.EnumName == null)
        {
            if (c.MinDisplayedValue is not null)
            {
                AppendLine($"/// Value range: displayed: {c.MinDisplayedValue}-{c.MaxDisplayedValue}, real: {c.MinValue}-{c.MaxValue}");
            }
            else
            {
                AppendLine($"/// Value range: {c.MinValue}-{c.MaxValue}");
            }
        }
        AppendLine($"/// Original name: {i} '{c.InternalName}'");
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
            GenerateModuleStructMembers();
            GenerateStructCurveWritesReads();
        });
        AppendLine("}");
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
