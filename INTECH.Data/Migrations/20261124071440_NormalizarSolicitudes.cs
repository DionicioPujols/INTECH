using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Migrations;

/// <inheritdoc />
public partial class _20261124071440_NormalizarSolicitudes : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Solicitudes_Clientes_ClienteId",
            table: "Solicitudes");

        migrationBuilder.DropColumn(
            name: "Contacto",
            table: "Solicitudes");

        migrationBuilder.DropColumn(
            name: "FechaFin",
            table: "Solicitudes");

        migrationBuilder.DropColumn(
            name: "NombreCliente",
            table: "Solicitudes");

        migrationBuilder.DropColumn(
            name: "TecnicoAsignado",
            table: "Solicitudes");

        migrationBuilder.AlterColumn<int>(
            name: "ClienteId",
            table: "Solicitudes",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Solicitudes_Clientes_ClienteId",
            table: "Solicitudes",
            column: "ClienteId",
            principalTable: "Clientes",
            principalColumn: "ClienteId",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Solicitudes_Clientes_ClienteId",
            table: "Solicitudes");

        migrationBuilder.AlterColumn<int>(
            name: "ClienteId",
            table: "Solicitudes",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AddColumn<string>(
            name: "Contacto",
            table: "Solicitudes",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<DateTime>(
            name: "FechaFin",
            table: "Solicitudes",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "NombreCliente",
            table: "Solicitudes",
            type: "nvarchar(150)",
            maxLength: 150,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "TecnicoAsignado",
            table: "Solicitudes",
            type: "nvarchar(150)",
            maxLength: 150,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddForeignKey(
            name: "FK_Solicitudes_Clientes_ClienteId",
            table: "Solicitudes",
            column: "ClienteId",
            principalTable: "Clientes",
            principalColumn: "ClienteId");
    }
}
