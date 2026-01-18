using System.Linq;

namespace SunSharp.Tests;

public class EffectExtensionsTests
{
    [Test]
    public void IsNonLinear_ShouldReturnTrue_ForNonLinearEffects()
    {
        var nonLinearEffects = new[]
        {
            Effect.Jump,
            Effect.SetJumpMode,
            Effect.StopPlaying
        };

        foreach (var effect in nonLinearEffects)
        {
            effect.IsNonLinear().Should().BeTrue();
        }
    }

    [Test]
    public void IsNonLinear_ShouldReturnFalse_ForLinearEffects()
    {
        var linearEffects = Enum.GetValues<Effect>().Except(new[]
        {
            Effect.Jump,
            Effect.SetJumpMode,
            Effect.StopPlaying
        });
        foreach (var effect in linearEffects)
        {
            effect.IsNonLinear().Should().BeFalse();
        }
    }

    [Test]
    public void IsDestructive_ShouldReturnTrue_ForDestructiveEffects()
    {
        var destructiveEffects = new[]
        {
            Effect.DeleteEventOnTrackWithProbability,
            Effect.CyclicShiftTrackLines,
            Effect.GeneratePolyrhythm,
            Effect.CopyTrackToPattern,
            Effect.CopyTrackFromPattern,
            Effect.WriteRandomValue
        };
        foreach (var effect in destructiveEffects)
        {
            effect.IsDestructive().Should().BeTrue();
        }
    }

    [Test]
    public void IsDestructive_ShouldReturnFalse_ForNonDestructiveEffects()
    {
        var nonDestructiveEffects = Enum.GetValues<Effect>().Except(new[]
        {
            Effect.DeleteEventOnTrackWithProbability,
            Effect.CyclicShiftTrackLines,
            Effect.GeneratePolyrhythm,
            Effect.CopyTrackToPattern,
            Effect.CopyTrackFromPattern,
            Effect.WriteRandomValue
        });
        foreach (var effect in nonDestructiveEffects)
        {
            effect.IsDestructive().Should().BeFalse();
        }
    }

    [Test]
    public void ChangesTempo_ShouldReturnTrue_ForTimeModifyingEffects()
    {
        var timeModifyingEffects = new[]
        {
            Effect.SetBpm,
            Effect.SetPlayingSpeed
        };
        foreach (var effect in timeModifyingEffects)
        {
            effect.ChangesTempo().Should().BeTrue();
        }
    }

    [Test]
    public void ChangesTempo_ShouldReturnFalse_ForNonTimeModifyingEffects()
    {
        var nonTimeModifyingEffects = Enum.GetValues<Effect>().Except(new[]
        {
            Effect.SetBpm,
            Effect.SetPlayingSpeed
        });
        foreach (var effect in nonTimeModifyingEffects)
        {
            effect.ChangesTempo().Should().BeFalse();
        }
    }
}
