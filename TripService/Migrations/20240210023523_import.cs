using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KayakTracker.Migrations
{
    /// <inheritdoc />
    public partial class import : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_River_RiverId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_River",
                table: "River");

            migrationBuilder.RenameTable(
                name: "River",
                newName: "Rivers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rivers",
                table: "Rivers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 10, 2, 35, 23, 343, DateTimeKind.Utc).AddTicks(9746), new DateTime(2024, 2, 10, 2, 35, 23, 343, DateTimeKind.Utc).AddTicks(9738) });

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Rivers_RiverId",
                table: "Trips",
                column: "RiverId",
                principalTable: "Rivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Rivers_RiverId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rivers",
                table: "Rivers");

            migrationBuilder.RenameTable(
                name: "Rivers",
                newName: "River");

            migrationBuilder.AddPrimaryKey(
                name: "PK_River",
                table: "River",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 7, 0, 23, 51, 960, DateTimeKind.Utc).AddTicks(8104), new DateTime(2024, 2, 7, 0, 23, 51, 960, DateTimeKind.Utc).AddTicks(8095) });

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_River_RiverId",
                table: "Trips",
                column: "RiverId",
                principalTable: "River",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
