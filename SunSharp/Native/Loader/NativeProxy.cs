using System;

namespace SunSharp.Native.Loader
{
    public sealed partial class NativeProxy
    {
        private readonly ILibraryHandler _handler;

        private readonly object _lock = new object();

        public NativeProxy(ILibraryHandler handler)
        {
            _handler = handler;
        }

        public bool IsLoaded { get; private set; }

        public bool IsLibraryLoaded
        {
            get
            {
                lock (_lock)
                {
                    return _handler.IsLibraryLoaded;
                }
            }
        }

        /// <summary>
        /// Loads the library if necessary.
        /// Loads the library functions and sets the IsLoaded flag.
        /// Nothing will be done if the library and proxy were already loaded.
        /// </summary>
        public void Load()
        {
            lock (_lock)
            {
                if (IsLoaded && _handler.IsLibraryLoaded)
                    return;

                try
                {
                    if (!_handler.IsLibraryLoaded)
                    {
                        // make sure that all delegates are null, do so ASAP so we don't hard fail for any reason
                        // this should never matter... probably
                        UnloadInternal();

                        // library is loaded, so we need to reload those delegates
                        _handler.LoadLibrary();
                        LoadInternal();
                    }
                    else if (!IsLoaded)
                    {
                        LoadInternal();
                    }
                }
                catch (Exception)
                {
                    _handler.UnloadLibrary();
                    UnloadInternal();
                    throw;
                }

                IsLoaded = true;
            }
        }

        /// <summary>
        /// Unloads the SunVox engine if possible.
        /// Unloads the library functions and sets the IsLoaded flag.
        /// Unloads the library if possible.
        /// If an unexpected exception is thrown, it will be rethrown, as this is a potentially dangerous situation where
        /// memory was probably leaked.
        /// </summary>
        public void Unload()
        {
            lock (_lock)
            {
                var handlerIsLibraryLoader = _handler.IsLibraryLoaded;

                switch (IsLoaded)
                {
                    // nothing to unload
                    case false when !handlerIsLibraryLoader:
                        return;
                    // sunvox might need to be unloaded
                    case true when handlerIsLibraryLoader:
                        if (sv_deinit == null)
                        {
                            throw new InvalidOperationException($"{nameof(sv_deinit)} was null, but library and proxy are both loaded.");
                        }

                        sv_deinit.Invoke();
                        break;
                }

                // unload delegates if applies
                if (IsLoaded)
                {
                    UnloadInternal();
                    IsLoaded = false;
                }

                // unload library if applies
                if (handlerIsLibraryLoader)
                    _handler.UnloadLibrary();
            }
        }

        internal Exception GetNoDelegateException()
        {
            string message;
            try
            {
                lock (_lock)
                {
                    var isLibraryLoaded = _handler.IsLibraryLoaded;
                    var isProxyLoaded = IsLoaded;
                    message = (isLibraryLoaded, isProxyLoaded) switch
                    {
                        (true, true) => "Missing delegate. Library is loaded, proxy is loaded.",
                        (true, false) => "Missing delegate. Library is loaded, proxy is not loaded.",
                        (false, true) => "Missing delegate. Library is not loaded, proxy is loaded.",
                        (false, false) => "Missing delegate. Library is not loaded, proxy is not loaded."
                    };
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
