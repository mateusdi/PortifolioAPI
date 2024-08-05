using Microsoft.EntityFrameworkCore;
using PortifolioAPI.infrastructure;
using PortifolioAPI.Interfaces;

namespace PortifolioAPI.Repositories
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
                var todoItem = await _dbSet.FindAsync(id);
                if (todoItem == null)
                {
                    throw new Exception("id não encontrado!");
                }

                _dbSet.Remove(todoItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) {
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

        public void Update(TEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
