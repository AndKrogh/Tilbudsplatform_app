using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TilbudsPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbWorklogNotWorkin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worklogs_Users_UserId",
                table: "Worklogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Worklogs_WorkTasks_WorkTaskId",
                table: "Worklogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Projects_ProjectId",
                table: "WorkTasks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WorkTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_UserId",
                table: "WorkTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worklogs_Users_UserId",
                table: "Worklogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worklogs_WorkTasks_WorkTaskId",
                table: "Worklogs",
                column: "WorkTaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_Projects_ProjectId",
                table: "WorkTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_Users_UserId",
                table: "WorkTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worklogs_Users_UserId",
                table: "Worklogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Worklogs_WorkTasks_WorkTaskId",
                table: "Worklogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Projects_ProjectId",
                table: "WorkTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Users_UserId",
                table: "WorkTasks");

            migrationBuilder.DropIndex(
                name: "IX_WorkTasks_UserId",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Worklogs_Users_UserId",
                table: "Worklogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worklogs_WorkTasks_WorkTaskId",
                table: "Worklogs",
                column: "WorkTaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_Projects_ProjectId",
                table: "WorkTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
