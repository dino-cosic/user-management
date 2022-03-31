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
                },
                new Entities.User {
                    Id= 2,
                    FirstName= "Alonzo",
                    LastName= "Oliveti",
                    Username= "aoliveti1",
                    Password= "gGdUPAtzi",
                    Email= "aoliveti1@hao123.com",
                    Status= Entities.Status.Active
                },
                new Entities.User {
                    Id= 3,
                    FirstName= "Aleta",
                    LastName= "Isaaksohn",
                    Username= "aisaaksohn2",
                    Password= "vNPKGT5",
                    Email= "aisaaksohn2@bing.com",
                    Status= Entities.Status.Active},
                    new Entities.User {
                    Id= 4,
                    FirstName= "Hilary",
                    LastName= "Trendle",
                    Username= "htrendle3",
                    Password= "aa9VHs",
                    Email= "htrendle3@washington.edu",
                    Status= Entities.Status.Active
                },
                new Entities.User{
                    Id= 5,
                    FirstName= "Yorgo",
                    LastName= "Aupol",
                    Username= "yaupol4",
                    Password= "kcfIDPxcwqVM",
                    Email= "yaupol4@google.ru",
                    Status= Entities.Status.Active
                },
                new Entities.User {
                    Id= 6,
                    FirstName= "Adaline",
                    LastName= "Balstone",
                    Username= "abalstone5",
                    Password= "EbPYJJEOuKaV",
                    Email= "abalstone5@oakley.com",
                    Status= Entities.Status.Active
                },
                new Entities.User {
                    Id= 7,
                    FirstName= "Cassius",
                    LastName= "Aloshikin",
                    Username= "caloshikin6",
                    Password= "hXl6f5I2wj",
                    Email= "caloshikin6@e-recht24.de",
                    Status= Entities.Status.Active
                },
                new Entities.User {
                    Id= 8,
                    FirstName= "Reggis",
                    LastName= "Prop",
                    Username= "rprop7",
                    Password= "mnYOoAsk",
                    Email= "rprop7@soundcloud.com",
                    Status= Entities.Status.Active
                },
                new Entities.User {
                    Id= 9,
                    FirstName= "Jojo",
                    LastName= "Hanhardt",
                    Username= "jhanhardt8",
                    Password= "KTMJwApWNbbE",
                    Email= "jhanhardt8@cloudflare.com",
                    Status= Entities.Status.Active
                },
                new Entities.User {
                    Id= 10,
                    FirstName= "Marlo",
                    LastName= "Perch",
                    Username= "mperch9",
                    Password= "oBT7NwZX3",
                    Email= "mperch9@upenn.edu",
                    Status= Entities.Status.Active
                    }
            });

            builder.Entity<Entities.Permission>().HasData(new Entities.Permission[]
            {
                new Entities.Permission
                {
                    Id = 1,
                    Code = "Admin",
                    Description = "All access rights over the application."
                },
                new Entities.Permission
                {
                    Id = 2,
                    Code = "Read",
                    Description = "Read access rights over the application."
                },
                new Entities.Permission
                {
                    Id = 3,
                    Code = "Write",
                    Description = "Write access rights over the application."
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