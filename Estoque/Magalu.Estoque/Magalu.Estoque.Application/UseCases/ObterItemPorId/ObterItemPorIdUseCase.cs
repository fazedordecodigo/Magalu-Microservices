using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Application.UseCases.ObterItemPorId
{
    public class ObterItemPorIdUseCase : IObterItemPorIdUseCaseQuery<Task<IEnumerable<Item>>, ObterItemPorIdDto>
    {
        private readonly IRepository<Item> _itemRepository;

        public ObterItemPorIdUseCase(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> Handler(ObterItemPorIdDto query)
        {
            return await _itemRepository.GetAll(1,5);
        }
    }
}
