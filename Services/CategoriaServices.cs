using LavandierAirLine.Data;
using LavandierAirLine.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LavandierAirLine.Services;

public class CategoriaServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<CategoriaVuelo>> Listar(Expression<Func<CategoriaVuelo, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CategoriaVuelo
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

}