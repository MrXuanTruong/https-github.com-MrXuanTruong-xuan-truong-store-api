using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class InitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 24, 53, 272, DateTimeKind.Utc).AddTicks(6015), new DateTime(2020, 11, 23, 12, 24, 53, 273, DateTimeKind.Utc).AddTicks(5133) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 24, 53, 273, DateTimeKind.Utc).AddTicks(7408), new DateTime(2020, 11, 23, 12, 24, 53, 273, DateTimeKind.Utc).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 24, 53, 273, DateTimeKind.Utc).AddTicks(7664), new DateTime(2020, 11, 23, 12, 24, 53, 273, DateTimeKind.Utc).AddTicks(7670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 12, 24, 53, 275, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 12, 24, 53, 275, DateTimeKind.Utc).AddTicks(7792));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 21, 18, 602, DateTimeKind.Utc).AddTicks(5534), new DateTime(2020, 11, 23, 12, 21, 18, 603, DateTimeKind.Utc).AddTicks(5914) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 21, 18, 603, DateTimeKind.Utc).AddTicks(8134), new DateTime(2020, 11, 23, 12, 21, 18, 603, DateTimeKind.Utc).AddTicks(8258) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 21, 18, 603, DateTimeKind.Utc).AddTicks(8373), new DateTime(2020, 11, 23, 12, 21, 18, 603, DateTimeKind.Utc).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 12, 21, 18, 606, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 12, 21, 18, 606, DateTimeKind.Utc).AddTicks(3227));
        }
    }
}
