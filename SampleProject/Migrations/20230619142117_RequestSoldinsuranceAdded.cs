using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleProject.Migrations
{
    /// <inheritdoc />
    public partial class RequestSoldinsuranceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestTitle = table.Column<string>(type: "TEXT", nullable: false),
                    CapitalSum = table.Column<decimal>(type: "TEXT", nullable: false),
                    BillTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldInsurances_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldInsurances_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoldInsurances_RequestId",
                table: "SoldInsurances",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldInsurances_ServiceId",
                table: "SoldInsurances",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoldInsurances");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
