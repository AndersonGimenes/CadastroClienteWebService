using CadastroClienteWebService.Domain.Entidades;

namespace CadastroClienteWebService.UseCase.Interfaces.Repository
{
    public interface ICadastroClienteRepository
    {
        public Cliente Inserir(Cliente cliente);
    }
}
