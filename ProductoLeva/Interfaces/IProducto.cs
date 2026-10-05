using ProductoLeva.Models;

namespace ProductoLeva.Interfaces
{
    public interface IProducto
    {
        Task<List<Producto>> getProdcutos();
        Task<Producto> getProductoById(int id);
    }
}
