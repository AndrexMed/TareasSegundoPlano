
namespace TareasSegundoPlano.SegundoPlano
{
    public class TareaSegundoPlanoRecurrente : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested) //Mientras no se solicite la cancelacion se ejecutar este bloque.
                {
                    Console.WriteLine("Ejecutando tarea en segundo plano...");
                    await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Deteniendo la ejecutacion de la tarea en segundo plano.");
            }
        }
    }
}