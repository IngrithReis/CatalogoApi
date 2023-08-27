using CatalogoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private List<Produto> _produtos = new List<Produto>()
            {
                { new Produto() { Id = 1, Cor = "preta", Nome="Televisão", Descricao = "TV 20 polegadas", Marca="Philco", Preco = 15520.25M, EAN ="123456789", QtdDisponivel = 15 } },
                { new Produto() { Id = 2, Cor = "preta", Nome="Liquidificador", Descricao = "liquidificador masterplus", Marca="Philco", Preco = 130.45M, EAN ="123456710", QtdDisponivel = 10 }},
                { new Produto() { Id = 3, Cor = "azul", Nome="Tablet", Descricao = "Tablet infantil", Marca="Barbante", Preco = 1250.25M, EAN ="123456711", QtdDisponivel = 5 }},
                { new Produto() { Id = 4, Cor = "Prata", Nome="Secadora de Roupas", Descricao = "Secadora independente de roupas", Marca="Brastemp", Preco = 1320.25M, EAN ="123456712", QtdDisponivel = 2 } },
                { new Produto() { Id = 5, Cor = "Rosa", Nome="Secador de cabelos", Descricao = "Secador com escova modeladora", Marca="XPto", Preco = 655.75M, EAN ="123456713", QtdDisponivel = 45 }},
                { new Produto() { Id = 6, Cor = "Preta", Nome="Notebook", Descricao = "Notebook", Marca="Sansung", Preco = 2320.25M, EAN ="123456713", QtdDisponivel = 22 }}
            };

        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(_produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _produtos.FirstOrDefault(x => x.Id == id);
            if(produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
    }
}
