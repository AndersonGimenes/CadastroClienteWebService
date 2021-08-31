using CadastroClienteWebService.Domain.Entidades;
using CadastroClienteWebService.Domain.Exception;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CadastroClienteWebService.Domain.Validate
{
    internal class ClienteValidation
    {
        private StringBuilder _sb = new StringBuilder();
        
        internal ClienteValidation(Cliente cliente)
        {
            ValidarNullOrEmpty(cliente.Nome, nameof(Cliente.Nome));
            ValidarNullOrEmpty(cliente.Sobrenome, nameof(Cliente.Sobrenome));

            ValidarQuantidadeCaracteres(cliente.Nome, 30, nameof(Cliente.Nome));
            ValidarQuantidadeCaracteres(cliente.Sobrenome, 100, nameof(Cliente.Sobrenome));

            ValidarMascaraCpf(cliente.Cpf);

            ConstruirException();
        }
        
        private void ValidarNullOrEmpty(string valor, string paramName)
        {
            if (string.IsNullOrWhiteSpace(valor))
                _sb.Append($"O campo {paramName} deve ser preenchido. {Environment.NewLine}");
        }

        private void ValidarQuantidadeCaracteres(string valor, int tamanho, string paramName)
        {
            if (valor.Length > tamanho)
                _sb.Append($"O campo {paramName} deve ter no maximo {tamanho} caracteres. {Environment.NewLine}");
        }

        private void ValidarMascaraCpf(string cpf)
        {
            var pattern = @"\d{3}.\d{3}.\d{3}-\d{2}";
           
            if (!Regex.IsMatch(cpf, pattern))
                _sb.Append($"Formato CPF incorreto por favor utilize o seguinte formato: 123.456.789-10. {Environment.NewLine}");
        }

        private void ConstruirException()
        {
            if (_sb.Length > 0)
                throw new DomainException(_sb.ToString());
        }
    }
}
