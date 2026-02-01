#if !GENERATION

namespace SunSharp.Modules
{
    public partial interface IVorbisPlayerModuleHandle
    {
        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoVorbisPlayer(string)"/>
        void LoadAudio(string path);

        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoVorbisPlayer(byte[])"/>
        void LoadAudio(byte[] data);
    }

    public partial struct VorbisPlayerModuleHandle : IVorbisPlayerModuleHandle
    {
        /// <inheritdoc/>
        public void LoadAudio(string path)
        {
            ModuleHandle.LoadIntoVorbisPlayer(path);
        }

        /// <inheritdoc/>
        public void LoadAudio(byte[] data)
        {
            ModuleHandle.LoadIntoVorbisPlayer(data);
        }
    }
}

#endif
