using CadastroClienteWebService.Domain.Enums;
using CadastroClienteWebService.Domain.Validate;
using System;

namespace CadastroClienteWebService.Domain.Entidades
{
    public class Cliente : Pessoa
    {
        public Cliente(int id, string nome, string sobrenome, string cpf, DateTime nascimento, Profissao profissao) 
            : base(id, nome, sobrenome, cpf, nascimento)
        {
            Profissao = profissao;
        }

        public Profissao Profissao { get; private set; }

        public Cliente IsValid()
        {
            new ClienteValidation(this);
            return this;
        }
        public void AdicionarMascaraCpf()
        {
            Cpf = Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00");
        }

        public void RemoverMascaraCpf()
        {
            Cpf = Cpf.Replace(".", string.Empty).Replace("-", string.Empty);
        }
    }
}
