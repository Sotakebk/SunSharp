/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// This module repeats a fragment of the incoming sound a specified number of times.
    /// </summary>
    public partial interface ILoopModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-256
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 0 'Volume'
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Length'
        /// </summary>
        int GetLength(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Length'
        /// </summary>
        void SetLength(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 'Channels'
        /// </summary>
        ChannelsInverted GetChannels();

        /// <summary>
        /// Original name: 2 'Channels'
        /// </summary>
        void SetChannels(ChannelsInverted value);

        /// <summary>
        /// Value range: 0-128
        /// Original name: 3 'Repeat (128=endless)'
        /// </summary>
        int GetRepeatEndless128(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-128
        /// Original name: 3 'Repeat (128=endless)'
        /// </summary>
        void SetRepeatEndless128(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 'Mode'
        /// </summary>
        LoopMode GetMode();

        /// <summary>
        /// Original name: 4 'Mode'
        /// </summary>
        void SetMode(LoopMode value);

        /// <summary>
        /// Original name: 5 'Length unit'
        /// </summary>
        LoopTimeUnit GetLengthUnit();

        /// <summary>
        /// Original name: 5 'Length unit'
        /// </summary>
        void SetLengthUnit(LoopTimeUnit value);

        /// <summary>
        /// Max buffer size in seconds
        /// <br>
        /// Value range: 1-240
        /// Original name: 6 'Max buffer size'
        /// </summary>
        int GetMaxBufferSize(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Max buffer size in seconds
        /// <br>
        /// Value range: 1-240
        /// Original name: 6 'Max buffer size'
        /// </summary>
        void SetMaxBufferSize(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 7 'On NoteON'
        /// </summary>
        LoopOnNoteOn GetOnNoteon();

        /// <summary>
        /// Original name: 7 'On NoteON'
        /// </summary>
        void SetOnNoteon(LoopOnNoteOn value);
    }

    /// <inheritdoc cref="ILoopModuleHandle"/>
    public readonly partial struct LoopModuleHandle : ILoopModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public LoopModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(LoopModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Loop;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Loop;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="ILoopModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="ILoopModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="ILoopModuleHandle.GetLength" />
        public int GetLength(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="ILoopModuleHandle.SetLength" />
        public void SetLength(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="ILoopModuleHandle.GetChannels" />
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILoopModuleHandle.SetChannels" />
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILoopModuleHandle.GetRepeatEndless128" />
        public int GetRepeatEndless128(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="ILoopModuleHandle.SetRepeatEndless128" />
        public void SetRepeatEndless128(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="ILoopModuleHandle.GetMode" />
        public LoopMode GetMode() => (LoopMode)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILoopModuleHandle.SetMode" />
        public void SetMode(LoopMode value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILoopModuleHandle.GetLengthUnit" />
        public LoopTimeUnit GetLengthUnit() => (LoopTimeUnit)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILoopModuleHandle.SetLengthUnit" />
        public void SetLengthUnit(LoopTimeUnit value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILoopModuleHandle.GetMaxBufferSize" />
        public int GetMaxBufferSize(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="ILoopModuleHandle.SetMaxBufferSize" />
        public void SetMaxBufferSize(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="ILoopModuleHandle.GetOnNoteon" />
        public LoopOnNoteOn GetOnNoteon() => (LoopOnNoteOn)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ILoopModuleHandle.SetOnNoteon" />
        public void SetOnNoteon(LoopOnNoteOn value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
