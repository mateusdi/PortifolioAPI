using Microsoft.EntityFrameworkCore;
using PortifolioAPI.Models;

namespace PortifolioAPI.infrastructure
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
