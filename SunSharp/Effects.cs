namespace SunSharp
{
    public enum Effect : byte
    {
        None = 0,

        SlideUp = 0x01,
        SlideDown = 0x02,
        SlideToNote = 0x03,
        Vibrato = 0x04,
        PitchBendUp = 0x05,
        PitchBendDown = 0x06,
        SetPhasePercents = 0x07,
        Arpeggio = 0x08,
        SetPhase = 0x09,
        VelocitySlide = 0x0A,
        SetPlayingSpeed = 0x0F,
        FineSlideUp = 0x11,
        FineSlideDown = 0x12,
        SetBypassSoloMute = 0x13,
        ResetBypassSoloMute = 0x14,
        ChangeModuleFinetune = 0x15,
        Retrigger = 0x19,
        FineVelocitySlide = 0x1A,
        CutNote = 0x1C,
        DelayNote = 0x1D,
        SetBpm = 0x1F,
        NoteProbability = 0x20,
        NoteProbabilityRandomVelocity = 0x21,
        SetControllerRandomAbsolute = 0x22,
        SetControllerRandomRange = 0x23,
        PlayNoteFromLine = 0x24,
        PlayRandomNoteFromRange = 0x25,
        PlayNoteRandomTrackSameLine = 0x26,
        PlayRandomNoteFromRangeTracksSameLine = 0x27,
        PlayNoteFromLineOnTrackZero = 0x28,
        PlayRandomNoteFromRangeOnTrackZero = 0x29,
        StopPlaying = 0x30,
        Jump = 0x31,
        SetJumpMode = 0x32,
        SlotSync = 0x33,
        SetResetProjectOptions = 0x34,
        BindMidiOut = 0x35,
        DeleteEventOnTrackWithProbability = 0x38,
        CyclicShiftTrackLines = 0x39,
        GeneratePolyrhythm = 0x3A,
        CopyTrackToPattern = 0x3B,
        CopyTrackFromPattern = 0x3C,
        WriteRandomValue = 0x3D,
    }

    public static class EffectExtensions
    {
        public static bool IsNonLinear(this Effect effect)
        {
            return effect == Effect.Jump
                   || effect == Effect.SetJumpMode
                   || effect == Effect.StopPlaying;
        }

        public static bool IsDestructive(this Effect effect)
        {
            return effect == Effect.DeleteEventOnTrackWithProbability
                   || effect == Effect.CyclicShiftTrackLines
                   || effect == Effect.GeneratePolyrhythm
                   || effect == Effect.CopyTrackToPattern
                   || effect == Effect.CopyTrackFromPattern
                   || effect == Effect.WriteRandomValue;
        }

        public static bool ModifiesTime(this Effect effect)
        {
            return effect == Effect.SetBpm
                   || effect == Effect.SetPlayingSpeed;
        }
    }
}
