using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using INTECH.Context;
using INTECH.Models;
using System.Linq.Expressions;

namespace INTECH.Services;

public class ClientesService(
    IDbContextFactory<Contexto> contextFactory
    ) : IServiceResult<Clientes, int>
{

    public async Task<Result> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
        {
            var inserto = await Insertar(cliente);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(cliente);
            return Result.Success(modifico);
        }
    }

    private async Task<bool> Existe(int clienteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AnyAsync(c => c.ClienteId == clienteId);
    }

    public async Task<bool> ExisteRncCedula(string rncCedula)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AnyAsync(c => c.RncCedula == rncCedula && !c.IsDeleted);
    }

    private async Task<bool> Insertar(Clientes cliente)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Clientes.Add(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Clientes cliente)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var clienteExistente = await contexto.Clientes
            .Include(c => c.TelefonosClientes)
            .SingleOrDefaultAsync(c => c.ClienteId == cliente.ClienteId);
        if (clienteExistente == null)
        {
            return false;
        }

        clienteExistente.Nombre = cliente.Nombre;
        clienteExistente.Correo = cliente.Correo;
        clienteExistente.RncCedula = cliente.RncCedula;
        clienteExistente.Direccion = cliente.Direccion;

        contexto.RemoveRange(clienteExistente.TelefonosClientes);
        foreach (var telefono in cliente.TelefonosClientes)
        {
            clienteExistente.TelefonosClientes.Add(new TelefonosClientes
            {
                ClienteId = clienteExistente.ClienteId,
                Numero = telefono.Numero,
                EsPrincipal = telefono.EsPrincipal
            });
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<Clientes?>> Buscar(int clienteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .Include(c => c.TelefonosClientes.Where(t => !t.IsDeleted))
            .Include(c => c.Solicitudes)
            .FirstOrDefaultAsync(c => c.ClienteId == clienteId && !c.IsDeleted);
    }

    public async Task<Result<List<Clientes>>> GetList(Expression<Func<Clientes, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .Include(c => c.TelefonosClientes.Where(t => !t.IsDeleted))
            .Include(c => c.Solicitudes)
            .Where(c => !c.IsDeleted)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int clienteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Clientes
            .Where(c => c.ClienteId == clienteId && !c.IsDeleted)
            .ExecuteUpdateAsync(c => c.SetProperty(cliente => cliente.IsDeleted, true)) > 0;
        return Result.Success(eliminado);
    }
}
