using Portifolio.Domain.Entities;


namespace Portifolio.Infra.Data.Context
{
    public class ElementosQueue
    {
        public static Dictionary<int, Dictionary<int, Elemento>> fila = new();
        public static int indiceFIFO = 0;
    }
}
