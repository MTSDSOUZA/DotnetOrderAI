using DotnetOrderAI.Models;

namespace DotnetOrderAI.Repository.Interface
{
    public interface IPagamentoRepository
    {
        Task<IEnumerable<Pagamento>> GetPagamentos();
        Task<Pagamento> GetPagamento(int Id);
        Task<Pagamento> AddPagamento(Pagamento pagamento);
        Task<Pagamento> UpdatePagamento(Pagamento pagamento);
        void DeletePagamento(int Id);
    }
}
