using Magalu.Carrinho.Application.Interfaces;
using Magalu.Carrinho.Application.Usecases.AdicionarItens;
using Magalu.Carrinho.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Magalu.Carrinho.API.Controllers
{
    [Route("carrinhos")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IUseCaseCommand<CarrinhoDto> _useCaseCommand;
        private readonly IUseCaseQuery<IList<CarrinhoCompras>> _useCaseQuery;

        public CarrinhoController(IUseCaseCommand<CarrinhoDto> useCaseCommand, IUseCaseQuery<IList<CarrinhoCompras>> useCaseQuery)
        {
            _useCaseCommand = useCaseCommand;
            _useCaseQuery = useCaseQuery;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_useCaseQuery.Handler());
        }

        [HttpPost("{Id}/itens")]
        public IActionResult Post(CarrinhoDto request)
        {
            _useCaseCommand.Handler(request);
            return Ok();
        }
    }
}
