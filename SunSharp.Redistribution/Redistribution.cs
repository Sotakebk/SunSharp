using SunSharp.LibraryLoading;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SunSharp.Redistribution
{
    public static class Redistribution
    {
        #region platform invoke

        private static class WindowsImports
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string dllToLoad);

            [DllImport("kernel32.dll")]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hModule);
        }

        private static class LinuxImports
        {
            [DllImport("libdl.so")]
            public static extern IntPtr dlopen(string filename, int flags);

            [DllImport("libdl.so")]
            public static extern IntPtr dlsym(IntPtr handle, string symbol);

            [DllImport("libdl.so")]
            public static extern int dlclose(IntPtr hModule);
        }

        private static class MacOSImports
        {
            [DllImport("libdl.so")]
            public static extern IntPtr dlopen(string fileName, int flags);

            [DllImport("libdl.so")]
            public static extern IntPtr dlsym(IntPtr handle, string symbol);

            [DllImport("libdl.so")]
            public static extern int dlclose(IntPtr handle);
        }

        private static IntPtr LoadLibrary(string filename)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return WindowsImports.LoadLibrary(filename);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LinuxImports.dlopen(filename, 0);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return MacOSImports.dlopen(filename, 0);

            throw new Exception("Unsupported OS.");
        }

        private static IntPtr FindFunction(IntPtr handle, string symbol)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return WindowsImports.GetProcAddress(handle, symbol);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LinuxImports.dlsym(handle, symbol);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return MacOSImports.dlsym(handle, symbol);

            throw new Exception("Unsupported OS.");
        }

        private static void UnloadLibrary(IntPtr handle)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                WindowsImports.FreeLibrary(handle);
                return;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                LinuxImports.dlclose(handle);
                return;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                MacOSImports.dlclose(handle);
                return;
            }

            throw new Exception("Unsupported OS.");
        }

        private static string GetLibraryPath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                    return Path.Combine("lib", "windows", "lib_x86_64", "sunvox.dll");
                if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                    return Path.Combine("lib", "windows", "lib_x86", "sunvox.dll");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
                    return Path.Combine("lib", "linux", "lib_arm64", "sunvox.so");
                if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                    return Path.Combine("lib", "linux", "lib_x86_64", "sunvox.so");
                if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                    return Path.Combine("lib", "linux", "lib_x86", "sunvox.so");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
                    return Path.Combine("lib", "macos", "lib_arm64", "sunvox.dylib");
                if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                    return Path.Combine("lib", "macos", "lib_x86_64", "sunvox.dylib");
            }
            throw new Exception("Unsupported OS.");
        }

        #endregion platform invoke

        private static object _lock = new object();
        private static IntPtr LoadedLibraryHandle;
        private static ProxyClass proxyClass;

        public static void LoadLibrary()
        {
            lock (_lock)
            {
                if (LoadedLibraryHandle == IntPtr.Zero)
                    LoadedLibraryHandle = LoadLibrary(GetLibraryPath());
            }
        }

        public static ISunVoxLib GetLibrary()
        {
            lock (_lock)
            {
                if (LoadedLibraryHandle == IntPtr.Zero)
                    throw new Exception();

                if (proxyClass == null)
                {
                    proxyClass = new ProxyClass(GetDelegateFromName);
                }
                return proxyClass;
            }
        }

        public static void UnloadLibrary()
        {
            lock (_lock)
            {
                if (LoadedLibraryHandle != IntPtr.Zero)
                    UnloadLibrary(LoadedLibraryHandle);
                else
                    throw new Exception();
            }
        }

        private static Delegate GetDelegateFromName(string name, Type delegateType)
        {
            var ptr = FindFunction(LoadedLibraryHandle, name);
            if (ptr == IntPtr.Zero)
                throw new Exception($"Symbol {name} not found! Library: {GetLibraryPath()}.");
            return Marshal.GetDelegateForFunctionPointer(ptr, delegateType);
        }
    }
}
