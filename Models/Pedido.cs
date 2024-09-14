using System.ComponentModel.DataAnnotations;

namespace DotnetOrderAI.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal FreteEntrega { get; set; }
        public string DataPedido { get; set; }
        public string DataEntrega { get; set; }
    }
}
