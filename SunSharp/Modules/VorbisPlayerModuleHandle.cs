#if !GENERATION

namespace SunSharp.Modules
{
    public partial interface IVorbisPlayerModuleHandle
    {
        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoVorbisPlayer(string)"/>
        void LoadVorbis(string path);

        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoVorbisPlayer(byte[])"/>
        void LoadIntoVorbisPlayer(byte[] data);
    }

    public partial struct VorbisPlayerModuleHandle : IVorbisPlayerModuleHandle
    {
        /// <inheritdoc/>
        public void LoadVorbis(string path)
        {
            ModuleHandle.LoadIntoVorbisPlayer(path);
        }

        /// <inheritdoc/>
        public void LoadIntoVorbisPlayer(byte[] data)
        {
            ModuleHandle.LoadIntoVorbisPlayer(data);
        }
    }
}

#endif
