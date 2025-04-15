using LavandierAirLine.Data;
using LavandierAirLine.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LavandierAirLine.Services;

public class AvionService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<Avion>> Listar(Expression<Func<Avion, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Avion
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

}
