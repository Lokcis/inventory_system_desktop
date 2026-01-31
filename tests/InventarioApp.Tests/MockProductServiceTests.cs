using System.Linq;
using System.Threading.Tasks;
using InventarioApp.Core.Models;
using InventarioApp.Core.Services;
using Xunit;

namespace InventarioApp.Tests
{
    public class MockProductServiceTests
    {
        [Fact]
        public async Task CreateAndGetAll_ReturnsCreated()
        {
            var svc = new MockProductService();

            await svc.CreateAsync(new Product { Name = "A", Quantity = 1 });
            var list = await svc.GetAllAsync();

            Assert.Single(list);
        }

        [Fact]
        public async Task Update_ChangesQuantity()
        {
            var svc = new MockProductService();
            var p = new Product { Name = "A", Quantity = 1 };

            await svc.CreateAsync(p);
            p.Quantity = 5;
            await svc.UpdateAsync(p);

            var updated = (await svc.GetAllAsync()).First();
            Assert.Equal(5, updated.Quantity);
        }
    }
}
