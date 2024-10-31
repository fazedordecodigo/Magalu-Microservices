using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Application.UseCases.ObterItens
{
    public class ObterItensUseCase : IUseCaseQuery<IList<Item>>
    {
        private readonly IItemRepository _itemRepository;
        public ObterItensUseCase(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IList<Item> Handler()
        {
            return _itemRepository.GetAll();
        }
    }
}
