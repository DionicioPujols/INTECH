using Microsoft.EntityFrameworkCore;
using INTECH.Models;

namespace INTECH.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public DbSet<Modelo1> Modelos { get; set; }
    public DbSet<EstadosSolicitudes> EstadosSolicitudes { get; set; }
    public DbSet<Solicitudes> Solicitudes { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<TelefonosClientes> TelefonosClientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EstadosSolicitudes>().HasData(
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 1,
                Nombre = "Pendiente"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 2,
                Nombre = "Finalizada"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 3,
                Nombre = "Cancelada"
            }
        );
    }
}
