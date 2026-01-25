/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Pitch Detector tries to detect the pitch of the incoming audio signal. The frequency and note will be displayed. Notes will be sent to the module output.
    /// </summary>
    public partial interface IPitchDetectorModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Original name: 0 'Algorithm'
        /// </summary>
        PitchDetectorAlgorithm GetAlgorithm();

        /// <summary>
        /// Original name: 0 'Algorithm'
        /// </summary>
        void SetAlgorithm(PitchDetectorAlgorithm value);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 1 'Threshold'
        /// </summary>
        int GetThreshold(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 1 'Threshold'
        /// </summary>
        void SetThreshold(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Gain'
        /// </summary>
        int GetGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Gain'
        /// </summary>
        void SetGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 3 'Microtones'
        /// </summary>
        Toggle GetMicrotones();

        /// <summary>
        /// Original name: 3 'Microtones'
        /// </summary>
        void SetMicrotones(Toggle value);

        /// <summary>
        /// Value range: displayed: -256-256, real: 0-512
        /// Original name: 4 'Detector finetune'
        /// </summary>
        int GetDetectorFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -256-256, real: 0-512
        /// Original name: 4 'Detector finetune'
        /// </summary>
        void SetDetectorFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-4000
        /// Original name: 5 'LP filter freq (0 - OFF)'
        /// </summary>
        int GetLpFilterFreqOff0(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-4000
        /// Original name: 5 'LP filter freq (0 - OFF)'
        /// </summary>
        void SetLpFilterFreqOff0(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 6 'LP filter roll-off'
        /// </summary>
        FilterRollOff GetLpFilterRollOff();

        /// <summary>
        /// Original name: 6 'LP filter roll-off'
        /// </summary>
        void SetLpFilterRollOff(FilterRollOff value);

        /// <summary>
        /// Original name: 7 'Alg1-2 Sample rate (Hz)'
        /// </summary>
        PitchDetectorAlgSampleRate GetAlgSampleRateHz12();

        /// <summary>
        /// Original name: 7 'Alg1-2 Sample rate (Hz)'
        /// </summary>
        void SetAlgSampleRateHz12(PitchDetectorAlgSampleRate value);

        /// <summary>
        /// Original name: 8 'Alg1-2 Buffer (ms)'
        /// </summary>
        PitchDetectorBufferSize GetAlgBufferMs12();

        /// <summary>
        /// Original name: 8 'Alg1-2 Buffer (ms)'
        /// </summary>
        void SetAlgBufferMs12(PitchDetectorBufferSize value);

        /// <summary>
        /// Value range: 0-100
        /// Original name: 9 'Alg1-2 Buf overlap'
        /// </summary>
        int GetAlgBufOverlap12(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-100
        /// Original name: 9 'Alg1-2 Buf overlap'
        /// </summary>
        void SetAlgBufOverlap12(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-100
        /// Original name: 10 'Alg1 Sensitivity (absolute threshold)'
        /// </summary>
        int GetAlgSensitivityAbsoluteThreshold1(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-100
        /// Original name: 10 'Alg1 Sensitivity (absolute threshold)'
        /// </summary>
        void SetAlgSensitivityAbsoluteThreshold1(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 11 'Record notes'
        /// </summary>
        Toggle GetRecordNotes();

        /// <summary>
        /// Original name: 11 'Record notes'
        /// </summary>
        void SetRecordNotes(Toggle value);
    }

    /// <inheritdoc cref="IPitchDetectorModuleHandle"/>
    public readonly partial struct PitchDetectorModuleHandle : IPitchDetectorModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public PitchDetectorModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(PitchDetectorModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.PitchDetector;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.PitchDetector;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetAlgorithm" />
        public PitchDetectorAlgorithm GetAlgorithm() => (PitchDetectorAlgorithm)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetAlgorithm" />
        public void SetAlgorithm(PitchDetectorAlgorithm value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetThreshold" />
        public int GetThreshold(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetThreshold" />
        public void SetThreshold(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetGain" />
        public int GetGain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetGain" />
        public void SetGain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetMicrotones" />
        public Toggle GetMicrotones() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetMicrotones" />
        public void SetMicrotones(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetDetectorFinetune" />
        public int GetDetectorFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetDetectorFinetune" />
        public void SetDetectorFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetLpFilterFreqOff0" />
        public int GetLpFilterFreqOff0(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetLpFilterFreqOff0" />
        public void SetLpFilterFreqOff0(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetLpFilterRollOff" />
        public FilterRollOff GetLpFilterRollOff() => (FilterRollOff)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetLpFilterRollOff" />
        public void SetLpFilterRollOff(FilterRollOff value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetAlgSampleRateHz12" />
        public PitchDetectorAlgSampleRate GetAlgSampleRateHz12() => (PitchDetectorAlgSampleRate)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetAlgSampleRateHz12" />
        public void SetAlgSampleRateHz12(PitchDetectorAlgSampleRate value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetAlgBufferMs12" />
        public PitchDetectorBufferSize GetAlgBufferMs12() => (PitchDetectorBufferSize)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetAlgBufferMs12" />
        public void SetAlgBufferMs12(PitchDetectorBufferSize value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetAlgBufOverlap12" />
        public int GetAlgBufOverlap12(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetAlgBufOverlap12" />
        public void SetAlgBufOverlap12(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetAlgSensitivityAbsoluteThreshold1" />
        public int GetAlgSensitivityAbsoluteThreshold1(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetAlgSensitivityAbsoluteThreshold1" />
        public void SetAlgSensitivityAbsoluteThreshold1(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.GetRecordNotes" />
        public Toggle GetRecordNotes() => (Toggle)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IPitchDetectorModuleHandle.SetRecordNotes" />
        public void SetRecordNotes(Toggle value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
