using Portifolio.Domain.Entities;

namespace Portifolio.Application.Services
{
    public class ListaService
    {
        public static List<Elemento> OrganizarLista(List<Elemento> lista)
        {
            List<Elemento> ListaAuxiliar = lista;

            var tamanhoLista = lista.Count;
            Elemento elementoAuxiliar;
            for (int i = 0; i < tamanhoLista; i++)
            {
                for (int j = 0; j < tamanhoLista; j++)
                {
                    //verifico se n é o ultimo elemento da lista, para n der indexofbound
                    if (j < (tamanhoLista - 1))
                    {
                        //verfico se o próximo é menor que o anterior
                        if (ListaAuxiliar[j + 1].tipo < ListaAuxiliar[j].tipo)
                        {// se for eu troco eles
                            elementoAuxiliar = ListaAuxiliar[j];
                            ListaAuxiliar[j] = ListaAuxiliar[j + 1];
                            ListaAuxiliar[j + 1] = elementoAuxiliar;
                        }
                    }
                }
            }

            return ListaAuxiliar;
        }

    }
}
