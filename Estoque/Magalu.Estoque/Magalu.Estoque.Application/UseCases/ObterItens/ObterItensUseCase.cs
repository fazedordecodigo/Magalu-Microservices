using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Application.UseCases.ObterItens
{
    public class ObterItensUseCase : IUseCaseQuery<IEnumerable<Item>>
    {
        private readonly IItemRepository _itemRepository;
        public ObterItensUseCase(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IEnumerable<Item> Handler()
        {
            return _itemRepository.GetAll(1, 3);
        }
    }
}
