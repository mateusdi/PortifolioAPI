using Portifolio.Domain.Entities;

namespace Portifolio.Domain.Interfaces
{
    public interface IPessoa
    {
        Task<Pessoa> Create(Pessoa pessoa);
        Task<List<Pessoa>> GetAllAsync();
        Task<Pessoa> GetByIdAsync(int id);
        Task Update(int id, Pessoa pessoa);
        Task Delete(int id);
    }
}
