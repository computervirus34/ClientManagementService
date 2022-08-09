using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class DepartmentSpellingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deaprtment",
                table: "BranchStaff");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "BranchStaff",
                unicode: false,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "BranchStaff");

            migrationBuilder.AddColumn<int>(
                name: "Deaprtment",
                table: "BranchStaff",
                type: "int",
                unicode: false,
                nullable: false,
                defaultValue: 0);
        }
    }
}
