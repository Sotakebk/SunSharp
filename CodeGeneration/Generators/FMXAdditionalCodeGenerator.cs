using CodeGeneration.ReparsedData;
using SunSharp;

namespace CodeGeneration.Generators
{
    internal class FMXAdditionalCodeGenerator : AdditionalGenerator
    {
        private const int SubGeneratorStart = 1;
        private const int SubGeneratorEnd = 5;

        public override void AppendCode()
        {
            var methods = new string[]
            {
                "Volume",
                "Attack",
                "Decay",
                "SustainLevel",
                "Release",
                "AttackCurve",
                "DecayCurve",
                "ReleaseCurve",
                "Sustain",
                "SustainPedal",
                "EnvelopeScalingPerKey",
                "VolumeScalingPerKey",
                "VelocitySensitivity",
                "Waveform",
                "Noise",
                "Phase",
                "FreqMultiply",
                "ConstantPitch",
                "SelfModulation",
                "Feedback",
                "ModulationType",
            };

            foreach (var method in methods)
            {
                var module = Data.Modules.First(m => m.FriendlyName == "FMX");
                var originalController = module.Controllers.First(c => c.FriendlyName.StartsWith(method)
                                                                       && c.FriendlyName.EndsWith(
                                                                           $"{SubGeneratorStart}"));
                AppendGroupMethod(method, originalController);
            }
        }

        private void AppendGroupMethod(string name, CtlDesc c)
        {
            if (!string.IsNullOrWhiteSpace(c.EnumTypeName))
            {
                // ENUM
                var @enum = Data.Enums.First(e => e.Name == c.EnumTypeName);

                AppendLine("/// <summary>");
                AppendLine($"/// <para> index range: {SubGeneratorStart} to {SubGeneratorEnd} </para>");
                AppendLine(
                    $"/// <para> Possible values: {string.Join(", ", @enum.Values.Select(v => v.name))} </para>");
                AppendLine("/// </summary>");

                AppendLine($"public {@enum.Name} Get{name}(int index)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine($"if (index < {SubGeneratorStart} || index > {SubGeneratorEnd})");
                    AddIndent(() => AppendLine("throw new System.ArgumentOutOfRangeException(nameof(index));"));
                    AppendLine();
                    AppendLine(
                        $"return ({@enum.Name})ModuleHandle.GetControllerValue({c.Id} + index - 1, {nameof(ValueScalingType)}.{ValueScalingType.Displayed});");
                });
                AppendLine("}");
                AppendLine();

                AppendLine("/// <summary>");
                AppendLine($"/// <para> index range: {SubGeneratorStart} to {SubGeneratorEnd} </para>");
                AppendLine(
                    $"/// <para> Possible values: {string.Join(", ", @enum.Values.Select(v => v.name))} </para>");
                AppendLine("/// </summary>");

                AppendLine($"public void Set{name}(int index, {@enum.Name} value)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine($"if (index < {SubGeneratorStart} || index > {SubGeneratorEnd})");
                    AddIndent(() => AppendLine("throw new System.ArgumentOutOfRangeException(nameof(index));"));
                    AppendLine();
                    AppendLine(
                        $"ModuleHandle.SetControllerValue({c.Id} + index - 1, (int)value, {nameof(ValueScalingType)}.{ValueScalingType.Displayed});");
                });
                AppendLine("}");
                AppendLine();
            }
            else
            {
                // REAL
                AppendLine("/// <summary>");
                AppendLine($"/// <para> index range: {SubGeneratorStart} to {SubGeneratorEnd} </para>");
                AppendLine($"/// <para> Value range: {c.MinValue} to {c.MaxValue} </para>");
                AppendLine("/// </summary>");

                AppendLine($"public int Get{name}(int index)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine($"if (index < {SubGeneratorStart} || index > {SubGeneratorEnd})");
                    AddIndent(() => AppendLine("throw new System.ArgumentOutOfRangeException(nameof(index));"));
                    AppendLine();
                    AppendLine(
                        $"return ModuleHandle.GetControllerValue({c.Id} + index - 1, {nameof(ValueScalingType)}.{ValueScalingType.Displayed});");
                });
                AppendLine("}");
                AppendLine();

                AppendLine("/// <summary>");
                AppendLine($"/// <para> index range: {SubGeneratorStart} to {SubGeneratorEnd} </para>");
                AppendLine($"/// <para> Value range: {c.MinValue} to {c.MaxValue} </para>");
                AppendLine("/// </summary>");

                AppendLine($"public void Set{name}(int index, int value)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine($"if (index < {SubGeneratorStart} || index > {SubGeneratorEnd})");
                    AddIndent(() => AppendLine("throw new System.ArgumentOutOfRangeException(nameof(index));"));
                    AppendLine();
                    AppendLine(
                        $"ModuleHandle.SetControllerValue({c.Id} + index - 1, value, {nameof(ValueScalingType)}.{ValueScalingType.Displayed});");
                });
                AppendLine("}");
                AppendLine();
            }
        }
    }
}
