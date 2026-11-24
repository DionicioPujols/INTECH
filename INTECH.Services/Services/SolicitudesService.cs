using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using INTECH.Context;
using INTECH.Models;
using System.Linq.Expressions;

namespace INTECH.Services;

public class SolicitudesService(
    IDbContextFactory<Contexto> contextFactory
    ) : IServiceResult<Solicitudes, int>
{

    public async Task<Result> Guardar(Solicitudes solicitud)
    {
        if (solicitud.IsDeleted || solicitud.FechaFin < solicitud.FechaSolicitud)
        {
            return Result.Success(false);
        }

        if (!await Existe(solicitud.SolicitudId))
        {
            if (solicitud.SolicitudId != 0)
            {
                return Result.Success(false);
            }

            var inserto = await Insertar(solicitud);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(solicitud);
            return Result.Success(modifico);
        }
    }

    private async Task<bool> Existe(int solicitudId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Solicitudes
            .AnyAsync(s => s.SolicitudId == solicitudId && !s.IsDeleted);
    }

    private async Task<bool> Insertar(Solicitudes solicitud)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var estadoExiste = await contexto.EstadosSolicitudes
            .AnyAsync(e => e.EstadoSolicitudId == solicitud.EstadoSolicitudId);
        if (!estadoExiste)
        {
            return false;
        }

        if (solicitud.ClienteId.HasValue)
        {
            var cliente = await contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == solicitud.ClienteId && !c.IsDeleted);
            if (cliente == null)
            {
                return false;
            }

            solicitud.NombreCliente = cliente.Nombre;
        }

        solicitud.Cliente = null;
        solicitud.EstadoSolicitud = null!;
        contexto.Solicitudes.Add(solicitud);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Solicitudes solicitud)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var solicitudExiste = await contexto.Solicitudes
            .AnyAsync(s => s.SolicitudId == solicitud.SolicitudId && !s.IsDeleted);
        var estadoExiste = await contexto.EstadosSolicitudes
            .AnyAsync(e => e.EstadoSolicitudId == solicitud.EstadoSolicitudId);
        if (!solicitudExiste || !estadoExiste)
        {
            return false;
        }

        if (solicitud.ClienteId.HasValue)
        {
            var cliente = await contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == solicitud.ClienteId);
            var clienteAnteriorId = await contexto.Solicitudes
                .Where(s => s.SolicitudId == solicitud.SolicitudId)
                .Select(s => s.ClienteId)
                .FirstOrDefaultAsync();
            if (cliente == null || (cliente.IsDeleted && clienteAnteriorId != cliente.ClienteId))
            {
                return false;
            }

            solicitud.NombreCliente = cliente.Nombre;
        }

        solicitud.Cliente = null;
        solicitud.EstadoSolicitud = null!;
        contexto.Update(solicitud);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<Solicitudes?>> Buscar(int solicitudId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Solicitudes
            .Include(s => s.EstadoSolicitud)
            .FirstOrDefaultAsync(s => s.SolicitudId == solicitudId && !s.IsDeleted);
    }

    public async Task<Result<List<Solicitudes>>> GetList(Expression<Func<Solicitudes, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Solicitudes
            .Include(s => s.EstadoSolicitud)
            .Where(s => !s.IsDeleted)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int solicitudId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Solicitudes
            .Where(s => s.SolicitudId == solicitudId && !s.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(solicitud => solicitud.IsDeleted, true)) > 0;
        return Result.Success(eliminado);
    }
}
