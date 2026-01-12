#if !GENERATION

namespace SunSharp.Modules
{
    public partial interface IVorbisPlayerModuleHandle
    {
        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoVorbisPLayer(string)"/>
        void LoadVorbis(string path);

        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoVorbisPLayer(byte[])"/>
        void LoadIntoVorbisPLayer(byte[] data);
    }

    public partial struct VorbisPlayerModuleHandle : IVorbisPlayerModuleHandle
    {
        /// <inheritdoc/>
        public void LoadVorbis(string path)
        {
            ModuleHandle.LoadIntoVorbisPLayer(path);
        }

        /// <inheritdoc/>
        public void LoadIntoVorbisPLayer(byte[] data)
        {
            ModuleHandle.LoadIntoVorbisPLayer(data);
        }
    }
}

#endif
