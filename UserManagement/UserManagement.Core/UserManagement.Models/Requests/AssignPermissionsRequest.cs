using System.Collections.Generic;

namespace UserManagement.Models.Requests
{
    public class AssignPermissionsRequest
    {
        public List<int> PermissionIds { get; set; }

        public int UserId { get; set; }
    }
}
