using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClienteWebService.Repository.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        public int? Profissao { get; set; }        
    }
}
