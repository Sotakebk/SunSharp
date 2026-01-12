namespace SunSharp.Modules
{
    public interface ITypedModuleHandle
    {
        /// <summary>
        /// Determines whether the underlying module is of the correct type.
        /// </summary>
        bool IsCorrectHandleType();

        void AssertCorrectHandleType();
    }
}
