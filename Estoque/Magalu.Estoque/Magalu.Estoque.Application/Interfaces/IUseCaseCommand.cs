namespace Magalu.Estoque.Application.Interfaces
{
    public interface IUseCaseCommand<in T> where T : class
    {
        void Handler(T itens);
    }
}
