using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleProject.Migrations
{
    /// <inheritdoc />
    public partial class default_setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceName = table.Column<string>(type: "TEXT", nullable: false),
                    MinCapital = table.Column<long>(type: "INTEGER", nullable: false),
                    MaxCapital = table.Column<long>(type: "INTEGER", nullable: false),
                    Rate = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
