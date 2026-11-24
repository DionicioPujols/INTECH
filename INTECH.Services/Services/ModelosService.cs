using Microsoft.EntityFrameworkCore;
using INTECH.Context;
using INTECH.Models;
using System.Linq.Expressions;
using Aplicada1.Core;

namespace INTECH.Services;

public class ModelosService(
IDbContextFactory<Contexto> contextFactory
) : Aplicada1.Core.IServiceResult<Modelo1, int>
{
    public Task<Result<Modelo1?>> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Modelo1>>> GetList(Expression<Func<Modelo1, bool>> criterio)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Guardar(Modelo1 entidad)
    {
        throw new NotImplementedException();
    }
}
