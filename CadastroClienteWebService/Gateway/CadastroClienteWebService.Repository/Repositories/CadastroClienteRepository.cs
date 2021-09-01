using AutoMapper;
using CadastroClienteWebService.Domain.Entidades;
using CadastroClienteWebService.Repository.Context;
using CadastroClienteWebService.Repository.Models;
using CadastroClienteWebService.UseCase.Interfaces.Repository;
using System;

namespace CadastroClienteWebService.Repository.Repositories
{
    public class CadastroClienteRepository : ICadastroClienteRepository
    {
        private readonly CadastroClienteContext _context;
        private readonly IMapper _mapper;

        public CadastroClienteRepository(CadastroClienteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Cliente Inserir(Cliente cliente)
        {
            var clienteModel = _mapper.Map<ClienteModel>(cliente);

            _context.Clientes.Add(clienteModel);

            _context.SaveChanges();

            return _mapper.Map<Cliente>(clienteModel);
        }
    }
}
