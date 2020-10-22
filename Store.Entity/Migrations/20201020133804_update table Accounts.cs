using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class updatetableAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "Address", "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { "Quận 9", new DateTime(2020, 10, 20, 13, 38, 3, 553, DateTimeKind.Utc).AddTicks(8665), "e10adc3949ba59abbe56e057f20f883e", new DateTime(2020, 10, 20, 13, 38, 3, 554, DateTimeKind.Utc).AddTicks(573) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 13, 38, 3, 554, DateTimeKind.Utc).AddTicks(1991), new DateTime(2020, 10, 20, 13, 38, 3, 554, DateTimeKind.Utc).AddTicks(2020) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "Address", "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { null, new DateTime(2020, 10, 20, 13, 30, 56, 599, DateTimeKind.Utc).AddTicks(7688), "e10adc3949ba59abbe56e057f20f883e", new DateTime(2020, 10, 20, 13, 30, 56, 599, DateTimeKind.Utc).AddTicks(9026) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 13, 30, 56, 600, DateTimeKind.Utc).AddTicks(489), new DateTime(2020, 10, 20, 13, 30, 56, 600, DateTimeKind.Utc).AddTicks(516) });
        }
    }
}
