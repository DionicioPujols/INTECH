using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261126215602_EliminarHerramientasOrdenesTrabajo : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Herramientas",
            table: "OrdenesTrabajo");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Herramientas",
            table: "OrdenesTrabajo",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }
}
