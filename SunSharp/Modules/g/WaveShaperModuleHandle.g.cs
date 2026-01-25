/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// In simple terms, WaveShaper allows you to change the shape of the input signal. In math terms, WaveShaper is the expression y = f( x ); where y - output; x - input; f - function with graph which you can see in the WaveShaper interface.
    /// </summary>
    public partial interface IWaveShaperModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-512
        /// Original name: 0 'Input volume'
        /// </summary>
        int GetInputVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 0 'Input volume'
        /// </summary>
        void SetInputVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Mix'
        /// </summary>
        int GetMix(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'Mix'
        /// </summary>
        void SetMix(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 2 'Output volume'
        /// </summary>
        int GetOutputVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 2 'Output volume'
        /// </summary>
        void SetOutputVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 'Symmetric'
        /// </summary>
        Toggle GetSymmetric();

        /// <summary>
        /// Original name: 3 'Symmetric'
        /// </summary>
        void SetSymmetric(Toggle value);

        /// <summary>
        /// Original name: 4 'Mode'
        /// </summary>
        Quality GetMode();

        /// <summary>
        /// Original name: 4 'Mode'
        /// </summary>
        void SetMode(Quality value);

        /// <summary>
        /// Original name: 5 'DC blocker'
        /// </summary>
        Toggle GetDcBlocker();

        /// <summary>
        /// Original name: 5 'DC blocker'
        /// </summary>
        void SetDcBlocker(Toggle value);

        /// <summary>
        /// Maps input to output.
        /// <br>
        /// <br> Write to curve 0 of WaveShaper.
        /// <br> The curve contains 256 values in range of 0 to 1.
        /// </summary>
        int WriteCurveValueMap(float[] buffer);

        /// <summary>
        /// Maps input to output.
        /// <br>
        /// <br> Read from curve 0 of WaveShaper.
        /// <br> The curve contains 256 values in range of 0 to 1.
        /// </summary>
        int ReadCurveValueMap(float[] buffer);
    }

    /// <inheritdoc cref="IWaveShaperModuleHandle"/>
    public readonly partial struct WaveShaperModuleHandle : IWaveShaperModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public WaveShaperModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(WaveShaperModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.WaveShaper;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.WaveShaper;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IWaveShaperModuleHandle.GetInputVolume" />
        public int GetInputVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IWaveShaperModuleHandle.SetInputVolume" />
        public void SetInputVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IWaveShaperModuleHandle.GetMix" />
        public int GetMix(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IWaveShaperModuleHandle.SetMix" />
        public void SetMix(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IWaveShaperModuleHandle.GetOutputVolume" />
        public int GetOutputVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IWaveShaperModuleHandle.SetOutputVolume" />
        public void SetOutputVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IWaveShaperModuleHandle.GetSymmetric" />
        public Toggle GetSymmetric() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IWaveShaperModuleHandle.SetSymmetric" />
        public void SetSymmetric(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IWaveShaperModuleHandle.GetMode" />
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IWaveShaperModuleHandle.SetMode" />
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IWaveShaperModuleHandle.GetDcBlocker" />
        public Toggle GetDcBlocker() => (Toggle)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IWaveShaperModuleHandle.SetDcBlocker" />
        public void SetDcBlocker(Toggle value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IWaveShaperModuleHandle.ReadCurveValueMap"
        public int ReadCurveValueMap(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IWaveShaperModuleHandle.WriteCurveValueMap"
        public int WriteCurveValueMap(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);
    }
}
#endif
