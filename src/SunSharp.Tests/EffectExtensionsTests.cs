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

    [Test]
    public void IsEventDelay_ShouldReturnTrue_ForDelayEffects()
    {
        var delayEffects = new[]
        {
            Effect.Delay0,
            Effect.Delay1,
            Effect.Delay2,
            Effect.Delay3,
            Effect.Delay4,
            Effect.Delay5,
            Effect.Delay6,
            Effect.Delay7,
            Effect.Delay8,
            Effect.Delay9,
            Effect.Delay10,
            Effect.Delay11,
            Effect.Delay12,
            Effect.Delay13,
            Effect.Delay14,
            Effect.Delay15,
            Effect.Delay16,
            Effect.Delay17,
            Effect.Delay18,
            Effect.Delay19,
            Effect.Delay20,
            Effect.Delay21,
            Effect.Delay22,
            Effect.Delay23,
            Effect.Delay24,
            Effect.Delay25,
            Effect.Delay26,
            Effect.Delay27,
            Effect.Delay28,
            Effect.Delay29,
            Effect.Delay30,
            Effect.Delay31
        };
        foreach (var effect in delayEffects)
        {
            effect.IsEventDelay().Should().BeTrue();
        }
    }

    [Test]
    public void IsEventDelay_ShouldReturnFalse_ForNonDelayEffects()
    {
        var nonDelayEffects = Enum.GetValues<Effect>().Where(e => e < Effect.Delay0 || e > Effect.Delay31);
        foreach (var effect in nonDelayEffects)
        {
            effect.IsEventDelay().Should().BeFalse();
        }
    }
}
