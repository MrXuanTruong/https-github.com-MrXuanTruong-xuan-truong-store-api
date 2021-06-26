using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class InsertTableVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ExportStock_ExportStockId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImportStock_ImportStockId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ExportStockId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImportStockId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExportStockId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImportStockId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ImportStock");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ExportStock");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExportStock");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ExportStock");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ExportStock");

            migrationBuilder.RenameColumn(
                name: "PaymentmethodId",
                table: "Orders",
                newName: "PaymentMethodId");

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "ProductBrands",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "ProductBrands",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PaymentMethodId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ImportStockDetail",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ImportStockDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImportStockCode",
                table: "ImportStock",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportStockCode",
                table: "ExportStock",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ExportStock",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "ExportStock",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VoucherId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExportStockDetail",
                columns: table => new
                {
                    ExportStockDetailId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    ExportStockId = table.Column<long>(nullable: false),
                    ColorId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportStockDetail", x => x.ExportStockDetailId);
                    table.ForeignKey(
                        name: "FK_ExportStockDetail_ExportStock_ExportStockId",
                        column: x => x.ExportStockId,
                        principalTable: "ExportStock",
                        principalColumn: "ExportStockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportStockDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    PaymentMethodName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    VoucherCode = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherId);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 14, 8, 15, 18, 953, DateTimeKind.Utc).AddTicks(2348), new DateTime(2021, 6, 14, 8, 15, 18, 953, DateTimeKind.Utc).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 14, 8, 15, 18, 953, DateTimeKind.Utc).AddTicks(5619), new DateTime(2021, 6, 14, 8, 15, 18, 953, DateTimeKind.Utc).AddTicks(5667) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 14, 8, 15, 18, 953, DateTimeKind.Utc).AddTicks(5682), new DateTime(2021, 6, 14, 8, 15, 18, 953, DateTimeKind.Utc).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 6, 14, 8, 15, 18, 954, DateTimeKind.Utc).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 6, 14, 8, 15, 18, 954, DateTimeKind.Utc).AddTicks(3017));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BranchId",
                table: "Orders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ColorId",
                table: "OrderDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_VoucherId",
                table: "Accounts",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportStockDetail_ExportStockId",
                table: "ExportStockDetail",
                column: "ExportStockId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportStockDetail_ProductId",
                table: "ExportStockDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Vouchers_VoucherId",
                table: "Accounts",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "VoucherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Colors_ColorId",
                table: "OrderDetails",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Branches_BranchId",
                table: "Orders",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Vouchers_VoucherId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Colors_ColorId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Branches_BranchId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ExportStockDetail");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BranchId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ColorId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_VoucherId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ImportStockDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ImportStockDetail");

            migrationBuilder.DropColumn(
                name: "ImportStockCode",
                table: "ImportStock");

            migrationBuilder.DropColumn(
                name: "ExportStockCode",
                table: "ExportStock");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "ExportStock");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ExportStock");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "Orders",
                newName: "PaymentmethodId");

            migrationBuilder.AddColumn<long>(
                name: "ExportStockId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImportStockId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PaymentmethodId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ImportStock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "ExportStock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExportStock",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ExportStock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "ExportStock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_ExportStockId",
                table: "Products",
                column: "ExportStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImportStockId",
                table: "Products",
                column: "ImportStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ExportStock_ExportStockId",
                table: "Products",
                column: "ExportStockId",
                principalTable: "ExportStock",
                principalColumn: "ExportStockId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImportStock_ImportStockId",
                table: "Products",
                column: "ImportStockId",
                principalTable: "ImportStock",
                principalColumn: "ImportStockId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
