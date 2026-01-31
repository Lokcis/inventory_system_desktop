using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioApp.Core.Models;

namespace InventarioApp.Core.Services
{
    /// <summary>
    /// Implementación en memoria de IProductService para pruebas y desarrollo sin backend.
    /// </summary>
    public class MockProductService : IProductService
    {
        private readonly List<Product> _items = new List<Product>();
        private int _nextId = 1;

        public Task CreateAsync(Product product)
        {
            // Asignar id simulado y clonar para evitar aliasing
            var p = new Product { Name = product.Name, Quantity = product.Quantity };
            _items.Add(p);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            // En este mock no usamos id real; borrar por nombre si existe
            var item = _items.FirstOrDefault();
            if (item != null) _items.Remove(item);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_items.ToList());
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return Task.FromResult<Product?>(_items.FirstOrDefault());
        }

        public Task UpdateAsync(Product product)
        {
            var item = _items.FirstOrDefault(i => i.Name == product.Name);
            if (item != null)
            {
                item.Quantity = product.Quantity;
            }
            return Task.CompletedTask;
        }
    }
}
