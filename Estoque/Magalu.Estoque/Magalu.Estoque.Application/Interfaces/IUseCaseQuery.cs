namespace Magalu.Estoque.Application.Interfaces
{
    public interface IUseCaseQuery<out T> where T : class
    {
        T Handler();
    }
}
