using System;

namespace UserManagement.Core.Exceptions
{
    public class BusinessDataValidationException : Exception
    {
        public BusinessDataValidationException(string paramName, string paramValue, string? rules = null)
            : base($"{paramName} is provided with invalid value: {paramValue}. Please try again with different value." + $"{rules}")
        {
        }
    }
}