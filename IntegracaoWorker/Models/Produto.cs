using System.Text.Json.Serialization;

namespace IntegracaoWorker.Models
{
    public class Produto
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
