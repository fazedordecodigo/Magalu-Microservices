using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;
using Magalu.Estoque.Persistence.Contexts;

namespace Magalu.Estoque.Persistence.Repositories
{
    public abstract class Repository<T>(EstoqueContext context) : IRepository<T> where T : Entity
    {
        protected readonly EstoqueContext _context = context;

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T? Get(Guid id)
        {
           return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll(int skip, int take)
        {
            return [.. _context.Set<T>().Skip(skip).Take(take)];
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
