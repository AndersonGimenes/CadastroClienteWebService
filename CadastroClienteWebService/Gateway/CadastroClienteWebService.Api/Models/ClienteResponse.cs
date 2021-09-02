namespace CadastroClienteWebService.Api.Models
{
    public class ClienteResponse : ClienteBase
    {
        public int Idade { get; set; }
        public string Nascimento { get; set; }
        public string Profissao { get; set; }
    }
}
