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

        public Cliente Atualizar(Cliente cliente)
        {
            cliente
                .IsValid()
                .RemoverMascaraCpf();

            var clienteResponse = _cadastroClienteRepository.Atualizar(cliente);
            clienteResponse.AdicionarMascaraCpf();

            return clienteResponse;
        }

        public void Deletar(Cliente cliente)
        {
            _cadastroClienteRepository.Deletar(cliente);
        }

        public Cliente Inserir(Cliente cliente)
        {
            cliente
                .IsValid()
                .RemoverMascaraCpf();

            var clienteResponse = _cadastroClienteRepository.Inserir(cliente);
            clienteResponse.AdicionarMascaraCpf();

            return clienteResponse;
        }

        public Cliente ObterPorId(int id) => _cadastroClienteRepository.ObterPorId(id);

        public IEnumerable<Cliente> ObterTodos() => _cadastroClienteRepository.ObterTodos();
    }
}
