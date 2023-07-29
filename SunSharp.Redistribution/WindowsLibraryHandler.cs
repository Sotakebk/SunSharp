using System;
using System.Runtime.InteropServices;
using SunSharp.Native.Loader;

namespace SunSharp.Redistribution
{
    internal sealed class WindowsLibraryHandler : ILibraryHandler
    {
        public bool IsLibraryLoaded => _ptr != IntPtr.Zero;

        private readonly object _lock = new object();
        private readonly string _path;
        private volatile IntPtr _ptr = IntPtr.Zero;

        public WindowsLibraryHandler(string path)
        {
            _path = path;
        }

        public void LoadLibrary()
        {
            lock (_lock)
            {
                if (IsLibraryLoaded)
                    throw new LibraryLoadingException("SunVoxLib is already loaded.");

                var ptr = WindowsLibraryHandler.LoadLibrary(_path);
                if (ptr == IntPtr.Zero)
                    throw new LibraryLoadingException($"Failed to load SunVoxLib from path '{_path}'.");

                _ptr = ptr;
            }
        }

        public void UnloadLibrary()
        {
            lock (_lock)
            {
                if (!IsLibraryLoaded)
                    throw new LibraryLoadingException("SunVoxLib is not loaded.");

                var ptr = _ptr;
                _ptr = IntPtr.Zero;
                WindowsLibraryHandler.FreeLibrary(ptr);
            }
        }

        public Delegate GetFunctionByName(string name, Type delegateType)
        {
            if (delegateType.IsAssignableFrom(typeof(Delegate)))
                throw new ArgumentException($"Type {delegateType.Name} is not a delegate type");

            lock (_lock)
            {
                if (!IsLibraryLoaded)
                    throw new LibraryLoadingException("SunVoxLib is not loaded.");

                var ptr = WindowsLibraryHandler.GetProcAddress(_ptr, name);
                if (ptr == IntPtr.Zero)
                    throw new LibraryLoadingException($"Failed to load SunVoxLib from path '{_path}'.");

                return Marshal.GetDelegateForFunctionPointer(ptr, delegateType);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true, CharSet = CharSet.Ansi)]
        private static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string dllToLoad);

        [DllImport("kernel32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string procedureName);

        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);
    }
}
