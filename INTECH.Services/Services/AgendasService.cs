using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using INTECH.Context;
using INTECH.Models;
using System.Linq.Expressions;

namespace INTECH.Services;

public class AgendasService(
    IDbContextFactory<Contexto> contextFactory
    )
{

    public async Task<Result> Guardar(Agendas agenda)
    {
        if (!await Existe(agenda.AgendaId))
        {
            var inserto = await Insertar(agenda);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(agenda);
            return Result.Success(modifico);
        }
    }

    private async Task<bool> Existe(int agendaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Agendas
            .AnyAsync(a => a.AgendaId == agendaId);
    }
}