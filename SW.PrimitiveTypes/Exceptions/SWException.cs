using System;

namespace SW.PrimitiveTypes
{
    public class SWException : Exception
    {
        public SWException()
        {
        }

        public SWException(string message) : base(message)
        {
        }

        public SWException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
