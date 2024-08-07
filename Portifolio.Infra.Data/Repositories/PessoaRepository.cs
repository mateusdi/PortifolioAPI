using Microsoft.EntityFrameworkCore;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Context;



namespace Portifolio.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoa
    {

        DBContext _context;
        
        public PessoaRepository(DBContext context)
        {
            _context = context;
        }

        public async void Create(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)  
        {
                var item = await _context.Pessoas.FindAsync(id);

                _context.Pessoas.Remove(item);
                await _context.SaveChangesAsync();
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            return _context.Pessoas.ToList();
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async void Update(Pessoa pessoa)
        {
            _context.Pessoas.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
