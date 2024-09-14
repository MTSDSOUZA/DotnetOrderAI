using DotnetOrderAI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetOrderAI.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Usuario> TabelaUsuario { get; set; }
        public DbSet<Pedido> TabelaPedido { get; set; }
        public DbSet<ItemPedido> TabelaItemPedido { get; set; }
        public DbSet<Pagamento> TabelaPagamento { get; set; }
    }
}
