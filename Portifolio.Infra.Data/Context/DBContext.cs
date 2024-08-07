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

      
    }
}
