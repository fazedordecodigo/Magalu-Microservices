using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Test.Fakes
{
    public class ItemRepositoryFake : IRepository<Item>
    {
        public async Task<IEnumerable<Item>> GetAll(int skip, int take)
        {
            return await Task.Run(
                () => new List<Item> { new() { Nome = "Item 1" } }
            );
        }
    }
}
