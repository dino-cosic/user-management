using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.EF.Entities
{
    public class UserPermission
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Permission")]
        public int PermissionId { get; set; }

        public User User { get; set; }

        public Permission Permission { get; set; }
    }
}