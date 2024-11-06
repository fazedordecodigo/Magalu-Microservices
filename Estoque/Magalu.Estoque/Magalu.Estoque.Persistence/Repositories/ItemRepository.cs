using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;
using Magalu.Estoque.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Magalu.Estoque.Persistence.Repositories
{
    public class ItemRepository : IRepository<Item>
    {   
        private readonly ILogger<ItemRepository> _logger;
        private readonly EstoqueContext _context;

        public ItemRepository(EstoqueContext context, ILogger<ItemRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAll(int skip, int take)
        {
            try
            {
                return await _context.Items.AsNoTracking().Skip(skip).Take(take).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar itens");
                throw;
            }
        }
    }
}

