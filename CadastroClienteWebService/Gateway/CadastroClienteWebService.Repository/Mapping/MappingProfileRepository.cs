using AutoMapper;
using CadastroClienteWebService.Domain.Entidades;
using CadastroClienteWebService.Repository.Models;
using System;

namespace CadastroClienteWebService.Repository.Mapping
{
    public class MappingProfileRepository : Profile
    {
        public MappingProfileRepository()
        {
            CreateMap<Cliente, ClienteModel>();

            CreateMap<ClienteModel, Cliente>();
        }
    }
}
