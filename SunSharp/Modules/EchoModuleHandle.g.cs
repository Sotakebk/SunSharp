/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Stereo echo. Maximum delay length: 4 seconds.
    /// </summary>
    public partial interface IEchoModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-256
        /// Original name: 0 'Dry'
        /// </summary>
        int GetDry(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 0 'Dry'
        /// </summary>
        void SetDry(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Wet'
        /// </summary>
        int GetWet(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Wet'
        /// </summary>
        void SetWet(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Feedback'
        /// </summary>
        int GetFeedback(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Feedback'
        /// </summary>
        void SetFeedback(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 3 'Delay'
        /// </summary>
        int GetDelay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 3 'Delay'
        /// </summary>
        void SetDelay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 4 'Right channel offset'
        /// </summary>
        Toggle GetRightChannelOffset();

        /// <summary>
        /// Original name: 4 'Right channel offset'
        /// </summary>
        void SetRightChannelOffset(Toggle value);

        /// <summary>
        /// Original name: 5 'Delay unit'
        /// </summary>
        EchoDelayUnit GetDelayUnit();

        /// <summary>
        /// Original name: 5 'Delay unit'
        /// </summary>
        void SetDelayUnit(EchoDelayUnit value);

        /// <summary>
        /// Expressed as Delay/32768.
        /// <br>
        /// Value range: 0-32768
        /// Original name: 6 'Right channel offset'
        /// </summary>
        int GetRightChannelOffsetDelay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Expressed as Delay/32768.
        /// <br>
        /// Value range: 0-32768
        /// Original name: 6 'Right channel offset'
        /// </summary>
        void SetRightChannelOffsetDelay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 7 'Filter'
        /// </summary>
        EchoFilter GetFilter();

        /// <summary>
        /// Original name: 7 'Filter'
        /// </summary>
        void SetFilter(EchoFilter value);

        /// <summary>
        /// Value range: 0-22000
        /// Original name: 8 'F.freq'
        /// </summary>
        int GetFFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-22000
        /// Original name: 8 'F.freq'
        /// </summary>
        void SetFFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);
    }

    /// <inheritdoc cref="IEchoModuleHandle"/>
    public readonly partial struct EchoModuleHandle : IEchoModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public EchoModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(EchoModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Echo;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Echo;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IEchoModuleHandle.GetDry" />
        public int GetDry(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.SetDry" />
        public void SetDry(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.GetWet" />
        public int GetWet(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.SetWet" />
        public void SetWet(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.GetFeedback" />
        public int GetFeedback(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.SetFeedback" />
        public void SetFeedback(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.GetDelay" />
        public int GetDelay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.SetDelay" />
        public void SetDelay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.GetRightChannelOffset" />
        public Toggle GetRightChannelOffset() => (Toggle)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IEchoModuleHandle.SetRightChannelOffset" />
        public void SetRightChannelOffset(Toggle value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IEchoModuleHandle.GetDelayUnit" />
        public EchoDelayUnit GetDelayUnit() => (EchoDelayUnit)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IEchoModuleHandle.SetDelayUnit" />
        public void SetDelayUnit(EchoDelayUnit value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IEchoModuleHandle.GetRightChannelOffsetDelay" />
        public int GetRightChannelOffsetDelay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.SetRightChannelOffsetDelay" />
        public void SetRightChannelOffsetDelay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.GetFilter" />
        public EchoFilter GetFilter() => (EchoFilter)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IEchoModuleHandle.SetFilter" />
        public void SetFilter(EchoFilter value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IEchoModuleHandle.GetFFreq" />
        public int GetFFreq(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IEchoModuleHandle.SetFFreq" />
        public void SetFFreq(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);
    }
}
#endif
