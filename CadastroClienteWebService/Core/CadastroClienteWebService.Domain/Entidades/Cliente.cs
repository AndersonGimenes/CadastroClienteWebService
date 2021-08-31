namespace CadastroClienteWebService.Domain.Entidades
{
    class Cliente : Pessoa
    {
        public Profissao Profissao { get; private set; }
    }
}
