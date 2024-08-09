using Microsoft.EntityFrameworkCore;
using Portifolio.Domain.Entities;

namespace Portifolio.Infra.Data.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
        }


    }
}
