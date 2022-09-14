using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class Sexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorasLaboradas",
                table: "Personas",
                newName: "HorasLaborables");

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId",
                table: "SugerenciasCuidado",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "SignosVitales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "Valor",
                table: "SignosVitales",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_SugerenciasCuidado_HistoriaId",
                table: "SugerenciasCuidado",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SignosVitales_PacienteId",
                table: "SignosVitales",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SignosVitales_Personas_PacienteId",
                table: "SignosVitales",
                column: "PacienteId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SugerenciasCuidado_Historias_HistoriaId",
                table: "SugerenciasCuidado",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignosVitales_Personas_PacienteId",
                table: "SignosVitales");

            migrationBuilder.DropForeignKey(
                name: "FK_SugerenciasCuidado_Historias_HistoriaId",
                table: "SugerenciasCuidado");

            migrationBuilder.DropIndex(
                name: "IX_SugerenciasCuidado_HistoriaId",
                table: "SugerenciasCuidado");

            migrationBuilder.DropIndex(
                name: "IX_SignosVitales_PacienteId",
                table: "SignosVitales");

            migrationBuilder.DropColumn(
                name: "HistoriaId",
                table: "SugerenciasCuidado");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "SignosVitales");

            migrationBuilder.RenameColumn(
                name: "HorasLaborables",
                table: "Personas",
                newName: "HorasLaboradas");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "SignosVitales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
