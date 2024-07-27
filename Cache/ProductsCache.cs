using TareasSegundoPlano.Dtos;

namespace TareasSegundoPlano.Cache
{
    // Definición de la interfaz para una caché de productos
    public interface IProductsCache
    {
        // Propiedad para obtener los productos almacenados en la caché
        IEnumerable<Product>? GetProducts { get; }

        // Método para guardar una nueva lista de productos en la caché
        void SaveProducts(IEnumerable<Product> newProducts);
    }

    // Implementación de la interfaz IProductsCache
    public class ProductsCache : IProductsCache
    {
        // Campo privado para almacenar los productos en la caché
        private IEnumerable<Product>? _products;

        // Propiedad pública para obtener los productos en la caché, implementando la propiedad de la interfaz
        public IEnumerable<Product>? GetProducts => _products;

        // Método para guardar una nueva lista de productos en la caché
        public void SaveProducts(IEnumerable<Product> newProducts)
        {
            // Usa Interlocked.Exchange para reemplazar de forma segura el campo _products
            // con la nueva lista de productos. Esto es seguro para multihilo, lo que significa
            // que previene problemas cuando múltiples hilos acceden o modifican el campo _products simultáneamente.
            Interlocked.Exchange(ref _products, newProducts);
        }
    }
}
