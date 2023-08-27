using IntegracaoWorker.Data;
using Microsoft.EntityFrameworkCore;

namespace IntegracaoWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((ctx, services) =>
                {
                    var config = ctx.Configuration;
                    services.AddDbContext<CatalogoDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("Catalogo")));
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}