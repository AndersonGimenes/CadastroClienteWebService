using CadastroClienteWebService.Domain.Entidades;
using System.Collections.Generic;

namespace CadastroClienteWebService.UseCase.Interfaces.Repository
{
    public interface ICadastroClienteRepository
    {
        Cliente Inserir(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Deletar(int id);
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
    }
}
