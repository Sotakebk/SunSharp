namespace CodeGeneration.Generators
{
    internal class VorbisPlayerAdditionalGenerator : AdditionalGenerator
    {
        public override void AppendCode()
        {
            AppendLine("/// <inheritdoc cref=\"ModuleHandle.LoadIntoVorbisPLayer(string)\"/>");
            AppendLine("public void LoadVorbis(string path) => ModuleHandle.LoadIntoVorbisPLayer(path);");
            AppendLine();
            AppendLine("/// <inheritdoc cref=\"ModuleHandle.LoadIntoVorbisPLayer(byte[])\"/>");
            AppendLine("public void LoadIntoVorbisPLayer(byte[] data) => ModuleHandle.LoadIntoVorbisPLayer(data);");
        }
    }
}
