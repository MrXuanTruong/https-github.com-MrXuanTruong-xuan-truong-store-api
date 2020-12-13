using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 28, 5, 16, 25, 669, DateTimeKind.Utc).AddTicks(3598), new DateTime(2020, 11, 28, 5, 16, 25, 670, DateTimeKind.Utc).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 28, 5, 16, 25, 670, DateTimeKind.Utc).AddTicks(1971), new DateTime(2020, 11, 28, 5, 16, 25, 670, DateTimeKind.Utc).AddTicks(2057) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 28, 5, 16, 25, 670, DateTimeKind.Utc).AddTicks(2083), new DateTime(2020, 11, 28, 5, 16, 25, 670, DateTimeKind.Utc).AddTicks(2086) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 28, 5, 16, 25, 671, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 28, 5, 16, 25, 671, DateTimeKind.Utc).AddTicks(7133));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
