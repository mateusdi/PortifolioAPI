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

        public async Task<Pessoa> Create(Pessoa pessoa)
        {
             _context.Pessoas.Add(pessoa);
             await _context.SaveChangesAsync();

            return await Task.FromResult<Pessoa>(pessoa);


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
                pessoa.id = existePessoa.id;
                _context.Entry(existePessoa).CurrentValues.SetValues(pessoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
