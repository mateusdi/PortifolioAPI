using Microsoft.EntityFrameworkCore;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio.Infra.Data.Repositories
{
    public class ProjetoRepository : IProjeto
    {
        DBContext _context;

        public ProjetoRepository(DBContext context)
        {
            _context = context;
        }

        public async void Create(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
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

        public async void Update(Projeto projeto)
        {
            _context.Projetos.Entry(projeto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
