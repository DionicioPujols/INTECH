using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using INTECH.Context;
using INTECH.Models;
using System.Linq.Expressions;

namespace INTECH.Services;

public class EstadosSolicitudesService(
    IDbContextFactory<Contexto> contextFactory
    ) : IServiceResult<EstadosSolicitudes, int>
{

    public async Task<Result> Guardar(EstadosSolicitudes estadoSolicitud)
    {
        if (!await Existe(estadoSolicitud.EstadoSolicitudId))
        {
            var inserto = await Insertar(estadoSolicitud);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(estadoSolicitud);
            return Result.Success(modifico);
        }
    }

    private async Task<bool> Existe(int estadoSolicitudId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.EstadosSolicitudes
            .AnyAsync(p => p.EstadoSolicitudId == estadoSolicitudId);
    }

    private async Task<bool> Insertar(EstadosSolicitudes estadoSolicitud)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.EstadosSolicitudes.Add(estadoSolicitud);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EstadosSolicitudes estadoSolicitud)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(estadoSolicitud);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<EstadosSolicitudes?>> Buscar(int estadoSolicitudId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.EstadosSolicitudes
            .FirstOrDefaultAsync(p => p.EstadoSolicitudId == estadoSolicitudId);
    }

    public async Task<Result<List<EstadosSolicitudes>>> GetList(Expression<Func<EstadosSolicitudes, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.EstadosSolicitudes
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int estadoSolicitudId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var tieneSolicitudes = await contexto.Solicitudes
            .AnyAsync(s => s.EstadoSolicitudId == estadoSolicitudId);
        if (tieneSolicitudes)
        {
            return Result.Success(false);
        }

        var eliminado = await contexto.EstadosSolicitudes
            .Where(p => p.EstadoSolicitudId == estadoSolicitudId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }
}
