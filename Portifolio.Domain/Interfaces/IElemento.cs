using Portifolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio.Domain.Interfaces
{
    public interface IElemento
    {
        void Create(Elemento elemento);

        public List<Elemento> GetAll();
    }
}
