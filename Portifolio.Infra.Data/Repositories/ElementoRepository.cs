using Portifolio.Domain.Entities;
using Portifolio.Infra.Data.Interfaces;
using Portifolio.Domain.Services;

namespace Portifolio.Infra.Data.Repositories
{
    public class ElementoRepository : IElementoRepository
    {

        private List<Elemento> ElementosQueue = new();

        //organizo a lista e insiro na listaFila 
        public void Create(List<Elemento> elementos)
        {
            elementos = ListaService.OrganizarLista(elementos);

            for (int i = 0; i < elementos.Count; i++)
            {
                //travo para evitar problemas ao gravar na lista simultaneo
                lock (ElementosQueue)
                {
                     ElementosQueue.Add(elementos[i]);
                }
                
            }
        }

        public List<Elemento> GetAll()
        {
            return ElementosQueue;
        }


    }


}

