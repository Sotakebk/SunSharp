using static SunSharp.Tests.Mocks.ModuleFlagsHelper;

namespace SunSharp.Tests;

public class ModuleFlagsTests
{
    [Test]
    public void ModuleFlagsPropertiesShouldReturnValuesAsExpected()
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
    public void ModuleFlagsInputCountAndOutputCountReturnExpectedValues()
    {
        var exampleFlags = new ModuleFlags(0);
        exampleFlags.InputUpperCount.Should().Be(0);
        exampleFlags.OutputUpperCount.Should().Be(0);

        var otherExampleFlags = new ModuleFlags(CreateModuleFlagsValue(inputCount: 255, outputCount: 255));
        otherExampleFlags.InputUpperCount.Should().Be(255);
        otherExampleFlags.OutputUpperCount.Should().Be(255);

        var andAnotherExampleFlags = new ModuleFlags(CreateModuleFlagsValue(inputCount: 4, outputCount: 8));
        andAnotherExampleFlags.InputUpperCount.Should().Be(4);
        andAnotherExampleFlags.OutputUpperCount.Should().Be(8);
    }

    [TestCase(0u)]
    [TestCase(1u)]
    [TestCase(2023u)]
    [TestCase(uint.MaxValue)]
    public void ModuleFlagsImplicitConversionShouldReturnInternalValue(uint value)
    {
        var exampleFlags = (ModuleFlags)value;
        var valueFromConversion = (uint)exampleFlags;

        exampleFlags.Value.Should().Be(value);
        valueFromConversion.Should().Be(exampleFlags.Value);
        valueFromConversion.Should().Be(value);
    }
}
