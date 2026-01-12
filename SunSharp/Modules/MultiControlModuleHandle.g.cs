/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// With this module you can change the values of multiple controllers (in different modules) at once. Maximum number of connected controllers - 16.
    /// </summary>
    public partial interface IMultiControlModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 0 'Value'
        /// </summary>
        int GetValue(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 0 'Value'
        /// </summary>
        void SetValue(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 1 'Gain'
        /// </summary>
        int GetGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 1 'Gain'
        /// </summary>
        void SetGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 2 'Quantization'
        /// </summary>
        int GetQuantization(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 2 'Quantization'
        /// </summary>
        void SetQuantization(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -16384-16384, real: 0-32768
        /// Original name: 3 'OUT offset'
        /// </summary>
        int GetOutOffset(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -16384-16384, real: 0-32768
        /// Original name: 3 'OUT offset'
        /// </summary>
        void SetOutOffset(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1000
        /// Original name: 4 'Response'
        /// </summary>
        int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1000
        /// Original name: 4 'Response'
        /// </summary>
        void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32768
        /// Original name: 5 'Sample rate'
        /// </summary>
        int GetSampleRate(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32768
        /// Original name: 5 'Sample rate'
        /// </summary>
        void SetSampleRate(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Modifies values.
        /// <br>
        /// <br> Write to curve 0 of MultiControl.
        /// <br> The curve contains 257 values in range of 0 to 1.
        /// </summary>
        int WriteCurveValueMap(float[] buffer);

        /// <summary>
        /// Modifies values.
        /// <br>
        /// <br> Read from curve 0 of MultiControl.
        /// <br> The curve contains 257 values in range of 0 to 1.
        /// </summary>
        int ReadCurveValueMap(float[] buffer);
    }

    /// <inheritdoc cref="IMultiControlModuleHandle"/>
    public readonly partial struct MultiControlModuleHandle : IMultiControlModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public MultiControlModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(MultiControlModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.MultiControl;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.MultiControl;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IMultiControlModuleHandle.GetValue" />
        public int GetValue(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.SetValue" />
        public void SetValue(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.GetGain" />
        public int GetGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.SetGain" />
        public void SetGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.GetQuantization" />
        public int GetQuantization(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.SetQuantization" />
        public void SetQuantization(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.GetOutOffset" />
        public int GetOutOffset(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.SetOutOffset" />
        public void SetOutOffset(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.GetResponse" />
        public int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.SetResponse" />
        public void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.GetSampleRate" />
        public int GetSampleRate(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.SetSampleRate" />
        public void SetSampleRate(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IMultiControlModuleHandle.ReadCurveValueMap"
        public int ReadCurveValueMap(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IMultiControlModuleHandle.WriteCurveValueMap"
        public int WriteCurveValueMap(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);
    }
}
#endif
