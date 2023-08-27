using IntegracaoWorker.Data;
using IntegracaoWorker.Models;
using IntegracaoWorker.Models.DTOs;
using System.Text.Json;

namespace IntegracaoWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {   
                using var scope = _serviceScopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<CatalogoDbContext>();

                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5000/");
                var request = new HttpRequestMessage(HttpMethod.Get, "Produto");
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var produtosDTO = JsonSerializer.Deserialize<List<ProdutoDTO>>(responseContent);
                var produtosBanco = dbContext.Produtos.Where(x => produtosDTO.Select(y => y.Id).Contains(x.Id_Externo)).ToList();
                foreach(var produtoDTO in produtosDTO)
                {
                    var produtoBanco = produtosBanco.FirstOrDefault(x => x.Id_Externo == produtoDTO.Id);

                    if(produtoBanco == null)
                    {
                        dbContext.Produtos.Add(new Produto { 
                            Id_Externo = produtoDTO.Id,
                            Nome = produtoDTO.Nome,
                            Cor = produtoDTO.Cor,
                            Preco = produtoDTO.Preco,
                            Descricao = produtoDTO.Descricao,
                            EAN = produtoDTO.EAN,
                            Marca = produtoDTO.Marca,
                            QtdDisponivel = produtoDTO.QtdDisponivel,
                        });
                    }
                    else
                    {
                        produtoBanco.Id_Externo = produtoDTO.Id;
                        produtoBanco.Nome = produtoDTO.Nome;
                        produtoBanco.Cor = produtoDTO.Cor;
                        produtoBanco.Preco = produtoDTO.Preco;
                        produtoBanco.Descricao = produtoDTO.Descricao;
                        produtoBanco.EAN = produtoDTO.EAN;
                        produtoBanco.Marca = produtoDTO.Marca;
                        produtoBanco.QtdDisponivel = produtoDTO.QtdDisponivel;

                    }
                }
                

                await dbContext.SaveChangesAsync();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}