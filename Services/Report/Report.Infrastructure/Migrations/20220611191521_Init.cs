using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Report.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    RequestedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationReportResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    LocationReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    PersonCount = table.Column<long>(type: "bigint", nullable: false),
                    PhoneNumberCount = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationReportResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationReportResult_LocationReport_LocationReportId",
                        column: x => x.LocationReportId,
                        principalTable: "LocationReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationReport_Id",
                table: "LocationReport",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationReportResult_Id",
                table: "LocationReportResult",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationReportResult_LocationReportId",
                table: "LocationReportResult",
                column: "LocationReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationReportResult");

            migrationBuilder.DropTable(
                name: "LocationReport");
        }
    }
}
