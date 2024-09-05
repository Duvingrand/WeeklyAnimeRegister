using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPropio.Migrations
{
    /// <inheritdoc />
    public partial class CreacionHistorial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistorialId",
                table: "series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistorialId1",
                table: "series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistorialId2",
                table: "series",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "historial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_series_HistorialId",
                table: "series",
                column: "HistorialId");

            migrationBuilder.CreateIndex(
                name: "IX_series_HistorialId1",
                table: "series",
                column: "HistorialId1");

            migrationBuilder.CreateIndex(
                name: "IX_series_HistorialId2",
                table: "series",
                column: "HistorialId2");

            migrationBuilder.AddForeignKey(
                name: "FK_series_historial_HistorialId",
                table: "series",
                column: "HistorialId",
                principalTable: "historial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_series_historial_HistorialId1",
                table: "series",
                column: "HistorialId1",
                principalTable: "historial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_series_historial_HistorialId2",
                table: "series",
                column: "HistorialId2",
                principalTable: "historial",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_series_historial_HistorialId",
                table: "series");

            migrationBuilder.DropForeignKey(
                name: "FK_series_historial_HistorialId1",
                table: "series");

            migrationBuilder.DropForeignKey(
                name: "FK_series_historial_HistorialId2",
                table: "series");

            migrationBuilder.DropTable(
                name: "historial");

            migrationBuilder.DropIndex(
                name: "IX_series_HistorialId",
                table: "series");

            migrationBuilder.DropIndex(
                name: "IX_series_HistorialId1",
                table: "series");

            migrationBuilder.DropIndex(
                name: "IX_series_HistorialId2",
                table: "series");

            migrationBuilder.DropColumn(
                name: "HistorialId",
                table: "series");

            migrationBuilder.DropColumn(
                name: "HistorialId1",
                table: "series");

            migrationBuilder.DropColumn(
                name: "HistorialId2",
                table: "series");
        }
    }
}
