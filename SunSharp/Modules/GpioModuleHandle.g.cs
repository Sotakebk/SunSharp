/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// With this module you can use the General-Purpose Input/Output (GPIO) pins of the device board. For example, you can send some signals to the LEDs, or receive the ON/OFF (1/0) messages from the buttons.
    /// </summary>
    public partial interface IGpioModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Original name: 0 'Out'
        /// </summary>
        Toggle GetOut();

        /// <summary>
        /// Original name: 0 'Out'
        /// </summary>
        void SetOut(Toggle value);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Out pin'
        /// </summary>
        int GetOutPin(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Out pin'
        /// </summary>
        void SetOutPin(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-100
        /// Original name: 2 'Out threshold'
        /// </summary>
        int GetOutThreshold(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-100
        /// Original name: 2 'Out threshold'
        /// </summary>
        void SetOutThreshold(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 'In'
        /// </summary>
        Toggle GetIn();

        /// <summary>
        /// Original name: 3 'In'
        /// </summary>
        void SetIn(Toggle value);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'In pin'
        /// </summary>
        int GetInPin(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 4 'In pin'
        /// </summary>
        void SetInPin(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-128
        /// Original name: 5 'In note'
        /// </summary>
        int GetInNote(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-128
        /// Original name: 5 'In note'
        /// </summary>
        void SetInNote(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-100
        /// Original name: 6 'In amplitude'
        /// </summary>
        int GetInAmplitude(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-100
        /// Original name: 6 'In amplitude'
        /// </summary>
        void SetInAmplitude(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);
    }

    /// <inheritdoc cref="IGpioModuleHandle"/>
    public readonly partial struct GpioModuleHandle : IGpioModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public GpioModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(GpioModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Gpio;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Gpio;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IGpioModuleHandle.GetOut" />
        public Toggle GetOut() => (Toggle)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGpioModuleHandle.SetOut" />
        public void SetOut(Toggle value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGpioModuleHandle.GetOutPin" />
        public int GetOutPin(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.SetOutPin" />
        public void SetOutPin(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.GetOutThreshold" />
        public int GetOutThreshold(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.SetOutThreshold" />
        public void SetOutThreshold(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.GetIn" />
        public Toggle GetIn() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGpioModuleHandle.SetIn" />
        public void SetIn(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGpioModuleHandle.GetInPin" />
        public int GetInPin(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.SetInPin" />
        public void SetInPin(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.GetInNote" />
        public int GetInNote(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.SetInNote" />
        public void SetInNote(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.GetInAmplitude" />
        public int GetInAmplitude(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IGpioModuleHandle.SetInAmplitude" />
        public void SetInAmplitude(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);
    }
}
#endif
