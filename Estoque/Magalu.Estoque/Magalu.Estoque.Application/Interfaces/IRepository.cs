using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll(int skip, int take);
    }
}
