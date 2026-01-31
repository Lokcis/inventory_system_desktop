namespace InventarioApp.Core.Models
{
    /// <summary>
    /// Representa un producto en el inventario.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Nombre descriptivo del producto.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad disponible en inventario.
        /// </summary>
        public int Quantity { get; set; }
    }
}
