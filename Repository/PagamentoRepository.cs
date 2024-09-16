using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using DotnetOrderAI.Data;
using Microsoft.EntityFrameworkCore;

namespace DotnetOrderAI.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly dbContext dbContext;
        public PagamentoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Pagamento> AddPagamento(Pagamento pagamento)
        {
            var result = await dbContext.TabelaPagamento.AddAsync(pagamento);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeletePagamento(int Id)
        {
            var result = await dbContext.TabelaPagamento.FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                dbContext.TabelaPagamento.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Pagamento> GetPagamento(int Id)
        {
            return await dbContext.TabelaPagamento.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Pagamento>> GetPagamentos()
        {
            return await dbContext.TabelaPagamento.ToListAsync();
        }

        public async Task<Pagamento> UpdatePagamento(Pagamento pagamento)
        {
            var result = await dbContext.TabelaPagamento.FirstOrDefaultAsync(e => e.Id == pagamento.Id);
            if (result != null)
            {
                result.num_cartao = pagamento.num_cartao;
                result.nome_cartao = pagamento.nome_cartao;
                result.data_validade = pagamento.data_validade;
                result.cvv = pagamento.cvv;
                result.apelido_cartao = pagamento.apelido_cartao;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
