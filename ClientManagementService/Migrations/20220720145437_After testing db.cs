using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class Aftertestingdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "BranchStaff");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Branch");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "ProductPrice",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DiscountType",
                table: "ProductPrice",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LicenseType",
                table: "Product",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPurchased",
                table: "OfferItem",
                unicode: false,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualDiscount",
                table: "OfferItem",
                type: "decimal(10,3)",
                unicode: false,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Offer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "DiscountRate",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "DiscountRate",
                unicode: false,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "DiscountRate",
                unicode: false,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BranchStaff",
                unicode: false,
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldUnicode: false,
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Deaprtment",
                table: "BranchStaff",
                unicode: false,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "BranchStaff",
                unicode: false,
                maxLength: 200,
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "ProductPrice");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "ProductPrice");

            migrationBuilder.DropColumn(
                name: "IsPurchased",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "ManualDiscount",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "DiscountRate");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "DiscountRate");

            migrationBuilder.DropColumn(
                name: "Deaprtment",
                table: "BranchStaff");

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "BranchStaff");

            migrationBuilder.AlterColumn<string>(
                name: "LicenseType",
                table: "Product",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "Product",
                type: "int",
                unicode: false,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Order",
                type: "int",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Offer",
                type: "int",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "DiscountRate",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BranchStaff",
                type: "varchar(70)",
                unicode: false,
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 70);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "BranchStaff",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Branch",
                type: "varchar(70)",
                unicode: false,
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Branch",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);
        }
    }
}
