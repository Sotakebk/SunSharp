using CodeGeneration.Logic;
using SunSharp;

namespace CodeGeneration.Generators.ModuleHandles;

public class FmxModuleGenerator : BasicModuleGenerator
{
    public FmxModuleGenerator(string internalName, KnownModuleData moduleData)
        : base(internalName, moduleData)
    {
    }

    private record GroupedControllerInfo(int firstIndex, string Name);

    private static readonly GroupedControllerInfo[] _groupedControllers = new[]
    {
        new GroupedControllerInfo(9, "Volume"),
        new GroupedControllerInfo(14,"Attack"),
        new GroupedControllerInfo(19,"Decay"),
        new GroupedControllerInfo(24,"SustainLevel"),
        new GroupedControllerInfo(29,"Release"),
        new GroupedControllerInfo(34,"AttackCurve"),
        new GroupedControllerInfo(39,"DecayCurve"),
        new GroupedControllerInfo(44,"ReleaseCurve"),
        new GroupedControllerInfo(49,"Sustain"),
        new GroupedControllerInfo(54,"SustainPedal"),
        new GroupedControllerInfo(59,"EnvelopeScalingPerKey"),
        new GroupedControllerInfo(64,"VolumeScalingPerKey"),
        new GroupedControllerInfo(69,"VelocitySensitivity"),
        new GroupedControllerInfo(74,"Waveform"),
        new GroupedControllerInfo(79,"Noise"),
        new GroupedControllerInfo(84,"Phase"),
        new GroupedControllerInfo(89,"FrequencyMultiply"),
        new GroupedControllerInfo(94,"ConstantPitch"),
        new GroupedControllerInfo(99,"SelfModulation"),
        new GroupedControllerInfo(104,"Feedback"),
        new GroupedControllerInfo(109,"ModulationType"),
    };

    protected override void GenerateInterfaceControllerGettersSettersEvents()
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
            AppendLine();
            GenerateInterfaceMakeEvent(i, c);
        }

        foreach(var group in _groupedControllers)
        {
            AppendLine();
            GenerateInterfaceGroupedGetter(group.firstIndex, group.Name);
            AppendLine();
            GenerateInterfaceGroupedSetter(group.firstIndex, group.Name);
            AppendLine();
            GenerateInterfaceGroupedMakeEvent(group.firstIndex, group.Name);
        }
    }

    private void GenerateInterfaceGroupedMakeEvent(int firstIndex, string name)
    {
        var c = ModuleDescription.Controllers[firstIndex];
        GenerateGroupedXmlDoc(firstIndex, name, c, isSetter: false, isEvent: true);
        
        if (c.EnumName != null)
        {
            AppendLine($"{nameof(PatternEvent)} Make{name}Event(int index, {c.EnumName} value);");
        }
        else
        {
            AppendLine($"{nameof(PatternEvent)} Make{name}Event(int index, int value);");
        }
    }

    private void GenerateInterfaceGroupedSetter(int firstIndex, string name)
    {
        var c = ModuleDescription.Controllers[firstIndex];
        GenerateGroupedXmlDoc(firstIndex, name, c, isSetter: true, isEvent: false);
        
        if (c.EnumName != null)
        {
            AppendLine($"void Set{name}(int index, {c.EnumName} value);");
        }
        else
        {
            AppendLine($"void Set{name}(int index, int value, {nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed});");
        }
    }
    private void GenerateInterfaceGroupedGetter(int firstIndex, string name)
    {
        var c = ModuleDescription.Controllers[firstIndex];
        GenerateGroupedXmlDoc(firstIndex, name, c, isSetter: false, isEvent: false);
        
        if (c.EnumName != null)
        {
            AppendLine($"{c.EnumName} Get{name}(int index);");
        }
        else
        {
            AppendLine($"int Get{name}(int index, {nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed});");
        }
    }

    private void GenerateGroupedXmlDoc(int firstIndex, string name, ControllerDescription c, bool isSetter, bool isEvent)
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
                    AppendLine("/// <br/>");
                }
            }
            AppendLine("/// <br/>");
        }
        AppendLine($"/// This method accesses one of 5 grouped controllers starting at controller {firstIndex}.");
        AppendLine("/// <br/>");
        if (c.ControllerType == ControllerType.Normal)
        {
            AppendLine($"/// Value range: displayed: {c.MinDisplayedValue} to {c.MaxDisplayedValue}, real: {c.MinValue} to {c.MaxValue}");
        }
        AppendLine($"/// Original name pattern: {firstIndex}-{firstIndex + 4} '{c.InternalName}'");
        if (isSetter || isEvent)
        {
            AppendLine($"/// Note: equivalent <see cref=\"{nameof(IVirtualPattern)}.{nameof(IVirtualPattern.SendEvent)}\"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.");
        }
        AppendLine("/// </summary>");
        AppendLine("/// <param name=\"index\">Index of the controller in the group (0-4)</param>");
    }

    private void GenerateIndexValidation()
    {
        AppendLine("if (index < 0 || index > 4)");
        AppendLine("{");
        AddIndent(() =>
        {
            AppendLine($"throw new {nameof(ArgumentOutOfRangeException)}(nameof(index));");
        });
        AppendLine("}");
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
            AppendLine();
            GenerateStructMakeEvent(i, c);
        }

        foreach (var group in _groupedControllers)
        {
            AppendLine();
            GenerateStructGroupedGetter(group.firstIndex, group.Name);
            AppendLine();
            GenerateStructGroupedSetter(group.firstIndex, group.Name);
            AppendLine();
            GenerateStructGroupedMakeEvent(group.firstIndex, group.Name);
        }
    }

    private void GenerateStructGroupedMakeEvent(int firstIndex, string name)
    {
        var c = ModuleDescription.Controllers[firstIndex];
        AppendLine($"/// <inheritdoc cref=\"{InterfaceName}.Make{name}Event\" />");
        
        if (c.EnumName != null)
        {
            AppendLine($"public {nameof(PatternEvent)} Make{name}Event(int index, {c.EnumName} value)");
            AppendLine("{");
            AddIndent(() =>
            {
                if (c.MinValue != 0 || c.MinDisplayedValue != 0 || c.Offset != 0 || c.MinValue != c.MinDisplayedValue)
                {
                    throw new Exception("Assumption about enum-controller values was violated.");
                }
                GenerateIndexValidation();
                AppendLine($"return {nameof(PatternEvent)}.{nameof(PatternEvent.ControllerEvent)}(ModuleHandle.{nameof(SynthModuleHandle.Id)}, (byte)({firstIndex} + index), (ushort)Math.Clamp((int)value, 0, 0x8000));");
            });
            AppendLine("}");
        }
        else
        {
            AppendLine($"public {nameof(PatternEvent)} Make{name}Event(int index, int value)");
            AppendLine("{");
            AddIndent(() =>
            {
                GenerateIndexValidation();
                if (c.ControllerType == ControllerType.Selector)
                {
                    AppendLine($"return {nameof(PatternEvent)}.{nameof(PatternEvent.ControllerEvent)}(ModuleHandle.{nameof(SynthModuleHandle.Id)}, (byte)({firstIndex} + index), (ushort)Math.Clamp(value, 0, 0x8000));");
                    return;
                }
                if (c.Offset != 0)
                {
                    AppendLine($"value -= {c.Offset};");
                }
                if (c.MinValue != 0)
                {
                    AppendLine($"value -= {c.MinValue};");
                }
                AppendLine($"value = value * 0x8000 / ({c.MaxValue - c.MinValue});");
                AppendLine($"return {nameof(PatternEvent)}.{nameof(PatternEvent.ControllerEvent)}(ModuleHandle.{nameof(SynthModuleHandle.Id)}, (byte)({firstIndex} + index), (ushort)Math.Clamp(value, 0, 0x8000));");
            });
            AppendLine("}");
        }
    }
    private void GenerateStructGroupedSetter(int firstIndex, string name)
    {
        var c = ModuleDescription.Controllers[firstIndex];
        AppendLine($"/// <inheritdoc cref=\"{InterfaceName}.Set{name}\" />");
        
        if (c.EnumName != null)
        {
            AppendLine($"public void Set{name}(int index, {c.EnumName} value)");
            AppendLine("{");
            AddIndent(() =>
            {
                GenerateIndexValidation();
                AppendLine($"ModuleHandle.SetControllerValue((byte)({firstIndex} + index), (int)value, {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed});");
            });
            AppendLine("}");
        }
        else
        {
            AppendLine($"public void Set{name}(int index, int value, {nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed})");
            AppendLine("{");
            AddIndent(() =>
            {
                GenerateIndexValidation();
                AppendLine($"ModuleHandle.SetControllerValue((byte)({firstIndex} + index), value, valueScalingMode);");
            });
            AppendLine("}");
        }
    }
    private void GenerateStructGroupedGetter(int firstIndex, string name)
    {
        var c = ModuleDescription.Controllers[firstIndex];
        AppendLine($"/// <inheritdoc cref=\"{InterfaceName}.Get{name}\" />");
        
        if (c.EnumName != null)
        {
            AppendLine($"public {c.EnumName} Get{name}(int index)");
            AppendLine("{");
            AddIndent(() =>
            {
                GenerateIndexValidation();
                AppendLine($"return ({c.EnumName})ModuleHandle.GetControllerValue((byte)({firstIndex} + index), ValueScalingMode.Displayed);");
            });
            AppendLine("}");
        }
        else
        {
            AppendLine($"public int Get{name}(int index, {nameof(ValueScalingMode)} valueScalingMode = {nameof(ValueScalingMode)}.{ValueScalingMode.Displayed})");
            AppendLine("{");
            AddIndent(() =>
            {
                GenerateIndexValidation();
                AppendLine($"return ModuleHandle.GetControllerValue((byte)({firstIndex} + index), valueScalingMode);");
            });
            AppendLine("}");
        }
    }
}
