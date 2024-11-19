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

        public async Task<List<Product>> Listar(Expression<Func<Product, bool>> criterio)
        {
            return await _context.Product
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<Product> Buscar(int id)
        {
            return await _context.Product.AsNoTracking().
                   FirstOrDefaultAsync(w => w.ProductosId == id);
        }
    }
}



