using System;
using System.Runtime.InteropServices;
using SunSharp.Native.Loader;

namespace SunSharp.Redistribution
{
    internal sealed class UnixLibraryHandler : ILibraryHandler
    {
        private readonly object _lock = new object();
        private readonly string _path;
        private volatile IntPtr _ptr = IntPtr.Zero;

        public UnixLibraryHandler(string path)
        {
            _path = path;
        }

        public bool IsLibraryLoaded => _ptr != IntPtr.Zero;

        public void LoadLibrary()
        {
            lock (_lock)
            {
                if (IsLibraryLoaded)
                {
                    return;
                }

                var ptr = dlopen(_path, 0);
                if (ptr == IntPtr.Zero)
                {
                    var error = dlerror();
                    throw new LibraryLoadingException($"Failed to load SunVoxLib from path '{_path}' with error '{error}'.");
                }

                _ptr = ptr;
            }
        }

        public void UnloadLibrary()
        {
            lock (_lock)
            {
                if (!IsLibraryLoaded)
                {
                    return;
                }

                var code = dlclose(_ptr);
                if (code != 0)
                {
                    var error = dlerror();
                    throw new LibraryLoadingException($"Failed to unload SunVoxLib with error '{error}'.");
                }

                _ptr = IntPtr.Zero;
            }
        }

        public Delegate GetFunctionByName(string name, Type delegateType)
        {
            if (delegateType.IsAssignableFrom(typeof(Delegate)))
            {
                throw new ArgumentException($"Type {delegateType.Name} is not a delegate type");
            }

            lock (_lock)
            {
                if (!IsLibraryLoaded)
                {
                    throw new LibraryLoadingException("SunVoxLib is not loaded.");
                }

                var ptr = dlsym(_ptr, name);
                if (ptr != IntPtr.Zero)
                {
                    return Marshal.GetDelegateForFunctionPointer(ptr, delegateType);
                }

                var error = dlerror();
                throw new LibraryLoadingException($"Failed to load SunVoxLib function '{name}' with error '{error}'.");
            }
        }

        [DllImport("libdl.so", CharSet = CharSet.Unicode)]
        public static extern IntPtr dlopen(string filename, int flags);

        [DllImport("libdl.so", CharSet = CharSet.Unicode)]
        public static extern IntPtr dlsym(IntPtr handle, string symbol);

        [DllImport("libdl.so")]
        public static extern int dlclose(IntPtr handle);

        [DllImport("libdl.so", CharSet = CharSet.Unicode)]
        public static extern string dlerror();
    }
}
