namespace SunSharp.Tests;

public class ModuleFlagsTests
{
    public static uint CreateModuleFlagsValue(bool exists = false, bool isGenerator = false, bool isEffect = false,
    bool isMute = false, bool isSolo = false, bool isBypassed = false, byte inputCount = 0, byte outputCount = 0)
    {
        return ((exists ? 1u : 0) << 0)
               | ((isGenerator ? 1u : 0) << 1)
               | ((isEffect ? 1u : 0) << 2)
               | ((isMute ? 1u : 0) << 3)
               | ((isSolo ? 1u : 0) << 4)
               | ((isBypassed ? 1u : 0) << 5)
               | ((uint)inputCount << 16)
               | ((uint)outputCount << 24);
    }

    [Test]
    public void Properties_ShouldReturnValuesAsExpected()
    {
        for (uint i = 0; i <= 0b111111; i++)
        {
            var flag = new ModuleFlags(i);

            flag.Exists.Should().Be((i & (1 << 0)) != 0);
            flag.Generator.Should().Be((i & (1 << 1)) != 0);
            flag.Effect.Should().Be((i & (1 << 2)) != 0);
            flag.Mute.Should().Be((i & (1 << 3)) != 0);
            flag.Solo.Should().Be((i & (1 << 4)) != 0);
            flag.Bypass.Should().Be((i & (1 << 5)) != 0);
        }
    }

    [Test]
    public void InputCount_ReturnExpectedValues()
    {
        var exampleFlags = new ModuleFlags(0);
        exampleFlags.InputUpperCount.Should().Be(0);

        var otherExampleFlags = new ModuleFlags(CreateModuleFlagsValue(inputCount: 255, outputCount: 255));
        otherExampleFlags.InputUpperCount.Should().Be(255);

        var andAnotherExampleFlags = new ModuleFlags(CreateModuleFlagsValue(inputCount: 4, outputCount: 8));
        andAnotherExampleFlags.InputUpperCount.Should().Be(4);
    }

    [Test]
    public void OutputCount_ReturnExpectedValues()
    {
        var exampleFlags = new ModuleFlags(0);
        exampleFlags.OutputUpperCount.Should().Be(0);

        var otherExampleFlags = new ModuleFlags(CreateModuleFlagsValue(inputCount: 255, outputCount: 255));
        otherExampleFlags.OutputUpperCount.Should().Be(255);

        var andAnotherExampleFlags = new ModuleFlags(CreateModuleFlagsValue(inputCount: 4, outputCount: 8));
        andAnotherExampleFlags.OutputUpperCount.Should().Be(8);
    }

    [TestCase(0u)]
    [TestCase(1u)]
    [TestCase(2023u)]
    [TestCase(uint.MaxValue)]
    public void ImplicitConversion_ShouldReturnInternalValue(uint value)
    {
        var exampleFlags = (ModuleFlags)value;
        var valueFromConversion = (uint)exampleFlags;

        exampleFlags.Value.Should().Be(value);
        valueFromConversion.Should().Be(exampleFlags.Value);
        valueFromConversion.Should().Be(value);
    }
}
