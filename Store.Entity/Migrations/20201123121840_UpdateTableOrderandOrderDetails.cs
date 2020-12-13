using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class UpdateTableOrderandOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 18, 39, 358, DateTimeKind.Utc).AddTicks(5708), new DateTime(2020, 11, 23, 12, 18, 39, 359, DateTimeKind.Utc).AddTicks(3242) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 18, 39, 359, DateTimeKind.Utc).AddTicks(5435), new DateTime(2020, 11, 23, 12, 18, 39, 359, DateTimeKind.Utc).AddTicks(5569) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 12, 18, 39, 359, DateTimeKind.Utc).AddTicks(5604), new DateTime(2020, 11, 23, 12, 18, 39, 359, DateTimeKind.Utc).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 12, 18, 39, 361, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 12, 18, 39, 361, DateTimeKind.Utc).AddTicks(6048));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 52, 43, 98, DateTimeKind.Utc).AddTicks(9915), new DateTime(2020, 11, 23, 8, 52, 43, 99, DateTimeKind.Utc).AddTicks(5729) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 52, 43, 99, DateTimeKind.Utc).AddTicks(7196), new DateTime(2020, 11, 23, 8, 52, 43, 99, DateTimeKind.Utc).AddTicks(7285) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 52, 43, 99, DateTimeKind.Utc).AddTicks(7315), new DateTime(2020, 11, 23, 8, 52, 43, 99, DateTimeKind.Utc).AddTicks(7319) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 8, 52, 43, 101, DateTimeKind.Utc).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 8, 52, 43, 101, DateTimeKind.Utc).AddTicks(4883));
        }
    }
}
