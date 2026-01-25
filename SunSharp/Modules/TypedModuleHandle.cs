namespace SunSharp.Modules
{
    public interface ITypedModuleHandle
    {
        /// <summary>
        /// Determines whether the underlying module is of the correct type.
        /// </summary>
        bool IsCorrectHandleType();

        /// <summary>
        /// Throws an exception if the underlying module is not of the correct type.
        /// </summary>
        /// <exception cref="IncorrectSynthHandleTypeException">Thrown if the underlying module is not of the correct type.</exception>
        void AssertCorrectHandleType();
    }
}
