using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagementService.Migrations
{
    public partial class InitalMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ManagerName = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Contact = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Location = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    Symbol = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchStaff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    UserId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Contact = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    Location = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    BranchId = table.Column<int>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchStaff_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    ContactPerson = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Contact = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    Location = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    BranchId = table.Column<int>(unicode: false, nullable: false),
                    CurrencyId = table.Column<int>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchStaff_BranchId",
                table: "BranchStaff",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_BranchId",
                table: "Client",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CurrencyId",
                table: "Client",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchStaff");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
