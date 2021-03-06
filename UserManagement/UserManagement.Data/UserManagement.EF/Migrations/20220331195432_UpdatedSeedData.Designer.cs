// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.EF;

namespace UserManagement.EF.Migrations
{
    [DbContext(typeof(UserManagementDbContext))]
    [Migration("20220331195432_UpdatedSeedData")]
    partial class UpdatedSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PermissionUser", b =>
                {
                    b.Property<int>("PermissionsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PermissionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PermissionUser");
                });

            modelBuilder.Entity("UserManagement.EF.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "Admin",
                            Description = "All access rights over the application."
                        },
                        new
                        {
                            Id = 2,
                            Code = "Read",
                            Description = "Read access rights over the application."
                        },
                        new
                        {
                            Id = 3,
                            Code = "Write",
                            Description = "Write access rights over the application."
                        });
                });

            modelBuilder.Entity("UserManagement.EF.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "dino.cosic@company.com",
                            FirstName = "Dino",
                            LastName = "Cosic",
                            Password = "Password41ng",
                            Status = 1,
                            Username = "dcosic"
                        },
                        new
                        {
                            Id = 2,
                            Email = "aoliveti1@hao123.com",
                            FirstName = "Alonzo",
                            LastName = "Oliveti",
                            Password = "gGdUPAtzi",
                            Status = 1,
                            Username = "aoliveti1"
                        },
                        new
                        {
                            Id = 3,
                            Email = "aisaaksohn2@bing.com",
                            FirstName = "Aleta",
                            LastName = "Isaaksohn",
                            Password = "vNPKGT5",
                            Status = 1,
                            Username = "aisaaksohn2"
                        },
                        new
                        {
                            Id = 4,
                            Email = "htrendle3@washington.edu",
                            FirstName = "Hilary",
                            LastName = "Trendle",
                            Password = "aa9VHs",
                            Status = 1,
                            Username = "htrendle3"
                        },
                        new
                        {
                            Id = 5,
                            Email = "yaupol4@google.ru",
                            FirstName = "Yorgo",
                            LastName = "Aupol",
                            Password = "kcfIDPxcwqVM",
                            Status = 1,
                            Username = "yaupol4"
                        },
                        new
                        {
                            Id = 6,
                            Email = "abalstone5@oakley.com",
                            FirstName = "Adaline",
                            LastName = "Balstone",
                            Password = "EbPYJJEOuKaV",
                            Status = 1,
                            Username = "abalstone5"
                        },
                        new
                        {
                            Id = 7,
                            Email = "caloshikin6@e-recht24.de",
                            FirstName = "Cassius",
                            LastName = "Aloshikin",
                            Password = "hXl6f5I2wj",
                            Status = 1,
                            Username = "caloshikin6"
                        },
                        new
                        {
                            Id = 8,
                            Email = "rprop7@soundcloud.com",
                            FirstName = "Reggis",
                            LastName = "Prop",
                            Password = "mnYOoAsk",
                            Status = 1,
                            Username = "rprop7"
                        },
                        new
                        {
                            Id = 9,
                            Email = "jhanhardt8@cloudflare.com",
                            FirstName = "Jojo",
                            LastName = "Hanhardt",
                            Password = "KTMJwApWNbbE",
                            Status = 1,
                            Username = "jhanhardt8"
                        },
                        new
                        {
                            Id = 10,
                            Email = "mperch9@upenn.edu",
                            FirstName = "Marlo",
                            LastName = "Perch",
                            Password = "oBT7NwZX3",
                            Status = 1,
                            Username = "mperch9"
                        });
                });

            modelBuilder.Entity("UserManagement.EF.Entities.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("PermissionUser", b =>
                {
                    b.HasOne("UserManagement.EF.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagement.EF.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserManagement.EF.Entities.UserPermission", b =>
                {
                    b.HasOne("UserManagement.EF.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagement.EF.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
