using System.Linq;
using System.Runtime.InteropServices;

namespace SunSharp.Tests;

public class UtilityHelperTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(short.MaxValue)]
    [TestCase(short.MinValue)]
    public void ToShortBitwise_ShouldReturnExpectedValue(short testValue)
    {
        var value = (uint)unchecked((ushort)testValue);
        var result = UtilityHelper.ToShortBitwise(value);
        result.Should().Be(testValue);
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(short.MaxValue)]
    [TestCase(short.MinValue)]
    public void ToShortBitwise_WithUpperBytesSet_ShouldReturnExpectedValue(short testValue)
    {
        var value = unchecked((ushort)testValue) | 0xFFFF0000;
        var result = UtilityHelper.ToShortBitwise(value);
        result.Should().Be(testValue);
    }

    [Test]
    public void CopyIntArrayShouldSkipNegativeOnes_NullPtr_ShouldReturnEmptyArray()
    {
        var array = UtilityHelper.CopyIntArraySkipNegativeOnes(IntPtr.Zero, 10);
        array.Should().BeEmpty();
    }

    [Test]
    public void CopyIntArraySkipNegativeOnes_ValidData_ShouldReturnValidData()
    {
        var originalArray = new[] { 0, 1, 2, -1, -1, -1, 4, 5 };
        int[] array;
        var originalArrayHandle = GCHandle.Alloc(originalArray, GCHandleType.Pinned);
        try
        {
            array = UtilityHelper.CopyIntArraySkipNegativeOnes(
                originalArrayHandle.AddrOfPinnedObject(), originalArray.Length);
        }
        finally
        {
            originalArrayHandle.Free();
        }
        array.Should().BeEquivalentTo(originalArray.Where(static i => i != -1).ToArray());
    }

    [TestCase(0, 0, 0u)]
    [TestCase(-1, -1, 0xFFFFFFFFu)]
    [TestCase(1, 1, 0x00010001u)]
    [TestCase(short.MaxValue, short.MaxValue, 0x7FFF7FFFu)]
    [TestCase(short.MinValue, short.MaxValue, 0x7FFF8000u)]
    [TestCase(short.MaxValue, short.MinValue, 0x80007FFFu)]
    [TestCase(short.MinValue, short.MinValue, 0x80008000u)]
    public void UnpackTwoSignedShorts_ShouldReturnExpectedValue(short lowerBytes, short upperBytes, uint value)
    {
        var result = UtilityHelper.UnpackTwoSignedShorts(value);
        result.Should().Be((lowerBytes, upperBytes));
    }

    [TestCase(0, 0, 0u)]
    [TestCase(-1, -1, 0xFFFFFFFFu)]
    [TestCase(1, 1, 0x00010001u)]
    [TestCase(short.MaxValue, short.MaxValue, 0x7FFF7FFFu)]
    [TestCase(short.MinValue, short.MaxValue, 0x7FFF8000u)]
    [TestCase(short.MaxValue, short.MinValue, 0x80007FFFu)]
    [TestCase(short.MinValue, short.MinValue, 0x80008000u)]
    public void PackTwoSignedShorts_ShouldReturnExpectedValue(short lowerBytes, short upperBytes, uint value)
    {
        var result = UtilityHelper.PackTwoSignedShorts(lowerBytes, upperBytes);
        result.Should().Be(value);
    }
}
