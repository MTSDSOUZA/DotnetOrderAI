using DotnetOrderAI.Data;
using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DotnetOrderAI.Repository
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly dbContext dbContext;
        public ItemPedidoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ItemPedido> AddItemPedido(ItemPedido itempedido)
        {
            var result = await dbContext.TabelaItemPedido.AddAsync(itempedido);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteItemPedido(int Id)
        {
            var result = await dbContext.TabelaItemPedido.FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                dbContext.TabelaItemPedido.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<ItemPedido> GetItemPedido(int Id)
        {
            return await dbContext.TabelaItemPedido.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<ItemPedido>> GetItensPedido()
        {
            return await dbContext.TabelaItemPedido.ToListAsync();
        }

        public async Task<ItemPedido> UpdateItemPedido(ItemPedido itempedido)
        {
            var result = await dbContext.TabelaItemPedido.FirstOrDefaultAsync(e => e.Id == itempedido.Id);
            if (result != null)
            {
                result.nome = itempedido.nome;
                result.descricao = itempedido.descricao;
                result.quantidade = itempedido.quantidade;
                result.preco = itempedido.preco;
                result.recomendacao = itempedido.recomendacao;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
