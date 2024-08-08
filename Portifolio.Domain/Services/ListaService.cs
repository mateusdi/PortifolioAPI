using Portifolio.Domain.Entities;

namespace Portifolio.Domain.Services
{
    public class ListaService
    {
        //não usar o Sort para organizar a lista, fazer manualmente como os Incas
        public static List<Elemento> OrganizarLista(List<Elemento> lista)
        {
            Elemento elementoAuxiliar;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    //verifico se n é o ultimo elemento da lista, para n der indexofbound
                    if (j < (lista.Count - 1))
                    {
                        //verfico se o próximo é menor que o anterior
                        if (lista[j + 1].tipo < lista[j].tipo)
                        {// se for eu troco eles
                            elementoAuxiliar = lista[j];
                            lista[j] = lista[j + 1];
                            lista[j + 1] = elementoAuxiliar;
                        }
                    }
                }
            }
            return lista;
        }

    }
}
