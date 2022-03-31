using System;

namespace UserManagement.Core.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException() : base() { }

        public DataNotFoundException(int userId) : base($"No user found with id {userId}")
        {
        }
    }
}