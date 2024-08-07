using Microsoft.EntityFrameworkCore;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Context;

namespace Portifolio.Infra.Data.Repositories
{
    public class GenericoRepository<TEntity> : IGenerica<TEntity> where TEntity : class
    {

        DBContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericoRepository(DBContext context)
        {
            _context = context;
            //para diminuir um pouco o reúso de código
            _dbSet = _context.Set<TEntity>();
        }

        public void Create(TEntity model)
        {
            _dbSet.Add(model);
            _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            try
            {
                var item = await _dbSet.FindAsync(id);
                if (item == null)
                {
                    throw new Exception("id não encontrado!");
                }

                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.ToList();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        //tratar melhor isso
        public void Update(TEntity model)
        {
            _dbSet.Entry(model).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}
