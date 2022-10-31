using Microsoft.EntityFrameworkCore.Migrations;

namespace COP3855_Project.Migrations
{
    public partial class Surface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ThreePerformancePackage",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThreePerformancePackagePrice",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SPerformancePackagePrice",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SeatingPrice",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "XPerformancePackagePrice",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ModelY_SeatingPrice",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TowHitchPrice",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YPerformancePackagePrice",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AcMobileConnectPrice",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AccWallConnectPrice",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DestinationFee",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EnhancedAutopilotPrice",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExteriorPrice",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FullSelfDrivingPrice",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InteriorPrice",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WheelsPrice",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreePerformancePackage",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ThreePerformancePackagePrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "SPerformancePackagePrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "SeatingPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "XPerformancePackagePrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ModelY_SeatingPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TowHitchPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "YPerformancePackagePrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AcMobileConnectPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AccWallConnectPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DestinationFee",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EnhancedAutopilotPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ExteriorPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FullSelfDrivingPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "InteriorPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "WheelsPrice",
                table: "Vehicles");
        }
    }
}
