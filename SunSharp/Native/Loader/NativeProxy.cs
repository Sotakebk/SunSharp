using System;
using System.Runtime.CompilerServices;

namespace SunSharp.Native.Loader
{
    /// <summary>
    /// Provides a thread-safe proxy for loading and managing native library function delegates.
    /// </summary>
    public sealed partial class NativeProxy : ISunVoxLibC
    {
        private readonly ILibraryHandler _handler;

        private readonly object _lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeProxy"/> class.
        /// </summary>
        /// <param name="handler">The library handler responsible for loading and unloading the native library.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="handler"/> is <see langword="null"/>.
        /// </exception>
        public NativeProxy(ILibraryHandler handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        /// <summary>
        /// Whether the proxy has loaded all function delegates from the native library.
        /// </summary>
        public bool IsProxyLoaded { get; private set; }

        /// <summary>
        /// Whether the underlying native library is currently loaded.
        /// </summary>
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
        /// Whether the proxy is fully ready to use, i.e., both the native library and all function delegates are loaded.
        /// </summary>
        public bool IsReady
        {
            get
            {
                lock (_lock)
                {
                    return IsProxyLoaded && _handler.IsLibraryLoaded;
                }
            }
        }

        /// <summary>
        /// Returns the current instance as an object implementing the ISunVoxLibC interface.
        /// </summary>
        public ISunVoxLibC AsNativeLibrary() => this;

        /// <summary>
        /// Loads the native library if necessary and initializes all function delegates.
        /// </summary>
        /// <exception cref="AggregateException">Thrown when both loading and cleanup fail.</exception>
        /// <remarks>
        /// This operation is thread-safe and idempotent. If both the library and proxy are already loaded,
        /// this method returns immediately.
        /// </remarks>
        public void Load()
        {
            lock (_lock)
            {
                if (IsProxyLoaded && _handler.IsLibraryLoaded)
                {
                    // don't need to do anything
                    return;
                }

                try
                {
                    if (IsProxyLoaded)
                    {
                        // library got unloaded somehow, so we need to unload the delegates too
                        IsProxyLoaded = false;
                        SetAllDelegatesToNull();
                    }

                    if (!_handler.IsLibraryLoaded)
                    {
                        _handler.LoadLibrary();
                    }
                    FetchAndAssignDelegates();
                    IsProxyLoaded = true;
                }
                catch (Exception ex)
                {
                    // null delegates before unloading the library to avoid inconsistent state
                    // this way, in multithreaded scenarios, we prevent memory access violations
                    IsProxyLoaded = false;
                    SetAllDelegatesToNull();
                    try
                    {
                        if (_handler.IsLibraryLoaded)
                        {
                            _handler.UnloadLibrary();
                        }
                    }
                    catch (Exception ex1)
                    {
                        throw new AggregateException("Failed to load native library and initialize delegates. Additionally, unloading the library also failed.", ex, ex1);
                    }
                    throw;
                }
            }
        }

        /// <summary>
        /// Deinitializes the SunVox engine, unloads all function delegates, and unloads the native library if loaded.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This operation is thread-safe. Delegates are set to null before calling <see cref="ISunVoxLibC.sv_deinit"/> to prevent access from other threads.
        /// </para>
        /// <para>
        /// This method passes exceptions thrown during deinitialization or unloading to the caller. This requires careful handling, as there is risk of unmanaged resources not being released properly. If <see cref="ISunVoxLibC.sv_deinit"/> fails, the issue may be unrecoverable.
        /// </para>
        /// </remarks>
        public void Unload()
        {
            lock (_lock)
            {
                // null delegates before unloading the library to avoid inconsistent state
                // this way, in multithreaded scenarios, we prevent memory access violations
                var deinitDelegate = sv_deinit;
                IsProxyLoaded = false;
                SetAllDelegatesToNull(); // makes sure that all delegates are null, regardless of previous state

                // at this point other threads cannot call delegates anymore
                // if possible, deinitialize sunvox first
                bool isLibraryLoaded = _handler.IsLibraryLoaded;
                if (deinitDelegate != null && isLibraryLoaded)
                {
                    // value may be 0 if successful or -1 if already deinitialized
                    // ignoring return value as there is nothing we can do about it here
                    deinitDelegate.Invoke();
                }

                if (isLibraryLoaded)
                {
                    _handler.UnloadLibrary();
                }
            }
        }

        internal Exception GetNoDelegateException([CallerMemberName] string name = "")
        {
            string message;
            try
            {
                lock (_lock)
                {
                    var isLibraryLoaded = _handler.IsLibraryLoaded;
                    var isProxyLoaded = IsProxyLoaded;
                    message = (isLibraryLoaded, isProxyLoaded) switch
                    {
                        (true, true) => $"Missing delegate for function '{name}'. Library is loaded, proxy is loaded.",
                        (true, false) => $"Missing delegate for function '{name}'. Library is loaded, proxy is not loaded.",
                        (false, true) => $"Missing delegate for function '{name}'. Library is not loaded, proxy is loaded.",
                        (false, false) => $"Missing delegate for function '{name}'. Library is not loaded, proxy is not loaded."
                    };
                }
            }
            catch (Exception ex)
            {
                return new InvalidOperationException("Missing delegate. Library state is unknown.", ex);
            }

            return new InvalidOperationException(message);
        }

        private T GetDelegateOrThrow<T>(string name)
            where T : Delegate
        {
            return (T)_handler.GetFunctionByName(name, typeof(T)) ?? throw new InvalidOperationException($"Failed to load function '{name}'.");
        }
    }
}
