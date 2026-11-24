using Microsoft.EntityFrameworkCore;
using INTECH.Models;

namespace INTECH.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

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
                Nombre = "En proceso"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 3,
                Nombre = "En Espera Administración"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 4,
                Nombre = "En revisión"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 5,
                Nombre = "Enviada al cliente"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 6,
                Nombre = "Aprobada"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 7,
                Nombre = "Rechazada"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 8,
                Nombre = "Pendiente de cobro"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 9,
                Nombre = "Finalizada"
            },
            new EstadosSolicitudes
            {
                EstadoSolicitudId = 10,
                Nombre = "Cancelada"
            }
        );
    }
}
