using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using INTECH.Context;
using INTECH.Models;
using System.Linq.Expressions;

namespace INTECH.Services;

public class HistorialesService(
    IDbContextFactory<Contexto> contextFactory
    )
{

    public async Task<Result> Guardar(Historiales historial)
    {
        if (!await Existe(historial.HistorialId))
        {
            var inserto = await Insertar(historial);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(historial);
            return Result.Success(modifico);
        }
    }

    private async Task<bool> Existe(int historialId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Historiales
            .AnyAsync(h => h.HistorialId == historialId);
    }

    private async Task<bool> Insertar(Historiales historial)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Historiales.Add(historial);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Historiales historial)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var historialExistente = await contexto.Historiales
            .Include(h => h.HistorialesDetalle)
            .SingleOrDefaultAsync(h => h.HistorialId == historial.HistorialId);
        if (historialExistente == null)
        {
            return false;
        }

        historialExistente.SolicitudId = historial.SolicitudId;
        historialExistente.TecnicoId = historial.TecnicoId;
        historialExistente.FechaFinalizacion = historial.FechaFinalizacion;

        contexto.RemoveRange(historialExistente.HistorialesDetalle);
        foreach (var detalle in historial.HistorialesDetalle)
        {
            historialExistente.HistorialesDetalle.Add(new HistorialesDetalle
            {
                HistorialId = historialExistente.HistorialId,
                Titulo = detalle.Titulo,
                Descripcion = detalle.Descripcion,
                Fecha = detalle.Fecha
            });
        }

        return await contexto.SaveChangesAsync() > 0;
    }
}