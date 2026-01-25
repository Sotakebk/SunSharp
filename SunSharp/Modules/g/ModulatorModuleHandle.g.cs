/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Amplitude or Phase modulator. First input = Carrier. Other inputs = Modulators (will be mixed into a single signal).
    /// </summary>
    public partial interface IModulatorModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-512
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 0 'Volume'
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 1 'Modulation type'
        /// </summary>
        ModulationType GetModulationType();

        /// <summary>
        /// Original name: 1 'Modulation type'
        /// </summary>
        void SetModulationType(ModulationType value);

        /// <summary>
        /// Original name: 2 'Channels'
        /// </summary>
        Channels GetChannels();

        /// <summary>
        /// Original name: 2 'Channels'
        /// </summary>
        void SetChannels(Channels value);

        /// <summary>
        /// Original name: 3 'Max PM delay'
        /// </summary>
        ModulatorMaxPhaseModulationDelay GetMaxPhaseModulationDelay();

        /// <summary>
        /// Original name: 3 'Max PM delay'
        /// </summary>
        void SetMaxPhaseModulationDelay(ModulatorMaxPhaseModulationDelay value);

        /// <summary>
        /// Original name: 4 'PM interpolation'
        /// </summary>
        ModulatorPhaseModulationInterpolation GetPhaseModulationInterpolation();

        /// <summary>
        /// Original name: 4 'PM interpolation'
        /// </summary>
        void SetPhaseModulationInterpolation(ModulatorPhaseModulationInterpolation value);
    }

    /// <inheritdoc cref="IModulatorModuleHandle"/>
    public readonly partial struct ModulatorModuleHandle : IModulatorModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public ModulatorModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(ModulatorModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Modulator;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Modulator;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IModulatorModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IModulatorModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IModulatorModuleHandle.GetModulationType" />
        public ModulationType GetModulationType() => (ModulationType)ModuleHandle.GetControllerValue(1, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IModulatorModuleHandle.SetModulationType" />
        public void SetModulationType(ModulationType value) => ModuleHandle.SetControllerValue(1, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IModulatorModuleHandle.GetChannels" />
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IModulatorModuleHandle.SetChannels" />
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IModulatorModuleHandle.GetMaxPhaseModulationDelay" />
        public ModulatorMaxPhaseModulationDelay GetMaxPhaseModulationDelay() => (ModulatorMaxPhaseModulationDelay)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IModulatorModuleHandle.SetMaxPhaseModulationDelay" />
        public void SetMaxPhaseModulationDelay(ModulatorMaxPhaseModulationDelay value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IModulatorModuleHandle.GetPhaseModulationInterpolation" />
        public ModulatorPhaseModulationInterpolation GetPhaseModulationInterpolation() => (ModulatorPhaseModulationInterpolation)ModuleHandle.GetControllerValue(4, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IModulatorModuleHandle.SetPhaseModulationInterpolation" />
        public void SetPhaseModulationInterpolation(ModulatorPhaseModulationInterpolation value) => ModuleHandle.SetControllerValue(4, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
