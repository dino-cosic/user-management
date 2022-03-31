using System;

namespace UserManagement.Core.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException() : base() { }

        public DataNotFoundException(string resource, string paramName, int id) : base($"No data was found in the database for {resource} with {paramName}: {id}")
        {
        }
    }
}