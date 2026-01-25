/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// DC blocking filter.
    /// </summary>
    public partial interface IDcBlockerModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Original name: 0 'Channels'
        /// </summary>
        Channels GetChannels();

        /// <summary>
        /// Original name: 0 'Channels'
        /// </summary>
        void SetChannels(Channels value);
    }

    /// <inheritdoc cref="IDcBlockerModuleHandle"/>
    public readonly partial struct DcBlockerModuleHandle : IDcBlockerModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public DcBlockerModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(DcBlockerModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.DcBlocker;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.DcBlocker;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IDcBlockerModuleHandle.GetChannels" />
        public Channels GetChannels() => (Channels)ModuleHandle.GetControllerValue(0, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IDcBlockerModuleHandle.SetChannels" />
        public void SetChannels(Channels value) => ModuleHandle.SetControllerValue(0, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
