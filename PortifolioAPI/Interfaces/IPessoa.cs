using PortifolioAPI.Model;

namespace PortifolioAPI.Interfaces
{
    public interface IPessoa
    {
        void Add(Pessoa pessoa);
        List<Pessoa> Get();
    }
}
