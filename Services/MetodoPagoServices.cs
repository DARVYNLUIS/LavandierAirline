using LavandierAirLine.Data;
using LavandierAirLine.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LavandierAirLine.Services
{
    public class MetodoPagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<List<MetodosPagos>> Listar(Expression<Func<MetodosPagos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.MetodosPagos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
