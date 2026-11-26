using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using INTECH.Context;
using INTECH.Models;
using System.Linq.Expressions;

namespace INTECH.Services;

public class LevantamientosService(
    IDbContextFactory<Contexto> contextFactory
    )
{

    public async Task<Result> Guardar(Levantamientos levantamiento)
    {
        if (!await Existe(levantamiento.LevantamientoId))
        {
            var inserto = await Insertar(levantamiento);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(levantamiento);
            return Result.Success(modifico);
        }
    }

    private async Task<bool> Existe(int levantamientoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Levantamientos
            .AnyAsync(l => l.LevantamientoId == levantamientoId);
    }

    private async Task<bool> Insertar(Levantamientos levantamiento)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Levantamientos.Add(levantamiento);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Levantamientos levantamiento)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var levantamientoExistente = await contexto.Levantamientos
            .Include(l => l.FotosLevantamientos)
            .SingleOrDefaultAsync(l => l.LevantamientoId == levantamiento.LevantamientoId);
        if (levantamientoExistente == null)
        {
            return false;
        }

        levantamientoExistente.SolicitudId = levantamiento.SolicitudId;
        levantamientoExistente.TecnicoId = levantamiento.TecnicoId;
        levantamientoExistente.FechaProgramada = levantamiento.FechaProgramada;
        levantamientoExistente.HoraInicio = levantamiento.HoraInicio;
        levantamientoExistente.HoraFin = levantamiento.HoraFin;
        levantamientoExistente.DisponibilidadEspaciosFisicos = levantamiento.DisponibilidadEspaciosFisicos;
        levantamientoExistente.CargasElectricas = levantamiento.CargasElectricas;
        levantamientoExistente.EstabilidadTension = levantamiento.EstabilidadTension;
        levantamientoExistente.RecorridoTuberias = levantamiento.RecorridoTuberias;
        levantamientoExistente.RecorridoCableado = levantamiento.RecorridoCableado;
        levantamientoExistente.Observaciones = levantamiento.Observaciones;
        levantamientoExistente.EsBorrador = levantamiento.EsBorrador;

        contexto.RemoveRange(levantamientoExistente.FotosLevantamientos);
        foreach (var foto in levantamiento.FotosLevantamientos)
        {
            levantamientoExistente.FotosLevantamientos.Add(new FotosLevantamientos
            {
                LevantamientoId = levantamientoExistente.LevantamientoId,
                NombreArchivo = foto.NombreArchivo,
                TipoContenido = foto.TipoContenido,
                Contenido = foto.Contenido
            });
        }

        return await contexto.SaveChangesAsync() > 0;
    }
}
