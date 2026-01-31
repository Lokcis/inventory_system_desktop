using System.Collections.Generic;
using System.Threading.Tasks;
using InventarioApp.Core.Models;

namespace InventarioApp.Core.Services
{
    /// <summary>
    /// Contrato para operaciones CRUD sobre productos.
    /// Implementaciones pueden ser mocks, adaptadores HTTP, o acceso a base de datos.
    /// </summary>
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
