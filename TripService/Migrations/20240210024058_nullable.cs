using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KayakTracker.Migrations
{
    /// <inheritdoc />
    public partial class nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rivers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 10, 2, 40, 58, 537, DateTimeKind.Utc).AddTicks(6374), new DateTime(2024, 2, 10, 2, 40, 58, 537, DateTimeKind.Utc).AddTicks(6363) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rivers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 10, 2, 35, 23, 343, DateTimeKind.Utc).AddTicks(9746), new DateTime(2024, 2, 10, 2, 35, 23, 343, DateTimeKind.Utc).AddTicks(9738) });
        }
    }
}
