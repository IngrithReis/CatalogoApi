using IntegracaoWorker.Models;
using System.Text.Json;

namespace IntegracaoWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5000/");
                var request = new HttpRequestMessage(HttpMethod.Get, "Produto");
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var produtos = JsonSerializer.Deserialize<List<Produto>>(responseContent);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}