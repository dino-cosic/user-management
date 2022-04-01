using System;

namespace UserManagement.Core.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string paramnName) : base($"Provided {paramnName} is not valid.")
        {
        }
    }
}