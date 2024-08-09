using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Portifolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio.Infra.Data.EntitiesConfiguration
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Projeto> builder)
        {
            builder.HasAlternateKey(x => x.id);
            builder.Property(x => x.descricao).HasMaxLength(255).IsRequired();
            builder.Property(x => x.nome).HasMaxLength(50).IsRequired();

            //definoo relacionamento 1 para muitos
            builder.HasOne(x => x.pessoa).WithMany(x => x.projetos).HasForeignKey(x => x.pessoaId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
