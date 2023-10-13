﻿using System;
using NUnit.Framework;
using SunSharp.Redistribution;

namespace SunSharp.IntegrationTests;

public class BaseIntegrationTests
{
    private ISunVoxLib? _lib;

    protected ISunVoxLib GetLoadedLibrary()
    {
        return _lib ?? throw new InvalidOperationException();
    }

    [OneTimeSetUp]
    protected void OneTimeSetUp()
    {
        LibraryLoader.Load();
        _lib = LibraryLoader.GetLibraryInstance();
    }

    [OneTimeTearDown]
    protected void OneTimeTearDown()
    {
        LibraryLoader.Unload();
    }

    [SetUp]
    protected void SetUp()
    {
        try
        {
            _lib = LibraryLoader.GetLibraryInstance();
            _lib.Initialize(-1, flags: InitFlags.UserAudioCallback | InitFlags.AudioFloat32);
        }
        catch (Exception e)
        {
            TestContext.WriteLine(e);
        }
    }

    [TearDown]
    protected void TearDown()
    {
        try
        {
            try
            {
                var log = _lib?.GetLog(0x10000);
                TestContext.WriteLine(log);
            }
            finally
            {
                _lib?.Deinitialize();
                _lib = null;
            }
        }
        catch (Exception e)
        {
            TestContext.WriteLine(e);
        }
    }
}
