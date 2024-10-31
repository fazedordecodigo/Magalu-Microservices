namespace Magalu.Estoque.Application.UseCases.ObterItens
{
    public class ItensQueryDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
