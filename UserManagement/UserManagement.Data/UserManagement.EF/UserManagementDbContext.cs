using Microsoft.EntityFrameworkCore;

namespace UserManagement.EF
{
    public class UserManagementDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UserManagement;Trusted_Connection=True;");

        public DbSet<Entities.User> Users { get; set; }

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

            base.OnModelCreating(builder);
        }

    }
}