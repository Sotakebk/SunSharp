using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    /// <summary>
    /// Represents a SunVox pattern event that encodes music commands such as notes, effects, and
    /// controller changes in a compact 64-bit format.
    /// </summary>
    /// <remarks>
    /// For better readability, consider using the property accessors and factory methods provided.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PatternEvent : IEquatable<PatternEvent>
    {
        /// <summary>
        /// Raw 64-bit data representing the entire event.
        /// </summary>
        [field: FieldOffset(0)] public ulong Data { get; set; }

        /// <summary>
        /// Note number or special command. Consider using <see cref="Note"/> instead.
        /// </summary>
        [field: FieldOffset(0)] public byte NN { get; set; }

        /// <summary>
        /// Raw velocity value (actual velocity + 1). A value of 0 indicates default velocity should be used.
        /// Consider using <see cref="Velocity"/> property instead for automatic offset handling.
        /// </summary>
        [field: FieldOffset(1)] public byte VV { get; set; }

        /// <summary>
        /// Raw module number (actual module ID + 1). A value of 0 indicates no module is targeted.
        /// Consider using <see cref="ModuleId"/> property instead for automatic offset handling.
        /// </summary>
        [field: FieldOffset(2)] public ushort MM { get; set; }

        /// <summary>
        /// Combined controller and effect code as a 16-bit value (high byte = CC, low byte = EE).
        /// Consider using <see cref="ControllerId"/> and <see cref="Effect"/> properties instead
        /// for better readability.
        /// </summary>
        [field: FieldOffset(4)] public ushort CCEE { get; set; }

        /// <summary>
        /// Raw effect code (low byte of CCEE). Consider using <see cref="Effect"/> property instead
        /// for type-safe effect handling.
        /// </summary>
        [field: FieldOffset(4)] public byte EE { get; set; }

        /// <summary>
        /// Raw controller number (high byte of CCEE, actual controller + 1).
        /// Consider using <see cref="ControllerId"/> property instead for automatic offset handling.
        /// </summary>
        [field: FieldOffset(5)] public byte CC { get; set; }

        /// <summary>
        /// Combined 16-bit parameter value (low byte = XX, high byte = YY).
        /// </summary>
        [field: FieldOffset(6)] public ushort XXYY { get; set; }

        /// <summary>
        /// High byte of parameter value (upper 8 bits of XXYY).
        /// </summary>
        [field: FieldOffset(7)] public byte YY { get; set; }

        /// <summary>
        /// Low byte of parameter value (lower 8 bits of XXYY).
        /// </summary>
        [field: FieldOffset(6)] public byte XX { get; set; }

        /// <summary>
        /// Note value. Allows for explicit note commands.
        /// </summary>
        public Note Note
        {
            readonly get => NN;
            set => NN = value;
        }

        /// <summary>
        /// Note velocity. Returns null when default velocity is used. Automatically handles the +1
        /// offset used in raw data.
        /// </summary>
        public byte? Velocity
        {
            readonly get => VV == 0 ? null : (byte?)(VV - 1);
            set => VV = value == null ? (byte)0 : (byte)(value + 1);
        }

        /// <summary>
        /// Module identifier (0-based). Returns null when no module is specified. Automatically handles
        /// the +1 offset used in raw data.
        /// </summary>
        public int? ModuleId
        {
            readonly get => MM == 0 ? null : (ushort?)(MM - 1);
            set => MM = (value == null) ? (ushort)0 : (ushort)(value + 1);
        }

        /// <summary>
        /// Pattern event effect code.
        /// </summary>
        public Effect Effect
        {
            readonly get => (Effect)EE;
            set => EE = (byte)value;
        }

        /// <summary>
        /// Controller identifier (0-based). Returns <see langword="null"/> when no controller is specified.
        /// Module controllers: 0-126 (raw data: 1-127).
        /// MIDI controllers: 127+ (raw data: 0x80+).
        /// Automatically handles the +1 offset used in raw data.
        /// </summary>
        public byte? ControllerId
        {
            readonly get => CC == 0 ? null : (byte?)(CC - 1);
            set => CC = value == null ? (byte)0 : (byte)(value + 1);
        }

        /// <summary>
        /// Parameter value for controller or effect (16-bit unsigned integer).
        /// <para>Range: 0-32768 (0x8000) for controllers, 0-65535 (0xFFFF) for effects.</para>
        /// <para>For pitch commands: 0x0000 = highest pitch, 0x7800 = C0, 0x100 = one semitone.</para>
        /// </summary>
        public ushort Value
        {
            readonly get => XXYY;
            set => XXYY = value;
        }

        /// <summary>
        /// Gets a value indicating whether this event contains a note command (musical note or special command).
        /// </summary>
        public readonly bool HasNote => NN != 0;

        /// <summary>
        /// Gets a value indicating whether this event contains an explicit velocity value (not using default).
        /// </summary>
        public readonly bool HasVelocity => VV != 0;

        /// <summary>
        /// Gets a value indicating whether this event targets a specific module.
        /// </summary>
        public readonly bool HasModule => MM != 0;

        /// <summary>
        /// Gets a value indicating whether this event contains a controller change.
        /// </summary>
        public readonly bool HasController => CC != 0;

        /// <summary>
        /// Gets a value indicating whether this event contains an effect command.
        /// </summary>
        public readonly bool HasEffect => EE != 0;

        /// <summary>
        /// Gets a value indicating whether this event contains a non-zero parameter value.
        /// </summary>
        public readonly bool HasValue => XXYY != 0;

        /// <summary>
        /// Whether this is an empty event (all fields zero).
        /// </summary>
        public readonly bool IsEmpty => Data == 0;

        /// <summary>
        /// Gets an empty pattern event with all fields set to zero (represents a blank pattern cell).
        /// </summary>
        public static PatternEvent Empty => new PatternEvent(0);

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternEvent"/> struct from raw 64-bit data.
        /// </summary>
        /// <param name="value">The raw 64-bit value containing all event fields.</param>
        public PatternEvent(ulong value) : this()
        {
            Data = value;
        }

        /// <summary>
        /// Initializes a pattern event with individual fields. Uses raw data format.
        /// </summary>
        /// <remarks>
        /// Consider using factory methods for better readability.
        /// </remarks>
        /// <param name="nn"><inheritdoc cref="NN" path="/summary"/></param>
        /// <param name="vv"><inheritdoc cref="VV" path="/summary"/></param>
        /// <param name="mm"><inheritdoc cref="MM" path="/summary"/></param>
        /// <param name="cc"><inheritdoc cref="CC" path="/summary"/></param>
        /// <param name="ee"><inheritdoc cref="EE" path="/summary"/></param>
        /// <param name="xxyy"><inheritdoc cref="XXYY" path="/summary"/></param>
        public PatternEvent(byte nn, byte vv, ushort mm, byte cc, byte ee, ushort xxyy) : this()
        {
            NN = nn;
            VV = vv;
            MM = mm;
            CC = cc;
            EE = ee;
            XXYY = xxyy;
        }

        /// <summary>
        /// Creates a note event that triggers a note on the specified module.
        /// </summary>
        /// <param name="note"><inheritdoc cref="Note" path="/summary"/></param>
        /// <param name="moduleId"><inheritdoc cref="ModuleId" path="/summary"/></param>
        /// <param name="velocity"><inheritdoc cref="Velocity" path="/summary"/></param>
        public static PatternEvent NoteEvent(Note note, int? moduleId, byte? velocity = null)
        {
            return new PatternEvent()
            {
                Note = note,
                ModuleId = moduleId,
                Velocity = velocity
            };
        }

        /// <summary>
        /// Creates a controller event that changes a module parameter.
        /// </summary>
        /// <param name="moduleId"><inheritdoc cref="ModuleId" path="/summary"/></param>
        /// <param name="controller"><inheritdoc cref="ControllerId" path="/summary"/></param>
        /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
        /// <remarks>
        /// For better type safety and readability, consider using typed module handles and extension methods.
        /// </remarks>
        public static PatternEvent ControllerEvent(int moduleId, byte controller, ushort value)
        {
            return new PatternEvent()
            {
                ModuleId = moduleId,
                ControllerId = controller,
                Value = value
            };
        }

        /// <summary>
        /// Creates an effect event that applies a pattern effect.
        /// </summary>
        /// <param name="moduleId"><inheritdoc cref="ModuleId" path="/summary"/></param>
        /// <param name="effect"><inheritdoc cref="Effect" path="/summary"/></param>
        /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
        /// <returns>A new <see cref="PatternEvent"/> configured as an effect event.</returns>
        public static PatternEvent EffectEvent(int? moduleId, Effect effect, ushort value)
        {
            return new PatternEvent()
            {
                ModuleId = moduleId,
                Effect = effect,
                Value = value
            };
        }

        /// <summary>
        /// Creates a Set Pitch event with exact pitch value for microtonal or pitch-bend effects.
        /// </summary>
        /// <param name="moduleId">Module number (0-based).</param>
        /// <param name="pitch">Pitch value where 0x0000 = highest pitch, 0x7800 = C0 (lowest), 0x100 = one semitone.</param>
        /// <param name="velocity">Velocity value (0-128). Use <see langword="null"/> for default velocity.</param>
        /// <returns>A new <see cref="PatternEvent"/> configured as a set pitch event.</returns>
        /// <example>
        /// <code>
        /// // Set pitch to middle C (C4 = 0x3C00)
        /// var middleC = PatternEvent.SetPitchEvent(0, 0x3C00);
        /// // Set pitch to A4 (440Hz reference = 0x4500)
        /// var a440 = PatternEvent.SetPitchEvent(0, 0x4500, 100);
        /// </code>
        /// </example>
        public static PatternEvent SetPitchEvent(int moduleId, ushort pitch, byte? velocity = null)
        {
            return new PatternEvent()
            {
                Note = Note.SetPitch,
                ModuleId = moduleId,
                Velocity = velocity,
                Value = pitch
            };
        }

        /// <summary>
        /// Creates a Set Pitch event by converting a frequency in Hz to the appropriate pitch value.
        /// </summary>
        /// <param name="moduleId">Module number (0-based).</param>
        /// <param name="frequency">Frequency in Hz (e.g., 440.0 for A4).</param>
        /// <param name="velocity">Velocity value (0-128). Use <see langword="null"/> for default velocity.</param>
        /// <returns>A new <see cref="PatternEvent"/> with the calculated pitch value.</returns>
        /// <example>
        /// <code>
        /// // Set pitch to A4 (440 Hz)
        /// var a440 = PatternEvent.SetFrequencyEvent(0, 440.0, 100);
        /// // Set pitch to middle C (261.63 Hz)
        /// var c4 = PatternEvent.SetFrequencyEvent(0, 261.63);
        /// </code>
        /// </example>
        public static PatternEvent SetFrequencyEvent(int moduleId, double frequency, byte? velocity = null)
        {
            var pitch = (ushort)Microtones.FrequencyToPitch(frequency);
            return SetPitchEvent(moduleId, pitch, velocity);
        }

        /// <summary>
        /// Creates a new generic pattern event with optional parameters for flexible event construction.
        /// </summary>
        /// <param name="note"><inheritdoc cref="Note" path="/summary"/></param>
        /// <param name="velocity"><inheritdoc cref="Velocity" path="/summary"/></param>
        /// <param name="moduleId"><inheritdoc cref="ModuleId" path="/summary"/></param>
        /// <param name="controller"><inheritdoc cref="ControllerId" path="/summary"/></param>
        /// <param name="effect"><inheritdoc cref="Effect" path="/summary"/></param>
        /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
        /// <returns>A new <see cref="PatternEvent"/> with the specified fields.</returns>
        /// <remarks>
        /// This method provides maximum flexibility for creating events. For common scenarios,
        /// consider using specific factory methods like <see cref="NoteEvent"/>, <see cref="ControllerEvent"/>, etc.
        /// </remarks>
        public static PatternEvent NewEvent(Note note = default, byte? velocity = null, int? moduleId = null, byte? controller = null, Effect effect = Effect.None, ushort value = 0)
        {
            return new PatternEvent()
            {
                Note = note,
                Velocity = velocity,
                ModuleId = moduleId,
                ControllerId = controller,
                Effect = effect,
                Value = value
            };
        }

        /// <summary>
        /// Merges two events, with non-zero values from <paramref name="second"/> overwriting
        /// corresponding values in <paramref name="first"/>.
        /// </summary>
        /// <param name="first">The base event providing default values.</param>
        /// <param name="second">The event whose non-zero fields override the base event.</param>
        /// <returns>A merged <see cref="PatternEvent"/> combining both inputs.</returns>
        /// <remarks>
        /// This performs a field-by-field merge where any non-zero field in <paramref name="second"/>
        /// replaces the corresponding field in <paramref name="first"/>. Useful for layering
        /// pattern data or applying partial updates.
        /// </remarks>
        public static PatternEvent Merge(PatternEvent first, PatternEvent second)
        {
            return new PatternEvent()
            {
                NN = second.NN != 0 ? second.NN : first.NN,
                VV = second.VV != 0 ? second.VV : first.VV,
                MM = second.MM != 0 ? second.MM : first.MM,
                EE = second.EE != 0 ? second.EE : first.EE,
                CC = second.CC != 0 ? second.CC : first.CC,
                XXYY = second.XXYY != 0 ? second.XXYY : first.XXYY
            };
        }

        public static implicit operator PatternEvent(ulong value)
        {
            return new PatternEvent(value);
        }

        public static implicit operator ulong(PatternEvent @event)
        {
            return @event.Data;
        }

        /// <summary>
        /// Column header string for pattern display: "NNVVMMMMCCEEXXYY".
        /// </summary>
        /// <remarks>
        /// Primarily used for formatting pattern output in tracker-style displays.
        /// </remarks>
        public const string PatternEventHeaderString = "NNVVMMMMCCEEXXYY";

        /// <summary>
        /// Returns hexadecimal string representation that roughly follows the SunVox format.
        /// Empty fields shown as spaces.
        /// </summary>
        /// <remarks>
        /// Some examples of the output format:
        /// <list type="bullet">
        /// <item><description>"C4__00001________" - Note C4 on module 0, no velocity, no effect/controller/value.</description></item>
        /// <item><description>"__64__0001_02_1000" - Velocity 100 on module 0, controller 2 set to 4096.</description></item>
        /// </list>
        /// <para>
        /// Keep in mind:
        /// <list type="bullet">
        /// <item><description>Module number (MMMM) is as displayed in SunVox, incremented by one compared to library-side module IDs</description></item>
        /// <item><description>CC and EE are independent, unlike in SunVox</description></item>
        /// <item><description>CC is as displayed in SunVox, incremented by one compared to library-side module IDs</description></item>
        /// </list>
        /// </para>
        /// Note: spaces were replaced with underscores for better visibility in the examples.
        /// </remarks>
        public override readonly string ToString()
        {
            return $"{(Note)NN}" +
                   $"{(VV != 0 ? $"{VV - 1:X2}" : "  ")}" +
                   $"{(MM != 0 ? $"{MM - 1:X4}" : "    ")}" +
                   $"{(CC != 0 ? $"{CC:X2}" : "  ")}" +
                   $"{(EE != 0 ? $"{EE:X2}" : "  ")}" +
                   $"{(XXYY != 0 ? $"{XXYY:X4}" : "    ")}";
        }

        public static bool operator ==(PatternEvent a, PatternEvent b)
        {
            return a.Data == b.Data;
        }

        public static bool operator !=(PatternEvent a, PatternEvent b)
        {
            return a.Data != b.Data;
        }

        /// <inheritdoc/>
        public override readonly bool Equals(object? obj)
        {
            return obj is PatternEvent e && this == e;
        }

        /// <inheritdoc/>
        public readonly bool Equals(PatternEvent other)
        {
            return this == other;
        }

        /// <inheritdoc/>
        public override readonly int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }
}
