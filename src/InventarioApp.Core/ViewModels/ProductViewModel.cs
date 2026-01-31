using System.ComponentModel;
using InventarioApp.Core.Models;

namespace InventarioApp.Core.ViewModels
{
    /// <summary>
    /// ViewModel para <see cref="Product"/> que expone propiedades y operaciones para la UI.
    /// Se encarga únicamente de la lógica de presentación y notificación de cambios.
    /// </summary>
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly Product _product;

        /// <summary>
        /// Crea una instancia de <see cref="ProductViewModel"/> vinculada a un <see cref="Product"/>.
        /// </summary>
        public ProductViewModel(Product product)
        {
            _product = product;
        }

        /// <summary>
        /// Nombre del producto (bindable).
        /// </summary>
        public string Name
        {
            get => _product.Name;
            set
            {
                if (_product.Name != value)
                {
                    _product.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Cantidad disponible del producto (bindable).
        /// </summary>
        public int Quantity
        {
            get => _product.Quantity;
            private set
            {
                if (_product.Quantity != value)
                {
                    _product.Quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        /// <summary>
        /// Aumenta la cantidad del producto. Lanza <see cref="ArgumentException"/> si el valor es negativo.
        /// </summary>
        public void Add(int amount)
        {
            if (amount < 0) throw new System.ArgumentException("amount must be >= 0", nameof(amount));
            Quantity = _product.Quantity + amount;
        }

        /// <summary>
        /// Reduce la cantidad del producto. Lanza excepción si la cantidad solicitada excede la disponible.
        /// </summary>
        public void Remove(int amount)
        {
            if (amount < 0) throw new System.ArgumentException("amount must be >= 0", nameof(amount));
            if (amount > _product.Quantity) throw new System.InvalidOperationException("Insufficient quantity");
            Quantity = _product.Quantity - amount;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
