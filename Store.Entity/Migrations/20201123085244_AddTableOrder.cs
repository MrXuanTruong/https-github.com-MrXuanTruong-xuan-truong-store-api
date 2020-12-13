using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class AddTableOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
