using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class Intivitual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 22, 2, 56, 27, 957, DateTimeKind.Utc).AddTicks(8351), new DateTime(2020, 10, 22, 2, 56, 27, 958, DateTimeKind.Utc).AddTicks(351) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 22, 2, 56, 27, 958, DateTimeKind.Utc).AddTicks(1801), new DateTime(2020, 10, 22, 2, 56, 27, 958, DateTimeKind.Utc).AddTicks(1825) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 13, 38, 3, 553, DateTimeKind.Utc).AddTicks(8665), new DateTime(2020, 10, 20, 13, 38, 3, 554, DateTimeKind.Utc).AddTicks(573) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 13, 38, 3, 554, DateTimeKind.Utc).AddTicks(1991), new DateTime(2020, 10, 20, 13, 38, 3, 554, DateTimeKind.Utc).AddTicks(2020) });
        }
    }
}
