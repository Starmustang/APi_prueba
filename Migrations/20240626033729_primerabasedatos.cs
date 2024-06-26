using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APi_prueba.Migrations
{
    /// <inheritdoc />
    public partial class primerabasedatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Peso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Prioridad = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("f83bc361-e443-47f7-89ec-556241277222"), null, "Actividades pendientes", 20 },
                    { new Guid("f83bc361-e443-47f7-89ec-556241277233"), null, "Actividades personales", 69 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("f83bc361-e443-47f7-89ec-556241277234"), new Guid("f83bc361-e443-47f7-89ec-556241277222"), null, new DateTime(2024, 6, 25, 23, 37, 27, 263, DateTimeKind.Local).AddTicks(328), 1, "Pago de servicios publicos" },
                    { new Guid("f83bc361-e443-47f7-89ec-556241277235"), new Guid("f83bc361-e443-47f7-89ec-556241277233"), null, new DateTime(2024, 6, 25, 23, 37, 27, 263, DateTimeKind.Local).AddTicks(349), 0, "Terminar pelicula" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
