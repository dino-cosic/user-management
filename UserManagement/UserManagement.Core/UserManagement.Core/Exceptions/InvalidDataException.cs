using System;

namespace UserManagement.Core.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string paramName) : base($"Provided {paramName} is not valid.")
        {
        }
    }
}