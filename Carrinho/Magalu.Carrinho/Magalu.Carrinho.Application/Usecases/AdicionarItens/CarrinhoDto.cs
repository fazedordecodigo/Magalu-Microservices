using Microsoft.AspNetCore.Mvc;

namespace Magalu.Carrinho.Application.Usecases.AdicionarItens
{
    public class CarrinhoDto
    {
        [FromRoute]
        public required Guid Id { get; init; }
        [FromBody]
        public required ItemDto[] Body { get; init; }
    }

    public class ItemDto
    {
        public required Guid Id { get; init; }
        public required string Nome { get; init; }
    }
}
