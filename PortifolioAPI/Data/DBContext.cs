using Microsoft.EntityFrameworkCore;
using PortifolioAPI.Model;

namespace PortifolioAPI.Data
{
    public class DBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conexaoStr = "Server=localhost;User Id=root;Password=1234;Database=portifolio";
                optionsBuilder.UseMySql(conexaoStr, ServerVersion.AutoDetect(conexaoStr));
            }
        }


        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
