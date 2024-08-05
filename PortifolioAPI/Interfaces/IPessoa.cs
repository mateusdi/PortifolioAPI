
using PortifolioAPI.Models;

namespace PortifolioAPI.Interfaces
{
    public interface IPessoa
    {
        void Create(Pessoa pessoa);
        Task<List<Pessoa>> GetAllAsync();
        Task<Pessoa> GetByIdAsync(int id);
        void Update(Pessoa pessoa);
        void Delete(int id);
        

    }
}
