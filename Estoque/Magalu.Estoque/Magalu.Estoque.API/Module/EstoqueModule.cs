using Magalu.Estoque.API.Consumers;
using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Application.UseCases.ObterItemPorId;
using Magalu.Estoque.Application.UseCases.ObterItens;
using Magalu.Estoque.Domain;
using Magalu.Estoque.Persistence.Contexts;
using Magalu.Estoque.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Magalu.Estoque.API.Module
{
    public static class EstoqueModule
    {
        public static IServiceCollection AddEstoqueModule(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseQuery<Task<IEnumerable<Item>>>, ObterItensUseCase>();
            services.AddTransient<IRepository<Item>, ItemRepository>();
            services.AddTransient<RedisContext>();
            services.AddScoped<IObterItemPorIdUseCaseQuery<Task<IEnumerable<Item>>, ObterItemPorIdDto>, ObterItemPorIdUseCase>();
            services.AddHostedService<BaixaEstoqueConsumer>();
            services.Decorate(typeof(IRepository<>), typeof(CachedRepository<>));

            return services;
        }
    }
}
