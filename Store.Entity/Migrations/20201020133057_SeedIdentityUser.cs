using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Email", "Phone", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 13, 30, 56, 599, DateTimeKind.Utc).AddTicks(7688), "xuantruongmu98@gmail.com", "0345286525", new DateTime(2020, 10, 20, 13, 30, 56, 599, DateTimeKind.Utc).AddTicks(9026) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 13, 30, 56, 600, DateTimeKind.Utc).AddTicks(489), new DateTime(2020, 10, 20, 13, 30, 56, 600, DateTimeKind.Utc).AddTicks(516) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Email", "Phone", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 3, 8, 58, 486, DateTimeKind.Utc).AddTicks(9577), "locxtit@gmail.com", "0986210955", new DateTime(2020, 10, 20, 3, 8, 58, 487, DateTimeKind.Utc).AddTicks(1118) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 3, 8, 58, 487, DateTimeKind.Utc).AddTicks(2661), new DateTime(2020, 10, 20, 3, 8, 58, 487, DateTimeKind.Utc).AddTicks(2687) });
        }
    }
}
