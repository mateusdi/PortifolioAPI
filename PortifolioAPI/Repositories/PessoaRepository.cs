using PortifolioAPI.Model;
using PortifolioAPI.Models;

namespace PortifolioAPI.Dados
{
    public class PessoaRepository : IPessoa
    {
        private readonly DBContext _context =  new DBContext();
        public void Add(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
        }

        public List<Pessoa> Get()
        {
            return _context.Pessoas.ToList();
        }
    }
}
