using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;

namespace Magalu.Estoque.Persistence.Repositories
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

        public T? Get(Guid id)
        {
            return _values.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> GetAll()
        {
            return _values;
        }

        public void Update(T entity)
        {
            var result = Get(entity.Id);
            if (result is not null)
            {
                Delete(result);
                Add(entity);
            }
        }
    }
}
