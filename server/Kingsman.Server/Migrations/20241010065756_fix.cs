using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kingsman.Server.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_AspNetUsers_UserId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_UserId",
                table: "OrderItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c5d8860-1266-463f-9b54-39771c26f722");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da87cd5a-f06c-49e7-b65e-5c8531373e94");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "214bfc83-8f7f-4c6b-997f-52a9da5713f2", null, "Administrator", "ADMINISTRATOR" },
                    { "f0c75d27-3780-4f90-8124-fc360e700fb8", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3078234e-d9c8-4a9f-950a-29da57f1b991", "AQAAAAIAAYagAAAAEBgaINYvUziZ2Z8N1hTRBpBEnbZaB8f6KA2Ju8Bc3jHCPbp2/6DX8yaUTYtqm1MD+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e98b2457-53cb-4ca9-aac3-d3efc52650ac", "AQAAAAIAAYagAAAAEOiS5vGsiUNNwQXPVTX3XP+NW60i0yJ4iA+A4lbSishsIetv3QCIlrJClifZQPWGaA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "214bfc83-8f7f-4c6b-997f-52a9da5713f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0c75d27-3780-4f90-8124-fc360e700fb8");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OrderItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c5d8860-1266-463f-9b54-39771c26f722", null, "Manager", "MANAGER" },
                    { "da87cd5a-f06c-49e7-b65e-5c8531373e94", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cb6c390a-df9e-47c7-8ba1-c3773a196c13", "AQAAAAIAAYagAAAAECAYMU1WYpkKfAsoFSQDRxFn/oAUy6XO4WvXamdGze1qc7h3nuPyQpBL+FFVqBmKZg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ed28e0b-cf4d-4946-b34e-a7dfaf82a437", "AQAAAAIAAYagAAAAEIuqC/EosniiYQIrHXMw+ZZqt8AqHQWsZqs7UmyoR/OKdjcnNOlMNept33pli2X2xQ==" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("dddd1111-1111-1111-1111-111111111111"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("dddd2111-1111-1111-1111-111111111111"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("eeee2222-2222-2222-2222-222222222222"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("ffff3333-3333-3333-3333-333333333333"),
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UserId",
                table: "OrderItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_AspNetUsers_UserId",
                table: "OrderItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
