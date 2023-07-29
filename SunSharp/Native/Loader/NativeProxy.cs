using System;

namespace SunSharp.Native.Loader
{
    public sealed partial class NativeProxy
    {
        public bool IsLoaded { get; private set; }

        private readonly object _lock = new object();
        private readonly ILibraryHandler _handler;

        public NativeProxy(ILibraryHandler handler)
        {
            _handler = handler;

            if (handler.IsLibraryLoaded)
                Load();
        }

        public void Load()
        {
            lock (_lock)
            {
                try
                {
                    if (!_handler.IsLibraryLoaded)
                        _handler.LoadLibrary();
                }
                catch (Exception)
                {
                    _handler.UnloadLibrary();
                    throw;
                }

                LoadInternal();
                IsLoaded = true;
            }
        }

        public void Unload()
        {
            lock (_lock)
            {
                UnloadInternal();
                _handler.UnloadLibrary();
                IsLoaded = false;
            }
        }

        private Exception GetNoDelegateException()
        {
            string message;
            try
            {
                lock (_lock)
                {
                    if (_handler.IsLibraryLoaded && IsLoaded)
                        message = "Missing delegate. Library is loaded, proxy is loaded.";
                    else if (_handler.IsLibraryLoaded && !IsLoaded)
                        message = "Missing delegate. Library is loaded, proxy is not loaded.";
                    else if (!_handler.IsLibraryLoaded && IsLoaded)
                        message = "Missing delegate. Library is not loaded, proxy is loaded.";
                    else if (!_handler.IsLibraryLoaded && !IsLoaded)
                        message = "Missing delegate. Library is not loaded, proxy is not loaded.";
                    else
                        message = "Missing delegate, and library status is unknown.";
                }
            }
            catch (Exception ex)
            {
                return new InvalidOperationException("Missing delegate. Library state is unknown.", ex);
            }

            return new InvalidOperationException(message);
        }
    }
}
