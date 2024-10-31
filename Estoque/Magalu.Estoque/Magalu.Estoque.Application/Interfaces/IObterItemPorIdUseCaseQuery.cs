namespace Magalu.Estoque.Application.Interfaces
{
    public interface IObterItemPorIdUseCaseQuery<out T, in U> where T : class where U : class
    {
        T Handler(U query);
    }
}
