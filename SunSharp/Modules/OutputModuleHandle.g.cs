/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Audio output module.
    /// </summary>
    public partial interface IOutputModuleHandle : ITypedModuleHandle
    {
    }

    /// <inheritdoc cref="IOutputModuleHandle"/>
    public readonly partial struct OutputModuleHandle : IOutputModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public OutputModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(OutputModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Output;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Output;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }
    }
}
#endif
