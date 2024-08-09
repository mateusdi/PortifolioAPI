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

        public async Task Create(Pessoa pessoa)
        {
             _context.Pessoas.Add(pessoa);
             await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)  
        {
                var pessoa = await _context.Pessoas.FindAsync(id);

                _context.Pessoas.Remove(pessoa);
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

        public async Task Update(int id, Pessoa pessoa)
        {
            var existePessoa = await _context.Pessoas.FindAsync(id);

            if (existePessoa != null)
            {
                if (pessoa.id == null)
                {
                    pessoa.id = id;
                }
                
                 _context.Pessoas.Update(pessoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
