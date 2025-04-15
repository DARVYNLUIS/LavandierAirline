using LavandierAirLine.Data;
using LavandierAirLine.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LavandierAirLine.Services;

public class ViajeServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Viajes.AnyAsync(p => p.ViajesId == id);
    }

    // 2️⃣ Método para modificar un producto
    public async Task<bool> Modificar(Viaje viajes)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(viajes);
        return await contexto.SaveChangesAsync() > 0;
    }

    // 3️⃣ Método para insertar un nuevo producto
    public async Task<bool> Insertar(Viaje viajes)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Viajes.Add(viajes);
        return await contexto.SaveChangesAsync() > 0;
    }

    // 4️⃣ Método para guardar (insertar o modificar)
    public async Task<bool> Guardar(Viaje viajes)
    {
        if (!await Existe(viajes.ViajesId))
            return await Insertar(viajes);
        else
            return await Modificar(viajes);
    }

    // 5️⃣ Método para eliminar un producto por ID
    public async Task<bool> Eliminar(int viajesId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Viajes
            .Where(p => p.ViajesId == viajesId)
            .ExecuteDeleteAsync() > 0;
    }

    // 6️⃣ Método para listar productos según un criterio
    public async Task<List<Viaje>> Listar(Expression<Func<Viaje, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Viajes
            .Include(p => p.Avion)
            .Where(criterio)
            .ToListAsync();
    }

    // 8️⃣ Método para buscar un producto por ID
    public async Task<Viaje?> BuscarId(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Viajes.FirstOrDefaultAsync(p => p.ViajesId == id);
    }
}