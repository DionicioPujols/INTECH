using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261123232555_AgregarClienteYTipoServicioSolicitudes : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "NombreCliente",
            table: "Solicitudes",
            type: "nvarchar(150)",
            maxLength: 150,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "TipoServicio",
            table: "Solicitudes",
            type: "nvarchar(150)",
            maxLength: 150,
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "NombreCliente",
            table: "Solicitudes");

        migrationBuilder.DropColumn(
            name: "TipoServicio",
            table: "Solicitudes");
    }
}
