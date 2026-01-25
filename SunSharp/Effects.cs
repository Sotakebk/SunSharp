namespace SunSharp
{
    /// <summary>
    /// Represents various effects that can be applied to notes or tracks in the SunVox pattern.
    /// </summary>
    public enum Effect : byte
    {
        /// <summary>
        /// No effect applied.
        /// </summary>
        None = 0,

        /// <summary>
        /// Slide up (portamento up). Sliding speed = XXYY.
        /// Can use the last nonzero parameter when XXYY = 0x0000.
        /// </summary>
        SlideUp = 0x01,

        /// <summary>
        /// Slide down (portamento down). Sliding speed = XXYY.
        /// Can use the last nonzero parameter when XXYY = 0x0000.
        /// </summary>
        SlideDown = 0x02,

        /// <summary>
        /// Slide to note. Sliding speed = XXYY.
        /// Can use the last nonzero parameter when XXYY = 0x0000.
        /// </summary>
        SlideToNote = 0x03,

        /// <summary>
        /// Vibrato. XX - frequency; YY - amplitude.
        /// Can use the last nonzero parameter when XXYY = 0x0000.
        /// </summary>
        Vibrato = 0x04,

        /// <summary>
        /// Pitch bend up: pitch = original pitch (initialized when a note is activated) + XXYY.
        /// One semitone = 0x0100.
        /// </summary>
        PitchBendUp = 0x05,

        /// <summary>
        /// Pitch bend down: pitch = original pitch (initialized when a note is activated) - XXYY.
        /// One semitone = 0x0100.
        /// </summary>
        PitchBendDown = 0x06,

        /// <summary>
        /// Set phase (or sample offset) XXYY in percents (from 0x0000 (0%) to 0x8000 (100%)).
        /// </summary>
        SetPhasePercents = 0x07,

        /// <summary>
        /// Arpeggio. XX - second note increment; YY - third note increment.
        /// </summary>
        Arpeggio = 0x08,

        /// <summary>
        /// Set phase (or sample offset) XXYY in samples*0x0100.
        /// </summary>
        SetPhase = 0x09,

        /// <summary>
        /// Velocity slide up/down. XX - up speed; YY - down speed.
        /// Can use the last nonzero parameter when XXYY = 0x0000.
        /// </summary>
        VelocitySlide = 0x0A,

        /// <summary>
        /// Set playing speed or time grids.
        /// XXYY: 0x0001 to 0x001F - number of ticks per line; 0x0020 to 0x00FF - BPM;
        /// XXYY: 0xF001 to 0xF020 and 0xF100 to 0xF120 - time grids.
        /// </summary>
        SetPlayingSpeed = 0x0F,

        /// <summary>
        /// Fine slide up. XXYY specifies the amount.
        /// </summary>
        FineSlideUp = 0x11,

        /// <summary>
        /// Fine slide down. XXYY specifies the amount.
        /// </summary>
        FineSlideDown = 0x12,

        /// <summary>
        /// Set Bypass/Solo/Mute (BSM = XYY) flags.
        /// Bypass - 0x0100; Solo - 0x0010; Mute - 0x0001.
        /// </summary>
        SetBypassSoloMute = 0x13,

        /// <summary>
        /// Reset Bypass/Solo/Mute (BSM = XYY) flags.
        /// Bypass - 0x0100; Solo - 0x0010; Mute - 0x0001.
        /// </summary>
        ResetBypassSoloMute = 0x14,

        /// <summary>
        /// Change the relative note and finetune of the module.
        /// XX - relative note (0x00 - ignore; 0x01 = -127 decimal; 0x80 = 0x0; 0xFF = 127 decimal);
        /// YY - finetune (0x00 - ignore; 0x01 = one semitone lower; 0x80 = 0x0; 0xFF = one semitone higher).
        /// </summary>
        ChangeModuleFineTune = 0x15,

        /// <summary>
        /// Retrigger note after XXYY ticks during the line.
        /// </summary>
        Retrigger = 0x19,

        /// <summary>
        /// Fine velocity slide up/down. XX - up speed; YY - down speed.
        /// Applied once at the beginning of a line.
        /// </summary>
        FineVelocitySlide = 0x1A,

        /// <summary>
        /// Cut note after YY ticks in the current line.
        /// </summary>
        CutNote = 0x1C,

        /// <summary>
        /// Delay the start of note until tick YY in the current line.
        /// </summary>
        DelayNote = 0x1D,

        /// <summary>
        /// Set BPM to XXYY.
        /// </summary>
        SetBpm = 0x1F,

        /// <summary>
        /// Note probability. XXYY specifies the probability.
        /// </summary>
        NoteProbability = 0x20,

        /// <summary>
        /// Note probability with random velocity. XXYY specifies the probability.
        /// </summary>
        NoteProbabilityRandomVelocity = 0x21,

        /// <summary>
        /// Set controller value to a random number from 0x0000 to XXYY.
        /// </summary>
        SetControllerRandomAbsolute = 0x22,

        /// <summary>
        /// Set controller value to a random number with range from XX (0x00 to 0xFF) to YY (0x00 to 0xFF).
        /// </summary>
        SetControllerRandomRange = 0x23,

        /// <summary>
        /// Take a note from line XXYY on the same track.
        /// </summary>
        PlayNoteFromLine = 0x24,

        /// <summary>
        /// Take a random note from the range of lines XX..YY (inclusive) on the same track.
        /// </summary>
        PlayRandomNoteFromRange = 0x25,

        /// <summary>
        /// Take a note from track XXYY on the same line.
        /// </summary>
        PlayNoteRandomTrackSameLine = 0x26,

        /// <summary>
        /// Take a random note from the range of tracks XX..YY (inclusive) on the same line.
        /// </summary>
        PlayRandomNoteFromRangeTracksSameLine = 0x27,

        /// <summary>
        /// Take a note from line XXYY on track 0x0.
        /// </summary>
        PlayNoteFromLineOnTrackZero = 0x28,

        /// <summary>
        /// Take a random note from the range of lines XX..YY (inclusive) on track 0x0.
        /// </summary>
        PlayRandomNoteFromRangeOnTrackZero = 0x29,

        /// <summary>
        /// Stop playing the song.
        /// </summary>
        StopPlaying = 0x30,

        /// <summary>
        /// Jump to line XXYY (address) right after the end of the current line.
        /// </summary>
        Jump = 0x31,

        /// <summary>
        /// Set jump address mode YY:
        /// 0x0 - absolute address, relative to the start of the timeline (default);
        /// 0x1 - (pattern beginning + address);
        /// 0x2 - (pattern beginning - address);
        /// 0x3 - (next line + address);
        /// 0x4 - (next line - address).
        /// </summary>
        SetJumpMode = 0x32,

        /// <summary>
        /// Slot sync (for sv_sync_resume() in SunVox library).
        /// </summary>
        SlotSync = 0x33,

        /// <summary>
        /// Set (XX) or reset (YY) project options:
        /// 0x1 - no portamento on the first tick (for compatibility with old tracker formats);
        /// 0x2 - no velocity slide on the first tick (for compatibility with old tracker formats);
        /// 0x4 - use Round-robin keyboard track allocation algorithm, instead of default tight packing;
        /// 0x8 - always output 7-bit MIDI controller values, even if the controller is 14-bit (0x0-0x1F).
        /// </summary>
        SetResetProjectOptions = 0x34,

        /// <summary>
        /// Bind MIDI OUT message XX (0x0 - Program Change; 0x1 - Channel Pressure; 0x2 - Pitch Bend Change)
        /// to controller YY (0x0 - OFF; 0x80 - MIDI controller 0x0; 0x81 - MIDI controller 0x1...).
        /// For the specified module only.
        /// </summary>
        BindMidiOut = 0x35,

        /// <summary>
        /// Delete an event on track XX with a probability of YY (0x00 to 0xFF (100%)).
        /// Destructive effect - irreversibly changes the contents of the pattern.
        /// </summary>
        DeleteEventOnTrackWithProbability = 0x38,

        /// <summary>
        /// Cyclic shift of track XX down by YY lines.
        /// Destructive effect - irreversibly changes the contents of the pattern.
        /// </summary>
        CyclicShiftTrackLines = 0x39,

        /// <summary>
        /// Generate a new iteration of YY-line polyrhythm on track XX.
        /// Destructive effect - irreversibly changes the contents of the pattern.
        /// </summary>
        GeneratePolyrhythm = 0x3A,

        /// <summary>
        /// Copy track XX to the pattern named YY.
        /// Destructive effect - irreversibly changes the contents of the pattern.
        /// </summary>
        CopyTrackToPattern = 0x3B,

        /// <summary>
        /// Copy track XX from the pattern YY.
        /// For example, if XXYY = 0x0023, then the first track will be copied from the pattern named "23".
        /// Destructive effect - irreversibly changes the contents of the pattern.
        /// </summary>
        CopyTrackFromPattern = 0x3C,

        /// <summary>
        /// Write a random value to track YY.
        /// Min value, max value and column must be in track 0x0, starting from line XX.
        /// Destructive effect - irreversibly changes the contents of the pattern.
        /// </summary>
        WriteRandomValue = 0x3D,

        /// <summary>
        /// Delays an event for 0x0/0x20 of line duration.
        /// </summary>
        Delay0 = 0x40,

        /// <summary>
        /// Delays an event for 0x1/0x20 of line duration.
        /// </summary>
        Delay1 = 0x41,

        /// <summary>
        /// Delays an event for 0x2/0x20 of line duration.
        /// </summary>
        Delay2 = 0x42,

        /// <summary>
        /// Delays an event for 0x3/0x20 of line duration.
        /// </summary>
        Delay3 = 0x43,

        /// <summary>
        /// Delays an event for 0x4/0x20 of line duration.
        /// </summary>
        Delay4 = 0x44,

        /// <summary>
        /// Delays an event for 0x5/0x20 of line duration.
        /// </summary>
        Delay5 = 0x45,

        /// <summary>
        /// Delays an event for 0x6/0x20 of line duration.
        /// </summary>
        Delay6 = 0x46,

        /// <summary>
        /// Delays an event for 0x7/0x20 of line duration.
        /// </summary>
        Delay7 = 0x47,

        /// <summary>
        /// Delays an event for 0x8/0x20 of line duration.
        /// </summary>
        Delay8 = 0x48,

        /// <summary>
        /// Delays an event for 0x9/0x20 of line duration.
        /// </summary>
        Delay9 = 0x49,

        /// <summary>
        /// Delays an event for 0xA/0x20 of line duration.
        /// </summary>
        Delay10 = 0x4A,

        /// <summary>
        /// Delays an event for 0xB/0x20 of line duration.
        /// </summary>
        Delay11 = 0x4B,

        /// <summary>
        /// Delays an event for 0xC/0x20 of line duration.
        /// </summary>
        Delay12 = 0x4C,

        /// <summary>
        /// Delays an event for 0xD/0x20 of line duration.
        /// </summary>
        Delay13 = 0x4D,

        /// <summary>
        /// Delays an event for 0xE/0x20 of line duration.
        /// </summary>
        Delay14 = 0x4E,

        /// <summary>
        /// Delays an event for 0xF/0x20 of line duration.
        /// </summary>
        Delay15 = 0x4F,

        /// <summary>
        /// Delays an event for 0x10/0x20 of line duration.
        /// </summary>
        Delay16 = 0x50,

        /// <summary>
        /// Delays an event for 0x11/0x20 of line duration.
        /// </summary>
        Delay17 = 0x51,

        /// <summary>
        /// Delays an event for 0x12/0x20 of line duration.
        /// </summary>
        Delay18 = 0x52,

        /// <summary>
        /// Delays an event for 0x13/0x20 of line duration.
        /// </summary>
        Delay19 = 0x53,

        /// <summary>
        /// Delays an event for 0x14/0x20 of line duration.
        /// </summary>
        Delay20 = 0x54,

        /// <summary>
        /// Delays an event for 0x15/0x20 of line duration.
        /// </summary>
        Delay21 = 0x55,

        /// <summary>
        /// Delays an event for 0x16/0x20 of line duration.
        /// </summary>
        Delay22 = 0x56,

        /// <summary>
        /// Delays an event for 0x17/0x20 of line duration.
        /// </summary>
        Delay23 = 0x57,

        /// <summary>
        /// Delays an event for 0x18/0x20 of line duration.
        /// </summary>
        Delay24 = 0x58,

        /// <summary>
        /// Delays an event for 0x19/0x20 of line duration.
        /// </summary>
        Delay25 = 0x59,

        /// <summary>
        /// Delays an event for 0x1A/0x20 of line duration.
        /// </summary>
        Delay26 = 0x5A,

        /// <summary>
        /// Delays an event for 0x1B/0x20 of line duration.
        /// </summary>
        Delay27 = 0x5B,

        /// <summary>
        /// Delays an event for 0x1C/0x20 of line duration.
        /// </summary>
        Delay28 = 0x5C,

        /// <summary>
        /// Delays an event for 0x1D/0x20 of line duration.
        /// </summary>
        Delay29 = 0x5D,

        /// <summary>
        /// Delays an event for 0x1E/0x20 of line duration.
        /// </summary>
        Delay30 = 0x5E,

        /// <summary>
        /// Delays an event for 0x1F/0x20 of line duration.
        /// </summary>
        Delay31 = 0x5F,
    }

    public static class EffectExtensions
    {
        /// <summary>
        /// Determines whether the specified effect is non-linear.
        /// </summary>
        /// <remarks>
        /// Non-linear effects are those that alter the normal sequential flow of pattern playback,
        /// such as jumps or stops, rather than modifying the sound or parameters of the notes being played.
        /// </remarks>
        public static bool IsNonLinear(this Effect effect)
        {
            return effect == Effect.Jump
                   || effect == Effect.SetJumpMode
                   || effect == Effect.StopPlaying;
        }

        /// <summary>
        /// Determines whether the specified effect is destructive.
        /// </summary>
        /// <remarks>
        /// Destructive effects are those that can remove or overwrite existing data in the pattern,
        /// potentially leading to loss of information.
        /// The effects considered destructive include deleting events, shifting track lines,
        /// generating polyrhythms, copying tracks, and writing random values.
        /// </remarks>
        public static bool IsDestructive(this Effect effect)
        {
            return effect == Effect.DeleteEventOnTrackWithProbability
                   || effect == Effect.CyclicShiftTrackLines
                   || effect == Effect.GeneratePolyrhythm
                   || effect == Effect.CopyTrackToPattern
                   || effect == Effect.CopyTrackFromPattern
                   || effect == Effect.WriteRandomValue;
        }

        /// <summary>
        /// Determines whether the specified effect changes the tempo.
        /// </summary>
        /// <remarks>
        /// Tempo-changing effects are those that modify the speed or BPM (beats per minute) of the playback.
        /// </remarks>
        public static bool ChangesTempo(this Effect effect)
        {
            return effect == Effect.SetBpm
                   || effect == Effect.SetPlayingSpeed;
        }

        /// <summary>
        /// Determines whether the specified effect is an event delay effect.
        /// </summary>
        /// <remarks>
        /// Event delay effects (0x40 to 0x5F) delay an event for a selected fraction of the line,
        /// from 0% to 96.875%.
        /// </remarks>
        public static bool IsEventDelay(this Effect effect)
        {
            return effect >= Effect.Delay0 && effect <= Effect.Delay31;
        }
    }
}
