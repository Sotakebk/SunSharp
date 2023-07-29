using System;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SunSharp.UnitTests;

internal class HelperTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(short.MaxValue)]
    [TestCase(short.MinValue)]
    public void ToShortBitwiseShouldGiveSameValueForArgument(short testValue)
    {
        var value = (uint)unchecked((ushort)testValue);

        var result = Helper.ToShortBitwise(value);

        Assert.That(result, Is.EqualTo(testValue));
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(short.MaxValue)]
    [TestCase(short.MinValue)]
    public void ToShortBitwiseShouldGiveSameValueForArgumentWithHighBits(short testValue)
    {
        var value = unchecked((ushort)testValue) | 0xFFFF0000;

        var result = Helper.ToShortBitwise(value);

        Assert.That(result, Is.EqualTo(testValue));
    }

    [Test]
    public void CopyIntArrayShouldSkipNegativeOnesReturnEmptyArrayForNullPtr()
    {
        var array = Helper.CopyIntArraySkipNegativeOnes(IntPtr.Zero, 10);

        Assert.That(array, Is.EqualTo(Array.Empty<int>()));
    }

    [Test]
    public void CopyIntArraySkipNegativeOnesShouldReturnValidData()
    {
        var originalArray = new[] { 0, 1, 2, -1, -1, -1, 4, 5 };
        int[] array;
        var originalArrayHandle = GCHandle.Alloc(originalArray, GCHandleType.Pinned);
        try
        {
            array = Helper.CopyIntArraySkipNegativeOnes(
                originalArrayHandle.AddrOfPinnedObject(), originalArray.Length);
        }
        finally
        {
            originalArrayHandle.Free();
        }

        Assert.That(array, Is.EqualTo(originalArray.Where(i => i != -1).ToArray()));
    }

    [TestCase(0, 0)]
    [TestCase(-1, -1)]
    [TestCase(1, 1)]
    [TestCase(short.MaxValue, short.MaxValue)]
    [TestCase(short.MinValue, short.MaxValue)]
    [TestCase(short.MaxValue, short.MinValue)]
    [TestCase(short.MinValue, short.MinValue)]
    public void SplitValueTo2DPositionShouldReturnExpectedValues(short x, short y)
    {
        var value = unchecked((ushort)x)
                    | ((uint)(unchecked((ushort)y)) << 16);
        var result = Helper.SplitValueTo2DPosition(value);

        Assert.That(result, Is.EqualTo((x, y)));
    }

    [TestCase(0, 0)]
    [TestCase(-1, -1)]
    [TestCase(1, 1)]
    [TestCase(short.MaxValue, short.MaxValue)]
    [TestCase(short.MinValue, short.MaxValue)]
    [TestCase(short.MaxValue, short.MinValue)]
    [TestCase(short.MinValue, short.MinValue)]
    public void SplitValueToFineTuneShouldReturnExpectedValues(short fineTune, short relativeNote)
    {
        var value = unchecked((ushort)fineTune)
                    | ((uint)(unchecked((ushort)relativeNote)) << 16);
        var result = Helper.SplitValueToFineTune(value);

        Assert.That(result, Is.EqualTo((fineTune, relativeNote)));
    }

    [TestCase(0x7800, 16.35)] // C0
    [TestCase(0x7800 - 0x100 * (12 * 4 + 9), 440)] // A4
    [TestCase(0x7800 - 0x100 * (12 * 5 + 9), 880)] // A5
    public void FrequencyFromPitchShouldReturnExpectedValues(double input, double expected)
    {
        var result = Helper.PitchToFrequency(input);
        var resultFloat = Helper.PitchToFrequency((float)input);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(expected).Within(expected * 0.01));
            Assert.That(resultFloat, Is.EqualTo(expected).Within(expected * 0.01));
        });
    }

    [TestCase(16.35, 0x7800)] // C0
    [TestCase(440, 0x7800 - 0x100 * (12 * 4 + 9))] // A4
    [TestCase(880, 0x7800 - 0x100 * (12 * 5 + 9))] // A5
    public void PitchFromFrequencyShouldReturnExpectedValues(double input, double expected)
    {
        var result = Helper.FrequencyToPitch(input);
        var resultFloat = Helper.FrequencyToPitch((float)input);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(expected).Within(expected * 0.01));
            Assert.That(resultFloat, Is.EqualTo(expected).Within(expected * 0.01));
        });
    }
}
