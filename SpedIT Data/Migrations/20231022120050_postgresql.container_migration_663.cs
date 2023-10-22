using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpedIT_Data.Migrations
{
    /// <inheritdoc />
    public partial class postgresqlcontainer_migration_663 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_VehicleId1",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_VehicleId1",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId1",
                table: "Packages",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_VehicleId1",
                table: "Packages",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_VehicleId1",
                table: "Packages",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
