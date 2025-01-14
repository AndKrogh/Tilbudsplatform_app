using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TilbudsPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkTaskWithLoggedHoursAndDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoggedDate",
                table: "WorkTasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastLoggedUserName",
                table: "WorkTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalLoggedHours",
                table: "WorkTasks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoggedDate",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "LastLoggedUserName",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "TotalLoggedHours",
                table: "WorkTasks");
        }
    }
}
