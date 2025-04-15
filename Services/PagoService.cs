using LavandierAirLine.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LavandierAirLine.Modelos;

public class PagoServices
{

    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
    public PagoServices(IDbContextFactory<ApplicationDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Pagos.AnyAsync(p => p.PagoId == id);
    }

    private async Task AfectarPrestamo(ApplicationDbContext contexto, float monto, int id, bool resta = true )
    {
        var Pedido = await contexto.Boletos
                .FirstOrDefaultAsync(p => p.BoletoId == id);

            if (Pedido != null)
            {
                if (resta)
                    Pedido.PrecioTotal -=monto;
                else
                    Pedido.PrecioTotal += monto;
            }
        
    }
    public async Task<bool> ActulizarEstado(Pago pago, int estadoId)
    {

        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return false;
     
    }

    public async Task<bool> Insertar(Pago pagos)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        await AfectarPrestamo(contexto, pagos.Monto, pagos.BoletoId,true);
        contexto.Pagos.Add(pagos);
        var Cantidad = await contexto.SaveChangesAsync() > 0;
        await ActulizarEstado(pagos, 2); // Cambiar el estado a Pagado
        return true;
    }

    public async Task<bool> Modificar(Pago pagos)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        var pagoOriginal = await contexto.Pagos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PagoId == pagos.PagoId);

        if (pagoOriginal is null)
            return false;

        // Revertir detalles anteriores
        await AfectarPrestamo(contexto, pagos.Monto, pagos.BoletoId, false);
        // Aplicar nuevos detalles
        await AfectarPrestamo(contexto, pagos.Monto, pagos.BoletoId, true);

        contexto.Update(pagos);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Pago pagos)
    {
        if (!await Existe(pagos.PagoId))
            return await Insertar(pagos);
        else
            return await Modificar(pagos);
    }

    public async Task<bool> Eliminar(int pagoId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        var pago = await contexto.Pagos
            .FirstOrDefaultAsync(p => p.PagoId == pagoId);

        if (pago is null)
            return false;

        await AfectarPrestamo(contexto, pago.Monto, pago.BoletoId, false);

        contexto.Pagos.Remove(pago);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Pago?> BuscarId(int id)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Pagos
            .FirstOrDefaultAsync(p => p.PagoId == id);
    }
    public async Task<List<Pago>> Listar(Expression<Func<Pago, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Pagos
            .Include(p => p.Boleto)
            .Include(p => p.Usuario)
            .Include(p => p.EstadoPago)
            .Include(p => p.MetodosPagos)
            .Where(criterio)
            .ToListAsync();
    }
}