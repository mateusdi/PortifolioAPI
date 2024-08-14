using Microsoft.EntityFrameworkCore;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Context;


namespace Portifolio.Infra.Data.Repositories
{
    public class ProjetoRepository : IProjeto
    {
        DBContext _context;

        public ProjetoRepository(DBContext context)
        {
            _context = context;
        }

        public async Task Create(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Projetos.FindAsync(id);

            _context.Projetos.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Projeto>> GetAllAsync()
        {
            return _context.Projetos.ToList();
        }

        public async Task<Projeto> GetByIdAsync(int id)
        {
            return await _context.Projetos.FindAsync(id);
        }

        public async Task Update(int id, Projeto projeto)
        {
            var existeProjeto = await _context.Projetos.FindAsync(id);
            var existePessoa = await _context.Pessoas.FindAsync(projeto.pessoaId);

            if (existeProjeto != null && existePessoa != null)
            {
                projeto.id = existeProjeto.id;
                _context.Entry(existeProjeto).CurrentValues.SetValues(projeto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
