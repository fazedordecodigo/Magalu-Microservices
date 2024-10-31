
using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Application.UseCases.ObterItemPorId;
using Magalu.Estoque.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Magalu.Estoque.API.Controllers
{
    [Route("itens")]
    [ApiController]
    public class EstoqueController: ControllerBase
    {
        private readonly IUseCaseQuery<IList<Item>> _useCaseQuery;
        private readonly IObterItemPorIdUseCaseQuery<Item, ObterItemPorIdDto> _obterItemPorIdUseCaseQuery;
        public EstoqueController(IUseCaseQuery<IList<Item>> useCaseQuery, IObterItemPorIdUseCaseQuery<Item, ObterItemPorIdDto> obterItemPorIdUseCaseQuery)
        {
            _useCaseQuery = useCaseQuery;
            _obterItemPorIdUseCaseQuery = obterItemPorIdUseCaseQuery;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_useCaseQuery.Handler());
        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute] ObterItemPorIdDto route)
        {
            return Ok(_obterItemPorIdUseCaseQuery.Handler(route));
        }
    }
}
