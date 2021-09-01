using CadastroClienteWebService.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClienteWebService.Repository.Configuration
{
    class ClienteModelConfiguration : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder
                .ToTable("Clientes");

            builder
                .HasKey(x => x.Id)
                .HasName("Pk_Cliente");

            builder
                .Property(x => x.Nome)
                .HasColumnType("VARCHAR(30)")
                .IsRequired();

            builder
                .Property(x => x.Sobrenome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder
                .Property(x => x.Cpf)
                .HasColumnType("VARCHAR(11)")
                .IsRequired();

            builder
                .Property(x => x.Nascimento)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder
                .Property(x => x.Idade)
                .HasColumnType("INT")
                .IsRequired();

            builder
                .Property(x => x.Profissao)
                .HasColumnType("INT")
                .HasDefaultValue(null);
        }
    }
}
