using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261126025401_AgregarLevantamientosYFotos : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Levantamientos",
            columns: table => new
            {
                LevantamientoId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                SolicitudId = table.Column<int>(type: "int", nullable: false),
                TecnicoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FechaProgramada = table.Column<DateTime>(type: "datetime2", nullable: false),
                HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                HoraFin = table.Column<TimeOnly>(type: "time", nullable: false),
                DisponibilidadEspaciosFisicos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CargasElectricas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                EstabilidadTension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                RecorridoTuberias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                RecorridoCableado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                EsBorrador = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Levantamientos", x => x.LevantamientoId);
                table.ForeignKey(
                    name: "FK_Levantamientos_Solicitudes_SolicitudId",
                    column: x => x.SolicitudId,
                    principalTable: "Solicitudes",
                    principalColumn: "SolicitudId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "FotosLevantamientos",
            columns: table => new
            {
                FotoLevantamientoId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LevantamientoId = table.Column<int>(type: "int", nullable: false),
                NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TipoContenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Contenido = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FotosLevantamientos", x => x.FotoLevantamientoId);
                table.ForeignKey(
                    name: "FK_FotosLevantamientos_Levantamientos_LevantamientoId",
                    column: x => x.LevantamientoId,
                    principalTable: "Levantamientos",
                    principalColumn: "LevantamientoId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_FotosLevantamientos_LevantamientoId",
            table: "FotosLevantamientos",
            column: "LevantamientoId");

        migrationBuilder.CreateIndex(
            name: "IX_Levantamientos_SolicitudId",
            table: "Levantamientos",
            column: "SolicitudId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "FotosLevantamientos");

        migrationBuilder.DropTable(
            name: "Levantamientos");
    }
}
