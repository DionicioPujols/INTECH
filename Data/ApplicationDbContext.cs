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
                    Id = "00000000-0000-0000-0000-000000000001",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000001"
                },
                new IdentityRole
                {
                    Id = "00000000-0000-0000-0000-000000000002",
                    Name = "Técnico",
                    NormalizedName = "TÉCNICO",
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000002"
                },
                new IdentityRole
                {
                    Id = "00000000-0000-0000-0000-000000000003",
                    Name = "Gerente",
                    NormalizedName = "GERENTE",
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000003"
                }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "00000000-0000-0000-0000-000000000010",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAIAAYagAAAAEBpUpJtjUT1J1rgHrNB5JRV0pCR+d9CxHDy5PJwCrBvWmMECBG1HjjC2P1Jk5Rk9Qw==",
                    SecurityStamp = "00000000-0000-0000-0000-000000000011",
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000012",
                    LockoutEnabled = true
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "00000000-0000-0000-0000-000000000010",
                    RoleId = "00000000-0000-0000-0000-000000000001"
                }
            );
        }
    }
}