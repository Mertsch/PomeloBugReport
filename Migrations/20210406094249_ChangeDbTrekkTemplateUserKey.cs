using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomeloPrimaryKeyBug.Migrations
{
    public partial class ChangeDbTrekkTemplateUserKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks_workers",
                table: "tasks_workers");

            migrationBuilder.DropIndex(
                name: "IX_tasks_workers_TrekkTemplateId",
                table: "tasks_workers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tasks_workers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks_workers",
                table: "tasks_workers",
                columns: new[] { "TrekkTemplateId", "WorkerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks_workers",
                table: "tasks_workers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tasks_workers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks_workers",
                table: "tasks_workers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_workers_TrekkTemplateId",
                table: "tasks_workers",
                column: "TrekkTemplateId");
        }
    }
}
