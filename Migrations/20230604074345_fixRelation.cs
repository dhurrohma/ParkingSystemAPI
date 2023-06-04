using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingSystemApi.Migrations
{
    public partial class fixRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Vehicles_VehicleId",
                table: "Owners");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Vehicles_VehicleId",
                table: "Owners",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Vehicles_VehicleId",
                table: "Owners");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Vehicles_VehicleId",
                table: "Owners",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
