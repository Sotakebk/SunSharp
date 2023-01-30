namespace CodeGeneration
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
            AppendLine("namespace CodeGeneration");
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
            AppendLine("data.Enums = new EnumDescription[]");
            AppendLine("{");
            AddIndent(() =>
            {
                foreach (var ed in _data.Enums.OrderBy(e => e.Name))
                {
                    AppendLine($"new EnumDescription(");
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
            AppendLine("data.Modules = new ModuleDescription[]");
            AppendLine("{");
            AddIndent(() =>
            {
                foreach (var moduleDescription in _data.Modules.OrderBy(n => n.Name))
                {
                    AppendLine("new ModuleDescription(");
                    AddIndent(() =>
                    {
                        AppendLine($"\"{moduleDescription.Name}\",");
                        AppendLine($"\"{moduleDescription.InternalName}\",");
                        AppendLine($"\"{moduleDescription.Description}\",");
                        AppendLine("new List<ControllerDescription>()");
                        AppendLine("{");
                        AddIndent(() =>
                        {
                            foreach (var cd in moduleDescription.Controllers.OrderBy(c => c.Id))
                            {
                                if (!string.IsNullOrWhiteSpace(cd.EnumTypeName))
                                    AppendLine($"new ControllerDescription({cd.Id}, \"{cd.Name}\", \"{cd.OriginalName}\", \"{cd.Description}\", {cd.MinValue}, {cd.MaxValue}, \"{cd.EnumTypeName}\"),");
                                else
                                    AppendLine($"new ControllerDescription({cd.Id}, \"{cd.Name}\", \"{cd.OriginalName}\", \"{cd.Description}\", {cd.MinValue}, {cd.MaxValue}),");
                            }
                        });
                        AppendLine("},");
                        AppendLine("new List<CurveDescription>()");
                        AppendLine("{");
                        AddIndent(() =>
                        {
                            foreach (var cd in moduleDescription.Curves.OrderBy(c => c.Id))
                            {
                                AppendLine($"new CurveDescription({cd.Id}, \"{cd.Name}\", \"{cd.Description}\", {cd.MinValue}, {cd.MaxValue}, {cd.Size}),");
                            }
                        });
                        AppendLine("}");
                    });
                    AppendLine("),");
                }
            });
            AppendLine("};");
        }
    }
}
