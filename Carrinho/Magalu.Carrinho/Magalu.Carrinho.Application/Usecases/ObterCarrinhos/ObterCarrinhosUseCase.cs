using Magalu.Carrinho.Application.Interfaces;
using Magalu.Carrinho.Domain;

namespace Magalu.Carrinho.Application.Usecases.ObterCarrinhos
{
    public class ObterCarrinhosUseCase : IUseCaseQuery<IList<CarrinhoCompras>>
    {
        private readonly ICarrinhoRepository _carrinhoRepository;

        public ObterCarrinhosUseCase(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public IList<CarrinhoCompras> Handler()
        {
            return _carrinhoRepository.GetAll();
        }
    }
}
