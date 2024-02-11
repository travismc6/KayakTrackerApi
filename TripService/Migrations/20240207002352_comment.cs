using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KayakTracker.Migrations
{
    /// <inheritdoc />
    public partial class comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Text", "TripId", "UserId" },
                values: new object[] { 1, "My test comment about the river", 1, "1" });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 7, 0, 23, 51, 960, DateTimeKind.Utc).AddTicks(8104), new DateTime(2024, 2, 7, 0, 23, 51, 960, DateTimeKind.Utc).AddTicks(8095) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 7, 0, 21, 4, 193, DateTimeKind.Utc).AddTicks(9345), new DateTime(2024, 2, 7, 0, 21, 4, 193, DateTimeKind.Utc).AddTicks(9337) });
        }
    }
}
