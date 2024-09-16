using DotnetOrderAI.Models;

namespace DotnetOrderAI.Repository.Interface
{
    public interface IItemPedidoRepository
    {
        Task<IEnumerable<ItemPedido>> GetItensPedido();
        Task<ItemPedido> GetItemPedido(int itemId);
        Task<ItemPedido> AddItemPedido(ItemPedido user);
        Task<ItemPedido> UpdateItemPedido(ItemPedido user);
        void DeleteItemPedido(int itemId);
    }
}
