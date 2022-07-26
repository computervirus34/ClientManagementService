using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class schedulesandproductadditionalinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(unicode: false, nullable: false),
                    Datetime = table.Column<DateTime>(unicode: false, nullable: false),
                    CourseContent = table.Column<string>(maxLength: 2000, nullable: true),
                    Venue = table.Column<string>(maxLength: 200, nullable: true),
                    Mode = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<string>(unicode: false, nullable: true),
                    IsActive = table.Column<bool>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAdditionalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(unicode: false, nullable: false),
                    ProductId = table.Column<int>(unicode: false, nullable: false),
                    Admin = table.Column<bool>(unicode: false, nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LicenseType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ProtectionType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NumberOfPlaces = table.Column<int>(unicode: false, nullable: false),
                    IsSmallBusiness = table.Column<bool>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAdditionalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAdditionalInfo_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAdditionalInfo_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_ProductId",
                table: "CourseSchedule",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdditionalInfo_OrderId",
                table: "ProductAdditionalInfo",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdditionalInfo_ProductId",
                table: "ProductAdditionalInfo",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSchedule");

            migrationBuilder.DropTable(
                name: "ProductAdditionalInfo");
        }
    }
}
