using System;

namespace SunSharp.Native.Loader
{
    public interface ILibraryHandler
    {
        public bool IsLibraryLoaded { get; }

        /// <summary>
        /// A method to be called to load a library and prepare everything.
        /// </summary>
        void LoadLibrary();

        /// <summary>
        /// A method to unload the library if loaded, and destroy unmanaged objects.
        /// </summary>
        void UnloadLibrary();

        /// <summary>
        /// A method that returns a delegate from a function pointer, found in the loaded library by name.
        /// Should fail immediately if the method is not found.
        /// </summary>
        Delegate GetFunctionByName(string name, Type delegateType);
    }
}
