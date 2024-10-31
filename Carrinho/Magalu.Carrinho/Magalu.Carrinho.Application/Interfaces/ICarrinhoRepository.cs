using Magalu.Carrinho.Domain;

namespace Magalu.Carrinho.Application.Interfaces
{
    public interface ICarrinhoRepository : IRepository<CarrinhoCompras>
    {
        void AddRangeItem(Guid carrinhoId, IList<Item> itens);
    }
}
