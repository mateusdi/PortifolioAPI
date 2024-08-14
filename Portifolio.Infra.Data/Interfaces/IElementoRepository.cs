using Portifolio.Domain.Entities;

namespace Portifolio.Infra.Data.Interfaces
{
    public interface IElementoRepository
    {
        Task Create(Elemento elemento);
    }
}
