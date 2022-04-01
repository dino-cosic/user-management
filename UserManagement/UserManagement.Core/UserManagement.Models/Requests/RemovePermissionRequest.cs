namespace UserManagement.Models.Requests
{
    public class RemovePermissionRequest
    {
        public int PermissionId { get; set; }

        public int UserId { get; set; }
    }
}
