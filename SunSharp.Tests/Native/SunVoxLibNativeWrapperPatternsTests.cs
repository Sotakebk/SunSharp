using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NSubstitute;
using NUnit.Framework;
using SunSharp.Native;
using TddXt.AnyRoot;
using TddXt.AnyRoot.Collections;
using TddXt.AnyRoot.Numbers;
using TddXt.AnyRoot.Strings;
using static TddXt.AnyRoot.Root;

namespace SunSharp.Tests.Native;

public class SunVoxLibNativeWrapperPatternsTests
{
    public static PatternDataCase[] PatternDataCases => new[]
    {
        new PatternDataCase
        {
            CaseName = "simple call with equal size buffers",
            ToLines = 2,
            ToTracks = 3,
            FromLines = 2,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x3, 0x5,
                0x2, 0x4, 0x6
            },
            ToData = new PatternEvent[]
            {
                0x1, 0x3, 0x5,
                0x2, 0x4, 0x6
            },
            ExpectedOperationCount = 2 * 3
        },
        new PatternDataCase
        {
            CaseName = "simple call with original data buffer being bigger",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x1, 0x4,
                0x2, 0x5
            },
            ExpectedOperationCount = 2 * 2
        },
        new PatternDataCase
        {
            CaseName = "simple call with original data buffer being smaller",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 2,
            FromTracks = 2,
            FromData = new PatternEvent[]
            {
                0x1, 0x4,
                0x2, 0x5
            },
            ToData = new PatternEvent[]
            {
                0x1, 0x4, 0x0,
                0x2, 0x5, 0x0,
                0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 2 * 2
        },
        new PatternDataCase
        {
            CaseName = "call with maxLines and maxTracks smaller than size",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x1, 0x4, 0x0,
                0x2, 0x5, 0x0,
                0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 2 * 2,
            MaxLines = 2,
            MaxTracks = 2
        },
        new PatternDataCase
        {
            CaseName = "call with maxTracks set to zero",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 0,
            MaxTracks = 0
        },
        new PatternDataCase
        {
            CaseName = "call with MaxLines set to zero",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 0,
            MaxLines = 0
        },
        new PatternDataCase
        {
            CaseName = "call with maxTracks and maxLines set to zero",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 0,
            MaxLines = 0,
            MaxTracks = 0
        },
        new PatternDataCase
        {
            CaseName = "call with source data being empty",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 0,
            FromTracks = 0,
            FromData = Array.Empty<PatternEvent>(),
            ToData = new PatternEvent[]
            {
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 0
        },
        new PatternDataCase
        {
            CaseName = "call with target data being empty",
            ToLines = 0,
            ToTracks = 0,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = Array.Empty<PatternEvent>(),
            ExpectedOperationCount = 0
        },
        new PatternDataCase
        {
            CaseName = "call with target buffer offset lines",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0, 0x0,
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8
            },
            ExpectedOperationCount = 2 * 3,
            TargetOffsetLines = 1
        },
        new PatternDataCase
        {
            CaseName = "call with target buffer offset tracks",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x1, 0x4,
                0x0, 0x2, 0x5,
                0x0, 0x3, 0x6
            },
            ExpectedOperationCount = 2 * 3,
            TargetOffsetTracks = 1
        },
        new PatternDataCase
        {
            CaseName = "call with target buffer offset tracks and lines",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0, 0x0,
                0x0, 0x1, 0x4,
                0x0, 0x2, 0x5
            },
            ExpectedOperationCount = 2 * 2,
            TargetOffsetTracks = 1,
            TargetOffsetLines = 1
        },
        new PatternDataCase
        {
            CaseName = "call with source offset lines",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9,
                0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 2 * 3,
            SourceOffsetLines = 1
        },
        new PatternDataCase
        {
            CaseName = "call with source offset tracks",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x4, 0x7, 0x0,
                0x5, 0x8, 0x0,
                0x6, 0x9, 0x0
            },
            ExpectedOperationCount = 2 * 3,
            SourceOffsetTracks = 1
        },
        new PatternDataCase
        {
            CaseName = "call with source offset tracks and lines",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData = new PatternEvent[]
            {
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            },
            ToData = new PatternEvent[]
            {
                0x5, 0x8, 0x0,
                0x6, 0x9, 0x0,
                0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 2 * 2,
            SourceOffsetTracks = 1,
            SourceOffsetLines = 1
        },
        new PatternDataCase
        {
            CaseName = "call with source offset real tracks and lines, and target offset tracks and lines",
            ToLines = 4,
            ToTracks = 4,
            FromLines = 4,
            FromTracks = 4,
            FromData = new PatternEvent[]
            {
                0x1, 0x6, 0xA, 0xE,
                0x2, 0x7, 0xB, 0xF,
                0x3, 0x8, 0xC, 0x10,
                0x4, 0x9, 0xD, 0x11
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0, 0x0, 0x0,
                0x0, 0x7, 0xB, 0xF,
                0x0, 0x8, 0xC, 0x10,
                0x0, 0x9, 0xD, 0x11
            },
            ExpectedOperationCount = 3 * 3,
            SourceOffsetTracks = 1,
            SourceOffsetLines = 1,
            TargetOffsetTracks = 1,
            TargetOffsetLines = 1
        },
        new PatternDataCase
        {
            CaseName =
                "call with source offset real tracks and lines, and target offset tracks and lines, and max tracks and lines",
            ToLines = 4,
            ToTracks = 4,
            FromLines = 4,
            FromTracks = 4,
            FromData = new PatternEvent[]
            {
                0x1, 0x6, 0xA, 0xE,
                0x2, 0x7, 0xB, 0xF,
                0x3, 0x8, 0xC, 0x10,
                0x4, 0x9, 0xD, 0x11
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0, 0x0, 0x0,
                0x0, 0x7, 0xB, 0x0,
                0x0, 0x8, 0xC, 0x0,
                0x0, 0x0, 0x0, 0x0
            },
            ExpectedOperationCount = 2 * 2,
            SourceOffsetTracks = 1,
            SourceOffsetLines = 1,
            TargetOffsetTracks = 1,
            TargetOffsetLines = 1,
            MaxLines = 2,
            MaxTracks = 2
        },
        new PatternDataCase
        {
            CaseName = "call with target track offset being greater than size",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 2,
            FromTracks = 2,
            FromData = new PatternEvent[]
            {
                0x1, 0x6,
                0x2, 0x7
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0,
                0x0, 0x0
            },
            ExpectedOperationCount = 0,
            TargetOffsetTracks = 2
        },
        new PatternDataCase
        {
            CaseName = "call with target line offset being greater than size",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 2,
            FromTracks = 2,
            FromData = new PatternEvent[]
            {
                0x1, 0x6,
                0x2, 0x7
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0,
                0x0, 0x0
            },
            ExpectedOperationCount = 0,
            TargetOffsetLines = 2
        },
        new PatternDataCase
        {
            CaseName = "call with source line offset being greater than size",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 2,
            FromTracks = 2,
            FromData = new PatternEvent[]
            {
                0x1, 0x6,
                0x2, 0x7
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0,
                0x0, 0x0
            },
            ExpectedOperationCount = 0,
            SourceOffsetLines = 2
        },
        new PatternDataCase
        {
            CaseName = "call with source line offset being greater than size",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 2,
            FromTracks = 2,
            FromData = new PatternEvent[]
            {
                0x1, 0x6,
                0x2, 0x7
            },
            ToData = new PatternEvent[]
            {
                0x0, 0x0,
                0x0, 0x0
            },
            ExpectedOperationCount = 0,
            SourceOffsetTracks = 2
        }
    };

    [Test]
    public void CloneModuleShouldThrowOnNegativeReturnedValue()
    {
        var originalPatternId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.ClonePattern(slotId, originalPatternId, x, y),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_new_pattern(slotId, originalPatternId, x, y, -1, -1, -1, IntPtr.Zero);
    }

    [Test]
    public void ClonePatternShouldCallExpectedMethod()
    {
        var newPatternId = Any.Integer();
        var originalPatternId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(newPatternId);

        // when
        var value = wrapper.ClonePattern(slotId, originalPatternId, x, y);

        // then
        library.Received(1).sv_new_pattern(slotId, originalPatternId, x, y, -1, -1, -1, IntPtr.Zero);
        Assert.That(value, Is.EqualTo(newPatternId));
    }

    [Test]
    public void CreateModuleShouldThrowOnNegativeReturnedValue()
    {
        var patternName = Any.String();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();
        var tracks = Any.Integer();
        var lines = Any.Integer();
        var iconSeed = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.CreatePattern(slotId, x, y, tracks, lines, iconSeed, patternName),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_new_pattern(slotId, -1, x, y, tracks, lines, iconSeed, Arg.Any<IntPtr>());
    }

    [Test]
    public void CreatePatternShouldCallExpectedMethod()
    {
        var newPatternId = Any.Integer();
        var patternName = Any.String();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();
        var tracks = Any.Integer();
        var lines = Any.Integer();
        var iconSeed = Any.Integer();
        var receivedPatternName = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(newPatternId);
        library.When(static l => l.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => { receivedPatternName = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()); });

        // when
        var value = wrapper.CreatePattern(slotId, x, y, tracks, lines, iconSeed, patternName);

        // then
        library.Received(1).sv_new_pattern(slotId, -1, x, y, tracks, lines, iconSeed, Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(newPatternId));
            Assert.That(receivedPatternName, Is.EqualTo(patternName));
        });
    }

    [Test]
    public void CreatePatternShouldCallExpectedMethodWithDefaultValues()
    {
        var newPatternId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();
        var tracks = Any.Integer();
        var lines = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(newPatternId);

        // when
        var value = wrapper.CreatePattern(slotId, x, y, tracks, lines);

        // then
        library.Received(1).sv_new_pattern(slotId, -1, x, y, tracks, lines, 0, IntPtr.Zero);
        Assert.That(value, Is.EqualTo(newPatternId));
    }

    [Test]
    public void FindPatternShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var foundPatternId = Any.Integer();
        library.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(foundPatternId);
        var patternName = Any.String();
        var receivedString = string.Empty;
        var slotId = Any.Integer();
        library.When(static l => l.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.FindPattern(slotId, patternName);

        // then
        library.Received(1).sv_find_pattern(slotId, Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(foundPatternId));
            Assert.That(receivedString, Is.EqualTo(patternName));
        });
    }

    [Test]
    public void FindPatternShouldCallExpectedMethodAndReturnNullWhenPatternNotFound()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);
        var patternName = Any.String();
        var receivedString = string.Empty;
        var slotId = Any.Integer();
        library.When(static l => l.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.FindPattern(slotId, patternName);

        // then
        library.Received(1).sv_find_pattern(slotId, Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(null));
            Assert.That(receivedString, Is.EqualTo(patternName));
        });
    }

    [Test]
    public void FindPatternShouldCallExpectedMethodAndThrowOnReturnCodeLessThanNegativeOne()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-2);
        var patternName = Any.String();
        var slotId = Any.Integer();

        // when
        Assert.That(() => wrapper.FindPattern(slotId, patternName), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_find_pattern(slotId, Arg.Any<IntPtr>());
    }

    [Test]
    public void GetPatternEventValueShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        var track = Any.Integer();
        var line = Any.Integer();
        var column = Any.Instance<Column>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(0);

        // when
        wrapper.GetPatternEventValue(slotId, patternId, track, line, column);

        // then
        library.Received(1).sv_get_pattern_event(slotId, patternId, track, line, (int)column);
    }

    [Test]
    public void GetPatternEventValueShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        var track = Any.Integer();
        var line = Any.Integer();
        var column = Any.Instance<Column>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.GetPatternEventValue(slotId, patternId, track, line, column),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_pattern_event(slotId, patternId, track, line, (int)column);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void GetPatternExistsShouldCallExpectedMethodAndReturnValue(bool exists)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(exists ? 1 : 0);

        // when
        var receivedExists = wrapper.GetPatternExists(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        Assert.That(receivedExists, Is.EqualTo(exists));
    }

    [Test]
    public void GetPatternExistsShouldThrowOnErrorReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.GetPatternExists(slotId, patternId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
    }

    [Test]
    public void GetPatternLinesShouldCallExpectedMethodAndReturnValue()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var lines = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(lines);

        // when
        var receivedLines = wrapper.GetPatternLines(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        Assert.That(receivedLines, Is.EqualTo(lines));
    }

    [Test]
    public void GetPatternLinesShouldThrowOnErrorReturnCode()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.GetPatternLines(slotId, patternId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
    }

    [Test]
    public void GetPatternNameShouldCallExpectedMethodAndReturnNullWhenNullPointer()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_pattern_name(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var receivedPatternName = wrapper.GetPatternName(slotId, patternId);
        // then
        library.Received(1).sv_get_pattern_name(slotId, patternId);
        Assert.That(receivedPatternName, Is.EqualTo(null));
    }

    [Test]
    public void GetPatternNameShouldCallExpectedMethodAndReturnString()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var patternName = Any.String();
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var stringPointer = IntPtr.Zero;
        string? receivedPatternName;

        try
        {
            stringPointer = Marshal.StringToHGlobalAnsi(patternName);
            library.sv_get_pattern_name(Arg.Any<int>(), Arg.Any<int>()).Returns(stringPointer);

            // when
            receivedPatternName = wrapper.GetPatternName(slotId, patternId);
        }
        finally
        {
            Marshal.FreeHGlobal(stringPointer);
        }

        // then
        library.Received(1).sv_get_pattern_name(slotId, patternId);
        Assert.That(receivedPatternName, Is.EqualTo(patternName));
    }

    [Test]
    public void GetPatternPositionShouldCallExpectedMethodsAndReturnValue()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_x(Arg.Any<int>(), Arg.Any<int>()).Returns(x);
        library.sv_get_pattern_y(Arg.Any<int>(), Arg.Any<int>()).Returns(y);

        // when
        var value = wrapper.GetPatternPosition(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_x(slotId, patternId);
        library.Received(1).sv_get_pattern_y(slotId, patternId);
        Assert.That(value, Is.EqualTo((x, y)));
    }

    [Test]
    public void GetPatternTracksShouldCallExpectedMethodAndReturnValue()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var tracks = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(tracks);

        // when
        var receivedLines = wrapper.GetPatternTracks(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
        Assert.That(receivedLines, Is.EqualTo(tracks));
    }

    [Test]
    public void GetPatternTracksShouldThrowOnErrorReturnCode()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.GetPatternTracks(slotId, patternId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
    }

    [Test]
    public void GetPatternXShouldCallExpectedMethodsAndReturnValue()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_x(Arg.Any<int>(), Arg.Any<int>()).Returns(x);

        // when
        var value = wrapper.GetPatternX(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_x(slotId, patternId);
        Assert.That(value, Is.EqualTo(x));
    }

    [Test]
    public void GetPatternYShouldCallExpectedMethodsAndReturnValue()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var y = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_y(Arg.Any<int>(), Arg.Any<int>()).Returns(y);

        // when
        var value = wrapper.GetPatternY(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_y(slotId, patternId);
        Assert.That(value, Is.EqualTo(y));
    }

    [Test]
    public void GetUpperPatternCountShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_patterns(Arg.Any<int>()).Returns(0);

        // when
        wrapper.GetUpperPatternCount(slotId);

        // then
        library.Received(1).sv_get_number_of_patterns(slotId);
    }

    [Test]
    public void GetUpperPatternCountShouldCallExpectedMethodAndThrowOnNegativeReturnCode()
    {
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_patterns(Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.GetUpperPatternCount(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_number_of_patterns(slotId);
    }

    [Test]
    public void RemovePatternShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_remove_pattern(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.RemovePattern(slotId, patternId);

        // then
        library.Received(1).sv_remove_pattern(slotId, patternId);
    }

    [Test]
    public void RemovePatternShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_remove_pattern(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.RemovePattern(slotId, patternId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_remove_pattern(slotId, patternId);
    }

    [Test]
    public void SetPatternNameShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var nameToSet = Any.String();
        var receivedString = string.Empty;
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        library.When(static l => l.sv_set_pattern_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.SetPatternName(slotId, patternId, nameToSet);

        // then
        library.Received(1).sv_set_pattern_name(slotId, patternId, Arg.Any<IntPtr>());
        Assert.That(receivedString, Is.EqualTo(nameToSet));
    }

    [Test]
    public void SetPatternNameShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var nameToSet = Any.String();
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        library.sv_set_pattern_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetPatternName(slotId, patternId, nameToSet),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_pattern_name(slotId, patternId, Arg.Any<IntPtr>());
    }

    [Test]
    public void SetPatternPositionShouldCallExpectedMethodAndReturnValue()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_pattern_xy(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetPatternPosition(slotId, patternId, x, y);

        // then
        library.Received(1).sv_set_pattern_xy(slotId, patternId, x, y);
    }

    [Test]
    public void SetPatternPositionShouldThrowOnErrorReturnCode()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_pattern_xy(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetPatternPosition(slotId, patternId, x, y),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_pattern_xy(slotId, patternId, x, y);
    }

    [Test]
    public void SetPatternSizeShouldCallExpectedMethodAndReturnValue()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var lines = Any.Integer();
        var tracks = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetPatternSize(slotId, patternId, tracks, lines);

        // then
        library.Received(1).sv_set_pattern_size(slotId, patternId, tracks, lines);
    }

    [Test]
    public void SetPatternSizeShouldCallExpectedMethodWithDefaultValuesAndReturnValue()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_pattern_size(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetPatternSize(slotId, patternId);

        // then
        library.Received(1).sv_set_pattern_size(slotId, patternId, -1, -1);
    }

    [Test]
    public void SetPatternSizeShouldThrowOnErrorReturnCode()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var lines = Any.Integer();
        var tracks = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_pattern_size(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetPatternSize(slotId, patternId, tracks, lines),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_pattern_size(slotId, patternId, tracks, lines);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void GetPatternMutedShouldCallExpectedMethodAndReturnValue(bool muted)
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_pattern_mute(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(muted ? 1 : 0);

        // when
        var value = wrapper.GetPatternMuted(slotId, patternId);

        // then
        library.Received(1).sv_pattern_mute(slotId, patternId, -1);
        Assert.That(value, Is.EqualTo(muted));
    }

    [Test]
    public void GetPatternMutedShouldThrowOnErrorReturnCode()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_pattern_mute(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.GetPatternMuted(slotId, patternId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_pattern_mute(slotId, patternId, -1);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void SetPatternMutedShouldCallExpectedMethod(bool muted)
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_pattern_mute(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(Any.Boolean() ? 1 : 0);

        // when
        wrapper.SetPatternMuted(slotId, patternId, muted);

        // then
        library.Received(1).sv_pattern_mute(slotId, patternId, muted ? 1 : 0);
    }

    [Test]
    public void SetPatternMutedShouldThrowOnErrorReturnCode()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var muted = Any.Boolean();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_pattern_mute(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetPatternMuted(slotId, patternId, muted),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_pattern_mute(slotId, patternId, muted ? 1 : 0);
    }

    [Test]
    public void SetPatternEventShouldCallExpectedMethod()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var track = Any.Integer();
        var line = Any.Integer();
        var nn = Any.Integer();
        var vv = Any.Integer();
        var mm = Any.Integer();
        var ccee = Any.Integer();
        var xxyy = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(0);

        // when
        wrapper.SetPatternEvent(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);

        // then
        library.Received(1).sv_set_pattern_event(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);
    }

    [Test]
    public void SetPatternEventShouldThrowOnNonZeroReturnCode()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var track = Any.Integer();
        var line = Any.Integer();
        var nn = Any.Integer();
        var vv = Any.Integer();
        var mm = Any.Integer();
        var ccee = Any.Integer();
        var xxyy = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.SetPatternEvent(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_pattern_event(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);
    }

    [Test]
    public void SetPatternEventWithStructShouldCallExpectedMethod()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var track = Any.Integer();
        var line = Any.Integer();
        var patternEvent = Any.Instance<PatternEvent>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(0);

        // when
        wrapper.SetPatternEvent(slotId, patternId, track, line, patternEvent);

        // then
        library.Received(1).sv_set_pattern_event(slotId, patternId, track, line, patternEvent.NN, patternEvent.VV,
            patternEvent.MM, patternEvent.CCEE, patternEvent.XXYY);
    }

    [Test]
    public void SetPatternEventWithStructShouldThrowOnNonZeroReturnCode()
    {
        var patternId = Any.Integer();
        var slotId = Any.Integer();
        var track = Any.Integer();
        var line = Any.Integer();
        var patternEvent = Any.Instance<PatternEvent>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.SetPatternEvent(slotId, patternId, track, line, patternEvent),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_pattern_event(slotId, patternId, track, line, patternEvent.NN, patternEvent.VV,
            patternEvent.MM, patternEvent.CCEE, patternEvent.XXYY);
    }

    [Test]
    public void GetPatternDataReturnsDataAsExpected()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        const int lines = 4;
        const int tracks = 5;
        var receivedPatternData = Array.Empty<PatternEvent>();
        var receivedTracks = 0;
        var receivedLines = 0;

        var patternData = new PatternEvent[tracks * lines];
        for (var line = 0; line < lines; line++)
        for (var track = 0; track < tracks; track++)
            patternData[line * tracks + track] = new PatternEvent
            {
                CCEE = (ushort)line,
                XXYY = (ushort)track
            };

        var handle = GCHandle.Alloc(patternData, GCHandleType.Pinned);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(lines);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(tracks);
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(handle.AddrOfPinnedObject());

        try
        {
            // when
            var result = wrapper.GetPatternData(slotId, patternId);
            if (result != null)
                (receivedPatternData, receivedTracks, receivedLines) = result.Value;
        }
        finally
        {
            handle.Free();
        }
        // then

        Assert.That(receivedPatternData, Is.Not.EquivalentTo(Array.Empty<PatternEvent>()));
        Assert.That(receivedPatternData, Has.Length.EqualTo(receivedTracks * receivedLines));
        Assert.That(receivedPatternData, Is.EquivalentTo(patternData));
        library.Received(1).sv_get_pattern_data(slotId, patternId);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
    }

    [Test]
    public void GetPatternDataReturnsNullWhenLengthEqualsZero()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        // when
        var receivedPatternData = wrapper.GetPatternData(slotId, patternId);
        // then
        Assert.That(receivedPatternData, Is.Null);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>());
        library.Received(0).sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>());
    }

    [Test]
    public void GetPatternDataReturnsNullWhenPtrIsNullPtr()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        const int lines = 4;
        const int tracks = 5;

        var patternData = new PatternEvent[tracks * lines];
        for (var i = 0; i < tracks * lines; i++)
            patternData[i] = Any.Instance<PatternEvent>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(lines);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(tracks);
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var result = wrapper.GetPatternData(slotId, patternId);
        // then
        Assert.That(result, Is.Null);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
        library.Received(1).sv_get_pattern_data(slotId, patternId);
    }

    [Test]
    public void ReadPatternDataShouldReturnFalseAndNotChangeDataWhenLengthEqualsZero()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        const int readTracks = 2;
        const int readLines = 3;
        var originalData = new PatternEvent[readTracks * readLines];
        for (var i = 0; i < originalData.Length; i++)
            originalData[i] = Any.UnsignedLong();

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        var readEventCount = wrapper.ReadPatternData(slotId, patternId, buffer, readTracks, readLines);

        // then
        Assert.Multiple(() =>
        {
            Assert.That(readEventCount, Is.EqualTo(0));
            Assert.That(buffer, Is.EquivalentTo(originalData));
        });
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>());
        library.Received(0).sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>());
    }

    [Test]
    public void ReadPatternDataShouldReturnFalseAndNotChangeDataWhenPtrIsNullPtr()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        const int readTracks = 2;
        const int readLines = 3;
        var originalData = new PatternEvent[readTracks * readLines];
        for (var i = 0; i < originalData.Length; i++)
            originalData[i] = Any.UnsignedLong();

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(Any.Integer());
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(Any.Integer());
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var readEventCount = wrapper.ReadPatternData(slotId, patternId, buffer, readTracks, readLines);

        // then
        Assert.Multiple(() =>
        {
            Assert.That(readEventCount, Is.EqualTo(0));
            Assert.That(buffer, Is.EquivalentTo(originalData));
        });
        library.Received(1).sv_get_pattern_data(slotId, patternId);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
    }

    [Test]
    public void WritePatternDataShouldReturnFalseAndNotChangeDataWhenPtrIsNullPtr()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        const int readTracks = 2;
        const int readLines = 3;
        var originalData = new PatternEvent[readTracks * readLines];
        for (var i = 0; i < originalData.Length; i++)
            originalData[i] = Any.UnsignedLong();

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(Any.Integer());
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(Any.Integer());
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var readEventCount = wrapper.WritePatternData(slotId, patternId, buffer, readTracks, readLines);

        // then
        Assert.Multiple(() =>
        {
            Assert.That(readEventCount, Is.EqualTo(0));
            Assert.That(buffer, Is.EquivalentTo(originalData));
        });
        library.Received(1).sv_get_pattern_data(slotId, patternId);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
    }

    [TestCase(2, 2, 2, 1)]
    [TestCase(2, 2, 1, 2)]
    [TestCase(2, 2, 3, 2)]
    [TestCase(2, 2, 2, 3)]
    public void ReadPatternDataShouldThrowIfBufferIsDifferentToRequestedDataRead(int tracksToRead, int linesToRead,
        int tracksInBuffer, int linesInBuffer)
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        var originalData = new PatternEvent[tracksInBuffer * linesInBuffer];
        for (var i = 0; i < originalData.Length; i++)
            originalData[i] = Any.UnsignedLong();

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        // when
        Assert.That(() => wrapper.ReadPatternData(slotId, patternId, buffer, tracksToRead, linesToRead),
            Throws.ArgumentException);

        // then
        Assert.Multiple(() => { Assert.That(buffer, Is.EquivalentTo(originalData)); });
        library.Received(0).sv_get_pattern_data(slotId, patternId);
        library.Received(0).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(slotId, patternId);
    }

    [TestCase(-2, 2, 0, 0, 0, 0)]
    [TestCase(2, -2, 0, 0, 0, 0)]
    [TestCase(2, 2, -1, 0, 0, 0)]
    [TestCase(2, 2, 0, -1, 0, 0)]
    [TestCase(2, 2, 0, 0, -1, 0)]
    [TestCase(2, 2, 0, 0, 0, -1)]
    public void ReadPatternDataShouldThrowIfAnyOffsetValeIsNegative(int bufferTracks, int bufferLines,
        int bufferOffsetTracks, int bufferOffsetLines, int readOffsetTracks, int readOffsetLines)
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        var originalData = new PatternEvent[2 * 2];
        for (var i = 0; i < originalData.Length; i++)
            originalData[i] = Any.UnsignedLong();

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        // when
        Assert.That(
            () => wrapper.ReadPatternData(slotId, patternId, buffer, bufferTracks, bufferLines, bufferOffsetTracks,
                bufferOffsetLines, readOffsetTracks, readOffsetLines),
            Throws.TypeOf<ArgumentOutOfRangeException>());

        // then
        Assert.Multiple(() => { Assert.That(buffer, Is.EquivalentTo(originalData)); });
        library.Received(0).sv_get_pattern_data(slotId, patternId);
        library.Received(0).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(slotId, patternId);
    }

    [TestCase(-2, 2, 0, 0, 0, 0)]
    [TestCase(2, -2, 0, 0, 0, 0)]
    [TestCase(2, 2, -1, 0, 0, 0)]
    [TestCase(2, 2, 0, -1, 0, 0)]
    [TestCase(2, 2, 0, 0, -1, 0)]
    [TestCase(2, 2, 0, 0, 0, -1)]
    public void WritePatternDataShouldThrowIfAnyOffsetValeIsNegative(int bufferTracks, int bufferLines,
        int bufferOffsetTracks, int bufferOffsetLines, int writeOffsetTracks, int writeOffsetLines)
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        var originalData = new PatternEvent[2 * 2];
        for (var i = 0; i < originalData.Length; i++)
            originalData[i] = Any.UnsignedLong();

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        // when
        Assert.That(
            () => wrapper.WritePatternData(slotId, patternId, buffer, bufferTracks, bufferLines, bufferOffsetTracks,
                bufferOffsetLines, writeOffsetTracks, writeOffsetLines),
            Throws.TypeOf<ArgumentOutOfRangeException>());

        // then
        Assert.Multiple(() => { Assert.That(buffer, Is.EquivalentTo(originalData)); });
        library.Received(0).sv_get_pattern_data(slotId, patternId);
        library.Received(0).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(slotId, patternId);
    }

    [TestCase(2, 2, 2, 1)]
    [TestCase(2, 2, 1, 2)]
    [TestCase(2, 2, 3, 2)]
    [TestCase(2, 2, 2, 3)]
    public void WritePatternDataShouldThrowIfBufferIsDifferentToRequestedDataRead(int tracksToRead, int linesToRead,
        int tracksInBuffer, int linesInBuffer)
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        var originalData = new PatternEvent[tracksInBuffer * linesInBuffer];
        for (var i = 0; i < originalData.Length; i++)
            originalData[i] = Any.UnsignedLong();

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        // when
        Assert.That(() => wrapper.WritePatternData(slotId, patternId, buffer, tracksToRead, linesToRead),
            Throws.ArgumentException);

        // then
        Assert.Multiple(() => { Assert.That(buffer, Is.EquivalentTo(originalData)); });
        library.Received(0).sv_get_pattern_data(slotId, patternId);
        library.Received(0).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(slotId, patternId);
    }

    private static void PrintPatternEventCollection(IList<PatternEvent> collection, int tracks, int lines, string name)
    {
        TestContext.Out.WriteLine(name);
        for (var l = 0; l < lines; l++)
        {
            for (var t = 0; t < tracks; t++)
            {
                TestContext.Out.Write(collection[l * tracks + t].ToString());
                TestContext.Out.Write(" ");
            }

            TestContext.Out.WriteLine(" ");
        }
    }

    [TestCaseSource(nameof(PatternDataCases))]
    public void ReadPatternDataShouldWorkAsExpected(PatternDataCase testCase)
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        int readEventCount;
        var buffer = new PatternEvent[testCase.ToLines * testCase.ToTracks];

        var handle = GCHandle.Alloc(testCase.FromData, GCHandleType.Pinned);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(testCase.FromLines);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(testCase.FromTracks);
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(handle.AddrOfPinnedObject());
        try
        {
            // when
            readEventCount = wrapper.ReadPatternData(slotId, patternId, buffer, testCase.ToTracks, testCase.ToLines,
                testCase.TargetOffsetTracks, testCase.TargetOffsetLines, testCase.SourceOffsetTracks,
                testCase.SourceOffsetLines, testCase.MaxTracks, testCase.MaxLines);
        }
        finally
        {
            handle.Free();
        }

        PrintPatternEventCollection(testCase.FromData, testCase.FromTracks, testCase.FromLines, "original data");
        PrintPatternEventCollection(buffer, testCase.ToTracks, testCase.ToLines, "read buffer");
        PrintPatternEventCollection(testCase.ToData, testCase.ToTracks, testCase.ToLines, "expected");

        // then
        Assert.Multiple(() =>
        {
            Assert.That(readEventCount, Is.EqualTo(testCase.ExpectedOperationCount));
            Assert.That(buffer, Is.EquivalentTo(testCase.ToData));
        });

        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        var shouldContinueWithAccessingRemoteData = testCase.FromLines * testCase.FromTracks != 0;
        library.Received(testCase.FromLines != 0 ? 1 : 0).sv_get_pattern_tracks(slotId, patternId);
        library.Received(shouldContinueWithAccessingRemoteData ? 1 : 0).sv_get_pattern_data(slotId, patternId);
    }

    [TestCaseSource(nameof(PatternDataCases))]
    public void WritePatternDataShouldWorkAsExpected(PatternDataCase testCase)
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        int writtenEventCount;
        var buffer = new PatternEvent[testCase.ToLines * testCase.ToTracks];

        var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(testCase.ToLines);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(testCase.ToTracks);
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(handle.AddrOfPinnedObject());
        try
        {
            // when
            writtenEventCount = wrapper.WritePatternData(slotId, patternId, testCase.FromData, testCase.FromTracks,
                testCase.FromLines, testCase.SourceOffsetTracks, testCase.SourceOffsetLines,
                testCase.TargetOffsetTracks, testCase.TargetOffsetLines, testCase.MaxTracks, testCase.MaxLines);
        }
        finally
        {
            handle.Free();
        }

        PrintPatternEventCollection(testCase.FromData, testCase.FromTracks, testCase.FromLines, "original data");
        PrintPatternEventCollection(buffer, testCase.ToTracks, testCase.ToLines, "written buffer");
        PrintPatternEventCollection(testCase.ToData, testCase.ToTracks, testCase.ToLines, "expected");

        // then
        Assert.Multiple(() =>
        {
            Assert.That(writtenEventCount, Is.EqualTo(testCase.ExpectedOperationCount));
            Assert.That(buffer, Is.EquivalentTo(testCase.ToData));
        });

        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        var shouldContinueWithAccessingRemoteData = testCase.ToLines * testCase.ToTracks != 0;
        library.Received(testCase.ToLines != 0 ? 1 : 0).sv_get_pattern_tracks(slotId, patternId);
        library.Received(shouldContinueWithAccessingRemoteData ? 1 : 0).sv_get_pattern_data(slotId, patternId);
    }

    [Test]
    public void SetPatternDataShouldSetDataAsExpected()
    {
        var slotId = Any.Integer();
        var patternId = Any.Integer();
        var lines = 3;
        var tracks = 4;
        var data = Any.Array<PatternEvent>(lines * tracks);

        var buffer = new PatternEvent[lines * tracks + 1];

        var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(handle.AddrOfPinnedObject());
        library.sv_set_pattern_size(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        try
        {
            // when
            wrapper.SetPatternData(slotId, patternId, data, tracks, lines);
        }
        finally
        {
            handle.Free();
        }

        Assert.Multiple(() =>
        {
            Assert.That(buffer[..^1], Is.EquivalentTo(data));
            Assert.That(buffer[^1].Data, Is.EqualTo(0));
        });
        library.Received(1).sv_set_pattern_size(slotId, patternId, tracks, lines);
        library.Received(1).sv_get_pattern_data(slotId, patternId);
    }

    public class PatternDataCase
    {
        public string CaseName { get; set; } = string.Empty;

        public int FromTracks { get; set; }
        public int FromLines { get; set; }
        public PatternEvent[] FromData { get; set; } = Array.Empty<PatternEvent>();

        public int ToTracks { get; set; }
        public int ToLines { get; set; }
        public PatternEvent[] ToData { get; set; } = Array.Empty<PatternEvent>();

        public int TargetOffsetTracks { get; set; }
        public int TargetOffsetLines { get; set; }
        public int SourceOffsetTracks { get; set; }
        public int SourceOffsetLines { get; set; }
        public int? MaxTracks { get; set; }
        public int? MaxLines { get; set; }

        public int ExpectedOperationCount { get; set; }

        public override string ToString()
        {
            return CaseName;
        }
    }
}
