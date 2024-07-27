
namespace TareasSegundoPlano.SegundoPlano
{
    public class TareaSegundoPlanoCiclosDeVida : IHostedLifecycleService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("1. Antes de Iniciar la Tarea...");
            return Task.CompletedTask;
        }

        public async Task StartedAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("2. Iniciando la tarea la Tarea...");
            await Task.Delay(10000);
            //return Task.CompletedTask;
        }

        public Task StartingAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("3. Tarea iniciada...");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("4. Antes de detener la Tarea...");
            return Task.CompletedTask;
        }

        public Task StoppedAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("5. Deteniendo la tarea...");
            return Task.CompletedTask;
        }

        public Task StoppingAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("6. Tarea detenida...");
            return Task.CompletedTask;
        }
    }
}