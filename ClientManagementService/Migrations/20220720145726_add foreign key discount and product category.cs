using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class addforeignkeydiscountandproductcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DiscountRate_ProductCategoryId",
                table: "DiscountRate",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountRate_ProductCategory_ProductCategoryId",
                table: "DiscountRate",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountRate_ProductCategory_ProductCategoryId",
                table: "DiscountRate");

            migrationBuilder.DropIndex(
                name: "IX_DiscountRate_ProductCategoryId",
                table: "DiscountRate");
        }
    }
}
