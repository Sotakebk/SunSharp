namespace CodeGeneration
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
            AppendLine(" * Do not modify this file manually. It was generated automatically by the CodeGeneration project.");
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
                var modules = _data.Modules.OrderBy(m => m.Name).ToArray();
                for (int i = 0; i < modules.Length; i++)
                {
                    var module = modules[i];
                    AppendLine($"public static {module.Name} As{module.Name}(this Module module) => new {module.Name}(module);");

                    if (i != modules.Length - 1)
                        AppendLine();
                }
            });
            AppendLine("}");
        }

        private void GenerateStructs()
        {
            var modules = _data.Modules.OrderBy(m => m.Name).ToArray();
            for (var i = 0; i < modules.Length; i++)
            {
                var module = modules[i];

                AppendLine($"public struct {module.Name}");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine("public Module Module { get; private set; }");
                    AppendLine();
                    AppendLine($"public {module.Name}(Module module)");
                    AppendLine("{");
                    AddIndent(() =>
                    {
                        AppendLine("Module = module;");
                    });
                    AppendLine("}");

                    if (module.Controllers.Any() || module.Curves.Any())
                        AppendLine();

                    if (module.Controllers.Any())
                    {
                        AppendLine("#region controllers");
                        AppendLine();
                        GenerateControllers(module);
                        AppendLine("#endregion controllers");
                    }

                    if (module.Controllers.Any() && module.Curves.Any())
                        AppendLine();

                    if (module.Curves.Any())
                    {
                        AppendLine("#region curves");
                        AppendLine();
                        GenerateCurves(module);
                        AppendLine("#endregion curves");
                    }
                });
                AppendLine("}");
                if (i != modules.Length - 1)
                    AppendLine();
            }
        }

        private void GenerateControllers(ModuleDescription module)
        {
            foreach (var controller in module.Controllers.OrderBy(c => c.Name))
            {
                AppendLine("/// <summary>");
                AppendLine($"/// Original name: {controller.OriginalName}");
                AppendLine($"/// <para> Value range: {controller.MinValue} to {controller.MaxValue} </para>");
                if (!string.IsNullOrWhiteSpace(controller.Description))
                    AppendLine($"/// <para> {controller.Description} </para>");
                AppendLine("/// </summary>");
                AppendLine($"public ushort Get{controller.Name}() => (ushort)Module.GetControllerValue({controller.Id}, true);");
                AppendLine();
                AppendLine("/// <summary>");
                AppendLine($"/// Original name: {controller.OriginalName}");
                AppendLine($"/// <para> Value range: {controller.MinValue} to {controller.MaxValue} </para>");
                if (!string.IsNullOrWhiteSpace(controller.Description))
                    AppendLine($"/// <para> {controller.Description} </para>");
                AppendLine("/// </summary>");
                AppendLine($"public void Set{controller.Name}({(string.IsNullOrWhiteSpace(controller.EnumTypeName) ? "ushort" : controller.EnumTypeName)} value) => Module.SetControllerValue({controller.Id}, (ushort)value);");
                AppendLine();
            }
        }

        private void GenerateCurves(ModuleDescription module)
        {
            foreach (var curve in module.Curves.OrderBy(c => c.Name))
            {
                AppendLine("/// <summary>");
                AppendLine($"/// Read {curve.Name} containing {curve.Size} values.");
                AppendLine($"/// <para> Value range: {curve.MinValue} to {curve.MaxValue}. </para>");
                if (!string.IsNullOrWhiteSpace(curve.Description))
                    AppendLine($"/// <para> Value range: {curve.Description} </para>");
                AppendLine("/// </summary>");
                AppendLine($"public void Read{curve.Name}(float[] buffer)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine($"if (buffer.Length < {curve.Size})");
                    AddIndent(() => AppendLine($"throw new System.ArgumentException(\"Buffer must be at least of size {curve.Size}\");"));
                    AppendLine();
                    AppendLine($"Module.ReadModuleCurve({curve.Id}, buffer);");
                });
                AppendLine("}");
                AppendLine();
                AppendLine("/// <summary>");
                AppendLine($"/// Write {curve.Name} containing {curve.Size} values.");
                AppendLine($"/// <para> Value range: {curve.MinValue} to {curve.MaxValue}. </para>");
                if (!string.IsNullOrWhiteSpace(curve.Description))
                    AppendLine($"/// <para> Value range: {curve.Description} </para>");
                AppendLine("/// </summary>");
                AppendLine($"public void Write{curve.Name}(float[] buffer)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine($"if (buffer.Length < {curve.Size})");
                    AddIndent(() => AppendLine($"throw new System.ArgumentException(\"Buffer must be at least of size {curve.Size}\");"));
                    AppendLine();
                    AppendLine($"Module.WriteModuleCurve({curve.Id}, buffer);");
                });
                AppendLine("}");
                AppendLine();
            }
        }
    }
}
