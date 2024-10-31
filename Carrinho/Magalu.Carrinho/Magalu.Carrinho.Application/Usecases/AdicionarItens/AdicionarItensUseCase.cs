using Magalu.Carrinho.Application.Interfaces;
using Magalu.Carrinho.Domain;

namespace Magalu.Carrinho.Application.Usecases.AdicionarItens
{
    public class AdicionarItensUseCase : IUseCaseCommand<CarrinhoDto>
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IPublisher<CarrinhoCompras> _publisher;
        private readonly IItemGateway _itemGateway;

        public AdicionarItensUseCase(ICarrinhoRepository carrinhoRepository, IItemGateway itemGateway, IPublisher<CarrinhoCompras> publisher)
        {
            _carrinhoRepository = carrinhoRepository;
            _publisher = publisher;
            _itemGateway = itemGateway;
        }

        public async Task Handler(CarrinhoDto itens)
        {
            var carrinho = _carrinhoRepository.Get(itens.Id);
            foreach (var item in itens.Body)
            {
                var result = await _itemGateway.GetItemByIdAsync(item.Id) ?? throw new ArgumentException("Item não existe");
                carrinho.AdicionarItem(result);
            }
            _carrinhoRepository.Update(carrinho);
            await _publisher.PublishAsync(carrinho, "baixa_estoque");
        }
    }
}
