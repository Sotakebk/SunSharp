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
    /// <see cref="Load" /> the library once, then <see cref="GetLibraryInstance" />.
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
        private static ISunVoxLib? _lib;

        public static bool IsLoaded => _proxy?.IsLoaded ?? false;

        private static ILibraryHandler GetPlatformSpecificLibraryHandler()
        {
            var errorMessage =
                $"Current platform and architecture not supported. Architecture: '{RuntimeInformation.ProcessArchitecture}', platform: '{RuntimeInformation.OSDescription}'";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var path = RuntimeInformation.ProcessArchitecture switch
                {
                    Architecture.X64 => Path.Combine(Environment.CurrentDirectory, "runtimes/win-x64/native/sunvox.dll"),
                    Architecture.X86 => Path.Combine(Environment.CurrentDirectory, "runtimes/win-x86-64/native/sunvox.dll"),
                    _ => throw new PlatformNotSupportedException(errorMessage)
                };

                return new WindowsLibraryHandler(path);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var path = RuntimeInformation.ProcessArchitecture switch
                {
                    Architecture.X64 => Path.Combine(Environment.CurrentDirectory, "runtimes/linux-x86-64/native/sunvox.so"),
                    Architecture.X86 => Path.Combine(Environment.CurrentDirectory, "runtimes/linux-x86/native/sunvox.so"),
                    Architecture.Arm64 => Path.Combine(Environment.CurrentDirectory, "runtimes/linux-arm64/native/sunvox.so"),
                    _ => throw new PlatformNotSupportedException(errorMessage)
                };

                return new UnixLibraryHandler(path);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                var path = RuntimeInformation.ProcessArchitecture switch
                {
                    Architecture.X64 => Path.Combine(Environment.CurrentDirectory, "runtimes/macos-x86-64/native/sunvox.so"),
                    Architecture.Arm64 => Path.Combine(Environment.CurrentDirectory, "runtimes/macos-arm64/native/sunvox.so"),
                    _ => throw new PlatformNotSupportedException(errorMessage)
                };

                return new UnixLibraryHandler(path);
            }

            throw new PlatformNotSupportedException(errorMessage);
        }

        public static void Load()
        {
            lock (Lock)
            {
                if (_proxy == null)
                {
                    var handler = GetPlatformSpecificLibraryHandler();
                    _proxy = new NativeProxy(handler);
                }

                _proxy.Load();
            }
        }

        public static ISunVoxLib GetLibraryInstance()
        {
            lock (Lock)
            {
                if (!IsLoaded || _proxy == null)
                    throw new InvalidOperationException("The library was not loaded yet.");

                return _lib ??= new SunVoxLibNativeWrapper(_proxy);
            }
        }

        public static void Unload()
        {
            lock (Lock)
            {
                if (!IsLoaded)
                    throw new InvalidOperationException("The library was not loaded yet.");
                _proxy?.Unload();
            }
        }
    }
}
