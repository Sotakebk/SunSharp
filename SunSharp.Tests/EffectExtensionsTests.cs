using System;
using System.Linq;
using NUnit.Framework;

namespace SunSharp.Tests;

public class EffectExtensionsTests
{
    [Test]
    public void ShouldReturnCorrectExtensionMethodValuesForDefinedEnumValues()
    {
        var nonLinearEffects = new[]
        {
            Effect.Jump,
            Effect.SetJumpMode,
            Effect.StopPlaying
        };

        var destructiveEffects = new[]
        {
            Effect.DeleteEventOnTrackWithProbability,
            Effect.CyclicShiftTrackLines,
            Effect.GeneratePolyrhythm,
            Effect.CopyTrackToPattern,
            Effect.CopyTrackFromPattern,
            Effect.WriteRandomValue
        };

        var timeModifyingEffects = new[]
        {
            Effect.SetBpm,
            Effect.SetPlayingSpeed
        };

        foreach (var effect in Enum.GetValues<Effect>())
        {
            var expectedToBeNonLinear = nonLinearEffects.Contains(effect);
            var expectedToBeDestructive = destructiveEffects.Contains(effect);
            var expectedToBeTimeModifying = timeModifyingEffects.Contains(effect);

            Assert.Multiple(() =>
            {
                Assert.That(effect.IsNonLinear(), Is.EqualTo(expectedToBeNonLinear));
                Assert.That(effect.IsDestructive(), Is.EqualTo(expectedToBeDestructive));
                Assert.That(effect.ChangesTempo(), Is.EqualTo(expectedToBeTimeModifying));
            });
        }
    }
}
