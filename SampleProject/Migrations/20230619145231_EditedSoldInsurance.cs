using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleProject.Migrations
{
    /// <inheritdoc />
    public partial class EditedSoldInsurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Capital",
                table: "SoldInsurances",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "SoldInsurances",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capital",
                table: "SoldInsurances");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "SoldInsurances");
        }
    }
}
