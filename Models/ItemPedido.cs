using System.ComponentModel.DataAnnotations;

namespace DotnetOrderAI.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;
        public int quantidade { get; set; }
        public decimal preco { get; set; }
        public string recomendacao { get; set; } = string.Empty;
    }
}
