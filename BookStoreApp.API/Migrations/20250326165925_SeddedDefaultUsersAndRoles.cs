using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94c252a6-9a2d-4236-a5b9-a5daefe55cbd", "35316823-7634-4e80-a900-5b3ea77ab87a", "User", "USER" },
                    { "cf90e635-2edd-429d-871f-e1bd28dcd30e", "8e29e6e6-c46c-463f-b38a-85d0696f298c", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "34c434ac-ad11-4d05-82f7-a39ccea6045d", 0, "de9a3ef7-5a37-460f-bf82-712f75a653e7", "admin@bookstore.com", false, "Admin", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEBzG6mhIv85WfrXO9RFHPfMT5PvY1sV9EdF/Zol7+MccBeLOi5Vmlja1nXua3c0D2A==", null, false, "d7592b03-6fc0-49c9-8163-2cba2e74c634", false, "admin@bookstore.com" },
                    { "74f518ec-b5aa-48b8-aa8a-3de90a93be2d", 0, "4e321370-ceb4-4078-8c73-d0d7da1d5956", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEDRIs/89cNe8jnLQXwwznYWRIMd69cXQo5OGf2niT8NcjaBf6vqKEJ1VVbLdEm2YLA==", null, false, "553b8893-6bc1-402f-ba6d-1793991c16aa", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cf90e635-2edd-429d-871f-e1bd28dcd30e", "34c434ac-ad11-4d05-82f7-a39ccea6045d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "94c252a6-9a2d-4236-a5b9-a5daefe55cbd", "74f518ec-b5aa-48b8-aa8a-3de90a93be2d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf90e635-2edd-429d-871f-e1bd28dcd30e", "34c434ac-ad11-4d05-82f7-a39ccea6045d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94c252a6-9a2d-4236-a5b9-a5daefe55cbd", "74f518ec-b5aa-48b8-aa8a-3de90a93be2d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c252a6-9a2d-4236-a5b9-a5daefe55cbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf90e635-2edd-429d-871f-e1bd28dcd30e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34c434ac-ad11-4d05-82f7-a39ccea6045d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74f518ec-b5aa-48b8-aa8a-3de90a93be2d");
        }
    }
}
