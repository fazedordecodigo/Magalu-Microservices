using Magalu.Carrinho.Domain;

namespace Magalu.Carrinho.Application.Interfaces
{
    public interface IItemGateway
    {
        Task<Item?> GetItemByIdAsync(Guid id);
    }
}
