using Microsoft.EntityFrameworkCore.Migrations;

namespace COP3855_Project.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: false),
                    ExteriorColor = table.Column<string>(nullable: true),
                    InteriorColor = table.Column<string>(nullable: true),
                    Wheels = table.Column<string>(nullable: true),
                    EnhancedAutopilot = table.Column<bool>(nullable: false),
                    FullSelfDriving = table.Column<bool>(nullable: false),
                    AccWallConnect = table.Column<string>(nullable: true),
                    AccMobileConnect = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    SPerformancePackage = table.Column<bool>(nullable: true),
                    XPerformancePackage = table.Column<bool>(nullable: true),
                    Seating = table.Column<int>(nullable: true),
                    YPerformancePackage = table.Column<bool>(nullable: true),
                    TowHitch = table.Column<bool>(nullable: true),
                    ModelY_Seating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
