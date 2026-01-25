/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// MetaModule is a full-featured copy of SunVox in a single module. So you can include one SunVox-project into another recursively.
    /// </summary>
    public partial interface IMetaModuleModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-1024
        /// Original name: 0 'Volume'
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-256
        /// Original name: 1 'Input module'
        /// </summary>
        int GetInputModule(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-256
        /// Original name: 1 'Input module'
        /// </summary>
        void SetInputModule(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 'Play patterns'
        /// </summary>
        MetaModulePatternMode GetPlayPatterns();

        /// <summary>
        /// Original name: 2 'Play patterns'
        /// </summary>
        void SetPlayPatterns(MetaModulePatternMode value);

        /// <summary>
        /// Value range: 1-1000
        /// Original name: 3 'BPM (Beats Per Minute)'
        /// </summary>
        int GetBeatsPerMinute(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-1000
        /// Original name: 3 'BPM (Beats Per Minute)'
        /// </summary>
        void SetBeatsPerMinute(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-31
        /// Original name: 4 'TPL (Ticks Per Line)'
        /// </summary>
        int GetTicksPerLine(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-31
        /// Original name: 4 'TPL (Ticks Per Line)'
        /// </summary>
        void SetTicksPerLine(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);
    }

    /// <inheritdoc cref="IMetaModuleModuleHandle"/>
    public readonly partial struct MetaModuleModuleHandle : IMetaModuleModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public MetaModuleModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(MetaModuleModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.MetaModule;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.MetaModule;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IMetaModuleModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IMetaModuleModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IMetaModuleModuleHandle.GetInputModule" />
        public int GetInputModule(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IMetaModuleModuleHandle.SetInputModule" />
        public void SetInputModule(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IMetaModuleModuleHandle.GetPlayPatterns" />
        public MetaModulePatternMode GetPlayPatterns() => (MetaModulePatternMode)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IMetaModuleModuleHandle.SetPlayPatterns" />
        public void SetPlayPatterns(MetaModulePatternMode value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IMetaModuleModuleHandle.GetBeatsPerMinute" />
        public int GetBeatsPerMinute(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IMetaModuleModuleHandle.SetBeatsPerMinute" />
        public void SetBeatsPerMinute(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IMetaModuleModuleHandle.GetTicksPerLine" />
        public int GetTicksPerLine(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IMetaModuleModuleHandle.SetTicksPerLine" />
        public void SetTicksPerLine(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);
    }
}
#endif
