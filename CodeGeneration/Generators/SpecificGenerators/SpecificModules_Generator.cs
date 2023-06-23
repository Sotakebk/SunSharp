using CodeGeneration.ReparsedData;
using SunSharp;
using SunSharp.ObjectWrapper.Modules;

namespace CodeGeneration.Generators.SpecificGenerators
{
    internal class SpecificModules_Generator : BaseGenerator
    {
        private Data _data;

        public SpecificModules_Generator(Data data)
        {
            _data = data;
        }

        protected override void GenerateBody()
        {
            AppendLine("/*");
            AppendLine(" * IMPORTANT!");
            AppendLine(
                " * Do not modify this file manually. It was generated automatically by the CodeGeneration project.");
            AppendLine("*/");
            AppendLine();
            AppendLine("namespace SunSharp.ObjectWrapper.Modules");
            AppendLine("{");
            AddIndent(() =>
            {
                GenerateEnums();
                AppendLine();
                GenerateExtensions();
                AppendLine();
                GenerateStructs();
            });

            AppendLine("}");
        }

        private void GenerateEnums()
        {
            AppendLine("#region enums");
            var enums = _data.Enums.OrderBy(e => e.Name).ToArray();
            for (int i = 0; i < enums.Length; i++)
            {
                AppendLine();
                var @enum = enums[i];
                AppendLine($"public enum {@enum.Name} : ushort");
                AppendLine("{");
                AddIndent(() =>
                {
                    foreach (var value in @enum.Values)
                    {
                        AppendLine($"{value.name} = {value.value},");
                    }
                });
                AppendLine("}");
            }

            AppendLine();
            AppendLine("#endregion enums");
        }

        private void GenerateExtensions()
        {
            AppendLine("public static class ModuleExtensions");
            AppendLine("{");
            AddIndent(() =>
            {
                var modules = _data.Modules.OrderBy(m => m.FriendlyName).ToArray();
                for (int i = 0; i < modules.Length; i++)
                {
                    var module = modules[i];
                    AppendLine(
                        $"public static {module.FriendlyName}ModuleHandle As{module.FriendlyName}(this ModuleHandle module) => new {module.FriendlyName}ModuleHandle(module);");

                    if (i != modules.Length - 1)
                        AppendLine();
                }
            });
            AppendLine("}");
        }

        private void GenerateStructs()
        {
            var modules = _data.Modules.OrderBy(m => m.FriendlyName).ToArray();
            for (var i = 0; i < modules.Length; i++)
            {
                var m = modules[i];

                AppendLine($"public struct {m.FriendlyName}ModuleHandle : {nameof(IModuleHandleWrapper)}");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine("public ModuleHandle ModuleHandle { get; private set; }");
                    AppendLine();
                    AppendLine($"public {m.FriendlyName}ModuleHandle(ModuleHandle module)");
                    AppendLine("{");
                    AddIndent(() => { AppendLine("ModuleHandle = module;"); });
                    AppendLine("}");

                    AppendLine();
                    GenerateModuleMethods(m);

                    if (m.Controllers.Any() || m.Curves.Any())
                        AppendLine();

                    if (m.Controllers.Any())
                    {
                        AppendLine("#region controllers");
                        AppendLine();
                        GenerateControllers(m);
                        AppendLine("#endregion controllers");
                    }

                    if (m.Controllers.Any() && m.Curves.Any())
                        AppendLine();

                    if (m.Curves.Any())
                    {
                        AppendLine("#region curves");
                        AppendLine();
                        GenerateCurves(m);
                        AppendLine("#endregion curves");
                    }

                    if (m.Curves.Any() && m.AdditionalCodeDescription != null)
                    {
                        AppendLine();
                    }
                });
                AppendLine("}");
                if (i != modules.Length - 1)
                    AppendLine();
            }
        }

        private void GenerateModuleMethods(ModuleDesc m)
        {
            if (m.AdditionalCodeDescription == null)
                return;

            var acd = m.AdditionalCodeDescription;
            AppendLine();
            AppendLine("#region module type-specific methods");
            AppendLine();
            acd.AddCode(Context, _data);
            AppendLine("#endregion module type-specific methods");
            AppendLine();
        }

        private void GenerateControllers(ModuleDesc module)
        {
            foreach (var c in module.Controllers.OrderBy(c => c.FriendlyName))
            {
                if (!string.IsNullOrWhiteSpace(c.EnumTypeName))
                {
                    // ENUM
                    var @enum = _data.Enums.First(e => e.Name == c.EnumTypeName);
                    AppendLine("/// <summary>");
                    AppendLine($"/// Original name: {c.InternalName}");
                    AppendLine(
                        $"/// <para> Possible values: {string.Join(", ", @enum.Values.Select(v => v.name))} </para>");
                    if (!string.IsNullOrWhiteSpace(c.Description))
                        AppendLine($"/// <para> {c.Description} </para>");
                    AppendLine("/// </summary>");
                    AppendLine(
                        $"public {@enum.Name} Get{c.FriendlyName}() => ({@enum.Name})ModuleHandle.GetControllerValue({c.Id}, {nameof(ValueScalingType)}.{ValueScalingType.Displayed});");
                    AppendLine();
                    AppendLine("/// <summary>");
                    AppendLine($"/// Original name: {c.InternalName}");
                    AppendLine(
                        $"/// <para> Possible values: {string.Join(", ", @enum.Values.Select(v => v.name))} </para>");
                    if (!string.IsNullOrWhiteSpace(c.Description))
                        AppendLine($"/// <para> {c.Description} </para>");
                    AppendLine("/// </summary>");
                    AppendLine(
                        $"public void Set{c.FriendlyName}({@enum.Name} value) => ModuleHandle.SetControllerValue({c.Id}, (int)value, {nameof(ValueScalingType)}.{ValueScalingType.Displayed});");
                    AppendLine();
                }
                else
                {
                    // REAL
                    AppendLine("/// <summary>");
                    AppendLine($"/// Original name: {c.InternalName}");
                    AppendLine($"/// <para> Value range: {c.MinValue} to {c.MaxValue} </para>");
                    if (!string.IsNullOrWhiteSpace(c.Description))
                        AppendLine($"/// <para> {c.Description} </para>");
                    AppendLine("/// </summary>");
                    AppendLine(
                        $"public int Get{c.FriendlyName}() => ModuleHandle.GetControllerValue({c.Id}, {nameof(ValueScalingType)}.{ValueScalingType.Displayed});");
                    AppendLine();
                    AppendLine("/// <summary>");
                    AppendLine($"/// Original name: {c.InternalName}");
                    AppendLine($"/// <para> Value range: {c.MinValue} to {c.MaxValue} </para>");
                    if (!string.IsNullOrWhiteSpace(c.Description))
                        AppendLine($"/// <para> {c.Description} </para>");
                    AppendLine("/// </summary>");
                    AppendLine(
                        $"public void Set{c.FriendlyName}(int value) => ModuleHandle.SetControllerValue({c.Id}, value, {nameof(ValueScalingType)}.{ValueScalingType.Displayed});");
                    AppendLine();
                }
            }
        }

        private void GenerateCurves(ModuleDesc module)
        {
            foreach (var curve in module.Curves.OrderBy(c => c.FriendlyName))
            {
                AppendLine("/// <summary>");
                AppendLine($"/// Read {curve.FriendlyName} containing {curve.Size} values.");
                AppendLine($"/// <para> Value range: {curve.MinValue} to {curve.MaxValue}. </para>");
                if (!string.IsNullOrWhiteSpace(curve.Description))
                    AppendLine($"/// <para> {curve.Description} </para>");
                AppendLine("/// </summary>");
                AppendLine($"public void Read{curve.FriendlyName}(float[] buffer)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine($"if (buffer.Length < {curve.Size})");
                    AddIndent(() =>
                        AppendLine(
                            $"throw new System.ArgumentException(\"Buffer must be at least of size {curve.Size}\");"));
                    AppendLine();
                    AppendLine($"ModuleHandle.ReadCurve({curve.Id}, buffer);");
                });
                AppendLine("}");
                AppendLine();
                AppendLine("/// <summary>");
                AppendLine($"/// Write {curve.FriendlyName} containing {curve.Size} values.");
                AppendLine($"/// <para> Value range: {curve.MinValue} to {curve.MaxValue}. </para>");
                if (!string.IsNullOrWhiteSpace(curve.Description))
                    AppendLine($"/// <para> {curve.Description} </para>");
                AppendLine("/// </summary>");
                AppendLine($"public void Write{curve.FriendlyName}(float[] buffer)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine($"if (buffer.Length < {curve.Size})");
                    AddIndent(() =>
                        AppendLine(
                            $"throw new System.ArgumentException(\"Buffer must be at least of size {curve.Size}\");"));
                    AppendLine();
                    AppendLine($"ModuleHandle.WriteCurve({curve.Id}, buffer);");
                });
                AppendLine("}");
                AppendLine();
            }
        }
    }
}
