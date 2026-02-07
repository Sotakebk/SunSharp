/*
 * Do not modify this file manually.
*/

#nullable enable

#if !SUNSHARP_GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// Drum synthesizer with variety of predefined sounds. The sound quality of this module is better at a sample rate of 44100Hz.
    /// </summary>
    public partial interface IDrumSynthModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 0 'Volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 512) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeVolumeEvent(int value);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 1 'Panning'
        /// </summary>
        int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 1 'Panning'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-128 to 128) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakePanningEvent(int value);

        /// <summary>
        /// Original name: 2 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 'Polyphony'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakePolyphonyEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 3 'Bass volume'
        /// </summary>
        int GetBassVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 3 'Bass volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetBassVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 512) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeBassVolumeEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 4 'Bass power'
        /// </summary>
        int GetBassPower(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 4 'Bass power'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetBassPower(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeBassPowerEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 5 'Bass tone'
        /// </summary>
        int GetBassTone(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 5 'Bass tone'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetBassTone(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeBassToneEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 6 'Bass length'
        /// </summary>
        int GetBassLength(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 6 'Bass length'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetBassLength(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeBassLengthEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 7 'Hihat volume'
        /// </summary>
        int GetHihatVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 7 'Hihat volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetHihatVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 512) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeHihatVolumeEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 8 'Hihat length'
        /// </summary>
        int GetHihatLength(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 8 'Hihat length'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetHihatLength(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeHihatLengthEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 9 'Snare volume'
        /// </summary>
        int GetSnareVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 9 'Snare volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSnareVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 512) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSnareVolumeEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 10 'Snare tone'
        /// </summary>
        int GetSnareTone(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 10 'Snare tone'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSnareTone(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSnareToneEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 11 'Snare length'
        /// </summary>
        int GetSnareLength(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 256, real: 0 to 256
        /// Original name: 11 'Snare length'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSnareLength(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 256) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSnareLengthEvent(int value);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 12 'Bass panning'
        /// </summary>
        int GetBassPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 12 'Bass panning'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetBassPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-128 to 128) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeBassPanningEvent(int value);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 13 'Hihat panning'
        /// </summary>
        int GetHihatPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 13 'Hihat panning'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetHihatPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-128 to 128) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeHihatPanningEvent(int value);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 14 'Snare panning'
        /// </summary>
        int GetSnarePanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128 to 128, real: 0 to 256
        /// Original name: 14 'Snare panning'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent(int, PatternEvent)"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSnarePanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-128 to 128) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeSnarePanningEvent(int value);
    }

    /// <inheritdoc cref="IDrumSynthModuleHandle"/>
    public readonly partial struct DrumSynthModuleHandle : IDrumSynthModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public DrumSynthModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(DrumSynthModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.DrumSynth;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.DrumSynth;
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

        /// <inheritdoc cref="SynthModuleHandle.GetInputModules()"/>
        public SynthModuleHandle[] GetInputModules() => ModuleHandle.GetInputModules();

        /// <inheritdoc cref="SynthModuleHandle.GetOutputModules()"/>
        public SynthModuleHandle[] GetOutputModules() => ModuleHandle.GetOutputModules();

        /// <inheritdoc cref="SynthModuleHandle.ConnectInput(SynthModuleHandle)"/>
        public void ConnectInput(SynthModuleHandle targetModule) => ModuleHandle.ConnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.ConnectOutput(SynthModuleHandle)"/>
        public void ConnectOutput(SynthModuleHandle targetModule) => ModuleHandle.ConnectOutput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectInput(SynthModuleHandle)"/>
        public void DisconnectInput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectOutput(SynthModuleHandle)"/>
        public void DisconnectOutput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectOutput(targetModule);

        #endregion

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetVolume(ValueScalingMode)" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetVolume(int, ValueScalingMode)" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeVolumeEvent" />
        public PatternEvent MakeVolumeEvent(int value)
        {
            value = value * 0x8000 / (512);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetPanning(ValueScalingMode)" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetPanning(int, ValueScalingMode)" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakePanningEvent" />
        public PatternEvent MakePanningEvent(int value)
        {
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetPolyphony(ValueScalingMode)" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetPolyphony(int, ValueScalingMode)" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakePolyphonyEvent" />
        public PatternEvent MakePolyphonyEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetBassVolume(ValueScalingMode)" />
        public int GetBassVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetBassVolume(int, ValueScalingMode)" />
        public void SetBassVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeBassVolumeEvent" />
        public PatternEvent MakeBassVolumeEvent(int value)
        {
            value = value * 0x8000 / (512);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetBassPower(ValueScalingMode)" />
        public int GetBassPower(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetBassPower(int, ValueScalingMode)" />
        public void SetBassPower(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeBassPowerEvent" />
        public PatternEvent MakeBassPowerEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetBassTone(ValueScalingMode)" />
        public int GetBassTone(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetBassTone(int, ValueScalingMode)" />
        public void SetBassTone(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeBassToneEvent" />
        public PatternEvent MakeBassToneEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetBassLength(ValueScalingMode)" />
        public int GetBassLength(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetBassLength(int, ValueScalingMode)" />
        public void SetBassLength(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeBassLengthEvent" />
        public PatternEvent MakeBassLengthEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetHihatVolume(ValueScalingMode)" />
        public int GetHihatVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetHihatVolume(int, ValueScalingMode)" />
        public void SetHihatVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeHihatVolumeEvent" />
        public PatternEvent MakeHihatVolumeEvent(int value)
        {
            value = value * 0x8000 / (512);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetHihatLength(ValueScalingMode)" />
        public int GetHihatLength(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetHihatLength(int, ValueScalingMode)" />
        public void SetHihatLength(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeHihatLengthEvent" />
        public PatternEvent MakeHihatLengthEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetSnareVolume(ValueScalingMode)" />
        public int GetSnareVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetSnareVolume(int, ValueScalingMode)" />
        public void SetSnareVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeSnareVolumeEvent" />
        public PatternEvent MakeSnareVolumeEvent(int value)
        {
            value = value * 0x8000 / (512);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 9, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetSnareTone(ValueScalingMode)" />
        public int GetSnareTone(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetSnareTone(int, ValueScalingMode)" />
        public void SetSnareTone(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeSnareToneEvent" />
        public PatternEvent MakeSnareToneEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 10, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetSnareLength(ValueScalingMode)" />
        public int GetSnareLength(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(11, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetSnareLength(int, ValueScalingMode)" />
        public void SetSnareLength(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(11, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeSnareLengthEvent" />
        public PatternEvent MakeSnareLengthEvent(int value)
        {
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 11, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetBassPanning(ValueScalingMode)" />
        public int GetBassPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(12, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetBassPanning(int, ValueScalingMode)" />
        public void SetBassPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(12, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeBassPanningEvent" />
        public PatternEvent MakeBassPanningEvent(int value)
        {
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 12, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetHihatPanning(ValueScalingMode)" />
        public int GetHihatPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(13, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetHihatPanning(int, ValueScalingMode)" />
        public void SetHihatPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(13, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeHihatPanningEvent" />
        public PatternEvent MakeHihatPanningEvent(int value)
        {
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 13, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="IDrumSynthModuleHandle.GetSnarePanning(ValueScalingMode)" />
        public int GetSnarePanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(14, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.SetSnarePanning(int, ValueScalingMode)" />
        public void SetSnarePanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(14, value, valueScalingMode);

        /// <inheritdoc cref="IDrumSynthModuleHandle.MakeSnarePanningEvent" />
        public PatternEvent MakeSnarePanningEvent(int value)
        {
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 14, (ushort)Math.Clamp(value, 0, 0x8000));
        }
    }
}
#endif
