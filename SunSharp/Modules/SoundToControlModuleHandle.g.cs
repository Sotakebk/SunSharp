/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// This module converts the audio signal to the numeric value of any selected controller.
    /// </summary>
    public partial interface ISoundToControlModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 1-32768
        /// Original name: 0 'Sample rate'
        /// </summary>
        int GetSampleRate(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32768
        /// Original name: 0 'Sample rate'
        /// </summary>
        void SetSampleRate(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 'Channels'
        /// </summary>
        ChannelsInverted GetChannels();

        /// <summary>
        /// Original name: 1 'Channels'
        /// </summary>
        void SetChannels(ChannelsInverted value);

        /// <summary>
        /// Original name: 2 'Absolute'
        /// </summary>
        Toggle GetAbsolute();

        /// <summary>
        /// Original name: 2 'Absolute'
        /// </summary>
        void SetAbsolute(Toggle value);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 3 'Gain'
        /// </summary>
        int GetGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 3 'Gain'
        /// </summary>
        void SetGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'Smooth'
        /// </summary>
        int GetSmooth(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'Smooth'
        /// </summary>
        void SetSmooth(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Mode'
        /// </summary>
        SoundToControlMode GetMode();

        /// <summary>
        /// Original name: 5 'Mode'
        /// </summary>
        void SetMode(SoundToControlMode value);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 6 'OUT min'
        /// </summary>
        int GetOutMin(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 6 'OUT min'
        /// </summary>
        void SetOutMin(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 7 'OUT max'
        /// </summary>
        int GetOutMax(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 7 'OUT max'
        /// </summary>
        void SetOutMax(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-255
        /// Original name: 8 'OUT controller'
        /// </summary>
        int GetOutController(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-255
        /// Original name: 8 'OUT controller'
        /// </summary>
        void SetOutController(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);
    }

    /// <inheritdoc cref="ISoundToControlModuleHandle"/>
    public readonly partial struct SoundToControlModuleHandle : ISoundToControlModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public SoundToControlModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(SoundToControlModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.SoundToControl;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.SoundToControl;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetSampleRate" />
        public int GetSampleRate(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetSampleRate" />
        public void SetSampleRate(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetChannels" />
        public ChannelsInverted GetChannels() => (ChannelsInverted)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetChannels" />
        public void SetChannels(ChannelsInverted value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetAbsolute" />
        public Toggle GetAbsolute() => (Toggle)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetAbsolute" />
        public void SetAbsolute(Toggle value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetGain" />
        public int GetGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetGain" />
        public void SetGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetSmooth" />
        public int GetSmooth(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetSmooth" />
        public void SetSmooth(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetMode" />
        public SoundToControlMode GetMode() => (SoundToControlMode)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetMode" />
        public void SetMode(SoundToControlMode value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetOutMin" />
        public int GetOutMin(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetOutMin" />
        public void SetOutMin(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetOutMax" />
        public int GetOutMax(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetOutMax" />
        public void SetOutMax(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.GetOutController" />
        public int GetOutController(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="ISoundToControlModuleHandle.SetOutController" />
        public void SetOutController(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);
    }
}
#endif
