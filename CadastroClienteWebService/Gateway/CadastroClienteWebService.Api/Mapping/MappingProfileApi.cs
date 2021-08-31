using AutoMapper;
using CadastroClienteWebService.Api.Models;
using CadastroClienteWebService.Domain.Entidades;

namespace CadastroClienteWebService.Api.Mapping
{
    public class MappingProfileApi : Profile
    {
        public MappingProfileApi()
        {
            CreateMap<ClienteRequest, Cliente>();

            CreateMap<Cliente, ClienteResponse>();
        }
    }
}
