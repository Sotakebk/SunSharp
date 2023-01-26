namespace SunSharp.Abstractions
{
    internal class AbstractionBuildingException : System.Exception
    {
        public AbstractionBuildingException(string message) : base(message)
        {
        }

        public AbstractionBuildingException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
