using Microsoft.EntityFrameworkCore;
using INTECH.Models;

namespace INTECH.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public DbSet<Modelo1> Modelos { get; set; }
}