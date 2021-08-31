using System;

namespace CadastroClienteWebService.Domain.Entidades
{
    public abstract class Pessoa
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Cpf { get; protected set; }
        public DateTime Nascimento { get; protected set; }
        public int Idade { get; protected set; }
    }
}
