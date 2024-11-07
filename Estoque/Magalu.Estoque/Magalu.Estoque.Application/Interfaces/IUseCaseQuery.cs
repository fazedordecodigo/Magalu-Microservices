namespace Magalu.Estoque.Application.Interfaces
{
    public interface IUseCaseQuery<in T, out U> where T : class where U : class
    {
        U Handler(T request);
    }
}
