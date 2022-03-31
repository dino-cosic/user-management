using System;

namespace UserManagement.Core.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException() : base() { }

        public DataNotFoundException(string resource, string paramName, int userId) : base($"No data was found in the database for {resource} with {paramName}: {userId}")
        {
        }
    }
}