using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261126221401_AgregarHistorialYDetalle : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Historiales",
            columns: table => new
            {
                HistorialId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                SolicitudId = table.Column<int>(type: "int", nullable: false),
                TecnicoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Historiales", x => x.HistorialId);
                table.ForeignKey(
                    name: "FK_Historiales_Solicitudes_SolicitudId",
                    column: x => x.SolicitudId,
                    principalTable: "Solicitudes",
                    principalColumn: "SolicitudId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "HistorialesDetalle",
            columns: table => new
            {
                DetalleId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                HistorialId = table.Column<int>(type: "int", nullable: false),
                Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_HistorialesDetalle", x => x.DetalleId);
                table.ForeignKey(
                    name: "FK_HistorialesDetalle_Historiales_HistorialId",
                    column: x => x.HistorialId,
                    principalTable: "Historiales",
                    principalColumn: "HistorialId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Historiales_SolicitudId",
            table: "Historiales",
            column: "SolicitudId");

        migrationBuilder.CreateIndex(
            name: "IX_HistorialesDetalle_HistorialId",
            table: "HistorialesDetalle",
            column: "HistorialId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "HistorialesDetalle");

        migrationBuilder.DropTable(
            name: "Historiales");
    }
}
