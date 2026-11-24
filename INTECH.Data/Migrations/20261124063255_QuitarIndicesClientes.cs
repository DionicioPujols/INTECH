using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261124063255_QuitarIndicesClientes : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_TelefonosClientes_ClienteId_EsPrincipal",
            table: "TelefonosClientes");

        migrationBuilder.DropIndex(
            name: "IX_Clientes_RncCedula",
            table: "Clientes");

        migrationBuilder.CreateIndex(
            name: "IX_TelefonosClientes_ClienteId",
            table: "TelefonosClientes",
            column: "ClienteId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_TelefonosClientes_ClienteId",
            table: "TelefonosClientes");

        migrationBuilder.CreateIndex(
            name: "IX_TelefonosClientes_ClienteId_EsPrincipal",
            table: "TelefonosClientes",
            columns: new[] { "ClienteId", "EsPrincipal" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Clientes_RncCedula",
            table: "Clientes",
            column: "RncCedula",
            unique: true);
    }
}
