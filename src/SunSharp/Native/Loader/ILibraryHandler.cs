using System;

namespace SunSharp.Native.Loader
{
    /// <summary>
    /// Provides an abstraction for loading and managing native library handles.
    /// Used to load native libraries, retrieve function pointers, and unload libraries when no longer needed.
    /// Used by the <see cref="NativeProxy"/> class.
    /// </summary>
    /// <remarks>
    /// You may implement this interface to create custom library loading mechanisms,
    /// if necessary for your platform or application requirements.
    /// See the implementation in the SunSharp.Redistribution package for reference.
    /// </remarks>
    /// <seealso cref="NativeProxy"/>
    public interface ILibraryHandler
    {
        /// <summary>
        /// Whether the native library is currently loaded.
        /// </summary>
        public bool IsLibraryLoaded { get; }

        /// <summary>
        /// Loads the native library from the file system and prepares it for use.
        /// </summary>
        void LoadLibrary();

        /// <summary>
        /// Unloads the native library if it is currently loaded and releases any associated unmanaged resources.
        /// </summary>
        void UnloadLibrary();

        /// <summary>
        /// Retrieves a managed delegate for an exported function from the loaded library.
        /// </summary>
        /// <param name="name">The name of the exported function to retrieve.</param>
        /// <param name="delegateType">The delegate type that matches the function signature.</param>
        /// <returns>
        /// A delegate instance that can be used to invoke the native function.
        /// </returns>
        Delegate GetFunctionByName(string name, Type delegateType);
    }
}
