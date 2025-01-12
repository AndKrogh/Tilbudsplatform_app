using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TilbudsPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorklogAndWorkTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Worklogs_Projects_ProjectId",
                table: "Worklogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Worklogs");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "WorkTasks");

            migrationBuilder.RenameColumn(
                name: "LoggedDate",
                table: "Worklogs",
                newName: "DateWorked");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "WorkTasks",
                newName: "IX_WorkTasks_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Worklogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WorkTaskId",
                table: "Worklogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTasks",
                table: "WorkTasks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Worklogs_WorkTaskId",
                table: "Worklogs",
                column: "WorkTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worklogs_Projects_ProjectId",
                table: "Worklogs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worklogs_Projects_ProjectId",
                table: "Worklogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Worklogs_WorkTasks_WorkTaskId",
                table: "Worklogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Projects_ProjectId",
                table: "WorkTasks");

            migrationBuilder.DropIndex(
                name: "IX_Worklogs_WorkTaskId",
                table: "Worklogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTasks",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "WorkTaskId",
                table: "Worklogs");

            migrationBuilder.RenameTable(
                name: "WorkTasks",
                newName: "Tasks");

            migrationBuilder.RenameColumn(
                name: "DateWorked",
                table: "Worklogs",
                newName: "LoggedDate");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTasks_ProjectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Worklogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Worklogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worklogs_Projects_ProjectId",
                table: "Worklogs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
