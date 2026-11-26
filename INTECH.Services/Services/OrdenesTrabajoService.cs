using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using INTECH.Context;
using INTECH.Models;
using System.Linq.Expressions;

namespace INTECH.Services;

public class OrdenesTrabajoService(
    IDbContextFactory<Contexto> contextFactory
    )
{

    public async Task<Result> Guardar(OrdenesTrabajo ordenTrabajo)
    {
        if (!await Existe(ordenTrabajo.OrdenTrabajoId))
        {
            var inserto = await Insertar(ordenTrabajo);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(ordenTrabajo);
            return Result.Success(modifico);
        }
    }
}