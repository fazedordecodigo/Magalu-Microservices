using Magalu.Carrinho.Application.Interfaces;
using Magalu.Carrinho.Domain;

namespace Magalu.Carrinho.Persistence.Repositories
{
    public class CarrinhoRepository : Repository<CarrinhoCompras>, ICarrinhoRepository
    {
        public CarrinhoRepository()
        {
            var car1 = new CarrinhoCompras();
            var car2 = new CarrinhoCompras();
            var car3 = new CarrinhoCompras();

            Add(car1);
            Add(car2);
            Add(car3);
        }

        public void AddRangeItem(Guid carrinhoId, IList<Item> itens)
        {
            _ = _values.FirstOrDefault(x => x.Id == carrinhoId);
        }
    }
}
