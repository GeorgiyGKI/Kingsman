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
                    { "a6d7c3a4-7bf8-45bd-a69e-aeb0fe3892c4", null, "Administrator", "ADMINISTRATOR" },
                    { "dd6b6472-d5cf-417a-851d-2c8c32809196", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86dfd14c-79c8-4fa0-bb4f-b8b6bd658cae", "AQAAAAIAAYagAAAAEMwKDH1Yk3WdxPtjBlutCNplYkYYCPPIaYezVac+KFJFRS7P4oKjTGKC+8KuIgwyEA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3caaf8e-4482-4a5e-919d-44d1fe5bdc36", "AQAAAAIAAYagAAAAEBMmvZuz7Y2l566QRiH6xI/3U8zEDTCpO/An7A1AFYpIhkMF/az6E2TQmmhQpgQC3Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6d7c3a4-7bf8-45bd-a69e-aeb0fe3892c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd6b6472-d5cf-417a-851d-2c8c32809196");

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
