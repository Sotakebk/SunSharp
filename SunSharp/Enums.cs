using System;
using System.Diagnostics.CodeAnalysis;

namespace SunSharp
{
    public enum AudioChannel
    {
        Mono = 0,
        Left = Mono,
        Right = 1
    }

    public enum AudioChannels
    {
        Mono = 1,
        Stereo = 2
    }

    public enum Column
    {
        /// <summary>
        /// The 'Note' column (NN).
        /// </summary>
        Note = 0,

        /// <summary>
        /// The 'Velocity' column (VV).
        /// </summary>
        Velocity = 1,

        /// <summary>
        /// The 'Module' column (MM).
        /// </summary>
        Module = 2,

        /// <summary>
        /// The 'Controller Effect' column (CCEE).
        /// </summary>
        ControllerEffect = 3,

        /// <summary>
        /// The 'Parameter' column (XXYY).
        /// </summary>
        Parameter = 4
    }

    public enum TimeMapType
    {
        Speed = SunVoxConstants.SV_TIME_MAP_SPEED,
        FrameCount = SunVoxConstants.SV_TIME_MAP_FRAMECNT
    }

    public enum ValueScalingMode
    {
        Real = 0,
        Column = 1,
        Displayed = 2
    }

    public enum ControllerType
    {
        Real = 0,
        Enum = 1
    }

    [Flags]
    public enum SunVoxInitOptions : uint
    {
        None = 0,

        /// <summary>
        /// Less information will be written to standard output.
        /// </summary>
        NoDebugOutput = SunVoxConstants.SV_INIT_FLAG_NO_DEBUG_OUTPUT,

        /// <summary>
        /// No automatic sound management, sv_audio_callback must be used.
        /// </summary>
        UserAudioCallback = SunVoxConstants.SV_INIT_FLAG_USER_AUDIO_CALLBACK,

        /// <summary>
        /// Sets the format which must be used with sv_audio_callback to <see cref="short" />.
        /// May not apply without <see cref="UserAudioCallback" />. Mutually exclusive with <see cref="AudioFloat32" />.
        /// </summary>
        AudioInt16 = SunVoxConstants.SV_INIT_FLAG_AUDIO_INT16,

        /// <summary>
        /// Sets the format which must be used with sv_audio_callback to <see cref="float" />.
        /// May not apply without <see cref="UserAudioCallback" />. Mutually exclusive with <see cref="AudioInt16" />.
        /// </summary>
        AudioFloat32 = SunVoxConstants.SV_INIT_FLAG_AUDIO_FLOAT32,

        /// <summary>
        /// Audio callback and other methods will be called from one thread.
        /// Applies if <see cref="UserAudioCallback" /> is set.
        /// </summary>
        OneThread = SunVoxConstants.SV_INIT_FLAG_ONE_THREAD
    }

    [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "The enum is supposed to help with choosing a type.")]
    public enum OutputType
    {
        Float32 = 1,
        Int16 = 2
    }

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
        ChangeModuleFineTune = 0x15,
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
        WriteRandomValue = 0x3D
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
    }
}
