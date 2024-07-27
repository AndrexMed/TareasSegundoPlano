using TareasSegundoPlano.Cache;
using TareasSegundoPlano.Interfaces;
using TareasSegundoPlano.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Tareas en segundo Plano...
//builder.Services.AddHostedService<TareaSegundoPlanoRecurrente>();
//builder.Services.AddHostedService<TareaSegundoPlanoCiclosDeVida>();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IProductService, ProductsService>();

builder.Services.AddSingleton<IProductsCache, ProductsCache>();
builder.Services.AddHostedService<ProductsSegundoPlanoService>();

builder.Services.Configure<HostOptions>(opciones =>
{
    opciones.ServicesStartConcurrently = true;
    opciones.ServicesStopConcurrently = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/getProducts", (IProductsCache productsCache) =>
{
    return productsCache.GetProducts;
});

app.Run();