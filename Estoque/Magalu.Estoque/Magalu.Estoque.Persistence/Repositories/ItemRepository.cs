using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Persistence.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository()
        {
            Add(new Item { Id = Guid.NewGuid(), Nome = "Item 1" });
            Add(new Item { Id = Guid.NewGuid(), Nome = "Item 2" });
            Add(new Item { Id = Guid.NewGuid(), Nome = "Item 3" });
            Add(new Item { Id = Guid.NewGuid(), Nome = "Item 4" });
            Add(new Item { Id = Guid.NewGuid(), Nome = "Item 5" });
        }
    }
}
