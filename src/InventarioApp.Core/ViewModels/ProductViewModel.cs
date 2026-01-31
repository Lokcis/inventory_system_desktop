using System.ComponentModel;
using InventarioApp.Core.Models;

namespace InventarioApp.Core.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly Product _product;

        public ProductViewModel(Product product)
        {
            _product = product;
        }

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

        public void Add(int amount)
        {
            if (amount < 0) throw new System.ArgumentException("amount must be >= 0", nameof(amount));
            Quantity = _product.Quantity + amount;
        }

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
