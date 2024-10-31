namespace Magalu.Carrinho.Application.Interfaces
{
    public interface IUseCaseQuery<out T> where T : class
    {
        T Handler();
    }
}
