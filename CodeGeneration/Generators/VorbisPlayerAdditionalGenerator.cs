namespace CodeGeneration.Generators
{
    internal class VorbisPlayerAdditionalGenerator : AdditionalGenerator
    {
        public override void AppendCode()
        {
            AppendLine("/// <inheritdoc cref=\"ModuleHandle.LoadIntoVorbisPLayer(string)\"/>");
            AppendLine("public void LoadVorbis(string path) => Module.LoadIntoVorbisPLayer(path);");
            AppendLine();
            AppendLine("/// <inheritdoc cref=\"ModuleHandle.LoadIntoVorbisPLayer(byte[])\"/>");
            AppendLine("public void LoadIntoVorbisPLayer(byte[] data) => Module.LoadIntoVorbisPLayer(data);");
        }
    }
}
