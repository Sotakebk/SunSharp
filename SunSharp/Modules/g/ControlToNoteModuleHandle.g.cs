/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// Ctl2Note converts the value of the 'Pitch' controller to a note (Note ON/OFF commands at the output).
    /// </summary>
    public partial interface IControlToNoteModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 0 'Pitch'
        /// </summary>
        int GetPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 0 'Pitch'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakePitchEvent(int value);

        /// <summary>
        /// Original name: 1 'First note'
        /// </summary>
        int GetFirstNote(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 'First note'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFirstNote(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeFirstNoteEvent(int value);

        /// <summary>
        /// Original name: 2 'Range (number of semitones)'
        /// </summary>
        int GetRangeNumberOfSemitones(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 'Range (number of semitones)'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRangeNumberOfSemitones(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeRangeNumberOfSemitonesEvent(int value);

        /// <summary>
        /// Original name: 3 'Transpose'
        /// </summary>
        int GetTranspose(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 'Transpose'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetTranspose(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeTransposeEvent(int value);

        /// <summary>
        /// Value range: displayed: -256 to 256, real: 0 to 512
        /// Original name: 4 'Finetune'
        /// </summary>
        int GetFineTune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -256 to 256, real: 0 to 512
        /// Original name: 4 'Finetune'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFineTune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-256 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeFineTuneEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 5 'Velocity'
        /// </summary>
        int GetVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 5 'Velocity'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeVelocityEvent(int value);

        /// <summary>
        /// Original name: 6 'State'
        /// </summary>
        Toggle GetState();

        /// <summary>
        /// Original name: 6 'State'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetState(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeStateEvent(Toggle value);

        /// <summary>
        /// Original name: 7 'NoteON'
        /// </summary>
        ControlToNoteOnBehaviour GetNoteon();

        /// <summary>
        /// Original name: 7 'NoteON'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetNoteon(ControlToNoteOnBehaviour value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeNoteonEvent(ControlToNoteOnBehaviour value);

        /// <summary>
        /// Original name: 8 'NoteOFF'
        /// </summary>
        ControlToNoteOffBehaviour GetNoteoff();

        /// <summary>
        /// Original name: 8 'NoteOFF'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetNoteoff(ControlToNoteOffBehaviour value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeNoteoffEvent(ControlToNoteOffBehaviour value);

        /// <summary>
        /// Original name: 9 'Record notes'
        /// </summary>
        Toggle GetRecordNotes();

        /// <summary>
        /// Original name: 9 'Record notes'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRecordNotes(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeRecordNotesEvent(Toggle value);
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

        #region IGenericSynthModuleHandle implementation

        public int Id => ModuleHandle.Id;

        public ISlot Slot => ModuleHandle.Slot;

        /// <inheritdoc/>
        public ModuleFlags GetFlags() => ModuleHandle.GetFlags();

        /// <inheritdoc/>
        public SynthModuleType? GetModuleType() => ModuleHandle.GetModuleType();

        /// <inheritdoc/>
        public bool GetExists() => ModuleHandle.GetExists();

        /// <inheritdoc/>
        public FineTunePair GetFineTune() => ModuleHandle.GetFineTune();

        /// <inheritdoc/>
        public void SetFineTune(FineTunePair fineTune) => ModuleHandle.SetFineTune(fineTune);

        /// <inheritdoc/>
        public int ReadScope(AudioChannel channel, short[] buffer) => ModuleHandle.ReadScope(channel, buffer);

        /// <inheritdoc/>
        public string? GetName() => ModuleHandle.GetName();

        /// <inheritdoc/>
        public void SetName(string name) => ModuleHandle.SetName(name);

        /// <inheritdoc/>
        public (int, int) GetPosition() => ModuleHandle.GetPosition();

        /// <inheritdoc/>
        public void SetPosition(int x, int y) => ModuleHandle.SetPosition(x, y);

        /// <inheritdoc/>
        public (byte, byte, byte) GetColor() => ModuleHandle.GetColor();

        /// <inheritdoc/>
        public void SetColor(byte r, byte g, byte b) => ModuleHandle.SetColor(r, g, b);

        /// <inheritdoc/>
        public int[] GetInputs() => ModuleHandle.GetInputs();

        /// <inheritdoc/>
        ISynthModuleHandle[] IGenericSynthModuleHandle.GetInputModules() => (ModuleHandle as IGenericSynthModuleHandle).GetInputModules();

        /// <inheritdoc/>
        public int[] GetOutputs() => ModuleHandle.GetOutputs();

        /// <inheritdoc/>
        ISynthModuleHandle[] IGenericSynthModuleHandle.GetOutputModules() => (ModuleHandle as IGenericSynthModuleHandle).GetOutputModules();

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectInput(int targetModuleId) => ModuleHandle.ConnectInput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectInput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).ConnectInput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectOutput(int targetModuleId) => ModuleHandle.ConnectOutput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectOutput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).ConnectOutput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectInput(int targetModuleId) => ModuleHandle.DisconnectInput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectInput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).DisconnectInput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectOutput(int targetModuleId) => ModuleHandle.DisconnectOutput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectOutput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).DisconnectOutput(targetModule);

        /// <inheritdoc/>
        public PatternEvent MakeSetControllerValueEvent(byte controllerId, ushort value) => ModuleHandle.MakeSetControllerValueEvent(controllerId, value);

        /// <inheritdoc/>
        public PatternEvent MakeNoteEvent(Note note, byte? velocity = default) => ModuleHandle.MakeNoteEvent(note, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeSetPitchEvent(ushort pitch, byte? velocity = default) => ModuleHandle.MakeSetPitchEvent(pitch, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeSetFrequencyEvent(double frequency, byte? velocity = default) => ModuleHandle.MakeSetFrequencyEvent(frequency, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeEvent(Note note = default, byte? velocity = default, byte? controller = default, Effect effect = Effect.None, ushort value = 0) => ModuleHandle.MakeEvent(note, velocity, controller, effect, value);

        /// <inheritdoc cref="SynthModuleHandle.GetInputModules"/>
        public SynthModuleHandle[] GetInputModules() => ModuleHandle.GetInputModules();

        /// <inheritdoc cref="SynthModuleHandle.GetOutputModules"/>
        public SynthModuleHandle[] GetOutputModules() => ModuleHandle.GetOutputModules();

        /// <inheritdoc cref="SynthModuleHandle.ConnectInput"/>
        public void ConnectInput(SynthModuleHandle targetModule) => ModuleHandle.ConnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.ConnectOutput"/>
        public void ConnectOutput(SynthModuleHandle targetModule) => ModuleHandle.ConnectOutput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectInput"/>
        public void DisconnectInput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectOutput"/>
        public void DisconnectOutput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectOutput(targetModule);

        #endregion

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetPitch" />
        public int GetPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetPitch" />
        public void SetPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakePitchEvent" />
        public PatternEvent MakePitchEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetFirstNote" />
        public int GetFirstNote(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetFirstNote" />
        public void SetFirstNote(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeFirstNoteEvent" />
        public PatternEvent MakeFirstNoteEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetRangeNumberOfSemitones" />
        public int GetRangeNumberOfSemitones(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetRangeNumberOfSemitones" />
        public void SetRangeNumberOfSemitones(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeRangeNumberOfSemitonesEvent" />
        public PatternEvent MakeRangeNumberOfSemitonesEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetTranspose" />
        public int GetTranspose(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetTranspose" />
        public void SetTranspose(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeTransposeEvent" />
        public PatternEvent MakeTransposeEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetFineTune" />
        public int GetFineTune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetFineTune" />
        public void SetFineTune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeFineTuneEvent" />
        public PatternEvent MakeFineTuneEvent(int value)
        {
            value -= -256;
            value = value * 0x8000 / (512);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetVelocity" />
        public int GetVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetVelocity" />
        public void SetVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeVelocityEvent" />
        public PatternEvent MakeVelocityEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetState" />
        public Toggle GetState() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetState" />
        public void SetState(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeStateEvent" />
        public PatternEvent MakeStateEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetNoteon" />
        public ControlToNoteOnBehaviour GetNoteon() => (ControlToNoteOnBehaviour)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetNoteon" />
        public void SetNoteon(ControlToNoteOnBehaviour value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeNoteonEvent" />
        public PatternEvent MakeNoteonEvent(ControlToNoteOnBehaviour value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetNoteoff" />
        public ControlToNoteOffBehaviour GetNoteoff() => (ControlToNoteOffBehaviour)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetNoteoff" />
        public void SetNoteoff(ControlToNoteOffBehaviour value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeNoteoffEvent" />
        public PatternEvent MakeNoteoffEvent(ControlToNoteOffBehaviour value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IControlToNoteModuleHandle.GetRecordNotes" />
        public Toggle GetRecordNotes() => (Toggle)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.SetRecordNotes" />
        public void SetRecordNotes(Toggle value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IControlToNoteModuleHandle.MakeRecordNotesEvent" />
        public PatternEvent MakeRecordNotesEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 9, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }
    }
}
#endif
