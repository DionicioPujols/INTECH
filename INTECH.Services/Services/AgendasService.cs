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

    private async Task<bool> Insertar(Agendas agenda)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Agendas.Add(agenda);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Agendas agenda)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var agendaExistente = await contexto.Agendas
            .SingleOrDefaultAsync(a => a.AgendaId == agenda.AgendaId);
        if (agendaExistente == null)
        {
            return false;
        }

        agendaExistente.SolicitudId = agenda.SolicitudId;
        agendaExistente.TecnicoId = agenda.TecnicoId;
        agendaExistente.Fecha = agenda.Fecha;
        agendaExistente.HoraInicio = agenda.HoraInicio;
        agendaExistente.HoraFin = agenda.HoraFin;

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<Agendas?>> Buscar(int agendaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Agendas
            .Include(a => a.Solicitud)
                .ThenInclude(s => s.Cliente)
            .Include(a => a.Solicitud)
                .ThenInclude(s => s.EstadoSolicitud)
            .FirstOrDefaultAsync(a => a.AgendaId == agendaId && !a.IsDeleted);
    }
}