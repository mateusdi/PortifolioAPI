using Portifolio.Domain.Entities;
using Portifolio.Infra.Data.Interfaces;
using Portifolio.Domain.Services;
using Portifolio.Infra.Data.Context;

namespace Portifolio.Infra.Data.Repositories
{
    public class ElementoRepository : IElementoRepository
    {

        int countCircular = 0;

        //uma list de dicionario

        //organizo a lista e insiro na listaFila 
        public Task Create(Elemento elemento)
        {
            //vou ter que buscar a qual fila o elemento pertence, caso n tenho nenhuma criar
           BuscaGrupo(elemento);
            
            lock (ElementosQueue.fila)
            {
                //insiro o novo elemento na lista pelo index da key no dicionario e na lista
                ElementosQueue.fila[elemento.tipo].Add(ElementosQueue.indiceFIFO, elemento);
                ElementosQueue.indiceFIFO++;
            }
            return Task.FromResult(ElementosQueue.fila);
        }

        public Task Delete() {
            //remoção circular teria q ser um dicionary dentro de outro, no segundo dictionari a key seria a ordem de inserção

            //calcular quantos tipos tenho, e quantos itens
            int linha = ElementosQueue.fila.Count;
            //a coluna é o valor do count
            lock (ElementosQueue.fila)
            {
                //verificar é o ultimo elemento,caso seja remove a linha inteiro do dictionary
                //posso procurar onde está o valor do count
                ElementosQueue.fila[linha].Remove();     
                
            }
            return Task.FromResult(ElementosQueue.fila);
        }

        public Dictionary<int, int> ProcuraItem(int indiceFIFO)
        {
            var myDict = new Dictionary<int, int>();

            foreach (var elementoFila in ElementosQueue.fila)
            {
                foreach (var itemFila in ElementosQueue.fila[elementoFila.Key])
                {
                    if(itemFila.Key == indiceFIFO)
                    {
                        myDict.Add(elementoFila.Key, itemFila.Key);   
                        return myDict;
                    }
                }
            }
            return myDict;
        }

            public int BuscaGrupo(Elemento elemento) {

            lock (ElementosQueue.fila)
            {
                //se tem grupo
                foreach (var elementoFila in ElementosQueue.fila)
                {
                    if (elementoFila.Key == elemento.tipo)
                    {
                        return elementoFila.Key;//ToList();
                    }       
                }
                //caso não tenha grupo, crio um novo e retorno
                AddGrupo(elemento);
            }
            return elemento.tipo;
        }

        public void AddGrupo(Elemento elemento)
        {
            ElementosQueue.fila.Add(elemento.tipo, new Dictionary<int, Elemento>());
        }
    }


}

