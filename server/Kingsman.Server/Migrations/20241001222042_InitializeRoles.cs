using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kingsman.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitializeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2415e066-0c93-44b3-97e7-2296a5ccd808", null, "Manager", "MANAGER" },
                    { "7bcb7fd3-b621-40ee-be17-aeba94dabd05", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2415e066-0c93-44b3-97e7-2296a5ccd808");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bcb7fd3-b621-40ee-be17-aeba94dabd05");
        }
    }
}
