using PortifolioAPI.Model;

namespace PortifolioAPI.Models
{
    public interface IPessoa
    {
        void Add(Pessoa pessoa);
        List<Pessoa> Get();
    }
}
