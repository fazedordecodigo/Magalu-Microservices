using Magalu.Carrinho.Application.Interfaces;
using Magalu.Carrinho.Domain;

namespace Magalu.Carrinho.Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IList<T> _values;
        protected Repository()
        {
            _values = [];
        }

        public void Add(T entity)
        {
            _values.Add(entity);
        }

        public void Delete(T entity)
        {
            _values.Remove(entity);
        }

        public T Get(Guid id)
        {
            var result = _values.FirstOrDefault(x => x.Id == id);
            return result is null ? throw new ArgumentException("Item não existe") : result;
        }

        public IList<T> GetAll()
        {
            return _values;
        }

        public void Update(T entity)
        {
            var result = Get(entity.Id);
            Delete(result);
            Add(entity);
        }
    }
}
