using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INTECH.Data.Migrations;

/// <inheritdoc />
public partial class _20261123152422_RolesYAdministradorPredeterminados : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            values: new object[,]
            {
                { "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000001", "Administrador", "ADMINISTRADOR" },
                { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000002", "Técnico", "TÉCNICO" },
                { "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000003", "Gerente", "GERENTE" }
            });

        migrationBuilder.InsertData(
            table: "AspNetUsers",
            columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            values: new object[] { "00000000-0000-0000-0000-000000000010", 0, "00000000-0000-0000-0000-000000000012", null, false, true, null, null, "ADMIN", "AQAAAAIAAYagAAAAEBpUpJtjUT1J1rgHrNB5JRV0pCR+d9CxHDy5PJwCrBvWmMECBG1HjjC2P1Jk5Rk9Qw==", null, false, "00000000-0000-0000-0000-000000000011", false, "admin" });

        migrationBuilder.InsertData(
            table: "AspNetUserRoles",
            columns: new[] { "RoleId", "UserId" },
            values: new object[] { "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000010" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "AspNetRoles",
            keyColumn: "Id",
            keyValue: "00000000-0000-0000-0000-000000000002");

        migrationBuilder.DeleteData(
            table: "AspNetRoles",
            keyColumn: "Id",
            keyValue: "00000000-0000-0000-0000-000000000003");

        migrationBuilder.DeleteData(
            table: "AspNetUserRoles",
            keyColumns: new[] { "RoleId", "UserId" },
            keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000010" });

        migrationBuilder.DeleteData(
            table: "AspNetRoles",
            keyColumn: "Id",
            keyValue: "00000000-0000-0000-0000-000000000001");

        migrationBuilder.DeleteData(
            table: "AspNetUsers",
            keyColumn: "Id",
            keyValue: "00000000-0000-0000-0000-000000000010");
    }
}
