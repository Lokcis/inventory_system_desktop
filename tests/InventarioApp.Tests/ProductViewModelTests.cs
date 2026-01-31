using InventarioApp.Core.Models;
using InventarioApp.Core.ViewModels;
using Xunit;

namespace InventarioApp.Tests
{
    public class ProductViewModelTests
    {
        [Fact]
        public void Add_IncreasesQuantity()
        {
            var product = new Product { Name = "Test", Quantity = 5 };
            var vm = new ProductViewModel(product);

            vm.Add(3);

            Assert.Equal(8, vm.Quantity);
        }

        [Fact]
        public void Remove_DecreasesQuantity()
        {
            var product = new Product { Name = "Test", Quantity = 5 };
            var vm = new ProductViewModel(product);

            vm.Remove(2);

            Assert.Equal(3, vm.Quantity);
        }

        [Fact]
        public void Remove_TooMuch_Throws()
        {
            var product = new Product { Name = "Test", Quantity = 5 };
            var vm = new ProductViewModel(product);

            Assert.Throws<System.InvalidOperationException>(() => vm.Remove(10));
        }

        [Fact]
        public void Add_Negative_Throws()
        {
            var product = new Product { Name = "Test", Quantity = 5 };
            var vm = new ProductViewModel(product);

            Assert.Throws<System.ArgumentException>(() => vm.Add(-1));
        }
    }
}
