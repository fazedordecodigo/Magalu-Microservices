
using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Magalu.Estoque.API.Controllers
{
    [Route("itens")]
    [ApiController]
    public class EstoqueController: ControllerBase
    {
        private readonly IUseCaseQuery<Task<IEnumerable<Item>>> _useCaseQuery;
        public EstoqueController(IUseCaseQuery<Task<IEnumerable<Item>>> useCaseQuery)
        {
            _useCaseQuery = useCaseQuery;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _useCaseQuery.Handler();
            return Ok(result);
        }
    }
}
