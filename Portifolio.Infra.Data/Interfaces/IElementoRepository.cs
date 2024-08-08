using Portifolio.Domain.Entities;


namespace Portifolio.Infra.Data.Interfaces
{
    public interface IElementoRepository
    {
        List<Elemento> Create(List<Elemento> elemento);

    }
}
