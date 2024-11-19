using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WilmerCastillo_AP1_P2.DAL;
using WilmerCastillo_AP1_P2.Models;


namespace WilmerCastillo_AP1_P2.Services;
 public class CombosServices(IDbContextFactory<Context> DbFactory)
{

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Combo1.AnyAsync(a => a.CombosId == id);
    }

    private async Task<bool> Insertar(Combo1 combos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        await AfectarArticulo(combos.CombosDetalle.ToArray(), true);
        contexto.Combo1.Add(combos);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task AfectarArticulo(ComboDetalles[] detalle, bool resta = true)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach (var item in detalle)
        {
            var Articulo = await contexto.Product.SingleAsync(p => p.ProductosId == item.ProductosId);
            if (resta)
                Articulo.Existencia -= item.Cantidad;
            else
                Articulo.Existencia += item.Cantidad;
        }

        await contexto.SaveChangesAsync();
    }

    private async Task<bool> Modificar(Combo1 combos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var comboOriginal = await contexto.Combo1
            .Include(t => t.CombosDetalle)
            .FirstOrDefaultAsync(t => t.CombosId == combos.CombosId);

        if (comboOriginal == null)
            return false;

        await AfectarArticulo(comboOriginal.CombosDetalle.ToArray(), false);

        foreach (var detalleOriginal in comboOriginal.CombosDetalle)
        {
            if (!combos.CombosDetalle.Any(d => d.DetalleId == detalleOriginal.DetalleId))
            {
                contexto.ComboDetalles.Remove(detalleOriginal);
            }
        }

        await AfectarArticulo(combos.CombosDetalle.ToArray(), true);

        contexto.Entry(comboOriginal).CurrentValues.SetValues(combos);

        foreach (var detalle in combos.CombosDetalle)
        {
            var detalleExistente = comboOriginal.CombosDetalle
                .FirstOrDefault(d => d.DetalleId == detalle.DetalleId);

            if (detalleExistente != null)
            {
                contexto.Entry(detalleExistente).CurrentValues.SetValues(detalle);
            }
            else
            {
                comboOriginal.CombosDetalle.Add(detalle);
            }
        }

        return await contexto.SaveChangesAsync() > 0;
    }



    public async Task<bool> Guardar(Combo1 combos)
    {
        if (!await Existe(combos.CombosId))
            return await Insertar(combos);
        else
            return await Modificar(combos);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var context = await DbFactory.CreateDbContextAsync();
        var cotizacion = await context.Combo1
            .Include(t => t.CombosDetalle)
            .ThenInclude(td => td.Productos)
            .FirstOrDefaultAsync(t => t.CombosId == id);

        if (cotizacion == null)
            return false;

        await AfectarArticulo(cotizacion.CombosDetalle.ToArray(), resta: false);

        context.ComboDetalles.RemoveRange(cotizacion.CombosDetalle);
        context.Combo1.Remove(cotizacion);

        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<Combo1> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Combo1
            .Include(t => t.CombosDetalle)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.CombosId == id);
    }

    public async Task<Combo1> BuscarConDetalles(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Combo1
            
            .Include(t => t.CombosDetalle)
            .ThenInclude(td => td.Productos)
            .FirstOrDefaultAsync(p => p.CombosId == id);
    }

    public async Task<List<Combo1>> Listar(Expression<Func<Combo1, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var combo = await contexto.Combo1
            .Include(t => t.CombosDetalle)
            .ThenInclude(td => td.Productos)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
        return combo;
 
    }

}





    
    