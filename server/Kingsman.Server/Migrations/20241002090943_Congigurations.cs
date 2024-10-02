using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kingsman.Server.Migrations
{
    /// <inheritdoc />
    public partial class Congigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_AspNetUsers_CustomerId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2415e066-0c93-44b3-97e7-2296a5ccd808");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bcb7fd3-b621-40ee-be17-aeba94dabd05");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "OrderItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_CustomerId",
                table: "OrderItems",
                newName: "IX_OrderItems_UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c5d8860-1266-463f-9b54-39771c26f722", null, "Manager", "MANAGER" },
                    { "da87cd5a-f06c-49e7-b65e-5c8531373e94", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "cb6c390a-df9e-47c7-8ba1-c3773a196c13", "user1@example.com", true, "FirstName", "LastName", false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAECAYMU1WYpkKfAsoFSQDRxFn/oAUy6XO4WvXamdGze1qc7h3nuPyQpBL+FFVqBmKZg==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "user1" },
                    { "22222222-2222-2222-2222-222222222222", 0, "2ed28e0b-cf4d-4946-b34e-a7dfaf82a437", "user2@example.com", true, "FirstName", "LastName", false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEIuqC/EosniiYQIrHXMw+ZZqt8AqHQWsZqs7UmyoR/OKdjcnNOlMNept33pli2X2xQ==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "des1", "Puma" },
                    { 2, "des2", "Adidas" },
                    { 3, "des3", "Nike" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Jackets" },
                    { 2, "Overshirts" },
                    { 3, "Bombers" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "HexValue", "Name", "RgbValue" },
                values: new object[,]
                {
                    { 1, "#FF0000", "Red", "255,0,0" },
                    { 2, "#00FF00", "Green", "0,255,0" },
                    { 3, "#0000FF", "Blue", "0,0,255" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-1111-1111-1111-111111111111"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.00m, "11111111-1111-1111-1111-111111111111" },
                    { new Guid("bbbb2222-2222-2222-2222-222222222222"), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m, "22222222-2222-2222-2222-222222222222" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ColorId", "Description", "Name", "Price", "RefNumber", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 3, 2, 1, "A red t-shirt made of 100% cotton.", "Red T-Shirt", 19.99m, "RTS1001", 2, 100 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 2, 3, 3, "Comfortable blue sneakers for everyday wear.", "Blue Sneakers", 49.99m, "BSK2002", 3, 50 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 1, 1, 2, "A stylish green jacket with a hood.", "Green Jacket", 79.99m, "GJ3003", 4, 30 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { new Guid("dddd1111-1111-1111-1111-111111111111"), new Guid("aaaa1111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 2, 50.00m, null },
                    { new Guid("dddd2111-1111-1111-1111-111111111111"), new Guid("bbbb2222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111"), 2, 50.00m, null },
                    { new Guid("eeee2222-2222-2222-2222-222222222222"), new Guid("bbbb2222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), 1, 200.00m, null },
                    { new Guid("ffff3333-3333-3333-3333-333333333333"), new Guid("bbbb2222-2222-2222-2222-222222222222"), new Guid("33333333-3333-3333-3333-333333333333"), 3, 100.00m, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_AspNetUsers_UserId",
                table: "OrderItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_AspNetUsers_UserId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c5d8860-1266-463f-9b54-39771c26f722");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da87cd5a-f06c-49e7-b65e-5c8531373e94");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("dddd1111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("dddd2111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("eeee2222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("ffff3333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OrderItems",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_UserId",
                table: "OrderItems",
                newName: "IX_OrderItems_CustomerId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2415e066-0c93-44b3-97e7-2296a5ccd808", null, "Manager", "MANAGER" },
                    { "7bcb7fd3-b621-40ee-be17-aeba94dabd05", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_AspNetUsers_CustomerId",
                table: "OrderItems",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
