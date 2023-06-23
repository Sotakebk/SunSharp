using CodeGeneration.ReparsedData;

namespace CodeGeneration.Generators.SpecificGenerators
{
    internal class ModuleData_Generator : BaseGenerator
    {
        private Data _data;

        public ModuleData_Generator(Data data)
        {
            _data = data;
        }

        protected override void GenerateBody()
        {
            AppendLine("/*");
            AppendLine(" * IMPORTANT!");
            AppendLine(" * Please run CodeGeneration each time this file is manually changed.");
            AppendLine("*/");
            AppendLine();
            AppendLine("using CodeGeneration.Generators;");
            AppendLine();
            AppendLine("namespace CodeGeneration.ReparsedData");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("public partial class Data");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine("public static Data GetData()");
                    AppendLine("{");
                    AddIndent(() =>
                    {
                        AppendLine("var data = new Data();");
                        AppendLine();
                        AddEnums();
                        AppendLine();
                        AddModules();
                        AppendLine();
                        AppendLine("return data;");
                    });
                    AppendLine("}");
                });
                AppendLine("}");
            });

            AppendLine("}");
        }

        protected void AddEnums()
        {
            AppendLine($"data.Enums = new {nameof(EnumDesc)}[]");
            AppendLine("{");
            AddIndent(() =>
            {
                foreach (var ed in _data.Enums.OrderBy(e => e.Name))
                {
                    AppendLine($"new {nameof(EnumDesc)}(");
                    AddIndent(() =>
                    {
                        AppendLine($"\"{ed.Name}\",");
                        AppendLine("new []{");
                        AddIndent(() =>
                        {
                            foreach (var val in ed.Values.OrderBy(v => v.value))
                            {
                                AppendLine($"({val.value}, \"{val.name}\"),");
                            }
                        });
                        AppendLine("}");
                    });
                    AppendLine("),");
                }
            });
            AppendLine("};");
        }

        protected void AddModules()
        {
            AppendLine($"data.Modules = new {nameof(ModuleDesc)}[]");
            AppendLine("{");
            AddIndent(() =>
            {
                foreach (var md in _data.Modules.OrderBy(n => n.FriendlyName))
                {
                    AppendLine($"new {nameof(ModuleDesc)}(");
                    AddIndent(() =>
                    {
                        AppendLine($"\"{md.FriendlyName}\",");
                        AppendLine($"\"{md.InternalName}\",");
                        AppendLine($"\"{md.Description}\",");
                        AppendLine($"new List<{nameof(CtlDesc)}>()");
                        AppendLine("{");
                        AddIndent(() =>
                        {
                            foreach (var cd in md.Controllers.OrderBy(c => c.Id))
                            {
                                AddController(cd);
                            }
                        });
                        AppendLine("},");
                        AppendLine($"new List<{nameof(CurveDesc)}>()");
                        AppendLine("{");
                        AddIndent(() =>
                        {
                            foreach (var cd in md.Curves.OrderBy(c => c.Id))
                            {
                                AppendLine(
                                    $"new {nameof(CurveDesc)}({cd.Id}, \"{cd.FriendlyName}\", \"{cd.Description}\", {cd.MinValue}, {cd.MaxValue}, {cd.Size}),");
                            }
                        });
                        AppendLine("},");
                        if (md.AdditionalCodeDescription == null)
                            AppendLine("null");
                        else
                        {
                            var genericType = md.AdditionalCodeDescription.GetType().GetGenericArguments()[0];
                            AppendLine($"new {nameof(AddCodeDesc)}<{genericType.Name}>()");
                        }
                    });
                    AppendLine("),");
                }
            });
            AppendLine("};");
        }

        private void AddController(CtlDesc cd)
        {
            if (cd.IgnoreInternalEnum)
            {
                AppendLine(
                    $"new {nameof(CtlDesc)}({cd.Id}, \"{cd.FriendlyName}\", \"{cd.InternalName}\", \"{cd.Description}\", {cd.MinValue}, {cd.MaxValue}, ignoreInternalEnum: true),");
            }
            else if (!string.IsNullOrWhiteSpace(cd.EnumTypeName))
            {
                AppendLine(
                    $"new {nameof(CtlDesc)}({cd.Id}, \"{cd.FriendlyName}\", \"{cd.InternalName}\", \"{cd.Description}\", {cd.MinValue}, {cd.MaxValue}, enumTypeName: \"{cd.EnumTypeName}\"),");
            }
            else
            {
                AppendLine(
                    $"new {nameof(CtlDesc)}({cd.Id}, \"{cd.FriendlyName}\", \"{cd.InternalName}\", \"{cd.Description}\", {cd.MinValue}, {cd.MaxValue}),");
            }
        }
    }
}
