namespace CodeGeneration.Generators.SpecificGenerators
{
    internal class ModuleType_Generator : BaseGenerator
    {
        private ICollection<(int value, string friendlyName, string internalName)> types = ModuleTypes.GetModuleTypes();

        protected override void GenerateBody()
        {
            AppendLine("/*");
            AppendLine(" * IMPORTANT!");
            AppendLine(
                " * Do not modify this file manually. It was generated automatically by the CodeGeneration project.");
            AppendLine("*/");
            AppendLine();
            AppendLine("namespace SunSharp.ObjectWrapper");
            AppendLine("{");
            AddIndent(() =>
            {
                GenerateEnum();
                AppendLine();
                GenerateHelper();
            });
            AppendLine("}");
        }

        private void GenerateEnum()
        {
            AppendLine("public enum ModuleType");
            AppendLine("{");
            AddIndent(() =>
            {
                foreach (var value in types.OrderBy(t => t.friendlyName))
                    AppendLine($"{value.friendlyName} = {value.value},");
                AppendLine($"Unknown = 0,");
            });
            AppendLine("}");
        }

        private void GenerateHelper()
        {
            AppendLine("public static class ModuleTypeHelper");
            AppendLine("{");
            AddIndent(() =>
            {
                AppendLine("public static string InternalNameFromType(ModuleType type)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine("switch (type)");
                    AppendLine("{");
                    AddIndent(() =>
                    {
                        foreach (var value in types.OrderBy(t => t.friendlyName))
                            AppendLine($"case ModuleType.{value.friendlyName}: return \"{value.internalName}\";");
                        AppendLine($"default: return \"unknown\";");
                    });
                    AppendLine("}");
                });
                AppendLine("}");
                AppendLine();

                AppendLine("public static ModuleType TypeFromInternalName(string internalName)");
                AppendLine("{");
                AddIndent(() =>
                {
                    AppendLine("switch (internalName)");
                    AppendLine("{");
                    AddIndent(() =>
                    {
                        foreach (var value in types.OrderBy(t => t.friendlyName))
                            AppendLine($"case \"{value.internalName}\": return ModuleType.{value.friendlyName};");
                        AppendLine($"default: return ModuleType.Unknown;");
                    });
                    AppendLine("}");
                });
                AppendLine("}");
            });
            AppendLine("}");
        }
    }
}
