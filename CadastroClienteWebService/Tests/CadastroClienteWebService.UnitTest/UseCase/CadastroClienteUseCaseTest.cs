using CadastroClienteWebService.Domain.Entidades;
using CadastroClienteWebService.Domain.Enums;
using CadastroClienteWebService.Domain.Exception;
using CadastroClienteWebService.UseCase.Implementacao;
using CadastroClienteWebService.UseCase.Interfaces.Repository;
using Moq;
using System;
using Xunit;

namespace CadastroClienteWebService.UnitTest.UseCase
{
    public class CadastroClienteUseCaseTest
    {
        private readonly Mock<ICadastroClienteRepository> _cadastroClienteRepository;
        private readonly CadastroClienteUseCase _cadastroClienteUseCase;

        public CadastroClienteUseCaseTest()
        {
            _cadastroClienteRepository = new Mock<ICadastroClienteRepository>();
            _cadastroClienteUseCase = new CadastroClienteUseCase(_cadastroClienteRepository.Object);

        }

        [Fact]
        public void DadoDadosValidosDeveSerPersistidoClienteComSucesso()
        {
            var cliente = ConstruirCliente("Roberto", "Da Silva", "123.456.789-10");

            _cadastroClienteRepository
                .Setup(x => x.Inserir(It.IsAny<Cliente>()))
                .Returns(ConstruirCliente("Roberto", "Da Silva", "123.456.789-10", 1));

            var clienteResponse = _cadastroClienteUseCase.Inserir(cliente);

            Assert.Equal(1, clienteResponse.Id);
        }

        [Fact]
        public void DadoDadosValidosAIdadeDeveSerCalculada()
        {
            var cliente = ConstruirCliente("Roberto", "Da Silva", "123.456.789-10");
            var idade = new DateTime(DateTime.Now.Subtract(cliente.Nascimento).Ticks).Year - 1;

            _cadastroClienteRepository
                .Setup(x => x.Inserir(It.IsAny<Cliente>()))
                .Returns(ConstruirCliente("Roberto", "Da Silva", "123.456.789-10", 1));

            var clienteResponse = _cadastroClienteUseCase.Inserir(cliente);

            Assert.Equal(idade, clienteResponse.Idade);
        }

        [Theory]
        [InlineData("", "O campo Nome deve ser preenchido.")]
        [InlineData("TesteDaSilvaInacioCorreaSantadaDaMooca", "O campo Nome deve ter no maximo 30 caracteres.")]
        public void CasoONomeSejaVazioOuMaiorQueTrintaCaracteresDeveLancarUmExcecaoDeDominio(string nome, string result)
        {
            var cliente = ConstruirCliente(nome, "Da Silva", "123.456.789-10");

            var ex = Assert.Throws<DomainException>(() => _cadastroClienteUseCase.Inserir(cliente));
            Assert.Equal(result, ex.Message.Trim());
        }

        [Theory]
        [InlineData("", "O campo Sobrenome deve ser preenchido.")]
        [InlineData("TesteDaSilvaInacioCorreaSantadaDaMoocaTesteDaSilvaInacioCorreaSantadaDaMoocaTesteDaSilvaInacioCorreaSantadaDaMoocaTesteDaSilvaInacioCorreaSantadaDaMooca", "O campo Sobrenome deve ter no maximo 100 caracteres.")]
        public void CasoOSobreNomeSejaVazioOuMaiorQueCemCaracteresDeveLancarUmExcecaoDeDominio(string sobreNome, string result)
        {
            var cliente = ConstruirCliente("Roberto", sobreNome, "123.456.789-10");

            var ex = Assert.Throws<DomainException>(() => _cadastroClienteUseCase.Inserir(cliente));
            Assert.Equal(result, ex.Message.Trim());
        }

        [Fact]
        public void CasoOCpfEstejaForaDaMascaraPadraoDeveLancarUmExcecaoDeDominio()
        {
            var cliente = ConstruirCliente("Roberto", "Da Silva", "12345678910");

            var ex = Assert.Throws<DomainException>(() => _cadastroClienteUseCase.Inserir(cliente));
            Assert.Equal("Formato CPF incorreto por favor utilize o seguinte formato: 123.456.789-10.", ex.Message.Trim());
        }

        private Cliente ConstruirCliente(string nome, string sobrenome, string cpf, int id = default) => 
            new Cliente(id, nome, sobrenome, cpf, new DateTime(1990, 06, 01), Profissao.Programador);
    }
}