using Magalu.Estoque.API.Consumers;
using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Application.UseCases.ObterItemPorId;
using Magalu.Estoque.Application.UseCases.ObterItens;
using Magalu.Estoque.Domain;
using Magalu.Estoque.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Magalu.Estoque.API.Module
{
    public static class EstoqueModule
    {
        public static IServiceCollection AddEstoqueModule(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseQuery<IEnumerable<Item>>, ObterItensUseCase>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IObterItemPorIdUseCaseQuery<Item, ObterItemPorIdDto>, ObterItemPorIdUseCase>();
            services.AddHostedService<BaixaEstoqueConsumer>();

            return services;
        }
    }
}
