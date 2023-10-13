using NUnit.Framework;
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

            Assert.Multiple(() =>
            {
                Assert.That(flag.Exists, Is.EqualTo((i & (1 << 0)) != 0));
                Assert.That(flag.Generator, Is.EqualTo((i & (1 << 1)) != 0));
                Assert.That(flag.Effect, Is.EqualTo((i & (1 << 2)) != 0));
                Assert.That(flag.Mute, Is.EqualTo((i & (1 << 3)) != 0));
                Assert.That(flag.Solo, Is.EqualTo((i & (1 << 4)) != 0));
                Assert.That(flag.Bypass, Is.EqualTo((i & (1 << 5)) != 0));
            });
        }
    }

    [Test]
    public void ModuleFlagsInputCountAndOutputCountReturnExpectedValues()
    {
        var exampleFlags = new ModuleFlags(0);
        Assert.Multiple(() =>
        {
            Assert.That(exampleFlags.InputUpperCount, Is.EqualTo(0));
            Assert.That(exampleFlags.OutputUpperCount, Is.EqualTo(0));
        });

        var otherExampleFlags = new ModuleFlags(CreateModuleFlagsValue(inputCount: 255, outputCount: 255));
        Assert.Multiple(() =>
        {
            Assert.That(otherExampleFlags.InputUpperCount, Is.EqualTo(255));
            Assert.That(otherExampleFlags.OutputUpperCount, Is.EqualTo(255));
        });

        var andAnotherExampleFlags = new ModuleFlags(CreateModuleFlagsValue(inputCount: 4, outputCount: 8));
        Assert.Multiple(() =>
        {
            Assert.That(andAnotherExampleFlags.InputUpperCount, Is.EqualTo(4));
            Assert.That(andAnotherExampleFlags.OutputUpperCount, Is.EqualTo(8));
        });
    }

    [TestCase(0u)]
    [TestCase(1u)]
    [TestCase(2023u)]
    [TestCase(uint.MaxValue)]
    public void ModuleFlagsImplicitConversionShouldReturnInternalValue(uint value)
    {
        var exampleFlags = (ModuleFlags)value;
        var valueFromConversion = (uint)exampleFlags;

        Assert.Multiple(() =>
        {
            Assert.That(exampleFlags.Value, Is.EqualTo(value));
            Assert.That(valueFromConversion, Is.EqualTo(exampleFlags.Value));
            Assert.That(valueFromConversion, Is.EqualTo(value));
        });
    }
}
