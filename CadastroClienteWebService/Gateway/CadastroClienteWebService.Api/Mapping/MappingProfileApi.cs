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

            CreateMap<Cliente, ClienteResponse>()
                .ForMember(dest => dest.Nascimento, opts => opts.MapFrom(x => x.Nascimento.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Profissao, opts => opts.MapFrom(x => x.Profissao.ToString()));
        }
    }
}
