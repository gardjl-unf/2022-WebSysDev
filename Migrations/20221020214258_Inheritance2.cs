using Microsoft.EntityFrameworkCore.Migrations;

namespace COP3855_Project.Migrations
{
    public partial class Inheritance2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tires",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tires",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vehicles");
        }
    }
}
