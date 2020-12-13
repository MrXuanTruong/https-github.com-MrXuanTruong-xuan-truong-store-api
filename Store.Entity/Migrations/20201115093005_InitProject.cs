using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class InitProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStatuses",
                columns: table => new
                {
                    AccountStatusId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    AccountStatusName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatuses", x => x.AccountStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    AccountTypeName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
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
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    BranchTypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTypes", x => x.BranchTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ColorName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "ExportStock",
                columns: table => new
                {
                    ExportStockId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    FromBranchId = table.Column<long>(nullable: false),
                    ToBranchId = table.Column<long>(nullable: false),
                    ColorId = table.Column<long>(nullable: false),
                    Quantity = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportStock", x => x.ExportStockId);
                });

            migrationBuilder.CreateTable(
                name: "ImportStock",
                columns: table => new
                {
                    ImportStockId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    BranchId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportStock", x => x.ImportStockId);
                });

            migrationBuilder.CreateTable(
                name: "ImportStockDetail",
                columns: table => new
                {
                    ImportStockDetailId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ImportStockId = table.Column<long>(nullable: false),
                    ColorId = table.Column<long>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportStockDetail", x => x.ImportStockDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    ProductBrandId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProductBrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.ProductBrandId);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    ProductStatusId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProductStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.ProductStatusId);
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
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProvinceName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 100, nullable: true),
                    ThumnailUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: true),
                    ProductBrandId = table.Column<long>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Stock = table.Column<int>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    ProductStatusId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    ExportStockId = table.Column<long>(nullable: true),
                    ImportStockId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ExportStock_ExportStockId",
                        column: x => x.ExportStockId,
                        principalTable: "ExportStock",
                        principalColumn: "ExportStockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ImportStock_ImportStockId",
                        column: x => x.ImportStockId,
                        principalTable: "ImportStock",
                        principalColumn: "ImportStockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "ProductBrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductStatuses_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "ProductStatuses",
                        principalColumn: "ProductStatusId",
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
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    DistrictName = table.Column<string>(maxLength: 50, nullable: true),
                    ProvinceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    ProductColorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    ColorId = table.Column<long>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.ProductColorId);
                    table.ForeignKey(
                        name: "FK_ProductColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    ProductImageUrl = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
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
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(maxLength: 50, nullable: true),
                    ProvinceId = table.Column<long>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    BranchTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_BranchTypes_BranchTypeId",
                        column: x => x.BranchTypeId,
                        principalTable: "BranchTypes",
                        principalColumn: "BranchTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    AccountStatusId = table.Column<long>(nullable: true),
                    AccountTypeId = table.Column<long>(nullable: true),
                    BranchId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountStatuses_AccountStatusId",
                        column: x => x.AccountStatusId,
                        principalTable: "AccountStatuses",
                        principalColumn: "AccountStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductBranches",
                columns: table => new
                {
                    ProductBranchId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    LocalStock = table.Column<int>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    BranchId = table.Column<long>(nullable: false),
                    ColorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBranches", x => x.ProductBranchId);
                    table.ForeignKey(
                        name: "FK_ProductBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBranches_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductBranches_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountStatuses",
                columns: new[] { "AccountStatusId", "AccountStatusName", "CreatedBy", "CreatedByName", "CreatedDate", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "Đang hoạt động", null, null, null, null, null, null },
                    { 2L, "Đã nghỉ", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "AccountTypeId", "AccountTypeName", "CreatedBy", "CreatedByName", "CreatedDate", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "Supervisor", null, null, null, null, null, null },
                    { 2L, "Saler", null, null, null, null, null, null },
                    { 3L, "Customer", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Address", "BranchName", "BranchTypeId", "CreatedBy", "CreatedByName", "CreatedDate", "DistrictId", "ProvinceId", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, "Hồ Chí Minh", null, null, null, null, null, null, null, null, null },
                    { 2L, null, "Hà Nội", null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CreatedBy", "CreatedByName", "CreatedDate", "Description", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 3L, "Xe côn tay", null, null, null, null, null, null, null },
                    { 2L, "Xe tay ga", null, null, null, null, null, null, null },
                    { 1L, "Xe số", null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorName", "CreatedBy", "CreatedByName", "CreatedDate", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "Trắng", null, null, null, null, null, null },
                    { 2L, "Đen", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "ProductBrandId", "CreatedBy", "CreatedByName", "CreatedDate", "ProductBrandName", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, null, null, "Honda", null, null, null },
                    { 2L, null, null, null, "Yamaha", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductStatuses",
                columns: new[] { "ProductStatusId", "CreatedBy", "CreatedByName", "CreatedDate", "ProductStatusName", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, null, null, "Sẵn sàng giao dịch", null, null, null },
                    { 2L, null, null, null, "Chưa thể giao dịch", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "CreatedBy", "CreatedByName", "CreatedDate", "ProvinceName", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[] { 1L, null, null, null, "Hồ Chí Minh", null, null, null });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountStatusId", "AccountTypeId", "Address", "BranchId", "CreatedBy", "CreatedByName", "CreatedDate", "DateOfBirth", "Email", "FullName", "Password", "Phone", "UpdatedBy", "UpdatedByName", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, "9 District", 1L, null, null, new DateTime(2020, 11, 15, 9, 30, 4, 787, DateTimeKind.Utc).AddTicks(7530), new DateTime(1998, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "xuantruongmu98@gmail.com", "Admin", "e10adc3949ba59abbe56e057f20f883e", "0345286525", null, null, new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(2732), "admin" },
                    { 3L, 1L, 3L, "Binh Thanh District", 1L, null, null, new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(4248), new DateTime(1995, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvana@gmail.com", "Nguyễn Văn A", "e10adc3949ba59abbe56e057f20f883e", "0345286525", null, null, new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(4251), "customer" },
                    { 2L, 2L, 2L, "9 District", 2L, null, null, new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(4142), new DateTime(1998, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "xuantruongmu98@gmail.com", "xuantruong", "e10adc3949ba59abbe56e057f20f883e", "0345286525", null, null, new DateTime(2020, 11, 15, 9, 30, 4, 788, DateTimeKind.Utc).AddTicks(4224), "truongit" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "DistrictId", "CreatedBy", "CreatedByName", "CreatedDate", "DistrictName", "ProvinceId", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[] { 1L, null, null, null, "Quận 1", 1L, null, null, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedBy", "CreatedByName", "CreatedDate", "Description", "ExportStockId", "ImportStockId", "Price", "ProductBrandId", "ProductName", "ProductStatusId", "Stock", "ThumnailUrl", "UpdatedBy", "UpdatedByName", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { 1L, 1L, null, null, new DateTime(2020, 11, 15, 9, 30, 4, 790, DateTimeKind.Utc).AddTicks(1914), "Mẫu xe số hiện đại bán chạy nhất tháng", null, null, 1000m, 1L, "Winner", 1L, 100, null, null, null, null, 50 },
                    { 2L, 2L, null, null, new DateTime(2020, 11, 15, 9, 30, 4, 790, DateTimeKind.Utc).AddTicks(2638), "Specification:OK", null, null, 1500m, 2L, "Air Blade 2020", 1L, 80, null, null, null, null, 50 }
                });

            migrationBuilder.InsertData(
                table: "ProductBranches",
                columns: new[] { "ProductBranchId", "BranchId", "ColorId", "CreatedBy", "CreatedByName", "CreatedDate", "LocalStock", "ProductId", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1L, null, null, null, null, 50, 1L, null, null, null },
                    { 2L, 2L, null, null, null, null, 40, 1L, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "ProductColorId", "ColorId", "CreatedBy", "CreatedByName", "CreatedDate", "Price", "ProductId", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1L, null, null, null, 1000.0, 1L, null, null, null },
                    { 2L, 2L, null, null, null, 1200.0, 1L, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "CreatedBy", "CreatedByName", "CreatedDate", "ProductId", "ProductImageUrl", "UpdatedBy", "UpdatedByName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, null, null, 1L, "/images/product/hondawaversx.jpg", null, null, null },
                    { 2L, null, null, null, 1L, "/images/product/hondawaversx.jpg", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountStatusId",
                table: "Accounts",
                column: "AccountStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BranchId",
                table: "Accounts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username",
                table: "Accounts",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchTypeId",
                table: "Branches",
                column: "BranchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DistrictId",
                table: "Branches",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ProvinceId",
                table: "Branches",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBranches_BranchId",
                table: "ProductBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBranches_ColorId",
                table: "ProductBranches",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBranches_ProductId",
                table: "ProductBranches",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ColorId",
                table: "ProductColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductId",
                table: "ProductColors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ExportStockId",
                table: "Products",
                column: "ExportStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImportStockId",
                table: "Products",
                column: "ImportStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStatusId",
                table: "Products",
                column: "ProductStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ImportStockDetail");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductBranches");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "AccountStatuses");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "BranchTypes");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ExportStock");

            migrationBuilder.DropTable(
                name: "ImportStock");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductStatuses");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
