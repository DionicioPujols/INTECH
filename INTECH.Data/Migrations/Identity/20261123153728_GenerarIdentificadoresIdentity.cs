using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTECH.Data.Migrations
{
    public partial class _20261123153728_GenerarIdentificadoresIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE [dbo].[AspNetRoleClaims] NOCHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId];
                ALTER TABLE [dbo].[AspNetUserRoles] NOCHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId];
                ALTER TABLE [dbo].[AspNetUserRoles] NOCHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserClaims] NOCHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserLogins] NOCHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserTokens] NOCHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserPasskeys] NOCHECK CONSTRAINT [FK_AspNetUserPasskeys_AspNetUsers_UserId];
                UPDATE [dbo].[AspNetRoleClaims] SET [RoleId] = CASE [RoleId] WHEN N'00000000-0000-0000-0000-000000000001' THEN N'59e653a4-d69a-4abb-8a91-341506ee8a06' WHEN N'00000000-0000-0000-0000-000000000002' THEN N'a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a' WHEN N'00000000-0000-0000-0000-000000000003' THEN N'6dae16d7-4344-451e-8052-9582ed4595d1' END WHERE [RoleId] IN (N'00000000-0000-0000-0000-000000000001', N'00000000-0000-0000-0000-000000000002', N'00000000-0000-0000-0000-000000000003');
                UPDATE [dbo].[AspNetUserRoles] SET [RoleId] = CASE [RoleId] WHEN N'00000000-0000-0000-0000-000000000001' THEN N'59e653a4-d69a-4abb-8a91-341506ee8a06' WHEN N'00000000-0000-0000-0000-000000000002' THEN N'a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a' WHEN N'00000000-0000-0000-0000-000000000003' THEN N'6dae16d7-4344-451e-8052-9582ed4595d1' END WHERE [RoleId] IN (N'00000000-0000-0000-0000-000000000001', N'00000000-0000-0000-0000-000000000002', N'00000000-0000-0000-0000-000000000003');
                UPDATE [dbo].[AspNetUserRoles] SET [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063' WHERE [UserId] = N'00000000-0000-0000-0000-000000000010';
                UPDATE [dbo].[AspNetUserClaims] SET [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063' WHERE [UserId] = N'00000000-0000-0000-0000-000000000010';
                UPDATE [dbo].[AspNetUserLogins] SET [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063' WHERE [UserId] = N'00000000-0000-0000-0000-000000000010';
                UPDATE [dbo].[AspNetUserTokens] SET [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063' WHERE [UserId] = N'00000000-0000-0000-0000-000000000010';
                UPDATE [dbo].[AspNetUserPasskeys] SET [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063' WHERE [UserId] = N'00000000-0000-0000-0000-000000000010';
                UPDATE [dbo].[AspNetRoles] SET [Id] = N'59e653a4-d69a-4abb-8a91-341506ee8a06', [ConcurrencyStamp] = N'40753da4-be56-42bd-b90d-d20d06ccfaf1' WHERE [Id] = N'00000000-0000-0000-0000-000000000001';
                UPDATE [dbo].[AspNetRoles] SET [Id] = N'a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a', [ConcurrencyStamp] = N'9edc1fd0-cb93-4eb6-82a2-171b12d3c49e' WHERE [Id] = N'00000000-0000-0000-0000-000000000002';
                UPDATE [dbo].[AspNetRoles] SET [Id] = N'6dae16d7-4344-451e-8052-9582ed4595d1', [ConcurrencyStamp] = N'f24b9410-da9a-4994-88f7-7e2767e3ce14' WHERE [Id] = N'00000000-0000-0000-0000-000000000003';
                UPDATE [dbo].[AspNetUsers] SET [Id] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063', [SecurityStamp] = N'aa26598b-8bdf-4c7b-b308-e0dbd9bf2d3f', [ConcurrencyStamp] = N'1226f878-2209-425f-b4cb-f512fbc97c72' WHERE [Id] = N'00000000-0000-0000-0000-000000000010';
                ALTER TABLE [dbo].[AspNetRoleClaims] WITH CHECK CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId];
                ALTER TABLE [dbo].[AspNetUserRoles] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId];
                ALTER TABLE [dbo].[AspNetUserRoles] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserClaims] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserLogins] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserTokens] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserPasskeys] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserPasskeys_AspNetUsers_UserId];
                """);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE [dbo].[AspNetRoleClaims] NOCHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId];
                ALTER TABLE [dbo].[AspNetUserRoles] NOCHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId];
                ALTER TABLE [dbo].[AspNetUserRoles] NOCHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserClaims] NOCHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserLogins] NOCHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserTokens] NOCHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserPasskeys] NOCHECK CONSTRAINT [FK_AspNetUserPasskeys_AspNetUsers_UserId];
                UPDATE [dbo].[AspNetRoleClaims] SET [RoleId] = CASE [RoleId] WHEN N'59e653a4-d69a-4abb-8a91-341506ee8a06' THEN N'00000000-0000-0000-0000-000000000001' WHEN N'a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a' THEN N'00000000-0000-0000-0000-000000000002' WHEN N'6dae16d7-4344-451e-8052-9582ed4595d1' THEN N'00000000-0000-0000-0000-000000000003' END WHERE [RoleId] IN (N'59e653a4-d69a-4abb-8a91-341506ee8a06', N'a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a', N'6dae16d7-4344-451e-8052-9582ed4595d1');
                UPDATE [dbo].[AspNetUserRoles] SET [RoleId] = CASE [RoleId] WHEN N'59e653a4-d69a-4abb-8a91-341506ee8a06' THEN N'00000000-0000-0000-0000-000000000001' WHEN N'a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a' THEN N'00000000-0000-0000-0000-000000000002' WHEN N'6dae16d7-4344-451e-8052-9582ed4595d1' THEN N'00000000-0000-0000-0000-000000000003' END WHERE [RoleId] IN (N'59e653a4-d69a-4abb-8a91-341506ee8a06', N'a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a', N'6dae16d7-4344-451e-8052-9582ed4595d1');
                UPDATE [dbo].[AspNetUserRoles] SET [UserId] = N'00000000-0000-0000-0000-000000000010' WHERE [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063';
                UPDATE [dbo].[AspNetUserClaims] SET [UserId] = N'00000000-0000-0000-0000-000000000010' WHERE [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063';
                UPDATE [dbo].[AspNetUserLogins] SET [UserId] = N'00000000-0000-0000-0000-000000000010' WHERE [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063';
                UPDATE [dbo].[AspNetUserTokens] SET [UserId] = N'00000000-0000-0000-0000-000000000010' WHERE [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063';
                UPDATE [dbo].[AspNetUserPasskeys] SET [UserId] = N'00000000-0000-0000-0000-000000000010' WHERE [UserId] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063';
                UPDATE [dbo].[AspNetRoles] SET [Id] = N'00000000-0000-0000-0000-000000000001', [ConcurrencyStamp] = N'00000000-0000-0000-0000-000000000001' WHERE [Id] = N'59e653a4-d69a-4abb-8a91-341506ee8a06';
                UPDATE [dbo].[AspNetRoles] SET [Id] = N'00000000-0000-0000-0000-000000000002', [ConcurrencyStamp] = N'00000000-0000-0000-0000-000000000002' WHERE [Id] = N'a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a';
                UPDATE [dbo].[AspNetRoles] SET [Id] = N'00000000-0000-0000-0000-000000000003', [ConcurrencyStamp] = N'00000000-0000-0000-0000-000000000003' WHERE [Id] = N'6dae16d7-4344-451e-8052-9582ed4595d1';
                UPDATE [dbo].[AspNetUsers] SET [Id] = N'00000000-0000-0000-0000-000000000010', [SecurityStamp] = N'00000000-0000-0000-0000-000000000011', [ConcurrencyStamp] = N'00000000-0000-0000-0000-000000000012' WHERE [Id] = N'4d5d30d0-65b0-494d-a356-69a6a25e1063';
                ALTER TABLE [dbo].[AspNetRoleClaims] WITH CHECK CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId];
                ALTER TABLE [dbo].[AspNetUserRoles] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId];
                ALTER TABLE [dbo].[AspNetUserRoles] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserClaims] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserLogins] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserTokens] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId];
                ALTER TABLE [dbo].[AspNetUserPasskeys] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserPasskeys_AspNetUsers_UserId];
                """);
        }
    }
}
