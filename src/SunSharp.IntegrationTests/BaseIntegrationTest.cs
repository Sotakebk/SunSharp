using System.Runtime.CompilerServices;
using SunSharp.Diagnostics;
using SunSharp.Native;
using SunSharp.Redistribution;

namespace SunSharp.IntegrationTests;

public abstract class BaseIntegrationTest
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
        _libc = SunVoxLibraryLoader.Load();
    }

    [OneTimeTearDown]
    protected virtual void OneTimeTearDown()
    {
        SunVoxLibraryLoader.Unload();
    }

    [SetUp]
    protected virtual void SetUp()
    {
        try
        {
            Lib = new SunVoxLib(new SunVoxLibWithLogger(_libc!, new ConsoleLogger()));
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
            try
            {
                Lib.Deinitialize();
            }
            catch (SunVoxException)
            {
            }
        }
    }

    protected string GetTestPath([CallerFilePath] string path = "")
    {
        return System.IO.Path.GetDirectoryName(path) ?? string.Empty;
    }
}
