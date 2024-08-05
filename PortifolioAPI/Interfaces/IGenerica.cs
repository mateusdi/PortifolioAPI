

namespace PortifolioAPI.Interfaces
{
    public interface IGenerica<T> where T : class
    {
        void Create(T model);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Update(T model);
        void Delete(int id);
    }
}
