#if !GENERATION

namespace SunSharp.Modules
{
    public partial interface ISamplerModuleHandle
    {
        /// <inheritdoc cref="ISynthModuleHandle.LoadSamplerSample(byte[], int?)"/>
        void LoadSample(byte[] data, int? sampleSlot = null);

        /// <inheritdoc cref="ISynthModuleHandle.LoadSamplerSample(string, int?)"/>
        void LoadSample(string path, int? sampleSlot = null);
    }

    public partial struct SamplerModuleHandle : ISamplerModuleHandle
    {
        /// <inheritdoc/>
        public void LoadSample(byte[] data, int? sampleSlot = null)
        {
            ModuleHandle.LoadSamplerSample(data, sampleSlot);
        }

        /// <inheritdoc/>
        public void LoadSample(string path, int? sampleSlot = null)
        {
            ModuleHandle.LoadSamplerSample(path, sampleSlot);
        }
    }
}

#endif
