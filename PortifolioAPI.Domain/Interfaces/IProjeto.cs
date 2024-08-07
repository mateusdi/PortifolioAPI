

using Portifolio.Domain.Entities;

namespace Portifolio.Domain.Interfaces
{
    public interface IProjeto
    {
        void Create(Projeto Projeto);
        Task<List<Projeto>> GetAllAsync();
        Task<Projeto> GetByIdAsync(int id);
        void Update(Projeto Projeto);
        void Delete(int id);
    }
}
