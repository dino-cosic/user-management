using System;

namespace UserManagement.Core.Exceptions
{
    public class UserInvalidDataException : Exception
    {
        public UserInvalidDataException() : base($"Provided user data is not valid.")
        {
        }
    }
}