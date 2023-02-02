namespace CodeGeneration.Generators
{
    internal class MetaModuleAdditionalCodeGenerator : AdditionalGenerator
    {
        public override void AppendCode()
        {
            AppendLine("/// <inheritdoc cref=\"ModuleHandle.LoadIntoMetaModule(string)\"/>");
            AppendLine("public void LoadFile(string path) => Module.LoadIntoMetaModule(path);");
            AppendLine();
            AppendLine("/// <inheritdoc cref=\"ModuleHandle.LoadIntoMetaModule(byte[])\"/>");
            AppendLine("public void LoadFile(byte[] data) => Module.LoadIntoMetaModule(data);");
        }
    }
}
