
using Microsoft.EntityFrameworkCore;
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

        public void Create(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public void Update(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

      
    }
}
