using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261124072507_AgregarEstadosSolicitudes : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 2,
            column: "Nombre",
            value: "En proceso");

        migrationBuilder.UpdateData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 3,
            column: "Nombre",
            value: "En Espera Administración");

        migrationBuilder.InsertData(
            table: "EstadosSolicitudes",
            columns: new[] { "EstadoSolicitudId", "Nombre" },
            values: new object[,]
            {
                { 4, "En revisión" },
                { 5, "Enviada al cliente" },
                { 6, "Aprobada" },
                { 7, "Rechazada" },
                { 8, "Pendiente de cobro" },
                { 9, "Finalizada" },
                { 10, "Cancelada" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 10);

        migrationBuilder.UpdateData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 2,
            column: "Nombre",
            value: "Finalizada");

        migrationBuilder.UpdateData(
            table: "EstadosSolicitudes",
            keyColumn: "EstadoSolicitudId",
            keyValue: 3,
            column: "Nombre",
            value: "Cancelada");
    }
}
