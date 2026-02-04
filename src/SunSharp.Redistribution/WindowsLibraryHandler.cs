using System;
using System.Runtime.InteropServices;
using SunSharp.Native.Loader;

namespace SunSharp.Redistribution
{
    internal sealed class WindowsLibraryHandler : ILibraryHandler
    {
        private readonly object _lock = new object();
        private readonly string _path;
        private volatile IntPtr _ptr = IntPtr.Zero;

        public WindowsLibraryHandler(string path)
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
                    throw new LibraryLoadingException("SunVoxLib is already loaded.");
                }

                var ptr = LoadLibrary(_path);
                if (ptr == IntPtr.Zero)
                {
                    var error = Marshal.GetHRForLastWin32Error();
                    throw new LibraryLoadingException(
                        $"Failed to load SunVoxLib from path '{_path}' with error '{error:X8}'.");
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
                    throw new LibraryLoadingException("SunVoxLib is not loaded.");
                }

                var ptr = _ptr;
                _ptr = IntPtr.Zero;
                var value = FreeLibrary(ptr);
                if (value != 0)
                {
                    return;
                }

                var error = Marshal.GetHRForLastWin32Error();
                throw new LibraryLoadingException($"Failed to unload SunVoxLib with error error '{error:X8}'.");
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

                var ptr = GetProcAddress(_ptr, name);
                if (ptr != IntPtr.Zero)
                {
                    return Marshal.GetDelegateForFunctionPointer(ptr, delegateType);
                }

                var error = Marshal.GetHRForLastWin32Error();
                throw new LibraryLoadingException($"Failed to load SunVoxLib function '{name}' with error '{error:X8}'.");
            }
        }

        [DllImport("kernel32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CharSet = CharSet.Ansi)]
        private static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string dllToLoad);

        [DllImport("kernel32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr hModule,
            [MarshalAs(UnmanagedType.LPStr)] string procedureName);

        [DllImport("kernel32.dll")]
        private static extern int FreeLibrary(IntPtr hModule);
    }
}
