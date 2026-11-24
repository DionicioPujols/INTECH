using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace INTECH.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "59e653a4-d69a-4abb-8a91-341506ee8a06",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                    ConcurrencyStamp = "40753da4-be56-42bd-b90d-d20d06ccfaf1"
                },
                new IdentityRole
                {
                    Id = "a86a7a8a-6dd3-40c8-a596-1a8e9788cc9a",
                    Name = "Técnico",
                    NormalizedName = "TÉCNICO",
                    ConcurrencyStamp = "9edc1fd0-cb93-4eb6-82a2-171b12d3c49e"
                },
                new IdentityRole
                {
                    Id = "6dae16d7-4344-451e-8052-9582ed4595d1",
                    Name = "Gerente",
                    NormalizedName = "GERENTE",
                    ConcurrencyStamp = "f24b9410-da9a-4994-88f7-7e2767e3ce14"
                }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "4d5d30d0-65b0-494d-a356-69a6a25e1063",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAIAAYagAAAAEBpUpJtjUT1J1rgHrNB5JRV0pCR+d9CxHDy5PJwCrBvWmMECBG1HjjC2P1Jk5Rk9Qw==",
                    SecurityStamp = "aa26598b-8bdf-4c7b-b308-e0dbd9bf2d3f",
                    ConcurrencyStamp = "1226f878-2209-425f-b4cb-f512fbc97c72",
                    LockoutEnabled = true
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "4d5d30d0-65b0-494d-a356-69a6a25e1063",
                    RoleId = "59e653a4-d69a-4abb-8a91-341506ee8a06"
                }
            );
        }
    }
}