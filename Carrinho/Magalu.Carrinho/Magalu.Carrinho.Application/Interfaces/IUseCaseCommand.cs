namespace Magalu.Carrinho.Application.Interfaces
{
    public interface IUseCaseCommand<in T> where T : class
    {
        Task Handler(T itens);
    }
}
