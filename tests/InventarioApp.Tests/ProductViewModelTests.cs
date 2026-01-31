using InventarioApp.Core.Models;
using InventarioApp.Core.ViewModels;
using Xunit;

namespace InventarioApp.Tests
{
    /// <summary>
    /// Pruebas unitarias para <see cref="InventarioApp.Core.ViewModels.ProductViewModel"/>.
    /// Cada prueba documenta el comportamiento esperado para operaciones comunes y casos borde.
    /// </summary>
    public class ProductViewModelTests
    {
        [Fact]
        public void Add_IncreasesQuantity()
        {
            // Arrange
            var product = new Product { Name = "Test", Quantity = 5 };
            var vm = new ProductViewModel(product);

            // Act
            vm.Add(3);

            // Assert
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
