using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WilmerCastillo_AP1_P2.DAL;
using WilmerCastillo_AP1_P2.Models;

namespace WilmerCastillo_AP1_P2.Services

{
    public class ProductosService
    {
        private readonly Context _context;

        public ProductosService(Context context)
        {
            _context = context;
        }

        public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> criterio)
        {
            return await _context.Productos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<Productos> Buscar(int id)
        {
            return await _context.Productos.AsNoTracking().
                   FirstOrDefaultAsync(w => w.ProductosId == id);
        }
    }
}



