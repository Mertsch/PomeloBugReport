using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomeloPrimaryKeyBug.Migrations
{
    public partial class InititalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    tasks_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.tasks_id);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    workers_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.workers_id);
                });

            migrationBuilder.CreateTable(
                name: "tasks_workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrekkTemplateId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks_workers", x => x.Id);
                    table.ForeignKey(
                        name: "TemplateContainsTemplateWorkers",
                        column: x => x.TrekkTemplateId,
                        principalTable: "tasks",
                        principalColumn: "tasks_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "WorkerContainsTemplateWorkers",
                        column: x => x.WorkerId,
                        principalTable: "workers",
                        principalColumn: "workers_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_workers_TrekkTemplateId",
                table: "tasks_workers",
                column: "TrekkTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_workers_WorkerId",
                table: "tasks_workers",
                column: "WorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks_workers");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "workers");
        }
    }
}
