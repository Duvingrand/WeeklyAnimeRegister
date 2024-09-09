using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPropio.Migrations
{
    /// <inheritdoc />
    public partial class correcionhistorial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_series_historial_HistorialIdDropeados",
                table: "series");

            migrationBuilder.DropForeignKey(
                name: "FK_series_historial_HistorialIdProximos",
                table: "series");

            migrationBuilder.DropForeignKey(
                name: "FK_series_historial_HistorialIdTerminados",
                table: "series");

            migrationBuilder.DropIndex(
                name: "IX_series_HistorialIdDropeados",
                table: "series");

            migrationBuilder.DropIndex(
                name: "IX_series_HistorialIdProximos",
                table: "series");

            migrationBuilder.DropIndex(
                name: "IX_series_HistorialIdTerminados",
                table: "series");

            migrationBuilder.DropColumn(
                name: "HistorialIdDropeados",
                table: "series");

            migrationBuilder.DropColumn(
                name: "HistorialIdProximos",
                table: "series");

            migrationBuilder.DropColumn(
                name: "HistorialIdTerminados",
                table: "series");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "historial",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "historial");

            migrationBuilder.AddColumn<int>(
                name: "HistorialIdDropeados",
                table: "series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistorialIdProximos",
                table: "series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistorialIdTerminados",
                table: "series",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_series_HistorialIdDropeados",
                table: "series",
                column: "HistorialIdDropeados");

            migrationBuilder.CreateIndex(
                name: "IX_series_HistorialIdProximos",
                table: "series",
                column: "HistorialIdProximos");

            migrationBuilder.CreateIndex(
                name: "IX_series_HistorialIdTerminados",
                table: "series",
                column: "HistorialIdTerminados");

            migrationBuilder.AddForeignKey(
                name: "FK_series_historial_HistorialIdDropeados",
                table: "series",
                column: "HistorialIdDropeados",
                principalTable: "historial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_series_historial_HistorialIdProximos",
                table: "series",
                column: "HistorialIdProximos",
                principalTable: "historial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_series_historial_HistorialIdTerminados",
                table: "series",
                column: "HistorialIdTerminados",
                principalTable: "historial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
