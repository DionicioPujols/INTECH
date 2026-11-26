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
}