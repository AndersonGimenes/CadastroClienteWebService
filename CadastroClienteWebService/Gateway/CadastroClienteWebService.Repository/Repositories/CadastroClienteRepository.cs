using AutoMapper;
using CadastroClienteWebService.Domain.Entidades;
using CadastroClienteWebService.Repository.Context;
using CadastroClienteWebService.Repository.Models;
using CadastroClienteWebService.UseCase.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public Cliente Atualizar(Cliente cliente)
        {
            var clienteModel = _mapper.Map<ClienteModel>(cliente);

            _context.Clientes.Update(clienteModel);

            _context.SaveChanges();

            return _mapper.Map<Cliente>(clienteModel);
        }

        public void Deletar(Cliente cliente)
        {
            var clienteModel = _mapper.Map<ClienteModel>(cliente);

            _context.Clientes.Remove(clienteModel);

            _context.SaveChanges();
        }

        public Cliente Inserir(Cliente cliente)
        {
            var clienteModel = _mapper.Map<ClienteModel>(cliente);

            _context.Clientes.Add(clienteModel);

            _context.SaveChanges();

            return _mapper.Map<Cliente>(clienteModel);
        }

        public Cliente ObterPorId(int id)
        {
            var clienteModel = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == id);

            return _mapper.Map<Cliente>(clienteModel);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            var clientesModel = _context.Clientes.AsNoTracking().ToList();
            
            return _mapper.Map<IEnumerable<Cliente>>(clientesModel);
        }
    }
}
