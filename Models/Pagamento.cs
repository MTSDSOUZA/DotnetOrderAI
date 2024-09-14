using System.ComponentModel.DataAnnotations;

namespace DotnetOrderAI.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }
        public string num_cartao { get; set; } = string.Empty;
        public string nome_cartao { get; set; } = string.Empty;
        public string data_validade { get; set; } = string.Empty;
        public int cvv { get; set; }
        public string apelido_cartao { get; set; } = string.Empty;
    }
}
