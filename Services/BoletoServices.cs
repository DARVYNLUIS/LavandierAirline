using LavandierAirLine.Data;
using LavandierAirLine.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LavandierAirLine.Services;

public class BoletoServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Boletos.AnyAsync(p => p.BoletoId == id);
    }

    // 2️⃣ Método para modificar un producto
    public async Task<bool> Modificar(Boleto boletos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(boletos);
        return await contexto.SaveChangesAsync() > 0;
    }

    // 3️⃣ Método para insertar un nuevo producto
    public async Task<bool> Insertar(Boleto boletos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Boletos.Add(boletos);
        return await contexto.SaveChangesAsync() > 0;
    }

    // 4️⃣ Método para guardar (insertar o modificar)
    public async Task<bool> Guardar(Boleto boleto)
    {
        if (!await Existe(boleto.BoletoId))
            return await Insertar(boleto);
        else
            return await Modificar(boleto);
    }

    // 5️⃣ Método para eliminar un producto por ID
    public async Task<bool> Eliminar(int boletoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Boletos
            .Where(p => p.BoletoId == boletoId)
            .ExecuteDeleteAsync() > 0;
    }

    // 6️⃣ Método para listar productos según un criterio
    public async Task<List<Boleto>> Listar(Expression<Func<Boleto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Boletos
            .Include(b => b.Cliente)
            .Include(b => b.Viaje)
            .Where(criterio)
            .ToListAsync();
    }

    // 8️⃣ Método para buscar un producto por ID
    public async Task<Boleto?> BuscarId(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Boletos
             .Include(b => b.Cliente)
            .Include(b => b.Viaje)
            .FirstOrDefaultAsync(p => p.BoletoId == id);
    }
}
