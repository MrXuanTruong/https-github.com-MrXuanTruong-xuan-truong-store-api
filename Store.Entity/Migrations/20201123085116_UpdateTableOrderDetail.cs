using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class UpdateTableOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 51, 14, 669, DateTimeKind.Utc).AddTicks(7362), new DateTime(2020, 11, 23, 8, 51, 14, 670, DateTimeKind.Utc).AddTicks(6455) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 51, 14, 670, DateTimeKind.Utc).AddTicks(8952), new DateTime(2020, 11, 23, 8, 51, 14, 670, DateTimeKind.Utc).AddTicks(9099) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 51, 14, 670, DateTimeKind.Utc).AddTicks(9151), new DateTime(2020, 11, 23, 8, 51, 14, 670, DateTimeKind.Utc).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 8, 51, 14, 673, DateTimeKind.Utc).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 8, 51, 14, 673, DateTimeKind.Utc).AddTicks(2842));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 47, 21, 12, DateTimeKind.Utc).AddTicks(1685), new DateTime(2020, 11, 23, 8, 47, 21, 13, DateTimeKind.Utc).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 47, 21, 13, DateTimeKind.Utc).AddTicks(2983), new DateTime(2020, 11, 23, 8, 47, 21, 13, DateTimeKind.Utc).AddTicks(3123) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 23, 8, 47, 21, 13, DateTimeKind.Utc).AddTicks(3165), new DateTime(2020, 11, 23, 8, 47, 21, 13, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 8, 47, 21, 15, DateTimeKind.Utc).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 8, 47, 21, 15, DateTimeKind.Utc).AddTicks(7916));
        }
    }
}
