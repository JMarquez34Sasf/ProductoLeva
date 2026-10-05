using Microsoft.EntityFrameworkCore;
using ProductoLeva.Data;
using ProductoLeva.Interfaces;
using ProductoLeva.Models;

namespace ProductoLeva.Repositories
{
    public class ProductoRepository : IProducto
    {
        private readonly ProductoContext context;
        public ProductoRepository(ProductoContext context)
        {
            this.context = context;
        }

        public async Task<List<Producto>> getProdcutos()
        {
            return await context.Productos
                .Where(p=> p.Estado != "Inactivo")
                .ToListAsync();
        }

        public async Task<Producto> getProductoById(int id)
        {
            return await context.Productos.FindAsync(id);
        }
    }
}
