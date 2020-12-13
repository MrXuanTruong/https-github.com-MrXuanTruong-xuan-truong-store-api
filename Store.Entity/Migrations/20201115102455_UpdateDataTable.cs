using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class UpdateDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 15, 10, 24, 54, 366, DateTimeKind.Utc).AddTicks(97), new DateTime(2020, 11, 15, 10, 24, 54, 366, DateTimeKind.Utc).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 15, 10, 24, 54, 366, DateTimeKind.Utc).AddTicks(7193), new DateTime(2020, 11, 15, 10, 24, 54, 366, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 15, 10, 24, 54, 366, DateTimeKind.Utc).AddTicks(7301), new DateTime(2020, 11, 15, 10, 24, 54, 366, DateTimeKind.Utc).AddTicks(7304) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 15, 10, 24, 54, 368, DateTimeKind.Utc).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 15, 10, 24, 54, 368, DateTimeKind.Utc).AddTicks(1514));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 15, 9, 30, 4, 787, DateTimeKind.Utc).AddTicks(7530), new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(2732) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(4142), new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(4248), new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 15, 9, 30, 4, 790, DateTimeKind.Utc).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 15, 9, 30, 4, 790, DateTimeKind.Utc).AddTicks(2638));
        }
    }
}
