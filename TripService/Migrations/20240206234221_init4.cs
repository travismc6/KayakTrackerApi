using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KayakTracker.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "River",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_River", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RiverId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    Flow = table.Column<double>(type: "double precision", nullable: true),
                    StartName = table.Column<string>(type: "text", nullable: false),
                    StartCoordinates = table.Column<string>(type: "text", nullable: false),
                    EndName = table.Column<string>(type: "text", nullable: true),
                    EndCoordinates = table.Column<string>(type: "text", nullable: true),
                    TimeMinutes = table.Column<double>(type: "double precision", nullable: true),
                    DistanceMiles = table.Column<double>(type: "double precision", nullable: false),
                    MeasuredAt = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    AvgSpeed = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_River_RiverId",
                        column: x => x.RiverId,
                        principalTable: "River",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Highlight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Coordinates = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    TripId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Highlight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Highlight_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripAttendee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TripId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripAttendee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripAttendee_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "River",
                columns: new[] { "Id", "Description", "Name", "State" },
                values: new object[] { 1, "Test River", "Test River", 34 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "AvgSpeed", "DistanceMiles", "EndCoordinates", "EndDate", "EndName", "Flow", "MeasuredAt", "Notes", "OwnerId", "RiverId", "Stage", "StartCoordinates", "StartDate", "StartName", "State", "TimeMinutes" },
                values: new object[] { 1, 6.0, 10.0, null, new DateTime(2024, 2, 6, 23, 42, 20, 959, DateTimeKind.Utc).AddTicks(1319), null, null, null, "notes", "1", 1, null, "37.362,-91.543", new DateTime(2024, 2, 6, 23, 42, 20, 959, DateTimeKind.Utc).AddTicks(1312), "boat ramp", 0, 600.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Highlight_TripId",
                table: "Highlight",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripAttendee_TripId",
                table: "TripAttendee",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RiverId",
                table: "Trips",
                column: "RiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Highlight");

            migrationBuilder.DropTable(
                name: "TripAttendee");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "River");
        }
    }
}
