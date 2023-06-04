using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingSystemApi.Migrations
{
    public partial class fixRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingHistories_Vehicles_VehicleId",
                table: "ParkingHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingHistories_Vehicles_VehicleId",
                table: "ParkingHistories",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingHistories_Vehicles_VehicleId",
                table: "ParkingHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingHistories_Vehicles_VehicleId",
                table: "ParkingHistories",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
