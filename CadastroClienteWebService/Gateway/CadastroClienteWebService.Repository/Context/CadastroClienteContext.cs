using CadastroClienteWebService.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CadastroClienteWebService.Repository.Context
{
    public class CadastroClienteContext : DbContext
    {
        public CadastroClienteContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
