
using TareasSegundoPlano.Cache;
using TareasSegundoPlano.Interfaces;

namespace TareasSegundoPlano.Services
{
    public class ProductsSegundoPlanoService : BackgroundService
    {
        private readonly IProductsCache _cache;
        private readonly IServiceProvider _serviceProvider;

        public ProductsSegundoPlanoService(IProductsCache cache, IServiceProvider serviceProvider)
        {
            _cache = cache;
            _serviceProvider = serviceProvider;
        }

        public async override Task StartAsync(CancellationToken cancellationToken)
        {
            await UpdateProductCache();
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                await UpdateProductCache();
            }
        }

        private async Task UpdateProductCache()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                Console.WriteLine("Llenando cache...");
                var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

                var products = await productService.GetProducts();

                _cache.SaveProducts(products);
            }
        }
    }
}