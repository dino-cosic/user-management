using System;

namespace UserManagement.Core.Exceptions
{
    public class PermissionAlreadyAssignedException : Exception
    {
        public PermissionAlreadyAssignedException(string code)
            : base($"The permission with code: {code} is already assigned to this user.")
        {
        }
    }
}