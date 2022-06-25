using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class SurchargeandMaintenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemWeight",
                table: "OrderItem",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualDiscount",
                table: "Order",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetworkSurcharge",
                table: "Order",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SoftwareMaintenance",
                table: "Order",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "ItemWeight",
                table: "OfferItem",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualDiscount",
                table: "Offer",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetworkSurcharge",
                table: "Offer",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SoftwareMaintenance",
                table: "Offer",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManualDiscount",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "NetworkSurcharge",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SoftwareMaintenance",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ManualDiscount",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "NetworkSurcharge",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "SoftwareMaintenance",
                table: "Offer");

            migrationBuilder.AlterColumn<string>(
                name: "ItemWeight",
                table: "OrderItem",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemWeight",
                table: "OfferItem",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
