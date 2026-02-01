using System.Runtime.CompilerServices;
using SunSharp.Native;
using SunSharp.Redistribution;

namespace SunSharp.IntegrationTests;

public abstract class BaseIntegrationTests
{
    public ISunVoxLibC? _libc;
    public SunVoxLib Lib { get; protected set; }

    protected ISunVoxLibC GetLoadedLibrary()
    {
        return _libc ?? throw new InvalidOperationException();
    }

    [OneTimeSetUp]
    protected virtual void OneTimeSetUp()
    {
        _libc = LibraryLoader.Load();
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
            Lib = new SunVoxLib(_libc!);
            Lib.Initialize(-1, options: SunVoxInitOptions.UserAudioCallback | SunVoxInitOptions.AudioFloat32);
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
            var log = Lib.GetLog(0x10000);
            TestContext.Out.WriteLine(log);
        }
        finally
        {
            Lib.Deinitialize();
            _libc = null;
        }
    }

    protected string GetTestPath([CallerFilePath] string path = "")
    {
        return System.IO.Path.GetDirectoryName(path) ?? string.Empty;
    }
}
