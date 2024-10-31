using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Application.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T? Get(Guid id);
        IList<T> GetAll();
    }
}
