#if !GENERATION

namespace SunSharp.Modules
{
    public partial interface IMetaModuleModuleHandle
    {
        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoMetaModule(string)"/>
        void LoadFile(string path);

        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoMetaModule(byte[])"/>
        void LoadFile(byte[] data);
    }

    public partial struct MetaModuleModuleHandle : IMetaModuleModuleHandle
    {
        /// <inheritdoc/>
        public void LoadFile(string path) => ModuleHandle.LoadIntoMetaModule(path);

        /// <inheritdoc/>
        public void LoadFile(byte[] data) => ModuleHandle.LoadIntoMetaModule(data);
    }
}

#endif
