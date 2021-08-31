using CadastroClienteWebService.UseCase.Implementacao;
using CadastroClienteWebService.UseCase.Interfaces.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroClienteWebService.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services)
        {
            // aqui configurar injeção de dependencia
            services.AddTransient<ICadastroClienteUseCase, CadastroClienteUseCase>();
        }
    }
}
