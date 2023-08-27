using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoWorker.Models.DTOs
{
    internal class ProdutoDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("preco")]
        public decimal Preco { get; set; }
        [JsonPropertyName("cor")]
        public string Cor { get; set; }
        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }
        [JsonPropertyName("marca")]
        public string Marca { get; set; }
        [JsonPropertyName("qtdDisponivel")]
        public int QtdDisponivel { get; set; }
        [JsonPropertyName("ean")]
        public string EAN { get; set; }
    }
}
