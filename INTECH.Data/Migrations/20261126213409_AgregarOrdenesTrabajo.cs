using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261126213409_AgregarOrdenesTrabajo : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "OrdenesTrabajo",
            columns: table => new
            {
                OrdenTrabajoId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                SolicitudId = table.Column<int>(type: "int", nullable: false),
                Tareas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Materiales = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Herramientas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                InstruccionesCampo = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrdenesTrabajo", x => x.OrdenTrabajoId);
                table.ForeignKey(
                    name: "FK_OrdenesTrabajo_Solicitudes_SolicitudId",
                    column: x => x.SolicitudId,
                    principalTable: "Solicitudes",
                    principalColumn: "SolicitudId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_OrdenesTrabajo_SolicitudId",
            table: "OrdenesTrabajo",
            column: "SolicitudId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "OrdenesTrabajo");
    }
}
