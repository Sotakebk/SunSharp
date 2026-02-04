using System;

namespace SunSharp.Redistribution
{
    public class LibraryLoadingException : Exception
    {
        public LibraryLoadingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public LibraryLoadingException(string message) : base(message)
        {
        }
    }
}
