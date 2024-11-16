using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbFirst.Migrations
{
    /// <inheritdoc />
    public partial class test_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mileage2",
                table: "Car",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mileage2",
                table: "Car");
        }
    }
}
