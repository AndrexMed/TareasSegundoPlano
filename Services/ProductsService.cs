using TareasSegundoPlano.Dtos;
using TareasSegundoPlano.Interfaces;

namespace TareasSegundoPlano.Services
{
    public class ProductsService(HttpClient client) : IProductService
    {
        private readonly HttpClient _httpClient = client;
        public async Task<IEnumerable<Product>> GetProducts()
        {
            //Simulamos una espera.
            await Task.Delay(5000);

            var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("https://api.escuelajs.co/api/v1/products");
            return products;
        }
    }
}