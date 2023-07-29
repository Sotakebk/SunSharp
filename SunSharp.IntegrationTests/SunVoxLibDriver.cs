using System;
using SunSharp.Redistribution;

namespace SunSharp.IntegrationTests
{
    public class SunVoxLibDriver : IDisposable
    {
        public ISunVoxLib Library { get; set; }

        public SunVoxLibDriver()
        {
            LibraryLoader.Load();
            Library = LibraryLoader.GetLibraryInstance();
        }

        private void ReleaseUnmanagedResources()
        {
            if (LibraryLoader.IsLoaded)
                LibraryLoader.Unload();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~SunVoxLibDriver()
        {
            ReleaseUnmanagedResources();
        }
    }
}
