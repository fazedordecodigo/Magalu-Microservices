using Magalu.Estoque.Domain;
using Microsoft.EntityFrameworkCore;

namespace Magalu.Estoque.Persistence.Contexts
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {}

        public DbSet<Item> Items { get; set; }
    }
}
