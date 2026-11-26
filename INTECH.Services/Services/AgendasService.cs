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
}