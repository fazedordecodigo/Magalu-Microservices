using Magalu.Carrinho.Application.Interfaces;
using Magalu.Carrinho.Application.Settings;
using Magalu.Carrinho.Application.Usecases.AdicionarItens;
using Magalu.Carrinho.Application.Usecases.ObterCarrinhos;
using Magalu.Carrinho.Domain;
using Magalu.Carrinho.Persistence.Repositories;
using Magalu.Infraestructure.Gateways;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Magalu.Carrinho.API.Module
{
    public static class CarrinhoModule
    {
        public static IServiceCollection AddCarrinhoModule(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseCommand<CarrinhoDto>, AdicionarItensUseCase>();
            services.AddScoped<IItemGateway, ItemGateway>();
            services.AddSingleton<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<IUseCaseQuery<IList<CarrinhoCompras>>, ObterCarrinhosUseCase>();

            return services;
        }
    }
}
