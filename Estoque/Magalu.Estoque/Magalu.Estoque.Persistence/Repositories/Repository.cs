using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;
using Magalu.Estoque.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Magalu.Estoque.Persistence.Repositories
{
    public abstract class Repository<T>(EstoqueContext context, ILogger<Repository<T>> logger) : IRepository<T> where T : Entity
    {
        protected readonly EstoqueContext _context = context;
        protected readonly ILogger<Repository<T>> _logger = logger;

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T?> Get(Guid id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Get");
                throw;
            }

        }

        public async Task<IEnumerable<T>> GetAll(int skip, int take)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().Skip(skip).Take(take).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on GetAll");
                throw;
            }

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
