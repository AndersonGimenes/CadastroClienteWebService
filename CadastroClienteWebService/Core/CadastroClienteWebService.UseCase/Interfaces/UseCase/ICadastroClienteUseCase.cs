using CadastroClienteWebService.Domain.Entidades;
using System.Collections.Generic;

namespace CadastroClienteWebService.UseCase.Interfaces.UseCase
{
    public interface ICadastroClienteUseCase
    {
        Cliente ObterPrId(int id);
        IEnumerable<Cliente> ObterTodos();
        Cliente Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Deletar(Cliente cliente);
    }
}
