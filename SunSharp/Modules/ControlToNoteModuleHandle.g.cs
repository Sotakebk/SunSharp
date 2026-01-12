/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Ctl2Note converts the value of the 'Pitch' controller to a note (Note ON/OFF commands at the output).
    /// </summary>
    public partial interface IControlToNoteModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 0 'Pitch'
        /// </summary>
        int GetPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 0 'Pitch'
        /// </summary>
        void SetPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-120
        /// Original name: 1 'First note'
        /// </summary>
        int GetFirstNote(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-120
        /// Original name: 1 'First note'
        /// </summary>
        void SetFirstNote(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-120
        /// Original name: 2 'Range (number of semitones)'
        /// </summary>
        int GetRangeNumberOfSemitones(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-120
        /// Original name: 2 'Range (number of semitones)'
        /// </summary>
        void SetRangeNumberOfSemitones(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 3 'Transpose'
        /// </summary>
        int GetTranspose(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 3 'Transpose'
        /// </summary>
        void SetTranspose(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -256-256, real: 0-512
        /// Original name: 4 'Finetune'
        /// </summary>
        int GetFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -256-256, real: 0-512
        /// Original name: 4 'Finetune'
        /// </summary>
        void SetFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 5 'Velocity'
        /// </summary>
        int GetVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 5 'Velocity'
        /// </summary>
        void SetVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 6 'State'
        /// </summary>
        Toggle GetState();

        /// <summary>
        /// Original name: 6 'State'
        /// </summary>
        void SetState(Toggle value);

        /// <summary>
        /// Original name: 7 'NoteON'
        /// </summary>
        ControlToNoteOnBehaviour GetNoteon();

        /// <summary>
        /// Original name: 7 'NoteON'
        /// </summary>
        void SetNoteon(ControlToNoteOnBehaviour value);

        /// <summary>
        /// Original name: 8 'NoteOFF'
        /// </summary>
        ControlToNoteOffBehaviour GetNoteoff();

        /// <summary>
        /// Original name: 8 'NoteOFF'
        /// </summary>
        void SetNoteoff(ControlToNoteOffBehaviour value);

        /// <summary>
        /// Original name: 9 'Record notes'
        /// </summary>
        Toggle GetRecordNotes();

        /// <summary>
        /// Original name: 9 'Record notes'
        /// </summary>
        void SetRecordNotes(Toggle value);
    }

    /// <inheritdoc cref="IControlToNoteModuleHandle"/>
    public readonly partial struct ControlToNoteModuleHandle : IControlToNoteModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public ControlToNoteModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(ControlToNoteModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.ControlToNote;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.ControlToNote;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetPitch" />
        public int GetPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetPitch" />
        public void SetPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetFirstNote" />
        public int GetFirstNote(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetFirstNote" />
        public void SetFirstNote(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetRangeNumberOfSemitones" />
        public int GetRangeNumberOfSemitones(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetRangeNumberOfSemitones" />
        public void SetRangeNumberOfSemitones(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetTranspose" />
        public int GetTranspose(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetTranspose" />
        public void SetTranspose(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetFinetune" />
        public int GetFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetFinetune" />
        public void SetFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetVelocity" />
        public int GetVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetVelocity" />
        public void SetVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetState" />
        public Toggle GetState() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetState" />
        public void SetState(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetNoteon" />
        public ControlToNoteOnBehaviour GetNoteon() => (ControlToNoteOnBehaviour)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetNoteon" />
        public void SetNoteon(ControlToNoteOnBehaviour value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetNoteoff" />
        public ControlToNoteOffBehaviour GetNoteoff() => (ControlToNoteOffBehaviour)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetNoteoff" />
        public void SetNoteoff(ControlToNoteOffBehaviour value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetRecordNotes" />
        public Toggle GetRecordNotes() => (Toggle)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetRecordNotes" />
        public void SetRecordNotes(Toggle value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
