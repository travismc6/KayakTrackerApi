using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KayakTracker.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 6, 23, 44, 37, 925, DateTimeKind.Utc).AddTicks(4651), new DateTime(2024, 2, 6, 23, 44, 37, 925, DateTimeKind.Utc).AddTicks(4643) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 6, 23, 42, 20, 959, DateTimeKind.Utc).AddTicks(1319), new DateTime(2024, 2, 6, 23, 42, 20, 959, DateTimeKind.Utc).AddTicks(1312) });
        }
    }
}
