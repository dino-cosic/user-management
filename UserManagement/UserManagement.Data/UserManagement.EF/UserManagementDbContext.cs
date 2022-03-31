using Microsoft.EntityFrameworkCore;

namespace UserManagement.EF
{
    public class UserManagementDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UserManagement;Trusted_Connection=True;");

        public DbSet<Entities.User> Users { get; set; }

        public DbSet<Entities.Permission> Permissions { get; set; }

        public DbSet<Entities.UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Entities.User>().HasData(new Entities.User[]
            {
                new Entities.User
                {
                    Id = 1,
                    FirstName = "Dino",
                    LastName = "Cosic",
                    Username = "dcosic",
                    Password =  "Password41ng",
                    Email = "dino.cosic@company.com",
                    Status = Entities.Status.Active
                }
            });

            builder.Entity<Entities.Permission>().HasData(new Entities.Permission[]
            {
                new Entities.Permission
                {
                    Id = 1,
                    Code = "Admin",
                    Description = "Read permission alows reading all data in the application"
                }
            });

            builder.Entity<Entities.UserPermission>().HasData(new Entities.UserPermission[]
            {
                new Entities.UserPermission
                {
                    Id = 1,
                    UserId = 1,
                    PermissionId = 1,
                }
            });


            base.OnModelCreating(builder);
        }
    }
}