
using PortifolioAPI.Data;
using PortifolioAPI.Interfaces;
using PortifolioAPI.Model;



namespace PortifolioAPI.Respositories
{
    public class PessoaRepository : IPessoa
    {
        DBContext _context;

        public PessoaRepository(DBContext context)
        {
            _context = context;
        }

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
