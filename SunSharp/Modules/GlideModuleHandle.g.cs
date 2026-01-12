/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Glide is similar to the MultiSynth (which sends the input events to the connected output modules), but it also adds the commands of smooth transition between the notes.
    /// </summary>
    public partial interface IGlideModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-1000
        /// Original name: 0 'Response'
        /// </summary>
        int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1000
        /// Original name: 0 'Response'
        /// </summary>
        void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32768
        /// Original name: 1 'Sample rate'
        /// </summary>
        int GetSampleRate(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32768
        /// Original name: 1 'Sample rate'
        /// </summary>
        void SetSampleRate(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 'Reset on 1st note'
        /// </summary>
        Toggle GetResetOnStNote1();

        /// <summary>
        /// Original name: 2 'Reset on 1st note'
        /// </summary>
        void SetResetOnStNote1(Toggle value);

        /// <summary>
        /// Original name: 3 'Polyphony'
        /// </summary>
        Toggle GetPolyphony();

        /// <summary>
        /// Original name: 3 'Polyphony'
        /// </summary>
        void SetPolyphony(Toggle value);

        /// <summary>
        /// Value range: displayed: -600-600, real: 0-1200
        /// Original name: 4 'Pitch'
        /// </summary>
        int GetPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -600-600, real: 0-1200
        /// Original name: 4 'Pitch'
        /// </summary>
        void SetPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-200
        /// Original name: 5 'Pitch scale'
        /// </summary>
        int GetPitchScale(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-200
        /// Original name: 5 'Pitch scale'
        /// </summary>
        void SetPitchScale(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 6 'Reset'
        /// </summary>
        Toggle GetReset();

        /// <summary>
        /// Original name: 6 'Reset'
        /// </summary>
        void SetReset(Toggle value);
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

        /// <inheritdoc cref="IGlideModuleHandle.GetResponse" />
        public int GetResponse(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetResponse" />
        public void SetResponse(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.GetSampleRate" />
        public int GetSampleRate(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetSampleRate" />
        public void SetSampleRate(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.GetResetOnStNote1" />
        public Toggle GetResetOnStNote1() => (Toggle)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.SetResetOnStNote1" />
        public void SetResetOnStNote1(Toggle value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.GetPolyphony" />
        public Toggle GetPolyphony() => (Toggle)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.SetPolyphony" />
        public void SetPolyphony(Toggle value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.GetPitch" />
        public int GetPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetPitch" />
        public void SetPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.GetPitchScale" />
        public int GetPitchScale(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.SetPitchScale" />
        public void SetPitchScale(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IGlideModuleHandle.GetReset" />
        public Toggle GetReset() => (Toggle)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IGlideModuleHandle.SetReset" />
        public void SetReset(Toggle value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
