using LavandierAirLine.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LavandierAirLine.Services;

public class ClienteServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<ApplicationUser?>> Listar(Expression<Func<ApplicationUser, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cliente
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
