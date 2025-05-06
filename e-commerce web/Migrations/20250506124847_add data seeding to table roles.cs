using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce_web.Migrations
{
    /// <inheritdoc />
    public partial class adddataseedingtotableroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5579cda1-5bbd-4355-bee1-4d623bb976de", null, "User", "USER" },
                    { "b0a3e2ff-b1f7-4c6b-bfb1-01ab5bbc6815", null, "Admin", "ADMIN" },
                    { "f6fad1d1-43f5-4968-9329-7ef92a658c6f", null, "Vendor", "VENDOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5579cda1-5bbd-4355-bee1-4d623bb976de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0a3e2ff-b1f7-4c6b-bfb1-01ab5bbc6815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6fad1d1-43f5-4968-9329-7ef92a658c6f");
        }
    }
}
