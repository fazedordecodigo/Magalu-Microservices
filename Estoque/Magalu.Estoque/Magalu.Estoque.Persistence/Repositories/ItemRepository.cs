using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;
using Magalu.Estoque.Persistence.Contexts;

namespace Magalu.Estoque.Persistence.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(EstoqueContext context): base(context)
        { }
    }
}
