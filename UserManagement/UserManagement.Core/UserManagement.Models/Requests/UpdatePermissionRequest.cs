namespace UserManagement.Models.Requests
{
    public class UpdatePermissionRequest
    {
        public int PermissionId { get; set; }

        public int UserId { get; set; }

        public string PermissionCode { get; set; }
    }
}
