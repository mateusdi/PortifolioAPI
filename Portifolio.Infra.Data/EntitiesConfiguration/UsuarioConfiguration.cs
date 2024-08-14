using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portifolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio.Infra.Data.EntitiesConfiguration
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.HasAlternateKey(x => x.id);
            builder.Property(x => x.login).HasMaxLength(255).IsRequired();
            builder.Property(x => x.passwordHash).HasMaxLength(255).IsRequired();
            builder.Property(x => x.passwordSalt).HasMaxLength(255).IsRequired();

            //para evitar que seja inserido mais de um
            builder.HasIndex(x => x.login).IsUnique();

            //definoo relacionamento 1:1 um para um
            builder.HasOne(x => x.pessoa).WithOne(x => x.usuario).HasForeignKey<Usuario>(x => x.pessoaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            
            

        }

    }
}
