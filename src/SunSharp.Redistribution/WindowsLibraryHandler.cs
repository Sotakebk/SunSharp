using System;
using System.Runtime.InteropServices;

namespace SunSharp.Redistribution
{
    internal sealed class WindowsLibraryHandler : LibraryHandlerBase
    {
        public WindowsLibraryHandler(string path) : base(path)
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

                var ptr = LoadLibraryW(Path);
                if (ptr == IntPtr.Zero)
                {
                    var error = Marshal.GetHRForLastWin32Error();
                    throw new LibraryLoadingException(
                        $"Failed to load SunVoxLib from path '{Path}' with error '{error:X8}'.");
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

                var ptr = Handle;
                Handle = IntPtr.Zero;
                var value = FreeLibrary(ptr);
                if (value != 0)
                {
                    return;
                }

                var error = Marshal.GetHRForLastWin32Error();
                throw new LibraryLoadingException($"Failed to unload SunVoxLib with error '{error:X8}'.");
            }
        }

        protected override IntPtr GetFunctionPointer(IntPtr handle, string name)
        {
            return GetProcAddress(handle, name);
        }

        protected override Exception CreateFunctionLoadException(string name)
        {
            var error = Marshal.GetHRForLastWin32Error();
            return new LibraryLoadingException($"Failed to load SunVoxLib function '{name}' with error '{error:X8}'.");
        }

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern IntPtr LoadLibraryW([MarshalAs(UnmanagedType.LPWStr)] string lpFilename);

        [DllImport("kernel32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr hModule,
            [MarshalAs(UnmanagedType.LPStr)] string procedureName);

        [DllImport("kernel32.dll")]
        private static extern int FreeLibrary(IntPtr hModule);
    }
}
