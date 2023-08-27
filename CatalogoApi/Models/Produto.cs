namespace CatalogoApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Cor { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public int QtdDisponivel { get; set; }
        public string EAN { get; set; }
    }
}
