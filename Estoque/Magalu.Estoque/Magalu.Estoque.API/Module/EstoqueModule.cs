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
            services.AddScoped<IUseCaseQuery<IList<Item>>, ObterItensUseCase>();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddScoped<IObterItemPorIdUseCaseQuery<Item, ObterItemPorIdDto>, ObterItemPorIdUseCase>();

            return services;
        }
    }
}
