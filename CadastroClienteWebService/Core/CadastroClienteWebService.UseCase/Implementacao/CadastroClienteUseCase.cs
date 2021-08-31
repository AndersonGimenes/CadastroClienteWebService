using CadastroClienteWebService.Domain.Entidades;
using CadastroClienteWebService.UseCase.Interfaces.Repository;
using CadastroClienteWebService.UseCase.Interfaces.UseCase;
using System.Collections.Generic;

namespace CadastroClienteWebService.UseCase.Implementacao
{
    public class CadastroClienteUseCase : ICadastroClienteUseCase
    {
        private readonly ICadastroClienteRepository _cadastroClienteRepository;

        public CadastroClienteUseCase(ICadastroClienteRepository cadastroClienteRepository)
        {
            _cadastroClienteRepository = cadastroClienteRepository;
        }

        public void Atualizar(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public Cliente Inserir(Cliente cliente)
        {
            cliente.IsValid();

            return _cadastroClienteRepository.Inserir(cliente);
        }

        public Cliente ObterPrId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
