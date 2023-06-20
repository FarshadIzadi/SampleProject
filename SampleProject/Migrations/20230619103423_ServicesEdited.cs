using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleProject.Migrations
{
    /// <inheritdoc />
    public partial class ServicesEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Services",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                table: "Services",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
