using System.Runtime.CompilerServices;
using SunSharp.Native;
using SunSharp.Redistribution;

namespace SunSharp.IntegrationTests;

public abstract class BaseIntegrationTests
{
    private ISunVoxLib? _lib;

    protected ISunVoxLib GetLoadedLibrary()
    {
        return _lib ?? throw new InvalidOperationException();
    }

    [OneTimeSetUp]
    protected virtual void OneTimeSetUp()
    {
        LibraryLoader.Load();
        _lib = LibraryLoader.GetLibraryInstance();
    }

    [OneTimeTearDown]
    protected virtual void OneTimeTearDown()
    {
        LibraryLoader.Unload();
    }

    [SetUp]
    protected virtual void SetUp()
    {
        try
        {
            _lib = LibraryLoader.GetLibraryInstance();
            _lib.Initialize(-1, options: SunVoxInitOptions.UserAudioCallback | SunVoxInitOptions.AudioFloat32);
        }
        catch (Exception e)
        {
            TestContext.Out.WriteLine(e);
            throw;
        }
    }

    [TearDown]
    protected virtual void TearDown()
    {
        try
        {
            var log = _lib?.GetLog(0x10000);
            TestContext.Out.WriteLine(log);
        }
        finally
        {
            _lib?.Deinitialize();
            _lib = null;
        }
    }

    protected string GetTestPath([CallerFilePath] string path = "")
    {
        return System.IO.Path.GetDirectoryName(path) ?? string.Empty;
    }
}
