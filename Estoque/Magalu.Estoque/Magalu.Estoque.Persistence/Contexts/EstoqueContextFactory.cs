using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Magalu.Estoque.Persistence.Contexts
{
    public class EstoqueContextFactory: IDesignTimeDbContextFactory<EstoqueContext>
    {
        public EstoqueContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstoqueContext>();

            optionsBuilder.UseSqlite("Data Source=app.db");

            return new EstoqueContext(optionsBuilder.Options);
        }
    }
}