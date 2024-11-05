using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Magalu.Estoque.Persistence.Contexts
{
    public class EstoqueContextFactory: IDesignTimeDbContextFactory<EstoqueContext>
    {
        public EstoqueContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstoqueContext>();
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new EstoqueContext(optionsBuilder.Options);
        }
    }
}