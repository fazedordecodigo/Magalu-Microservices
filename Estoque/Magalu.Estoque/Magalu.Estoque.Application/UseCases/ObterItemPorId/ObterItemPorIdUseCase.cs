using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Application.UseCases.ObterItemPorId
{
    public class ObterItemPorIdUseCase : IObterItemPorIdUseCaseQuery<Item, ObterItemPorIdDto>
    {
        private readonly IItemRepository _itemRepository;

        public ObterItemPorIdUseCase(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Item Handler(ObterItemPorIdDto query)
        {
            return _itemRepository.Get(query.Id);
        }
    }
}
