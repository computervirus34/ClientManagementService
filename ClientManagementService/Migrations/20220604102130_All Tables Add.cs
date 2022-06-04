using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class AllTablesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currency",
                unicode: false,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldUnicode: false,
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Client",
                unicode: false,
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BranchStaff",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "BranchStaff",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "BranchStaff",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "BranchStaff",
                unicode: false,
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BranchName",
                table: "Branch",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(unicode: false, maxLength: 3, nullable: false),
                    BranchId = table.Column<int>(unicode: false, maxLength: 20, nullable: false),
                    OfferDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CustomerCurrency = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    OfferTotal = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    OfferTax = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    OfferDiscount = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFromOffer = table.Column<bool>(unicode: false, nullable: false),
                    OfferId = table.Column<int>(unicode: false, nullable: false),
                    ClientID = table.Column<int>(unicode: false, maxLength: 3, nullable: false),
                    BranchId = table.Column<int>(unicode: false, maxLength: 20, nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CustomerCurrency = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    OrderTax = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    OrderDiscount = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ProductCategoryId = table.Column<int>(unicode: false, nullable: false),
                    Type = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Descripion = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    AvailableQuantity = table.Column<int>(unicode: false, nullable: false),
                    Duration = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    IsLicenseProduct = table.Column<bool>(nullable: false),
                    LicenseType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ProtectionType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Comment = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(unicode: false, nullable: false),
                    ProductId = table.Column<int>(unicode: false, nullable: false),
                    Quantity = table.Column<int>(unicode: false, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    IsTaxApplied = table.Column<bool>(unicode: false, maxLength: 20, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    IsDiscountApplied = table.Column<bool>(unicode: false, maxLength: 20, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    OriginalProductCost = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    ItemWeight = table.Column<string>(unicode: false, nullable: true),
                    Comment = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferItem_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(unicode: false, nullable: false),
                    ProductId = table.Column<int>(unicode: false, nullable: false),
                    Quantity = table.Column<int>(unicode: false, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    IsTaxApplied = table.Column<bool>(unicode: false, maxLength: 20, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    IsDiscountApplied = table.Column<bool>(unicode: false, maxLength: 20, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    OriginalProductCost = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    ItemWeight = table.Column<string>(unicode: false, nullable: true),
                    Comment = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(unicode: false, nullable: false),
                    CurrencyId = table.Column<int>(unicode: false, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    GSTApplicable = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(unicode: false, maxLength: 3, nullable: false),
                    ActivationDate = table.Column<DateTime>(unicode: false, nullable: false),
                    StopDate = table.Column<DateTime>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_OfferId",
                table: "OfferItem",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_ProductId",
                table: "OfferItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_CurrencyId",
                table: "ProductPrice",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductId",
                table: "ProductPrice",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferItem");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currency",
                type: "varchar(3)",
                unicode: false,
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Client",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BranchStaff",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "BranchStaff",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "BranchStaff",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "BranchStaff",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "BranchName",
                table: "Branch",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 200);
        }
    }
}
