using DotnetOrderAI.Models;

namespace DotnetOrderAI.Repository.Interface
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetPedidos();
        Task<Pedido> GetPedido(int pedidoId);
        Task<Pedido> AddPedido(Pedido pedido);
        Task<Pedido> UpdatePedido(Pedido pedido);
        void DeletePedido(int pedidoId);
    }
}
