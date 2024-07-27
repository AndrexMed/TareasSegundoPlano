using TareasSegundoPlano.Dtos;

namespace TareasSegundoPlano.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}