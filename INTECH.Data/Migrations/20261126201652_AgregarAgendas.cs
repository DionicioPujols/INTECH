using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261126201652_AgregarAgendas : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Agendas",
            columns: table => new
            {
                AgendaId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                SolicitudId = table.Column<int>(type: "int", nullable: false),
                TecnicoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                HoraFin = table.Column<TimeOnly>(type: "time", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Agendas", x => x.AgendaId);
                table.ForeignKey(
                    name: "FK_Agendas_Solicitudes_SolicitudId",
                    column: x => x.SolicitudId,
                    principalTable: "Solicitudes",
                    principalColumn: "SolicitudId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Agendas_SolicitudId",
            table: "Agendas",
            column: "SolicitudId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Agendas");
    }
}
