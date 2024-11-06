using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Application.UseCases.ObterItens
{
    public class ObterItensUseCase : IUseCaseQuery<Task<IEnumerable<Item>>>
    {
        private readonly IRepository<Item> _itemRepository;
        public ObterItensUseCase(IRepository<Item>  itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<IEnumerable<Item>> Handler()
        {
            return await _itemRepository.GetAll(1, 3);
        }
    }
}
