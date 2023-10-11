using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpedIT_Data.Migrations
{
    /// <inheritdoc />
    public partial class postgresqlcontainer_migration_525 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "minimalSalary",
                table: "Positions",
                newName: "MinimalSalary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinimalSalary",
                table: "Positions",
                newName: "minimalSalary");
        }
    }
}
