using AutoMapper;
using CadastroClienteWebService.Repository.Repositories;
using CadastroClienteWebService.UseCase.Implementacao;
using CadastroClienteWebService.UseCase.Interfaces.Repository;
using CadastroClienteWebService.UseCase.Interfaces.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroClienteWebService.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services, Profile profile)
        {
            services.AddTransient<ICadastroClienteUseCase, CadastroClienteUseCase>();
            services.AddTransient<ICadastroClienteRepository, CadastroClienteRepository>();

            var cfg = new MapperConfiguration(opts => {
                opts.AddProfile(profile);
            });
            services.AddSingleton(cfg.CreateMapper());
        }
    }
}
