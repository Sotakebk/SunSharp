/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION

using System;

namespace SunSharp.Modules
{
    /// <summary>
    /// Sampler can play and record audio files. Supported file formats: WAV (PCM, uncompressed), AIFF (PCM, uncompressed), XI, OGG (Vorbis), MP3, FLAC, JPEG, RAW.
    /// </summary>
    public partial interface ISamplerModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 512, real: 0 to 512
        /// Original name: 0 'Volume'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
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
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (-128 to 128) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakePanningEvent(int value);

        /// <summary>
        /// Original name: 2 'Sample interpolation'
        /// </summary>
        SamplerInterpolation GetSampleInterpolation();

        /// <summary>
        /// Original name: 2 'Sample interpolation'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetSampleInterpolation(SamplerInterpolation value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeSampleInterpolationEvent(SamplerInterpolation value);

        /// <summary>
        /// Original name: 3 'Envelope interpolation'
        /// </summary>
        SamplerEnvelopeInterpolation GetEnvelopeInterpolation();

        /// <summary>
        /// Original name: 3 'Envelope interpolation'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetEnvelopeInterpolation(SamplerEnvelopeInterpolation value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeEnvelopeInterpolationEvent(SamplerEnvelopeInterpolation value);

        /// <summary>
        /// Original name: 4 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 'Polyphony'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakePolyphonyEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name: 5 'Rec threshold'
        /// </summary>
        int GetRecThreshold(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 10000, real: 0 to 10000
        /// Original name: 5 'Rec threshold'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRecThreshold(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 10000) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeRecThresholdEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 2048, real: 0 to 2048
        /// Original name: 6 'Tick length (norm=128)'
        /// </summary>
        int GetTickLengthNorm128(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 2048, real: 0 to 2048
        /// Original name: 6 'Tick length (norm=128)'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetTickLengthNorm128(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 2048) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeTickLengthNorm128Event(int value);

        /// <summary>
        /// Original name: 7 'Record'
        /// </summary>
        SamplerRecordState GetRecord();

        /// <summary>
        /// Original name: 7 'Record'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRecord(SamplerRecordState value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeRecordEvent(SamplerRecordState value);

        /// <summary>
        /// Original name: 8 'Reverse'
        /// </summary>
        Toggle GetReverse();

        /// <summary>
        /// Original name: 8 'Reverse'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetReverse(Toggle value);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is taken as is, only clamped to column value range.</para>
        /// </summary>
        PatternEvent MakeReverseEvent(Toggle value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 9 'Attack'
        /// </summary>
        int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 9 'Attack'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeAttackEvent(int value);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 10 'Release'
        /// </summary>
        int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: 0 to 32768, real: 0 to 32768
        /// Original name: 10 'Release'
        /// Note: equivalent <see cref="IVirtualPattern.SendEvent"/> will be used internally, which may introduce latency. It will also be affected by the event timestamp set.
        /// </summary>
        void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// <para>This is a helper method to automatically handle turning target controller values into column values.</para>
        /// <para>For this controller the input value is mapped from displayed range (0 to 32768) to column range (0 to 0x8000). Out of range values are clamped.</para>
        /// </summary>
        PatternEvent MakeReleaseEvent(int value);
    }

    /// <inheritdoc cref="ISamplerModuleHandle"/>
    public readonly partial struct SamplerModuleHandle : ISamplerModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public SamplerModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(SamplerModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Sampler;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Sampler;
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

        /// <inheritdoc cref="ISamplerModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeVolumeEvent" />
        public PatternEvent MakeVolumeEvent(int value)
        {
            value = value * 0x8000 / (512);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 0, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetPanning" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetPanning" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.MakePanningEvent" />
        public PatternEvent MakePanningEvent(int value)
        {
            value -= -128;
            value = value * 0x8000 / (256);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 1, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetSampleInterpolation" />
        public SamplerInterpolation GetSampleInterpolation() => (SamplerInterpolation)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.SetSampleInterpolation" />
        public void SetSampleInterpolation(SamplerInterpolation value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeSampleInterpolationEvent" />
        public PatternEvent MakeSampleInterpolationEvent(SamplerInterpolation value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 2, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetEnvelopeInterpolation" />
        public SamplerEnvelopeInterpolation GetEnvelopeInterpolation() => (SamplerEnvelopeInterpolation)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.SetEnvelopeInterpolation" />
        public void SetEnvelopeInterpolation(SamplerEnvelopeInterpolation value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeEnvelopeInterpolationEvent" />
        public PatternEvent MakeEnvelopeInterpolationEvent(SamplerEnvelopeInterpolation value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 3, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetPolyphony" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetPolyphony" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.MakePolyphonyEvent" />
        public PatternEvent MakePolyphonyEvent(int value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 4, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetRecThreshold" />
        public int GetRecThreshold(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetRecThreshold" />
        public void SetRecThreshold(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeRecThresholdEvent" />
        public PatternEvent MakeRecThresholdEvent(int value)
        {
            value = value * 0x8000 / (10000);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 5, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetTickLengthNorm128" />
        public int GetTickLengthNorm128(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetTickLengthNorm128" />
        public void SetTickLengthNorm128(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeTickLengthNorm128Event" />
        public PatternEvent MakeTickLengthNorm128Event(int value)
        {
            value = value * 0x8000 / (2048);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 6, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetRecord" />
        public SamplerRecordState GetRecord() => (SamplerRecordState)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.SetRecord" />
        public void SetRecord(SamplerRecordState value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeRecordEvent" />
        public PatternEvent MakeRecordEvent(SamplerRecordState value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 7, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetReverse" />
        public Toggle GetReverse() => (Toggle)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.SetReverse" />
        public void SetReverse(Toggle value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeReverseEvent" />
        public PatternEvent MakeReverseEvent(Toggle value)
        {
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 8, (ushort)Math.Clamp((int)value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetAttack" />
        public int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetAttack" />
        public void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeAttackEvent" />
        public PatternEvent MakeAttackEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 9, (ushort)Math.Clamp(value, 0, 0x8000));
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetRelease" />
        public int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetRelease" />
        public void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.MakeReleaseEvent" />
        public PatternEvent MakeReleaseEvent(int value)
        {
            value = value * 0x8000 / (32768);
            return PatternEvent.ControllerEvent(ModuleHandle.Id, 10, (ushort)Math.Clamp(value, 0, 0x8000));
        }
    }
}
#endif
