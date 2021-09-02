using CadastroClienteWebService.Domain.Enums;
using System;

namespace CadastroClienteWebService.Api.Models
{
    public class ClienteRequest : ClienteBase
    {
        public DateTime Nascimento { get; set; }
        public Profissao Profissao { get; set; }
    }
}
