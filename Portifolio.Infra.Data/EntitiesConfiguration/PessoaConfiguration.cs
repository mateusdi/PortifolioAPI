using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portifolio.Domain.Entities;


namespace Portifolio.Infra.Data.EntitiesConfiguration
{
    internal class PessoaConfiguration: IEntityTypeConfiguration<Pessoa>
    {


        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasAlternateKey(x => x.id);
            builder.Property(x => x.nome).HasMaxLength(255).IsRequired();
            builder.Property(x => x.email).HasMaxLength(255).IsRequired();

            //para evitar que seja inserido mais de um
            builder.HasIndex(x => x.email).IsUnique();
        }
    }
}
