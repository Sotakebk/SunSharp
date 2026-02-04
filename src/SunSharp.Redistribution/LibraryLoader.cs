using System;
using System.IO;
using System.Runtime.InteropServices;
using SunSharp.Native;
using SunSharp.Native.Loader;

namespace SunSharp.Redistribution
{
    /// <summary>
    /// Use this class to load and manage a SunVoxLib instance.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="Load" /> the library to use it through the preferred wrapper.
    /// After that, you may either use the returned instance, or construct a <see cref="SunSharp.SunVox" /> instance with it.
    /// </para>
    /// <para>
    /// If the library is already loaded, calling <see cref="Load" /> again will have no effect.
    /// </para>
    /// <para>
    /// You may also call <see cref="Unload" /> to unload the library, which should also deinitialize the library to avoid
    /// any memory leaks. You should keep the same library instance loaded in most use-cases.
    /// </para>
    /// </remarks>
    public static class LibraryLoader
    {
        private static readonly object Lock = new object();

        private static NativeProxy? _proxy;

        private static ILibraryHandler GetPlatformSpecificLibraryHandler()
        {
            var errorMessage =
                $"Current platform and architecture not supported. Architecture: '{RuntimeInformation.ProcessArchitecture}', platform: '{RuntimeInformation.OSDescription}'";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var path = RuntimeInformation.ProcessArchitecture switch
                {
                    Architecture.X64 => Path.Combine(AppContext.BaseDirectory, "runtimes/win-x64/native/sunvox.dll"),
                    Architecture.X86 => Path.Combine(AppContext.BaseDirectory, "runtimes/win-x86/native/sunvox.dll"),
                    _ => throw new PlatformNotSupportedException(errorMessage)
                };

                if(!File.Exists(path))
                {
                    throw new DllNotFoundException($"The SunVox library was not found at the expected location: {path}");
                }

                return new WindowsLibraryHandler(path);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var path = RuntimeInformation.ProcessArchitecture switch
                {
                    Architecture.X64 => Path.Combine(AppContext.BaseDirectory, "runtimes/linux-x64/native/sunvox.so"),
                    Architecture.X86 => Path.Combine(AppContext.BaseDirectory, "runtimes/linux-x86/native/sunvox.so"),
                    Architecture.Arm => Path.Combine(AppContext.BaseDirectory, "runtimes/linux-arm/native/sunvox.so"),
                    Architecture.Arm64 => Path.Combine(AppContext.BaseDirectory, "runtimes/linux-arm64/native/sunvox.so"),
                    _ => throw new PlatformNotSupportedException(errorMessage)
                };

                if (!File.Exists(path))
                {
                    throw new DllNotFoundException($"The SunVox library was not found at the expected location: {path}");
                }

                return new LinuxLibraryHandler(path);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                var path = RuntimeInformation.ProcessArchitecture switch
                {
                    Architecture.X64 => Path.Combine(AppContext.BaseDirectory, "runtimes/osx-x64/native/sunvox.dylib"),
                    Architecture.Arm64 => Path.Combine(AppContext.BaseDirectory, "runtimes/osx-arm64/native/sunvox.dylib"),
                    _ => throw new PlatformNotSupportedException(errorMessage)
                };

                if (!File.Exists(path))
                {
                    throw new DllNotFoundException($"The SunVox library was not found at the expected location: {path}");
                }

                return new MacOsLibraryLoader(path);
            }

            throw new PlatformNotSupportedException(errorMessage);
        }

        /// <exception cref="LibraryLoadingException">Thrown when the library fails to load.</exception>
        public static ISunVoxLibC Load()
        {
            lock (Lock)
            {
                if (_proxy == null)
                {
                    var handler = GetPlatformSpecificLibraryHandler();
                    _proxy = new NativeProxy(handler);
                }

                _proxy.Load();

                return _proxy;
            }
        }

        public static void Unload()
        {
            lock (Lock)
            {
                _proxy?.Unload();
            }
        }
    }
}
