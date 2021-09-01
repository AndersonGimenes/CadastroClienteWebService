using CadastroClienteWebService.Domain.Entidades;
using System.Collections.Generic;

namespace CadastroClienteWebService.UseCase.Interfaces.UseCase
{
    public interface ICadastroClienteUseCase
    {
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        Cliente Inserir(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Deletar(Cliente cliente);
    }
}
