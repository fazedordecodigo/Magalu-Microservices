
using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Application.UseCases.ObterItens;
using Magalu.Estoque.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Magalu.Estoque.API.Controllers
{
    [Route("itens")]
    [ApiController]
    public class EstoqueController: ControllerBase
    {
        private readonly IUseCaseQuery<ObterItensDto, Task<IEnumerable<Item>>> _useCaseQuery;
        public EstoqueController(IUseCaseQuery<ObterItensDto, Task<IEnumerable<Item>>> useCaseQuery)
        {
            _useCaseQuery = useCaseQuery;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ObterItensDto dto)
        {
            var result = await _useCaseQuery.Handler(dto);
            return Ok(result);
        }
    }
}
