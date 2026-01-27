using System.Runtime.InteropServices;
using SunSharp.Native;

namespace SunSharp.Tests.Native;

public class SunVoxLibNativeWrapperPatternsTests
{
    public static PatternDataCase[] PatternDataCases =>
    [
        new()
        {
            CaseName = "simple call with equal size buffers",
            ToLines = 2,
            ToTracks = 3,
            FromLines = 2,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x3, 0x5,
                0x2, 0x4, 0x6
            ],
            ToData =
            [
                0x1, 0x3, 0x5,
                0x2, 0x4, 0x6
            ],
            ExpectedOperationCount = 2 * 3
        },
        new()
        {
            CaseName = "simple call with original data buffer being bigger",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x1, 0x4,
                0x2, 0x5
            ],
            ExpectedOperationCount = 2 * 2
        },
        new()
        {
            CaseName = "simple call with original data buffer being smaller",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 2,
            FromTracks = 2,
            FromData =
            [
                0x1, 0x4,
                0x2, 0x5
            ],
            ToData =
            [
                0x1, 0x4, 0x0,
                0x2, 0x5, 0x0,
                0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 2 * 2
        },
        new()
        {
            CaseName = "call with maxLines and maxTracks smaller than size",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x1, 0x4, 0x0,
                0x2, 0x5, 0x0,
                0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 2 * 2,
            MaxLines = 2,
            MaxTracks = 2
        },
        new()
        {
            CaseName = "call with maxTracks set to zero",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 0,
            MaxTracks = 0
        },
        new()
        {
            CaseName = "call with MaxLines set to zero",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 0,
            MaxLines = 0
        },
        new()
        {
            CaseName = "call with maxTracks and maxLines set to zero",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 0,
            MaxLines = 0,
            MaxTracks = 0
        },
        new()
        {
            CaseName = "call with source data being empty",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 0,
            FromTracks = 0,
            FromData = [],
            ToData =
            [
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0,
                0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 0
        },
        new()
        {
            CaseName = "call with target data being empty",
            ToLines = 0,
            ToTracks = 0,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData = [],
            ExpectedOperationCount = 0
        },
        new()
        {
            CaseName = "call with target buffer offset lines",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x0, 0x0, 0x0,
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8
            ],
            ExpectedOperationCount = 2 * 3,
            TargetOffsetLines = 1
        },
        new()
        {
            CaseName = "call with target buffer offset tracks",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x0, 0x1, 0x4,
                0x0, 0x2, 0x5,
                0x0, 0x3, 0x6
            ],
            ExpectedOperationCount = 2 * 3,
            TargetOffsetTracks = 1
        },
        new()
        {
            CaseName = "call with target buffer offset tracks and lines",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x0, 0x0, 0x0,
                0x0, 0x1, 0x4,
                0x0, 0x2, 0x5
            ],
            ExpectedOperationCount = 2 * 2,
            TargetOffsetTracks = 1,
            TargetOffsetLines = 1
        },
        new()
        {
            CaseName = "call with source offset lines",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9,
                0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 2 * 3,
            SourceOffsetLines = 1
        },
        new()
        {
            CaseName = "call with source offset tracks",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x4, 0x7, 0x0,
                0x5, 0x8, 0x0,
                0x6, 0x9, 0x0
            ],
            ExpectedOperationCount = 2 * 3,
            SourceOffsetTracks = 1
        },
        new()
        {
            CaseName = "call with source offset tracks and lines",
            ToLines = 3,
            ToTracks = 3,
            FromLines = 3,
            FromTracks = 3,
            FromData =
            [
                0x1, 0x4, 0x7,
                0x2, 0x5, 0x8,
                0x3, 0x6, 0x9
            ],
            ToData =
            [
                0x5, 0x8, 0x0,
                0x6, 0x9, 0x0,
                0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 2 * 2,
            SourceOffsetTracks = 1,
            SourceOffsetLines = 1
        },
        new()
        {
            CaseName = "call with source offset real tracks and lines, and target offset tracks and lines",
            ToLines = 4,
            ToTracks = 4,
            FromLines = 4,
            FromTracks = 4,
            FromData =
            [
                0x1, 0x6, 0xA, 0xE,
                0x2, 0x7, 0xB, 0xF,
                0x3, 0x8, 0xC, 0x10,
                0x4, 0x9, 0xD, 0x11
            ],
            ToData =
            [
                0x0, 0x0, 0x0, 0x0,
                0x0, 0x7, 0xB, 0xF,
                0x0, 0x8, 0xC, 0x10,
                0x0, 0x9, 0xD, 0x11
            ],
            ExpectedOperationCount = 3 * 3,
            SourceOffsetTracks = 1,
            SourceOffsetLines = 1,
            TargetOffsetTracks = 1,
            TargetOffsetLines = 1
        },
        new()
        {
            CaseName =
                "call with source offset real tracks and lines, and target offset tracks and lines, and max tracks and lines",
            ToLines = 4,
            ToTracks = 4,
            FromLines = 4,
            FromTracks = 4,
            FromData =
            [
                0x1, 0x6, 0xA, 0xE,
                0x2, 0x7, 0xB, 0xF,
                0x3, 0x8, 0xC, 0x10,
                0x4, 0x9, 0xD, 0x11
            ],
            ToData =
            [
                0x0, 0x0, 0x0, 0x0,
                0x0, 0x7, 0xB, 0x0,
                0x0, 0x8, 0xC, 0x0,
                0x0, 0x0, 0x0, 0x0
            ],
            ExpectedOperationCount = 2 * 2,
            SourceOffsetTracks = 1,
            SourceOffsetLines = 1,
            TargetOffsetTracks = 1,
            TargetOffsetLines = 1,
            MaxLines = 2,
            MaxTracks = 2
        },
        new()
        {
            CaseName = "call with target track offset being greater than size",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 2,
            FromTracks = 2,
            FromData =
            [
                0x1, 0x6,
                0x2, 0x7
            ],
            ToData =
            [
                0x0, 0x0,
                0x0, 0x0
            ],
            ExpectedOperationCount = 0,
            TargetOffsetTracks = 2
        },
        new()
        {
            CaseName = "call with target line offset being greater than size",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 2,
            FromTracks = 2,
            FromData =
            [
                0x1, 0x6,
                0x2, 0x7
            ],
            ToData =
            [
                0x0, 0x0,
                0x0, 0x0
            ],
            ExpectedOperationCount = 0,
            TargetOffsetLines = 2
        },
        new()
        {
            CaseName = "call with source line offset being greater than size",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 2,
            FromTracks = 2,
            FromData =
            [
                0x1, 0x6,
                0x2, 0x7
            ],
            ToData =
            [
                0x0, 0x0,
                0x0, 0x0
            ],
            ExpectedOperationCount = 0,
            SourceOffsetLines = 2
        },
        new()
        {
            CaseName = "call with source line offset being greater than size",
            ToLines = 2,
            ToTracks = 2,
            FromLines = 2,
            FromTracks = 2,
            FromData =
            [
                0x1, 0x6,
                0x2, 0x7
            ],
            ToData =
            [
                0x0, 0x0,
                0x0, 0x0
            ],
            ExpectedOperationCount = 0,
            SourceOffsetTracks = 2
        }
    ];

    [Test, AutoData]
    public void ClonePattern_ShouldThrow_WhenNegativeValueReturned(int slotId, int originalPatternId, int x, int y)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.ClonePattern(slotId, originalPatternId, x, y)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_new_pattern(slotId, originalPatternId, x, y, -1, -1, -1, IntPtr.Zero);
    }

    [Test, AutoData]
    public void ClonePattern_ShouldCallExpectedMethod(int slotId, int originalPatternId, int x, int y, int newPatternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(newPatternId);

        // when
        var value = wrapper.ClonePattern(slotId, originalPatternId, x, y);
        library.Received(1).sv_new_pattern(slotId, originalPatternId, x, y, -1, -1, -1, IntPtr.Zero);
        value.Should().Be(newPatternId);
    }

    [Test, AutoData]
    public void CreatePattern_ShouldThrow_WhenNegativeValueReturned(int slotId, int x, int y, int tracks, int lines, int iconSeed, string patternName)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.CreatePattern(slotId, x, y, tracks, lines, iconSeed, patternName)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_new_pattern(slotId, -1, x, y, tracks, lines, iconSeed, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void CreatePattern_ShouldCallExpectedMethod(int slotId, int x, int y, int tracks, int lines, int iconSeed, string patternName, int newPatternId)
    {
        var receivedPatternName = string.Empty;
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(newPatternId);
        library.When(static l => l.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => { receivedPatternName = Marshal.PtrToStringUTF8(callInfo.Arg<IntPtr>()); });

        // when
        var value = wrapper.CreatePattern(slotId, x, y, tracks, lines, iconSeed, patternName);

        // then
        library.Received(1).sv_new_pattern(slotId, -1, x, y, tracks, lines, iconSeed, Arg.Any<IntPtr>());
        value.Should().Be(newPatternId);
        receivedPatternName.Should().Be(patternName);
    }

    [Test, AutoData]
    public void CreatePattern_WithDefaultValues_ShouldCallExpectedMethod(int slotId, int x, int y, int tracks, int lines, int newPatternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_new_pattern(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>())
            .Returns(newPatternId);

        // when
        var value = wrapper.CreatePattern(slotId, x, y, tracks, lines);

        // then
        library.Received(1).sv_new_pattern(slotId, -1, x, y, tracks, lines, 0, IntPtr.Zero);
        value.Should().Be(newPatternId);
    }

    [Test, AutoData]
    public void FindPattern_ShouldCallExpectedMethod(int slotId, string patternName, int foundPatternId)
    {
        var receivedString = string.Empty;
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(foundPatternId);
        library.When(static l => l.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringUTF8(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.FindPattern(slotId, patternName);

        // then
        library.Received(1).sv_find_pattern(slotId, Arg.Any<IntPtr>());
        value.Should().Be(foundPatternId);
        receivedString.Should().Be(patternName);
    }

    [Test, AutoData]
    public void FindPattern_ShouldReturnNull_WhenPatternNotFound(int slotId, string patternName)
    {
        var receivedString = string.Empty;
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);
        library.When(static l => l.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringUTF8(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.FindPattern(slotId, patternName);

        // then
        library.Received(1).sv_find_pattern(slotId, Arg.Any<IntPtr>());
        value.Should().BeNull();
        receivedString.Should().Be(patternName);
    }

    [Test, AutoData]
    public void FindPattern_ShouldThrow_WhenReturnCodeLessThanNegativeOne(int slotId, string patternName)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_find_pattern(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-2);

        // when
        wrapper.Invoking(w => w.FindPattern(slotId, patternName))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_find_pattern(slotId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void GetPatternEventValue_ShouldCallExpectedMethod(int slotId, int patternId, int track, int line, Column column)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(0);

        // when
        wrapper.GetPatternEventValue(slotId, patternId, track, line, column);

        // then
        library.Received(1).sv_get_pattern_event(slotId, patternId, track, line, (int)column);
    }

    [Test, AutoData]
    public void GetPatternEventValue_ShouldThrow_WhenNonZeroReturnCode(int slotId, int patternId, int track, int line, Column column)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.GetPatternEventValue(slotId, patternId, track, line, column))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_pattern_event(slotId, patternId, track, line, (int)column);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void GetPatternExists_ShouldReturnValue(bool exists)
    {
        var fixture = new Fixture();
        var slotId = fixture.Create<int>();
        var patternId = fixture.Create<int>();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(exists ? 1 : 0);

        // when
        var receivedExists = wrapper.GetPatternExists(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        receivedExists.Should().Be(exists);
    }

    [Test, AutoData]
    public void GetPatternExists_ShouldThrow_WhenErrorReturnCode(int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.GetPatternExists(slotId, patternId))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
    }

    [Test, AutoData]
    public void GetPatternLines_ShouldReturnValue(int slotId, int patternId, int lines)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(lines);

        // when
        var receivedLines = wrapper.GetPatternLines(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        receivedLines.Should().Be(lines);
    }

    [Test, AutoData]
    public void GetPatternLines_ShouldThrow_WhenErrorReturnCode(int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.GetPatternLines(slotId, patternId))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
    }

    [Test, AutoData]
    public void GetPatternName_ShouldReturnNull_WhenNullPointer(int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_name(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var receivedPatternName = wrapper.GetPatternName(slotId, patternId);
        // then
        library.Received(1).sv_get_pattern_name(slotId, patternId);
        receivedPatternName.Should().BeNull();
    }

    [Test, AutoData]
    public void GetPatternName_ShouldReturnString(int slotId, int patternId, string patternName)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        var stringPointer = Marshal.StringToHGlobalAnsi(patternName);
        string? receivedPatternName;

        try
        {
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
        receivedPatternName.Should().Be(patternName);
    }

    [Test, AutoData]
    public void GetPatternPosition_ShouldReturnValue(int slotId, int patternId, int x, int y)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_x(Arg.Any<int>(), Arg.Any<int>()).Returns(x);
        library.sv_get_pattern_y(Arg.Any<int>(), Arg.Any<int>()).Returns(y);

        // when
        var value = wrapper.GetPatternPosition(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_x(slotId, patternId);
        library.Received(1).sv_get_pattern_y(slotId, patternId);
        value.Should().Be((x, y));
    }

    [Test, AutoData]
    public void GetPatternTracks_ShouldReturnValue(int slotId, int patternId, int tracks)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(tracks);

        // when
        var receivedLines = wrapper.GetPatternTracks(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
        receivedLines.Should().Be(tracks);
    }

    [Test, AutoData]
    public void GetPatternTracks_ShouldThrow_WhenErrorReturnCode(int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.GetPatternTracks(slotId, patternId))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
    }

    [Test, AutoData]
    public void GetPatternX_ShouldReturnValue(int slotId, int patternId, int x)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_x(Arg.Any<int>(), Arg.Any<int>()).Returns(x);

        // when
        var value = wrapper.GetPatternX(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_x(slotId, patternId);
        value.Should().Be(x);
    }

    [Test, AutoData]
    public void GetPatternY_ShouldReturnValue(int slotId, int patternId, int y)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_y(Arg.Any<int>(), Arg.Any<int>()).Returns(y);

        // when
        var value = wrapper.GetPatternY(slotId, patternId);

        // then
        library.Received(1).sv_get_pattern_y(slotId, patternId);
        value.Should().Be(y);
    }

    [Test, AutoData]
    public void GetUpperPatternCount_ShouldCallExpectedMethod(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_number_of_patterns(Arg.Any<int>()).Returns(0);

        // when
        wrapper.GetUpperPatternCount(slotId);

        // then
        library.Received(1).sv_get_number_of_patterns(slotId);
    }

    [Test, AutoData]
    public void GetUpperPatternCount_ShouldThrow_WhenNegativeReturnCode(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_number_of_patterns(Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.GetUpperPatternCount(slotId))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_number_of_patterns(slotId);
    }

    [Test, AutoData]
    public void RemovePattern_ShouldCallExpectedMethod(int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_remove_pattern(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.RemovePattern(slotId, patternId);

        // then
        library.Received(1).sv_remove_pattern(slotId, patternId);
    }

    [Test, AutoData]
    public void RemovePattern_ShouldThrow_WhenNonZeroReturnCode(int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_remove_pattern(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.RemovePattern(slotId, patternId))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_remove_pattern(slotId, patternId);
    }

    [Test, AutoData]
    public void SetPatternName_ShouldCallExpectedMethod(int slotId, int patternId, string nameToSet)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        var receivedString = string.Empty;
        library.When(static l => l.sv_set_pattern_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringUTF8(callInfo.Arg<IntPtr>()));

        // when
        wrapper.SetPatternName(slotId, patternId, nameToSet);

        // then
        library.Received(1).sv_set_pattern_name(slotId, patternId, Arg.Any<IntPtr>());
        receivedString.Should().Be(nameToSet);
    }

    [Test, AutoData]
    public void SetPatternName_ShouldThrow_WhenNonZeroReturnCode(int slotId, int patternId, string nameToSet)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetPatternName(slotId, patternId, nameToSet)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_pattern_name(slotId, patternId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void SetPatternPosition_ShouldCallExpectedMethod(int slotId, int patternId, int x, int y)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_xy(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetPatternPosition(slotId, patternId, x, y);

        // then
        library.Received(1).sv_set_pattern_xy(slotId, patternId, x, y);
    }

    [Test, AutoData]
    public void SetPatternPosition_ShouldThrow_WhenErrorReturnCode(int slotId, int patternId, int x, int y)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_xy(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetPatternPosition(slotId, patternId, x, y))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_pattern_xy(slotId, patternId, x, y);
    }

    [Test, AutoData]
    public void SetPatternSize_ShouldCallExpectedMethod(int slotId, int patternId, int tracks, int lines)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetPatternSize(slotId, patternId, tracks, lines);

        // then
        library.Received(1).sv_set_pattern_size(slotId, patternId, tracks, lines);
    }

    [Test, AutoData]
    public void SetPatternSize_WithDefaultValues_ShouldCallExpectedMethod(int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_size(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetPatternSize(slotId, patternId);

        // then
        library.Received(1).sv_set_pattern_size(slotId, patternId, -1, -1);
    }

    [Test, AutoData]
    public void SetPatternSize_ShouldThrow_WhenErrorReturnCode(int slotId, int patternId, int tracks, int lines)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_size(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetPatternSize(slotId, patternId, tracks, lines))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_pattern_size(slotId, patternId, tracks, lines);
    }

    [Test, AutoData]
    public void GetPatternMuted_ShouldReturnValue(bool muted, int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_pattern_mute(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(muted ? 1 : 0);

        // when
        var value = wrapper.GetPatternMuted(slotId, patternId);

        // then
        library.Received(1).sv_pattern_mute(slotId, patternId, -1);
        value.Should().Be(muted);
    }

    [Test, AutoData]
    public void SetPatternMuted_ShouldCallExpectedMethod(bool muted, int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_pattern_mute(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(muted ? 1 : 0);

        // when
        wrapper.SetPatternMuted(slotId, patternId, muted);

        // then
        library.Received(1).sv_pattern_mute(slotId, patternId, muted ? 1 : 0);
    }

    [Test, AutoData]
    public void SetPatternEvent_ShouldCallExpectedMethod(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee, int xxyy)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(0);

        // when
        wrapper.SetPatternEvent(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);

        // then
        library.Received(1).sv_set_pattern_event(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);
    }

    [Test, AutoData]
    public void SetPatternEvent_ShouldThrow_WhenNonZeroReturnCode(int slotId, int patternId, int track, int line, int nn, int vv, int mm, int ccee, int xxyy)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.SetPatternEvent(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_pattern_event(slotId, patternId, track, line, nn, vv, mm, ccee, xxyy);
    }

    [Test, AutoData]
    public void SetPatternEventWithStruct_ShouldCallExpectedMethod(int slotId, int patternId, int track, int line, PatternEvent patternEvent)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(0);

        // when
        wrapper.SetPatternEvent(slotId, patternId, track, line, patternEvent);

        // then
        library.Received(1).sv_set_pattern_event(slotId, patternId, track, line, patternEvent.NN, patternEvent.VV,
            patternEvent.MM, patternEvent.CCEE, patternEvent.XXYY);
    }

    [Test, AutoData]
    public void SetPatternEventWithStruct_ShouldThrow_WhenNonZeroReturnCode(int slotId, int patternId, int track, int line, PatternEvent patternEvent)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_set_pattern_event(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.SetPatternEvent(slotId, patternId, track, line, patternEvent))
            .Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_pattern_event(slotId, patternId, track, line, patternEvent.NN, patternEvent.VV,
            patternEvent.MM, patternEvent.CCEE, patternEvent.XXYY);
    }

    [Test, AutoData]
    public void GetPatternData_ShouldReturnData(int slotId, int patternId)
    {
        const int lines = 4;
        const int tracks = 5;
        var receivedPatternData = Array.Empty<PatternEvent>();
        var receivedTracks = 0;
        var receivedLines = 0;

        var patternData = new PatternEvent[tracks * lines];
        for (var line = 0; line < lines; line++)
        {
            for (var track = 0; track < tracks; track++)
                patternData[line * tracks + track] = new PatternEvent
                {
                    CCEE = (ushort)line,
                    XXYY = (ushort)track
                };
        }

        var handle = GCHandle.Alloc(patternData, GCHandleType.Pinned);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
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

        receivedPatternData.Should().NotBeEquivalentTo(Array.Empty<PatternEvent>());
        receivedPatternData.Should().HaveCount(receivedTracks * receivedLines);
        receivedPatternData.Should().BeEquivalentTo(patternData);
        library.Received(1).sv_get_pattern_data(slotId, patternId);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
    }

    [Test, AutoData]
    public void GetPatternData_ShouldReturnNull_WhenLengthEqualsZero(int slotId, int patternId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        // when
        var receivedPatternData = wrapper.GetPatternData(slotId, patternId);
        // then
        receivedPatternData.Should().BeNull();
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>());
        library.Received(0).sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>());
    }

    [Test, AutoData]
    public void GetPatternData_ShouldReturnNull_WhenPtrIsNullPtr(int slotId, int patternId)
    {
        const int lines = 4;
        const int tracks = 5;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(lines);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(tracks);
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var result = wrapper.GetPatternData(slotId, patternId);
        // then
        result.Should().BeNull();
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
        library.Received(1).sv_get_pattern_data(slotId, patternId);
    }

    [Test, AutoData]
    public void ReadPatternData_ShouldReturnZeroAndNotChangeData_WhenLengthEqualsZero(int slotId, int patternId)
    {
        const int readTracks = 2;
        const int readLines = 3;
        var originalData = new PatternEvent[readTracks * readLines];
        for (var i = 0; i < originalData.Length; i++)
        {
            originalData[i] = new PatternEvent((ulong)i);
        }

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        var readEventCount = wrapper.ReadPatternData(slotId, patternId, buffer, readTracks, readLines);

        // then
        readEventCount.Should().Be(0);
        buffer.Should().BeEquivalentTo(originalData);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>());
        library.Received(0).sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>());
    }

    [Test, AutoData]
    public void ReadPatternData_ShouldReturnZeroAndNotChangeData_WhenPtrIsNullPtr(int slotId, int patternId, int lines, int tracks)
    {
        const int readTracks = 2;
        const int readLines = 3;
        var originalData = new PatternEvent[readTracks * readLines];
        for (var i = 0; i < originalData.Length; i++)
        {
            originalData[i] = new PatternEvent((ulong)i);
        }

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(lines);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(tracks);
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var readEventCount = wrapper.ReadPatternData(slotId, patternId, buffer, readTracks, readLines);

        // then
        readEventCount.Should().Be(0);
        buffer.Should().BeEquivalentTo(originalData);
        library.Received(1).sv_get_pattern_data(slotId, patternId);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
    }

    [Test, AutoData]
    public void WritePatternData_ShouldReturnZeroAndNotChangeData_WhenPtrIsNullPtr(int slotId, int patternId, int lines, int tracks)
    {
        const int readTracks = 2;
        const int readLines = 3;
        var originalData = new PatternEvent[readTracks * readLines];
        for (var i = 0; i < originalData.Length; i++)
        {
            originalData[i] = new PatternEvent((ulong)i);
        }

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
        library.sv_get_pattern_lines(Arg.Any<int>(), Arg.Any<int>()).Returns(lines);
        library.sv_get_pattern_tracks(Arg.Any<int>(), Arg.Any<int>()).Returns(tracks);
        library.sv_get_pattern_data(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var readEventCount = wrapper.WritePatternData(slotId, patternId, buffer, readTracks, readLines);

        // then
        readEventCount.Should().Be(0);
        buffer.Should().BeEquivalentTo(originalData);
        library.Received(1).sv_get_pattern_data(slotId, patternId);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        library.Received(1).sv_get_pattern_tracks(slotId, patternId);
    }

    [Test, AutoData]
    public void ReadPatternData_ShouldThrow_WhenBufferSizeDifferentFromRequestedSize(int slotId, int patternId, int tracksToRead, int linesToRead)
    {
        const int tracksInBuffer = 4;
        const int linesInBuffer = 32;
        var originalData = new PatternEvent[tracksInBuffer * linesInBuffer];
        for (var i = 0; i < originalData.Length; i++)
        {
            originalData[i] = new PatternEvent((ulong)i);
        }

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);

        // when
        wrapper.Invoking(w => w.ReadPatternData(slotId, patternId, buffer, tracksToRead, linesToRead))
            .Should().Throw<ArgumentException>();
        buffer.Should().BeEquivalentTo(originalData);
        library.Received(0).sv_get_pattern_data(slotId, patternId);
        library.Received(0).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(slotId, patternId);
    }

    [TestCase(-1, 0, 0, 0)]
    [TestCase(0, -1, 0, 0)]
    [TestCase(0, 0, -1, 0)]
    [TestCase(0, 0, 0, -1)]
    public void ReadPatternData_ShouldThrow_WhenAnyOffsetValueIsNegative(int bufferOffsetTracks, int bufferOffsetLines, int readOffsetTracks, int readOffsetLines)
    {
        var fixture = new Fixture();
        var slotId = fixture.Create<int>();
        var patternId = fixture.Create<int>();
        const int bufferTracks = 2;
        const int bufferLines = 2;
        var originalData = new PatternEvent[2 * 2];
        for (var i = 0; i < originalData.Length; i++)
        {
            originalData[i] = new PatternEvent((ulong)i);
        }

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);

        // when
        wrapper.Invoking(w => w.ReadPatternData(slotId, patternId, buffer, bufferTracks, bufferLines, bufferOffsetTracks, bufferOffsetLines, readOffsetTracks, readOffsetLines))
            .Should().Throw<ArgumentOutOfRangeException>();
        buffer.Should().BeEquivalentTo(originalData);
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
    public void WritePatternData_ShouldThrow_WhenAnyOffsetValueIsNegative(int bufferTracks, int bufferLines,
        int bufferOffsetTracks, int bufferOffsetLines, int writeOffsetTracks, int writeOffsetLines)
    {
        var fixture = new Fixture();
        var slotId = fixture.Create<int>();
        var patternId = fixture.Create<int>();
        var originalData = new PatternEvent[2 * 2];
        for (var i = 0; i < originalData.Length; i++)
        {
            originalData[i] = new PatternEvent((ulong)i);
        }

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);

        // when
        wrapper.Invoking(w => w.WritePatternData(slotId, patternId, buffer, bufferTracks, bufferLines, bufferOffsetTracks, bufferOffsetLines, writeOffsetTracks, writeOffsetLines))
            .Should().Throw<ArgumentOutOfRangeException>();
        buffer.Should().BeEquivalentTo(originalData);
        library.Received(0).sv_get_pattern_data(slotId, patternId);
        library.Received(0).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(slotId, patternId);
    }

    [TestCase(2, 2, 2, 1)]
    [TestCase(2, 2, 1, 2)]
    [TestCase(2, 2, 3, 2)]
    [TestCase(2, 2, 2, 3)]
    public void WritePatternData_ShouldThrow_WhenBufferSizeDifferentFromRequestedSize(int tracksToRead, int linesToRead,
        int tracksInBuffer, int linesInBuffer)
    {
        var fixture = new Fixture();
        var slotId = fixture.Create<int>();
        var patternId = fixture.Create<int>();
        var originalData = new PatternEvent[tracksInBuffer * linesInBuffer];
        for (var i = 0; i < originalData.Length; i++)
        {
            originalData[i] = new PatternEvent((ulong)i);
        }

        var buffer = (PatternEvent[])originalData.Clone();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);

        // when
        wrapper.Invoking(w => w.WritePatternData(slotId, patternId, buffer, tracksToRead, linesToRead))
            .Should().Throw<ArgumentException>();
        buffer.Should().BeEquivalentTo(originalData);
        library.Received(0).sv_get_pattern_data(slotId, patternId);
        library.Received(0).sv_get_pattern_lines(slotId, patternId);
        library.Received(0).sv_get_pattern_tracks(slotId, patternId);
    }

    private static void PrintPatternEventCollection(PatternEvent[] collection, int tracks, int lines, string name)
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
    public void ReadPatternData_ShouldWorkAsExpected(PatternDataCase testCase)
    {
        var fixture = new Fixture();
        var slotId = fixture.Create<int>();
        var patternId = fixture.Create<int>();
        int readEventCount;
        var buffer = new PatternEvent[testCase.ToLines * testCase.ToTracks];

        var handle = GCHandle.Alloc(testCase.FromData, GCHandleType.Pinned);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
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
        readEventCount.Should().Be(testCase.ExpectedOperationCount);
        buffer.Should().BeEquivalentTo(testCase.ToData);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        var shouldContinueWithAccessingRemoteData = testCase.FromLines * testCase.FromTracks != 0;
        library.Received(testCase.FromLines != 0 ? 1 : 0).sv_get_pattern_tracks(slotId, patternId);
        library.Received(shouldContinueWithAccessingRemoteData ? 1 : 0).sv_get_pattern_data(slotId, patternId);
    }

    [TestCaseSource(nameof(PatternDataCases))]
    public void WritePatternData_ShouldWorkAsExpected(PatternDataCase testCase)
    {
        var fixture = new Fixture();
        var slotId = fixture.Create<int>();
        var patternId = fixture.Create<int>();
        int writtenEventCount;
        var buffer = new PatternEvent[testCase.ToLines * testCase.ToTracks];

        var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
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
        writtenEventCount.Should().Be(testCase.ExpectedOperationCount);
        buffer.Should().BeEquivalentTo(testCase.ToData);
        library.Received(1).sv_get_pattern_lines(slotId, patternId);
        var shouldContinueWithAccessingRemoteData = testCase.ToLines * testCase.ToTracks != 0;
        library.Received(testCase.ToLines != 0 ? 1 : 0).sv_get_pattern_tracks(slotId, patternId);
        library.Received(shouldContinueWithAccessingRemoteData ? 1 : 0).sv_get_pattern_data(slotId, patternId);
    }

    [Test, AutoData]
    public void SetPatternData_ShouldSetData(int slotId, int patternId)
    {
        const int tracks = 4;
        const int lines = 32;
        var data = new PatternEvent[lines * tracks];
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = new PatternEvent((ulong)i);
        }

        // the +1 is here so that we can check that no more than the expected data is written
        var buffer = new PatternEvent[lines * tracks + 1];

        var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLib(library);
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

        buffer[..^1].Should().BeEquivalentTo(data);
        buffer[^1].Data.Should().Be(0);
        library.Received(1).sv_set_pattern_size(slotId, patternId, tracks, lines);
        library.Received(1).sv_get_pattern_data(slotId, patternId);
    }

    public class PatternDataCase
    {
        public string CaseName { get; set; } = string.Empty;

        public int FromTracks { get; set; }
        public int FromLines { get; set; }
        public PatternEvent[] FromData { get; set; } = [];

        public int ToTracks { get; set; }
        public int ToLines { get; set; }
        public PatternEvent[] ToData { get; set; } = [];

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
