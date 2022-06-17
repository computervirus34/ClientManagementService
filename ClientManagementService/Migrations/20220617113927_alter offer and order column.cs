using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class alterofferandordercolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Order",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalOrderTotal",
                table: "Order",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Offer",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalOfferTotal",
                table: "Offer",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OriginalOrderTotal",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "OriginalOfferTotal",
                table: "Offer");
        }
    }
}
