using AutoMapper;
using CadastroClienteWebService.Repository.Context;
using CadastroClienteWebService.Repository.Mapping;
using CadastroClienteWebService.Repository.Repositories;
using CadastroClienteWebService.UseCase.Implementacao;
using CadastroClienteWebService.UseCase.Interfaces.Repository;
using CadastroClienteWebService.UseCase.Interfaces.UseCase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroClienteWebService.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services, Profile profile)
        {
            services.AddTransient<ICadastroClienteUseCase, CadastroClienteUseCase>();
            services.AddTransient<ICadastroClienteRepository, CadastroClienteRepository>();

            services.AddDbContext<CadastroClienteContext>(options =>
               options.UseSqlServer(@"Server=DESKTOP-OJKSI8P\SQLEXPRESS;Database=ClienteDB;Integrated Security=True;Pooling=False"));// Mover para arquivo de configuração 

            var cfg = new MapperConfiguration(opts => {
                opts.AddProfile(profile);
                opts.AddProfile(new MappingProfileRepository());
            });
            services.AddSingleton(cfg.CreateMapper());
        }
    }
}
