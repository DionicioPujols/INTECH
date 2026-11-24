using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261123193658_AgregarSolicitudesYEstados : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "EstadosSolicitudes",
            columns: table => new
            {
                EstadoSolicitudId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EstadosSolicitudes", x => x.EstadoSolicitudId);
            });

        migrationBuilder.CreateTable(
            name: "Solicitudes",
            columns: table => new
            {
                SolicitudId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                Contacto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                EstadoSolicitudId = table.Column<int>(type: "int", nullable: false),
                FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                TecnicoAsignado = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Solicitudes", x => x.SolicitudId);
                table.ForeignKey(
                    name: "FK_Solicitudes_EstadosSolicitudes_EstadoSolicitudId",
                    column: x => x.EstadoSolicitudId,
                    principalTable: "EstadosSolicitudes",
                    principalColumn: "EstadoSolicitudId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "EstadosSolicitudes",
            columns: new[] { "EstadoSolicitudId", "Nombre" },
            values: new object[,]
            {
                { 1, "Pendiente" },
                { 2, "Finalizada" },
                { 3, "Cancelada" }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Solicitudes_EstadoSolicitudId",
            table: "Solicitudes",
            column: "EstadoSolicitudId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Solicitudes");

        migrationBuilder.DropTable(
            name: "EstadosSolicitudes");
    }
}
