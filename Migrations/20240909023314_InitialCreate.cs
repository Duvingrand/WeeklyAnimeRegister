using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPropio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_series_historial_HistorialId1",
                table: "series");

            migrationBuilder.DropForeignKey(
                name: "FK_series_historial_HistorialId2",
                table: "series");

            migrationBuilder.RenameColumn(
                name: "HistorialId2",
                table: "series",
                newName: "HistorialIdTerminados");

            migrationBuilder.RenameColumn(
                name: "HistorialId1",
                table: "series",
                newName: "HistorialIdProximos");

            migrationBuilder.RenameIndex(
                name: "IX_series_HistorialId2",
                table: "series",
                newName: "IX_series_HistorialIdTerminados");

            migrationBuilder.RenameIndex(
                name: "IX_series_HistorialId1",
                table: "series",
                newName: "IX_series_HistorialIdProximos");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "series",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "HistorialIdDropeados",
                table: "series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListType",
                table: "series",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_series_HistorialIdDropeados",
                table: "series",
                column: "HistorialIdDropeados");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "HistorialIdDropeados",
                table: "series");

            migrationBuilder.DropColumn(
                name: "ListType",
                table: "series");

            migrationBuilder.RenameColumn(
                name: "HistorialIdTerminados",
                table: "series",
                newName: "HistorialId2");

            migrationBuilder.RenameColumn(
                name: "HistorialIdProximos",
                table: "series",
                newName: "HistorialId1");

            migrationBuilder.RenameIndex(
                name: "IX_series_HistorialIdTerminados",
                table: "series",
                newName: "IX_series_HistorialId2");

            migrationBuilder.RenameIndex(
                name: "IX_series_HistorialIdProximos",
                table: "series",
                newName: "IX_series_HistorialId1");

            migrationBuilder.UpdateData(
                table: "series",
                keyColumn: "ImagePath",
                keyValue: null,
                column: "ImagePath",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "series",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
