using System;

namespace UserManagement.Core.Exceptions
{
    public class PermissionAlreadyAssignedException : Exception
    {
        public PermissionAlreadyAssignedException()
            : base("Choosen permission(s) already assigned to this user.")
        {
        }
    }
}