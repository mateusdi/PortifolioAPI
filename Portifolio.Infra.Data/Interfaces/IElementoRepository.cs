using Portifolio.Domain.Entities;


namespace Portifolio.Infra.Data.Interfaces
{
    public interface IElementoRepository
    {
        void Create(List<Elemento> elemento);

    }
}
