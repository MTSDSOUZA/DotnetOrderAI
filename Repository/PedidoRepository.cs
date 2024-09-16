using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using DotnetOrderAI.Data;
using Microsoft.EntityFrameworkCore;

namespace DotnetOrderAI.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly dbContext dbContext;
        public PedidoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Pedido> AddPedido(Pedido pedido)
        {
            var result = await dbContext.TabelaPedido.AddAsync(pedido);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeletePedido(int Id)
        {
            var result = await dbContext.TabelaPedido.FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                dbContext.TabelaPedido.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Pedido> GetPedido(int Id)
        {
            return await dbContext.TabelaPedido.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await dbContext.TabelaPedido.ToListAsync();
        }

        public async Task<Pedido> UpdatePedido(Pedido pedido)
        {
            var result = await dbContext.TabelaPedido.FirstOrDefaultAsync(e => e.Id == pedido.Id);
            if (result != null)
            {
                result.ValorTotal = pedido.ValorTotal;
                result.FreteEntrega = pedido.FreteEntrega;
                result.DataPedido = pedido.DataPedido;
                result.DataEntrega = pedido.DataEntrega;
                

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
