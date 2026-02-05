using System;
using System.Runtime.InteropServices;

namespace SunSharp.Redistribution
{
    internal sealed class LinuxLibraryHandler : LibraryHandlerBase
    {
        public LinuxLibraryHandler(string path) : base(path)
        {
        }

        public override void LoadLibrary()
        {
            lock (Lock)
            {
                if (IsLibraryLoaded)
                {
                    return;
                }

                var ptr = dlopen(Path, 0x002);
                if (ptr == IntPtr.Zero)
                {
                    var error = dlerror() ?? "<null>";
                    throw new LibraryLoadingException($"Failed to load SunVoxLib from path '{Path}' with error '{error}'.");
                }

                Handle = ptr;
            }
        }

        public override void UnloadLibrary()
        {
            lock (Lock)
            {
                if (!IsLibraryLoaded)
                {
                    return;
                }

                var code = dlclose(Handle);
                if (code != 0)
                {
                    var error = dlerror() ?? "<null>";
                    throw new LibraryLoadingException($"Failed to unload SunVoxLib with error '{error}'.");
                }

                Handle = IntPtr.Zero;
            }
        }

        protected override IntPtr GetFunctionPointer(IntPtr handle, string name)
        {
            return dlsym(handle, name);
        }

        protected override Exception CreateFunctionLoadException(string name)
        {
            var error = dlerror();
            return new LibraryLoadingException($"Failed to load SunVoxLib function '{name}' with error '{error}'.");
        }

        [DllImport("libdl.so.2", CharSet = CharSet.Unicode, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dlopen([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int flags);

        [DllImport("libdl.so.2", CharSet = CharSet.Unicode, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dlsym(IntPtr handle, [MarshalAs(UnmanagedType.LPUTF8Str)] string symbol);

        [DllImport("libdl.so.2")]
        public static extern int dlclose(IntPtr handle);

        [DllImport("libdl.so.2", CharSet = CharSet.Unicode, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string? dlerror();
    }
}
