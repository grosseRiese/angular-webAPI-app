using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListTask.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDoCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDos_ToDoCategories_ToDoCategoryId",
                        column: x => x.ToDoCategoryId,
                        principalTable: "ToDoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ToDoCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Important" });

            migrationBuilder.InsertData(
                table: "ToDoCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Completed" });

            migrationBuilder.InsertData(
                table: "ToDoCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ToDoCategoryId",
                table: "ToDos",
                column: "ToDoCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "ToDoCategories");
        }
    }
}
