using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.EF.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Code { get; set; }

        [Required]
        [MaxLength(512)]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}