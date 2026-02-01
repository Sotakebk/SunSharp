/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// Glide is similar to the MultiSynth (which sends the input events to the connected output modules), but it also adds the commands of smooth transition between the notes.
    /// </summary>
    public partial interface IGlideModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: 0 to 1000, real: 0 to 1000
        /// Original name: 0 'Response'
        /// </summary>
        int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 1000, real: 0 to 1000
        /// Original name: 0 'Response'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 1000) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeResponseEvent(int value);

        /// <summary>
        /// Value range: displayed: 1 to 32768, real: 1 to 32768
        /// Original name: 1 'Sample rate'
        /// </summary>
        int GetSampleRate(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 1 to 32768, real: 1 to 32768
        /// Original name: 1 'Sample rate'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSampleRate(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (1 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSampleRateEvent(int value);

        /// <summary>
        /// Original name: 2 'Reset on 1st note'
        /// </summary>
        Toggle GetResetOnStNote1();

        /// <summary>
        /// Original name: 2 'Reset on 1st note'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetResetOnStNote1(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeResetOnStNote1Event(Toggle value);

        /// <summary>
        /// Original name: 3 'Polyphony'
        /// </summary>
        Toggle GetPolyphony();

        /// <summary>
        /// Original name: 3 'Polyphony'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPolyphony(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakePolyphonyEvent(Toggle value);

        /// <summary>
        /// Value range: displayed: -600 to 600, real: 0 to 1200
        /// Original name: 4 'Pitch'
        /// </summary>
        int GetPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -600 to 600, real: 0 to 1200
        /// Original name: 4 'Pitch'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-600 to 600) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakePitchEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 200, real: 0 to 200
        /// Original name: 5 'Pitch scale'
        /// </summary>
        int GetPitchScale(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 200, real: 0 to 200
        /// Original name: 5 'Pitch scale'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPitchScale(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 200) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakePitchScaleEvent(int value);

        /// <summary>
        /// Original name: 6 'Reset'
        /// </summary>
        Toggle GetReset();

        /// <summary>
        /// Original name: 6 'Reset'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetReset(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeResetEvent(Toggle value);

        /// <summary>
        /// Original name: 7 'Octave'
        /// </summary>
        int GetOctave(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 7 'Octave'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetOctave(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeOctaveEvent(int value);

        /// <summary>
        /// Original name: 8 'Freq multiply'
        /// </summary>
        int GetFreqMultiply(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 8 'Freq multiply'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFreqMultiply(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeFreqMultiplyEvent(int value);

        /// <summary>
        /// Original name: 9 'Freq divide'
        /// </summary>
        int GetFreqDivide(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 9 'Freq divide'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetFreqDivide(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeFreqDivideEvent(int value);
    }

    /// <inheritdoc cref="IGlideModuleHandle"/>
    public readonly partial struct GlideModuleHandle : IGlideModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public GlideModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(GlideModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Glide;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Glide;
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

        /// <inheritdoc cref="IGlideModuleHandle.GetResponse" />
        public int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetResponse" />
        public void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.MakeResponseEvent" />
        public PatternEvent MakeResponseEvent(int value)
        {
            value = value * 0x8000 / (1000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetSampleRate" />
        public int GetSampleRate(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetSampleRate" />
        public void SetSampleRate(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.MakeSampleRateEvent" />
        public PatternEvent MakeSampleRateEvent(int value)
        {
            value -= 1;
            value = value * 0x8000 / (32767);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetResetOnStNote1" />
        public Toggle GetResetOnStNote1() => (Toggle)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.SetResetOnStNote1" />
        public void SetResetOnStNote1(Toggle value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.MakeResetOnStNote1Event" />
        public PatternEvent MakeResetOnStNote1Event(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetPolyphony" />
        public Toggle GetPolyphony() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.SetPolyphony" />
        public void SetPolyphony(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.MakePolyphonyEvent" />
        public PatternEvent MakePolyphonyEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetPitch" />
        public int GetPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetPitch" />
        public void SetPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.MakePitchEvent" />
        public PatternEvent MakePitchEvent(int value)
        {
            value -= -600;
            value = value * 0x8000 / (1200);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetPitchScale" />
        public int GetPitchScale(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetPitchScale" />
        public void SetPitchScale(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.MakePitchScaleEvent" />
        public PatternEvent MakePitchScaleEvent(int value)
        {
            value = value * 0x8000 / (200);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetReset" />
        public Toggle GetReset() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.SetReset" />
        public void SetReset(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.MakeResetEvent" />
        public PatternEvent MakeResetEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetOctave" />
        public int GetOctave(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetOctave" />
        public void SetOctave(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.MakeOctaveEvent" />
        public PatternEvent MakeOctaveEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetFreqMultiply" />
        public int GetFreqMultiply(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetFreqMultiply" />
        public void SetFreqMultiply(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.MakeFreqMultiplyEvent" />
        public PatternEvent MakeFreqMultiplyEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IGlideModuleHandle.GetFreqDivide" />
        public int GetFreqDivide(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetFreqDivide" />
        public void SetFreqDivide(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.MakeFreqDivideEvent" />
        public PatternEvent MakeFreqDivideEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 9, (ushort)Math.Clamp(value, 0, 0x8000));
        }
    }
}
#endif
