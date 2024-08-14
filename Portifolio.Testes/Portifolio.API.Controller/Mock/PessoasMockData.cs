using Portifolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio.Testes.Portifolio.API.Controller.Mock
{
    public class PessoasMockData
    {
        public static List<Pessoa> GetPessoas()
        {
            return new List<Pessoa>{
                new Pessoa{
                    id = 1,
                    nome = "mateus",
                    email = "mateus@gmail.com"
                },
                new Pessoa{
                    id = 2,
                    nome = "joao",
                    email = "joao@gmail.com"
                },
                new Pessoa{
                    id = 3,
                    nome = "igor",
                    email = "igor@gmail.com"
                },
            };
        }
    }
}
