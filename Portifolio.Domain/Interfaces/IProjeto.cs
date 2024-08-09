

using Portifolio.Domain.Entities;

namespace Portifolio.Domain.Interfaces
{
    public interface IProjeto
    {
        Task Create(Projeto Projeto);
        Task<List<Projeto>> GetAllAsync();
        Task<Projeto> GetByIdAsync(int id);
        Task Update(int id, Projeto Projeto);
        Task Delete(int id);
    }
}
