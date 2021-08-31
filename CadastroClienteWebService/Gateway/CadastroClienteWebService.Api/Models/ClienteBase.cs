using CadastroClienteWebService.Domain.Enums;
using System;

namespace CadastroClienteWebService.Api.Models
{
    public abstract class ClienteBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime Nascimento { get; set; }
        public Profissao Profissao { get; set; }
    }
}