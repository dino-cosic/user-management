using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.EF.Migrations
{
    public partial class UpdatedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "All access rights over the application.");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 2, "Read", "Read access rights over the application." },
                    { 3, "Write", "Write access rights over the application." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Status", "Username" },
                values: new object[,]
                {
                    { 2, "aoliveti1@hao123.com", "Alonzo", "Oliveti", "gGdUPAtzi", 1, "aoliveti1" },
                    { 3, "aisaaksohn2@bing.com", "Aleta", "Isaaksohn", "vNPKGT5", 1, "aisaaksohn2" },
                    { 4, "htrendle3@washington.edu", "Hilary", "Trendle", "aa9VHs", 1, "htrendle3" },
                    { 5, "yaupol4@google.ru", "Yorgo", "Aupol", "kcfIDPxcwqVM", 1, "yaupol4" },
                    { 6, "abalstone5@oakley.com", "Adaline", "Balstone", "EbPYJJEOuKaV", 1, "abalstone5" },
                    { 7, "caloshikin6@e-recht24.de", "Cassius", "Aloshikin", "hXl6f5I2wj", 1, "caloshikin6" },
                    { 8, "rprop7@soundcloud.com", "Reggis", "Prop", "mnYOoAsk", 1, "rprop7" },
                    { 9, "jhanhardt8@cloudflare.com", "Jojo", "Hanhardt", "KTMJwApWNbbE", 1, "jhanhardt8" },
                    { 10, "mperch9@upenn.edu", "Marlo", "Perch", "oBT7NwZX3", 1, "mperch9" }
                });

            migrationBuilder.DropTable(
                name: "PermissionUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Read permission alows reading all data in the application");
        }
    }
}
