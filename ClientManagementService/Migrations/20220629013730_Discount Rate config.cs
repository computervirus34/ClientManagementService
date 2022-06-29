using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class DiscountRateconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseType = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    SlabFrom = table.Column<int>(unicode: false, nullable: false),
                    SlabTo = table.Column<int>(unicode: false, nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(10,3)", unicode: false, nullable: false),
                    IsActive = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CreatedOn = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountRate", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountRate");
        }
    }
}
