using System;
using System.Runtime.InteropServices;
using SunSharp.Native.Loader;

namespace SunSharp.Redistribution
{
    internal abstract class LibraryHandlerBase : ILibraryHandler
    {
        private readonly object _lock = new object();
        private volatile IntPtr _ptr = IntPtr.Zero;

        protected LibraryHandlerBase(string path)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        private readonly string _path;
        protected string Path => _path;
        protected object Lock => _lock;
        protected IntPtr Handle
        {
            get => _ptr;
            set => _ptr = value;
        }

        public bool IsLibraryLoaded => _ptr != IntPtr.Zero;

        public abstract void LoadLibrary();
        public abstract void UnloadLibrary();

        public Delegate GetFunctionByName(string name, Type delegateType)
        {
            ValidateDelegateType(delegateType);

            lock (_lock)
            {
                if (!IsLibraryLoaded)
                {
                    throw new LibraryLoadingException("SunVoxLib is not loaded.");
                }

                var ptr = GetFunctionPointer(_ptr, name);
                if (ptr != IntPtr.Zero)
                {
                    return Marshal.GetDelegateForFunctionPointer(ptr, delegateType);
                }

                throw CreateFunctionLoadException(name);
            }
        }

        protected abstract IntPtr GetFunctionPointer(IntPtr handle, string name);
        protected abstract Exception CreateFunctionLoadException(string name);

        private static void ValidateDelegateType(Type delegateType)
        {
            if (!typeof(Delegate).IsAssignableFrom(delegateType))
            {
                throw new ArgumentException($"Type {delegateType.Name} is not a delegate type");
            }
        }
    }
}
