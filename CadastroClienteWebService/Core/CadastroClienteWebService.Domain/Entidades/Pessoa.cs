using System;

namespace CadastroClienteWebService.Domain.Entidades
{
    public abstract class Pessoa
    {
        protected Pessoa(int id, string nome, string sobrenome, string cpf, DateTime nascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Nascimento = nascimento;
        }

        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Cpf { get; protected set; }
        public DateTime Nascimento { get; protected set; }
        public int Idade { get => new DateTime(DateTime.Now.Subtract(Nascimento).Ticks).Year; }
    }
}
