using Magalu.Estoque.Domain;
using Microsoft.EntityFrameworkCore;

namespace Magalu.Estoque.Persistence.Contexts
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {}

        public DbSet<Item> Items { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = Guid.NewGuid(), Nome = "Item 1"},
                new Item { Id = Guid.NewGuid(), Nome = "Item 2"},
                new Item { Id = Guid.NewGuid(), Nome = "Item 3"}

            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Estoque");
        }
    }
}
