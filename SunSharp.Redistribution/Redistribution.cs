using System;
using System.IO;
using System.Runtime.InteropServices;
using SunSharp.LibraryLoading;

namespace SunSharp.Redistribution
{
    public static class LibraryLoader
    {
        #region platform invoke

#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

        private static class WindowsImports
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadLibrary(string dllToLoad);

            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern bool FreeLibrary(IntPtr hModule);
        }

        private static class LinuxImports
        {
            [DllImport("libdl.so", CharSet = CharSet.Ansi)]
            public static extern IntPtr dlopen(string filename, int flags);

            [DllImport("libdl.so", CharSet = CharSet.Ansi)]
            public static extern IntPtr dlsym(IntPtr handle, string symbol);

            [DllImport("libdl.so", CharSet = CharSet.Ansi)]
            public static extern int dlclose(IntPtr hModule);
        }

        private static class MacOSImports
        {
            [DllImport("libdl.so", CharSet = CharSet.Ansi)]
            public static extern IntPtr dlopen(string fileName, int flags);

            [DllImport("libdl.so", CharSet = CharSet.Ansi)]
            public static extern IntPtr dlsym(IntPtr handle, string symbol);

            [DllImport("libdl.so", CharSet = CharSet.Ansi)]
            public static extern int dlclose(IntPtr handle);
        }

#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments

        private static IntPtr LoadLibrary(string filename)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return WindowsImports.LoadLibrary(filename);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LinuxImports.dlopen(filename, 0);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return MacOSImports.dlopen(filename, 0);

            throw new InvalidOperationException("Unsupported OS.");
        }

        private static IntPtr FindFunction(IntPtr handle, string symbol)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return WindowsImports.GetProcAddress(handle, symbol);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LinuxImports.dlsym(handle, symbol);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return MacOSImports.dlsym(handle, symbol);

            throw new InvalidOperationException("Unsupported OS.");
        }

        private static void UnloadLibrary(IntPtr handle)
        {
            int returnCode;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                returnCode = (WindowsImports.FreeLibrary(handle) ? 0 : 1);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                returnCode = LinuxImports.dlclose(handle);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                returnCode = MacOSImports.dlclose(handle);
            else
                throw new InvalidOperationException("Unsupported OS.");

            if (returnCode != 0)
                throw new InvalidOperationException($"UnloadLibrary failed, code: {returnCode}");
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

            throw new InvalidOperationException("Unsupported OS.");
        }

        #endregion platform invoke

        private static readonly object Lock = new object();
        private static IntPtr _loadedLibraryHandle = IntPtr.Zero;
        private static ProxyClass? _proxyClass;

        public static void LoadLibrary()
        {
            lock (Lock)
            {
                if (_loadedLibraryHandle != IntPtr.Zero)
                    return;

                var path = GetLibraryPath();
                if (!File.Exists(path))
                    throw new InvalidOperationException($"Library at location \"{path}\" does not exist.");

                _loadedLibraryHandle = LoadLibrary(path);
                if (_loadedLibraryHandle == IntPtr.Zero)
                    throw new InvalidOperationException("LoadLibrary failed.");
            }
        }

        public static ISunVoxLib GetLibrary()
        {
            lock (Lock)
            {
                if (_loadedLibraryHandle == IntPtr.Zero)
                    throw new InvalidOperationException("Library is not loaded yet.");

                return _proxyClass ??= new ProxyClass(GetDelegateFromName);
            }
        }

        public static void UnloadLibrary()
        {
            lock (Lock)
            {
                if (_loadedLibraryHandle != IntPtr.Zero)
                    UnloadLibrary(_loadedLibraryHandle);
            }
        }

        private static Delegate GetDelegateFromName(string name, Type delegateType)
        {
            var ptr = FindFunction(_loadedLibraryHandle, name);
            if (ptr == IntPtr.Zero)
                throw new InvalidOperationException($"Symbol {name} not found! Library: {GetLibraryPath()}.");
            return Marshal.GetDelegateForFunctionPointer(ptr, delegateType);
        }
    }
}
