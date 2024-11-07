using Microsoft.Extensions.DependencyInjection;
using Magalu.Estoque.Domain;
using Magalu.Estoque.API.Consumers;
using Magalu.Estoque.Persistence.Contexts;
using Magalu.Estoque.Persistence.Repositories;
using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Application.UseCases.ObterItens;
using Magalu.Estoque.Application.UseCases.ObterItemPorId;

namespace Magalu.Estoque.API.Module
{
    public static class EstoqueModule
    {
        public static IServiceCollection AddEstoqueModule(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseQuery<ObterItensDto,Task<IEnumerable<Item>>>, ObterItensUseCase>();
            services.AddTransient<IRepository<Item>, ItemRepository>();
            services.AddTransient<RedisContext>();
            services.AddScoped<IObterItemPorIdUseCaseQuery<Task<IEnumerable<Item>>, ObterItemPorIdDto>, ObterItemPorIdUseCase>();
            services.AddHostedService<BaixaEstoqueConsumer>();
            services.Decorate(typeof(IRepository<>), typeof(CachedRepository<>));

            return services;
        }
    }
}
