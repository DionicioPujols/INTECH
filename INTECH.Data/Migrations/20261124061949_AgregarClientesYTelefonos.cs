using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261124061949_AgregarClientesYTelefonos : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "ClienteId",
            table: "Solicitudes",
            type: "int",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "Clientes",
            columns: table => new
            {
                ClienteId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                RncCedula = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Clientes", x => x.ClienteId);
            });

        migrationBuilder.CreateTable(
            name: "TelefonosClientes",
            columns: table => new
            {
                TelefonoClienteId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                ClienteId = table.Column<int>(type: "int", nullable: false),
                Numero = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                EsPrincipal = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TelefonosClientes", x => x.TelefonoClienteId);
                table.ForeignKey(
                    name: "FK_TelefonosClientes_Clientes_ClienteId",
                    column: x => x.ClienteId,
                    principalTable: "Clientes",
                    principalColumn: "ClienteId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Solicitudes_ClienteId",
            table: "Solicitudes",
            column: "ClienteId");

        migrationBuilder.CreateIndex(
            name: "IX_Clientes_RncCedula",
            table: "Clientes",
            column: "RncCedula",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_TelefonosClientes_ClienteId_EsPrincipal",
            table: "TelefonosClientes",
            columns: new[] { "ClienteId", "EsPrincipal" },
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Solicitudes_Clientes_ClienteId",
            table: "Solicitudes",
            column: "ClienteId",
            principalTable: "Clientes",
            principalColumn: "ClienteId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Solicitudes_Clientes_ClienteId",
            table: "Solicitudes");

        migrationBuilder.DropTable(
            name: "TelefonosClientes");

        migrationBuilder.DropTable(
            name: "Clientes");

        migrationBuilder.DropIndex(
            name: "IX_Solicitudes_ClienteId",
            table: "Solicitudes");

        migrationBuilder.DropColumn(
            name: "ClienteId",
            table: "Solicitudes");
    }
}
