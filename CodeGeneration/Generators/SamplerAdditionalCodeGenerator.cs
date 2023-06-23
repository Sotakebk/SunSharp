namespace CodeGeneration.Generators
{
    internal class SamplerAdditionalCodeGenerator : AdditionalGenerator
    {
        public override void AppendCode()
        {
            AppendLine("/// <inheritdoc cref=\"ModuleHandle.LoadSamplerSample(byte[], int)\"/>");
            AppendLine(
                "public void LoadSample(byte[] data, int sampleSlot = -1) => ModuleHandle.LoadSamplerSample(data, sampleSlot);");
            AppendLine();
            AppendLine("/// <inheritdoc cref=\"ModuleHandle.LoadSamplerSample(string, int)\"/>");
            AppendLine(
                "public void LoadSample(string path, int sampleSlot = -1) => ModuleHandle.LoadSamplerSample(path, sampleSlot);");
        }
    }
}
