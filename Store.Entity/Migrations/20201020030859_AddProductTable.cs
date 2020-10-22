using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStatuses",
                columns: table => new
                {
                    AccountStatusId = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AccountStatusName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatuses", x => x.AccountStatusId);
                    table.ForeignKey(
                        name: "FK_AccountStatuses_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountStatuses_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    BranchName = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchTypes",
                columns: table => new
                {
                    BranchTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    BranchTypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTypes", x => x.BranchTypeId);
                    table.ForeignKey(
                        name: "FK_BranchTypes_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BranchTypes_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Image = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DistrictName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Districts_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductBranches",
                columns: table => new
                {
                    ProductBranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBranches", x => x.ProductBranchId);
                    table.ForeignKey(
                        name: "FK_ProductBranches_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductBranches_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    ProductColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ProductColorName = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(maxLength: 50, nullable: false),
                    ProductId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.ProductColorId);
                    table.ForeignKey(
                        name: "FK_ProductColors_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductColors_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ProductImageUrl = table.Column<string>(maxLength: 200, nullable: false),
                    ProductId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImages_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(maxLength: 50, nullable: false),
                    Stock = table.Column<int>(maxLength: 50, nullable: false),
                    ViewCount = table.Column<int>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    DateCreated = table.Column<DateTime>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ProvinceName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK_Provinces_Accounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provinces_Accounts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 3, 8, 58, 486, DateTimeKind.Utc).AddTicks(9577), new DateTime(2020, 10, 20, 3, 8, 58, 487, DateTimeKind.Utc).AddTicks(1118) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 10, 20, 3, 8, 58, 487, DateTimeKind.Utc).AddTicks(2661), new DateTime(2020, 10, 20, 3, 8, 58, 487, DateTimeKind.Utc).AddTicks(2687) });

            migrationBuilder.CreateIndex(
                name: "IX_AccountStatuses_CreatedBy",
                table: "AccountStatuses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AccountStatuses_UpdatedBy",
                table: "AccountStatuses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CreatedBy",
                table: "Branches",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_UpdatedBy",
                table: "Branches",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchTypes_CreatedBy",
                table: "BranchTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchTypes_UpdatedBy",
                table: "BranchTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedBy",
                table: "Categories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedBy",
                table: "Categories",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CreatedBy",
                table: "Districts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_UpdatedBy",
                table: "Districts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBranches_CreatedBy",
                table: "ProductBranches",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBranches_UpdatedBy",
                table: "ProductBranches",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_CreatedBy",
                table: "ProductColors",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_UpdatedBy",
                table: "ProductColors",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_CreatedBy",
                table: "ProductImages",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_UpdatedBy",
                table: "ProductImages",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedBy",
                table: "Products",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdatedBy",
                table: "Products",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CreatedBy",
                table: "Provinces",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_UpdatedBy",
                table: "Provinces",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountStatuses");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "BranchTypes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "ProductBranches");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 9, 28, 15, 39, 8, 996, DateTimeKind.Utc).AddTicks(1021), new DateTime(2020, 9, 28, 15, 39, 8, 996, DateTimeKind.Utc).AddTicks(2179) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 9, 28, 15, 39, 8, 996, DateTimeKind.Utc).AddTicks(3418), new DateTime(2020, 9, 28, 15, 39, 8, 996, DateTimeKind.Utc).AddTicks(3439) });
        }
    }
}
